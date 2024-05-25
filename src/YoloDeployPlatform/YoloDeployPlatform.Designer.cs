namespace YoloDeployPlatform
{
    partial class YoloDeployPlatform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gb_engine = new System.Windows.Forms.GroupBox();
            this.rb_opencv = new System.Windows.Forms.RadioButton();
            this.rb_onnx = new System.Windows.Forms.RadioButton();
            this.rb_tensorrt = new System.Windows.Forms.RadioButton();
            this.rb_openvino = new System.Windows.Forms.RadioButton();
            this.gb_model = new System.Windows.Forms.GroupBox();
            this.rb_yolov8_obb = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_cls = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_pose = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_seg = new System.Windows.Forms.RadioButton();
            this.rb_yolo_world = new System.Windows.Forms.RadioButton();
            this.rb_yolov_seg = new System.Windows.Forms.RadioButton();
            this.rb_yolov9_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov7_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov5_cls = new System.Windows.Forms.RadioButton();
            this.rb_yolov6_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov5_seg = new System.Windows.Forms.RadioButton();
            this.rb_yolov5_det = new System.Windows.Forms.RadioButton();
            this.btn_class_select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_class_path = new System.Windows.Forms.TextBox();
            this.btn_input_select = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_input_path = new System.Windows.Forms.TextBox();
            this.cb_device = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_model_select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_model_path = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_msg_image = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_load_model = new System.Windows.Forms.Button();
            this.tc_operate = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_image_infer = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pb_video = new System.Windows.Forms.ProgressBar();
            this.btn_time = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_video_infer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_msg_video = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_score = new System.Windows.Forms.TextBox();
            this.tb_nms = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_categ_num = new System.Windows.Forms.TextBox();
            this.tb_input_size = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chb_time = new System.Windows.Forms.CheckBox();
            this.chb_fps = new System.Windows.Forms.CheckBox();
            this.rb_yolov10_det = new System.Windows.Forms.RadioButton();
            this.gb_engine.SuspendLayout();
            this.gb_model.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tc_operate.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "YOLO Model Deployment Testing Platform";
            // 
            // gb_engine
            // 
            this.gb_engine.Controls.Add(this.rb_opencv);
            this.gb_engine.Controls.Add(this.rb_onnx);
            this.gb_engine.Controls.Add(this.rb_tensorrt);
            this.gb_engine.Controls.Add(this.rb_openvino);
            this.gb_engine.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_engine.Location = new System.Drawing.Point(23, 504);
            this.gb_engine.Margin = new System.Windows.Forms.Padding(2);
            this.gb_engine.Name = "gb_engine";
            this.gb_engine.Padding = new System.Windows.Forms.Padding(2);
            this.gb_engine.Size = new System.Drawing.Size(258, 103);
            this.gb_engine.TabIndex = 4;
            this.gb_engine.TabStop = false;
            this.gb_engine.Text = "Inference Engine";
            // 
            // rb_opencv
            // 
            this.rb_opencv.AutoSize = true;
            this.rb_opencv.Location = new System.Drawing.Point(148, 70);
            this.rb_opencv.Margin = new System.Windows.Forms.Padding(2);
            this.rb_opencv.Name = "rb_opencv";
            this.rb_opencv.Size = new System.Drawing.Size(85, 23);
            this.rb_opencv.TabIndex = 3;
            this.rb_opencv.Text = "OpenCV";
            this.rb_opencv.UseVisualStyleBackColor = true;
            this.rb_opencv.CheckedChanged += new System.EventHandler(this.rb_opencv_CheckedChanged);
            // 
            // rb_onnx
            // 
            this.rb_onnx.AutoSize = true;
            this.rb_onnx.Location = new System.Drawing.Point(13, 70);
            this.rb_onnx.Margin = new System.Windows.Forms.Padding(2);
            this.rb_onnx.Name = "rb_onnx";
            this.rb_onnx.Size = new System.Drawing.Size(74, 23);
            this.rb_onnx.TabIndex = 2;
            this.rb_onnx.Text = "ONNX";
            this.rb_onnx.UseVisualStyleBackColor = true;
            this.rb_onnx.CheckedChanged += new System.EventHandler(this.rb_onnx_CheckedChanged);
            // 
            // rb_tensorrt
            // 
            this.rb_tensorrt.AutoSize = true;
            this.rb_tensorrt.Location = new System.Drawing.Point(141, 30);
            this.rb_tensorrt.Margin = new System.Windows.Forms.Padding(2);
            this.rb_tensorrt.Name = "rb_tensorrt";
            this.rb_tensorrt.Size = new System.Drawing.Size(94, 23);
            this.rb_tensorrt.TabIndex = 1;
            this.rb_tensorrt.Text = "TensorRT";
            this.rb_tensorrt.UseVisualStyleBackColor = true;
            this.rb_tensorrt.CheckedChanged += new System.EventHandler(this.rb_tensorrt_CheckedChanged);
            // 
            // rb_openvino
            // 
            this.rb_openvino.AutoSize = true;
            this.rb_openvino.Checked = true;
            this.rb_openvino.Location = new System.Drawing.Point(13, 30);
            this.rb_openvino.Margin = new System.Windows.Forms.Padding(2);
            this.rb_openvino.Name = "rb_openvino";
            this.rb_openvino.Size = new System.Drawing.Size(104, 23);
            this.rb_openvino.TabIndex = 0;
            this.rb_openvino.TabStop = true;
            this.rb_openvino.Text = "OpenVINO";
            this.rb_openvino.UseVisualStyleBackColor = true;
            this.rb_openvino.CheckedChanged += new System.EventHandler(this.rb_openvino_CheckedChanged);
            // 
            // gb_model
            // 
            this.gb_model.Controls.Add(this.rb_yolov8_obb);
            this.gb_model.Controls.Add(this.rb_yolov8_cls);
            this.gb_model.Controls.Add(this.rb_yolov8_pose);
            this.gb_model.Controls.Add(this.rb_yolov8_seg);
            this.gb_model.Controls.Add(this.rb_yolo_world);
            this.gb_model.Controls.Add(this.rb_yolov_seg);
            this.gb_model.Controls.Add(this.rb_yolov9_det);
            this.gb_model.Controls.Add(this.rb_yolov10_det);
            this.gb_model.Controls.Add(this.rb_yolov8_det);
            this.gb_model.Controls.Add(this.rb_yolov7_det);
            this.gb_model.Controls.Add(this.rb_yolov5_cls);
            this.gb_model.Controls.Add(this.rb_yolov6_det);
            this.gb_model.Controls.Add(this.rb_yolov5_seg);
            this.gb_model.Controls.Add(this.rb_yolov5_det);
            this.gb_model.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_model.Location = new System.Drawing.Point(20, 115);
            this.gb_model.Margin = new System.Windows.Forms.Padding(2);
            this.gb_model.Name = "gb_model";
            this.gb_model.Padding = new System.Windows.Forms.Padding(2);
            this.gb_model.Size = new System.Drawing.Size(523, 161);
            this.gb_model.TabIndex = 4;
            this.gb_model.TabStop = false;
            this.gb_model.Text = "Model";
            // 
            // rb_yolov8_obb
            // 
            this.rb_yolov8_obb.AutoSize = true;
            this.rb_yolov8_obb.Location = new System.Drawing.Point(263, 30);
            this.rb_yolov8_obb.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_obb.Name = "rb_yolov8_obb";
            this.rb_yolov8_obb.Size = new System.Drawing.Size(115, 23);
            this.rb_yolov8_obb.TabIndex = 3;
            this.rb_yolov8_obb.Text = "YOLOv8Obb";
            this.rb_yolov8_obb.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_cls
            // 
            this.rb_yolov8_cls.AutoSize = true;
            this.rb_yolov8_cls.Location = new System.Drawing.Point(263, 61);
            this.rb_yolov8_cls.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_cls.Name = "rb_yolov8_cls";
            this.rb_yolov8_cls.Size = new System.Drawing.Size(109, 23);
            this.rb_yolov8_cls.TabIndex = 3;
            this.rb_yolov8_cls.Text = "YOLOv8Cls";
            this.rb_yolov8_cls.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_pose
            // 
            this.rb_yolov8_pose.AutoSize = true;
            this.rb_yolov8_pose.Location = new System.Drawing.Point(139, 125);
            this.rb_yolov8_pose.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_pose.Name = "rb_yolov8_pose";
            this.rb_yolov8_pose.Size = new System.Drawing.Size(119, 23);
            this.rb_yolov8_pose.TabIndex = 3;
            this.rb_yolov8_pose.Text = "YOLOv8Pose";
            this.rb_yolov8_pose.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_seg
            // 
            this.rb_yolov8_seg.AutoSize = true;
            this.rb_yolov8_seg.Location = new System.Drawing.Point(139, 92);
            this.rb_yolov8_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_seg.Name = "rb_yolov8_seg";
            this.rb_yolov8_seg.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov8_seg.TabIndex = 3;
            this.rb_yolov8_seg.Text = "YOLOv8Seg";
            this.rb_yolov8_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolo_world
            // 
            this.rb_yolo_world.AutoSize = true;
            this.rb_yolo_world.Location = new System.Drawing.Point(392, 30);
            this.rb_yolo_world.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolo_world.Name = "rb_yolo_world";
            this.rb_yolo_world.Size = new System.Drawing.Size(111, 23);
            this.rb_yolo_world.TabIndex = 3;
            this.rb_yolo_world.Text = "YOLOWorld";
            this.rb_yolo_world.UseVisualStyleBackColor = true;
            // 
            // rb_yolov_seg
            // 
            this.rb_yolov_seg.AutoSize = true;
            this.rb_yolov_seg.Location = new System.Drawing.Point(263, 125);
            this.rb_yolov_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov_seg.Name = "rb_yolov_seg";
            this.rb_yolov_seg.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov_seg.TabIndex = 3;
            this.rb_yolov_seg.Text = "YOLOv9Seg";
            this.rb_yolov_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov9_det
            // 
            this.rb_yolov9_det.AutoSize = true;
            this.rb_yolov9_det.Location = new System.Drawing.Point(263, 92);
            this.rb_yolov9_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov9_det.Name = "rb_yolov9_det";
            this.rb_yolov9_det.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov9_det.TabIndex = 3;
            this.rb_yolov9_det.Text = "YOLOv9Det";
            this.rb_yolov9_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_det
            // 
            this.rb_yolov8_det.AutoSize = true;
            this.rb_yolov8_det.Location = new System.Drawing.Point(139, 61);
            this.rb_yolov8_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_det.Name = "rb_yolov8_det";
            this.rb_yolov8_det.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov8_det.TabIndex = 3;
            this.rb_yolov8_det.Text = "YOLOv8Det";
            this.rb_yolov8_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov7_det
            // 
            this.rb_yolov7_det.AutoSize = true;
            this.rb_yolov7_det.Location = new System.Drawing.Point(140, 30);
            this.rb_yolov7_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov7_det.Name = "rb_yolov7_det";
            this.rb_yolov7_det.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov7_det.TabIndex = 3;
            this.rb_yolov7_det.Text = "YOLOv7Det";
            this.rb_yolov7_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_cls
            // 
            this.rb_yolov5_cls.AutoSize = true;
            this.rb_yolov5_cls.Location = new System.Drawing.Point(13, 92);
            this.rb_yolov5_cls.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov5_cls.Name = "rb_yolov5_cls";
            this.rb_yolov5_cls.Size = new System.Drawing.Size(109, 23);
            this.rb_yolov5_cls.TabIndex = 2;
            this.rb_yolov5_cls.Text = "YOLOv5Cls";
            this.rb_yolov5_cls.UseVisualStyleBackColor = true;
            // 
            // rb_yolov6_det
            // 
            this.rb_yolov6_det.AutoSize = true;
            this.rb_yolov6_det.Location = new System.Drawing.Point(13, 125);
            this.rb_yolov6_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov6_det.Name = "rb_yolov6_det";
            this.rb_yolov6_det.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov6_det.TabIndex = 2;
            this.rb_yolov6_det.Text = "YOLOv6Det";
            this.rb_yolov6_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_seg
            // 
            this.rb_yolov5_seg.AutoSize = true;
            this.rb_yolov5_seg.Location = new System.Drawing.Point(13, 61);
            this.rb_yolov5_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov5_seg.Name = "rb_yolov5_seg";
            this.rb_yolov5_seg.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov5_seg.TabIndex = 1;
            this.rb_yolov5_seg.Text = "YOLOv5Seg";
            this.rb_yolov5_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_det
            // 
            this.rb_yolov5_det.AutoSize = true;
            this.rb_yolov5_det.Checked = true;
            this.rb_yolov5_det.Location = new System.Drawing.Point(13, 30);
            this.rb_yolov5_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov5_det.Name = "rb_yolov5_det";
            this.rb_yolov5_det.Size = new System.Drawing.Size(112, 23);
            this.rb_yolov5_det.TabIndex = 0;
            this.rb_yolov5_det.TabStop = true;
            this.rb_yolov5_det.Text = "YOLOv5Det";
            this.rb_yolov5_det.UseVisualStyleBackColor = true;
            // 
            // btn_class_select
            // 
            this.btn_class_select.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_class_select.Location = new System.Drawing.Point(448, 296);
            this.btn_class_select.Margin = new System.Windows.Forms.Padding(2);
            this.btn_class_select.Name = "btn_class_select";
            this.btn_class_select.Size = new System.Drawing.Size(75, 29);
            this.btn_class_select.TabIndex = 0;
            this.btn_class_select.Text = "Select";
            this.btn_class_select.UseVisualStyleBackColor = true;
            this.btn_class_select.Click += new System.EventHandler(this.btn_class_select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class Path:";
            // 
            // tb_class_path
            // 
            this.tb_class_path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_class_path.Location = new System.Drawing.Point(107, 297);
            this.tb_class_path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_class_path.Name = "tb_class_path";
            this.tb_class_path.Size = new System.Drawing.Size(330, 26);
            this.tb_class_path.TabIndex = 3;
            // 
            // btn_input_select
            // 
            this.btn_input_select.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_input_select.Location = new System.Drawing.Point(448, 340);
            this.btn_input_select.Margin = new System.Windows.Forms.Padding(2);
            this.btn_input_select.Name = "btn_input_select";
            this.btn_input_select.Size = new System.Drawing.Size(75, 29);
            this.btn_input_select.TabIndex = 0;
            this.btn_input_select.Text = "Select";
            this.btn_input_select.UseVisualStyleBackColor = true;
            this.btn_input_select.Click += new System.EventHandler(this.btn_input_select_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 344);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Input Path:";
            // 
            // tb_input_path
            // 
            this.tb_input_path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_input_path.Location = new System.Drawing.Point(107, 341);
            this.tb_input_path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_input_path.Name = "tb_input_path";
            this.tb_input_path.Size = new System.Drawing.Size(330, 26);
            this.tb_input_path.TabIndex = 3;
            // 
            // cb_device
            // 
            this.cb_device.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_device.FormattingEnabled = true;
            this.cb_device.Items.AddRange(new object[] {
            "CPU",
            "GPU"});
            this.cb_device.Location = new System.Drawing.Point(365, 515);
            this.cb_device.Margin = new System.Windows.Forms.Padding(2);
            this.cb_device.Name = "cb_device";
            this.cb_device.Size = new System.Drawing.Size(132, 27);
            this.cb_device.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(300, 520);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Device:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(574, 65);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(825, 520);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(574, 602);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(825, 520);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(554, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 1091);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Location = new System.Drawing.Point(554, 591);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 6);
            this.panel3.TabIndex = 6;
            // 
            // btn_model_select
            // 
            this.btn_model_select.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_model_select.Location = new System.Drawing.Point(448, 76);
            this.btn_model_select.Margin = new System.Windows.Forms.Padding(2);
            this.btn_model_select.Name = "btn_model_select";
            this.btn_model_select.Size = new System.Drawing.Size(75, 29);
            this.btn_model_select.TabIndex = 0;
            this.btn_model_select.Text = "Select";
            this.btn_model_select.UseVisualStyleBackColor = true;
            this.btn_model_select.Click += new System.EventHandler(this.btn_model_select_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model Path:";
            // 
            // tb_model_path
            // 
            this.tb_model_path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_model_path.Location = new System.Drawing.Point(107, 79);
            this.tb_model_path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_model_path.Name = "tb_model_path";
            this.tb_model_path.Size = new System.Drawing.Size(330, 26);
            this.tb_model_path.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Location = new System.Drawing.Point(-10, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1437, 6);
            this.panel2.TabIndex = 6;
            // 
            // tb_msg_image
            // 
            this.tb_msg_image.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_msg_image.Location = new System.Drawing.Point(23, 157);
            this.tb_msg_image.Margin = new System.Windows.Forms.Padding(2);
            this.tb_msg_image.Multiline = true;
            this.tb_msg_image.Name = "tb_msg_image";
            this.tb_msg_image.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_msg_image.Size = new System.Drawing.Size(513, 287);
            this.tb_msg_image.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Inference Information";
            // 
            // btn_load_model
            // 
            this.btn_load_model.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_model.Location = new System.Drawing.Point(374, 553);
            this.btn_load_model.Margin = new System.Windows.Forms.Padding(2);
            this.btn_load_model.Name = "btn_load_model";
            this.btn_load_model.Size = new System.Drawing.Size(114, 44);
            this.btn_load_model.TabIndex = 0;
            this.btn_load_model.Text = "Load Model";
            this.btn_load_model.UseVisualStyleBackColor = true;
            this.btn_load_model.Click += new System.EventHandler(this.btn_load_model_Click);
            // 
            // tc_operate
            // 
            this.tc_operate.Controls.Add(this.tabPage1);
            this.tc_operate.Controls.Add(this.tabPage2);
            this.tc_operate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_operate.Location = new System.Drawing.Point(3, 635);
            this.tc_operate.Name = "tc_operate";
            this.tc_operate.SelectedIndex = 0;
            this.tc_operate.Size = new System.Drawing.Size(546, 487);
            this.tc_operate.TabIndex = 8;
            this.tc_operate.SelectedIndexChanged += new System.EventHandler(this.tc_operate_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tb_msg_image);
            this.tabPage1.Controls.Add(this.btn_image_infer);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  Image  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_image_infer
            // 
            this.btn_image_infer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_image_infer.Location = new System.Drawing.Point(183, 33);
            this.btn_image_infer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_image_infer.Name = "btn_image_infer";
            this.btn_image_infer.Size = new System.Drawing.Size(114, 44);
            this.btn_image_infer.TabIndex = 0;
            this.btn_image_infer.Text = "Infer";
            this.btn_image_infer.UseVisualStyleBackColor = true;
            this.btn_image_infer.Click += new System.EventHandler(this.btn_image_infer_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pb_video);
            this.tabPage2.Controls.Add(this.btn_time);
            this.tabPage2.Controls.Add(this.btn_stop);
            this.tabPage2.Controls.Add(this.btn_start);
            this.tabPage2.Controls.Add(this.btn_video_infer);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tb_msg_video);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  Video  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pb_video
            // 
            this.pb_video.Location = new System.Drawing.Point(29, 423);
            this.pb_video.Name = "pb_video";
            this.pb_video.Size = new System.Drawing.Size(461, 23);
            this.pb_video.Step = 1;
            this.pb_video.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_video.TabIndex = 12;
            this.pb_video.Value = 1;
            // 
            // btn_time
            // 
            this.btn_time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_time.Location = new System.Drawing.Point(462, 23);
            this.btn_time.Margin = new System.Windows.Forms.Padding(2);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(64, 44);
            this.btn_time.TabIndex = 11;
            this.btn_time.Text = "Time";
            this.btn_time.UseVisualStyleBackColor = true;
            this.btn_time.Click += new System.EventHandler(this.btn_time_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(316, 23);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(114, 44);
            this.btn_stop.TabIndex = 11;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(164, 23);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(114, 44);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_video_infer
            // 
            this.btn_video_infer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_video_infer.Location = new System.Drawing.Point(24, 23);
            this.btn_video_infer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_video_infer.Name = "btn_video_infer";
            this.btn_video_infer.Size = new System.Drawing.Size(114, 44);
            this.btn_video_infer.TabIndex = 11;
            this.btn_video_infer.Text = "Infer";
            this.btn_video_infer.UseVisualStyleBackColor = true;
            this.btn_video_infer.Click += new System.EventHandler(this.btn_video_infer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Inference Information";
            // 
            // tb_msg_video
            // 
            this.tb_msg_video.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_msg_video.Location = new System.Drawing.Point(13, 111);
            this.tb_msg_video.Margin = new System.Windows.Forms.Padding(2);
            this.tb_msg_video.Multiline = true;
            this.tb_msg_video.Name = "tb_msg_video";
            this.tb_msg_video.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_msg_video.Size = new System.Drawing.Size(513, 307);
            this.tb_msg_video.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Location = new System.Drawing.Point(-1, 624);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 6);
            this.panel4.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Score Threshold:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "NMS Threshold:";
            // 
            // tb_score
            // 
            this.tb_score.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_score.Location = new System.Drawing.Point(117, 28);
            this.tb_score.Margin = new System.Windows.Forms.Padding(2);
            this.tb_score.Name = "tb_score";
            this.tb_score.Size = new System.Drawing.Size(72, 26);
            this.tb_score.TabIndex = 3;
            this.tb_score.Text = "0.6";
            this.tb_score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_nms
            // 
            this.tb_nms.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nms.Location = new System.Drawing.Point(117, 66);
            this.tb_nms.Margin = new System.Windows.Forms.Padding(2);
            this.tb_nms.Name = "tb_nms";
            this.tb_nms.Size = new System.Drawing.Size(72, 26);
            this.tb_nms.TabIndex = 3;
            this.tb_nms.Text = "0.5";
            this.tb_nms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tb_score);
            this.groupBox1.Controls.Add(this.tb_categ_num);
            this.groupBox1.Controls.Add(this.tb_nms);
            this.groupBox1.Controls.Add(this.tb_input_size);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 104);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inference Params";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(211, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 19);
            this.label11.TabIndex = 2;
            this.label11.Text = "Input Size:";
            // 
            // tb_categ_num
            // 
            this.tb_categ_num.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_categ_num.Location = new System.Drawing.Point(288, 28);
            this.tb_categ_num.Margin = new System.Windows.Forms.Padding(2);
            this.tb_categ_num.Name = "tb_categ_num";
            this.tb_categ_num.Size = new System.Drawing.Size(72, 26);
            this.tb_categ_num.TabIndex = 3;
            this.tb_categ_num.Text = "80";
            this.tb_categ_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_input_size
            // 
            this.tb_input_size.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_input_size.Location = new System.Drawing.Point(289, 62);
            this.tb_input_size.Margin = new System.Windows.Forms.Padding(2);
            this.tb_input_size.Name = "tb_input_size";
            this.tb_input_size.Size = new System.Drawing.Size(72, 26);
            this.tb_input_size.TabIndex = 3;
            this.tb_input_size.Text = "640";
            this.tb_input_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(202, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "Categ Num:";
            // 
            // chb_time
            // 
            this.chb_time.AutoSize = true;
            this.chb_time.Checked = true;
            this.chb_time.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_time.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chb_time.Location = new System.Drawing.Point(407, 414);
            this.chb_time.Name = "chb_time";
            this.chb_time.Size = new System.Drawing.Size(138, 20);
            this.chb_time.TabIndex = 10;
            this.chb_time.Text = "Time Detection";
            this.chb_time.UseVisualStyleBackColor = true;
            this.chb_time.CheckedChanged += new System.EventHandler(this.chb_time_CheckedChanged);
            // 
            // chb_fps
            // 
            this.chb_fps.AutoSize = true;
            this.chb_fps.Checked = true;
            this.chb_fps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_fps.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chb_fps.Location = new System.Drawing.Point(407, 452);
            this.chb_fps.Name = "chb_fps";
            this.chb_fps.Size = new System.Drawing.Size(90, 20);
            this.chb_fps.TabIndex = 10;
            this.chb_fps.Text = "FPS Draw";
            this.chb_fps.UseVisualStyleBackColor = true;
            this.chb_fps.CheckedChanged += new System.EventHandler(this.chb_fps_CheckedChanged);
            // 
            // rb_yolov10_det
            // 
            this.rb_yolov10_det.AutoSize = true;
            this.rb_yolov10_det.Location = new System.Drawing.Point(391, 61);
            this.rb_yolov10_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov10_det.Name = "rb_yolov10_det";
            this.rb_yolov10_det.Size = new System.Drawing.Size(120, 23);
            this.rb_yolov10_det.TabIndex = 3;
            this.rb_yolov10_det.Text = "YOLOv10Det";
            this.rb_yolov10_det.UseVisualStyleBackColor = true;
            // 
            // YoloDeployPlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 1132);
            this.Controls.Add(this.chb_fps);
            this.Controls.Add(this.chb_time);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tc_operate);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cb_device);
            this.Controls.Add(this.gb_model);
            this.Controls.Add(this.gb_engine);
            this.Controls.Add(this.tb_input_path);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_class_path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_model_path);
            this.Controls.Add(this.btn_load_model);
            this.Controls.Add(this.btn_input_select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_class_select);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_model_select);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "YoloDeployPlatform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YoloDeployPlatform";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_engine.ResumeLayout(false);
            this.gb_engine.PerformLayout();
            this.gb_model.ResumeLayout(false);
            this.gb_model.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tc_operate.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.RadioButton rb_yolov10_det;
    }
}

