using Color_Calibration.ComLib;
using Color_Calibration.UnPages;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        private string _path = Application.StartupPath + "\\Model";
        //private MainColorModel _colorModel = new MainColorModel();
        public MainForm()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            InitFormMove(Title_panel);
            Main_content.Controls.Add(_logopage);
            //Main_content.Dock = DockStyle.Fill;
            _setpage.DataReceived += new ComEvent.DataReceivedHandler(Com_DataReceived);
            _colorpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            _adjustpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);

            if (!Directory.Exists(_path + "\\"))
            {
                Directory.CreateDirectory(_path + "\\");
                Console.WriteLine("create");
            }
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
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
            MainColorModel.M_PageIndex = 1;
            //Main_content.Dock = DockStyle.Fill;
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
            //Main_content.Dock = DockStyle.Fill;
            MainColorModel.M_PageIndex = 2;
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
            //Main_content.Dock = DockStyle.Fill;
            MainColorModel.M_PageIndex = 3;
            _adjustpage.Data_Update();
        }
        
        /// <summary>
        /// 将对象保存到指定路径中,
        /// </summary>
        /// <param name="path">要保存的路径</param>
        /// <param name="obj">要保存的对象</param>
        public void SaveObject()
        {
            try
            {

                SerializeModel.PathFile = _path + "\\main_set.xml";
                MainSetModel setModel = new MainSetModel();
                setModel.H_Row = MainColorModel.H_Row;
                setModel.V_Colu = MainColorModel.V_Colu;
                setModel.M_MeterType = MainColorModel.M_MeterType;
                setModel.M_ModelType = MainColorModel.M_ModelType;
                setModel.M_PageIndex = MainColorModel.M_PageIndex;
                setModel.M_ComIndex = MainColorModel.M_ComIndex;
                setModel.T_Gamma = MainColorModel.T_Gamma;
                setModel.T_Temp = MainColorModel.T_Temp;
                setModel.T_Lum = MainColorModel.T_Lum;
                setModel.T_Custom = MainColorModel.T_Custom;
                setModel.T_ID = MainColorModel.T_ID;

                string ok = SerializeModel.XMLSerialize<MainSetModel>(setModel);
                //Console.WriteLine("[" + ok + "]文件保存成功...");
                //将对象写入到本地
            }
            catch (Exception)
            {
                Console.WriteLine("[" + "]文件保存失败...");
            }

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
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Initialize();
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Destroy(); ;
                Console.WriteLine("i1d3Destroy OK =  " + tt.ToString());
            }
            catch
            {
                Console.WriteLine("i1d3Destroy err.");
            }
            
            SaveObject();
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

            //Console.WriteLine("Debug:= " + MainColorModel.M_PageIndex);
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
                string ss = Encoding.Default.GetString(data);

                //Console.WriteLine(ss);
                if (MainColorModel.M_PageIndex == 2)
                    _colorpage.DataReceived(data);
                else if(MainColorModel.M_PageIndex == 3)
                    _adjustpage.DataReceived(data);
                else
                {
                    Console.WriteLine("this page:" + ss);
                }
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
