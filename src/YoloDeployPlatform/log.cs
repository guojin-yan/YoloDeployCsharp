using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoloDeployPlatform
{
    public class Log
    {
        public bool flag_time {get;set;}
        public bool flag_fps { get; set; }

        public long infer_time { get; set; }
        private TextBox current_cb;

        private static readonly Log instance = new Log();
        private Log() { }

        public static Log Instance
        {
            get { return instance; }
        }

        
        public void set_current_cb(TextBox cb) 
        {
            current_cb = cb;
        }

        public void print(string msg) 
        {
            current_cb.AppendText(msg + "\r\n");
        }
    }
}
