using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;
using Color_Calibration.ComLib;

namespace Color_Calibration.UnPages
{
    public partial class UnColorForm : UserControl
    {
        List<object> lstSource = new List<object>();
        private List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
        public event ComLib.ComEvent.DataSendHandler DataSend;
        public UnColorForm()
        {
            InitializeComponent();
        }

        private void UnColorForm_Load(object sender, EventArgs e)
        {
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "ID", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Backlight", HeadText = "Backlight", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "RGain", HeadText = "R Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "GGain", HeadText = "G Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "BGain", HeadText = "B Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Lum", HeadText = "Luminance", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "xValue", HeadText = " X ", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "yValue", HeadText = " Y ", Width = 50, WidthType = SizeType.Percent });
            this.ucDataGridView_result.Columns = lstCulumns;
            this.ucDataGridView_result.IsShowCheckBox = false;
            for (int i = 0; i < 5; i++)
            {
                ColorGaridModel model = new ColorGaridModel()
                {
                    ID = i.ToString(),
                    Backlight = "100",
                    RGain = "128",
                    GGain = "128",
                    BGain = "128",
                    Lum = "80",
                    xValue = "0.285",
                    yValue = "0.293",
                };
                lstSource.Add(model);
            }

            UCPagerControl2 page = new UCPagerControl2();
            page.Width = 34;
            page.DataSource = lstSource;
            this.ucDataGridView_result.Page = page;
            this.ucDataGridView_result.First();
            
        }

        private void ucCheckBox_out_CheckedChangeEvent(object sender, EventArgs e)
        {
            if(ucCheckBox_out.Checked)
            {
                ucDataGridView_result.Columns[5].isVisible = false;
                ucDataGridView_result.Columns[6].isVisible = false;
                ucDataGridView_result.Columns[7].isVisible = false;
            }
            else
            {
                ucDataGridView_result.Columns[5].isVisible = true;
                ucDataGridView_result.Columns[6].isVisible = true;
                ucDataGridView_result.Columns[7].isVisible = true;
            }
            ucDataGridView_result.ReloadSource();
        }
    }
}
