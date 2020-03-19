using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Color_Calibration.ComLib;
using HZH_Controls.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using Color_Calibration.NetCommand.IOCPServer;
using Color_Calibration.NetCommand.IOCPClinet;
using Color_Calibration.Control;
using System.Net;
using CA200SRVRLib;
using CASDK2;
using Color_Calibration.Color_Analyzer.CA_310;
using Color_Calibration.Color_Analyzer.CA_410;

namespace Color_Calibration.UnPages
{
    public partial class UnSetForm : UserControl
    {
        public SerialPort ComDevice = new SerialPort();
        public event ComEvent.DataReceivedHandler DataReceived;
        public event LANNetEvent.TCPConnectdHandler LanConnectReceived;
        List<KeyValuePair<string, string>> dit = new List<KeyValuePair<string, string>>();
        private MainForm _mainForm;
        #region Meter
        /*
         *  CA-310
         *  Declaration of objects
         */
        //private Meter_CA310 _meter_CA310 = new Meter_CA310();
        /*
         * CA-410
         * Declaration of objects
         */
        //private Meter_CA410 _meter_CA410 = new Meter_CA410();
        #endregion
        private IOCPServer _Tcp_Server;
        private string m_localEP;
        private List<DeviceMonitor> _deivceMonitor = new List<DeviceMonitor>();
        private List<IOCPClient> _tcp_clients = new List<IOCPClient>();
        public UnSetForm()
        {
            InitializeComponent();
            ReadObject();
            #region 界面初始化
            dit.Clear();
            int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 ,9 };
            foreach (int element in num)
            {
                dit.Add(new KeyValuePair<string, string>(element.ToString(), element.ToString()));
            }
            ucComHM.Source = dit;
            ucComVM.Source = dit;
            ucComHM.SelectedIndex = MainColorModel.H_Row - 1;
            ucComVM.SelectedIndex = MainColorModel.V_Colu - 1;

            List<KeyValuePair<string, string>> dit_gamma = new List<KeyValuePair<string, string>>();
            dit_gamma.Add(new KeyValuePair<string, string>("1", "GAMMA 2.2"));
            dit_gamma.Add(new KeyValuePair<string, string>("2", "GAMMA 2.4"));
            ucComTG.Source = dit_gamma;
            ucComTG.SelectedIndex = MainColorModel.T_Gamma;

            List<KeyValuePair<string, string>> dit_temp = new List<KeyValuePair<string, string>>();
            dit_temp.Add(new KeyValuePair<string, string>("1", "Cool "));
            dit_temp.Add(new KeyValuePair<string, string>("2", "NORMAL"));
            dit_temp.Add(new KeyValuePair<string, string>("3", "WARM "));
            dit_temp.Add(new KeyValuePair<string, string>("4", "CUSTOM"));
            ucComTC.Source = dit_temp;
            ucComTC.SelectedIndex = MainColorModel.T_Temp;

            List<KeyValuePair<string, string>> dit_lum = new List<KeyValuePair<string, string>>();
            dit_lum.Add(new KeyValuePair<string, string>("1", "AUTOMTIC"));
            dit_lum.Add(new KeyValuePair<string, string>("2", "CUSTOM"));
            ucComTL.Source = dit_lum;
            ucComTL.SelectedIndex = MainColorModel.T_Lum;
            #endregion
            InitialTempData();
            InitComPort();
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            if (Com_Class.GetLocalIP().Count > 0)
            {
                m_localEP = Com_Class.GetLocalIP()[0];
                _Tcp_Server = new IOCPServer(IPAddress.Parse(m_localEP), 8234, 81);
                _Tcp_Server.DataReceived += new LANNetEvent.TCPDataReceivedHandler(Lan_DataReceived);
                _Tcp_Server.ConnectReceived += new LANNetEvent.TCPConnectdHandler(Lan_ConnectReceived);
            }
            //Console.WriteLine("2222");
        }
        public void InitUmainForm(MainForm f)
        {
            _mainForm = f;
            ucSwitch_com.Checked = MainColorModel.T_ComLan;
            if (MainColorModel.T_ComLan)
            {
                if (MainColorModel.M_LanIndex == 0)
                    _mainForm.com_status.Text = "TCP Server  is Closed. ";
                else
                    _mainForm.com_status.Text = "TCP Client  is Closed. ";
            }
        }
        private void InitComPort()
        {
            string[] drpComList = SerialPort.GetPortNames().Distinct().ToArray();
            List<KeyValuePair<string, string>> dit_port = new List<KeyValuePair<string, string>>();
            if (drpComList.Length > 0)
            {
                for (int i = 1; i <= drpComList.Length; i++)
                {
                    dit_port.Add(new KeyValuePair<string, string>(i.ToString(), drpComList[i - 1]));
                }
                Uncom_port.Source = dit_port;
                if (dit_port.Count > MainColorModel.M_ComIndex)
                    Uncom_port.SelectedIndex = MainColorModel.M_ComIndex;
            }
            
            List<KeyValuePair<string, string>> dit_lan = new List<KeyValuePair<string, string>>();
            dit_lan.Add(new KeyValuePair<string, string>("1", "TCP Server"));
            dit_lan.Add(new KeyValuePair<string, string>("2", "TCP Client"));
            Uncom_lan.Source = dit_lan;
            Uncom_lan.SelectedIndex = MainColorModel.M_LanIndex;

            List<KeyValuePair<string, string>> dit_meter = new List<KeyValuePair<string, string>>();
            dit_meter.Add(new KeyValuePair<string, string>("1", "X-rite i1D3"));
            dit_meter.Add(new KeyValuePair<string, string>("2", "CA-310"));
            dit_meter.Add(new KeyValuePair<string, string>("4", "CA-410"));
            Uncom_meter.Source = dit_meter;
            Uncom_meter.SelectedIndex = MainColorModel.M_MeterType;

            List<KeyValuePair<string, string>> dit_model = new List<KeyValuePair<string, string>>();
            dit_model.Add(new KeyValuePair<string, string>("1", "Monitor"));
            dit_model.Add(new KeyValuePair<string, string>("2", "Multi-screen"));
            Uncom_model.Source = dit_model;
            Uncom_model.SelectedIndex = MainColorModel.M_ModelType;

            ucComHM.SelectedIndex = MainColorModel.H_Row - 1;
            ucComVM.SelectedIndex = MainColorModel.V_Colu - 1;
            //_mainForm.UpdateUIStatus();
        }
        #region Main UI change
        /// <summary>
        /// 色温用户自定义模式选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucComTC_SelectedChangedEvent(object sender, EventArgs e)
        {
            MainColorModel.T_Temp = ucComTC.SelectedIndex;
            //if (MainColorModel.M_PageIndex > 0)
            //    _mainForm.UpdateUIStatus();
            if(MainColorModel.M_PageIndex == 1)
                _mainForm.UpdateUIStatus();
        }
        private void ucComTL_SelectedChangedEvent(object sender, EventArgs e)
        {
            MainColorModel.T_Lum = ucComTL.SelectedIndex;
        }
        private void Uncom_model_SelectedChangedEvent(object sender, EventArgs e)
        {
            MainColorModel.M_ModelType = Uncom_model.SelectedIndex;
        }

        private void ucBtn_set_BtnClick(object sender, EventArgs e)
        {
            int index = ucComTC.SelectedIndex;
            new ColorForm(index).ShowDialog();
            _mainForm.UpdateUIStatus();
        }
        #endregion
        #region 数据传输
        /// <summary>
        /// 输出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(200);
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            if (MainColorModel.M_PageIndex == 3)
            {
                Thread.Sleep(200);
                string str;
                str = ComDevice.ReadExisting();
                ReDatas = Encoding.Default.GetBytes(str);
                DataReceived(this, ReDatas);//输出数据

                Console.WriteLine(str);
            }
            else
            {
                //Console.WriteLine("++++");
                ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据
                DataReceived(this, ReDatas);//输出数据
            }
            
            LogHelper.WriteLog("串口 DataReceived：" + Encoding.Default.GetString(ReDatas));
            //Console.WriteLine("串口 DataReceived：" + ReDatas.Length);
            //ExceptionLog.getLog().WriteLogFile(ReDatas, DateTime.Now.ToString("yyyyMMdd") + "log.txt");
        }

        private void Lan_DataReceived(object sender, byte[] data)
        {
            if (data.Length > 0)
            {
                DataReceived(this, data);//输出数据
                //Console.WriteLine("LAN DataReceived：" + data.Length);
                //LogHelper.WriteLog("LAN DataReceived：" + Encoding.Default.GetString(data));
            }
        }

        private void Lan_ConnectReceived(object sender, bool ok)
        {
            if (ok == false)
            {
                if (MainColorModel.M_LanIndex == 1)
                    SetReConnect(sender as IOCPClient);
                //Console.WriteLine("LAN DisConnect：" + client);
            }
            LanConnectReceived(sender, ok);
            //Console.WriteLine("LAN ConnectReceived：" + client);
            //LogHelper.WriteLog("LAN ConnectReceived：" + client);
            //Console.WriteLine("串口 DataReceived：" + ReDatas.Length);
            //ExceptionLog.getLog().WriteLogFile(ReDatas, DateTime.Now.ToString("yyyyMMdd") + "log.txt");
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    ComDevice.Write(data, 0, data.Length);//发送数据

                    //LogHelper.WriteLog("串口 Send Data:" + data);
                    return true;
                }
                catch (Exception ex)
                {
                    FrmDialog.ShowDialog(this, ex.Message, "Tips", true);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                //MessageBox.Show("Serial port is not open", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        #endregion
        #region 设备连接操作
        public void UpdateCom()
        {
            string[] drpComList = SerialPort.GetPortNames().Distinct().ToArray();
            List<KeyValuePair<string, string>> dit_port = new List<KeyValuePair<string, string>>();
            if (drpComList.Length > 0)
            {
                for (int i = 1; i <= drpComList.Length; i++)
                {
                    dit_port.Add(new KeyValuePair<string, string>(i.ToString(), drpComList[i - 1]));
                }
                Uncom_port.Source = dit_port;
                Uncom_port.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 关闭通讯连端口
        /// </summary>
        public void ClearSelf()
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();
                Btn_connect.Text = "Connect";
                Btn_connect.ForeColor = Color.FromArgb(74, 22, 124);
                Uncom_port.Enabled = true;
            }
            if (MainColorModel.T_ComLan)
            {
                if (MainColorModel.M_ComIndex == 0)
                    _Tcp_Server.Stop();
                else
                    Client_Close();
                Btn_connectLan.Text = "Connect";
                Btn_connectLan.ForeColor = Color.FromArgb(74, 22, 124);
                Uncom_lan.Enabled = true;
            }
            GlobalClass.c_bIsOpen = false;
            Btn_connect.Text = "Connect";
            Btn_connect.ForeColor = Color.FromArgb(74, 22, 124);
            Uncom_port.Enabled = true;
            UpdateCom();
        }
        /// <summary>
        /// 保存本页面的设置信息
        /// </summary>
        public void SavePage()
        {
            MainColorModel.M_ComIndex = Uncom_port.SelectedIndex;
            MainColorModel.M_LanIndex = Uncom_lan.SelectedIndex;
            MainColorModel.M_MeterType = Uncom_meter.SelectedIndex;
            MainColorModel.M_ModelType = Uncom_model.SelectedIndex;
            MainColorModel.T_Lum = ucComTL.SelectedIndex;
            SaveClientModel();
        }
        /// <summary>
        /// 关闭连接的校色设备
        /// </summary>
        public void ColseMeter()
        {
            if (m_bIsOpen)
            {
                if (MainColorModel.M_MeterType == 0)
                    CalibrationSDK.i1dColorSDK.i1d3DeviceClose(i1d3Handle);
                else if (MainColorModel.M_MeterType == 1)
                    GlobalClass._meter_CA310.CloseConnect_CA310();
                else
                    GlobalClass._meter_CA410.CloseConnect_CA410();
            }
        }
        /// <summary>
        /// 通讯连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_connect_BtnClick(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                if (string.IsNullOrEmpty(Uncom_port.SelectedText))
                {
                    FrmDialog.ShowDialog(this, "The serial port is not selected or does not exist and cannot be opened！", "Tips", false);
                    //MessageBox.Show("The serial port is not selected or does not exist and cannot be opened！", "Tips");
                    return;
                }

                ComDevice.PortName = Uncom_port.SelectedText;
                ComDevice.BaudRate = Convert.ToInt32("9600".ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32("0".ToString());
                ComDevice.DataBits = Convert.ToInt32("8".ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32("1".ToString());
                try
                {
                    if (!string.IsNullOrEmpty(ComDevice.PortName))
                        ComDevice.Open();
                    else
                    {
                        FrmDialog.ShowDialog(this, "Serial port cannot be opened！", "提示", false);
                        //MessageBox.Show("Serial port cannot be opened！", "Tips");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    FrmDialog.ShowDialog(this, ex.Message, "Tips", false);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.Text = "Close";
                _mainForm.com_status.Text = "SerialPort : " + Uncom_port.SelectedText + " is Connected";
                _mainForm.com_status.ForeColor = Color.FromArgb(164, 38, 143);
                //FrmTips.ShowTipsInfo(_mainForm, "SerialPort : " + Uncom_port.SelectedText + " is Connect");
                FrmTips.ShowTips(_mainForm, "SerialPort: " + Uncom_port.SelectedText + " is Connected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                Btn_connect.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    FrmDialog.ShowDialog(this, ex.Message, "Tips", false);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.Text = "Connect";
                _mainForm.com_status.Text = "SerialPort: " + Uncom_port.SelectedText + " is Disconnected";
                _mainForm.com_status.ForeColor = Color.Black;
                //FrmTips.ShowTipsInfo(_mainForm, "SerialPort : " + Uncom_port.SelectedText + " is Close");
                FrmTips.ShowTips(_mainForm, "SerialPort: " + Uncom_port.SelectedText + " is Disconnected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                Btn_connect.ForeColor = Color.FromArgb(164, 38, 143);
            }
            MainColorModel.M_ComIndex = Uncom_port.SelectedIndex;
            GlobalClass.c_bIsOpen = ComDevice.IsOpen;
            Uncom_port.Enabled = !ComDevice.IsOpen;
        }

        private void ucBtn_id_BtnClick(object sender, EventArgs e)
        {
            int row = int.Parse(ucComHM.SelectedText);
            int colu = int.Parse(ucComVM.SelectedText);
            new IDSetForm(this,row,colu).ShowDialog();
        }
        private bool m_bIsOpen = false;
        private IntPtr i1d3Handle;
        /// <summary>
        /// 校色设备 - 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unbt_meter_BtnClick(object sender, EventArgs e)
        {
            //FrmDialog.ShowDialog(this, "Open connect the i1D.", "提示", false);
            if (m_bIsOpen == false)
            {
                try
                {
                    if (Uncom_meter.SelectedIndex == 0)
                        Connect_i1d3();
                    else if (Uncom_meter.SelectedIndex == 1)
                    {
                        #region CA310
                        if (GlobalClass._meter_CA310.StartConnect_CA310())
                        {
                            m_bIsOpen = true;
                            GlobalClass.m_bIsOpen = m_bIsOpen;
                            Unbt_meter.Text = "Close";
                            _mainForm.meter_status.Text = "Calibration : CA310 is Connected ";
                            _mainForm.meter_status.ForeColor = Color.FromArgb(164, 38, 143);
                            Unbt_meter.ForeColor = Color.Red;
                            FrmTips.ShowTipsInfo(_mainForm, "Calibration : CA310 is Connected");
                        }
                        else
                        {
                            FrmTips.ShowTipsError(_mainForm, "Calibration : CA310 connection failed,please check the device connection");
                        }
                        #endregion
                    }
                    else
                    {
                        #region CA410
                        if (GlobalClass._meter_CA410.StartConnect_CA410())
                        {
                            m_bIsOpen = true;
                            GlobalClass.m_bIsOpen = m_bIsOpen;
                            Unbt_meter.Text = "Close";
                            _mainForm.meter_status.Text = "Calibration : CA410 is Connected ";
                            _mainForm.meter_status.ForeColor = Color.FromArgb(164, 38, 143);
                            Unbt_meter.ForeColor = Color.Red;
                            FrmTips.ShowTipsInfo(_mainForm, "Calibration : CA410 is Connected");
                        }
                        else
                        {
                            FrmTips.ShowTipsError(_mainForm, "Calibration : CA410 connection failed,please check the device connection.");
                        }
                        #endregion
                    }
                    MainColorModel.M_MeterType = Uncom_meter.SelectedIndex;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("i1d3 connect err:" + ex.Message);
                    FrmDialog.ShowDialog(this, "   Error Connect Color_Analyzer ! ", "Tips", false);
                    return;
                }
            }
            else
            {
                if (Uncom_meter.SelectedIndex == 0)
                    DisConnect_i1d3();
                else if (Uncom_meter.SelectedIndex == 1)
                {
                    #region CA310 Close
                    if (GlobalClass._meter_CA310.CloseConnect_CA310())
                    {
                        m_bIsOpen = false;
                        GlobalClass.m_bIsOpen = m_bIsOpen;
                        Unbt_meter.Text = "Connect";
                        _mainForm.meter_status.Text = "Calibration : CA310 is Disconnected";
                        _mainForm.meter_status.ForeColor = Color.Black;
                        Unbt_meter.ForeColor = Color.FromArgb(164, 38, 143);
                        FrmTips.ShowTipsInfo(_mainForm, "Calibration : CA310 is Disconnected");
                    }
                    else
                    {
                        FrmTips.ShowTipsError(_mainForm, "Calibration : CA310 Device connection error!");
                    }
                    #endregion
                }
                else
                {
                    #region CA410 Close
                    if (GlobalClass._meter_CA410.CloseConnect_CA410())
                    {
                        m_bIsOpen = false;
                        GlobalClass.m_bIsOpen = m_bIsOpen;
                        Unbt_meter.Text = "Connect";
                        _mainForm.meter_status.Text = "Calibration : CA410 is Disconnected";
                        _mainForm.meter_status.ForeColor = Color.Black;
                        Unbt_meter.ForeColor = Color.FromArgb(164, 38, 143);
                        FrmTips.ShowTipsInfo(_mainForm, "Calibration : CA410 is Disconnected");
                    }
                    else
                    {
                        FrmTips.ShowTipsError(_mainForm, "Calibration : CA410 Device connection error!");
                    }
                    #endregion
                }
            }
        }

        #region  i1d3 色彩分析仪 连接
        /// <summary>
        /// i1d3 连接
        /// </summary>
        private void Connect_i1d3()
        {
            try
            {
                CalibrationSDK.i1dColorSDK.i1d3Destroy();
                CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Initialize();
                //Console.WriteLine("i1d3Initialize OK =  " + tt.ToString());
                uint ii = CalibrationSDK.i1dColorSDK.i1d3GetNumberOfDevices();
                if (ii == 0)
                {
                    FrmDialog.ShowDialog(this, "   No i1d3 devices found!", "Tips", false);
                    return;
                }
                //Console.WriteLine("count: " + ii);
                //i1d3Handle = new IntPtr();
                tt = CalibrationSDK.i1dColorSDK.i1d3GetDeviceHandle(0, out i1d3Handle);
                if (tt != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
                {
                    FrmDialog.ShowDialog(this, "   Error getting handle!" + tt.ToString(), "Tips", false);
                    return;
                }
                GlobalClass.i1d3Handle = i1d3Handle;
                //Console.WriteLine("i1d3Handle: " + i1d3Handle);
                //string path = Application.StartupPath + "\\i1d3 Support Files\\";
                //CalibrationSDK.i1dColorSDK.i1d3SetSupportFilePath(i1d3Handle, path);

                tt = CalibrationSDK.i1dColorSDK.i1d3DeviceOpen(i1d3Handle);
                if (tt != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
                {
                    byte[] key = { 0xD4, 0x9F, 0xD4, 0xA4, 0x59, 0x7E, 0x35, 0xCF };
                    CalibrationSDK.i1dColorSDK.i1d3OverrideDeviceDefaults(0, 0, key);
                    //Console.WriteLine("i1d3Key: " + tt.ToString());
                    tt = CalibrationSDK.i1dColorSDK.i1d3DeviceOpen(i1d3Handle);

                    //Console.WriteLine("i1d3open: "+ tt.ToString());
                }
                if (tt != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
                {
                    FrmDialog.ShowDialog(this, "   Error opening i1d3 !   \r   " + tt.ToString(), "Tips", false);
                    return;
                }
                tt = CalibrationSDK.i1dColorSDK.i1d3SetIntegrationTime(i1d3Handle, 1.000);
                CalibrationSDK.i1dColorSDK.i1d3SetTargetLCDTime(i1d3Handle, 0.080);

                tt = CalibrationSDK.i1dColorSDK.i1d3SetMeasurementMode(i1d3Handle, CalibrationSDK.i1dColorSDK.i1d3MeasMode_t.i1d3MeasModeLCD);
                //Console.WriteLine("SetModel" + tt.ToString());
                //Console.WriteLine("Info== " + info.strFirmwareVersion +"="+ info.strProductName +"="+ info.ucIsLocked);
                m_bIsOpen = true;
                GlobalClass.m_bIsOpen = m_bIsOpen;
                Unbt_meter.Text = "Close";
                _mainForm.meter_status.Text = "Calibration : i1d3 is Connected ";
                _mainForm.meter_status.ForeColor = Color.FromArgb(164, 38, 143);
                FrmTips.ShowTipsInfo(_mainForm, "Calibration : i1d3 is Connected");
                //FrmTips.ShowTips(_mainForm, "Calibration : i1D3 is Connected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 70), TipsState.Info);
                Unbt_meter.ForeColor = Color.Red;
            }
            catch
            {
                FrmDialog.ShowDialog(this, "   Error connect i1d3 ! ", "Tips", false);
                return;
                //Console.WriteLine("i1d3 connect err.");
            }
        }
        private void DisConnect_i1d3()
        {
            if (i1d3Handle != null)
            {
                CalibrationSDK.i1dColorSDK.i1d3DeviceClose(i1d3Handle);
                m_bIsOpen = false;
                GlobalClass.m_bIsOpen = m_bIsOpen;
                Unbt_meter.Text = "Connect";
                _mainForm.meter_status.Text = "Calibration : i1d3 is Disconnected";
                _mainForm.meter_status.ForeColor = Color.Black;
                FrmTips.ShowTipsInfo(_mainForm, "Calibration : i1d3 is Disconnected");
                //FrmTips.ShowTips(_mainForm, "Calibration : i1D3 is Disconnected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 70), TipsState.Info);
                Unbt_meter.ForeColor = Color.FromArgb(164, 38, 143);
            }
        }
        #endregion
        
        #endregion
        #region 行列更新
        private void HV_Reflash()
        {
            List<KeyValuePair<string, string>> id_source = new List<KeyValuePair<string, string>>();
            int key = MainColorModel.H_Row * MainColorModel.V_Colu;
            for (int i = 1; i <= key; i++)
            {
                id_source.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString()));
            }
            MainColorModel.Id_List = id_source;
        }

        private void ucComHM_SelectedChangedEvent(object sender, EventArgs e)
        {
            int h_row = int.Parse(ucComHM.SelectedText);
            //int v_col = int.Parse(ucComVM.SelectedText);
            MainColorModel.H_Row = h_row;
            HV_Reflash();
        }

        private void ucComVM_SelectedChangedEvent(object sender, EventArgs e)
        {
            //int h_row = int.Parse(ucComHM.SelectedText);
            int v_col = int.Parse(ucComVM.SelectedText);
            MainColorModel.V_Colu = v_col;
            HV_Reflash();
        }
        #endregion
        #region 初始化数据
        private void ReadObject()
        {
            try
            {
                SerializeModel.PathFile = Application.StartupPath + "\\ColorData\\main_set.xml";
                MainSetModel setModel = new MainSetModel();
                setModel = SerializeModel.DeXMLSerialize<MainSetModel>();

                MainColorModel.H_Row = setModel.H_Row;
                MainColorModel.V_Colu = setModel.V_Colu;
                MainColorModel.M_MeterType = setModel.M_MeterType;
                MainColorModel.M_ModelType = setModel.M_ModelType;
                MainColorModel.M_PageIndex = setModel.M_PageIndex;
                MainColorModel.M_ComIndex = setModel.M_ComIndex;
                MainColorModel.M_LanIndex = setModel.M_LanIndex;
                MainColorModel.T_Custom = setModel.T_Custom;
                MainColorModel.T_Gamma = setModel.T_Gamma;
                MainColorModel.T_Temp = setModel.T_Temp;
                MainColorModel.T_Lum = setModel.T_Lum;
                MainColorModel.T_ID = setModel.T_ID;
                MainColorModel.T_ComLan = setModel.T_ComLan;
                //MainColorModel.T_ColorTemp = setModel.T_ColorTempStd;
                //Console.WriteLine(MainColorModel.H_Row + ":" + MainColorModel.V_Colu);
                ReadClientModel();
            }
            catch
            {
                Console.WriteLine("[" + "]文件读取失败...");
            }
        }
        
        private void InitialTempData()
        {
            string path = Application.StartupPath + "\\ColorData\\colortemp.xml";
            if (File.Exists(path))
            {
                SerializeModel.PathFile = path;
                try
                {
                    List<ColorTempModel> ListData = new List<ColorTempModel>();
                    ListData = SerializeModel.DeXMLSerialize<List<ColorTempModel>>();
                    if (ListData != null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            //UpdateGaridSource(ListData[i]);
                            GlobalClass._t_ColorTempStd[i, 0] = ListData[i].C_ColorTemp_x;
                            GlobalClass._t_ColorTempStd[i, 1] = ListData[i].C_ColorTemp_y;
                            GlobalClass._t_ColorTempStd[i, 2] = ListData[i].C_ColorTemp_lv;
                            GlobalClass._t_ColorEerorxy[i] = int.Parse(ListData[i].C_ColorEeror_xy);
                            GlobalClass._t_ColorEerorlv[i] = int.Parse(ListData[i].C_ColorEeror_lv);
                            GlobalClass._t_ColorEeror[i] = ListData[i].C_ColorEeror;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("[colortemp]文件读取失败...");
                }
            }
        }
        
        private void ReadClientModel()
        {
            string path = Application.StartupPath + "\\ColorData\\clientlist.xml";
            if (File.Exists(path))
            {
                SerializeModel.PathFile = path;
                try
                {
                    List<DeviceMonitor> ListData = new List<DeviceMonitor>();
                    ListData = SerializeModel.DeXMLSerialize<List<DeviceMonitor>>();
                    if (ListData != null)
                    {
                        for (int i = 0; i < ListData.Count; i++)
                        {
                            _deivceMonitor.Add(ListData[i]);
                        }
                    }
                    Console.WriteLine(ListData.Count);
                }
                catch
                {
                    Console.WriteLine("client List error.");
                }
            }
        }
        private void SaveClientModel()
        {
            if (_deivceMonitor.Count > 0)
            {
                try
                {
                    string path = Application.StartupPath + "\\ColorData\\clientlist.xml";
                    SerializeModel.PathFile = path;

                    List<DeviceMonitor> ListData = new List<DeviceMonitor>();

                    for (int i = 0; i < _deivceMonitor.Count; i++)
                    {
                        DeviceMonitor ct = new DeviceMonitor();
                        ct.ip = _deivceMonitor[i].ip;
                        ct.name = _deivceMonitor[i].name;
                        ct.mac = _deivceMonitor[i].mac;
                        ct.port = _deivceMonitor[i].port;
                        ListData.Add(ct);
                        //SerializeModel.XMLSerialize<ColorGaridModel>(model);
                    }
                    if (ListData != null)
                        SerializeModel.XMLSerialize<List<DeviceMonitor>>(ListData);
                    //FrmDialog.ShowDialog(this, " 保存调整的标准色温数据 " + Ok + "!", "提示", false);
                }
                catch
                {
                    Console.WriteLine("[" + "]Client文件保存失败...");
                }
            }
        }
        #endregion

        #region Lan 通讯连接
        /// <summary>
        /// 通讯方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSwitch_com_CheckedChanged(object sender, EventArgs e)
        {
            if (ucSwitch_com.Checked)
            {
                Uncom_lan.Visible = true;
                Uncom_port.Visible = false;
                Btn_connect.Visible = false;
                Btn_connectLan.Visible = true;
                GlobalClass.m_ComorLan = true;
                _mainForm.tcp_count.Visible = true;
                if (Uncom_lan.SelectedIndex == 0)
                {
                    lblBl_add.Visible = false;
                    _mainForm.com_status.Text = "TCP Server  is Closed. ";
                }
                else
                {
                    lblBl_add.Visible = true;
                    _mainForm.com_status.Text = "TCP Client  is Closed. ";
                }
                MainColorModel.T_ComLan = true;
            }
            else
            {
                Uncom_lan.Visible = false;
                Uncom_port.Visible = true;
                Btn_connect.Visible = true;
                Btn_connectLan.Visible = false;
                lblBl_add.Visible = false;
                GlobalClass.m_ComorLan = false;

                _mainForm.com_status.Text = "SerialPort: " + Uncom_port.SelectedText + " is Disconnected";
                _mainForm.tcp_count.Visible = false;
                MainColorModel.T_ComLan = false;
            }
        }

        /// <summary>
        /// Lan connect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_connectLan_Click(object sender, EventArgs e)
        {
            if (Uncom_lan.SelectedIndex == 0)
            {
                #region TCP Server Connect
                if (!_Tcp_Server.IsRunning)
                {
                    if (_Tcp_Server.Start())
                    {
                        ucSwitch_com.Enabled = false;
                        ucSwitch_com.Visible = false;
                        Btn_connectLan.Text = "Close";
                        GlobalClass.c_bIsOpen = true;
                        _mainForm.com_status.Text = "TCP Server : " + m_localEP + ": 8234 " + " is Listen.";
                        //Console.WriteLine("OK");
                        _mainForm.com_status.ForeColor = Color.FromArgb(164, 38, 143);
                        //FrmTips.ShowTipsInfo(_mainForm, "SerialPort : " + Uncom_port.SelectedText + " is Connect");
                        FrmTips.ShowTips(_mainForm, "TCP Server : " + m_localEP + ": 8234 " + " Starts  Listening.", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                        Btn_connectLan.ForeColor = Color.Red;
                    }
                    else
                    {
                        FrmDialog.ShowDialog(this, "TCP Server cannot be Start Listen！", "Tips", false);
                        //MessageBox.Show("Serial port cannot be opened！", "Tips");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        _Tcp_Server.Stop();
                    }
                    catch (Exception ex)
                    {
                        FrmDialog.ShowDialog(this, "TCP Server cannot be close Listen！", "Tips", false);
                        return;
                        //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ucSwitch_com.Enabled = true;
                    ucSwitch_com.Visible = true;
                    Btn_connectLan.Text = "Connect";
                    GlobalClass.c_bIsOpen = false;
                    _mainForm.com_status.Text = "TCP Server : " + m_localEP + ": 8234 " + " is Closed. ";
                    _mainForm.tcp_count.Text = "Count : 0";
                    _mainForm.com_status.ForeColor = Color.Black;
                    FrmTips.ShowTips(_mainForm, "TCP Server: " + m_localEP + ": 8234 " + "End  Listening. ", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                    Btn_connectLan.ForeColor = Color.FromArgb(164, 38, 143);
                }
                #endregion
            }
            else
            {
                #region TCP Client Connect
                if (_deivceMonitor.Count > 0)
                {
                    if (!GlobalClass.c_bIsOpen)
                    {
                        try
                        {
                            Cilent_connect();
                        }
                        catch
                        {
                            Console.WriteLine("Cilent_connect error.");
                        }
                        ucSwitch_com.Enabled = false;
                        ucSwitch_com.Visible = false;
                        lblBl_add.Visible = false;
                        Btn_connectLan.Text = "Close";
                        GlobalClass.c_bIsOpen = true;
                        _mainForm.com_status.Text = "TCP Client  is Connect.";
                        //Console.WriteLine("OK");
                        _mainForm.com_status.ForeColor = Color.FromArgb(74, 22, 124);
                        //FrmTips.ShowTipsInfo(_mainForm, "SerialPort : " + Uncom_port.SelectedText + " is Connect");
                        FrmTips.ShowTips(_mainForm, "TCP Client Starts To Connect.", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                        Btn_connectLan.ForeColor = Color.Red;
                    }
                    else
                    {
                        try
                        {
                            Client_Close();
                        }
                        catch (Exception ex)
                        {
                            //FrmDialog.ShowDialog(this, "TCP Server cannot be close Listen！", "Tips", false);
                            Console.WriteLine(ex.Message, "error");
                            return;
                        }
                        ucSwitch_com.Enabled = true;
                        ucSwitch_com.Visible = true;
                        lblBl_add.Visible = true;
                        Btn_connectLan.Text = "Connect";
                        GlobalClass.c_bIsOpen = false;
                        _mainForm.com_status.Text = "TCP Client  is Closed. ";
                        _mainForm.tcp_count.Text = "Count : 0";
                        _mainForm.com_status.ForeColor = Color.Black;
                        FrmTips.ShowTips(_mainForm, "TCP Client  Closes The Connection. ", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                        Btn_connectLan.ForeColor = Color.FromArgb(74, 22, 124);
                    }
                }
                #endregion
            }
            Uncom_lan.Enabled = !GlobalClass.c_bIsOpen;
            MainColorModel.M_LanIndex = Uncom_lan.SelectedIndex;
        }
        
        #region Client opreate
        /// <summary>
        /// Client connect
        /// </summary>
        private bool Cilent_connect()
        {
            if (_deivceMonitor.Count > 0)
            {
                _tcp_clients = new List<IOCPClient>();
                foreach (DeviceMonitor monitor in _deivceMonitor)
                {
                    IOCPClient _m_client = new IOCPClient(monitor.ip, monitor.port);
                    if (_m_client.Start())
                    {
                        _m_client.DataReceived += new LANNetEvent.TCPDataReceivedHandler(Lan_DataReceived);
                        _m_client.ConnectReceived += new LANNetEvent.TCPConnectdHandler(Lan_ConnectReceived);
                        _tcp_clients.Add(_m_client);
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Client Close Connect
        /// </summary>
        private void Client_Close()
        {
            if (_tcp_clients.Count > 0)
            {
                foreach (IOCPClient _m_client in _tcp_clients)
                {
                    if (_m_client != null && _m_client.Connected)
                        _m_client.DisConnect();
                }
            }
        }

        /// <summary>
        /// Clinet to send data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private bool Client_SendData(byte[] data)
        {
            if (_deivceMonitor.Count > 0)
            {
                foreach (IOCPClient _m_client in _tcp_clients)
                {
                    if (_m_client != null && _m_client.Connected)
                        _m_client.Send(data);
                }
                return true;
            }
            return false;
        }
        #endregion
        #region Lable show
        private void lblBl_add_MouseEnter(object sender, EventArgs e)
        {
            Label LB = sender as Label;
            LB.Image = Color_Calibration.Properties.Resources.btn2_Ent;
        }

        private void lblBl_add_MouseLeave(object sender, EventArgs e)
        {
            Label LB = sender as Label;
            LB.Image = null;
        }

        private void lblBl_add_MouseUp(object sender, MouseEventArgs e)
        {
            Label LB = sender as Label;
            LB.Location = new Point(LB.Location.X - 1, LB.Location.Y - 1);
        }

        private void lblBl_add_MouseDown(object sender, MouseEventArgs e)
        {
            Label LB = sender as Label;
            LB.Image = Color_Calibration.Properties.Resources.btn2_Dwn;
            LB.Location = new Point(LB.Location.X + 1, LB.Location.Y + 1);


            Form_Net _fn = new Form_Net();
            DialogResult result = _fn.ShowDialog();
            if (result == DialogResult.OK)
            {
                _deivceMonitor.Clear();
                _deivceMonitor = _fn.Get_deviceList();
            }
        }
        #endregion

        private void Uncom_lan_SelectedChangedEvent(object sender, EventArgs e)
        {
            if (Uncom_lan.SelectedIndex == 0)
                lblBl_add.Visible = false;
            else
                lblBl_add.Visible = true;
        }
        
        /// <summary>
        /// 刷新当前的连接
        /// </summary>
        private void RefreshConnect(bool con = true)
        {
            try
            {
                if (_deivceMonitor.Count > 0)
                {
                    foreach (IOCPClient _m_client in _tcp_clients)
                    {
                        if (_m_client == null || _m_client.Connected == false)
                        {
                            _tcp_clients.Remove(_m_client);
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 进行重新连接
        /// </summary>
        /// <param name="_client"></param>
        /// <returns></returns>
        private bool ReDoConnect(IOCPClient _client)
        {
            foreach (IOCPClient _m_client in _tcp_clients)
            {
                if (_m_client.Equals(_client))
                {
                    _m_client.DataReceived -= new LANNetEvent.TCPDataReceivedHandler(Lan_DataReceived);
                    _m_client.ConnectReceived -= new LANNetEvent.TCPConnectdHandler(Lan_ConnectReceived);
                    _tcp_clients.Remove(_m_client);
                    break;
                }
            }
            DeviceMonitor _monitor = new DeviceMonitor();
            foreach (DeviceMonitor monitor in _deivceMonitor)
            {
                if (_client.m_socket.RemoteEndPoint.ToString().Contains(monitor.ip))
                {
                    _monitor = monitor;
                    break;
                }
            }
            if (_monitor == null)
                return false;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IOCPClient _m_client = new IOCPClient(_monitor.ip, _monitor.port);
                    if (_m_client.Start())
                    {
                        _m_client.DataReceived += new LANNetEvent.TCPDataReceivedHandler(Lan_DataReceived);
                        _m_client.ConnectReceived += new LANNetEvent.TCPConnectdHandler(Lan_ConnectReceived);
                        _tcp_clients.Add(_m_client);
                        //Console.WriteLine("重新连接OK。");
                        return true;
                    }
                    Thread.Sleep(1000);
                }
                catch
                { }
            }
            return false;
        }
        /// <summary>
        /// 获取当前连接的数量
        /// </summary>
        /// <returns></returns>
        public int GetConnectCount()
        {
            if (Uncom_lan.SelectedIndex == 0)
                return _Tcp_Server.m_clients.Count;
            else
            {
                //RefreshConnect();
                return _tcp_clients.Count;
            }
        }
        public bool SetReConnect(IOCPClient _client)
        {
            bool ok = ReDoConnect(_client);
            return ok;
        }

        public string show_connectDevice()
        {
            string str = "";
            if (Uncom_lan.SelectedIndex == 0)
            {
                for (int i = 0; i < _Tcp_Server.m_clients.Count; i++)
                {
                    str += _Tcp_Server.m_clients[i].Socket.RemoteEndPoint.ToString() + "\n";
                }
            }
            else
            {
                for (int i = 0; i < _tcp_clients.Count; i++)
                {
                    str += _tcp_clients[i].m_socket.RemoteEndPoint.ToString() + "\n";
                }
            }
            return str;
        }
        #endregion
    }
}
