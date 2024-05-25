namespace YoloDeployPlatform
{
    partial class YoloDeployPlatform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            gb_engine = new GroupBox();
            rb_opencv = new RadioButton();
            rb_onnx = new RadioButton();
            rb_tensorrt = new RadioButton();
            rb_openvino = new RadioButton();
            gb_model = new GroupBox();
            rb_yolov8_obb = new RadioButton();
            rb_yolov8_cls = new RadioButton();
            rb_yolov8_pose = new RadioButton();
            rb_yolov8_seg = new RadioButton();
            rb_yolo_world = new RadioButton();
            rb_yolov_seg = new RadioButton();
            rb_yolov9_det = new RadioButton();
            rb_yolov8_det = new RadioButton();
            rb_yolov7_det = new RadioButton();
            rb_yolov5_cls = new RadioButton();
            rb_yolov6_det = new RadioButton();
            rb_yolov5_seg = new RadioButton();
            rb_yolov5_det = new RadioButton();
            btn_class_select = new Button();
            label3 = new Label();
            tb_class_path = new TextBox();
            btn_input_select = new Button();
            label4 = new Label();
            tb_input_path = new TextBox();
            cb_device = new ComboBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            btn_model_select = new Button();
            label2 = new Label();
            tb_model_path = new TextBox();
            panel2 = new Panel();
            tb_msg_image = new TextBox();
            label6 = new Label();
            btn_load_model = new Button();
            tc_operate = new TabControl();
            tabPage1 = new TabPage();
            btn_image_infer = new Button();
            tabPage2 = new TabPage();
            pb_video = new ProgressBar();
            btn_time = new Button();
            btn_stop = new Button();
            btn_start = new Button();
            btn_video_infer = new Button();
            label7 = new Label();
            tb_msg_video = new TextBox();
            panel4 = new Panel();
            label8 = new Label();
            label9 = new Label();
            tb_score = new TextBox();
            tb_nms = new TextBox();
            groupBox1 = new GroupBox();
            label11 = new Label();
            tb_categ_num = new TextBox();
            tb_input_size = new TextBox();
            label10 = new Label();
            chb_time = new CheckBox();
            chb_fps = new CheckBox();
            rb_yolov10_det = new RadioButton();
            gb_engine.SuspendLayout();
            gb_model.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tc_operate.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(560, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(616, 36);
            label1.TabIndex = 1;
            label1.Text = "YOLO Model Deployment Testing Platform";
            // 
            // gb_engine
            // 
            gb_engine.Controls.Add(rb_opencv);
            gb_engine.Controls.Add(rb_onnx);
            gb_engine.Controls.Add(rb_tensorrt);
            gb_engine.Controls.Add(rb_openvino);
            gb_engine.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            gb_engine.Location = new Point(22, 522);
            gb_engine.Margin = new Padding(2, 3, 2, 3);
            gb_engine.Name = "gb_engine";
            gb_engine.Padding = new Padding(2, 3, 2, 3);
            gb_engine.Size = new Size(282, 90);
            gb_engine.TabIndex = 4;
            gb_engine.TabStop = false;
            gb_engine.Text = "Inference Engine";
            // 
            // rb_opencv
            // 
            rb_opencv.AutoSize = true;
            rb_opencv.Location = new Point(154, 54);
            rb_opencv.Margin = new Padding(2, 3, 2, 3);
            rb_opencv.Name = "rb_opencv";
            rb_opencv.Size = new Size(85, 23);
            rb_opencv.TabIndex = 3;
            rb_opencv.Text = "OpenCV";
            rb_opencv.UseVisualStyleBackColor = true;
            rb_opencv.CheckedChanged += rb_opencv_CheckedChanged;
            // 
            // rb_onnx
            // 
            rb_onnx.AutoSize = true;
            rb_onnx.Location = new Point(15, 54);
            rb_onnx.Margin = new Padding(2, 3, 2, 3);
            rb_onnx.Name = "rb_onnx";
            rb_onnx.Size = new Size(74, 23);
            rb_onnx.TabIndex = 2;
            rb_onnx.Text = "ONNX";
            rb_onnx.UseVisualStyleBackColor = true;
            rb_onnx.CheckedChanged += rb_onnx_CheckedChanged;
            // 
            // rb_tensorrt
            // 
            rb_tensorrt.AutoSize = true;
            rb_tensorrt.Location = new Point(154, 25);
            rb_tensorrt.Margin = new Padding(2, 3, 2, 3);
            rb_tensorrt.Name = "rb_tensorrt";
            rb_tensorrt.Size = new Size(94, 23);
            rb_tensorrt.TabIndex = 1;
            rb_tensorrt.Text = "TensorRT";
            rb_tensorrt.UseVisualStyleBackColor = true;
            rb_tensorrt.CheckedChanged += rb_tensorrt_CheckedChanged;
            // 
            // rb_openvino
            // 
            rb_openvino.AutoSize = true;
            rb_openvino.Checked = true;
            rb_openvino.Location = new Point(15, 25);
            rb_openvino.Margin = new Padding(2, 3, 2, 3);
            rb_openvino.Name = "rb_openvino";
            rb_openvino.Size = new Size(104, 23);
            rb_openvino.TabIndex = 0;
            rb_openvino.TabStop = true;
            rb_openvino.Text = "OpenVINO";
            rb_openvino.UseVisualStyleBackColor = true;
            rb_openvino.CheckedChanged += rb_openvino_CheckedChanged;
            // 
            // gb_model
            // 
            gb_model.Controls.Add(rb_yolov8_obb);
            gb_model.Controls.Add(rb_yolov8_cls);
            gb_model.Controls.Add(rb_yolov8_pose);
            gb_model.Controls.Add(rb_yolov8_seg);
            gb_model.Controls.Add(rb_yolo_world);
            gb_model.Controls.Add(rb_yolov_seg);
            gb_model.Controls.Add(rb_yolov9_det);
            gb_model.Controls.Add(rb_yolov10_det);
            gb_model.Controls.Add(rb_yolov8_det);
            gb_model.Controls.Add(rb_yolov7_det);
            gb_model.Controls.Add(rb_yolov5_cls);
            gb_model.Controls.Add(rb_yolov6_det);
            gb_model.Controls.Add(rb_yolov5_seg);
            gb_model.Controls.Add(rb_yolov5_det);
            gb_model.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            gb_model.Location = new Point(20, 118);
            gb_model.Margin = new Padding(2, 3, 2, 3);
            gb_model.Name = "gb_model";
            gb_model.Padding = new Padding(2, 3, 2, 3);
            gb_model.Size = new Size(527, 159);
            gb_model.TabIndex = 4;
            gb_model.TabStop = false;
            gb_model.Text = "Model";
            // 
            // rb_yolov8_obb
            // 
            rb_yolov8_obb.AutoSize = true;
            rb_yolov8_obb.Location = new Point(283, 32);
            rb_yolov8_obb.Margin = new Padding(2, 3, 2, 3);
            rb_yolov8_obb.Name = "rb_yolov8_obb";
            rb_yolov8_obb.Size = new Size(115, 23);
            rb_yolov8_obb.TabIndex = 3;
            rb_yolov8_obb.Text = "YOLOv8Obb";
            rb_yolov8_obb.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_cls
            // 
            rb_yolov8_cls.AutoSize = true;
            rb_yolov8_cls.Location = new Point(284, 64);
            rb_yolov8_cls.Margin = new Padding(2, 3, 2, 3);
            rb_yolov8_cls.Name = "rb_yolov8_cls";
            rb_yolov8_cls.Size = new Size(109, 23);
            rb_yolov8_cls.TabIndex = 3;
            rb_yolov8_cls.Text = "YOLOv8Cls";
            rb_yolov8_cls.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_pose
            // 
            rb_yolov8_pose.AutoSize = true;
            rb_yolov8_pose.Location = new Point(149, 128);
            rb_yolov8_pose.Margin = new Padding(2, 3, 2, 3);
            rb_yolov8_pose.Name = "rb_yolov8_pose";
            rb_yolov8_pose.Size = new Size(119, 23);
            rb_yolov8_pose.TabIndex = 3;
            rb_yolov8_pose.Text = "YOLOv8Pose";
            rb_yolov8_pose.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_seg
            // 
            rb_yolov8_seg.AutoSize = true;
            rb_yolov8_seg.Location = new Point(149, 96);
            rb_yolov8_seg.Margin = new Padding(2, 3, 2, 3);
            rb_yolov8_seg.Name = "rb_yolov8_seg";
            rb_yolov8_seg.Size = new Size(112, 23);
            rb_yolov8_seg.TabIndex = 3;
            rb_yolov8_seg.Text = "YOLOv8Seg";
            rb_yolov8_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolo_world
            // 
            rb_yolo_world.AutoSize = true;
            rb_yolo_world.Location = new Point(407, 32);
            rb_yolo_world.Margin = new Padding(2, 3, 2, 3);
            rb_yolo_world.Name = "rb_yolo_world";
            rb_yolo_world.Size = new Size(111, 23);
            rb_yolo_world.TabIndex = 3;
            rb_yolo_world.Text = "YOLOWorld";
            rb_yolo_world.UseVisualStyleBackColor = true;
            // 
            // rb_yolov_seg
            // 
            rb_yolov_seg.AutoSize = true;
            rb_yolov_seg.Location = new Point(286, 128);
            rb_yolov_seg.Margin = new Padding(2, 3, 2, 3);
            rb_yolov_seg.Name = "rb_yolov_seg";
            rb_yolov_seg.Size = new Size(112, 23);
            rb_yolov_seg.TabIndex = 3;
            rb_yolov_seg.Text = "YOLOv9Seg";
            rb_yolov_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov9_det
            // 
            rb_yolov9_det.AutoSize = true;
            rb_yolov9_det.Location = new Point(286, 96);
            rb_yolov9_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov9_det.Name = "rb_yolov9_det";
            rb_yolov9_det.Size = new Size(112, 23);
            rb_yolov9_det.TabIndex = 3;
            rb_yolov9_det.Text = "YOLOv9Det";
            rb_yolov9_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_det
            // 
            rb_yolov8_det.AutoSize = true;
            rb_yolov8_det.Location = new Point(147, 64);
            rb_yolov8_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov8_det.Name = "rb_yolov8_det";
            rb_yolov8_det.Size = new Size(112, 23);
            rb_yolov8_det.TabIndex = 3;
            rb_yolov8_det.Text = "YOLOv8Det";
            rb_yolov8_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov7_det
            // 
            rb_yolov7_det.AutoSize = true;
            rb_yolov7_det.Location = new Point(147, 32);
            rb_yolov7_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov7_det.Name = "rb_yolov7_det";
            rb_yolov7_det.Size = new Size(112, 23);
            rb_yolov7_det.TabIndex = 3;
            rb_yolov7_det.Text = "YOLOv7Det";
            rb_yolov7_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_cls
            // 
            rb_yolov5_cls.AutoSize = true;
            rb_yolov5_cls.Location = new Point(18, 96);
            rb_yolov5_cls.Margin = new Padding(2, 3, 2, 3);
            rb_yolov5_cls.Name = "rb_yolov5_cls";
            rb_yolov5_cls.Size = new Size(109, 23);
            rb_yolov5_cls.TabIndex = 2;
            rb_yolov5_cls.Text = "YOLOv5Cls";
            rb_yolov5_cls.UseVisualStyleBackColor = true;
            // 
            // rb_yolov6_det
            // 
            rb_yolov6_det.AutoSize = true;
            rb_yolov6_det.Location = new Point(18, 128);
            rb_yolov6_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov6_det.Name = "rb_yolov6_det";
            rb_yolov6_det.Size = new Size(112, 23);
            rb_yolov6_det.TabIndex = 2;
            rb_yolov6_det.Text = "YOLOv6Det";
            rb_yolov6_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_seg
            // 
            rb_yolov5_seg.AutoSize = true;
            rb_yolov5_seg.Location = new Point(16, 64);
            rb_yolov5_seg.Margin = new Padding(2, 3, 2, 3);
            rb_yolov5_seg.Name = "rb_yolov5_seg";
            rb_yolov5_seg.Size = new Size(112, 23);
            rb_yolov5_seg.TabIndex = 1;
            rb_yolov5_seg.Text = "YOLOv5Seg";
            rb_yolov5_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_det
            // 
            rb_yolov5_det.AutoSize = true;
            rb_yolov5_det.Checked = true;
            rb_yolov5_det.Location = new Point(15, 32);
            rb_yolov5_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov5_det.Name = "rb_yolov5_det";
            rb_yolov5_det.Size = new Size(112, 23);
            rb_yolov5_det.TabIndex = 0;
            rb_yolov5_det.TabStop = true;
            rb_yolov5_det.Text = "YOLOv5Det";
            rb_yolov5_det.UseVisualStyleBackColor = true;
            // 
            // btn_class_select
            // 
            btn_class_select.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_class_select.Location = new Point(523, 295);
            btn_class_select.Margin = new Padding(2, 3, 2, 3);
            btn_class_select.Name = "btn_class_select";
            btn_class_select.Size = new Size(88, 28);
            btn_class_select.TabIndex = 0;
            btn_class_select.Text = "Select";
            btn_class_select.UseVisualStyleBackColor = true;
            btn_class_select.Click += btn_class_select_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(20, 301);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(85, 19);
            label3.TabIndex = 2;
            label3.Text = "Class Path:";
            // 
            // tb_class_path
            // 
            tb_class_path.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_class_path.Location = new Point(125, 297);
            tb_class_path.Margin = new Padding(2, 3, 2, 3);
            tb_class_path.Name = "tb_class_path";
            tb_class_path.Size = new Size(384, 26);
            tb_class_path.TabIndex = 3;
            // 
            // btn_input_select
            // 
            btn_input_select.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_input_select.Location = new Point(523, 342);
            btn_input_select.Margin = new Padding(2, 3, 2, 3);
            btn_input_select.Name = "btn_input_select";
            btn_input_select.Size = new Size(88, 27);
            btn_input_select.TabIndex = 0;
            btn_input_select.Text = "Select";
            btn_input_select.UseVisualStyleBackColor = true;
            btn_input_select.Click += btn_input_select_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(20, 347);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 19);
            label4.TabIndex = 2;
            label4.Text = "Input Path:";
            // 
            // tb_input_path
            // 
            tb_input_path.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_input_path.Location = new Point(125, 343);
            tb_input_path.Margin = new Padding(2, 3, 2, 3);
            tb_input_path.Name = "tb_input_path";
            tb_input_path.Size = new Size(384, 26);
            tb_input_path.TabIndex = 3;
            // 
            // cb_device
            // 
            cb_device.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cb_device.FormattingEnabled = true;
            cb_device.Items.AddRange(new object[] { "CPU", "GPU" });
            cb_device.Location = new Point(394, 536);
            cb_device.Margin = new Padding(2, 3, 2, 3);
            cb_device.Name = "cb_device";
            cb_device.Size = new Size(153, 27);
            cb_device.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(327, 539);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 19);
            label5.TabIndex = 2;
            label5.Text = "Device:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(658, 61);
            pictureBox1.Margin = new Padding(2, 3, 2, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(825, 520);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveBorder;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(658, 608);
            pictureBox2.Margin = new Padding(2, 3, 2, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(825, 520);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(646, 55);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(4, 1546);
            panel1.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Location = new Point(650, 593);
            panel3.Margin = new Padding(2, 3, 2, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1030, 4);
            panel3.TabIndex = 6;
            // 
            // btn_model_select
            // 
            btn_model_select.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_model_select.Location = new Point(523, 71);
            btn_model_select.Margin = new Padding(2, 3, 2, 3);
            btn_model_select.Name = "btn_model_select";
            btn_model_select.Size = new Size(88, 30);
            btn_model_select.TabIndex = 0;
            btn_model_select.Text = "Select";
            btn_model_select.UseVisualStyleBackColor = true;
            btn_model_select.Click += btn_model_select_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(20, 79);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 19);
            label2.TabIndex = 2;
            label2.Text = "Model Path:";
            // 
            // tb_model_path
            // 
            tb_model_path.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_model_path.Location = new Point(125, 75);
            tb_model_path.Margin = new Padding(2, 3, 2, 3);
            tb_model_path.Name = "tb_model_path";
            tb_model_path.Size = new Size(384, 26);
            tb_model_path.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(-12, 51);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1676, 4);
            panel2.TabIndex = 6;
            // 
            // tb_msg_image
            // 
            tb_msg_image.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_msg_image.Location = new Point(15, 165);
            tb_msg_image.Margin = new Padding(2, 3, 2, 3);
            tb_msg_image.Multiline = true;
            tb_msg_image.Name = "tb_msg_image";
            tb_msg_image.ScrollBars = ScrollBars.Both;
            tb_msg_image.Size = new Size(598, 307);
            tb_msg_image.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(201, 117);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(205, 24);
            label6.TabIndex = 1;
            label6.Text = "Inference Information";
            // 
            // btn_load_model
            // 
            btn_load_model.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_load_model.Location = new Point(376, 576);
            btn_load_model.Margin = new Padding(2, 3, 2, 3);
            btn_load_model.Name = "btn_load_model";
            btn_load_model.Size = new Size(133, 37);
            btn_load_model.TabIndex = 0;
            btn_load_model.Text = "Load Model";
            btn_load_model.UseVisualStyleBackColor = true;
            btn_load_model.Click += btn_load_model_Click;
            // 
            // tc_operate
            // 
            tc_operate.Controls.Add(tabPage1);
            tc_operate.Controls.Add(tabPage2);
            tc_operate.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            tc_operate.Location = new Point(3, 641);
            tc_operate.Margin = new Padding(4);
            tc_operate.Name = "tc_operate";
            tc_operate.SelectedIndex = 0;
            tc_operate.Size = new Size(637, 532);
            tc_operate.TabIndex = 8;
            tc_operate.SelectedIndexChanged += tc_operate_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tb_msg_image);
            tabPage1.Controls.Add(btn_image_infer);
            tabPage1.Location = new Point(4, 31);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(629, 497);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  Image  ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_image_infer
            // 
            btn_image_infer.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_image_infer.Location = new Point(233, 31);
            btn_image_infer.Margin = new Padding(2, 3, 2, 3);
            btn_image_infer.Name = "btn_image_infer";
            btn_image_infer.Size = new Size(133, 62);
            btn_image_infer.TabIndex = 0;
            btn_image_infer.Text = "Infer";
            btn_image_infer.UseVisualStyleBackColor = true;
            btn_image_infer.Click += btn_image_infer_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pb_video);
            tabPage2.Controls.Add(btn_time);
            tabPage2.Controls.Add(btn_stop);
            tabPage2.Controls.Add(btn_start);
            tabPage2.Controls.Add(btn_video_infer);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(tb_msg_video);
            tabPage2.Location = new Point(4, 31);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(629, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "  Video  ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pb_video
            // 
            pb_video.Location = new Point(46, 438);
            pb_video.Margin = new Padding(4);
            pb_video.Name = "pb_video";
            pb_video.Size = new Size(538, 33);
            pb_video.Step = 1;
            pb_video.Style = ProgressBarStyle.Continuous;
            pb_video.TabIndex = 12;
            pb_video.Value = 1;
            // 
            // btn_time
            // 
            btn_time.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_time.Location = new Point(539, 33);
            btn_time.Margin = new Padding(2, 3, 2, 3);
            btn_time.Name = "btn_time";
            btn_time.Size = new Size(75, 42);
            btn_time.TabIndex = 11;
            btn_time.Text = "Time";
            btn_time.UseVisualStyleBackColor = true;
            btn_time.Click += btn_time_Click;
            // 
            // btn_stop
            // 
            btn_stop.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_stop.Location = new Point(369, 33);
            btn_stop.Margin = new Padding(2, 3, 2, 3);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(133, 42);
            btn_stop.TabIndex = 11;
            btn_stop.Text = "Stop";
            btn_stop.UseVisualStyleBackColor = true;
            btn_stop.Click += btn_stop_Click;
            // 
            // btn_start
            // 
            btn_start.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_start.Location = new Point(191, 33);
            btn_start.Margin = new Padding(2, 3, 2, 3);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(133, 42);
            btn_start.TabIndex = 11;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // btn_video_infer
            // 
            btn_video_infer.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_video_infer.Location = new Point(28, 33);
            btn_video_infer.Margin = new Padding(2, 3, 2, 3);
            btn_video_infer.Name = "btn_video_infer";
            btn_video_infer.Size = new Size(133, 42);
            btn_video_infer.TabIndex = 11;
            btn_video_infer.Text = "Infer";
            btn_video_infer.UseVisualStyleBackColor = true;
            btn_video_infer.Click += btn_video_infer_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(201, 92);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(205, 24);
            label7.TabIndex = 9;
            label7.Text = "Inference Information";
            // 
            // tb_msg_video
            // 
            tb_msg_video.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_msg_video.Location = new Point(16, 119);
            tb_msg_video.Margin = new Padding(2, 3, 2, 3);
            tb_msg_video.Multiline = true;
            tb_msg_video.Name = "tb_msg_video";
            tb_msg_video.ScrollBars = ScrollBars.Both;
            tb_msg_video.Size = new Size(598, 311);
            tb_msg_video.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDark;
            panel4.Location = new Point(-2, 630);
            panel4.Margin = new Padding(2, 3, 2, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(651, 4);
            panel4.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(2, 35);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(112, 19);
            label8.TabIndex = 2;
            label8.Text = "Score Threshold:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(1, 81);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(111, 19);
            label9.TabIndex = 2;
            label9.Text = "NMS Threshold:";
            // 
            // tb_score
            // 
            tb_score.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_score.Location = new Point(136, 31);
            tb_score.Margin = new Padding(2, 3, 2, 3);
            tb_score.Name = "tb_score";
            tb_score.Size = new Size(83, 26);
            tb_score.TabIndex = 3;
            tb_score.Text = "0.6";
            tb_score.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_nms
            // 
            tb_nms.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_nms.Location = new Point(136, 77);
            tb_nms.Margin = new Padding(2, 3, 2, 3);
            tb_nms.Name = "tb_nms";
            tb_nms.Size = new Size(83, 26);
            tb_nms.TabIndex = 3;
            tb_nms.Text = "0.5";
            tb_nms.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(tb_score);
            groupBox1.Controls.Add(tb_categ_num);
            groupBox1.Controls.Add(tb_nms);
            groupBox1.Controls.Add(tb_input_size);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label10);
            groupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(20, 391);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(434, 113);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Inference Params";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(243, 79);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(72, 19);
            label11.TabIndex = 2;
            label11.Text = "Input Size:";
            // 
            // tb_categ_num
            // 
            tb_categ_num.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_categ_num.Location = new Point(336, 31);
            tb_categ_num.Margin = new Padding(2, 3, 2, 3);
            tb_categ_num.Name = "tb_categ_num";
            tb_categ_num.Size = new Size(83, 26);
            tb_categ_num.TabIndex = 3;
            tb_categ_num.Text = "80";
            tb_categ_num.TextAlign = HorizontalAlignment.Center;
            // 
            // tb_input_size
            // 
            tb_input_size.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_input_size.Location = new Point(334, 75);
            tb_input_size.Margin = new Padding(2, 3, 2, 3);
            tb_input_size.Name = "tb_input_size";
            tb_input_size.Size = new Size(83, 26);
            tb_input_size.TabIndex = 3;
            tb_input_size.Text = "640";
            tb_input_size.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(236, 35);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(82, 19);
            label10.TabIndex = 2;
            label10.Text = "Categ Num:";
            // 
            // chb_time
            // 
            chb_time.AutoSize = true;
            chb_time.Checked = true;
            chb_time.CheckState = CheckState.Checked;
            chb_time.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chb_time.Location = new Point(472, 413);
            chb_time.Margin = new Padding(4);
            chb_time.Name = "chb_time";
            chb_time.Size = new Size(138, 20);
            chb_time.TabIndex = 10;
            chb_time.Text = "Time Detection";
            chb_time.UseVisualStyleBackColor = true;
            chb_time.CheckedChanged += chb_time_CheckedChanged;
            // 
            // chb_fps
            // 
            chb_fps.AutoSize = true;
            chb_fps.Checked = true;
            chb_fps.CheckState = CheckState.Checked;
            chb_fps.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chb_fps.Location = new Point(472, 467);
            chb_fps.Margin = new Padding(4);
            chb_fps.Name = "chb_fps";
            chb_fps.Size = new Size(90, 20);
            chb_fps.TabIndex = 10;
            chb_fps.Text = "FPS Draw";
            chb_fps.UseVisualStyleBackColor = true;
            chb_fps.CheckedChanged += chb_fps_CheckedChanged;
            // 
            // rb_yolov10_det
            // 
            rb_yolov10_det.AutoSize = true;
            rb_yolov10_det.Location = new Point(407, 61);
            rb_yolov10_det.Margin = new Padding(2, 3, 2, 3);
            rb_yolov10_det.Name = "rb_yolov10_det";
            rb_yolov10_det.Size = new Size(120, 23);
            rb_yolov10_det.TabIndex = 3;
            rb_yolov10_det.Text = "YOLOv10Det";
            rb_yolov10_det.UseVisualStyleBackColor = true;
            // 
            // YoloDeployPlatform
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 1156);
            Controls.Add(chb_fps);
            Controls.Add(chb_time);
            Controls.Add(groupBox1);
            Controls.Add(tc_operate);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cb_device);
            Controls.Add(gb_model);
            Controls.Add(gb_engine);
            Controls.Add(tb_input_path);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tb_class_path);
            Controls.Add(label3);
            Controls.Add(tb_model_path);
            Controls.Add(btn_load_model);
            Controls.Add(btn_input_select);
            Controls.Add(label2);
            Controls.Add(btn_class_select);
            Controls.Add(label1);
            Controls.Add(btn_model_select);
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            Name = "YoloDeployPlatform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YoloDeployPlatform";
            Load += Form1_Load;
            gb_engine.ResumeLayout(false);
            gb_engine.PerformLayout();
            gb_model.ResumeLayout(false);
            gb_model.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tc_operate.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_engine;
        private System.Windows.Forms.RadioButton rb_opencv;
        private System.Windows.Forms.RadioButton rb_onnx;
        private System.Windows.Forms.RadioButton rb_tensorrt;
        private System.Windows.Forms.RadioButton rb_openvino;
        private System.Windows.Forms.GroupBox gb_model;
        private System.Windows.Forms.RadioButton rb_yolov7_det;
        private System.Windows.Forms.RadioButton rb_yolov6_det;
        private System.Windows.Forms.RadioButton rb_yolov5_seg;
        private System.Windows.Forms.RadioButton rb_yolov5_det;
        private System.Windows.Forms.RadioButton rb_yolov8_cls;
        private System.Windows.Forms.RadioButton rb_yolov8_pose;
        private System.Windows.Forms.RadioButton rb_yolov8_seg;
        private System.Windows.Forms.RadioButton rb_yolov8_det;
        private System.Windows.Forms.RadioButton rb_yolov8_obb;
        private System.Windows.Forms.RadioButton rb_yolov_seg;
        private System.Windows.Forms.RadioButton rb_yolov9_det;
        private System.Windows.Forms.ComboBox cb_device;
        private System.Windows.Forms.Button btn_class_select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_class_path;
        private System.Windows.Forms.Button btn_input_select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_input_path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_model_select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_model_path;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_msg_image;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_load_model;
        private System.Windows.Forms.RadioButton rb_yolo_world;
        private System.Windows.Forms.TabControl tc_operate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_msg_video;
        private System.Windows.Forms.Button btn_image_infer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_score;
        private System.Windows.Forms.TextBox tb_nms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_categ_num;
        private System.Windows.Forms.TextBox tb_input_size;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chb_time;
        private System.Windows.Forms.CheckBox chb_fps;
        private System.Windows.Forms.RadioButton rb_yolov5_cls;
        private System.Windows.Forms.Button btn_video_infer;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ProgressBar pb_video;
        private System.Windows.Forms.Button btn_time;
        private RadioButton rb_yolov10_det;
    }
}
