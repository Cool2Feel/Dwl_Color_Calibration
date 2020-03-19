using Color_Calibration.ComLib;
using Color_Calibration.Control;
using Color_Calibration.NetCommand.IOCPClinet;
using Color_Calibration.UnPages;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Color_Calibration
{
    /// <summary>
    /// Main Pages
    /// </summary>
    public partial class MainForm : FrmBase
    {
        #region Main PageObject
        private UnMainLogo _logopage = new UnMainLogo();
        private UnSetForm _setpage = new UnSetForm();
        private UnColorForm _colorpage = new UnColorForm();
        private UnAdjustForm _adjustpage = new UnAdjustForm();
        private UnControlForm _controlpage = new UnControlForm();
        private string _path = Application.StartupPath + "\\ColorData";
        public C_DebugPage _debug = new C_DebugPage();
        //private MainColorModel _colorModel = new MainColorModel();
        #endregion
        public MainForm()
        {
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            InitFormMove(Title_panel);
            Main_content.Controls.Add(_logopage);
            //Main_content.Dock = DockStyle.Fill;
            _setpage.DataReceived += new ComEvent.DataReceivedHandler(Com_DataReceived);
            _setpage.LanConnectReceived += new LANNetEvent.TCPConnectdHandler(LAN_ConnectReceived);
            _colorpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            _adjustpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            _controlpage.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            _debug = new C_DebugPage();
            _debug.DataSend += new ComEvent.DataSendHandler(DataSender_EventDataSend);
            if (!Directory.Exists(_path + "\\"))
            {
                Directory.CreateDirectory(_path + "\\");
                Console.WriteLine("create");
            }
            //GlobalClass.m_cIsRunning = false;
            CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Initialize();
            //this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            
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

        #region 切换页面UI
        /// <summary>
        /// 切换到Set Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_set_BtnClick(object sender, EventArgs e)
        {
            if (MainColorModel.M_PageIndex == 1)
                return;
            if (GlobalClass.m_cIsRunning)
            {
                FrmTips.ShowTipsInfo(this, "Performing color calibration adjustment...");
                return;
            }
            Btn_set.BackColor = Color.FromArgb(164,38,143);
            Btn_set.ForeColor = Color.White;
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.set;

            Btn_color.BackColor = Color.White;
            Btn_color.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;

            Btn_adjust.BackColor = Color.White;
            Btn_adjust.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;

            Btn_control.BackColor = Color.White;
            Btn_control.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_control.BtnImage = global::Color_Calibration.Properties.Resources.controlList;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_setpage);
            //_setpage.DataReceived += new ComEvent.DataReceivedHandler(Com_DataReceived);
            MainColorModel.M_PageIndex = 1;
            _setpage.InitUmainForm(this);
            //Main_content.Dock = DockStyle.Fill;
        }
        /// <summary>
        /// 切换到 Calibration Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_color_BtnClick(object sender, EventArgs e)
        {
            if (MainColorModel.M_PageIndex == 2)
                return;
            if (GlobalClass.m_cIsRunning)
            {
                return;
            }
            Btn_set.BackColor = Color.White;
            Btn_set.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;

            Btn_color.BackColor = Color.FromArgb(164, 38, 143);
            Btn_color.ForeColor = Color.White;
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration_ex;

            Btn_adjust.BackColor = Color.White;
            Btn_adjust.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;

            Btn_control.BackColor = Color.White;
            Btn_control.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_control.BtnImage = global::Color_Calibration.Properties.Resources.controlList;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_colorpage);
            //Main_content.Dock = DockStyle.Fill;
            MainColorModel.M_PageIndex = 2;
            _setpage.InitUmainForm(this);
        }
        /// <summary>
        /// 切换到Adjustment Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_adjust_BtnClick(object sender, EventArgs e)
        {
            if (MainColorModel.M_PageIndex == 3)
                return;
            if (GlobalClass.m_cIsRunning)
            {
                FrmTips.ShowTipsInfo(this, "Performing color calibration adjustment...");
                return;
            }
            Btn_set.BackColor = Color.White;
            Btn_set.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;

            Btn_color.BackColor = Color.White;
            Btn_color.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;

            Btn_adjust.BackColor = Color.FromArgb(164, 38, 143);
            Btn_adjust.ForeColor = Color.White;
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust_ex;

            Btn_control.BackColor = Color.White;
            Btn_control.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_control.BtnImage = global::Color_Calibration.Properties.Resources.controlList;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_adjustpage);
            //Main_content.Dock = DockStyle.Fill;
            MainColorModel.M_PageIndex = 3;
            _adjustpage.Data_Update();
        }
        private void Btn_control_BtnClick(object sender, EventArgs e)
        {
            if (MainColorModel.M_PageIndex == 4)
                return;
            if (GlobalClass.m_cIsRunning)
            {
                FrmTips.ShowTipsInfo(this, "Performing color calibration adjustment...");
                return;
            }
            Btn_set.BackColor = Color.White;
            Btn_set.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;

            Btn_color.BackColor = Color.White;
            Btn_color.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;

            Btn_adjust.BackColor = Color.White;
            Btn_adjust.ForeColor = Color.FromArgb(164, 38, 143);
            Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;

            Btn_control.BackColor = Color.FromArgb(164, 38, 143);
            Btn_control.ForeColor = Color.White;
            Btn_control.BtnImage = global::Color_Calibration.Properties.Resources.controlList_ex;

            Main_content.Controls.Clear();
            Main_content.Controls.Add(_controlpage);
            //Main_content.Dock = DockStyle.Fill;
            MainColorModel.M_PageIndex = 4;
            _controlpage.Data_Update();
        }

        public void UpdateUIStatus()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                int i = MainColorModel.T_Temp;
                string x = string.Format("{0:N3}", (float)GlobalClass._t_ColorTempStd[i, 0] / 10000);
                string y = string.Format("{0:N3}", (float)GlobalClass._t_ColorTempStd[i, 1] / 10000);
                string lv = GlobalClass._t_ColorTempStd[i, 2].ToString();
                color_temp.Text = "Target 『  Lv : " + lv + "  x ：" + x + "  y : " + y + " 』";
            }));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            UpdateUIStatus();
        }
        #endregion

        #region Save DataObjest
        /// <summary>
        /// 将对象保存到指定路径中,
        /// </summary>
        /// <param name="path">要保存的路径</param>
        /// <param name="obj">要保存的对象</param>
        private void SaveObject()
        {
            try
            {
                SerializeModel.PathFile = Application.StartupPath + "\\ColorData\\main_set.xml";
                MainSetModel setModel = new MainSetModel();
                setModel.H_Row = MainColorModel.H_Row;
                setModel.V_Colu = MainColorModel.V_Colu;
                setModel.M_MeterType = MainColorModel.M_MeterType;
                setModel.M_ModelType = MainColorModel.M_ModelType;
                setModel.M_PageIndex = MainColorModel.M_PageIndex;
                setModel.M_ComIndex = MainColorModel.M_ComIndex;
                setModel.M_LanIndex = MainColorModel.M_LanIndex;
                setModel.T_Gamma = MainColorModel.T_Gamma;
                setModel.T_Temp = MainColorModel.T_Temp;
                setModel.T_Lum = MainColorModel.T_Lum;
                setModel.T_Custom = MainColorModel.T_Custom;
                setModel.T_ID = MainColorModel.T_ID;
                setModel.T_ComLan = MainColorModel.T_ComLan;
                //setModel.T_ColorTempStd = MainColorModel.T_ColorTemp;

                string ok = SerializeModel.XMLSerialize<MainSetModel>(setModel);
                //Console.WriteLine("[" + ok + "]文件保存成功...");
                //将对象写入到本地
            }
            catch (Exception)
            {
                Console.WriteLine("[" + "]文件保存失败...");
            }

        }

        private void InitSaveForm()
        {
            _setpage.SavePage();
            MainColorModel.M_PageIndex = 0;
        }
        private void SaveColorTemp()
        {
            try
            {
                string path = Application.StartupPath + "\\ColorData\\colortemp.xml";
                SerializeModel.PathFile = path;

                List<ColorTempModel> ListData = new List<ColorTempModel>();

                for (int i = 0; i < 4; i++)
                {
                    ColorTempModel ct = new ColorTempModel();
                    ct.ID = i;
                    ct.C_ColorTemp_x = GlobalClass._t_ColorTempStd[i, 0];
                    ct.C_ColorTemp_y = GlobalClass._t_ColorTempStd[i, 1];
                    ct.C_ColorTemp_lv = GlobalClass._t_ColorTempStd[i, 2];
                    ct.C_ColorEeror_xy = GlobalClass._t_ColorEerorxy[i].ToString();
                    ct.C_ColorEeror_lv = GlobalClass._t_ColorEerorlv[i].ToString();
                    ct.C_ColorEeror = GlobalClass._t_ColorEeror[i];
                    ListData.Add(ct);
                    //SerializeModel.XMLSerialize<ColorGaridModel>(model);
                }
                if (ListData != null)
                    SerializeModel.XMLSerialize<List<ColorTempModel>>(ListData);
                //FrmDialog.ShowDialog(this, " 保存调整的标准色温数据 " + Ok + "!", "提示", false);
            }
            catch
            {
                Console.WriteLine("[" + "]文件保存失败...");
            }
        }
        #endregion
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
        #region Mainform Load/Close event
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalClass.m_cIsRunning = false;
            UpdateUIStatus();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ShowMain), null);
            //Console.WriteLine("1111");
        }
        private void ShowMain(object obj)
        {
            while (this.Opacity != 1)
            {
                Invoke((Action)delegate ()
                {
                    this.Opacity += 0.1;
                    Thread.Sleep(2);
                    Application.DoEvents();
                });
            }
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
                if (GlobalClass.c_bIsOpen)
                    _setpage.ClearSelf();
                if (GlobalClass.m_bIsOpen)
                    _setpage.ColseMeter();
                CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Destroy(); ;
                //Console.WriteLine("i1d3Destroy OK =  " + tt.ToString());
            }
            catch
            {
                //Console.WriteLine("i1d3Destroy err.");
            }
            InitSaveForm();
            SaveColorTemp();
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
            if (GlobalClass.m_cIsRunning)
            {
                FrmTips.ShowTipsInfo(this, "Performing color calibration adjustment...");
                return;
            }
            this.Close();
            Environment.Exit(0);
        }
        #endregion
        #region 串口数据 Main-API

        // 系统消息常量
        public const int WM_DEVICE_CHANGE = 0x219;             //设备改变           
        public const int DBT_DEVICEARRIVAL = 0x8000;          //设备插入
        public const int DBT_DEVICE_REMOVE_COMPLETE = 0x8004; //设备移除
        /// <summary>
        /// 串口插拔的消息处理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICE_CHANGE)        // 捕获USB设备的拔出消息WM_DEVICECHANGE
            {
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICE_REMOVE_COMPLETE:    // USB拔出      
                        {
                            if (GlobalClass.c_bIsOpen)
                            {
                                bool com = false;
                                String[] serialPorts = System.IO.Ports.SerialPort.GetPortNames();
                                for (int i = 0; i < serialPorts.Length; i++)//找出所有串口，并选择文件中的
                                {
                                    if (serialPorts[i].Equals(_setpage.ComDevice.PortName))
                                        com = true;
                                    //Console.WriteLine(serialPorts[i]);
                                }
                                if (!com)
                                {
                                    com_status.Text = "SerialPort: " + _setpage.ComDevice.PortName + " is Disconnected";
                                    com_status.ForeColor = Color.Black;
                                    _setpage.ClearSelf();
                                    _colorpage.StopRuning();
                                    FrmDialog.ShowDialog(this, "The serial port has been disconnected, please reset it to open!", "Tips", false);
                                }
                            }
                            _setpage.UpdateCom();
                        }
                        break;
                    case DBT_DEVICEARRIVAL:             // USB插入获取对应串口名称
                        {
                            _setpage.UpdateCom();
                        }
                        break;
                }
            }
            base.WndProc(ref m);
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
                //string ss = Encoding.Default.GetString(data);

                //Console.WriteLine(ss);
                if (MainColorModel.M_PageIndex == 2)
                    _colorpage.DataReceived(data);
                else if(MainColorModel.M_PageIndex == 3)
                    _adjustpage.DataReceived(data);
                else if (MainColorModel.M_PageIndex == 4)
                    _controlpage.DataReceived(data);
                else
                {
                    Console.WriteLine("this page:" + data.Length);
                }
                //_debug.ReceivePrint(data);
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                     _debug.ReceivePrint(data);
                })); 
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
            this.BeginInvoke(new MethodInvoker(delegate ()
             {
                 _debug.SendPrint(data);
             }));
            //_debug.SendPrint(data);
            return _setpage.SendData(data);
        }
        #endregion

        #region LAN 口数据 API
        /// <summary>
        /// 接收信息的处理更新
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <param name="Remoteip"></param>
        private void LAN_ConnectReceived(object sender, bool ok)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                Reflash_Connect("");
            }));
        }
        public void Reflash_Connect(string client)
        {
            //Console.WriteLine("[" + DateTime.Now.ToString() + "] / 完成对: " + client + "请求连接！ \r");
            int count = _setpage.GetConnectCount();
            tcp_count.Text = "Count : " + count;
            tcp_count.ForeColor = Color.FromArgb(74, 22, 124);
            if (count == MainColorModel.H_Row * MainColorModel.V_Colu)
                FrmTips.ShowTips(this, "All devices have completed a TCP connection : " + count, 2000, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
        }

        #endregion

        #region Debug_Showform
        private bool debug_show = false;
        private void debug_lable_Click(object sender, EventArgs e)
        {
            _debug.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
            if (debug_show)
            {
                _debug.Hide();
                debug_show = false;
                debug_lable.Text = "∨";
            }
            else
            {
                _debug.Show();
                debug_show = true;
                debug_lable.Text = "∧";
            }
            //Console.WriteLine(this.Location.X + "=" + this.Location.Y + this.Size.Height);
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            _debug.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
        }
        private void debug_lable_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        #endregion

        #region 连接数显示
        private void tcp_count_MouseEnter(object sender, EventArgs e)
        {
            this.tcp_count.BackColor = Color.FromArgb(247, 247, 247);
            this.tcp_count.ToolTipText = _setpage.show_connectDevice();
        }
        private void tcp_count_MouseLeave(object sender, EventArgs e)
        {
            this.tcp_count.BackColor = Color.Transparent;
        }
        #endregion
    }
}
