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

        public List<long> sum_time { get; set; } = new List<long>();

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

        public void print() 
        {
            long sum = 0;
            foreach (var item in sum_time) 
            {
                sum+= item;
            }
            sum = sum - sum_time[0];
            current_cb.AppendText("The average time: " + ((float)sum/(float)(sum_time.Count-1)).ToString("0.00") + "\r\n");
        }
    }
}
