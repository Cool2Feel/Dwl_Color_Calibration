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
    public partial class Form_Waiting : FrmBase
    {
        /// <summary>
        /// Gets or sets the MSG.
        /// </summary>
        /// <value>The MSG.</value>
        public string Msg { get { return label2.Text; } set { label2.Text = value; } }
        public string Msg2 { get { return label1.Text; } set { label1.Text = value; } }
        public int SetTime
        {
            get { return Time; }
            set
            {
                Time = value;
            }
        }
        
        public Form_Waiting()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            base.Opacity = 1.0;
            this.timer2.Enabled = false;
        }
        private static int Time = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Time > 0)
            {
                if(Time >= 10)
                    ucledNums1.Value = Time.ToString();
                else
                    ucledNums1.Value = " " + Time.ToString();
                Time -= 1;
                //Console.WriteLine("===111");
            }
            else
            {
                timer1.Enabled = false;
                Time = 10;
                this.Hide();
            }
        }

        /// <summary>
        /// Shows the form.
        /// </summary>
        /// <param name="intSleep">The int sleep.</param>
        public void ShowForm(int intSleep = 1)
        {
            base.Opacity = 0.0;
            if (intSleep <= 0)
            {
                intSleep = 1;
            }
            ucledNums1.Value = Time.ToString();
            base.Show();
            timer1.Interval = 1200;
            timer1.Enabled = true;
            this.timer2.Interval = intSleep;
            this.timer2.Enabled = true;
        }


        public void Stop()
        {
            base.Hide();
            timer1.Enabled = false;
            Time = 0;
        }
    }
}
