using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Color_Calibration.ComLib;
using System.Threading;
using HZH_Controls.Forms;
using HZH_Controls.Controls;

namespace Color_Calibration.UnPages
{
    public partial class UnAdjustForm : UserControl
    {
        #region 局部变量
        public event ComLib.ComEvent.DataSendHandler DataSend;
        private Thread myThread = null;
        private byte Index = 1;
        private int B_R = 128;
        private int B_G = 128;
        private int B_B = 128;
        private int Lum = 50;
        private int Conrast = 50;
        private int Saturation = 50;
        private int BlackL = 100;
        private int Clarity = 50;
        private bool do_run = false;
        #endregion
        public UnAdjustForm()
        {
            InitializeComponent();
            Uncom_id.Source = MainColorModel.Id_List;
            Uncom_id.SelectedIndex = 0;
            if(Uncom_id.Source.Count > 0)
                Index = 1;

            if (MainColorModel.M_ModelType == 1)
                Index = byte.Parse(Uncom_id.SelectedValue);
            else
                Index = 0xFD;
        }

        public void Data_Update()
        {
            Uncom_id.Source = MainColorModel.Id_List;
            Uncom_id.SelectedIndex = 0;
            if (Uncom_id.Source.Count > 0)
                Index = 1;
            if (MainColorModel.H_Row > 8 && MainColorModel.V_Colu > 8)
                Uncom_id.DropPanelHeight = 550;
            else
                Uncom_id.DropPanelHeight = (MainColorModel.H_Row + MainColorModel.V_Colu) * 10;
        }
        public void DataReceived(byte[] data)
        {
            try
            {
                if (data.Length > 0)
                {
                    string str = Encoding.Default.GetString(data);
                    if (str.Contains("COLOR_BALANCE"))
                    {
                        Init_Data1(str);
                        //Str += str;
                        //Console.Write(str);
                    }
                    if(str.Contains("COLOR_DATA"))
                    {
                        Init_Data2(str);
                    }
                    Console.Write("adjustpage:" + str);
                }
                //Console.Write(str);
            }
            catch
            {

            }
        }

        #region Track Changed
        private void ucTrack_bl_ValueChanged(object sender, EventArgs e)
        {
            label_bl.Text = ucTrack_bl.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if(do_run)
                Adjust_Value((byte)98, byte.Parse(ucTrack_bl.Value.ToString()));

        }

        private void ucTrack_r_ValueChanged(object sender, EventArgs e)
        {
            label_r.Text = ucTrack_r.Value.ToString();
            if (do_run)
                Adjust_Value((byte)100, byte.Parse(label_r.Text));
        }

        private void ucTrack_g_ValueChanged(object sender, EventArgs e)
        {
            label_g.Text = ucTrack_g.Value.ToString();
            if (do_run)
                Adjust_Value((byte)101, byte.Parse(label_g.Text));
        }

        private void ucTrack_b_ValueChanged(object sender, EventArgs e)
        {
            label_b.Text = ucTrack_b.Value.ToString();
            if (do_run)
                Adjust_Value((byte)102, byte.Parse(label_b.Text));
        }
        #endregion
        private void Uncom_id_SelectedChangedEvent(object sender, EventArgs e)
        {
            //if (Uncom_id.SelectedText != null)
                //Index = byte.Parse(Uncom_id.SelectedText);
        }


        #region  Lable_Mouse function
        private void lbl_MouseDown(object sender)
        {
            do_run = true;
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
        private void lblBl_add_MouseDown(object sender, MouseEventArgs e)
        {
            //lblBl_add.Image = Color_Calibration.Properties.Resources.btn2_Dwn;
            //lblBl_add.Location = new Point(lblBl_add.Location.X + 1, lblBl_add.Location.Y + 1);
            lbl_MouseDown(sender);
            ucTrack_bl.Value = Math.Min(ucTrack_bl.Value + 1, 100);
        }

        private void lblBl_add_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(sender);
            //lblBl_add.Image = Color_Calibration.Properties.Resources.btn2_Ent;
        }

        private void lblBl_add_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(sender);
            //lblBl_add.Image = null;
        }

        private void lblBl_add_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_MouseUp(sender);
            do_run = false;
            //lblBl_add.Location = new Point(lblBl_add.Location.X - 1, lblBl_add.Location.Y - 1);
        }

        private void lblBl_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_bl.Value = Math.Max(ucTrack_bl.Value - 1, 0);
        }

        private void lblRg_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_r.Value = Math.Min(ucTrack_r.Value + 1, 255);
        }

        private void lblRg_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_r.Value = Math.Max(ucTrack_r.Value - 1, 0);
        }

        private void lblGg_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_g.Value = Math.Min(ucTrack_g.Value + 1, 255);
        }

        private void lblGg_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_g.Value = Math.Max(ucTrack_g.Value - 1, 0);
        }

        private void lblBg_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_b.Value = Math.Min(ucTrack_b.Value + 1, 255);
        }

        private void lblBg_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_b.Value = Math.Max(ucTrack_b.Value - 1, 0);
        }
        #endregion


        /// <summary>
        /// set value api
        /// </summary>
        /// <param name="A_0"></param>
        /// <param name="A_1"></param>
        private void Adjust_Value(byte A_0, byte A_1)
        {
            byte[] array = new byte[8];
            array[0] = 0xE8;
            array[1] = Index;
            array[2] = 0x20;
            array[3] = A_0;
            array[4] = 0x0;
            array[5] = A_1;
            array[6] = 0x0;
            array[7] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3] + array[5]));

            try
            {
                //serialPort1.Write(array, 0, 6);
                DataSend(array);
                do_run = false;
            }
            catch
            {
                FrmDialog.ShowDialog(this, "     Error sending data from serial port！", "Tips", false);
                return;
            }

        }

        /// <summary>
        /// get RBG BL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtn_get_Click(object sender, EventArgs e)
        {
            if (GlobalClass.c_bIsOpen)
            {
                Index = byte.Parse(Uncom_id.SelectedValue);
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    Init_Thread();
                })); //开线程         
                myThread.Start(); //启动线程 
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not opened！", "Tips", false);
            }
        }
        
        private void Init_Thread()
        {
            ColorBelance_get1();
            Thread.Sleep(500);
            ColorBelance_get2();
        }

        #region 获取调整数据
        public void ColorBelance_get1()
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = Index;
            array[2] = 0x20;
            array[3] = 0x88;
            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));

            try
            {
                //serialPort1.Write(array, 0, 5);
                DataSend(array);

            }
            catch (Exception e)
            {
                return;
            }
        }
        public void ColorBelance_get2()
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = Index;
            array[2] = 0x20;
            array[3] = 0x86;
            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
            try
            {
                //serialPort1.Write(array, 0, 5);
                DataSend(array);
            }
            catch
            {
                return;
            }
        }
        private void Init_Data1(string Str)
        {
            if (Str != "")
            {
                try
                {
                    if (Str.IndexOf("COLOR_BALANCE:_", 0) >= 0 && (Str.IndexOf("_\r\n", 0) > 0 || Str.IndexOf("_\r\r\n", 0) > 0))
                    {
                        //MessageBox.Show("1receive_flag = false");
                        int num2 = Str.IndexOf("COLOR_BALANCE:_", 0) + 14;
                        int num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        B_R = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        B_G = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        B_B = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        /*
                        num2 = num3;
                        num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        O_R = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        O_G = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = Str.IndexOf("_", num2 + 1);
                        Str.Substring(num2 + 1, num3 - num2);
                        O_B = int.Parse(Str.Substring(num2 + 1, num3 - num2 - 1));
                        */
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            do_run = false;
                            ucTrack_r.Value = B_R;
                            ucTrack_g.Value = B_G;
                            ucTrack_b.Value = B_B;
                        }));
                        //Console.WriteLine("OOOOO_B=="+ O_B);
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                ColorBelance_get1();
                //return;
            }
        }

        private void Init_Data2(string str)
        {
            //Console.WriteLine("sssss=== "+str);
            if (str != "")
            {
                try
                {
                    if (str.IndexOf("COLOR_DATA:_", 0) >= 0 && (str.IndexOf("_\r\n", 0) > 0 || str.IndexOf("_\r\r\n", 0) > 0))
                    {
                        int num2 = str.IndexOf("COLOR_DATA:_", 0) + 11;
                        int num3 = str.IndexOf("_", num2 + 1);
                        str.Substring(num2 + 1, num3 - num2);
                        Lum = int.Parse(str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = str.IndexOf("_", num2 + 1);
                        str.Substring(num2 + 1, num3 - num2);
                        Conrast = int.Parse(str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = str.IndexOf("_", num2 + 1);
                        str.Substring(num2 + 1, num3 - num2);
                        BlackL = int.Parse(str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = str.IndexOf("_", num2 + 1);
                        str.Substring(num2 + 1, num3 - num2);
                        Clarity = int.Parse(str.Substring(num2 + 1, num3 - num2 - 1));
                        num2 = num3;
                        num3 = str.IndexOf("_", num2 + 1);
                        str.Substring(num2 + 1, num3 - num2);
                        Saturation = int.Parse(str.Substring(num2 + 1, num3 - num2 - 1));
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            do_run = false;
                            ucTrack_bl.Value = BlackL;
                            //Console.WriteLine(BlackL);
                        }));
                    }
                }
                catch
                {
                }
            }
            else
            {
                ColorBelance_get2();
                //return;
            }
        }

        #endregion
        /// <summary>
        /// set Default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ami_Button_12_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "   Initialize the screen color temperature data of the current ID by default！", "Tips", true) == DialogResult.OK)
            {
                byte[] array = new byte[5];
                array[0] = 0xE5;
                array[1] = Index;
                array[2] = 0x20;
                array[3] = 0x81;
                array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
                DataSend(array);
                Thread.Sleep(200);
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    Init_Thread();
                })); //开线程         
                myThread.Start(); //启动线程 
            }
        }

        #region Track MouseUp
        private void ucTrack_bl_MouseUp(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(ucTrack_bl.Value);
            Thread.Sleep(200);
            Adjust_Value((byte)98, byte.Parse(ucTrack_bl.Value.ToString()));
        }

        private void ucTrack_r_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)100, byte.Parse(ucTrack_r.Value.ToString()));
        }

        private void ucTrack_g_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)101, byte.Parse(ucTrack_g.Value.ToString()));
        }

        private void ucTrack_b_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)102, byte.Parse(ucTrack_b.Value.ToString()));
        }
        #endregion

        /// <summary>
        /// Measure Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_measure_Click(object sender, EventArgs e)
        {
            if (GlobalClass.m_bIsOpen == false)
            {
                FrmDialog.ShowDialog(this, "   Color calibration equipment is not connected ! ", "Tips", false);
                return;
            }
            try
            {
                string lv = "" ;string x = "" ;string y = "" ;
                if (MainColorModel.M_MeterType == 0)
                {
                    #region i1d3 Measure
                    IntPtr m_hi1d3 = GlobalClass.i1d3Handle;

                    //Console.WriteLine("i1d3Handle: " + m_hi1d3);

                    CalibrationSDK.i1dColorSDK.i1d3Yxy_t m_dYxyMeas = new CalibrationSDK.i1dColorSDK.i1d3Yxy_t();

                    CalibrationSDK.i1dColorSDK.i1d3Status_t m_err = CalibrationSDK.i1dColorSDK.i1d3MeasureYxy(m_hi1d3, ref m_dYxyMeas);
                    if (m_err != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
                    {
                        if (m_err == CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3ErrHW_PeriodeTimeOut)
                            FrmDialog.ShowDialog(this, "   The device measurement timed out and cannot detect the current display data (the display brightness is blank or the device lens is not punched)", "Tips", false);
                        else
                            FrmDialog.ShowDialog(this, "   Error for :" + m_err.ToString(), "Tips", false);
                        return;
                    }
                    lv = string.Format("{0:N3}", m_dYxyMeas.Y);
                    x = string.Format("{0:N3}", m_dYxyMeas.x);
                    y = string.Format("{0:N3}", m_dYxyMeas.y);
                    #endregion
                }
                else
                {
                    #region CA310/CA410
                    MeasureData _measureData = new MeasureData();
                    if (MainColorModel.M_MeterType == 1)
                        _measureData = GlobalClass._meter_CA310.GetCA310Measure_Data();
                    else
                        _measureData = GlobalClass._meter_CA410.GetCA410Measure_Data();
                    if (_measureData != null)
                    {
                        lv = string.Format("{0:N3}", _measureData.Lv);
                        x = string.Format("{0:N3}", _measureData.sx);
                        y = string.Format("{0:N3}", _measureData.sy);
                    }
                    #endregion
                }
                //Console.WriteLine("OK =" + m_dYxyMeas.Y + " - " + m_dYxyMeas.x + " - " + m_dYxyMeas.y + " - " + m_dYxyMeas.z);

                ucTextBox_lv.InputText = lv;
                ucTextBox_x.InputText = x;
                ucTextBox_y.InputText = y;
            }
            catch
            {
                FrmDialog.ShowDialog(this, "   Measure Lcd Error ! ", "Tips", false);
                return;
            }
        }

        private void ami_Button_setd_Click(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "   Initialize the screen color temperature data of the current ID by default！", "Tips", true) == DialogResult.OK)
            {
                byte[] array = new byte[5];
                array[0] = 0xE5;
                array[1] = Index;
                array[2] = 0x20;
                array[3] = 0x81;
                array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
                DataSend(array);
                Thread.Sleep(200);
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    Init_Thread();
                })); //开线程         
                myThread.Start(); //启动线程 
            }
        }
    }
}
