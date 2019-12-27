using Color_Calibration.UnPages;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration
{
    public partial class IDSetForm : FrmBase
    {
        private UnSetForm _mainform;
        private int rowsCount;
        private int colsCount;
        public IDSetForm(UnSetForm f ,int row,int colu)
        {
            InitializeComponent();

            _mainform = f;
            rowsCount = row;
            colsCount = colu;
            List<KeyValuePair<string, string>> row_dit = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, string>> colu_dit = new List<KeyValuePair<string, string>>();
            
            for (int i=1; i <= row; i++)
            {
                row_dit.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString()));
            }
            for (int i = 1; i <= colu; i++)
            {
                colu_dit.Add(new KeyValuePair<string, string>(i.ToString(), i.ToString()));
            }
            ucComHM.Source = row_dit;
            ucComVM.Source = colu_dit;
            ucComHM.SelectedIndex = 0;
            ucComVM.SelectedIndex = 0;
        }

        private void ucSwitch_sn_Click(object sender, EventArgs e)
        {
            if (ucSwitch_sn.Checked)
            {
                if (!Send_SN(true))
                    ucSwitch_sn.Checked = false;
                else
                {
                    if (ucStep_set.StepIndex == 0)
                        ucStep_set.StepIndex = 1;
                }
            }
            else
            {
                if (!Send_SN(false))
                    ucSwitch_sn.Checked = true;
            }

        }

        private void ucSwitch_id_Click(object sender, EventArgs e)
        {
            if (ucSwitch_id.Checked)
            {
                if (!Send_ID(true))
                    ucSwitch_id.Checked = false;
                else
                {
                    if (ucStep_set.StepIndex == 2)
                        ucStep_set.StepIndex = 3;
                }
            }
            else
            {
                if (!Send_ID(false))
                    ucSwitch_id.Checked = true;
            }
        }

        private void ucBtnImg1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool New_adress(uint A_0, byte A_1)//通过屏幕的序号来设置对应屏幕的地址----指令
        {
            byte[] array = new byte[11];
            array[0] = 0xEB;
            array[1] = 0xFD;
            array[2] = 0x20;
            array[3] = 0x13;
            array[4] = (byte)(A_0 >> 16);
            array[5] = (byte)(A_0 >> 8);
            array[6] = (byte)A_0;
            array[7] = A_1;
            array[8] = (byte)colsCount;
            array[9] = (byte)rowsCount;
            array[10] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3] + array[4] + array[5] + array[6] + array[7] + array[8] + array[9]));
            try
            {
                //serialPort1.Write(array, 0, 11);
                return _mainform.SendData(array);

            }
            catch
            {
                FrmDialog.ShowDialog(this, "ID 地址修改出错！", "提示", false);
                return false;
            }
        }
        /// <summary>
        /// 屏幕序号的查看指令
        /// </summary>
        /// <param name="A_0"></param>
        private bool Send_SN(bool A_0)// 屏幕序号的显示指令
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = 0xFD;
            array[2] = 0x20;
            if (A_0)
                array[3] = 0x23;//显示
            else
                array[3] = 0x24;
            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
            try
            {
                //serialPort1.Write(array, 0, 5);
                return _mainform.SendData(array);
            }
            catch
            {
                FrmDialog.ShowDialog(this, "显示屏幕序列号（SN）出错！", "提示", false);
                return false;
            }
        }
        /// <summary>
        /// 屏幕地址的查看指令
        /// </summary>
        /// <param name="A_0"></param>
        private bool Send_ID(bool A_0)//  屏幕的地址显示指令
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = 0xFD;
            array[2] = 0x20;
            if (A_0)
                array[3] = 0x21;
            else
                array[3] = 0x22;

            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
            try
            {
                //serialPort1.Write(array, 0, 5);
                return _mainform.SendData(array);
            }
            catch
            {
                FrmDialog.ShowDialog(this, "设置屏幕地址（ID）出错！", "提示", false);
                return false;
            }
        }
        /// <summary>
        /// set id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_setid_Click(object sender, EventArgs e)
        {
            uint sn = (uint)ucNum_SN.Num;
            byte id = (byte)(int.Parse(ucComVM.TextValue) + (int.Parse(ucComHM.TextValue) - 1) * colsCount);

            if (FrmDialog.ShowDialog(this, " ID设置 【" + "H Moniters:  " + ucComHM.TextValue + "       V Moniters:  " + ucComVM.TextValue + " 】\r                     屏幕地址（ID）= " + id, "提示", true) == DialogResult.Cancel)
                return;
            if (New_adress(sn, id))
            {
                if (ucStep_set.StepIndex == 1)
                    ucStep_set.StepIndex = 2;
            }
            //Console.WriteLine(sn + "==" + id);
        }
    }
}
