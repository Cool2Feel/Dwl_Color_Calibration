using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration.ComLib
{
    public class FormMove
    {//定义无边框窗体Form 
        [DllImport("user32.dll")]//*********************拖动无窗体的控件 
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;

        public const int SC_MOVE = 0xF010;

        public const int HTCAPTION = 0x0002;
        ///<summary>
        ///拖动Panel 窗体移动
        ///</summary>
        ///<param name="form1">窗口实例</param>
        ///<param name="panel1">要拖动的Panel</param>
        public static void MoveForm(Form form1)
        {
            ReleaseCapture();
            SendMessage(form1.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);//*********************调用移动无窗体控件函数 
        }
    }
}
