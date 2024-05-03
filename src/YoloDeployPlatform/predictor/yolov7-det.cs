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
    public class YOLOv7Det : YOLO
    {
        public YOLOv7Det(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
                  new List<string> { "images" }, new List<int[]> { new int[] { 100, 7 } }, new List<string> { "output" })
        {
        }
        protected override BaseResult postprocess(List<float[]> results)
        {
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            float[] output_data = results[0];
            // Preprocessing output results
            for (int i = 0; i < output_data.Length / 7; i++)
            {
                int s = 7 * i;
                float cx = output_data[s + 1];
                float cy = output_data[s + 2];
                float dx = output_data[s + 3];
                float dy = output_data[s + 4];
                int x = (int)((cx) * m_factor);
                int y = (int)((cy) * m_factor);
                int width = (int)((dx - cx) * m_factor);
                int height = (int)((dy - cy) * m_factor);
                Rect box = new Rect();
                box.X = x;
                box.Y = y;
                box.Width = width;
                box.Height = height;

                position_boxes.Add(box);
                class_ids.Add((int)output_data[s + 5]);
                confidences.Add((float)output_data[s + 6]);
            }
            int[] indexes = new int[position_boxes.Count];
            DetResult re = new DetResult();
            // 
            for (int i = 0; i < indexes.Length; i++)
            {
                re.add(class_ids[i], confidences[i], position_boxes[i]);
            }
            return re;
        }
    }
}
