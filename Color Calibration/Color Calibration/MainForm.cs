using Color_Calibration.ComLib;
using Color_Calibration.UnPages;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration
{
    public partial class MainForm : FrmBase
    {
        private UnMainLogo _logopage = new UnMainLogo();
        private UnSetForm _setpage = new UnSetForm();
        private UnColorForm _colorpage = new UnColorForm();
        private UnAdjustForm _adjustpage = new UnAdjustForm();
        public MainForm()
        {
            InitializeComponent();
            InitFormMove(Title_panel);
            Main_content.Controls.Add(_logopage);
            Main_content.Dock = DockStyle.Fill;
            _setpage.DataReceived += new ComEvent.DataReceivedHandler(Com_DataReceived);
            _colorpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            _adjustpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
        }
        /// <summary>
        /// 切换到Set Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_set_BtnClick(object sender, EventArgs e)
        {
            Btn_set.BackColor = Color.Purple;
            Btn_set.ForeColor = Color.White;
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.set;

            Btn_color.BackColor = Color.White;
            Btn_color.ForeColor = Color.Purple;
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;

            Btn_adjust.BackColor = Color.White;
            Btn_adjust.ForeColor = Color.Purple;
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_setpage);
            Main_content.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// 切换到 Calibration Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_color_BtnClick(object sender, EventArgs e)
        {
            Btn_set.BackColor = Color.White;
            Btn_set.ForeColor = Color.Purple;
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;

            Btn_color.BackColor = Color.Purple;
            Btn_color.ForeColor = Color.White;
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration_ex;

            Btn_adjust.BackColor = Color.White;
            Btn_adjust.ForeColor = Color.Purple;
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_colorpage);
            Main_content.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// 切换到Adjustment Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_adjust_BtnClick(object sender, EventArgs e)
        {
            Btn_set.BackColor = Color.White;
            Btn_set.ForeColor = Color.Purple;
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;

            Btn_color.BackColor = Color.White;
            Btn_color.ForeColor = Color.Purple;
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;

            Btn_adjust.BackColor = Color.Purple;
            Btn_adjust.ForeColor = Color.White;
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust_ex;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_adjustpage);
            Main_content.Dock = DockStyle.Fill;
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
        private void Title_panel_MouseDown(object sender, MouseEventArgs e)
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }
        /// <summary>
        /// 设置窗体居中显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Title_center_BtnClick(object sender, EventArgs e)
        {
            //this.StartPosition = FormStartPosition.CenterScreen;
            int w = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            int h = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.Location = new Point(w, h);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtnImg1_BtnClick(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// 串口数据返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, byte[] data)
        {
            if (data.Length > 1)
            {
                string ss = Encoding.Unicode.GetString(data);

                Console.WriteLine(ss);
            }

            //LogHelper.WriteLog("串口 DataReceived：" + Encoding.Default.GetString(ReDatas));
            //ExceptionLog.getLog().WriteLogFile(ReDatas, DateTime.Now.ToString("yyyyMMdd") + "log.txt");
        }
        /// <summary>
        /// 串口数据发送
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool DataSender_EventDataSend(byte[] data)
        {
            return _setpage.SendData(data);
        }

    }
}
