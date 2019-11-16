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
        public IDSetForm(int row,int colu)
        {
            InitializeComponent();

            
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
            if(ucStep_set.StepIndex == 0)
                ucStep_set.StepIndex = 1;
        }

        private void ucBtn_setid_BtnClick(object sender, EventArgs e)
        {
            if (ucStep_set.StepIndex == 1)
                ucStep_set.StepIndex = 2;
        }

        private void ucSwitch_id_Click(object sender, EventArgs e)
        {
            if (ucStep_set.StepIndex == 2)
                ucStep_set.StepIndex = 3;
        }

        private void ucBtnImg1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
