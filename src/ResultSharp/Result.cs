using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class Result
    {
        // 获取结果长度
        public int length 
        { get 
            { 
                return scores.Count;
            } 
        }

        // 识别结果类
        public List<string> classes = new List<string>();
        // 置信值
        public List<float> scores = new List<float>();
        // 预测框
        public List<Rect> rects = new List<Rect>();
        public List<Mat> masks = new List<Mat>();

        public void add(float score, Rect rect, string cla) {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
        }
        public void add(float score, Rect rect, string cla, Mat mask)
        {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
            masks.Add(mask);
        }
    }
}
