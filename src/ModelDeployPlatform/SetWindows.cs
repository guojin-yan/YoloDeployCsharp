using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 设置窗口类
/// 包含对窗口设置的相关操作
/// </summary>
public class SetWindows
{
    #region 引入Embeded Window 的 dll
    //FindWindow用来查找窗体。
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string strclassName, string strWindowText);

    //SetParent用来设置窗体的父窗体。
    [DllImport("user32.dll")]
    public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    //MoveWindow用来改变窗体大小。
    [DllImport("user32.dll")]
    public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

    //DestroyWindow用来关闭并窗体。
    [DllImport("user32.dll")]
    public static extern bool DestroyWindow(IntPtr hWnd);

    private const int GWL_STYLE = (-16);
    public const int WS_CAPTION = 0xC00000;

    //GetWindowLong 获取index
    [System.Runtime.InteropServices.DllImport("USER32.DLL")]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    //SetWindowLong 隐藏标题栏
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    #endregion 引入dll

    /// <summary>
    /// 查找弹出的图形窗口，并嵌入指定的 Control 中
    /// </summary>
    /// <param name="windowName">窗口名字符串</param>
    /// <param name="control">容器名</param>
    public static void EmbededFigureWindow(string windowName, Control control)
    {
        control.Controls.Clear(); // 清空Control中的控件 
                                  // 窗体嵌入
        IntPtr hWnd = new IntPtr(0);
        hWnd = IntPtr.Zero;
        hWnd = FindWindow(null, windowName);

        // 判断这个窗体是否有效 
        if (hWnd != IntPtr.Zero)
        {

            // 窗口存在且找到
            SetParent(hWnd, control.Handle); // 设置窗口的父窗体
            control.Tag = hWnd;
            // 隐藏窗体的标题栏
            SetWindowLong(hWnd, GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) & ~WS_CAPTION);
            // 设置窗体大小
            MoveWindow(hWnd, 0, 0, control.ClientSize.Width, control.ClientSize.Height, true);
            Thread.Sleep(100); // 线程休眠，防止卡死
            MoveWindow(hWnd, 0, 0, control.ClientSize.Width, control.ClientSize.Height, true);
        }
    }




    /// <summary>
    /// 将 Form 窗体嵌入到 Control 容器中
    /// </summary>
    /// <param name="form">窗体句柄</param>
    /// <param name="control">容器句柄</param>
    public static void EmbededFormWindow(Form form, Control control)
    {
        // 判断窗体是否存在
        if (form != null)
        {
            // 窗体有效，设置窗体
            control.Controls.Clear(); // 清空Control中的控件           
            form.TopLevel = false; // 设置子窗口不显示为顶级窗口            
            form.FormBorderStyle = FormBorderStyle.None; // 设置子窗口的样式，没有上面的标题栏         
            form.Dock = DockStyle.Fill;  // 设置填充样式           
            control.Controls.Add(form); // 加入控件           
            form.Show();  // 让窗体显示
        }
    }
}