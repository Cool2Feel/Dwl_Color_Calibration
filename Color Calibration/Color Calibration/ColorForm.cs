using Color_Calibration.ComLib;
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
        private int Index;
        public ColorForm(int index)
        {
            Index = index;
            InitializeComponent();
            string ss = "当前的色温模式：";
            if(index == 0)
                label_mode.Text = ss + "Cool ";
            else if(index == 1)
                label_mode.Text = ss + "NORMAL";
            else if (index == 2)
                label_mode.Text = ss + "WARM ";
            else if (index == 3)
                label_mode.Text = ss + "CUSTOM";
            //Console.WriteLine("22222");
        }

        #region Get xy function
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
        #endregion
        #region Track Changed
        private void ucTrack_x_ValueChanged(object sender, EventArgs e)
        {
            label_x.Text = string.Format("{0:N3}", ucTrack_x.Value);
            //float x_v = ucTrack_x.Value;
            int x = Get_x(ucTrack_x.Value);
            int y = Get_y(ucTrack_y.Value);

            Draw_ColorPoint(x, y);
            //Console.WriteLine("len==" + (int)len);
        }

        private void ucTrack_y_ValueChanged(object sender, EventArgs e)
        {
            label_y.Text = string.Format("{0:N3}", ucTrack_y.Value);
            //float y_v = ucTrack_y.Value;
            int x = Get_x(ucTrack_x.Value);
            int y = Get_y(ucTrack_y.Value);

            Draw_ColorPoint(x, y);

        }
        private void ucTrack_lv_ValueChanged(object sender, EventArgs e)
        {
            label_lv.Text =ucTrack_lv.Value.ToString();
        }
        #endregion
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
            GlobalClass._t_ColorTempStd[Index, 0] = (int)(ucTrack_x.Value * 10000);
            GlobalClass._t_ColorTempStd[Index, 1] = (int)(ucTrack_y.Value * 10000);
            GlobalClass._t_ColorTempStd[Index, 2] = (int)(ucTrack_lv.Value);
            //GlobalClass._t_ColorTempStd[Index, 2] = (int)(ucTrack_lv.Value * 10000);
            GlobalClass._t_ColorEerorxy[Index] = (int)(float.Parse(ucTextBox_xy.InputText) * 10000);
            GlobalClass._t_ColorEerorlv[Index] = int.Parse(ucTextBox_lv.InputText);
            if (ucSwitch1.Checked)
                GlobalClass._t_ColorEeror[Index] = true;
            else
                GlobalClass._t_ColorEeror[Index] = false;
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
            //Console.WriteLine("11111");
            Draw_Pic();
            ucTrack_x.Value = (float)GlobalClass._t_ColorTempStd[Index, 0] / 10000;
            ucTrack_y.Value = (float)GlobalClass._t_ColorTempStd[Index, 1] / 10000;
            ucTrack_lv.Value = GlobalClass._t_ColorTempStd[Index, 2];

            string xy = string.Format("{0:N3}", (float)GlobalClass._t_ColorEerorxy[Index] / 10000);
            ucTextBox_xy.InputText = xy;
            ucTextBox_lv.InputText = GlobalClass._t_ColorEerorlv[Index].ToString();
            if (GlobalClass._t_ColorEeror[Index])
                ucSwitch1.Checked = true;
            //string lv = string.Format("{0:N3}", GlobalClass._t_ColorEerorlv[Index]);
            //Console.WriteLine("11111" + GlobalClass._t_ColorTempStd[Index, 0] + "," + GlobalClass._t_ColorTempStd[Index, 1]);
        }

        #region  Lable_Mouse function
        private void lbl_MouseDown(object sender)
        {
            Label LB = sender as Label;
            LB.Image = Color_Calibration.Properties.Resources.btn2_Dwn;
            LB.Location = new Point(LB.Location.X + 1, LB.Location.Y + 1);
        }

        private void lbl_MouseUp(object sender)
        {
            Label LB = sender as Label;
            LB.Location = new Point(LB.Location.X - 1, LB.Location.Y - 1);
        }
        private void lbl_MouseEnter(object sender)
        {
            Label LB = sender as Label;
            LB.Image = Color_Calibration.Properties.Resources.btn2_Ent;
        }
        private void lbl_MouseLeave(object sender)
        {
            Label LB = sender as Label;
            LB.Image = null;
        }
        #endregion
        #region Lable_Mouse opreate
        private void lbl_x_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_x.Value = Math.Min((float)(ucTrack_x.Value + 0.001), (float)0.7);
        }

        private void lbl_x_add_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(sender);
        }

        private void lbl_x_add_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(sender);
        }

        private void lbl_x_add_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_MouseUp(sender);
        }
        private void label_lv_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_lv.Value = Math.Min((int)(ucTrack_lv.Value + 1), 1000);
        }

        private void lbl_y_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_y.Value = Math.Min((float)(ucTrack_y.Value + 0.001), (float)0.7);
        }

        private void lbl_x_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_x.Value = Math.Max((float)(ucTrack_x.Value - 0.001), 0);
        }

        private void lbl_y_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_y.Value = Math.Max((float)(ucTrack_y.Value - 0.001), 0);
        }
        private void label_lv_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_lv.Value = Math.Max((int)(ucTrack_lv.Value - 1), 100);
        }
        #endregion

        private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(ucSwitch1.Checked == true)
            {
                label_eerxy.Visible = true;
                label_errlv.Visible = true;
                ucTextBox_xy.Visible = true;
                ucTextBox_lv.Visible = true;
            }
            else
            {
                label_eerxy.Visible = false;
                label_errlv.Visible = false;
                ucTextBox_xy.Visible = false;
                ucTextBox_lv.Visible = false;
            }
        }

    }
}
