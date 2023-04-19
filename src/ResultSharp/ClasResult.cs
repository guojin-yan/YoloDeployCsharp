using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class ClasResult:ResultBase
    {
        /// <summary>
        /// 分类结果构造函数
        /// </summary>
        /// <param name="path">类别文件</param>
        public ClasResult(string path)
        {
            read_class_names(path);
        }
        /// <summary>
        /// 结果处理
        /// </summary>
        /// <param name="result">模型输出结果</param>
        /// <returns>识别结果与分数</returns>
        public KeyValuePair<string, float> process_result(float[] result) {
            int clas = 0;
            float score = result[0];
            for (int i = 0; i < result.Length; i++)
            {
                float temp = result[i];
                if (score <= temp)
                {
                    score = temp;
                    clas = i;
                }
            }
            return  new KeyValuePair<string, float>(this.class_names[clas], score);
        }
        /// <summary>
        /// 绘制识别结果
        /// </summary>
        /// <param name="result">识别结果</param>
        /// <param name="image"></param>
        /// <returns></returns>
        public Mat draw_result(KeyValuePair<string, float> result, Mat image)
        {
            Cv2.PutText(image, result.Key + ":  " + result.Value.ToString("0.00"),
                                new Point(25,30), HersheyFonts.HersheySimplex, 1, new Scalar(0, 0, 255), 2);
            return image;
        }
    }
}

