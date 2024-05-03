using OpenCvSharp.Dnn;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public class YOLOv6Det : YOLOv5Det
    {
        public YOLOv6Det(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size) 
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size)
        {
            this.m_output_sizes = new List<int[]> { new int[] { 1, 8400, 5 + categ_nums } };
            this.m_output_names = new List<string> { "outputs" };
        }
    }
}
