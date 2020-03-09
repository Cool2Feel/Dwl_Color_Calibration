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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1_tips = new System.Windows.Forms.Label();
            this.ucBtn_save = new EASkins.Ami_Button_1();
            this.ucBtn_clear = new EASkins.Ami_Button_1();
            this.ucBtn_Execute = new EASkins.Ami_Button_1();
            this.label2 = new System.Windows.Forms.Label();
            this.ami_Button_13 = new EASkins.Ami_Button_1();
            this.ami_Button_11 = new EASkins.Ami_Button_1();
            this.ucTextBox_id = new HZH_Controls.Controls.UCTextBoxEx();
            this.ucledNums1 = new HZH_Controls.Controls.UCLEDNums();
            this.ucCheckBox_out = new HZH_Controls.Controls.UCCheckBox();
            this.ucDataGridView_result = new HZH_Controls.Controls.UCDataGridView();
            this.Uncom_id = new HZH_Controls.Controls.UCCombox();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1_tips);
            this.panel1.Location = new System.Drawing.Point(62, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 44);
            this.panel1.TabIndex = 8;
            // 
            // label1_tips
            // 
            this.label1_tips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1_tips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1_tips.Location = new System.Drawing.Point(0, 0);
            this.label1_tips.Name = "label1_tips";
            this.label1_tips.Size = new System.Drawing.Size(810, 44);
            this.label1_tips.TabIndex = 0;
            this.label1_tips.Text = "Put the sensor on monitor : ID 1 , and then click the Execute button.";
            this.label1_tips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ucBtn_Execute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 71;
            this.label2.Text = "Moniter ID:";
            this.label2.Visible = false;
            // 
            // ami_Button_13
            // 
            this.ami_Button_13.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Button_13.Image = null;
            this.ami_Button_13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_13.Location = new System.Drawing.Point(823, 180);
            this.ami_Button_13.Name = "ami_Button_13";
            this.ami_Button_13.Size = new System.Drawing.Size(73, 30);
            this.ami_Button_13.TabIndex = 74;
            this.ami_Button_13.Text = "close";
            this.ami_Button_13.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_13.Visible = false;
            this.ami_Button_13.Click += new System.EventHandler(this.ami_Button_13_Click);
            // 
            // ami_Button_11
            // 
            this.ami_Button_11.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Button_11.Image = null;
            this.ami_Button_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_11.Location = new System.Drawing.Point(823, 148);
            this.ami_Button_11.Name = "ami_Button_11";
            this.ami_Button_11.Size = new System.Drawing.Size(73, 30);
            this.ami_Button_11.TabIndex = 73;
            this.ami_Button_11.Text = "open";
            this.ami_Button_11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_11.Visible = false;
            this.ami_Button_11.Click += new System.EventHandler(this.ami_Button_11_Click);
            // 
            // ucTextBox_id
            // 
            this.ucTextBox_id.BackColor = System.Drawing.Color.Silver;
            this.ucTextBox_id.ConerRadius = 5;
            this.ucTextBox_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_id.DecLength = 0;
            this.ucTextBox_id.FillColor = System.Drawing.Color.Empty;
            this.ucTextBox_id.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_id.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucTextBox_id.InputText = "1";
            this.ucTextBox_id.InputType = HZH_Controls.TextInputType.Number;
            this.ucTextBox_id.IsFocusColor = true;
            this.ucTextBox_id.IsRadius = true;
            this.ucTextBox_id.IsShowClearBtn = true;
            this.ucTextBox_id.IsShowKeyboard = false;
            this.ucTextBox_id.IsShowRect = true;
            this.ucTextBox_id.IsShowSearchBtn = false;
            this.ucTextBox_id.KeyBoardType = HZH_Controls.Controls.KeyBoardType.Null;
            this.ucTextBox_id.Location = new System.Drawing.Point(15, 156);
            this.ucTextBox_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_id.MaxValue = new decimal(new int[] {
            225,
            0,
            0,
            0});
            this.ucTextBox_id.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTextBox_id.Name = "ucTextBox_id";
            this.ucTextBox_id.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_id.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_id.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_id.PromptText = "ID";
            this.ucTextBox_id.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_id.RectWidth = 1;
            this.ucTextBox_id.RegexPattern = "";
            this.ucTextBox_id.Size = new System.Drawing.Size(92, 36);
            this.ucTextBox_id.TabIndex = 72;
            this.ucTextBox_id.Visible = false;
            this.ucTextBox_id.MouseEnter += new System.EventHandler(this.ucTextBox_id_MouseEnter);
            this.ucTextBox_id.MouseLeave += new System.EventHandler(this.ucTextBox_id_MouseLeave);
            // 
            // ucledNums1
            // 
            this.ucledNums1.BackColor = System.Drawing.Color.Transparent;
            this.ucledNums1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(26)))), ((int)(((byte)(143)))));
            this.ucledNums1.LineWidth = 8;
            this.ucledNums1.Location = new System.Drawing.Point(6, 6);
            this.ucledNums1.Name = "ucledNums1";
            this.ucledNums1.Size = new System.Drawing.Size(113, 68);
            this.ucledNums1.TabIndex = 69;
            this.ucledNums1.Value = "10";
            this.ucledNums1.Visible = false;
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
            this.ucCheckBox_out.TextValue = "Custom ID method";
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
            // Uncom_id
            // 
            this.Uncom_id.BackColor = System.Drawing.Color.Transparent;
            this.Uncom_id.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uncom_id.ConerRadius = 5;
            this.Uncom_id.DropPanelHeight = 500;
            this.Uncom_id.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Uncom_id.IsRadius = true;
            this.Uncom_id.IsShowRect = true;
            this.Uncom_id.ItemWidth = 92;
            this.Uncom_id.Location = new System.Drawing.Point(18, 106);
            this.Uncom_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Uncom_id.Name = "Uncom_id";
            this.Uncom_id.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.RectWidth = 1;
            this.Uncom_id.SelectedIndex = -1;
            this.Uncom_id.SelectedValue = "";
            this.Uncom_id.Size = new System.Drawing.Size(92, 36);
            this.Uncom_id.Source = null;
            this.Uncom_id.TabIndex = 75;
            this.Uncom_id.TabStop = false;
            this.Uncom_id.TextValue = null;
            this.Uncom_id.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Uncom_id.Visible = false;
            this.Uncom_id.SelectedChangedEvent += new System.EventHandler(this.Uncom_id_SelectedChangedEvent);
            // 
            // UnColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Color_Calibration.Properties.Resources.mainLogo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Uncom_id);
            this.Controls.Add(this.ami_Button_13);
            this.Controls.Add(this.ami_Button_11);
            this.Controls.Add(this.ucTextBox_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucledNums1);
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
        private System.Windows.Forms.Label label1_tips;
        private EASkins.Ami_Button_1 ucBtn_save;
        private EASkins.Ami_Button_1 ucBtn_clear;
        private EASkins.Ami_Button_1 ucBtn_Execute;
        private HZH_Controls.Controls.UCLEDNums ucledNums1;
        private System.Windows.Forms.Label label2;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_id;
        private EASkins.Ami_Button_1 ami_Button_13;
        private EASkins.Ami_Button_1 ami_Button_11;
        private HZH_Controls.Controls.UCCombox Uncom_id;
    }
}
