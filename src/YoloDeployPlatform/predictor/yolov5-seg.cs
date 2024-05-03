using OpenCvSharp.Dnn;
using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public class YOLOv5Seg : YOLO
    {
        public YOLOv5Seg(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
                  new List<string> { "images" }, new List<int[]> { new int[] { 1, 25200, 37 + categ_nums }, new int[] { 1, 32, 25600 } }, 
                  new List<string> { "output0", "output1" })
        {
        }
        protected override BaseResult postprocess(List<float[]> results) 
        {
            Mat detect_data = new Mat(this.m_output_sizes[0][1], this.m_output_sizes[0][2], MatType.CV_32FC1, results[0]);
            Mat proto_data = new Mat(this.m_output_sizes[1][1], this.m_output_sizes[1][2], MatType.CV_32F, results[1]);
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            List<Mat> masks = new List<Mat>();
            for (int i = 0; i < detect_data.Rows; i++)
            {
                float confidence = detect_data.At<float>(i, 4);
                if (confidence < 0.25)
                {
                    continue;
                }
                Mat classes_scores = new Mat(detect_data, new Rect(5, i, m_categ_nums, 1));
                OpenCvSharp.Point max_classId_point, min_classId_point;
                double max_score, min_score;
                // Obtain the maximum value and its position in a set of data
                Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                    out min_classId_point, out max_classId_point);
                // Confidence level between 0 ~ 1
                // Obtain identification box information
                if (max_score > 0.25)
                {
                    //Console.WriteLine(max_score);

                    Mat mask = new Mat(detect_data, new Rect(5 + m_categ_nums, i, 32, 1));//detect_data.Row(i).ColRange(4 + categ_nums, categ_nums + 36);

                    float cx = detect_data.At<float>(i, 0);
                    float cy = detect_data.At<float>(i, 1);
                    float ow = detect_data.At<float>(i, 2);
                    float oh = detect_data.At<float>(i, 3);
                    int x = (int)((cx - 0.5 * ow) * m_factor);
                    int y = (int)((cy - 0.5 * oh) * m_factor);
                    int width = (int)(ow * m_factor);
                    int height = (int)(oh * m_factor);
                    Rect box = new Rect();
                    box.X = x;
                    box.Y = y;
                    box.Width = width;
                    box.Height = height;

                    position_boxes.Add(box);
                    class_ids.Add(max_classId_point.X);
                    confidences.Add((float)max_score);
                    masks.Add(mask);
                }
            }


            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.m_det_thresh, this.m_det_nms_thresh, out indexes);

            SegResult result = new SegResult();
            Mat rgb_mask = Mat.Zeros(new Size(m_image_size[0], m_image_size[1]), MatType.CV_8UC3);
            Random rd = new Random(); // Generate Random Numbers
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                // Division scope
                Rect box = position_boxes[index];
                int box_x1 = Math.Max(0, box.X);
                int box_y1 = Math.Max(0, box.Y);
                int box_x2 = Math.Max(0, box.BottomRight.X);
                int box_y2 = Math.Max(0, box.BottomRight.Y);

                // Segmentation results
                Mat original_mask = masks[index] * proto_data;
                for (int col = 0; col < original_mask.Cols; col++)
                {
                    original_mask.Set<float>(0, col, sigmoid(original_mask.At<float>(0, col)));
                }
                // 1x25600 -> 160x160 Convert to original size
                Mat reshape_mask = original_mask.Reshape(1, 160);

                //Console.WriteLine("m1.size = {0}", m1.Size());

                // Split size after scaling
                int mx1 = Math.Max(0, (int)((box_x1 / m_factor) * 0.25));
                int mx2 = Math.Min(160, (int)((box_x2 / m_factor) * 0.25));
                int my1 = Math.Max(0, (int)((box_y1 / m_factor) * 0.25));
                int my2 = Math.Min(160, (int)((box_y2 / m_factor) * 0.25));
                // Crop Split Region
                Mat mask_roi = new Mat(reshape_mask, new OpenCvSharp.Range(my1, my2), new OpenCvSharp.Range(mx1, mx2));
                // Convert the segmented area to the actual size of the image
                Mat actual_maskm = new Mat();
                Cv2.Resize(mask_roi, actual_maskm, new Size(box_x2 - box_x1, box_y2 - box_y1));
                // Binary segmentation region
                for (int r = 0; r < actual_maskm.Rows; r++)
                {
                    for (int c = 0; c < actual_maskm.Cols; c++)
                    {
                        float pv = actual_maskm.At<float>(r, c);
                        if (pv > 0.5)
                        {
                            actual_maskm.Set<float>(r, c, 1.0f);
                        }
                        else
                        {
                            actual_maskm.Set<float>(r, c, 0.0f);
                        }
                    }
                }

                // 预测
                Mat bin_mask = new Mat();
                actual_maskm = actual_maskm * 200;
                actual_maskm.ConvertTo(bin_mask, MatType.CV_8UC1);
                if ((box_y1 + bin_mask.Rows) >= m_image_size[1])
                {
                    box_y2 = m_image_size[1] - 1;
                }
                if ((box_x1 + bin_mask.Cols) >= m_image_size[0])
                {
                    box_x2 = m_image_size[0] - 1;
                }
                // Obtain segmentation area
                Mat mask = Mat.Zeros(new Size(m_image_size[0], m_image_size[1]), MatType.CV_8UC1);
                bin_mask = new Mat(bin_mask, new OpenCvSharp.Range(0, box_y2 - box_y1), new OpenCvSharp.Range(0, box_x2 - box_x1));
                Rect roi1 = new Rect(box_x1, box_y1, box_x2 - box_x1, box_y2 - box_y1);
                bin_mask.CopyTo(new Mat(mask, roi1));
                // Color segmentation area
                Cv2.Add(rgb_mask, new Scalar(rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255)), rgb_mask, mask);
                result.add(class_ids[index], confidences[index], position_boxes[index], rgb_mask.Clone());
            }
            return result;
        }
    }
}
