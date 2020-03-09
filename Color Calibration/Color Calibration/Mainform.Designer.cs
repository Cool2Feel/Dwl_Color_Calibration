namespace Color_Calibration
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Main_content = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.debug_lable = new System.Windows.Forms.ToolStripStatusLabel();
            this.com_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.meter_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.color_temp = new System.Windows.Forms.ToolStripStatusLabel();
            this.version = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Btn_control = new HZH_Controls.Controls.UCBtnFillet();
            this.Btn_adjust = new HZH_Controls.Controls.UCBtnFillet();
            this.Btn_set = new HZH_Controls.Controls.UCBtnFillet();
            this.Btn_color = new HZH_Controls.Controls.UCBtnFillet();
            this.ucBtnImg1 = new HZH_Controls.Controls.UCBtnImg();
            this.Title_center = new HZH_Controls.Controls.UCBtnImg();
            this.Main_pic = new System.Windows.Forms.PictureBox();
            this.Title_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
            this.Title_panel.Controls.Add(this.label2);
            this.Title_panel.Controls.Add(this.ucBtnImg1);
            this.Title_panel.Controls.Add(this.Title_center);
            this.Title_panel.Controls.Add(this.label1);
            this.Title_panel.Controls.Add(this.Main_pic);
            this.Title_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title_panel.Location = new System.Drawing.Point(0, 0);
            this.Title_panel.Name = "Title_panel";
            this.Title_panel.Size = new System.Drawing.Size(917, 67);
            this.Title_panel.TabIndex = 0;
            this.Title_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_panel_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(141, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "KTC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(139, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color Calibration";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.Main_content);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 446);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_control, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_adjust, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_set, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_color, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 68);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Main_content
            // 
            this.Main_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_content.Location = new System.Drawing.Point(1, 70);
            this.Main_content.Name = "Main_content";
            this.Main_content.Size = new System.Drawing.Size(915, 375);
            this.Main_content.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debug_lable,
            this.com_status,
            this.meter_status,
            this.color_temp,
            this.version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(917, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // debug_lable
            // 
            this.debug_lable.AutoSize = false;
            this.debug_lable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.debug_lable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.debug_lable.ForeColor = System.Drawing.Color.Black;
            this.debug_lable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.debug_lable.Name = "debug_lable";
            this.debug_lable.Size = new System.Drawing.Size(30, 17);
            this.debug_lable.Text = "∨";
            this.debug_lable.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.debug_lable.Click += new System.EventHandler(this.debug_lable_Click);
            this.debug_lable.MouseEnter += new System.EventHandler(this.debug_lable_MouseEnter);
            // 
            // com_status
            // 
            this.com_status.AutoSize = false;
            this.com_status.BackColor = System.Drawing.Color.Transparent;
            this.com_status.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.com_status.Name = "com_status";
            this.com_status.Size = new System.Drawing.Size(200, 17);
            this.com_status.Text = "SerialPort : COM6 is Disconnected";
            // 
            // meter_status
            // 
            this.meter_status.AutoSize = false;
            this.meter_status.BackColor = System.Drawing.Color.Transparent;
            this.meter_status.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.meter_status.Name = "meter_status";
            this.meter_status.Size = new System.Drawing.Size(300, 17);
            this.meter_status.Text = "Calibration : i1D3 is Disconnected";
            // 
            // color_temp
            // 
            this.color_temp.AutoSize = false;
            this.color_temp.BackColor = System.Drawing.Color.Transparent;
            this.color_temp.Name = "color_temp";
            this.color_temp.Size = new System.Drawing.Size(260, 17);
            this.color_temp.Text = "Target -> Lv : 250  x ： 0.283  y : 0.294";
            // 
            // version
            // 
            this.version.Margin = new System.Windows.Forms.Padding(52, 3, 0, 2);
            this.version.Name = "version";
            this.version.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.version.Size = new System.Drawing.Size(42, 17);
            this.version.Text = "V 1.1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Btn_control
            // 
            this.Btn_control.BackColor = System.Drawing.Color.Transparent;
            this.Btn_control.BtnImage = global::Color_Calibration.Properties.Resources.controlList;
            this.Btn_control.BtnText = "Control             ";
            this.Btn_control.ConerRadius = 5;
            this.Btn_control.FillColor = System.Drawing.Color.White;
            this.Btn_control.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Btn_control.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Btn_control.IsRadius = false;
            this.Btn_control.IsShowRect = false;
            this.Btn_control.Location = new System.Drawing.Point(688, 0);
            this.Btn_control.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_control.Name = "Btn_control";
            this.Btn_control.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_control.RectWidth = 1;
            this.Btn_control.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_control.Size = new System.Drawing.Size(227, 66);
            this.Btn_control.TabIndex = 3;
            this.Btn_control.BtnClick += new System.EventHandler(this.Btn_control_BtnClick);
            // 
            // Btn_adjust
            // 
            this.Btn_adjust.BackColor = System.Drawing.Color.Transparent;
            this.Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;
            this.Btn_adjust.BtnText = "Adjustment         ";
            this.Btn_adjust.ConerRadius = 5;
            this.Btn_adjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_adjust.FillColor = System.Drawing.Color.White;
            this.Btn_adjust.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Btn_adjust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Btn_adjust.IsRadius = false;
            this.Btn_adjust.IsShowRect = false;
            this.Btn_adjust.Location = new System.Drawing.Point(459, 0);
            this.Btn_adjust.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_adjust.Name = "Btn_adjust";
            this.Btn_adjust.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_adjust.RectWidth = 1;
            this.Btn_adjust.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_adjust.Size = new System.Drawing.Size(227, 66);
            this.Btn_adjust.TabIndex = 2;
            this.Btn_adjust.BtnClick += new System.EventHandler(this.Btn_adjust_BtnClick);
            // 
            // Btn_set
            // 
            this.Btn_set.BackColor = System.Drawing.Color.White;
            this.Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;
            this.Btn_set.BtnText = "Set  COM          ";
            this.Btn_set.ConerRadius = 5;
            this.Btn_set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_set.FillColor = System.Drawing.Color.White;
            this.Btn_set.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_set.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Btn_set.IsRadius = false;
            this.Btn_set.IsShowRect = false;
            this.Btn_set.Location = new System.Drawing.Point(1, 0);
            this.Btn_set.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_set.Name = "Btn_set";
            this.Btn_set.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_set.RectWidth = 1;
            this.Btn_set.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_set.Size = new System.Drawing.Size(227, 66);
            this.Btn_set.TabIndex = 0;
            this.Btn_set.BtnClick += new System.EventHandler(this.Btn_set_BtnClick);
            // 
            // Btn_color
            // 
            this.Btn_color.BackColor = System.Drawing.Color.Transparent;
            this.Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;
            this.Btn_color.BtnText = "Color Calibration  ";
            this.Btn_color.ConerRadius = 5;
            this.Btn_color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_color.FillColor = System.Drawing.Color.White;
            this.Btn_color.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_color.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Btn_color.IsRadius = false;
            this.Btn_color.IsShowRect = false;
            this.Btn_color.Location = new System.Drawing.Point(230, 0);
            this.Btn_color.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_color.Name = "Btn_color";
            this.Btn_color.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_color.RectWidth = 1;
            this.Btn_color.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_color.Size = new System.Drawing.Size(227, 66);
            this.Btn_color.TabIndex = 1;
            this.Btn_color.BtnClick += new System.EventHandler(this.Btn_color_BtnClick);
            // 
            // ucBtnImg1
            // 
            this.ucBtnImg1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnImg1.BackColor = System.Drawing.Color.White;
            this.ucBtnImg1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnImg1.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.ucBtnImg1.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ucBtnImg1.BtnText = "";
            this.ucBtnImg1.ConerRadius = 5;
            this.ucBtnImg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnImg1.FillColor = System.Drawing.Color.White;
            this.ucBtnImg1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnImg1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ucBtnImg1.Image = global::Color_Calibration.Properties.Resources.close;
            this.ucBtnImg1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucBtnImg1.ImageFontIcons = null;
            this.ucBtnImg1.IsRadius = true;
            this.ucBtnImg1.IsShowRect = true;
            this.ucBtnImg1.IsShowTips = false;
            this.ucBtnImg1.Location = new System.Drawing.Point(867, 21);
            this.ucBtnImg1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnImg1.Name = "ucBtnImg1";
            this.ucBtnImg1.RectColor = System.Drawing.Color.White;
            this.ucBtnImg1.RectWidth = 1;
            this.ucBtnImg1.Size = new System.Drawing.Size(30, 30);
            this.ucBtnImg1.TabIndex = 3;
            this.ucBtnImg1.TabStop = false;
            this.ucBtnImg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucBtnImg1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnImg1.TipsText = "";
            this.ucBtnImg1.BtnClick += new System.EventHandler(this.ucBtnImg1_BtnClick);
            // 
            // Title_center
            // 
            this.Title_center.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Title_center.BackColor = System.Drawing.Color.White;
            this.Title_center.BtnBackColor = System.Drawing.Color.White;
            this.Title_center.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.Title_center.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Title_center.BtnText = "";
            this.Title_center.ConerRadius = 5;
            this.Title_center.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Title_center.FillColor = System.Drawing.Color.White;
            this.Title_center.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Title_center.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Title_center.Image = global::Color_Calibration.Properties.Resources.Calib;
            this.Title_center.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title_center.ImageFontIcons = null;
            this.Title_center.IsRadius = true;
            this.Title_center.IsShowRect = true;
            this.Title_center.IsShowTips = false;
            this.Title_center.Location = new System.Drawing.Point(819, 21);
            this.Title_center.Margin = new System.Windows.Forms.Padding(0);
            this.Title_center.Name = "Title_center";
            this.Title_center.RectColor = System.Drawing.Color.White;
            this.Title_center.RectWidth = 1;
            this.Title_center.Size = new System.Drawing.Size(30, 30);
            this.Title_center.TabIndex = 2;
            this.Title_center.TabStop = false;
            this.Title_center.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title_center.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.Title_center.TipsText = "";
            this.Title_center.BtnClick += new System.EventHandler(this.Title_center_BtnClick);
            // 
            // Main_pic
            // 
            this.Main_pic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Main_pic.BackgroundImage = global::Color_Calibration.Properties.Resources.logo;
            this.Main_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Main_pic.Location = new System.Drawing.Point(0, 0);
            this.Main_pic.Name = "Main_pic";
            this.Main_pic.Size = new System.Drawing.Size(136, 67);
            this.Main_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Main_pic.TabIndex = 0;
            this.Main_pic.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(917, 536);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Title_panel.ResumeLayout(false);
            this.Title_panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Title_panel;
        private System.Windows.Forms.PictureBox Main_pic;
        private HZH_Controls.Controls.UCBtnImg ucBtnImg1;
        private HZH_Controls.Controls.UCBtnImg Title_center;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private HZH_Controls.Controls.UCBtnFillet Btn_set;
        private System.Windows.Forms.Panel Main_content;
        private HZH_Controls.Controls.UCBtnFillet Btn_adjust;
        private HZH_Controls.Controls.UCBtnFillet Btn_color;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel version;
        public System.Windows.Forms.ToolStripStatusLabel meter_status;
        public System.Windows.Forms.ToolStripStatusLabel com_status;
        private System.Windows.Forms.ToolStripStatusLabel color_temp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private HZH_Controls.Controls.UCBtnFillet Btn_control;
        private System.Windows.Forms.ToolStripStatusLabel debug_lable;
    }
}

