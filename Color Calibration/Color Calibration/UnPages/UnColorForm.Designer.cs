namespace Color_Calibration.UnPages
{
    partial class UnColorForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_cm = new System.Windows.Forms.Label();
            this.ucCheckBox_out = new HZH_Controls.Controls.UCCheckBox();
            this.ucDataGridView_result = new HZH_Controls.Controls.UCDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucBtn_save = new EASkins.Ami_Button_1();
            this.ucBtn_clear = new EASkins.Ami_Button_1();
            this.ucBtn_Execute = new EASkins.Ami_Button_1();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_cm
            // 
            this.label_cm.AutoSize = true;
            this.label_cm.BackColor = System.Drawing.Color.Transparent;
            this.label_cm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cm.Location = new System.Drawing.Point(15, 219);
            this.label_cm.Name = "label_cm";
            this.label_cm.Size = new System.Drawing.Size(133, 19);
            this.label_cm.TabIndex = 6;
            this.label_cm.Text = "Calibration Result";
            // 
            // ucCheckBox_out
            // 
            this.ucCheckBox_out.BackColor = System.Drawing.Color.Transparent;
            this.ucCheckBox_out.Checked = false;
            this.ucCheckBox_out.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucCheckBox_out.Location = new System.Drawing.Point(166, 213);
            this.ucCheckBox_out.Name = "ucCheckBox_out";
            this.ucCheckBox_out.Padding = new System.Windows.Forms.Padding(1);
            this.ucCheckBox_out.Size = new System.Drawing.Size(171, 30);
            this.ucCheckBox_out.TabIndex = 7;
            this.ucCheckBox_out.TextValue = "Outcome Measures";
            this.ucCheckBox_out.Visible = false;
            this.ucCheckBox_out.CheckedChangeEvent += new System.EventHandler(this.ucCheckBox_out_CheckedChangeEvent);
            // 
            // ucDataGridView_result
            // 
            this.ucDataGridView_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDataGridView_result.AutoRowsScroll = true;
            this.ucDataGridView_result.BackColor = System.Drawing.Color.White;
            this.ucDataGridView_result.Columns = null;
            this.ucDataGridView_result.DataSource = null;
            this.ucDataGridView_result.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucDataGridView_result.HeadHeight = 26;
            this.ucDataGridView_result.HeadPadingLeft = 0;
            this.ucDataGridView_result.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView_result.IsCloseAutoHeight = false;
            this.ucDataGridView_result.IsShowCheckBox = false;
            this.ucDataGridView_result.IsShowHead = true;
            this.ucDataGridView_result.Location = new System.Drawing.Point(16, 244);
            this.ucDataGridView_result.Name = "ucDataGridView_result";
            this.ucDataGridView_result.Page = null;
            this.ucDataGridView_result.RowHeight = 22;
            this.ucDataGridView_result.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView_result.Size = new System.Drawing.Size(882, 134);
            this.ucDataGridView_result.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(62, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 44);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(810, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Put the sensor on monitor : ID 1 , and then click the Execute button.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucBtn_save
            // 
            this.ucBtn_save.BackColor = System.Drawing.Color.Transparent;
            this.ucBtn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBtn_save.Image = null;
            this.ucBtn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucBtn_save.Location = new System.Drawing.Point(734, 213);
            this.ucBtn_save.Name = "ucBtn_save";
            this.ucBtn_save.Size = new System.Drawing.Size(76, 28);
            this.ucBtn_save.TabIndex = 66;
            this.ucBtn_save.Text = "Save";
            this.ucBtn_save.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ucBtn_save.Click += new System.EventHandler(this.ucBtn_save_Click);
            // 
            // ucBtn_clear
            // 
            this.ucBtn_clear.BackColor = System.Drawing.Color.Transparent;
            this.ucBtn_clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBtn_clear.Image = null;
            this.ucBtn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucBtn_clear.Location = new System.Drawing.Point(822, 213);
            this.ucBtn_clear.Name = "ucBtn_clear";
            this.ucBtn_clear.Size = new System.Drawing.Size(76, 28);
            this.ucBtn_clear.TabIndex = 67;
            this.ucBtn_clear.Text = "Clear";
            this.ucBtn_clear.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ucBtn_clear.Click += new System.EventHandler(this.ucBtn_clear_BtnClick);
            // 
            // ucBtn_Execute
            // 
            this.ucBtn_Execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtn_Execute.BackColor = System.Drawing.Color.Transparent;
            this.ucBtn_Execute.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBtn_Execute.Image = null;
            this.ucBtn_Execute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucBtn_Execute.Location = new System.Drawing.Point(788, 18);
            this.ucBtn_Execute.Name = "ucBtn_Execute";
            this.ucBtn_Execute.Size = new System.Drawing.Size(110, 33);
            this.ucBtn_Execute.TabIndex = 68;
            this.ucBtn_Execute.Text = "Execute";
            this.ucBtn_Execute.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ucBtn_Execute.Click += new System.EventHandler(this.ucBtn_Execute_BtnClick);
            // 
            // UnColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Color_Calibration.Properties.Resources.mainLogo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ucBtn_Execute);
            this.Controls.Add(this.ucBtn_clear);
            this.Controls.Add(this.ucBtn_save);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucCheckBox_out);
            this.Controls.Add(this.label_cm);
            this.Controls.Add(this.ucDataGridView_result);
            this.Name = "UnColorForm";
            this.Size = new System.Drawing.Size(915, 411);
            this.Load += new System.EventHandler(this.UnColorForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCDataGridView ucDataGridView_result;
        private System.Windows.Forms.Label label_cm;
        private HZH_Controls.Controls.UCCheckBox ucCheckBox_out;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private EASkins.Ami_Button_1 ucBtn_save;
        private EASkins.Ami_Button_1 ucBtn_clear;
        private EASkins.Ami_Button_1 ucBtn_Execute;
    }
}
