using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Dnn;

namespace ResultSharp
{
    public class DetectionResult: ResultBase
    {
        public DetectionResult(string path, float[] scales, float score_threshold=0.25f, float nms_threshold=0.5f) {
            read_class_names(path);
            this.scales = scales;
            this.score_threshold = score_threshold;
            this.nms_threshold = nms_threshold;
        }

        public Result process_result(float[] result)
        {
            Mat result_data = new Mat(84, 8400, MatType.CV_32F, result);
            result_data = result_data.T();

            // 存放结果list
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            // 预处理输出结果
            for (int i = 0; i < result_data.Rows; i++)
            {
                // 获取置信值
                //float confidence = result_data.At<float>(i, 4);
                //if (confidence < this.score_threshold)
                //{
                //    continue;
                //}
                //Console.WriteLine(confidence);

                Mat classes_scores = result_data.Row(i).ColRange(4, 84);//GetArray(i, 5, classes_scores);
                Point max_classId_point, min_classId_point;
                double max_score, min_score;
                // 获取一组数据中最大值及其位置
                Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                    out min_classId_point, out max_classId_point);
                // 置信度 0～1之间
                // 获取识别框信息
                if (max_score > 0.25)
                {
                    //Console.WriteLine(max_score);
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
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
                }
            }

            // NMS非极大值抑制
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out indexes);

            Result re_result= new Result();
            // 将识别结果绘制到图片上
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                int idx = class_ids[index];
                re_result.add(confidences[index], position_boxes[index], this.class_names[class_ids[index]]);
            }
            return re_result;
        }
        public Mat draw_result(Result result, Mat image) {

            // 将识别结果绘制到图片上
            for (int i = 0; i < result.length; i++)
            {
                //Console.WriteLine(result.rects[i]);
                Cv2.Rectangle(image, result.rects[i], new Scalar(0, 0, 255), 2, LineTypes.Link8);
                Cv2.Rectangle(image, new Point(result.rects[i].TopLeft.X, result.rects[i].TopLeft.Y - 20),
                    new Point(result.rects[i].BottomRight.X, result.rects[i].TopLeft.Y), new Scalar(0, 255, 255), -1);
                Cv2.PutText(image, result.classes[i] + "-" + result.scores[i].ToString("0.00"),
                    new Point(result.rects[i].X, result.rects[i].Y - 10),
                    HersheyFonts.HersheySimplex, 0.6, new Scalar(0, 0, 0), 1);
            }
            return image;
        }

    }
}
