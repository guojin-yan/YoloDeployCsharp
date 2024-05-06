using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TensorRtSharp.Custom;

namespace YoloDeployPlatform
{
    public partial class ONNXToEngine : Form
    {
        public ONNXToEngine(string sorce_model_path)
        {
            InitializeComponent();
            tb_model_path.Text = sorce_model_path;
            CheckForIllegalCrossThreadCalls = false;
        }

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

        private void btn_conv_Click(object sender, EventArgs e)
        {
            tb_msg_image.Clear();
            tb_msg_image.AppendText("Attention:" + "\r\n");
            tb_msg_image.AppendText("    Model conversion takes some time, please be patient ! ! ! !" + "\r\n\r\n");
            tb_msg_image.AppendText("Converting, please wait ! ! . . ." + "\r\n\r\n");

            btn_conv.Enabled = false;
            Task task = new Task(() => {
                Nvinfer.OnnxToEngine(tb_model_path.Text, 50);
                string directory = Path.GetDirectoryName(tb_model_path.Text);
                string file = Path.GetFileNameWithoutExtension(tb_model_path.Text);
                tb_msg_image.AppendText("Conversion successful, model file saved to: " + Path.Combine(directory, file) + ".engine");
                btn_conv.Enabled = true;
            });
            task.Start();
        }
    }
}
