namespace YoloDeployPlatform
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_opencv = new System.Windows.Forms.RadioButton();
            this.rb_onnx = new System.Windows.Forms.RadioButton();
            this.rb_tensorrt = new System.Windows.Forms.RadioButton();
            this.rb_openvino = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_yolov8_obb = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_pose = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_seg = new System.Windows.Forms.RadioButton();
            this.rb_yolov_seg = new System.Windows.Forms.RadioButton();
            this.rb_yolov9_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov8_det = new System.Windows.Forms.RadioButton();
            this.rb_yolov7_det = new System.Windows.Forms.RadioButton();
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
            this.rb_yolo_world = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tb_msg_video = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_opencv);
            this.groupBox1.Controls.Add(this.rb_onnx);
            this.groupBox1.Controls.Add(this.rb_tensorrt);
            this.groupBox1.Controls.Add(this.rb_openvino);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 388);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(258, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inference Engine";
            // 
            // rb_opencv
            // 
            this.rb_opencv.AutoSize = true;
            this.rb_opencv.Location = new System.Drawing.Point(148, 70);
            this.rb_opencv.Margin = new System.Windows.Forms.Padding(2);
            this.rb_opencv.Name = "rb_opencv";
            this.rb_opencv.Size = new System.Drawing.Size(85, 23);
            this.rb_opencv.TabIndex = 3;
            this.rb_opencv.TabStop = true;
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
            this.rb_onnx.Size = new System.Drawing.Size(129, 23);
            this.rb_onnx.TabIndex = 2;
            this.rb_onnx.TabStop = true;
            this.rb_onnx.Text = "ONNX runtime";
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
            this.rb_tensorrt.TabStop = true;
            this.rb_tensorrt.Text = "TensorRT";
            this.rb_tensorrt.UseVisualStyleBackColor = true;
            this.rb_tensorrt.CheckedChanged += new System.EventHandler(this.rb_tensorrt_CheckedChanged);
            // 
            // rb_openvino
            // 
            this.rb_openvino.AutoSize = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_yolov8_obb);
            this.groupBox2.Controls.Add(this.radioButton12);
            this.groupBox2.Controls.Add(this.rb_yolov8_pose);
            this.groupBox2.Controls.Add(this.rb_yolov8_seg);
            this.groupBox2.Controls.Add(this.rb_yolo_world);
            this.groupBox2.Controls.Add(this.rb_yolov_seg);
            this.groupBox2.Controls.Add(this.rb_yolov9_det);
            this.groupBox2.Controls.Add(this.rb_yolov8_det);
            this.groupBox2.Controls.Add(this.rb_yolov7_det);
            this.groupBox2.Controls.Add(this.rb_yolov6_det);
            this.groupBox2.Controls.Add(this.rb_yolov5_seg);
            this.groupBox2.Controls.Add(this.rb_yolov5_det);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 115);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(503, 161);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model";
            // 
            // rb_yolov8_obb
            // 
            this.rb_yolov8_obb.AutoSize = true;
            this.rb_yolov8_obb.Location = new System.Drawing.Point(141, 128);
            this.rb_yolov8_obb.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_obb.Name = "rb_yolov8_obb";
            this.rb_yolov8_obb.Size = new System.Drawing.Size(120, 23);
            this.rb_yolov8_obb.TabIndex = 3;
            this.rb_yolov8_obb.TabStop = true;
            this.rb_yolov8_obb.Text = "YOLOv8-Obb";
            this.rb_yolov8_obb.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(271, 30);
            this.radioButton12.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(114, 23);
            this.radioButton12.TabIndex = 3;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "YOLOv8-Cls";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_pose
            // 
            this.rb_yolov8_pose.AutoSize = true;
            this.rb_yolov8_pose.Location = new System.Drawing.Point(141, 94);
            this.rb_yolov8_pose.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_pose.Name = "rb_yolov8_pose";
            this.rb_yolov8_pose.Size = new System.Drawing.Size(124, 23);
            this.rb_yolov8_pose.TabIndex = 3;
            this.rb_yolov8_pose.TabStop = true;
            this.rb_yolov8_pose.Text = "YOLOv8-Pose";
            this.rb_yolov8_pose.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_seg
            // 
            this.rb_yolov8_seg.AutoSize = true;
            this.rb_yolov8_seg.Location = new System.Drawing.Point(141, 61);
            this.rb_yolov8_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_seg.Name = "rb_yolov8_seg";
            this.rb_yolov8_seg.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov8_seg.TabIndex = 3;
            this.rb_yolov8_seg.TabStop = true;
            this.rb_yolov8_seg.Text = "YOLOv8-Seg";
            this.rb_yolov8_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov_seg
            // 
            this.rb_yolov_seg.AutoSize = true;
            this.rb_yolov_seg.Location = new System.Drawing.Point(271, 94);
            this.rb_yolov_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov_seg.Name = "rb_yolov_seg";
            this.rb_yolov_seg.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov_seg.TabIndex = 3;
            this.rb_yolov_seg.TabStop = true;
            this.rb_yolov_seg.Text = "YOLOv9-Seg";
            this.rb_yolov_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov9_det
            // 
            this.rb_yolov9_det.AutoSize = true;
            this.rb_yolov9_det.Location = new System.Drawing.Point(271, 61);
            this.rb_yolov9_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov9_det.Name = "rb_yolov9_det";
            this.rb_yolov9_det.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov9_det.TabIndex = 3;
            this.rb_yolov9_det.TabStop = true;
            this.rb_yolov9_det.Text = "YOLOv9-Det";
            this.rb_yolov9_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov8_det
            // 
            this.rb_yolov8_det.AutoSize = true;
            this.rb_yolov8_det.Location = new System.Drawing.Point(141, 30);
            this.rb_yolov8_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov8_det.Name = "rb_yolov8_det";
            this.rb_yolov8_det.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov8_det.TabIndex = 3;
            this.rb_yolov8_det.TabStop = true;
            this.rb_yolov8_det.Text = "YOLOv8-Det";
            this.rb_yolov8_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov7_det
            // 
            this.rb_yolov7_det.AutoSize = true;
            this.rb_yolov7_det.Location = new System.Drawing.Point(13, 128);
            this.rb_yolov7_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov7_det.Name = "rb_yolov7_det";
            this.rb_yolov7_det.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov7_det.TabIndex = 3;
            this.rb_yolov7_det.TabStop = true;
            this.rb_yolov7_det.Text = "YOLOv7-Det";
            this.rb_yolov7_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov6_det
            // 
            this.rb_yolov6_det.AutoSize = true;
            this.rb_yolov6_det.Location = new System.Drawing.Point(13, 94);
            this.rb_yolov6_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov6_det.Name = "rb_yolov6_det";
            this.rb_yolov6_det.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov6_det.TabIndex = 2;
            this.rb_yolov6_det.TabStop = true;
            this.rb_yolov6_det.Text = "YOLOv6-Det";
            this.rb_yolov6_det.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_seg
            // 
            this.rb_yolov5_seg.AutoSize = true;
            this.rb_yolov5_seg.Location = new System.Drawing.Point(13, 61);
            this.rb_yolov5_seg.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov5_seg.Name = "rb_yolov5_seg";
            this.rb_yolov5_seg.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov5_seg.TabIndex = 1;
            this.rb_yolov5_seg.TabStop = true;
            this.rb_yolov5_seg.Text = "YOLOv5-Seg";
            this.rb_yolov5_seg.UseVisualStyleBackColor = true;
            // 
            // rb_yolov5_det
            // 
            this.rb_yolov5_det.AutoSize = true;
            this.rb_yolov5_det.Location = new System.Drawing.Point(13, 30);
            this.rb_yolov5_det.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolov5_det.Name = "rb_yolov5_det";
            this.rb_yolov5_det.Size = new System.Drawing.Size(117, 23);
            this.rb_yolov5_det.TabIndex = 0;
            this.rb_yolov5_det.TabStop = true;
            this.rb_yolov5_det.Text = "YOLOv5-Det";
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
            this.cb_device.Location = new System.Drawing.Point(362, 399);
            this.cb_device.Margin = new System.Windows.Forms.Padding(2);
            this.cb_device.Name = "cb_device";
            this.cb_device.Size = new System.Drawing.Size(132, 27);
            this.cb_device.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 404);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Device:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
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
            this.tb_msg_image.Location = new System.Drawing.Point(13, 205);
            this.tb_msg_image.Margin = new System.Windows.Forms.Padding(2);
            this.tb_msg_image.Multiline = true;
            this.tb_msg_image.Name = "tb_msg_image";
            this.tb_msg_image.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_msg_image.Size = new System.Drawing.Size(513, 363);
            this.tb_msg_image.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(146, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Inference Information";
            // 
            // btn_load_model
            // 
            this.btn_load_model.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_model.Location = new System.Drawing.Point(362, 447);
            this.btn_load_model.Margin = new System.Windows.Forms.Padding(2);
            this.btn_load_model.Name = "btn_load_model";
            this.btn_load_model.Size = new System.Drawing.Size(114, 44);
            this.btn_load_model.TabIndex = 0;
            this.btn_load_model.Text = "Load Model";
            this.btn_load_model.UseVisualStyleBackColor = true;
            this.btn_load_model.Click += new System.EventHandler(this.btn_load_model_Click);
            // 
            // rb_yolo_world
            // 
            this.rb_yolo_world.AutoSize = true;
            this.rb_yolo_world.Location = new System.Drawing.Point(271, 128);
            this.rb_yolo_world.Margin = new System.Windows.Forms.Padding(2);
            this.rb_yolo_world.Name = "rb_yolo_world";
            this.rb_yolo_world.Size = new System.Drawing.Size(116, 23);
            this.rb_yolo_world.TabIndex = 3;
            this.rb_yolo_world.TabStop = true;
            this.rb_yolo_world.Text = "YOLO-World";
            this.rb_yolo_world.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 523);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 612);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tb_msg_image);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  Image  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tb_msg_video);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  Video  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Location = new System.Drawing.Point(0, 512);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 6);
            this.panel4.TabIndex = 6;
            // 
            // tb_msg_video
            // 
            this.tb_msg_video.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_msg_video.Location = new System.Drawing.Point(13, 204);
            this.tb_msg_video.Margin = new System.Windows.Forms.Padding(2);
            this.tb_msg_video.Multiline = true;
            this.tb_msg_video.Name = "tb_msg_video";
            this.tb_msg_video.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_msg_video.Size = new System.Drawing.Size(513, 363);
            this.tb_msg_video.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 167);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Inference Information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 1132);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cb_device);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YoloDeployPlatform";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_opencv;
        private System.Windows.Forms.RadioButton rb_onnx;
        private System.Windows.Forms.RadioButton rb_tensorrt;
        private System.Windows.Forms.RadioButton rb_openvino;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_yolov7_det;
        private System.Windows.Forms.RadioButton rb_yolov6_det;
        private System.Windows.Forms.RadioButton rb_yolov5_seg;
        private System.Windows.Forms.RadioButton rb_yolov5_det;
        private System.Windows.Forms.RadioButton radioButton12;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_msg_video;
    }
}

