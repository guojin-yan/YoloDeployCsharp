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
    public class YOLOv8Pose : YOLO
    {
        public YOLOv8Pose(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
            new List<string> { "images" }, new List<int[]> { new int[] { 1, 56, 8400 } }, new List<string> { "output0" })
        {
        }

        protected override BaseResult postprocess(List<float[]> results)
        {
            Mat result_data = new Mat(this.m_output_sizes[0][1], this.m_output_sizes[0][2], MatType.CV_32FC1, results[0]);
            result_data = result_data.T();
            List<Rect> position_boxes = new List<Rect>();
            List<float> confidences = new List<float>();
            List<PosePoint> pose_datas = new List<PosePoint>();
            for (int i = 0; i < result_data.Rows; i++)
            {
                if (result_data.At<float>(i, 4) > 0.25)
                {
                    //Console.WriteLine(max_score);
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
                    int x = (int)((cx - 0.5 * ow) * this.m_factor);
                    int y = (int)((cy - 0.5 * oh) * this.m_factor);
                    int width = (int)(ow * this.m_factor);
                    int height = (int)(oh * this.m_factor);
                    Rect box = new Rect();
                    box.X = x;
                    box.Y = y;
                    box.Width = width;
                    box.Height = height;
                    Mat pose_mat = new Mat(result_data, new Rect(5, i, 51, 1));//result_data.Row(i).ColRange(5, 56);
                    IntPtr pt = pose_mat.Data;
                    float[] pose_data = new float[51];
                    Marshal.Copy(pt, pose_data, 0, pose_data.Length);
                    PosePoint pose = new PosePoint(pose_data, this.m_factor);

                    position_boxes.Add(box);

                    confidences.Add((float)result_data.At<float>(i, 4));
                    pose_datas.Add(pose);
                }
            }

            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.m_det_thresh, this.m_det_nms_thresh, out indexes);

            PoseResult re = new PoseResult();
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                re.add(confidences[index], position_boxes[index], pose_datas[index]);
                //Console.WriteLine("rect: {0}, score: {1}", position_boxes[index], confidences[index]);
            }
            return re;
        }
    }
}
