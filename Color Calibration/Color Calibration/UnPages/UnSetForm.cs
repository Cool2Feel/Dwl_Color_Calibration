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

namespace Color_Calibration.UnPages
{
    public partial class UnSetForm : UserControl
    {
        private SerialPort ComDevice = new SerialPort();
        List<KeyValuePair<string, string>> dit = new List<KeyValuePair<string, string>>();
        public UnSetForm()
        {
            InitializeComponent();
            #region 界面初始化
            InitComPort();
            dit.Clear();
            int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13, 14 ,15 };
            foreach (int element in num)
            {
                dit.Add(new KeyValuePair<string, string>(element.ToString(), element.ToString()));
            }
            ucComHM.Source = dit;
            ucComVM.Source = dit;
            ucComHM.SelectedIndex = 0;
            ucComVM.SelectedIndex = 0;

            List<KeyValuePair<string, string>> dit_gamma = new List<KeyValuePair<string, string>>();
            dit_gamma.Add(new KeyValuePair<string, string>("1", "GAMMA 2.2"));
            dit_gamma.Add(new KeyValuePair<string, string>("2", "GAMMA 1.0"));
            ucComTG.Source = dit_gamma;
            ucComTG.SelectedIndex = 0;

            List<KeyValuePair<string, string>> dit_temp = new List<KeyValuePair<string, string>>();
            dit_temp.Add(new KeyValuePair<string, string>("1", "Cool "));
            dit_temp.Add(new KeyValuePair<string, string>("2", "NORMAL"));
            dit_temp.Add(new KeyValuePair<string, string>("3", "WARM "));
            dit_temp.Add(new KeyValuePair<string, string>("4", "CUSTOM"));
            ucComTC.Source = dit_temp;
            ucComTC.SelectedIndex = 3;

            List<KeyValuePair<string, string>> dit_lum = new List<KeyValuePair<string, string>>();
            dit_lum.Add(new KeyValuePair<string, string>("1", "AUTOMTIC"));
            dit_lum.Add(new KeyValuePair<string, string>("2", "OTHER"));
            ucComTL.Source = dit_lum;
            ucComTL.SelectedIndex = 0;
            #endregion
        }

        private void InitComPort()
        {
            string[] drpComList = SerialPort.GetPortNames().Distinct().ToArray();
            List<KeyValuePair<string, string>> dit_port = new List<KeyValuePair<string, string>>();
            if (drpComList.Length > 0)
            {
                for (int i = 1; i <= drpComList.Length; i++)
                {
                    dit_port.Add(new KeyValuePair<string, string>(i.ToString(), drpComList[i-1]));
                }
                Uncom_port.Source = dit_port;
                Uncom_port.SelectedIndex = 0;
            }
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);

            List<KeyValuePair<string, string>> dit_meter = new List<KeyValuePair<string, string>>();
            dit_meter.Add(new KeyValuePair<string, string>("1", "CA310"));
            dit_meter.Add(new KeyValuePair<string, string>("2", "X-rite i1D3"));
            Uncom_meter.Source = dit_meter;
            Uncom_meter.SelectedIndex = 0;

            List<KeyValuePair<string, string>> dit_model = new List<KeyValuePair<string, string>>();
            dit_model.Add(new KeyValuePair<string, string>("1", "监视器"));
            dit_model.Add(new KeyValuePair<string, string>("2", "拼接屏"));
            Uncom_model.Source = dit_model;
            Uncom_model.SelectedIndex = 0;
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
                label6.Visible = false;
                ucBtn_set.Visible = false;
            }
        }

        private void ucBtn_set_BtnClick(object sender, EventArgs e)
        {
            new ColorForm().ShowDialog();
        }

        public event ComEvent.DataReceivedHandler DataReceived;
        /// <summary>
        /// 输出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);//读取数据
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
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Serial port is not open", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

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

        private void Btn_connect_BtnClick(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                if (string.IsNullOrEmpty(Uncom_port.SelectedText))
                {
                    MessageBox.Show("The serial port is not selected or does not exist and cannot be opened！", "Tips");
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
                        MessageBox.Show("Serial port cannot be opened！", "Tips");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.BtnText = "Close";
            }
            else
            {
                try
                {
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LogHelper.WriteLog(Btn_connect.Text);
                Btn_connect.BtnText = "Connect";
            }

            Uncom_port.Enabled = !ComDevice.IsOpen;
        }

        private void ucBtn_id_BtnClick(object sender, EventArgs e)
        {
            int row = int.Parse(ucComHM.SelectedText);
            int colu = int.Parse(ucComVM.SelectedText);
            new IDSetForm(row,colu).ShowDialog();
        }
    }
}
