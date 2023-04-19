using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonSharp;
using TensorRTSharp;


namespace ModelDeployPlatform
{
    public partial class FormEngineConvert : Form
    {
        public FormEngineConvert()
        {
            InitializeComponent();
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
            dlg.Filter = "模型文件(*.pt,*.onnx)|*.pt;*.onnx";
            //判断文件对话框是否打开
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb_model_path.Text = dlg.FileName;
            }

        }

        private void btn_choose_output_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                if (tb_model_path.Text == "")
                {
                    tb_output_path.Text = fbd.SelectedPath + "\\model.engine";
                }
                else 
                {
                    tb_output_path.Text = fbd.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(tb_model_path.Text) + ".engine";
                }
               
            }

        }

        private void btn_model_convert_Click(object sender, EventArgs e)
        {
            if (tb_model_path.Text == "") 
            {
                MessageBox.Show("请选择模型文件", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tb_output_path.Text == "") 
            {
                tb_output_path.Text = Path.GetDirectoryName(tb_model_path.Text) + "\\" + Path.GetFileNameWithoutExtension(tb_model_path.Text) + ".engine";
            }
            ConsoleShow.AllocConsole();
            Thread model_conv = new Thread(() => {
                Console.WriteLine("原始模型路径：" + tb_model_path.Text);
                Console.WriteLine("输出模型路径：" + tb_output_path.Text);
                Console.WriteLine("正在转换中·····" );
                Nvinfer.onnx_to_engine(tb_model_path.Text, tb_output_path.Text, AccuracyFlag.kFP16);
                Console.WriteLine("模型转换成功！！！");
            }
           );

            model_conv.Start();

        }

        private void FormEngineConvert_Load(object sender, EventArgs e)
        {
        
        }
    }
}
