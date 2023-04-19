using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class PoseResult:ResultBase
    {
        public PoseResult( float[] scales, float score_threshold = 0.25f, float nms_threshold = 0.5f)
        {
            this.scales = scales;
            this.score_threshold = score_threshold;
            this.nms_threshold = nms_threshold;
        }
        public Result process_result(float[] result) 
        {
            Mat result_data = new Mat(56, 8400, MatType.CV_32F, result);
            result_data = result_data.T();
            // 存放结果list
            List<Rect> position_boxes = new List<Rect>();
            List<float> confidences = new List<float>();
            List<PoseData> pose_datas = new List<PoseData>();
            // 预处理输出结果
            for (int i = 0; i < result_data.Rows; i++)
            {

 
                // 获取识别框和关键点信息
                if (result_data.At<float>(i, 4) > 0.25)
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
                    Mat pose_mat= result_data.Row(i).ColRange(5, 56);
                    float[] pose_data = new float[51];
                    pose_mat.GetArray<float>(out pose_data);
                    PoseData pose = new PoseData(pose_data, this.scales);

                    position_boxes.Add(box);

                    confidences.Add((float)result_data.At<float>(i, 4));
                    pose_datas.Add(pose);
                }
            }

            // NMS非极大值抑制
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out indexes);

            Result re_result = new Result();
            // 将识别结果绘制到图片上
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                re_result.add(confidences[index], position_boxes[index], pose_datas[i]);
                Console.WriteLine("rect: {0}, score: {1}", position_boxes[index], confidences[index]);
            }
            return re_result;

        }

        public Mat draw_result(Result result, Mat image)
        {

            // 将识别结果绘制到图片上
            for (int i = 0; i < result.length; i++)
            {
                //Console.WriteLine(result.rects[i]);
                Cv2.Rectangle(image, result.rects[i], new Scalar(0, 0, 255), 2, LineTypes.Link8);
                Cv2.Rectangle(image, new Point(result.rects[i].TopLeft.X, result.rects[i].TopLeft.Y - 20),
                    new Point(result.rects[i].BottomRight.X, result.rects[i].TopLeft.Y), new Scalar(0, 255, 255), -1);
                Cv2.PutText(image, "person -" + result.scores[i].ToString("0.00"),
                    new Point(result.rects[i].X, result.rects[i].Y - 10),
                    HersheyFonts.HersheySimplex, 0.6, new Scalar(0, 0, 0), 1);
                draw_poses(result.poses[i], ref image);
            }
            return image;
        }

        public void draw_poses(PoseData pose, ref Mat image)
        {
            // 连接点关系
            int[,] edgs = new int[17, 2] { { 0, 1 }, { 0, 2}, {1, 3}, {2, 4}, {3, 5}, {4, 6}, {5, 7}, {6, 8},
                 {7, 9}, {8, 10}, {5, 11}, {6, 12}, {11, 13}, {12, 14},{13, 15 }, {14, 16 }, {11, 12 } };
            // 颜色库
            Scalar[] colors = new Scalar[18] { new Scalar(255, 0, 0), new Scalar(255, 85, 0), new Scalar(255, 170, 0),
                new Scalar(255, 255, 0), new Scalar(170, 255, 0), new Scalar(85, 255, 0), new Scalar(0, 255, 0),
                new Scalar(0, 255, 85), new Scalar(0, 255, 170), new Scalar(0, 255, 255), new Scalar(0, 170, 255),
                new Scalar(0, 85, 255), new Scalar(0, 0, 255), new Scalar(85, 0, 255), new Scalar(170, 0, 255),
                new Scalar(255, 0, 255), new Scalar(255, 0, 170), new Scalar(255, 0, 85) };
            // 绘制阈值
            double visual_thresh = 0.4;
            // 绘制关键点
            for (int p = 0; p < 17; p++)
            {
                if (pose.score[p] < visual_thresh)
                {
                    continue;
                }
                
                Cv2.Circle(image, pose.point[p], 2, colors[p], -1);
            }
            // 绘制
            for (int p = 0; p < 17; p++)
            {
                if (pose.score[edgs[p, 0]] < visual_thresh || pose.score[edgs[p, 1]] < visual_thresh)
                {
                    continue;
                }

                float[] point_x = new float[] { pose.point[edgs[p, 0]].X, pose.point[edgs[p, 1]].X };
                float[] point_y = new float[] { pose.point[edgs[p, 0]].Y, pose.point[edgs[p, 1]].Y };

                Point center_point = new Point((int)((point_x[0] + point_x[1]) / 2), (int)((point_y[0] + point_y[1]) / 2));
                double length = Math.Sqrt(Math.Pow((double)(point_x[0] - point_x[1]), 2.0) + Math.Pow((double)(point_y[0] - point_y[1]), 2.0));
                int stick_width = 2;
                Size axis = new Size(length / 2, stick_width);
                double angle = (Math.Atan2((double)(point_y[0] - point_y[1]), (double)(point_x[0] - point_x[1]))) * 180 / Math.PI;
                Point[] polygon = Cv2.Ellipse2Poly(center_point, axis, (int)angle, 0, 360, 1);
                Cv2.FillConvexPoly(image, polygon, colors[p]);

            }
        }
    }
}
