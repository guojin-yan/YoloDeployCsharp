namespace ResultSharp
{
    public class ResultBase
    {
        // 识别结果类型
        public string[] class_names;
        // 图片信息  缩放比例h, 缩放比例h,,height, width
        public float[] scales;
        // 置信度阈值
        public float score_threshold;
        // 非极大值抑制阈值
        public float nms_threshold;
        public ResultBase() { }
        /// <summary>
        /// 读取本地识别结果类型文件到内存
        /// </summary>
        /// <param name="path">文件路径</param>
        public void read_class_names(string path)
        {

            List<string> str = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                str.Add(line);
            }

            class_names = str.ToArray();
        }

    }
}

