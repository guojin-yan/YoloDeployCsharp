using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp.Dnn;
using OpenCvSharp;
using OpenVinoSharp;
using System.Diagnostics;

namespace yolo_openvino_demo
{
    internal class TimeTest
    {
        public static void test(string model_path, string image_path, string device) {
            Core core = new Core();
            Model model = core.read_model(model_path);
            CompiledModel compiled_model = core.compile_model(model, device);
            InferRequest infer_request = compiled_model.create_infer_request();
  
            Mat image = new Mat(image_path); // Read image by opencvsharp
            int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
            Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
            image.CopyTo(new Mat(max_image, roi));
            float factor = (float)(max_image_length / 640.0);

            Tensor input_tensor = infer_request.get_input_tensor();
            Shape input_shape = input_tensor.get_shape();
            Mat input_mat = CvDnn.BlobFromImage(max_image, 1.0 / 255.0, new OpenCvSharp.Size(input_shape[2], input_shape[3]), new Scalar(), true, false);
            float[] input_data = new float[input_shape[1] * input_shape[2] * input_shape[3]];
            Marshal.Copy(input_mat.Ptr(0), input_data, 0, input_data.Length);
            input_tensor.set_data<float>(input_data);


            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 100; i++) {
                infer_request.infer();
            }
            sw.Stop();

            Console.WriteLine("平均推理速度为：" + sw.Elapsed.TotalMilliseconds/100.0 + " ms");


        }
    }
}
