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
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_model_path.Text = dlg.FileName;
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
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_model_path.Text = dlg.FileName;
            }
        }

        private void btn_model_deploy_Click(object sender, EventArgs e)
        {
            string model_path = tb_model_path.Text;
            //model_path = @"E:\Git_space\基于Csharp部署Yolov8\model\yolov8s.engine";
            model_path = @"E:\Git_space\基于Csharp部署Yolov8\model\yolov8s.onnx";

            string classer_path = tb_clas_path.Text;
            classer_path = @"E:\Git_space\基于Csharp部署Yolov8\demo\lable.txt";
            string image_path = tb_test_image.Text;
            image_path = @"E:\Git_space\基于Csharp部署Yolov8\demo\demo_3.jpg";

            // 配置图片数据
            Mat image = new Mat(image_path);
            int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
            Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
            image.CopyTo(new Mat(max_image, roi));
            byte[] image_data = max_image.ImEncode(".bmp");
            //存储byte的长度
            ulong image_size = Convert.ToUInt64(image_data.Length);


            float[] result_array = new float[8400*84];
            float[] factors = new float[2];

            if (rb_openvino.Checked) 
            {
                if (rb_yolov8_det.Checked)
                {
                    Core core = new Core(model_path,"CPU");
                    Console.WriteLine("-------------------");


                    // 加载推理图片数据
                    core.load_input_data("images", image_data, image_size, 0);
                    // 模型推理
                    core.infer();
                    // 读取推理结果
                    result_array = core.read_infer_result<float>("output0", 8400 * 84);
                    factors = new float[2];
                    factors[0] = factors[1] = (float)(max_image_length / 640.0);
                    core.delet();

                }
            }
            else if (rb_tensorrt.Checked) 
            {
                if (rb_yolov8_det.Checked)
                {
                    Nvinfer nvinfer = new Nvinfer(model_path);
                    Console.WriteLine("-------------------");
                    nvinfer.creat_gpu_buffer();

                    // 加载推理图片数据
                    nvinfer.load_image_data("images", image_data, image_size, BNFlag.Normal);
                    // 模型推理
                    nvinfer.infer();
                    // 读取推理结果
                    result_array = nvinfer.read_infer_result("output0", 8400 * 84);
                    factors = new float[2];
                    factors[0] = factors[1] = (float)(max_image_length/640.0);
                    nvinfer.delete();

                }
            }
            else if (rb_onnx.Checked)
            { 
            }

            DetectionResult result_pro = new DetectionResult(classer_path, factors);
            Mat result_image = result_pro.draw_result(result_pro.process_resule(result_array), image.Clone());
            Cv2.Resize(image, image, new OpenCvSharp.Size(720, 480));
            Cv2.Resize(result_image, result_image, new OpenCvSharp.Size(720, 480));
            pictureBox1.Image = new Bitmap(image.ToMemoryStream()) as Image;
            pictureBox2.Image = new Bitmap(result_image.ToMemoryStream()) as Image;

        }
    }
}
