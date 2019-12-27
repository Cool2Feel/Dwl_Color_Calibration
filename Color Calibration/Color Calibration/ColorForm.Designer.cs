namespace Color_Calibration
{
    partial class ColorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucTrack_x = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrack_y = new HZH_Controls.Controls.UCTrackBar();
            this.ucBtn_set = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt1 = new HZH_Controls.Controls.UCBtnExt();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.lbl_x_down = new System.Windows.Forms.Label();
            this.lbl_x_add = new System.Windows.Forms.Label();
            this.lbl_y_down = new System.Windows.Forms.Label();
            this.lbl_y_add = new System.Windows.Forms.Label();
            this.label_mode = new System.Windows.Forms.Label();
            this.ucSwitch1 = new HZH_Controls.Controls.UCSwitch();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_eerxy = new System.Windows.Forms.Label();
            this.ucTextBox_xy = new HZH_Controls.Controls.UCTextBoxEx();
            this.label_errlv = new System.Windows.Forms.Label();
            this.ucTextBox_lv = new HZH_Controls.Controls.UCTextBoxEx();
            this.label_lv_down = new System.Windows.Forms.Label();
            this.label_lv_add = new System.Windows.Forms.Label();
            this.label_lv = new System.Windows.Forms.Label();
            this.ucTrack_lv = new HZH_Controls.Controls.UCTrackBar();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Color_Calibration.Properties.Resources.color_cie;
            this.pictureBox1.Location = new System.Drawing.Point(22, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucTrack_x
            // 
            this.ucTrack_x.DcimalDigits = 3;
            this.ucTrack_x.IsShowTips = true;
            this.ucTrack_x.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_x.LineWidth = 8F;
            this.ucTrack_x.Location = new System.Drawing.Point(399, 69);
            this.ucTrack_x.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_x.MaxValue = 0.7F;
            this.ucTrack_x.MinValue = 0F;
            this.ucTrack_x.Name = "ucTrack_x";
            this.ucTrack_x.Size = new System.Drawing.Size(313, 21);
            this.ucTrack_x.TabIndex = 1;
            this.ucTrack_x.Text = "ucTrack_x";
            this.ucTrack_x.TipsFormat = null;
            this.ucTrack_x.Value = 0.285F;
            this.ucTrack_x.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrack_x.ValueChanged += new System.EventHandler(this.ucTrack_x_ValueChanged);
            // 
            // ucTrack_y
            // 
            this.ucTrack_y.DcimalDigits = 3;
            this.ucTrack_y.IsShowTips = true;
            this.ucTrack_y.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_y.LineWidth = 8F;
            this.ucTrack_y.Location = new System.Drawing.Point(398, 105);
            this.ucTrack_y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_y.MaxValue = 0.7F;
            this.ucTrack_y.MinValue = 0.001F;
            this.ucTrack_y.Name = "ucTrack_y";
            this.ucTrack_y.Size = new System.Drawing.Size(313, 21);
            this.ucTrack_y.TabIndex = 2;
            this.ucTrack_y.Text = "ucTrack_y";
            this.ucTrack_y.TipsFormat = null;
            this.ucTrack_y.Value = 0.293F;
            this.ucTrack_y.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrack_y.ValueChanged += new System.EventHandler(this.ucTrack_y_ValueChanged);
            // 
            // ucBtn_set
            // 
            this.ucBtn_set.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ucBtn_set.BtnBackColor = System.Drawing.Color.DeepSkyBlue;
            this.ucBtn_set.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtn_set.BtnText = "OK";
            this.ucBtn_set.ConerRadius = 10;
            this.ucBtn_set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_set.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.ucBtn_set.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.IsRadius = true;
            this.ucBtn_set.IsShowRect = false;
            this.ucBtn_set.IsShowTips = false;
            this.ucBtn_set.Location = new System.Drawing.Point(561, 319);
            this.ucBtn_set.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_set.Name = "ucBtn_set";
            this.ucBtn_set.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_set.RectWidth = 1;
            this.ucBtn_set.Size = new System.Drawing.Size(100, 36);
            this.ucBtn_set.TabIndex = 24;
            this.ucBtn_set.TabStop = false;
            this.ucBtn_set.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_set.TipsText = "";
            this.ucBtn_set.BtnClick += new System.EventHandler(this.ucBtn_set_BtnClick);
            // 
            // ucBtnExt1
            // 
            this.ucBtnExt1.BackColor = System.Drawing.Color.Silver;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.Silver;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtnExt1.BtnText = "Cancle";
            this.ucBtnExt1.ConerRadius = 10;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.FillColor = System.Drawing.Color.Silver;
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = false;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(397, 319);
            this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt1.Name = "ucBtnExt1";
            this.ucBtnExt1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtnExt1.RectWidth = 1;
            this.ucBtnExt1.Size = new System.Drawing.Size(100, 36);
            this.ucBtnExt1.TabIndex = 25;
            this.ucBtnExt1.TabStop = false;
            this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt1.TipsText = "";
            this.ucBtnExt1.BtnClick += new System.EventHandler(this.ucBtnExt1_BtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(246, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Target x:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(246, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Target y:";
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_x.ForeColor = System.Drawing.Color.Purple;
            this.label_x.Location = new System.Drawing.Point(317, 70);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(49, 19);
            this.label_x.TabIndex = 28;
            this.label_x.Text = "0.285";
            // 
            // label_y
            // 
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_y.ForeColor = System.Drawing.Color.Purple;
            this.label_y.Location = new System.Drawing.Point(317, 106);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(49, 19);
            this.label_y.TabIndex = 29;
            this.label_y.Text = "0.293";
            // 
            // lbl_x_down
            // 
            this.lbl_x_down.BackColor = System.Drawing.Color.Transparent;
            this.lbl_x_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_x_down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_x_down.Location = new System.Drawing.Point(376, 71);
            this.lbl_x_down.Name = "lbl_x_down";
            this.lbl_x_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lbl_x_down.Size = new System.Drawing.Size(18, 18);
            this.lbl_x_down.TabIndex = 59;
            this.lbl_x_down.Tag = "";
            this.lbl_x_down.Text = "-";
            this.lbl_x_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_x_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_x_down_MouseDown);
            this.lbl_x_down.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.lbl_x_down.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.lbl_x_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // lbl_x_add
            // 
            this.lbl_x_add.BackColor = System.Drawing.Color.Transparent;
            this.lbl_x_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_x_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_x_add.Location = new System.Drawing.Point(720, 71);
            this.lbl_x_add.Name = "lbl_x_add";
            this.lbl_x_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lbl_x_add.Size = new System.Drawing.Size(18, 18);
            this.lbl_x_add.TabIndex = 58;
            this.lbl_x_add.Tag = "";
            this.lbl_x_add.Text = "+";
            this.lbl_x_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_x_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseDown);
            this.lbl_x_add.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.lbl_x_add.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.lbl_x_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // lbl_y_down
            // 
            this.lbl_y_down.BackColor = System.Drawing.Color.Transparent;
            this.lbl_y_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_y_down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_y_down.Location = new System.Drawing.Point(376, 107);
            this.lbl_y_down.Name = "lbl_y_down";
            this.lbl_y_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lbl_y_down.Size = new System.Drawing.Size(18, 18);
            this.lbl_y_down.TabIndex = 61;
            this.lbl_y_down.Tag = "";
            this.lbl_y_down.Text = "-";
            this.lbl_y_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_y_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_y_down_MouseDown);
            this.lbl_y_down.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.lbl_y_down.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.lbl_y_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // lbl_y_add
            // 
            this.lbl_y_add.BackColor = System.Drawing.Color.Transparent;
            this.lbl_y_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_y_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_y_add.Location = new System.Drawing.Point(720, 107);
            this.lbl_y_add.Name = "lbl_y_add";
            this.lbl_y_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.lbl_y_add.Size = new System.Drawing.Size(18, 18);
            this.lbl_y_add.TabIndex = 60;
            this.lbl_y_add.Tag = "";
            this.lbl_y_add.Text = "+";
            this.lbl_y_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_y_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_y_add_MouseDown);
            this.lbl_y_add.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.lbl_y_add.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.lbl_y_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_mode.ForeColor = System.Drawing.Color.Purple;
            this.label_mode.Location = new System.Drawing.Point(435, 13);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(176, 22);
            this.label_mode.TabIndex = 62;
            this.label_mode.Text = "当前的色温模式：Cool";
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch1.Checked = false;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch1.Location = new System.Drawing.Point(430, 187);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(83, 31);
            this.ucSwitch1.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch1.TabIndex = 63;
            this.ucSwitch1.Texts = null;
            this.ucSwitch1.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucSwitch1.CheckedChanged += new System.EventHandler(this.ucSwitch1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(317, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "校准误差   默认值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(517, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "自定义";
            // 
            // label_eerxy
            // 
            this.label_eerxy.BackColor = System.Drawing.Color.Transparent;
            this.label_eerxy.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_eerxy.Location = new System.Drawing.Point(324, 236);
            this.label_eerxy.Name = "label_eerxy";
            this.label_eerxy.Size = new System.Drawing.Size(116, 45);
            this.label_eerxy.TabIndex = 67;
            this.label_eerxy.Text = "   x、y error ± (0.001~0.05) :";
            this.label_eerxy.Visible = false;
            // 
            // ucTextBox_xy
            // 
            this.ucTextBox_xy.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox_xy.ConerRadius = 5;
            this.ucTextBox_xy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_xy.DecLength = 3;
            this.ucTextBox_xy.FillColor = System.Drawing.Color.Empty;
            this.ucTextBox_xy.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_xy.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_xy.InputText = "0.005";
            this.ucTextBox_xy.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBox_xy.IsFocusColor = true;
            this.ucTextBox_xy.IsRadius = true;
            this.ucTextBox_xy.IsShowClearBtn = false;
            this.ucTextBox_xy.IsShowKeyboard = false;
            this.ucTextBox_xy.IsShowRect = true;
            this.ucTextBox_xy.IsShowSearchBtn = false;
            this.ucTextBox_xy.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBox_xy.Location = new System.Drawing.Point(441, 241);
            this.ucTextBox_xy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_xy.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ucTextBox_xy.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTextBox_xy.Name = "ucTextBox_xy";
            this.ucTextBox_xy.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_xy.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_xy.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_xy.PromptText = "";
            this.ucTextBox_xy.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_xy.RectWidth = 1;
            this.ucTextBox_xy.RegexPattern = "";
            this.ucTextBox_xy.Size = new System.Drawing.Size(83, 34);
            this.ucTextBox_xy.TabIndex = 66;
            this.ucTextBox_xy.Visible = false;
            // 
            // label_errlv
            // 
            this.label_errlv.BackColor = System.Drawing.Color.Transparent;
            this.label_errlv.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_errlv.Location = new System.Drawing.Point(529, 236);
            this.label_errlv.Name = "label_errlv";
            this.label_errlv.Size = new System.Drawing.Size(96, 45);
            this.label_errlv.TabIndex = 69;
            this.label_errlv.Text = " Lv  error  ±   (10~100) :";
            this.label_errlv.Visible = false;
            // 
            // ucTextBox_lv
            // 
            this.ucTextBox_lv.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBox_lv.ConerRadius = 5;
            this.ucTextBox_lv.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBox_lv.DecLength = 0;
            this.ucTextBox_lv.FillColor = System.Drawing.Color.Empty;
            this.ucTextBox_lv.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBox_lv.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_lv.InputText = "20";
            this.ucTextBox_lv.InputType = HZH_Controls.TextInputType.NotControl;
            this.ucTextBox_lv.IsFocusColor = true;
            this.ucTextBox_lv.IsRadius = true;
            this.ucTextBox_lv.IsShowClearBtn = false;
            this.ucTextBox_lv.IsShowKeyboard = false;
            this.ucTextBox_lv.IsShowRect = true;
            this.ucTextBox_lv.IsShowSearchBtn = false;
            this.ucTextBox_lv.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBox_lv.Location = new System.Drawing.Point(625, 241);
            this.ucTextBox_lv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBox_lv.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucTextBox_lv.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTextBox_lv.Name = "ucTextBox_lv";
            this.ucTextBox_lv.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBox_lv.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBox_lv.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBox_lv.PromptText = "";
            this.ucTextBox_lv.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBox_lv.RectWidth = 1;
            this.ucTextBox_lv.RegexPattern = "";
            this.ucTextBox_lv.Size = new System.Drawing.Size(83, 34);
            this.ucTextBox_lv.TabIndex = 68;
            this.ucTextBox_lv.Visible = false;
            // 
            // label_lv_down
            // 
            this.label_lv_down.BackColor = System.Drawing.Color.Transparent;
            this.label_lv_down.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_lv_down.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label_lv_down.Location = new System.Drawing.Point(377, 142);
            this.label_lv_down.Name = "label_lv_down";
            this.label_lv_down.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.label_lv_down.Size = new System.Drawing.Size(18, 18);
            this.label_lv_down.TabIndex = 73;
            this.label_lv_down.Tag = "";
            this.label_lv_down.Text = "-";
            this.label_lv_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_lv_down.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_lv_down_MouseDown);
            this.label_lv_down.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.label_lv_down.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.label_lv_down.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // label_lv_add
            // 
            this.label_lv_add.BackColor = System.Drawing.Color.Transparent;
            this.label_lv_add.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_lv_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label_lv_add.Location = new System.Drawing.Point(721, 142);
            this.label_lv_add.Name = "label_lv_add";
            this.label_lv_add.Padding = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.label_lv_add.Size = new System.Drawing.Size(18, 18);
            this.label_lv_add.TabIndex = 72;
            this.label_lv_add.Tag = "";
            this.label_lv_add.Text = "+";
            this.label_lv_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_lv_add.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_lv_add_MouseDown);
            this.label_lv_add.MouseEnter += new System.EventHandler(this.lbl_x_add_MouseEnter);
            this.label_lv_add.MouseLeave += new System.EventHandler(this.lbl_x_add_MouseLeave);
            this.label_lv_add.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbl_x_add_MouseUp);
            // 
            // label_lv
            // 
            this.label_lv.AutoSize = true;
            this.label_lv.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_lv.ForeColor = System.Drawing.Color.Purple;
            this.label_lv.Location = new System.Drawing.Point(323, 141);
            this.label_lv.Name = "label_lv";
            this.label_lv.Size = new System.Drawing.Size(36, 19);
            this.label_lv.TabIndex = 71;
            this.label_lv.Text = "400";
            // 
            // ucTrack_lv
            // 
            this.ucTrack_lv.DcimalDigits = 0;
            this.ucTrack_lv.IsShowTips = true;
            this.ucTrack_lv.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrack_lv.LineWidth = 8F;
            this.ucTrack_lv.Location = new System.Drawing.Point(399, 140);
            this.ucTrack_lv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_lv.MaxValue = 1000F;
            this.ucTrack_lv.MinValue = 100F;
            this.ucTrack_lv.Name = "ucTrack_lv";
            this.ucTrack_lv.Size = new System.Drawing.Size(313, 21);
            this.ucTrack_lv.TabIndex = 70;
            this.ucTrack_lv.Text = "ucTrackBar1";
            this.ucTrack_lv.TipsFormat = null;
            this.ucTrack_lv.Value = 400F;
            this.ucTrack_lv.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrack_lv.ValueChanged += new System.EventHandler(this.ucTrack_lv_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(239, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 74;
            this.label8.Text = "Target Lv:";
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(757, 366);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_lv_down);
            this.Controls.Add(this.label_lv_add);
            this.Controls.Add(this.label_lv);
            this.Controls.Add(this.ucTrack_lv);
            this.Controls.Add(this.label_errlv);
            this.Controls.Add(this.ucTextBox_lv);
            this.Controls.Add(this.label_eerxy);
            this.Controls.Add(this.ucTextBox_xy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucSwitch1);
            this.Controls.Add(this.label_mode);
            this.Controls.Add(this.lbl_y_down);
            this.Controls.Add(this.lbl_y_add);
            this.Controls.Add(this.lbl_x_down);
            this.Controls.Add(this.lbl_x_add);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucBtnExt1);
            this.Controls.Add(this.ucBtn_set);
            this.Controls.Add(this.ucTrack_y);
            this.Controls.Add(this.ucTrack_x);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ColorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorForm";
            this.Load += new System.EventHandler(this.ColorForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private HZH_Controls.Controls.UCTrackBar ucTrack_x;
        private HZH_Controls.Controls.UCTrackBar ucTrack_y;
        private HZH_Controls.Controls.UCBtnExt ucBtn_set;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_y;
        private System.Windows.Forms.Label lbl_x_down;
        private System.Windows.Forms.Label lbl_x_add;
        private System.Windows.Forms.Label lbl_y_down;
        private System.Windows.Forms.Label lbl_y_add;
        private System.Windows.Forms.Label label_mode;
        private HZH_Controls.Controls.UCSwitch ucSwitch1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_eerxy;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_xy;
        private System.Windows.Forms.Label label_errlv;
        private HZH_Controls.Controls.UCTextBoxEx ucTextBox_lv;
        private System.Windows.Forms.Label label_lv_down;
        private System.Windows.Forms.Label label_lv_add;
        private System.Windows.Forms.Label label_lv;
        private HZH_Controls.Controls.UCTrackBar ucTrack_lv;
        private System.Windows.Forms.Label label8;
    }
}