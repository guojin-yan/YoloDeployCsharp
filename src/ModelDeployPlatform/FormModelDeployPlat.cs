using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TensorRTSharp;
using OpenVinoSharp;
using OpenCvSharp;
using ResultSharp;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using OpenCvSharp.Dnn;

namespace ModelDeployPlatform
{
    public partial class FormModelDeployPlat : Form
    {
        public FormModelDeployPlat()
        {
            InitializeComponent();
        }

        private void FormModelDeployPlat_Load(object sender, EventArgs e)
        {
            SetWindows.EmbededFigureWindow("数据显示", panel1);
        }

        private void btn_choose_model_path_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //若要改变对话框标题
            dlg.Title = "选择推理模型文件";
            //指定当前目录
            //dlg.InitialDirectory = System.Environment.CurrentDirectory;
            //dlg.InitialDirectory = System.IO.Path.GetFullPath(@"..//..//..//..");
            //设置文件过滤效果
            dlg.Filter = "模型文件(*.pt,*.onnx,*.engine)|*.pt;*.onnx;*.engine";
            dlg.InitialDirectory = @"E:\Git_space\Csharp_deploy_Yolov8\model";
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_model_path.Text = dlg.FileName;
            }
        }

        private void btn_choose_claspath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //若要改变对话框标题
            dlg.Title = "选择分类文件";
            //指定当前目录
            //dlg.InitialDirectory = System.Environment.CurrentDirectory;
            //dlg.InitialDirectory = System.IO.Path.GetFullPath(@"..//..//..//..");
            //设置文件过滤效果
            dlg.Filter = "分类文件(*.txt)|*.txt";
            dlg.InitialDirectory = @"E:\Git_space\Csharp_deploy_Yolov8\demo";
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_clas_path.Text = dlg.FileName;
            }
        }

        private void btn_choose_testimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //若要改变对话框标题
            dlg.Title = "选择测试图片文件";
            //指定当前目录
            //dlg.InitialDirectory = System.Environment.CurrentDirectory;
            //dlg.InitialDirectory = System.IO.Path.GetFullPath(@"..//..//..//..");
            //设置文件过滤效果
            dlg.Filter = "图片文件(*.png,*.jpg,*.jepg)|*.png;*.jpg;*.jepg";
            dlg.InitialDirectory = @"E:\Git_space\Csharp_deploy_Yolov8\demo";
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_test_image.Text = dlg.FileName;
            }
        }

        private void btn_model_deploy_Click(object sender, EventArgs e)
        {
            // 清屏专用
            Console.Clear();
            string model_path = tb_model_path.Text;
            //model_path = @"E:\Git_space\基于Csharp部署Yolov8\model\yolov8s.engine";
            //model_path = @"E:\Git_space\Csharp_deploy_Yolov8\model\yolov8s.onnx";
            //model_path = @"E:\Git_space\Csharp_deploy_Yolov8\model\yolov8s-seg.onnx";
            //model_path = @"E:\Git_space\Csharp_deploy_Yolov8\model\yolov8s-pose.onnx";

            string classer_path = tb_clas_path.Text;
            //classer_path = @"E:\Git_space\Csharp_deploy_Yolov8\demo\det_lable.txt";
            //classer_path = @"E:\Git_space\Csharp_deploy_Yolov8\demo\cls_lable.txt";
            string image_path = tb_test_image.Text;
            //image_path = @"E:\Git_space\Csharp_deploy_Yolov8\demo\demo_9.jpg";


            DateTime begin = DateTime.Now;
            DateTime end = DateTime.Now;
            TimeSpan model_load = new TimeSpan(0, 0, 0);
            TimeSpan data_load = new TimeSpan(0, 0, 0);
            TimeSpan model_infer = new TimeSpan(0, 0, 0);
            TimeSpan result_process = new TimeSpan(0, 0, 0);


            begin = DateTime.Now;
            // 配置图片数据
            Mat image = new Mat(image_path);
            int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
            Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
            image.CopyTo(new Mat(max_image, roi));
            end = DateTime.Now;
            data_load = end.Subtract(begin);




            #region 

            if (rb_yolov8_det.Checked) // yolov8-det模型
            {
                float[] result_array = new float[8400 * 84];
                float[] factors = new float[2];
                factors = new float[2];
                factors[0] = factors[1] = (float)(max_image_length / 640.0);


                if (rb_openvino.Checked)
                {
                    Console.WriteLine("------Yolov8 detection model deploy OpnenVINO-------");
                    begin = DateTime.Now;
                    Core core = new Core(model_path, "CPU");
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    core.load_input_data("images", image_data, image_size, 1);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    core.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = core.read_infer_result<float>("output0", 8400 * 84);

                    core.delet();
                }
                else if (rb_tensorrt.Checked)
                {
                    Console.WriteLine("------Yolov8 detection model deploy TensorRT-------");
                    begin = DateTime.Now;
                    Nvinfer nvinfer = new Nvinfer(model_path);
                    nvinfer.creat_gpu_buffer();
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    nvinfer.load_image_data("images", image_data, image_size, BNFlag.Normal);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    nvinfer.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = nvinfer.read_infer_result("output0", 8400 * 84);
                    nvinfer.delete();
                }
                else if (rb_onnx.Checked)
                {
                    Console.WriteLine("------Yolov8 detection model deploy ONNX runtime-------");
                    begin = DateTime.Now;
                    // 创建输出会话，用于输出模型读取信息
                    SessionOptions options = new SessionOptions();
                    options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                    // 设置为CPU上运行
                    options.AppendExecutionProvider_CPU(0);

                    // 船舰推理模型类，读取本地模型文件
                    InferenceSession onnx_session = new InferenceSession(model_path, options);//model_path 为onnx模型文件的路径
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将图片转为RGB通道
                    Mat image_rgb = new Mat();
                    Cv2.CvtColor(max_image, image_rgb, ColorConversionCodes.BGR2RGB);
                    Mat resize_image = new Mat();
                    Cv2.Resize(image_rgb, resize_image, new OpenCvSharp.Size(640, 640));

                    // 创建输入Tensor
                    Tensor<float> input_tensor = new DenseTensor<float>(new[] { 1, 3, 640, 640 });
                    for (int y = 0; y < resize_image.Height; y++)
                    {
                        for (int x = 0; x < resize_image.Width; x++)
                        {
                            input_tensor[0, 0, y, x] = resize_image.At<Vec3b>(y, x)[0] / 255f;
                            input_tensor[0, 1, y, x] = resize_image.At<Vec3b>(y, x)[1] / 255f;
                            input_tensor[0, 2, y, x] = resize_image.At<Vec3b>(y, x)[2] / 255f;
                        }
                    }

                    // 创建输入容器
                    List<NamedOnnxValue> input_ontainer = new List<NamedOnnxValue>();
                    //将 input_tensor 放入一个输入参数的容器，并指定名称
                    input_ontainer.Add(NamedOnnxValue.CreateFromTensor("images", input_tensor));
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    //运行 Inference 并获取结果
                    IDisposableReadOnlyCollection<DisposableNamedOnnxValue> result_infer = onnx_session.Run(input_ontainer);
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将输出结果转为DisposableNamedOnnxValue数组
                    DisposableNamedOnnxValue[] results_onnxvalue = result_infer.ToArray();

                    // 读取第一个节点输出并转为Tensor数据
                    Tensor<float> result_tensors = results_onnxvalue[0].AsTensor<float>();

                    result_array = result_tensors.ToArray();
                    onnx_session.Dispose();
                    resize_image.Dispose();
                    image_rgb.Dispose();

                }
                else if (rb_opencv.Checked)
                {
                    Console.WriteLine("------Yolov8 detection model deploy OpenCV-------");
                    begin = DateTime.Now;
                    // 初始化网络类，读取本地模型
                    Net opencv_net = CvDnn.ReadNetFromOnnx(model_path);
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 数据归一化处理
                    Mat BN_image = CvDnn.BlobFromImage(max_image, 1 / 255.0, new OpenCvSharp.Size(640, 640), new Scalar(0, 0, 0), true, false);

                    // 配置图片输入数据
                    opencv_net.SetInput(BN_image);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理，读取推理结果
                    Mat result_mat = opencv_net.Forward();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将推理结果转为float数据类型
                    Mat result_mat_to_float = new Mat(8400, 84, MatType.CV_32F, result_mat.Data);
                    // 将数据读取到数组中
                    result_mat_to_float.GetArray<float>(out result_array);
                }



                DetectionResult result_pro = new DetectionResult(classer_path, factors);
                Mat result_image = result_pro.draw_result(result_pro.process_result(result_array), image.Clone());
                end = DateTime.Now;
                result_process += end.Subtract(begin);


                Cv2.Resize(image, image, new OpenCvSharp.Size(720, 480));
                Cv2.Resize(result_image, result_image, new OpenCvSharp.Size(720, 480));
                pictureBox1.Image = new Bitmap(image.ToMemoryStream()) as Image;
                pictureBox2.Image = new Bitmap(result_image.ToMemoryStream()) as Image;
            }
            #endregion

            #region
            else if (rb_yolov8_seg.Checked) // yolov8-seg 模型
            {
                float[] det_result_array = new float[8400 * 116];
                float[] proto_result_array = new float[32 * 160 * 160];
                float[] factors = new float[4];
                factors[0] = factors[1] = (float)(max_image_length / 640.0);
                factors[2] = image.Rows;
                factors[3] = image.Cols;
                Console.WriteLine(factors[0]);
                if (rb_openvino.Checked)
                {
                    Console.WriteLine("------Yolov8 segmentation model deploy OpnenVINO-------");
                    begin = DateTime.Now;
                    Core core = new Core(model_path, "CPU");
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;

                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    core.load_input_data("images", image_data, image_size, 1);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    core.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    det_result_array = core.read_infer_result<float>("output0", 8400 * 116);
                    proto_result_array = core.read_infer_result<float>("output1", 32 * 160 * 160);
                    core.delet();
                }
                else if (rb_tensorrt.Checked)
                {
                    Console.WriteLine("------Yolov8 segmentation model deploy TensorRT-------");
                    begin = DateTime.Now;
                    Nvinfer nvinfer = new Nvinfer(model_path);
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    nvinfer.creat_gpu_buffer();
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    nvinfer.load_image_data("images", image_data, image_size, BNFlag.Normal);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    nvinfer.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    det_result_array = nvinfer.read_infer_result("output0", 8400 * 116);
                    proto_result_array = nvinfer.read_infer_result("output1", 32 * 160 * 160);
                    nvinfer.delete();
                }
                else if (rb_onnx.Checked)
                {
                    Console.WriteLine("------Yolov8 segmentation model deploy ONNX runtime-------");
                    begin = DateTime.Now;
                    // 创建输出会话，用于输出模型读取信息
                    SessionOptions options = new SessionOptions();
                    options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                    // 设置为CPU上运行
                    options.AppendExecutionProvider_CPU(0);

                    // 船舰推理模型类，读取本地模型文件
                    InferenceSession onnx_session = new InferenceSession(model_path, options);//model_path 为onnx模型文件的路径
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将图片转为RGB通道
                    Mat image_rgb = new Mat();
                    Cv2.CvtColor(max_image, image_rgb, ColorConversionCodes.BGR2RGB);
                    Mat resize_image = new Mat();
                    Cv2.Resize(image_rgb, resize_image, new OpenCvSharp.Size(640, 640));

                    // 创建输入Tensor
                    Tensor<float> input_tensor = new DenseTensor<float>(new[] { 1, 3, 640, 640 });
                    for (int y = 0; y < resize_image.Height; y++)
                    {
                        for (int x = 0; x < resize_image.Width; x++)
                        {
                            input_tensor[0, 0, y, x] = resize_image.At<Vec3b>(y, x)[0] / 255f;
                            input_tensor[0, 1, y, x] = resize_image.At<Vec3b>(y, x)[1] / 255f;
                            input_tensor[0, 2, y, x] = resize_image.At<Vec3b>(y, x)[2] / 255f;
                        }
                    }

                    // 创建输入容器
                    List<NamedOnnxValue> input_ontainer = new List<NamedOnnxValue>();
                    //将 input_tensor 放入一个输入参数的容器，并指定名称
                    input_ontainer.Add(NamedOnnxValue.CreateFromTensor("images", input_tensor));
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    //运行 Inference 并获取结果
                    IDisposableReadOnlyCollection<DisposableNamedOnnxValue> result_infer = onnx_session.Run(input_ontainer);
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将输出结果转为DisposableNamedOnnxValue数组
                    DisposableNamedOnnxValue[] results_onnxvalue = result_infer.ToArray();

                    // 读取第一个节点输出并转为Tensor数据
                    Tensor<float> result_tensors_det = results_onnxvalue[0].AsTensor<float>();
                    Tensor<float> result_tensors_proto = results_onnxvalue[1].AsTensor<float>();

                    det_result_array = result_tensors_det.ToArray();
                    proto_result_array = result_tensors_proto.ToArray();

                    onnx_session.Dispose();
                    resize_image.Dispose();
                    image_rgb.Dispose();

                }
                else if (rb_opencv.Checked)
                {
                    Console.WriteLine("------Yolov8 segmentation model deploy OpenCV-------");
                    begin = DateTime.Now;
                    // 初始化网络类，读取本地模型
                    Net opencv_net = CvDnn.ReadNetFromOnnx(model_path);
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 数据归一化处理
                    Mat BN_image = CvDnn.BlobFromImage(max_image, 1 / 255.0, new OpenCvSharp.Size(640, 640), new Scalar(0, 0, 0), true, false);

                    // 配置图片输入数据
                    opencv_net.SetInput(BN_image);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);

                    // 模型推理，读取推理结果
                    List<Mat> result_mats = new List<Mat>() { new Mat(8400, 84, MatType.CV_32F), new Mat(32, 160 * 160, MatType.CV_32F) };
                    string[] output_names = new string[] { "output0", "output1" };
                    begin = DateTime.Now;
                    opencv_net.Forward(result_mats, output_names);
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将推理结果转为float数据类型
                    Mat result_det = new Mat(8400, 84, MatType.CV_32F, result_mats[0].Data);
                    Mat result_proto = new Mat(32, 160 * 160, MatType.CV_32F, result_mats[1].Data);
                    // 将数据读取到数组中
                    result_det.GetArray<float>(out det_result_array);

                    result_proto.GetArray<float>(out proto_result_array);

                }



                SegmentationResult result_pro = new SegmentationResult(classer_path, factors);
                Mat result_image = result_pro.draw_result(result_pro.process_result(det_result_array, proto_result_array), image.Clone());
                end = DateTime.Now;
                result_process += end.Subtract(begin);


                Cv2.Resize(image, image, new OpenCvSharp.Size(720, 480));
                Cv2.Resize(result_image, result_image, new OpenCvSharp.Size(720, 480));
                pictureBox1.Image = new Bitmap(image.ToMemoryStream()) as Image;
                pictureBox2.Image = new Bitmap(result_image.ToMemoryStream()) as Image;

            }

            #endregion

            #region
            else if (rb_yolov8_cls.Checked)
            {
                float[] result_array = new float[1000];


                if (rb_openvino.Checked)
                {
                    Console.WriteLine("------Yolov8 Classification model deploy OpnenVINO-------\n");
                    begin = DateTime.Now;
                    Core core = new Core(model_path, "CPU");
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    core.load_input_data("images", image_data, image_size, 1);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    core.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = core.read_infer_result<float>("output0", 1000);

                    core.delet();
                }
                else if (rb_tensorrt.Checked)
                {
                    Console.WriteLine("------Yolov8 Classification model deploy TensorRT-------\n");
                    begin = DateTime.Now;
                    Nvinfer nvinfer = new Nvinfer(model_path);
                    nvinfer.creat_gpu_buffer();
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    nvinfer.load_image_data("images", image_data, image_size, BNFlag.Normal);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    nvinfer.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = nvinfer.read_infer_result("output0", 1000);
                    nvinfer.delete();
                }
                else if (rb_onnx.Checked)
                {
                    Console.WriteLine("------Yolov8 Classification model deploy ONNX runtime-------\n");
                    begin = DateTime.Now;
                    // 创建输出会话，用于输出模型读取信息
                    SessionOptions options = new SessionOptions();
                    options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                    // 设置为CPU上运行
                    options.AppendExecutionProvider_CPU(0);

                    // 船舰推理模型类，读取本地模型文件
                    InferenceSession onnx_session = new InferenceSession(model_path, options);//model_path 为onnx模型文件的路径
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将图片转为RGB通道
                    Mat image_rgb = new Mat();
                    Cv2.CvtColor(max_image, image_rgb, ColorConversionCodes.BGR2RGB);
                    Mat resize_image = new Mat();
                    Cv2.Resize(image_rgb, resize_image, new OpenCvSharp.Size(224, 224));

                    // 创建输入Tensor
                    Tensor<float> input_tensor = new DenseTensor<float>(new[] { 1, 3, 224, 224 });
                    for (int y = 0; y < resize_image.Height; y++)
                    {
                        for (int x = 0; x < resize_image.Width; x++)
                        {
                            input_tensor[0, 0, y, x] = resize_image.At<Vec3b>(y, x)[0] / 255f;
                            input_tensor[0, 1, y, x] = resize_image.At<Vec3b>(y, x)[1] / 255f;
                            input_tensor[0, 2, y, x] = resize_image.At<Vec3b>(y, x)[2] / 255f;
                        }
                    }

                    // 创建输入容器
                    List<NamedOnnxValue> input_ontainer = new List<NamedOnnxValue>();
                    //将 input_tensor 放入一个输入参数的容器，并指定名称
                    input_ontainer.Add(NamedOnnxValue.CreateFromTensor("images", input_tensor));
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    //运行 Inference 并获取结果
                    IDisposableReadOnlyCollection<DisposableNamedOnnxValue> result_infer = onnx_session.Run(input_ontainer);
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将输出结果转为DisposableNamedOnnxValue数组
                    DisposableNamedOnnxValue[] results_onnxvalue = result_infer.ToArray();

                    // 读取第一个节点输出并转为Tensor数据
                    Tensor<float> result_tensors = results_onnxvalue[0].AsTensor<float>();

                    result_array = result_tensors.ToArray();
                    onnx_session.Dispose();
                    resize_image.Dispose();
                    image_rgb.Dispose();

                }
                else if (rb_opencv.Checked)
                {
                    Console.WriteLine("------Yolov8 Classification model deploy OpenCV-------\n");
                    begin = DateTime.Now;
                    // 初始化网络类，读取本地模型
                    Net opencv_net = CvDnn.ReadNetFromOnnx(model_path);
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 数据归一化处理
                    Mat BN_image = CvDnn.BlobFromImage(max_image, 1 / 255.0, new OpenCvSharp.Size(224, 224), new Scalar(0, 0, 0), true, false);

                    // 配置图片输入数据
                    opencv_net.SetInput(BN_image);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理，读取推理结果
                    Mat result_mat = opencv_net.Forward();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将推理结果转为float数据类型
                    Mat result_mat_to_float = new Mat(1, 1000, MatType.CV_32F, result_mat.Data);
                    // 将数据读取到数组中
                    result_mat_to_float.GetArray<float>(out result_array);
                }

                ClasResult result_pro = new ClasResult(classer_path);
                KeyValuePair<string, float> result_cls = result_pro.process_result(result_array);
                Mat result_image = result_pro.draw_result(result_cls, image.Clone());
                end = DateTime.Now;
                result_process += end.Subtract(begin);
                Console.WriteLine(result_cls.ToString());

                Cv2.Resize(image, image, new OpenCvSharp.Size(720, 480));
                Cv2.Resize(result_image, result_image, new OpenCvSharp.Size(720, 480));
                pictureBox1.Image = new Bitmap(image.ToMemoryStream()) as Image;
                pictureBox2.Image = new Bitmap(result_image.ToMemoryStream()) as Image;


            }
            #endregion
            #region
            else if (rb_yolov8_pose.Checked) // yolov8-det模型
            {
                float[] result_array = new float[8400 * 56];
                float[] factors = new float[2];
                factors[0] = factors[1] = (float)(max_image_length / 640.0);


                if (rb_openvino.Checked)
                {
                    Console.WriteLine("------Yolov8 Pose model deploy OpnenVINO-------\n");
                    begin = DateTime.Now;
                    Core core = new Core(model_path, "CPU");
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    core.load_input_data("images", image_data, image_size, 1);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    core.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = core.read_infer_result<float>("output0", 8400 * 56);

                    core.delet();
                }
                else if (rb_tensorrt.Checked)
                {
                    Console.WriteLine("------Yolov8 Pose model deploy TensorRT-------\n");
                    begin = DateTime.Now;
                    Nvinfer nvinfer = new Nvinfer(model_path);
                    nvinfer.creat_gpu_buffer();
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    byte[] image_data = max_image.ImEncode(".bmp");
                    //存储byte的长度
                    ulong image_size = Convert.ToUInt64(image_data.Length);
                    // 加载推理图片数据
                    nvinfer.load_image_data("images", image_data, image_size, BNFlag.Normal);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理
                    nvinfer.infer();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 读取推理结果
                    result_array = nvinfer.read_infer_result("output0", 8400 * 56);
                    nvinfer.delete();
                }
                else if (rb_onnx.Checked)
                {
                    Console.WriteLine("------Yolov8 Pose model deploy ONNX runtime-------\n");
                    begin = DateTime.Now;
                    // 创建输出会话，用于输出模型读取信息
                    SessionOptions options = new SessionOptions();
                    options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                    // 设置为CPU上运行
                    options.AppendExecutionProvider_CPU(0);

                    // 船舰推理模型类，读取本地模型文件
                    InferenceSession onnx_session = new InferenceSession(model_path, options);//model_path 为onnx模型文件的路径
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将图片转为RGB通道
                    Mat image_rgb = new Mat();
                    Cv2.CvtColor(max_image, image_rgb, ColorConversionCodes.BGR2RGB);
                    Mat resize_image = new Mat();
                    Cv2.Resize(image_rgb, resize_image, new OpenCvSharp.Size(640, 640));

                    // 创建输入Tensor
                    Tensor<float> input_tensor = new DenseTensor<float>(new[] { 1, 3, 640, 640 });
                    for (int y = 0; y < resize_image.Height; y++)
                    {
                        for (int x = 0; x < resize_image.Width; x++)
                        {
                            input_tensor[0, 0, y, x] = resize_image.At<Vec3b>(y, x)[0] / 255f;
                            input_tensor[0, 1, y, x] = resize_image.At<Vec3b>(y, x)[1] / 255f;
                            input_tensor[0, 2, y, x] = resize_image.At<Vec3b>(y, x)[2] / 255f;
                        }
                    }

                    // 创建输入容器
                    List<NamedOnnxValue> input_ontainer = new List<NamedOnnxValue>();
                    //将 input_tensor 放入一个输入参数的容器，并指定名称
                    input_ontainer.Add(NamedOnnxValue.CreateFromTensor("images", input_tensor));
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    //运行 Inference 并获取结果
                    IDisposableReadOnlyCollection<DisposableNamedOnnxValue> result_infer = onnx_session.Run(input_ontainer);
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将输出结果转为DisposableNamedOnnxValue数组
                    DisposableNamedOnnxValue[] results_onnxvalue = result_infer.ToArray();

                    // 读取第一个节点输出并转为Tensor数据
                    Tensor<float> result_tensors = results_onnxvalue[0].AsTensor<float>();

                    result_array = result_tensors.ToArray();
                    onnx_session.Dispose();
                    resize_image.Dispose();
                    image_rgb.Dispose();

                }
                else if (rb_opencv.Checked)
                {
                    Console.WriteLine("------Yolov8 Pose model deploy OpenCV-------\n");
                    begin = DateTime.Now;
                    // 初始化网络类，读取本地模型
                    Net opencv_net = CvDnn.ReadNetFromOnnx(model_path);
                    end = DateTime.Now;
                    model_load = end.Subtract(begin);
                    begin = DateTime.Now;
                    // 数据归一化处理
                    Mat BN_image = CvDnn.BlobFromImage(max_image, 1 / 255.0, new OpenCvSharp.Size(640, 640), new Scalar(0, 0, 0), true, false);

                    // 配置图片输入数据
                    opencv_net.SetInput(BN_image);
                    end = DateTime.Now;
                    data_load += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 模型推理，读取推理结果
                    Mat result_mat = opencv_net.Forward();
                    end = DateTime.Now;
                    model_infer += end.Subtract(begin);
                    begin = DateTime.Now;
                    // 将推理结果转为float数据类型
                    Mat result_mat_to_float = new Mat(8400, 56, MatType.CV_32F, result_mat.Data);
                    // 将数据读取到数组中
                    result_mat_to_float.GetArray<float>(out result_array);
                }



                PoseResult result_pro = new PoseResult( factors);
                Mat result_image = result_pro.draw_result(result_pro.process_result(result_array), image.Clone());
                end = DateTime.Now;
                result_process += end.Subtract(begin);


                Cv2.Resize(image, image, new OpenCvSharp.Size(720, 480));
                Cv2.Resize(result_image, result_image, new OpenCvSharp.Size(720, 480));
                pictureBox1.Image = new Bitmap(image.ToMemoryStream()) as Image;
                pictureBox2.Image = new Bitmap(result_image.ToMemoryStream()) as Image;
            }
            #endregion

            Console.WriteLine("模型加载时间：{0}\n", model_load.TotalMilliseconds);
            Console.WriteLine("数据加载时间：{0}\n", data_load.TotalMilliseconds);
            Console.WriteLine("模型推理时间：{0}\n", model_infer.TotalMilliseconds);
            Console.WriteLine("结果处理时间：{0}\n", result_process.TotalMilliseconds);

        }

        private void btn_engine_conv_Click(object sender, EventArgs e)
        {
            FormEngineConvert form = new FormEngineConvert();
            form.Show();
        }
    }
}
