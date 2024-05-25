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
    public class YOLOv10Det : YOLO
    {
        public YOLOv10Det(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
            new List<string> { "images" }, new List<int[]> { new int[] { 1, 4 + categ_nums, 8400 } }, new List<string> { "output0" })
        {
        }

        protected override BaseResult postprocess(List<float[]> results)
        {
            List<Rect> positionBoxes = new List<Rect>();
            List<int> classIds = new List<int>();
            List<float> confidences = new List<float>();

            // Preprocessing output results
            for (int i = 0; i < results[0].Length / 6; i++)
            {
                int s = 6 * i;
                if ((float)results[0][s + 4] > 0.5)
                {
                    float cx = results[0][s + 0];
                    float cy = results[0][s + 1];
                    float dx = results[0][s + 2];
                    float dy = results[0][s + 3];
                    int x = (int)((cx) * m_factor);
                    int y = (int)((cy) * m_factor);
                    int width = (int)((dx - cx) * m_factor);
                    int height = (int)((dy - cy) * m_factor);
                    Rect box = new Rect();
                    box.X = x;
                    box.Y = y;
                    box.Width = width;
                    box.Height = height;

                    positionBoxes.Add(box);
                    classIds.Add((int)results[0][s + 5]);
                    confidences.Add((float)results[0][s + 4]);
                }
            }
            DetResult re = new DetResult();
            // 
            for (int i = 0; i < positionBoxes.Count; i++)
            {
                re.add(classIds[i], confidences[i], positionBoxes[i]);
            }
            return re;
        }
    }
}
