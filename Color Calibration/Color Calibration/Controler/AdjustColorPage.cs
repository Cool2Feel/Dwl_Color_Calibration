using Color_Calibration.ComLib;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Color_Calibration.Control
{
    public partial class AdjustColorPage : FrmBase
    {
        #region 局部变量
        public event ComLib.ComEvent.DataSendHandler DataSend;
        private Thread myThread = null;
        private byte Index = 1;
        private int B_R = 128;
        private int B_G = 128;
        private int B_B = 128;
        private int O_R = 128;
        private int O_G = 128;
        private int O_B = 128;
        private int Lum = 50;
        private int Conrast = 50;
        private int Saturation = 50;
        private int BlackL = 100;
        private int Clarity = 50;
        private bool do_run = false;
        #endregion
        public AdjustColorPage()
        {
            InitializeComponent();
            
            Uncom_id.Source = MainColorModel.Id_List;
            Uncom_id.SelectedIndex = 0;
            if (Uncom_id.Source.Count > 0)
                Index = 1;

            if (MainColorModel.M_ModelType == 1)
                Index = byte.Parse(Uncom_id.SelectedValue);
            else
                Index = 0xFD;
        }
        
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

        public void DataReceived(string data)
        {
            if (data.Length > 0)
            {
                string str = data;
                if (str.Contains("COLOR_BALANCE"))
                {
                    Init_Data1(str);
                    //Str += str;
                    //Console.Write(str);
                }
                if (str.Contains("COLOR_DATA"))
                {
                    Init_Data2(str);
                }
            }
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
                        
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            do_run = false;
                            ucTrack_r.Value = B_R;
                            ucTrack_g.Value = B_G;
                            ucTrack_b.Value = B_B;
                            ucTrack_ro.Value = O_R;
                            ucTrack_go.Value = O_G;
                            ucTrack_bo.Value = O_B;
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
                            ucTrack_br.Value = Lum;
                            ucTrack_con.Value = Conrast;
                            ucTrack_sa.Value = Saturation;
                            ucTrack_cl.Value = Clarity;
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

        #region Track Changed
        #region Backlight Track
        private void ucTrack_bl_ValueChanged(object sender, EventArgs e)
        {
            label_bl.Text = ucTrack_bl.Value.ToString();
            Console.WriteLine(do_run);
            if (do_run)
                Adjust_Value((byte)98, byte.Parse(ucTrack_bl.Value.ToString()));
        }

        private void ucTrack_bl_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)98, byte.Parse(ucTrack_bl.Value.ToString()));
        }
        #endregion

        #region 亮度Track
        private void ucTrack_br_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)96, byte.Parse(ucTrack_br.Value.ToString()));
        }

        private void ucTrack_br_ValueChanged(object sender, EventArgs e)
        {
            label_br.Text = ucTrack_br.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)96, byte.Parse(ucTrack_br.Value.ToString()));
        }
        #endregion
        #region 对比度Track
        private void ucTrack_con_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)97, byte.Parse(ucTrack_con.Value.ToString()));
        }

        private void ucTrack_con_ValueChanged(object sender, EventArgs e)
        {
            label_con.Text = ucTrack_con.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)97, byte.Parse(ucTrack_con.Value.ToString()));
        }
        #endregion
        #region 饱和度Track
        private void ucTrack_sa_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)99, byte.Parse(ucTrack_sa.Value.ToString()));
        }

        private void ucTrack_sa_ValueChanged(object sender, EventArgs e)
        {
            label_sa.Text = ucTrack_sa.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)99, byte.Parse(ucTrack_sa.Value.ToString()));
        }
        #endregion
        #region 清晰度Track
        private void ucTrack_cl_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)106, byte.Parse(ucTrack_cl.Value.ToString()));
        }

        private void ucTrack_cl_ValueChanged(object sender, EventArgs e)
        {
            label_cl.Text = ucTrack_cl.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)106, byte.Parse(ucTrack_cl.Value.ToString()));
        }
        #endregion

        #region red gain Track
        private void ucTrack_r_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)100, byte.Parse(ucTrack_r.Value.ToString()));
        }

        private void ucTrack_r_ValueChanged(object sender, EventArgs e)
        {
            label_r.Text = ucTrack_r.Value.ToString();
            if (do_run)
                Adjust_Value((byte)100, byte.Parse(label_r.Text));
        }
        #endregion
        #region green gain Track
        private void ucTrack_g_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)101, byte.Parse(ucTrack_g.Value.ToString()));
        }

        private void ucTrack_g_ValueChanged(object sender, EventArgs e)
        {
            label_g.Text = ucTrack_g.Value.ToString();
            if (do_run)
                Adjust_Value((byte)101, byte.Parse(label_g.Text));
        }
        #endregion
        #region blue gain Track
        private void ucTrack_b_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)102, byte.Parse(ucTrack_b.Value.ToString()));
        }

        private void ucTrack_b_ValueChanged(object sender, EventArgs e)
        {
            label_b.Text = ucTrack_b.Value.ToString();
            if (do_run)
                Adjust_Value((byte)102, byte.Parse(label_b.Text));
        }
        #endregion
        #region red gain offset Track
        private void ucTrack_ro_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)103, byte.Parse(ucTrack_ro.Value.ToString()));

        }

        private void ucTrack_ro_ValueChanged(object sender, EventArgs e)
        {
            label_ro.Text = ucTrack_ro.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)103, byte.Parse(ucTrack_ro.Value.ToString()));
        }
        #endregion
        #region green gain offset Track
        private void ucTrack_go_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)104, byte.Parse(ucTrack_go.Value.ToString()));
        }

        private void ucTrack_go_ValueChanged(object sender, EventArgs e)
        {
            label_go.Text = ucTrack_go.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)104, byte.Parse(ucTrack_go.Value.ToString()));
        }
        #endregion
        #region blue gain offset Track
        private void ucTrack_bo_MouseUp(object sender, MouseEventArgs e)
        {
            Thread.Sleep(200);
            Adjust_Value((byte)105, byte.Parse(ucTrack_bo.Value.ToString()));
        }

        private void ucTrack_bo_ValueChanged(object sender, EventArgs e)
        {
            label_bo.Text = ucTrack_bo.Value.ToString();
            //Console.WriteLine(ucTrack_bl.Value.ToString());
            if (do_run)
                Adjust_Value((byte)105, byte.Parse(ucTrack_bo.Value.ToString()));
        }
        #endregion
        #endregion
        
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
            lbl_MouseDown(sender);
            ucTrack_bl.Value = Math.Min(ucTrack_bl.Value + 1, 100);
        }

        private void lblBl_add_MouseEnter(object sender, EventArgs e)
        {
            lbl_MouseEnter(sender);
        }

        private void lblBl_add_MouseLeave(object sender, EventArgs e)
        {
            lbl_MouseLeave(sender);
        }

        private void lblBl_add_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_MouseUp(sender);
            do_run = false;
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

        private void lblBR_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_br.Value = Math.Max(ucTrack_br.Value - 1, 0);
        }

        private void lblSA_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_sa.Value = Math.Max(ucTrack_sa.Value - 1, 0);
        }

        private void lblCl_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_cl.Value = Math.Max(ucTrack_cl.Value - 1, 0);
        }

        private void lblRO_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_ro.Value = Math.Max(ucTrack_ro.Value - 1, 0);
        }

        private void lblGO_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_go.Value = Math.Max(ucTrack_go.Value - 1, 0);
        }

        private void lblBO_down_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_bo.Value = Math.Max(ucTrack_bo.Value - 1, 0);
        }

        private void lblCON_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_con.Value = Math.Min(ucTrack_con.Value + 1, 100);
        }

        private void lblBR_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_br.Value = Math.Min(ucTrack_br.Value + 1, 100);
        }

        private void lblSA_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_sa.Value = Math.Min(ucTrack_sa.Value + 1, 100);
        }

        private void lblCL_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_cl.Value = Math.Min(ucTrack_cl.Value + 1, 100);
        }

        private void lblRO_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_ro.Value = Math.Min(ucTrack_ro.Value + 1, 255);
        }

        private void lblGO_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_go.Value = Math.Min(ucTrack_go.Value + 1, 255);
        }

        private void lblBO_add_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_MouseDown(sender);
            ucTrack_bo.Value = Math.Min(ucTrack_bo.Value + 1, 255);
        }
        #endregion

        private void Init_Thread()
        {
            ColorBelance_get1();
            Thread.Sleep(500);
            ColorBelance_get2();
        }
        private void ucBtn_refresh_Click(object sender, EventArgs e)
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

        private void ucBtnImg1_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdjustColorPage_MouseMove(object sender, MouseEventArgs e)
        {
            FormMove.MoveForm(this);
        }
    }
}
