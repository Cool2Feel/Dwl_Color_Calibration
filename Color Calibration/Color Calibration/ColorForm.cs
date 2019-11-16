using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration
{
    public partial class ColorForm : Form
    {
        public ColorForm()
        {
            InitializeComponent();
        }


        private int Get_x(float x_v)
        {
            double len;
            if (x_v > 0.2)
            {
                len = ((x_v - 0.2) * 3) / 0.01;
                len = 121 + (int)len;
            }
            else
            {
                len = ((0.2 - x_v) * 3) / 0.01;
                len = 121 - len;
            }
            return (int)len;
        }
        private int Get_y(float y_v)
        {
            double len;
            if (y_v > 0.4)
            {
                len = ((y_v - 0.4) * 3) / 0.01;
                len = 222 - (int)len;
            }
            else
            {
                len = ((0.4 - y_v) * 3) / 0.01;
                len = 222 + (int)len;
            }
            return (int)len;
        }

        private void ucTrack_x_ValueChanged(object sender, EventArgs e)
        {
            label_x.Text = ucTrack_x.Value.ToString();
            //float x_v = ucTrack_x.Value;
            int x = Get_x(ucTrack_x.Value);
            int y = Get_y(ucTrack_y.Value);

            Draw_ColorPoint(x, y);
            //Console.WriteLine("len==" + (int)len);
        }

        private void ucTrack_y_ValueChanged(object sender, EventArgs e)
        {
            label_y.Text = ucTrack_y.Value.ToString();
            //float y_v = ucTrack_y.Value;
            int x = Get_x(ucTrack_x.Value);
            int y = Get_y(ucTrack_y.Value);

            Draw_ColorPoint(x, y);

        }
        
        private void Draw_ColorPoint(int x,int y)
        {
            pictureBox1.Image = global::Color_Calibration.Properties.Resources.color_cie;
            Bitmap bt = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bt);
            g.DrawLine(new Pen(Color.White, 3), new Point(148, 222), new Point(121, 294));
            g.DrawLine(new Pen(Color.White, 3), new Point(121, 294), new Point(166, 255));
            g.DrawLine(new Pen(Color.White, 3), new Point(166, 255), new Point(148, 222));
            //g.DrawLine(new Pen(Color.White, 4), new Point(0, bt.Height), new Point(bt.Width, 0));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x-3, y), new Point(x+3, y));
            g.DrawLine(new Pen(Color.Black, 2), new Point(x, y-3), new Point(x, y+3));
            pictureBox1.Image = bt;
        }

        #region 窗体移动
        //定义无边框窗体Form 
        [DllImport("user32.dll")]//*********************拖动无窗体的控件 
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;

        public const int SC_MOVE = 0xF010;

        public const int HTCAPTION = 0x0002;
        private void ColorForm_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(this);
        }
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
        #endregion
        private void ucBtn_set_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Draw_Pic()
        {
            Bitmap bt = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(bt);
            g.DrawLine(new Pen(Color.White, 3), new Point(148, 222), new Point(121, 294));
            g.DrawLine(new Pen(Color.White, 3), new Point(121, 294), new Point(166, 255));
            g.DrawLine(new Pen(Color.White, 3), new Point(166, 255), new Point(148, 222));
            //g.DrawLine(new Pen(Color.White, 4), new Point(0, bt.Height), new Point(bt.Width, 0));
            g.DrawLine(new Pen(Color.Black, 2), new Point(138, 251), new Point(144, 251));
            g.DrawLine(new Pen(Color.Black, 2), new Point(141, 248), new Point(141, 254));
            pictureBox1.Image = bt;
        }

        private void ColorForm_Load(object sender, EventArgs e)
        {
            Draw_Pic();
        }
    }
}
