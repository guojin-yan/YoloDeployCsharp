namespace YoloDeployPlatform
{
    partial class ONNXToEngine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_model_path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_model_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_msg_image = new System.Windows.Forms.TextBox();
            this.btn_conv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_model_path
            // 
            this.tb_model_path.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_model_path.Location = new System.Drawing.Point(154, 85);
            this.tb_model_path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_model_path.Name = "tb_model_path";
            this.tb_model_path.Size = new System.Drawing.Size(330, 26);
            this.tb_model_path.TabIndex = 6;
            this.tb_model_path.Text = "E:\\Model\\yolov8\\yolov5s.onnx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model Path:";
            // 
            // btn_model_select
            // 
            this.btn_model_select.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_model_select.Location = new System.Drawing.Point(495, 84);
            this.btn_model_select.Margin = new System.Windows.Forms.Padding(2);
            this.btn_model_select.Name = "btn_model_select";
            this.btn_model_select.Size = new System.Drawing.Size(75, 29);
            this.btn_model_select.TabIndex = 4;
            this.btn_model_select.Text = "Select";
            this.btn_model_select.UseVisualStyleBackColor = true;
            this.btn_model_select.Click += new System.EventHandler(this.btn_model_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "ONNX Model Conversion Engine Format";
            // 
            // tb_msg_image
            // 
            this.tb_msg_image.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_msg_image.Location = new System.Drawing.Point(26, 216);
            this.tb_msg_image.Margin = new System.Windows.Forms.Padding(2);
            this.tb_msg_image.Multiline = true;
            this.tb_msg_image.Name = "tb_msg_image";
            this.tb_msg_image.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_msg_image.Size = new System.Drawing.Size(544, 129);
            this.tb_msg_image.TabIndex = 8;
            // 
            // btn_conv
            // 
            this.btn_conv.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conv.Location = new System.Drawing.Point(201, 146);
            this.btn_conv.Margin = new System.Windows.Forms.Padding(2);
            this.btn_conv.Name = "btn_conv";
            this.btn_conv.Size = new System.Drawing.Size(146, 38);
            this.btn_conv.TabIndex = 4;
            this.btn_conv.Text = "Conversion";
            this.btn_conv.UseVisualStyleBackColor = true;
            this.btn_conv.Click += new System.EventHandler(this.btn_conv_Click);
            // 
            // ONNXToEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 356);
            this.Controls.Add(this.tb_msg_image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_model_path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_conv);
            this.Controls.Add(this.btn_model_select);
            this.Name = "ONNXToEngine";
            this.Text = "ONNXToEngine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_model_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_model_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_msg_image;
        private System.Windows.Forms.Button btn_conv;
    }
}