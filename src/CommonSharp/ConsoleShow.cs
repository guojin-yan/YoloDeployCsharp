using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonSharp
{
    public class ConsoleShow
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();//显示控制台
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole(); //释放控制台、关闭控制台
    }
}
