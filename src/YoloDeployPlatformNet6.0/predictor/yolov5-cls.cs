using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloDeployPlatform.predictor
{
    public class YOLOv5Cls : YOLO
    {
        public YOLOv5Cls(string model_path, EngineType engine, string device, int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
            : base(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, new int[] { 1, 3, input_size, input_size },
                  new List<string> { "images" }, new List<int[]> { new int[] { 1, 1, 1000} }, new List<string> { "output0" })
        {
        }

        protected override BaseResult postprocess(List<float[]> results)
        {
            List<int> sort_result = argsort(new List<float>(results[0]));
            ClsResult result = new ClsResult();
            for (int j = 0; j < m_categ_nums; ++j)
            {
                result.add(sort_result[j], results[0][sort_result[j]]);
            }
            return result;
        }


        private List<int> argsort(List<float> array)
        {
            int array_len = array.Count;
            //生成值和索引的列表
            List<float[]> new_array = new List<float[]> { };
            for (int i = 0; i < array_len; i++)
            {
                new_array.Add(new float[] { array[i], i });
            }
            //对列表按照值大到小进行排序
            new_array.Sort((a, b) => b[0].CompareTo(a[0]));
            //获取排序后的原索引
            List<int> array_index = new List<int>();
            foreach (float[] item in new_array)
            {
                array_index.Add((int)item[1]);
            }
            return array_index;
        }
    }
}
