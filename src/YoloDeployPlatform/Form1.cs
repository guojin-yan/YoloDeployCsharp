using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoloDeployPlatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region File_Select
        private void btn_model_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
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
            dlg.Title = "Select the test input file.";
            dlg.Filter = "Class file(*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_class_path.Text = dlg.FileName;
            }
        }

        private void btn_input_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select the test input file.";
            dlg.Filter = "Input file(*.png,*.jpg,*.jepg,*.mp4)|*.png;*.jpg;*.jepg;*.mp4";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_input_path.Text = dlg.FileName;
            }
        }
        #endregion
        private void btn_load_model_Click(object sender, EventArgs e)
        {

        }

        #region RadioButton_CheckedChanged
        private void rb_openvino_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_openvino.Checked) 
            {
                cb_device.SelectedIndex = 0;
            }
        }

        private void rb_tensorrt_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tensorrt.Checked)
            {
                cb_device.SelectedIndex = 1;
            }
        }

        private void rb_onnx_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_onnx.Checked)
            {
                cb_device.SelectedIndex = 0;
            }
        }

        private void rb_opencv_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_opencv.Checked)
            {
                cb_device.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
