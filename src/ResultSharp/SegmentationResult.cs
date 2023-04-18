using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class SegmentationResult: ResultBase
    {
        public SegmentationResult(string path, float[] scales, float score_threshold = 0.25f, float nms_threshold = 0.5f)
        {
            read_class_names(path);
            this.scales = scales;
            this.score_threshold = score_threshold;
            this.nms_threshold = nms_threshold;
        }

        private float sigmoid(float a)
        {
            float b = 1.0f / (1.0f + (float)Math.Exp(-a));
            return b;
        }

        public Result process_resule(float[] detect, float[] proto)
        {
            Mat detect_data = new Mat(116, 8400, MatType.CV_32F, detect);
            Mat proto_data = new Mat(32, 25600, MatType.CV_32F, proto);
            detect_data = detect_data.T();

            // 存放结果list
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            List<Mat> masks = new List<Mat>();
            // 预处理输出结果
            for (int i = 0; i < detect_data.Rows; i++)
            {

                Mat classes_scores = detect_data.Row(i).ColRange(4, 84);//GetArray(i, 5, classes_scores);
                Point max_classId_point, min_classId_point;
                double max_score, min_score;
                // 获取一组数据中最大值及其位置
                Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                    out min_classId_point, out max_classId_point);
                // 置信度 0～1之间
                // 获取识别框信息
                if (max_score > 0.25)
                {
                    Console.WriteLine(max_score);

                    Mat mask = detect_data.Row(i).ColRange(84, 116);

                    float cx = detect_data.At<float>(i, 0);
                    float cy = detect_data.At<float>(i, 1);
                    float ow = detect_data.At<float>(i, 2);
                    float oh = detect_data.At<float>(i, 3);
                    int x = (int)((cx - 0.5 * ow) * this.scales[0]);
                    int y = (int)((cy - 0.5 * oh) * this.scales[1]);
                    int width = (int)(ow * this.scales[0]);
                    int height = (int)(oh * this.scales[1]);
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

            // NMS非极大值抑制
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out indexes);

            Result re_result = new Result(); // 输出结果类
            // 带有颜色的RGB图像
            Mat rgb_mask = Mat.Zeros(new Size((int)scales[3], (int)scales[2]), MatType.CV_8UC3);
            Random rd = new Random(); // 产生随机数
            // 识别结果
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                // 分割范围
                Rect box = position_boxes[index];
                int box_x1 = Math.Max(0, box.X);
                int box_y1 = Math.Max(0, box.Y);
                int box_x2 = Math.Max(0, box.BottomRight.X);
                int box_y2 = Math.Max(0, box.BottomRight.Y);

                // 分割结果
                Mat original_mask = masks[index] * proto_data;
                for (int col = 0; col < original_mask.Cols; col++)
                {
                    original_mask.At<float>(0, col) = sigmoid(original_mask.At<float>(0, col));
                }
                // 1x25600 -> 160x160 转为原始大小
                Mat reshape_mask = original_mask.Reshape(1, 160);

                //Console.WriteLine("m1.size = {0}", m1.Size());

                // 缩放后分割大小
                int mx1 = Math.Max(0, (int)((box_x1 / scales[0]) * 0.25));
                int mx2 = Math.Max(0, (int)((box_x2 / scales[0]) * 0.25));
                int my1 = Math.Max(0, (int)((box_y1 / scales[1]) * 0.25));
                int my2 = Math.Max(0, (int)((box_y2 / scales[1]) * 0.25));
                // 裁剪分割区域
                Mat mask_roi = new Mat(reshape_mask,new OpenCvSharp.Range(my1, my2), new OpenCvSharp.Range(mx1, mx2));
                // 将分割区域转换到图片实际大小
                Mat actual_maskm = new Mat();
                Cv2.Resize(mask_roi, actual_maskm, new Size(box_x2 - box_x1, box_y2 - box_y1));
                // 二值化分割区域
                for (int r = 0; r < actual_maskm.Rows; r++)
                {
                    for (int c = 0; c < actual_maskm.Cols; c++)
                    {
                        float pv = actual_maskm.At<float>(r, c);
                        if (pv > 0.5)
                        {
                            actual_maskm.At<float>(r, c) = 1.0f;
                        }
                        else
                        {
                            actual_maskm.At<float>(r, c) = 0.0f;
                        }
                    }
                }

                // 预测
                Mat bin_mask = new Mat();
                actual_maskm = actual_maskm * 200;
                actual_maskm.ConvertTo(bin_mask, MatType.CV_8UC1);
                if ((box_y1 + bin_mask.Rows) >= scales[2])
                {
                    box_y2 = (int)scales[2] - 1;
                }
                if ((box_x1 + bin_mask.Cols) >= scales[3])
                {
                    box_x2 = (int)scales[3] - 1;
                }
                // 获取分割区域
                Mat mask = Mat.Zeros(new Size((int)scales[3], (int)scales[2]), MatType.CV_8UC1);
                bin_mask = new Mat(bin_mask, new OpenCvSharp.Range(0, box_y2 - box_y1), new OpenCvSharp.Range(0, box_x2 - box_x1));
                Rect roi = new Rect(box_x1, box_y1, box_x2 - box_x1, box_y2 - box_y1);
                bin_mask.CopyTo(new Mat( mask,roi));
                // 分割区域上色
                Cv2.Add(rgb_mask, new Scalar(rd.Next(0,255), rd.Next(0, 255), rd.Next(0, 255)), rgb_mask, mask);

                re_result.add(confidences[index], position_boxes[index], this.class_names[class_ids[index]],rgb_mask.Clone());

            }

            return re_result;
        }

        public Mat draw_result(Result result, Mat image)
        {
            Mat masked_img = new Mat();
            // 将识别结果绘制到图片上
            for (int i = 0; i < result.length; i++)
            {
                Cv2.Rectangle(image, result.rects[i], new Scalar(0, 0, 255), 2, LineTypes.Link8);
                Cv2.Rectangle(image, new Point(result.rects[i].TopLeft.X, result.rects[i].TopLeft.Y - 20),
                    new Point(result.rects[i].BottomRight.X, result.rects[i].TopLeft.Y), new Scalar(0, 255, 255), -1);
                Cv2.PutText(image, result.classes[i] + "-" + result.scores[i].ToString("0.00"),
                    new Point(result.rects[i].X, result.rects[i].Y - 10),
                    HersheyFonts.HersheySimplex, 0.6, new Scalar(0, 0, 0), 1);
                Cv2.AddWeighted(image, 0.5, result.masks[i], 0.5, 0, masked_img);
            }
            return masked_img;
        }
    }
}
