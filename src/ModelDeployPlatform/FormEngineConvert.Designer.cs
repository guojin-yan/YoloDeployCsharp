namespace ModelDeployPlatform
{
    partial class FormEngineConvert
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
            this.btn_model_convert = new System.Windows.Forms.Button();
            this.tb_model_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_choose_model_path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_output_path = new System.Windows.Forms.TextBox();
            this.btn_choose_output_path = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_model_convert
            // 
            this.btn_model_convert.Location = new System.Drawing.Point(296, 223);
            this.btn_model_convert.Name = "btn_model_convert";
            this.btn_model_convert.Size = new System.Drawing.Size(92, 38);
            this.btn_model_convert.TabIndex = 0;
            this.btn_model_convert.Text = "模型转换";
            this.btn_model_convert.UseVisualStyleBackColor = true;
            this.btn_model_convert.Click += new System.EventHandler(this.btn_model_convert_Click);
            // 
            // tb_model_path
            // 
            this.tb_model_path.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_model_path.Location = new System.Drawing.Point(160, 112);
            this.tb_model_path.Name = "tb_model_path";
            this.tb_model_path.Size = new System.Drawing.Size(520, 26);
            this.tb_model_path.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("思源黑体 CN", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "原始模型地址:";
            // 
            // btn_choose_model_path
            // 
            this.btn_choose_model_path.Location = new System.Drawing.Point(697, 114);
            this.btn_choose_model_path.Name = "btn_choose_model_path";
            this.btn_choose_model_path.Size = new System.Drawing.Size(57, 26);
            this.btn_choose_model_path.TabIndex = 0;
            this.btn_choose_model_path.Text = "选 择";
            this.btn_choose_model_path.UseVisualStyleBackColor = true;
            this.btn_choose_model_path.Click += new System.EventHandler(this.btn_choose_model_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("思源宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(202, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "TensorRT engine 模型转换";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("思源黑体 CN", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(43, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "转换模型地址:";
            // 
            // tb_output_path
            // 
            this.tb_output_path.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_output_path.Location = new System.Drawing.Point(160, 156);
            this.tb_output_path.Name = "tb_output_path";
            this.tb_output_path.Size = new System.Drawing.Size(520, 26);
            this.tb_output_path.TabIndex = 1;
            // 
            // btn_choose_output_path
            // 
            this.btn_choose_output_path.Location = new System.Drawing.Point(697, 156);
            this.btn_choose_output_path.Name = "btn_choose_output_path";
            this.btn_choose_output_path.Size = new System.Drawing.Size(57, 26);
            this.btn_choose_output_path.TabIndex = 0;
            this.btn_choose_output_path.Text = "选 择";
            this.btn_choose_output_path.UseVisualStyleBackColor = true;
            this.btn_choose_output_path.Click += new System.EventHandler(this.btn_choose_output_path_Click);
            // 
            // FormEngineConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 283);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_output_path);
            this.Controls.Add(this.tb_model_path);
            this.Controls.Add(this.btn_choose_output_path);
            this.Controls.Add(this.btn_choose_model_path);
            this.Controls.Add(this.btn_model_convert);
            this.Name = "FormEngineConvert";
            this.Text = "FormEngineConvert";
            this.Load += new System.EventHandler(this.FormEngineConvert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_model_convert;
        private TextBox tb_model_path;
        private Label label1;
        private Button btn_choose_model_path;
        private Label label2;
        private Label label3;
        private TextBox tb_output_path;
        private Button btn_choose_output_path;
    }
}