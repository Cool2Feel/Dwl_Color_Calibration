using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration.UnPages
{
    public partial class UnAdjustForm : UserControl
    {
        public event ComLib.ComEvent.DataSendHandler DataSend;
        public UnAdjustForm()
        {
            InitializeComponent();
        }

        private void ucTrack_bl_ValueChanged(object sender, EventArgs e)
        {
            label_bl.Text = ucTrack_bl.Value.ToString();
        }

        private void ucTrack_r_ValueChanged(object sender, EventArgs e)
        {
            label_r.Text = ucTrack_r.Value.ToString();
        }

        private void ucTrack_g_ValueChanged(object sender, EventArgs e)
        {
            label_g.Text = ucTrack_g.Value.ToString();
        }

        private void ucTrack_b_ValueChanged(object sender, EventArgs e)
        {
            label_b.Text = ucTrack_b.Value.ToString();
        }
    }
}
