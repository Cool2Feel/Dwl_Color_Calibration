using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Color_Calibration.ComLib;
using Color_Calibration.UnPages;
using HZH_Controls.Forms;

namespace WallControl
{
    public partial class Form_UartIrCmd_3458 : FrmBase
    {
        private int count;
        //private UnControlForm mf;
        public event Color_Calibration.ComLib.ComEvent.DataSendHandler DataSend;
        //private bool port_flag = false;
        //AutoSizeFormClass asc = new AutoSizeFormClass(); 
        public Form_UartIrCmd_3458(int count)
        {
            InitializeComponent();
            //this.mf = f;
            this.count = count;
            timer1.Interval = 100 * count + 300;
            timer1.Start();
        }
        
        private void Send_Control(byte A_0)
        {
            try
            {
                byte[] array = new byte[5];
                array[0] = 0xE5;
                array[2] = 0x20;
                array[3] = A_0;
                for (int i = 0; i < count; i++)
                {
                    if (GlobalClass.select_address[i] != 0)
                    {
                        array[1] = GlobalClass.select_address[i];
                        array[4] = (byte)(255 - (255 & array[0] + array[1] + array[2] + array[3]));
                        //Console.WriteLine("array[1] = " + array[1]);
                        if (GlobalClass.c_bIsOpen)
                        {
                            //serialPort1.Write(array, 0, 5);
                            DataSend(array);
                        }
                        else
                        {
                            FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                            return;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void Set_Enable(Button b, bool f)
        {
            b.Enabled = f;
            //Cursor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC9);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB9);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBA);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBB);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBC);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBD);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBE);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xBF);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC1);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC7);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC8);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB2);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB4);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB5);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB3);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC4);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC5);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC6);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xC3);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB6);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB0);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xB8);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control b in this.Controls)
            {
                if (!b.Enabled)
                {
                    b.Enabled = true;
                    b.Focus();
                }
            }
            //Cursor.Show();
        }
        
        private void Form_UartIrCmd_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xDD);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xDC);
        }

        private void Form_UartIrCmd_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this); 
        }

        private void Form_UartIrCmd_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xE0);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xDB);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Set_Enable(sender as Button, false);
            Send_Control((byte)0xD9);
        }
        
        private void Form_UartIrCmd_3458_MouseMove(object sender, MouseEventArgs e)
        {
            FormMove.MoveForm(this);
        }

        private void ucBtnImg1_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
