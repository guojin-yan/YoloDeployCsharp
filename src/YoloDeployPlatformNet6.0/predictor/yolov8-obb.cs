using OpenCvSharp.Dnn;
using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public class YOLOv8Obb : YOLO
    {
        public YOLOv8Obb(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
            new List<string> { "images" }, new List<int[]> { new int[] { 1, 5 + categ_nums, 21504 }}, new List<string> { "output0"})
        {
        }

        protected override BaseResult postprocess(List<float[]> results) 
        {
            Mat result_data = new Mat(this.m_output_sizes[0][1], this.m_output_sizes[0][2], MatType.CV_32FC1,results[0]);
            result_data = result_data.T();

            float[] d = new float[this.m_output_sizes[0][2]];
            result_data.GetArray<float>(out d);

            // Storage results list
            List<Rect2d> position_boxes = new List<Rect2d>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            List<float> rotations = new List<float>();
            // Preprocessing output results
            for (int i = 0; i < result_data.Rows; i++)
            {
                Mat classes_scores = new Mat(result_data, new Rect(4, i, m_categ_nums, 1));
                OpenCvSharp.Point max_classId_point, min_classId_point;
                double max_score, min_score;
                // Obtain the maximum value and its position in a set of data
                Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                    out min_classId_point, out max_classId_point);
                // Confidence level between 0 ~ 1
                // Obtain identification box information
                if (max_score > 0.25)
                {
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
                    double x = (cx - 0.5 * ow) * m_factor;
                    double y = (cy - 0.5 * oh) * m_factor;
                    double width = ow * m_factor;
                    double height = oh * m_factor;
                    Rect2d box = new Rect2d();
                    box.X = x;
                    box.Y = y;
                    box.Width = width;
                    box.Height = height;

                    position_boxes.Add(box);
                    class_ids.Add(max_classId_point.X);
                    confidences.Add((float)max_score);
                    rotations.Add(result_data.At<float>(i, 19));
                }
            }
            // NMS non maximum suppression
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.m_det_thresh, this.m_det_nms_thresh, out indexes);

            List<RotatedRect> rotated_rects = new List<RotatedRect>();
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];

                float w = (float)position_boxes[index].Width;
                float h = (float)position_boxes[index].Height;
                float x = (float)position_boxes[index].X + w / 2;
                float y = (float)position_boxes[index].Y + h / 2;
                float r = rotations[index];
                float w_ = w > h ? w : h;
                float h_ = w > h ? h : w;
                r = (float)((w > h ? r : (float)(r + Math.PI / 2)) % Math.PI);
                RotatedRect rotate = new RotatedRect(new Point2f(x, y), new Size2f(w_, h_), (float)(r * 180.0 / Math.PI));
                rotated_rects.Add(rotate);
            }

            ObbResult re = new ObbResult();
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                re.add(class_ids[index], confidences[index], rotated_rects[i]);
            }
            return re;
        }
    }
}
