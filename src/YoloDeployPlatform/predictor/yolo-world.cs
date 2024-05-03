using OpenCvSharp.Dnn;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenVinoSharp.Extensions.result;

namespace YoloDeployPlatform.predictor
{
    public class YOLOWorld : YOLO
    {
        public YOLOWorld(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
            new List<string> { "images" }, new List<int[]> { new int[] { 1, 4 + categ_nums, 8400 } }, new List<string> { "output0" })
        {
        }
        protected override BaseResult postprocess(List<float[]> results)
        {
            Mat result_data = new Mat(this.m_output_sizes[0][1], this.m_output_sizes[0][2], MatType.CV_32F, results[0]);
            result_data = result_data.T();

            // Storage results list
            List<Rect> position_boxes = new List<Rect>();
            List<int> classIds = new List<int>();
            List<float> confidences = new List<float>();
            // Preprocessing output results
            for (int i = 0; i < result_data.Rows; i++)
            {
                Mat classesScores = new Mat(result_data, new Rect(4, i, m_categ_nums, 1));
                Point maxClassIdPoint, minClassIdPoint;
                double maxScore, minScore;
                // Obtain the maximum value and its position in a set of data
                Cv2.MinMaxLoc(classesScores, out minScore, out maxScore,
                            out minClassIdPoint, out maxClassIdPoint);
                // Confidence level between 0 ~ 1
                // Obtain identification box information
                if (maxScore > 0.25)
                {
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
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
                    classIds.Add(maxClassIdPoint.X);
                    confidences.Add((float)maxScore);
                }
            }
            // NMS non maximum suppression
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.m_det_thresh, this.m_det_nms_thresh, out indexes);
            DetResult re = new DetResult();
            // 
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                re.add(classIds[index], confidences[index], position_boxes[index]);
            }
            return re;
        }
    }
}
