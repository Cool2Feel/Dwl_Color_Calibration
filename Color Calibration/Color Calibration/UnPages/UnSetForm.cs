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

namespace Color_Calibration.UnPages
{
    public partial class UnSetForm : UserControl
    {
        private SerialPort ComDevice = new SerialPort();
        List<KeyValuePair<string, string>> dit = new List<KeyValuePair<string, string>>();
        private MainForm _mainForm;
        public UnSetForm()
        {
            InitializeComponent();
            ReadObject();
            #region 界面初始化
            dit.Clear();
            int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13, 14 ,15 };
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
            dit_lum.Add(new KeyValuePair<string, string>("2", "OTHER"));
            ucComTL.Source = dit_lum;
            ucComTL.SelectedIndex = MainColorModel.T_Lum;
            #endregion
            InitialTempData();
            InitComPort();
            //Console.WriteLine("2222");
        }
        public void InitUmainForm(MainForm f)
        {
            _mainForm = f;
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
                Uncom_port.SelectedIndex = MainColorModel.M_ComIndex;
            }
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);

            List<KeyValuePair<string, string>> dit_meter = new List<KeyValuePair<string, string>>();
            //dit_meter.Add(new KeyValuePair<string, string>("1", "CA310"));
            dit_meter.Add(new KeyValuePair<string, string>("2", "X-rite i1D3"));
            Uncom_meter.Source = dit_meter;
            Uncom_meter.SelectedIndex = MainColorModel.M_MeterType;

            List<KeyValuePair<string, string>> dit_model = new List<KeyValuePair<string, string>>();
            dit_model.Add(new KeyValuePair<string, string>("1", "监视器"));
            dit_model.Add(new KeyValuePair<string, string>("2", "拼接屏"));
            Uncom_model.Source = dit_model;
            Uncom_model.SelectedIndex = MainColorModel.M_ModelType;

            ucComHM.SelectedIndex = MainColorModel.H_Row - 1;
            ucComVM.SelectedIndex = MainColorModel.V_Colu - 1;
            //_mainForm.UpdateUIStatus();
        }
        /// <summary>
        /// 色温用户自定义模式选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucComTC_SelectedChangedEvent(object sender, EventArgs e)
        {
            if(ucComTC.SelectedIndex == 3)
            {
                label6.Visible = true;
                ucBtn_set.Visible = true;
            }
            else
            {
                //label6.Visible = false;
                //ucBtn_set.Visible = false;
            }
            MainColorModel.T_Temp = ucComTC.SelectedIndex;
            //if (MainColorModel.M_PageIndex > 0)
            //    _mainForm.UpdateUIStatus();
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

        #region 数据传输
        public event ComEvent.DataReceivedHandler DataReceived;
        /// <summary>
        /// 输出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(200);
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            if (MainColorModel.M_PageIndex == 2)
                ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据
            else if (MainColorModel.M_PageIndex == 3)
            {
                Thread.Sleep(200);
                string str;
                str = ComDevice.ReadExisting();
                ReDatas = Encoding.Default.GetBytes(str);
            }

            DataReceived(this, ReDatas);//输出数据

            LogHelper.WriteLog("串口 DataReceived：" + Encoding.Default.GetString(ReDatas));

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

                    LogHelper.WriteLog("串口 Send Data:" + data);
                    return true;
                }
                catch (Exception ex)
                {
                    FrmDialog.ShowDialog(this, ex.Message, "提示", true);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not open ！", "提示",true);
                //MessageBox.Show("Serial port is not open", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        #endregion
        #region 设备连接操作
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClearSelf()
        {
            if (ComDevice.IsOpen)
            {
                ComDevice.Close();
            }
        }

        public void SavePage()
        {
            MainColorModel.M_ComIndex = Uncom_port.SelectedIndex;
            MainColorModel.M_MeterType = Uncom_meter.SelectedIndex;
            MainColorModel.M_ModelType = Uncom_model.SelectedIndex;
            MainColorModel.T_Lum = ucComTL.SelectedIndex;
        }

        public void Colsei1D()
        {
            if (m_bIsOpen)
            {
                CalibrationSDK.i1dColorSDK.i1d3DeviceClose(i1d3Handle);
            }
        }
        /// <summary>
        /// 串口连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_connect_BtnClick(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                if (string.IsNullOrEmpty(Uncom_port.SelectedText))
                {
                    FrmDialog.ShowDialog(this, "The serial port is not selected or does not exist and cannot be opened！", "提示", false);
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
                    FrmDialog.ShowDialog(this, ex.Message, "提示", false);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.Text = "Close";
                _mainForm.com_status.Text = "SerialPort : " + Uncom_port.SelectedText + " is Connected";
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
                    FrmDialog.ShowDialog(this, ex.Message, "提示", false);
                    //MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.Text = "Connect";
                _mainForm.com_status.Text = "SerialPort: " + Uncom_port.SelectedText + " is Disconnected";
                //FrmTips.ShowTipsInfo(_mainForm, "SerialPort : " + Uncom_port.SelectedText + " is Close");
                FrmTips.ShowTips(_mainForm, "SerialPort: " + Uncom_port.SelectedText + " is Disconnected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                Btn_connect.ForeColor = Color.Purple;
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
        /// i1D3 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Unbt_meter_BtnClick(object sender, EventArgs e)
        {
            //FrmDialog.ShowDialog(this, "Open connect the i1D.", "提示", false);
            if (m_bIsOpen == false)
            {
                //string retlust;
                try
                {
                    CalibrationSDK.i1dColorSDK.i1d3Destroy();
                    CalibrationSDK.i1dColorSDK.i1d3Status_t tt = CalibrationSDK.i1dColorSDK.i1d3Initialize();
                    //Console.WriteLine("i1d3Initialize OK =  " + tt.ToString());
                    uint ii = CalibrationSDK.i1dColorSDK.i1d3GetNumberOfDevices();
                    if (ii == 0)
                    {
                        FrmDialog.ShowDialog(this, "   No i1d3 devices found!", "提示", false);
                        return;
                    }
                    //Console.WriteLine("count: " + ii);
                    //i1d3Handle = new IntPtr();
                    tt = CalibrationSDK.i1dColorSDK.i1d3GetDeviceHandle(0,out i1d3Handle);
                    if (tt != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
                    {
                        FrmDialog.ShowDialog(this, "   Error getting handle!" + tt.ToString(), "提示", false);
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
                        FrmDialog.ShowDialog(this, "   Error opening i1d3 !   \r   " + tt.ToString(), "提示", false);
                        return;
                    }
                    //CalibrationSDK.i1dColorSDK.i1d3DEVICE_INFO info = new CalibrationSDK.i1dColorSDK.i1d3DEVICE_INFO();
                    //tt = CalibrationSDK.i1dColorSDK.i1d3GetDeviceInfo(i1d3Handle, ref info);

                    // Display the serial number.
                    //string sn = null;
                    //Console.WriteLine("getinfo=" + tt.ToString());
                    //IntPtr ptrIn = Marshal.StringToHGlobalAnsi("text");
                    //tt = CalibrationSDK.i1dColorSDK.i1d3GetSerialNumber(i1d3Handle, ptrIn);
                    //retlust = Marshal.PtrToStringAnsi(ptrIn);
                    //Console.WriteLine("getsn===" + tt.ToString() + "=== " + retlust);

                    tt = CalibrationSDK.i1dColorSDK.i1d3SetIntegrationTime(i1d3Handle, 1.000);
                    CalibrationSDK.i1dColorSDK.i1d3SetTargetLCDTime(i1d3Handle, 0.080);

                    tt = CalibrationSDK.i1dColorSDK.i1d3SetMeasurementMode(i1d3Handle, CalibrationSDK.i1dColorSDK.i1d3MeasMode_t.i1d3MeasModeLCD);
                    //Console.WriteLine("SetModel" + tt.ToString());
                    //Console.WriteLine("Info== " + info.strFirmwareVersion +"="+ info.strProductName +"="+ info.ucIsLocked);
                }
                catch
                {
                    FrmDialog.ShowDialog(this, "   Error connect i1d3 ! ", "提示", false);
                    return;
                    //Console.WriteLine("i1d3 connect err.");
                }
                m_bIsOpen = true;
                GlobalClass.m_bIsOpen = m_bIsOpen;
                Unbt_meter.Text = "Close";
                _mainForm.meter_status.Text = "Calibration : i1D3 is Connected ";
                FrmTips.ShowTipsInfo(_mainForm, "Calibration : i1D3 is Connected");
                //FrmTips.ShowTips(_mainForm, "Calibration : i1D3 is Connected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 70), TipsState.Info);
                Unbt_meter.ForeColor = Color.Red;
            }
            else
            {
                CalibrationSDK.i1dColorSDK.i1d3DeviceClose(i1d3Handle);
                m_bIsOpen = false;
                GlobalClass.m_bIsOpen = m_bIsOpen;
                Unbt_meter.Text = "Connect";
                _mainForm.meter_status.Text = "Calibration : i1D3 is Disconnected";
                FrmTips.ShowTipsInfo(_mainForm, "Calibration : i1D3 is Disconnected");
                //FrmTips.ShowTips(_mainForm, "Calibration : i1D3 is Disconnected", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 70), TipsState.Info);
                Unbt_meter.ForeColor = Color.Purple;
            }
        }
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
                MainColorModel.T_Custom = setModel.T_Custom;
                MainColorModel.T_Gamma = setModel.T_Gamma;
                MainColorModel.T_Temp = setModel.T_Temp;
                MainColorModel.T_Lum = setModel.T_Lum;
                MainColorModel.T_ID = setModel.T_ID;
                //MainColorModel.T_ColorTemp = setModel.T_ColorTempStd;
                //Console.WriteLine(MainColorModel.H_Row + ":" + MainColorModel.V_Colu);
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
        #endregion

    }
}
