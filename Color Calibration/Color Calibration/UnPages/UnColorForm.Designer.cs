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
            this.ucBtn_setid = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt1 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt2 = new HZH_Controls.Controls.UCBtnExt();
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
            // ucBtn_setid
            // 
            this.ucBtn_setid.BackColor = System.Drawing.Color.White;
            this.ucBtn_setid.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_setid.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_setid.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtn_setid.BtnText = "Execute";
            this.ucBtn_setid.ConerRadius = 10;
            this.ucBtn_setid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_setid.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtn_setid.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_setid.IsRadius = true;
            this.ucBtn_setid.IsShowRect = true;
            this.ucBtn_setid.IsShowTips = false;
            this.ucBtn_setid.Location = new System.Drawing.Point(788, 71);
            this.ucBtn_setid.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_setid.Name = "ucBtn_setid";
            this.ucBtn_setid.RectColor = System.Drawing.Color.Purple;
            this.ucBtn_setid.RectWidth = 2;
            this.ucBtn_setid.Size = new System.Drawing.Size(110, 33);
            this.ucBtn_setid.TabIndex = 36;
            this.ucBtn_setid.TabStop = false;
            this.ucBtn_setid.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_setid.TipsText = "";
            // 
            // ucBtnExt1
            // 
            this.ucBtnExt1.BackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtnExt1.BtnText = "Save";
            this.ucBtnExt1.ConerRadius = 10;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = true;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(734, 213);
            this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt1.Name = "ucBtnExt1";
            this.ucBtnExt1.RectColor = System.Drawing.Color.Purple;
            this.ucBtnExt1.RectWidth = 2;
            this.ucBtnExt1.Size = new System.Drawing.Size(76, 28);
            this.ucBtnExt1.TabIndex = 37;
            this.ucBtnExt1.TabStop = false;
            this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt1.TipsText = "";
            // 
            // ucBtnExt2
            // 
            this.ucBtnExt2.BackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt2.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtnExt2.BtnText = "Clear";
            this.ucBtnExt2.ConerRadius = 10;
            this.ucBtnExt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt2.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtnExt2.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt2.IsRadius = true;
            this.ucBtnExt2.IsShowRect = true;
            this.ucBtnExt2.IsShowTips = false;
            this.ucBtnExt2.Location = new System.Drawing.Point(822, 213);
            this.ucBtnExt2.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt2.Name = "ucBtnExt2";
            this.ucBtnExt2.RectColor = System.Drawing.Color.Purple;
            this.ucBtnExt2.RectWidth = 2;
            this.ucBtnExt2.Size = new System.Drawing.Size(76, 28);
            this.ucBtnExt2.TabIndex = 38;
            this.ucBtnExt2.TabStop = false;
            this.ucBtnExt2.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt2.TipsText = "";
            // 
            // UnColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Color_Calibration.Properties.Resources.mainLogo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ucBtnExt2);
            this.Controls.Add(this.ucBtnExt1);
            this.Controls.Add(this.ucBtn_setid);
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
        private HZH_Controls.Controls.UCBtnExt ucBtn_setid;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt1;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt2;
    }
}
