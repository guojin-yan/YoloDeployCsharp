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
        // 分割区域
        public List<Mat> masks = new List<Mat>();
        // 人体关键点
        public List<PoseData> poses = new List<PoseData>();

        /// <summary>
        /// 物体检测
        /// </summary>
        /// <param name="score">预测分数</param>
        /// <param name="rect">识别框</param>
        /// <param name="cla">识别类</param>
        public void add(float score, Rect rect, string cla) {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
        }
        /// <summary>
        /// 物体分割
        /// </summary>
        /// <param name="score">预测分数</param>
        /// <param name="rect">识别框</param>
        /// <param name="cla">识别类</param>
        /// <param name="mask">语义分割结果</param>
        public void add(float score, Rect rect, string cla, Mat mask)
        {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
            masks.Add(mask);
        }
        /// <summary>
        /// 关键点预测
        /// </summary>
        /// <param name="score">预测分数</param>
        /// <param name="rect">识别框</param>
        /// <param name="pose">关键点数据</param>
        public void add(float score, Rect rect, PoseData pose)
        {
            scores.Add(score);
            rects.Add(rect);
            poses.Add(pose);
        }
    }
    /// <summary>
    /// 人体关键点数据
    /// </summary>
    public struct PoseData {
        public float[] score = new float[17];
        public List<Point> point = new List<Point>();

        public PoseData(float[] data, float[] scales) 
        {
            for (int i = 0; i < 17; i++) 
            {
                Point p = new Point((int)(data[3 * i] * scales[0]), (int)(data[3 * i + 1] * scales[1]));
                this.point.Add(p);
                this.score[i] = data[3 * i + 2];
            }
        }
    }
}

