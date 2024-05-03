using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public class YOLOv9Det : YOLOv8Det
    {
        public YOLOv9Det(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size)
        {
        }
    }
}
