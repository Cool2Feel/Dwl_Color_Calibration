namespace Color_Calibration.UnPages
{
    partial class UnAdjustForm
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
            this.Uncom_id = new HZH_Controls.Controls.UCCombox();
            this.label_mi = new System.Windows.Forms.Label();
            this.label_cm = new System.Windows.Forms.Label();
            this.ucSplitLine_H2 = new HZH_Controls.Controls.UCSplitLine_H();
            this.label_cp = new System.Windows.Forms.Label();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucTextBox_x = new HZH_Controls.Controls.UCTextBoxEx();
            this.ucTextBox_y = new HZH_Controls.Controls.UCTextBoxEx();
            this.ucTextBox_lv = new HZH_Controls.Controls.UCTextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_r = new System.Windows.Forms.Label();
            this.label_bl = new System.Windows.Forms.Label();
            this.ucTrack_r = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrack_bl = new HZH_Controls.Controls.UCTrackBar();
            this.label_b = new System.Windows.Forms.Label();
            this.label_g = new System.Windows.Forms.Label();
            this.ucTrack_b = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrack_g = new HZH_Controls.Controls.UCTrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblBl_add = new System.Windows.Forms.Label();
            this.lblBl_down = new System.Windows.Forms.Label();
            this.lblRg_add = new System.Windows.Forms.Label();
            this.lblGg_add = new System.Windows.Forms.Label();
            this.lblBg_add = new System.Windows.Forms.Label();
            this.lblRg_down = new System.Windows.Forms.Label();
            this.lblGg_down = new System.Windows.Forms.Label();
            this.lblBg_down = new System.Windows.Forms.Label();
            this.Btn_measure = new EASkins.Ami_Button_1();
            this.ucBtn_get = new EASkins.Ami_Button_1();
            this.ami_Button_setd = new EASkins.Ami_Button_1();
            this.SuspendLayout();
            // 
            // Uncom_id
            // 
            this.Uncom_id.BackColor = System.Drawing.Color.Transparent;
            this.Uncom_id.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uncom_id.ConerRadius = 5;
            this.Uncom_id.DropPanelHeight = 500;
            this.Uncom_id.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Uncom_id.IsRadius = true;
            this.Uncom_id.IsShowRect = true;
            this.Uncom_id.ItemWidth = 80;
            this.Uncom_id.Location = new System.Drawing.Point(44, 260);
            this.Uncom_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Uncom_id.Name = "Uncom_id";
            this.Uncom_id.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_id.RectWidth = 1;
            this.Uncom_id.SelectedIndex = -1;
            this.Uncom_id.SelectedValue = "";
            this.Uncom_id.Size = new System.Drawing.Size(160, 24);
            this.Uncom_id.Source = null;
            this.Uncom_id.TabIndex = 37;
            this.Uncom_id.TextValue = null;
            this.Uncom_id.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Uncom_id.SelectedChangedEvent += new System.EventHandler(this.Uncom_id_SelectedChangedEvent);
            // 
            // label_mi
            // 
            this.label_mi.AutoSize = true;
            this.label_mi.BackColor = System.Drawing.Color.Transparent;
            this.label_mi.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_mi.Location = new System.Drawing.Point(38, 236);
            this.label_mi.Name = "label_mi";
            this.label_mi.Size = new System.Drawing.Size(86, 19);
            this.label_mi.TabIndex = 32;
            this.label_mi.Text = "Monitor ID";
            // 
            // label_cm
            // 
            this.label_cm.AutoSize = true;
            this.label_cm.BackColor = System.Drawing.Color.Transparent;
            this.label_cm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cm.Location = new System.Drawing.Point(22, 202);
            this.label_cm.Name = "label_cm";
            this.label_cm.Size = new System.Drawing.Size(148, 19);
            this.label_cm.TabIndex = 30;
            this.label_cm.Text = "Manual Adjustment";
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(44, 231);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(160, 2);
            this.ucSplitLine_H2.TabIndex = 29;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // label_cp
            // 
            this.label_cp.AutoSize = true;
            this.label_cp.BackColor = System.Drawing.Color.Transparent;
            this.label_cp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cp.Location = new System.Drawing.Point(22, 14);
            this.label_cp.Name = "label_cp";
            this.label_cp.Size = new System.Drawing.Size(147, 19);
            this.label_cp.TabIndex = 28;
            this.label_cp.Text = "Color Measurement";
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(44, 40);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(160, 2);
            this.ucSplitLine_H1.TabIndex = 27;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucTextBox_x
            // 
            this.ucTextBox_x.BackColor = System.Drawing.SystemColors.Control;
            this.ucTextBox_x.ConerRadius = 5;
            this.ucTextBox_x.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_x.DecLength = 3;
            this.ucTextBox_x.Enabled = false;
            this.ucTextBox_x.FillColor = System.Drawing.SystemColors.Control;
            this.ucTextBox_x.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_x.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_x.InputText = "";
            this.ucTextBox_x.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBox_x.IsFocusColor = true;
            this.ucTextBox_x.IsRadius = true;
            this.ucTextBox_x.IsShowClearBtn = false;
            this.ucTextBox_x.IsShowKeyboard = false;
            this.ucTextBox_x.IsShowRect = true;
            this.ucTextBox_x.IsShowSearchBtn = false;
            this.ucTextBox_x.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBox_x.Location = new System.Drawing.Point(93, 86);
            this.ucTextBox_x.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_x.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucTextBox_x.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ucTextBox_x.Name = "ucTextBox_x";
            this.ucTextBox_x.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_x.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_x.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_x.PromptText = "";
            this.ucTextBox_x.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_x.RectWidth = 1;
            this.ucTextBox_x.RegexPattern = "";
            this.ucTextBox_x.Size = new System.Drawing.Size(112, 32);
            this.ucTextBox_x.TabIndex = 38;
            // 
            // ucTextBox_y
            // 
            this.ucTextBox_y.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox_y.ConerRadius = 5;
            this.ucTextBox_y.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_y.DecLength = 3;
            this.ucTextBox_y.Enabled = false;
            this.ucTextBox_y.FillColor = System.Drawing.SystemColors.Control;
            this.ucTextBox_y.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_y.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_y.InputText = "";
            this.ucTextBox_y.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBox_y.IsFocusColor = true;
            this.ucTextBox_y.IsRadius = true;
            this.ucTextBox_y.IsShowClearBtn = false;
            this.ucTextBox_y.IsShowKeyboard = false;
            this.ucTextBox_y.IsShowRect = true;
            this.ucTextBox_y.IsShowSearchBtn = false;
            this.ucTextBox_y.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBox_y.Location = new System.Drawing.Point(93, 121);
            this.ucTextBox_y.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_y.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucTextBox_y.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ucTextBox_y.Name = "ucTextBox_y";
            this.ucTextBox_y.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_y.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_y.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_y.PromptText = "";
            this.ucTextBox_y.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_y.RectWidth = 1;
            this.ucTextBox_y.RegexPattern = "";
            this.ucTextBox_y.Size = new System.Drawing.Size(112, 32);
            this.ucTextBox_y.TabIndex = 40;
            // 
            // ucTextBox_lv
            // 
            this.ucTextBox_lv.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox_lv.ConerRadius = 5;
            this.ucTextBox_lv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_lv.DecLength = 3;
            this.ucTextBox_lv.Enabled = false;
            this.ucTextBox_lv.FillColor = System.Drawing.SystemColors.Control;
            this.ucTextBox_lv.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_lv.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_lv.InputText = "";
            this.ucTextBox_lv.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBox_lv.IsFocusColor = true;
            this.ucTextBox_lv.IsRadius = true;
            this.ucTextBox_lv.IsShowClearBtn = false;
            this.ucTextBox_lv.IsShowKeyboard = false;
            this.ucTextBox_lv.IsShowRect = true;
            this.ucTextBox_lv.IsShowSearchBtn = false;
            this.ucTextBox_lv.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBox_lv.Location = new System.Drawing.Point(93, 156);
            this.ucTextBox_lv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_lv.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ucTextBox_lv.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.ucTextBox_lv.Name = "ucTextBox_lv";
            this.ucTextBox_lv.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_lv.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_lv.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_lv.PromptText = "";
            this.ucTextBox_lv.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_lv.RectWidth = 1;
            this.ucTextBox_lv.RegexPattern = "";
            this.ucTextBox_lv.Size = new System.Drawing.Size(112, 32);
            this.ucTextBox_lv.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(48, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "Y :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(48, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 19);
            this.label3.TabIndex = 43;
            this.label3.Text = "Lv :";
            // 
            // label_r
            // 
            this.label_r.AutoSize = true;
            this.label_r.BackColor = System.Drawing.Color.Transparent;
            this.label_r.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_r.ForeColor = System.Drawing.Color.Purple;
            this.label_r.Location = new System.Drawing.Point(502, 275);
            this.label_r.Name = "label_r";
            this.label_r.Size = new System.Drawing.Size(36, 19);
            this.label_r.TabIndex = 47;
            this.label_r.Text = "128";
            // 
            // label_bl
            // 
            this.label_bl.AutoSize = true;
            this.label_bl.BackColor = System.Drawing.Color.Transparent;
            this.label_bl.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_bl.ForeColor = System.Drawing.Color.Purple;
            this.label_bl.Location = new System.Drawing.Point(502, 242);
            this.label_bl.Name = "label_bl";
            this.label_bl.Size = new System.Drawing.Size(36, 19);
            this.label_bl.TabIndex = 46;
            this.label_bl.Text = "100";
            // 
            // ucTrack_r
            // 
            this.ucTrack_r.BackColor = System.Drawing.Color.Transparent;
            this.ucTrack_r.DcimalDigits = 0;
            this.ucTrack_r.IsShowTips = true;
            this.ucTrack_r.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_r.LineWidth = 5F;
            this.ucTrack_r.Location = new System.Drawing.Point(562, 274);
            this.ucTrack_r.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_r.MaxValue = 255F;
            this.ucTrack_r.MinValue = 0F;
            this.ucTrack_r.Name = "ucTrack_r";
            this.ucTrack_r.Size = new System.Drawing.Size(320, 20);
            this.ucTrack_r.TabIndex = 45;
            this.ucTrack_r.Text = "ucTrack_r";
            this.ucTrack_r.TipsFormat = null;
            this.ucTrack_r.Value = 128F;
            this.ucTrack_r.ValueColor = System.Drawing.Color.Purple;
            this.ucTrack_r.ValueChanged += new System.EventHandler(this.ucTrack_r_ValueChanged);
            this.ucTrack_r.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucTrack_r_MouseUp);
            // 
            // ucTrack_bl
            // 
            this.ucTrack_bl.BackColor = System.Drawing.Color.Transparent;
            this.ucTrack_bl.DcimalDigits = 0;
            this.ucTrack_bl.IsShowTips = true;
            this.ucTrack_bl.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_bl.LineWidth = 5F;
            this.ucTrack_bl.Location = new System.Drawing.Point(562, 240);
            this.ucTrack_bl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_bl.MaxValue = 100F;
            this.ucTrack_bl.MinValue = 0F;
            this.ucTrack_bl.Name = "ucTrack_bl";
            this.ucTrack_bl.Size = new System.Drawing.Size(320, 20);
            this.ucTrack_bl.TabIndex = 44;
            this.ucTrack_bl.Text = "ucTrack_bl";
            this.ucTrack_bl.TipsFormat = null;
            this.ucTrack_bl.Value = 100F;
            this.ucTrack_bl.ValueColor = System.Drawing.Color.Purple;
            this.ucTrack_bl.ValueChanged += new System.EventHandler(this.ucTrack_bl_ValueChanged);
            this.ucTrack_bl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucTrack_bl_MouseUp);
            // 
            // label_b
            // 
            this.label_b.AutoSize = true;
            this.label_b.BackColor = System.Drawing.Color.Transparent;
            this.label_b.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_b.ForeColor = System.Drawing.Color.Purple;
            this.label_b.Location = new System.Drawing.Point(502, 343);
            this.label_b.Name = "label_b";
            this.label_b.Size = new System.Drawing.Size(36, 19);
            this.label_b.TabIndex = 51;
            this.label_b.Text = "128";
            // 
            // label_g
            // 
            this.label_g.AutoSize = true;
            this.label_g.BackColor = System.Drawing.Color.Transparent;
            this.label_g.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_g.ForeColor = System.Drawing.Color.Purple;
            this.label_g.Location = new System.Drawing.Point(502, 309);
            this.label_g.Name = "label_g";
            this.label_g.Size = new System.Drawing.Size(36, 19);
            this.label_g.TabIndex = 50;
            this.label_g.Text = "128";
            // 
            // ucTrack_b
            // 
            this.ucTrack_b.BackColor = System.Drawing.Color.Transparent;
            this.ucTrack_b.DcimalDigits = 0;
            this.ucTrack_b.IsShowTips = true;
            this.ucTrack_b.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_b.LineWidth = 5F;
            this.ucTrack_b.Location = new System.Drawing.Point(562, 342);
            this.ucTrack_b.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_b.MaxValue = 255F;
            this.ucTrack_b.MinValue = 0F;
            this.ucTrack_b.Name = "ucTrack_b";
            this.ucTrack_b.Size = new System.Drawing.Size(320, 20);
            this.ucTrack_b.TabIndex = 49;
            this.ucTrack_b.Text = "ucTrack_b";
            this.ucTrack_b.TipsFormat = null;
            this.ucTrack_b.Value = 128F;
            this.ucTrack_b.ValueColor = System.Drawing.Color.Purple;
            this.ucTrack_b.ValueChanged += new System.EventHandler(this.ucTrack_b_ValueChanged);
            this.ucTrack_b.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucTrack_b_MouseUp);
            // 
            // ucTrack_g
            // 
            this.ucTrack_g.BackColor = System.Drawing.Color.Transparent;
            this.ucTrack_g.DcimalDigits = 0;
            this.ucTrack_g.IsShowTips = true;
            this.ucTrack_g.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_g.LineWidth = 5F;
            this.ucTrack_g.Location = new System.Drawing.Point(562, 308);
            this.ucTrack_g.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_g.MaxValue = 255F;
            this.ucTrack_g.MinValue = 0F;
            this.ucTrack_g.Name = "ucTrack_g";
            this.ucTrack_g.Size = new System.Drawing.Size(320, 20);
            this.ucTrack_g.TabIndex = 48;
            this.ucTrack_g.Text = "ucTrack_g";
            this.ucTrack_g.TipsFormat = null;
            this.ucTrack_g.Value = 128F;
            this.ucTrack_g.ValueColor = System.Drawing.Color.Purple;
            this.ucTrack_g.ValueChanged += new System.EventHandler(this.ucTrack_g_ValueChanged);
            this.ucTrack_g.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucTrack_g_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(448, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "R Gain:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(431, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 52;
            this.label7.Text = "Backlight:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(449, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "B Gain:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(447, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "G Gain:";
            // 
            // lblBl_add
            // 
            this.lblBl_add.BackColor = System.Drawing.Color.Transparent;
            this.lblBl_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBl_add.ForeColor = System.Drawing.Color.White;
            this.lblBl_add.Location = new System.Drawing.Point(885, 241);
            this.lblBl_add.Name = "lblBl_add";
            this.lblBl_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblBl_add.Size = new System.Drawing.Size(18, 18);
            this.lblBl_add.TabIndex = 56;
            this.lblBl_add.Tag = "";
            this.lblBl_add.Text = "+";
            this.lblBl_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBl_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseDown);
            this.lblBl_add.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblBl_add.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblBl_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblBl_down
            // 
            this.lblBl_down.BackColor = System.Drawing.Color.Transparent;
            this.lblBl_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBl_down.ForeColor = System.Drawing.Color.White;
            this.lblBl_down.Location = new System.Drawing.Point(544, 241);
            this.lblBl_down.Name = "lblBl_down";
            this.lblBl_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblBl_down.Size = new System.Drawing.Size(18, 18);
            this.lblBl_down.TabIndex = 57;
            this.lblBl_down.Tag = "";
            this.lblBl_down.Text = "-";
            this.lblBl_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBl_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBl_down_MouseDown);
            this.lblBl_down.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblBl_down.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblBl_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblRg_add
            // 
            this.lblRg_add.BackColor = System.Drawing.Color.Transparent;
            this.lblRg_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRg_add.ForeColor = System.Drawing.Color.White;
            this.lblRg_add.Location = new System.Drawing.Point(885, 276);
            this.lblRg_add.Name = "lblRg_add";
            this.lblRg_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblRg_add.Size = new System.Drawing.Size(18, 18);
            this.lblRg_add.TabIndex = 58;
            this.lblRg_add.Tag = "";
            this.lblRg_add.Text = "+";
            this.lblRg_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRg_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblRg_add_MouseDown);
            this.lblRg_add.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblRg_add.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblRg_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblGg_add
            // 
            this.lblGg_add.BackColor = System.Drawing.Color.Transparent;
            this.lblGg_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGg_add.ForeColor = System.Drawing.Color.White;
            this.lblGg_add.Location = new System.Drawing.Point(885, 309);
            this.lblGg_add.Name = "lblGg_add";
            this.lblGg_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblGg_add.Size = new System.Drawing.Size(18, 18);
            this.lblGg_add.TabIndex = 59;
            this.lblGg_add.Tag = "";
            this.lblGg_add.Text = "+";
            this.lblGg_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGg_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblGg_add_MouseDown);
            this.lblGg_add.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblGg_add.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblGg_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblBg_add
            // 
            this.lblBg_add.BackColor = System.Drawing.Color.Transparent;
            this.lblBg_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBg_add.ForeColor = System.Drawing.Color.White;
            this.lblBg_add.Location = new System.Drawing.Point(885, 344);
            this.lblBg_add.Name = "lblBg_add";
            this.lblBg_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblBg_add.Size = new System.Drawing.Size(18, 18);
            this.lblBg_add.TabIndex = 60;
            this.lblBg_add.Tag = "";
            this.lblBg_add.Text = "+";
            this.lblBg_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBg_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBg_add_MouseDown);
            this.lblBg_add.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblBg_add.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblBg_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblRg_down
            // 
            this.lblRg_down.BackColor = System.Drawing.Color.Transparent;
            this.lblRg_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRg_down.ForeColor = System.Drawing.Color.White;
            this.lblRg_down.Location = new System.Drawing.Point(544, 276);
            this.lblRg_down.Name = "lblRg_down";
            this.lblRg_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblRg_down.Size = new System.Drawing.Size(18, 18);
            this.lblRg_down.TabIndex = 61;
            this.lblRg_down.Tag = "";
            this.lblRg_down.Text = "-";
            this.lblRg_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRg_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblRg_down_MouseDown);
            this.lblRg_down.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblRg_down.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblRg_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblGg_down
            // 
            this.lblGg_down.BackColor = System.Drawing.Color.Transparent;
            this.lblGg_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGg_down.ForeColor = System.Drawing.Color.White;
            this.lblGg_down.Location = new System.Drawing.Point(544, 310);
            this.lblGg_down.Name = "lblGg_down";
            this.lblGg_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblGg_down.Size = new System.Drawing.Size(18, 18);
            this.lblGg_down.TabIndex = 62;
            this.lblGg_down.Tag = "";
            this.lblGg_down.Text = "-";
            this.lblGg_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGg_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblGg_down_MouseDown);
            this.lblGg_down.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblGg_down.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblGg_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // lblBg_down
            // 
            this.lblBg_down.BackColor = System.Drawing.Color.Transparent;
            this.lblBg_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBg_down.ForeColor = System.Drawing.Color.White;
            this.lblBg_down.Location = new System.Drawing.Point(544, 344);
            this.lblBg_down.Name = "lblBg_down";
            this.lblBg_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lblBg_down.Size = new System.Drawing.Size(18, 18);
            this.lblBg_down.TabIndex = 63;
            this.lblBg_down.Tag = "";
            this.lblBg_down.Text = "-";
            this.lblBg_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBg_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblBg_down_MouseDown);
            this.lblBg_down.MouseEnter += new System.EventHandler(this.lblBl_add_MouseEnter);
            this.lblBg_down.MouseLeave += new System.EventHandler(this.lblBl_add_MouseLeave);
            this.lblBg_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblBl_add_MouseUp);
            // 
            // Btn_measure
            // 
            this.Btn_measure.BackColor = System.Drawing.Color.Transparent;
            this.Btn_measure.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_measure.Image = null;
            this.Btn_measure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_measure.Location = new System.Drawing.Point(44, 49);
            this.Btn_measure.Name = "Btn_measure";
            this.Btn_measure.Size = new System.Drawing.Size(161, 30);
            this.Btn_measure.TabIndex = 64;
            this.Btn_measure.Text = "Measure";
            this.Btn_measure.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Btn_measure.Click += new System.EventHandler(this.Btn_measure_Click);
            // 
            // ucBtn_get
            // 
            this.ucBtn_get.BackColor = System.Drawing.Color.Transparent;
            this.ucBtn_get.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBtn_get.Image = null;
            this.ucBtn_get.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucBtn_get.Location = new System.Drawing.Point(44, 294);
            this.ucBtn_get.Name = "ucBtn_get";
            this.ucBtn_get.Size = new System.Drawing.Size(161, 30);
            this.ucBtn_get.TabIndex = 65;
            this.ucBtn_get.Text = "Get";
            this.ucBtn_get.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ucBtn_get.Click += new System.EventHandler(this.ucBtn_get_Click);
            // 
            // ami_Button_setd
            // 
            this.ami_Button_setd.BackColor = System.Drawing.Color.Transparent;
            this.ami_Button_setd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ami_Button_setd.Image = null;
            this.ami_Button_setd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ami_Button_setd.Location = new System.Drawing.Point(44, 333);
            this.ami_Button_setd.Name = "ami_Button_setd";
            this.ami_Button_setd.Size = new System.Drawing.Size(161, 30);
            this.ami_Button_setd.TabIndex = 67;
            this.ami_Button_setd.Text = "Set Default";
            this.ami_Button_setd.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ami_Button_setd.Visible = false;
            this.ami_Button_setd.Click += new System.EventHandler(this.ami_Button_setd_Click);
            // 
            // UnAdjustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Color_Calibration.Properties.Resources.mainLogo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ami_Button_setd);
            this.Controls.Add(this.ucBtn_get);
            this.Controls.Add(this.Btn_measure);
            this.Controls.Add(this.lblBg_down);
            this.Controls.Add(this.lblGg_down);
            this.Controls.Add(this.lblRg_down);
            this.Controls.Add(this.lblBg_add);
            this.Controls.Add(this.lblGg_add);
            this.Controls.Add(this.lblRg_add);
            this.Controls.Add(this.lblBl_down);
            this.Controls.Add(this.lblBl_add);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_b);
            this.Controls.Add(this.label_g);
            this.Controls.Add(this.ucTrack_b);
            this.Controls.Add(this.ucTrack_g);
            this.Controls.Add(this.label_r);
            this.Controls.Add(this.label_bl);
            this.Controls.Add(this.ucTrack_r);
            this.Controls.Add(this.ucTrack_bl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucTextBox_lv);
            this.Controls.Add(this.ucTextBox_y);
            this.Controls.Add(this.ucTextBox_x);
            this.Controls.Add(this.Uncom_id);
            this.Controls.Add(this.label_mi);
            this.Controls.Add(this.label_cm);
            this.Controls.Add(this.ucSplitLine_H2);
            this.Controls.Add(this.label_cp);
            this.Controls.Add(this.ucSplitLine_H1);
            this.DoubleBuffered = true;
            this.Name = "UnAdjustForm";
            this.Size = new System.Drawing.Size(915, 374);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCCombox Uncom_id;
        private System.Windows.Forms.Label label_mi;
        private System.Windows.Forms.Label label_cm;
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H2;
        private System.Windows.Forms.Label label_cp;
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_x;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_y;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_lv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_r;
        private System.Windows.Forms.Label label_bl;
        private HZH_Controls.Controls.UCTrackBar ucTrack_r;
        private HZH_Controls.Controls.UCTrackBar ucTrack_bl;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_g;
        private HZH_Controls.Controls.UCTrackBar ucTrack_b;
        private HZH_Controls.Controls.UCTrackBar ucTrack_g;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblBl_add;
        private System.Windows.Forms.Label lblBl_down;
        private System.Windows.Forms.Label lblRg_add;
        private System.Windows.Forms.Label lblGg_add;
        private System.Windows.Forms.Label lblBg_add;
        private System.Windows.Forms.Label lblRg_down;
        private System.Windows.Forms.Label lblGg_down;
        private System.Windows.Forms.Label lblBg_down;
        private EASkins.Ami_Button_1 Btn_measure;
        private EASkins.Ami_Button_1 ucBtn_get;
        private EASkins.Ami_Button_1 ami_Button_setd;
    }
}
