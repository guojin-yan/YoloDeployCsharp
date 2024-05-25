using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using OpenVinoSharp.Extensions.process;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using YoloDeployPlatform.predictor;
using Timer = System.Windows.Forms.Timer;

namespace YoloDeployPlatform
{
    public partial class YoloDeployPlatform : Form
    {
        private YOLO yolo = new YOLO();
        private Log log = Log.Instance;
        private Stopwatch sw = new Stopwatch();
        private List<string> class_names= new List<string>();

        private VideoCapture video;

        private Timer video_timer = new Timer();
        private bool timerRunning = false;

        private string infer_type = "det"; 

        public YoloDeployPlatform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_device.Items.Clear();
            cb_device.Items.AddRange(new object[] { "AUTO", "CPU", "GPU.0", "GPU.1" });
            cb_device.SelectedIndex = 1;
            log.set_current_cb(tb_msg_image);
            btn_image_infer.Enabled = false;
            btn_video_infer.Enabled = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = false;

            if (chb_time.Checked)
            {
                log.flag_time = true;
            }
            else
            {
                log.flag_time = false;
            }

            if (chb_fps.Checked)
            {
                log.flag_fps = true;
            }
            else
            {
                log.flag_fps = false;
            }

            video_timer.Interval = 1;
            video_timer.Enabled = false;
            video_timer.Tick += new EventHandler(video_timer_Tick);
        }
        #region File_Select
        private void btn_model_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "E:\\Model\\yolo";
            dlg.Title = "Select inference model file.";
            dlg.Filter = "Model file(*.pdmodel,*.onnx,*.xml,*.engine)|*.pdmodel;*.onnx;*.xml;*.engine";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_model_path.Text = dlg.FileName;
            }
        }

        private void btn_class_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "E:\\ModelData\\lable";
            dlg.Title = "Select the test input file.";
            dlg.Filter = "Class file(*.txt)|*.txt";
            class_names = new List<string>();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_class_path.Text = dlg.FileName;
                StreamReader sr = new StreamReader(dlg.FileName);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    class_names.Add(line);
                }
            }
        }

        private void btn_input_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "E:\\ModelData";
            dlg.Title = "Select the test input file.";
            dlg.Filter = "Input file(*.png,*.jpg,*.jepg,*.mp4,*.mov)|*.png;*.jpg;*.jepg;*.mp4;*.mov";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_input_path.Text = dlg.FileName;
            }
        }
        #endregion
       

        #region RadioButton_CheckedChanged
        private void rb_openvino_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_openvino.Checked) 
            {
                cb_device.Items.Clear();
                cb_device.Items.AddRange(new object[] { "AUTO", "CPU", "GPU.0", "GPU.1" });
                cb_device.SelectedIndex = 1;
            }
        }

        private void rb_tensorrt_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tensorrt.Checked)
            {
                cb_device.Items.Clear();
                cb_device.Items.AddRange(new object[] { "GPU.0", "GPU.1" });
                cb_device.SelectedIndex = 0;
            }
        }

        private void rb_onnx_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_onnx.Checked)
            {
                cb_device.Items.Clear();
                cb_device.Items.AddRange(new object[] { "CPU", "GPU.0", "GPU.1" });
                cb_device.SelectedIndex = 0;
            }
        }

        private void rb_opencv_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_opencv.Checked)
            {
                cb_device.Items.Clear();
                cb_device.Items.AddRange(new object[] { "CPU"});
                cb_device.SelectedIndex = 0;
            }
        }

        private void chb_time_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_time.Checked)
            {
                log.flag_time = true;
            }
            else
            {
                log.flag_time = false;
            }
        }

        private void chb_fps_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_fps.Checked)
            {
                log.flag_fps = true;
            }
            else
            {
                log.flag_fps = false;
            }
        }

        private void tc_operate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc_operate.SelectedIndex == 0)
            {
                log.set_current_cb(tb_msg_image);
            }
            else
            {
                log.set_current_cb(tb_msg_video);
            }
        }

        #endregion

        private void btn_load_model_Click(object sender, EventArgs e)
        {
            string model_type_str = check_rb(gb_model.Controls);
            if (model_type_str == "")
            {
                show_worn_msg_box("Please select a model category.");
                return;
            }
            string engine_type_str = check_rb(gb_engine.Controls);
            if (engine_type_str == "")
            {
                show_worn_msg_box("Please select an inference engine.");
                return;
            }
            ModelType model_type = MyEnum.GetModelType<ModelType>(model_type_str);
            EngineType engine_type = MyEnum.GetEngineType<EngineType>(engine_type_str);


            if ((model_type == ModelType.YOLOv10Det) ||
                (model_type == ModelType.YOLOv9Det) ||
                (model_type == ModelType.YOLOv8Det) ||
                (model_type == ModelType.YOLOv7Det) ||
                (model_type == ModelType.YOLOv6Det) ||
                (model_type == ModelType.YOLOv5Det) ||
                (model_type == ModelType.YOLOWorld)) 
            {
                infer_type = "det";
            }
            else if ((model_type == ModelType.YOLOv9Seg) ||
                (model_type == ModelType.YOLOv8Seg) ||
                (model_type == ModelType.YOLOv5Seg))
            {
                infer_type = "seg";
            }
            else if ((model_type == ModelType.YOLOv8Pose))
            {
                infer_type = "pose";
            }
            else if ((model_type == ModelType.YOLOv8Obb))
            {
                infer_type = "obb";
            }
            else if ((model_type == ModelType.YOLOv8Cls) ||
                (model_type == ModelType.YOLOv5Cls))
            {
                infer_type = "cls";
            }
            string model_path = tb_model_path.Text;
            string device = cb_device.SelectedItem.ToString();

            string extension = Path.GetExtension(model_path);
            if (EngineType.TensorRT == engine_type)
            {

                if ((extension != ".engine") && (extension == ".onnx"))
                {
                    ONNXToEngine from = new ONNXToEngine(model_path);
                    from.Show();
                    string directory = Path.GetDirectoryName(model_path);
                    string file = Path.GetFileNameWithoutExtension(model_path);
                    tb_model_path.Text = Path.Combine(directory, file) + ".engine";
                    model_path = tb_model_path.Text;
                    return;
                }
                else if (extension == ".engine") { }
                else
                {
                    show_worn_msg_box("Please select the correct model format.");
                    return;
                }
            }
            else 
            {
                if ((extension == ".onnx" && (
                    EngineType.ONNX == engine_type ||
                    EngineType.OpenVINO == engine_type ||
                    EngineType.OpenCV == engine_type)) ||
                    (extension == ".xml" && EngineType.OpenVINO == engine_type))
                { }
                else 
                {
                    show_worn_msg_box("Please select the correct model format.");
                    return;
                }
            }

            yolo.Dispose();

            float score = float.Parse(tb_score.Text);
            float nms = float.Parse(tb_nms.Text);
            int categ_num = int.Parse(tb_categ_num.Text);
            int input_size = int.Parse(tb_input_size.Text);


            if (log.flag_time) 
            {
                sw.Restart();
                yolo = YOLO.GetYolo(model_type, model_path, engine_type, device, categ_num, score, nms, input_size);
                sw.Stop();
                log.print("Model loaded successfull, spend time: " + sw.ElapsedMilliseconds + " ms;");
            }
            yolo = YOLO.GetYolo(model_type, model_path, engine_type, device, categ_num, score, nms, input_size);
            btn_image_infer.Enabled = true;
            btn_video_infer.Enabled = true;
        }


        private void btn_image_infer_Click(object sender, EventArgs e)
        {
            string input_path = tb_input_path.Text;
            Mat img = Cv2.ImRead(input_path);
            pictureBox1.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img);
            Mat re_img = image_predict(img);
            pictureBox2.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(re_img);
        }

        private void btn_video_infer_Click(object sender, EventArgs e)
        {
            video = new VideoCapture(tb_input_path.Text);
            pb_video.Maximum = video.FrameCount + 1;
            pb_video.Value = 0;
            btn_start.Enabled = true;
            btn_stop.Enabled = true;
            log.sum_time = new List<long>();
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (video.IsOpened()) 
            {
                if (!timerRunning)
                {
                    video_timer.Enabled = true;
                    video_timer.Start();
                    timerRunning = true;
                }

            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                video_timer.Enabled = false;
                video_timer.Stop();
                timerRunning = false;
            } 
        }
        private void video_timer_Tick(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                Mat frame = new Mat();
                video.Read(frame);
                if (!frame.Empty())
                {
                    pb_video.Value = pb_video.Value + 1;
                    pictureBox1.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    Mat re_img = image_predict(frame, true);
                    pictureBox2.BackgroundImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(re_img);
                    Cv2.WaitKey(1);
                }
            }
        }

        #region 
        private string check_rb(Control.ControlCollection controls)
        {
            string key = "";
            foreach (Control ctr in controls)
            {
                if (ctr is RadioButton && (ctr as RadioButton).Checked)
                {
                    key = ctr.Text;
                }
            }
            return key;
        }


        private void show_worn_msg_box(string message)
        {
            string caption = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OK; // 设置按钮
            MessageBoxIcon icon = MessageBoxIcon.Warning; // 设置图标
            DialogResult result = MessageBox.Show(this, message, caption, buttons, icon);

            // 根据用户的点击按钮处理逻辑
            if (result == DialogResult.OK)
            {
                // 用户点击了OK
                return;
            }
        }

        Mat image_predict(Mat img, bool is_video = false)
        {
            Mat re_img = new Mat();


            BaseResult result;
            if (log.flag_time && !is_video)
            {
                log.flag_time = false;
                yolo.predict(img);
                log.flag_time = true;
                result = yolo.predict(img);
            }
            else
            {
                result = yolo.predict(img);
            }

            if (class_names.Count > 0)
            {
                result.update_lable(class_names);
            }

            if (infer_type == "det")
            {
                re_img = Visualize.draw_det_result(result, img);
            }
            else if (infer_type == "seg") 
            {
                re_img = Visualize.draw_seg_result(result, img);
            }
            else if (infer_type == "pose")
            {
                re_img = Visualize.draw_poses(result, img);
            }
            else if (infer_type == "obb")
            {
                re_img = Visualize.draw_obb_result(result, img);
            }
            else if (infer_type == "cls")
            {
                ClsResult cresult = result as ClsResult;
                log.print(string.Format("\n Classification Top {0} result : \n", 10));
                log.print("classid probability");
                log.print("------- -----------");
                for (int i = 0; i < 10; ++i)
                {
                    ClsData data = cresult.datas[i];
                    log.print(data.to_string("0.00"));
                }
                re_img = img.Clone();
            }

            if (log.flag_time && log.flag_fps)
            {
                Cv2.Rectangle(re_img, new OpenCvSharp.Point(30, 20), new OpenCvSharp.Point(250, 60),
                    new Scalar(0.0, 255.0, 255.0), -1);
                Cv2.PutText(re_img, "FPS: " + (1000.0 / log.infer_time).ToString("0.00"), new OpenCvSharp.Point(50, 50),
                    HersheyFonts.HersheySimplex, 0.8, new Scalar(0, 0, 0), 2);
            }

            return re_img;
        }



        #endregion

        private void btn_time_Click(object sender, EventArgs e)
        {
            log.print();
        }
    }
}
