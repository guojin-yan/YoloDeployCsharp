using OpenCvSharp;
using OpenVinoSharp.Extensions.model;
using OpenVinoSharp.Extensions.process;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using OpenVinoSharp.Extensions.result;
namespace YoloDeployPlatform.predictor
{
    public class YOLO : IDisposable
    {
        protected int m_categ_nums;
        protected float m_det_thresh;
        protected float m_det_nms_thresh;
        protected float m_factor;
        protected int[] m_input_size;
        protected List<int[]> m_output_sizes;
        protected List<string> m_input_names;
        protected List<string> m_output_names;

        protected List<int> m_image_size = new List<int>();

        private Predictor m_predictor;
        Log m_log =Log.Instance;
        Stopwatch sw = new Stopwatch();
        public YOLO() 
        {
            m_predictor = new Predictor();
        }
        public YOLO(string model_path,EngineType engine, string device, int categ_nums, float det_thresh, 
            float det_nms_thresh, int[] input_size, List<string> input_names, List<int[]> output_sizes, List<string> output_names)
        {
            m_predictor = new Predictor(model_path, engine, device);
            m_categ_nums = categ_nums;
            m_det_thresh = det_thresh;
            m_det_nms_thresh = det_nms_thresh;
            m_input_size = input_size;
            m_output_sizes = output_sizes;
            m_input_names = input_names;
            m_output_names = output_names;
        }
        float[] preprocess(Mat img)
        {
            m_image_size = new List<int> { (int)img.Size().Width, (int)img.Size().Height };
            Mat mat = new Mat();
            Cv2.CvtColor(img, mat, ColorConversionCodes.BGR2RGB);
            mat = Resize.letterbox_img(mat, (int)m_input_size[2], out m_factor);
            mat = Normalize.run(mat, true);
            return Permute.run(mat);
        }

        List<float[]> infer(Mat img) 
        {
            List<float[]> re;
            if (m_log.flag_time)
            {
                sw.Restart();
                float[] data = preprocess(img);
                sw.Stop();
                m_log.print("Input data process successfull, spend time: " + sw.ElapsedMilliseconds + " ms;");
                sw.Restart();
                re = m_predictor.infer(data, m_input_names, m_input_size, m_output_names, m_output_sizes);
                sw.Stop();
                m_log.print("Model infer successfull, spend time: " + sw.ElapsedMilliseconds + " ms;");
                m_log.infer_time = sw.ElapsedMilliseconds;
                m_log.sum_time.Add(sw.ElapsedMilliseconds);
            }
            else
            {
                float[] data = preprocess(img);
                re = m_predictor.infer(data, m_input_names, m_input_size, m_output_names, m_output_sizes);
            }
            return re;
        }


        public BaseResult predict(Mat img)
        {
            List<float[]> result_data = infer(img);
            BaseResult re;
            if (m_log.flag_time)
            {
                sw.Restart();
                re = postprocess(result_data);
                sw.Stop();
                m_log.print("Result data process successfull, spend time: " + sw.ElapsedMilliseconds + " ms;");
            }
            else
            {
                re = postprocess(result_data);
            }
            return re;
        }



        protected virtual BaseResult postprocess(List<float[]> results) 
        {
            return new BaseResult();
        }

        public void Dispose()
        {
            m_predictor.Dispose();
        }

        public static YOLO GetYolo(ModelType model_type, string model_path, EngineType engine, string device,
            int categ_nums, float det_thresh, float det_nms_thresh, int input_size)
        {
            if (model_type == ModelType.YOLOv5Det)
            {
                return new YOLOv5Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv5Seg) 
            {
                return new YOLOv5Seg(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv5Cls)
            {
                return new YOLOv5Cls(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv6Det)
            {
                return new YOLOv6Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv7Det)
            {
                return new YOLOv7Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv8Det)
            {
                return new YOLOv8Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv8Seg)
            {
                return new YOLOv8Seg(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv8Obb)
            {
                return new YOLOv8Obb(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv8Pose)
            {
                return new YOLOv8Pose(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv8Cls)
            {
                return new YOLOv8Cls(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv9Det)
            {
                return new YOLOv9Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv9Seg)
            {
                return new YOLOv9Seg(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOWorld)
            {
                return new YOLOWorld(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else if (model_type == ModelType.YOLOv10Det)
            {
                return new YOLOv10Det(model_path, engine, device, categ_nums, det_thresh, det_nms_thresh, input_size);
            }
            else
            {
                throw new Exception("Model type error");
            }
        }


        protected static float sigmoid(float a)
        {
            float b = 1.0f / (1.0f + (float)Math.Exp(-a));
            return b;
        }
    }
}
