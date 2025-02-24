using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp;
using static System.Formats.Asn1.AsnWriter;

namespace yolo_openvino_demo
{
    internal class YoloDet
    {
        public static void predict(string model_path, string image_path, string device)
        {
            DateTime start = DateTime.Now;
            // -------- Step 1. Initialize OpenVINO Runtime Core --------
            Core core = new Core();
            DateTime end = DateTime.Now;
            Console.WriteLine("1. Initialize OpenVINO Runtime Core success, time spend: " + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 2. Read inference model --------
            start = DateTime.Now;
            Model model = core.read_model(model_path);
            end = DateTime.Now;
            Console.WriteLine("2. Read inference model success, time spend: " + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 3. Loading a model to the device --------
            start = DateTime.Now;
            CompiledModel compiled_model = core.compile_model(model, device);
            end = DateTime.Now;
            Console.WriteLine("3. Loading a model to the device success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 4. Create an infer request --------
            start = DateTime.Now;
            InferRequest infer_request = compiled_model.create_infer_request();
            end = DateTime.Now;
            Console.WriteLine("4. Create an infer request success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 5. Process input images --------
            start = DateTime.Now;
            Mat image = new Mat(image_path); // Read image by opencvsharp
            int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
            Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
            image.CopyTo(new Mat(max_image, roi));
            float factor = (float)(max_image_length / 640.0);
            end = DateTime.Now;
            Console.WriteLine("5. Process input images success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 6. Set up input data --------
            start = DateTime.Now;
            Tensor input_tensor = infer_request.get_input_tensor();
            Shape input_shape = input_tensor.get_shape();
            Mat input_mat = CvDnn.BlobFromImage(max_image, 1.0 / 255.0, new OpenCvSharp.Size(input_shape[2], input_shape[3]), new Scalar(), true, false);
            float[] input_data = new float[input_shape[1] * input_shape[2] * input_shape[3]];
            Marshal.Copy(input_mat.Ptr(0), input_data, 0, input_data.Length);
            input_tensor.set_data<float>(input_data);

            end = DateTime.Now;
            Console.WriteLine("6. Set up input data success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 7. Do inference synchronously --------
            infer_request.infer();
            start = DateTime.Now;
            infer_request.infer();
            end = DateTime.Now;
            Console.WriteLine("7. Do inference synchronously success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            // -------- Step 8. Get infer result data --------
            start = DateTime.Now;
            Tensor output_tensor = infer_request.get_output_tensor();
            int output_length = (int)output_tensor.get_size();
            float[] output_data = output_tensor.get_data<float>(output_length);
            end = DateTime.Now;
            Console.WriteLine("8. Get infer result data success, time spend:" + (end - start).TotalMilliseconds + "ms.");

            // -------- Step 9. Process reault  --------
            start = DateTime.Now;
            // Storage results list
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            // Preprocessing output results
            for (int i = 0; i < 8400; i++)
            {
                for (int j = 4; j < 84; j++)
                {
                    float conf = output_data[8400 * j + i];
                    int label = j - 4;
                    if (conf > 0.2)
                    {
                        float cx = output_data[8400 * 0 + i];
                        float cy = output_data[8400 * 1 + i];
                        float ow = output_data[8400 * 2 + i];
                        float oh = output_data[8400 * 3 + i];
                        int x = (int)((cx - 0.5 * ow) * factor);
                        int y = (int)((cy - 0.5 * oh) * factor);
                        int width = (int)(ow * factor);
                        int height = (int)(oh * factor);
                        Rect box = new Rect(x, y, width, height);
                        position_boxes.Add(box);
                        class_ids.Add(label);
                        confidences.Add(conf);
                    }
                }

            }
            // NMS non maximum suppression
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, 0.5f, 0.5f, out indexes);

            end = DateTime.Now;
            Console.WriteLine("9. Process reault  success, time spend:" + (end - start).TotalMilliseconds + "ms.");
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                Cv2.Rectangle(image, position_boxes[index], new Scalar(0, 0, 255), 2, LineTypes.Link8);
                Cv2.Rectangle(image, new OpenCvSharp.Point(position_boxes[index].TopLeft.X, position_boxes[index].TopLeft.Y + 30),
                    new OpenCvSharp.Point(position_boxes[index].BottomRight.X, position_boxes[index].TopLeft.Y), new Scalar(0, 255, 255), -1);
                Cv2.PutText(image, class_ids[index] + "-" + confidences[index].ToString("0.00"),
                    new OpenCvSharp.Point(position_boxes[index].X, position_boxes[index].Y + 25),
                    HersheyFonts.HersheySimplex, 0.8, new Scalar(0, 0, 0), 2);
            }
            string output_path = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(image_path)),
                Path.GetFileNameWithoutExtension(image_path) + "_result.jpg");
            Cv2.ImWrite(output_path, image);
            Console.WriteLine("The result save to " + output_path);
            Cv2.ImShow("Result", image);
            Cv2.WaitKey(0);
        }
    }
  
}
