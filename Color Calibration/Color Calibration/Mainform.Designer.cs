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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Title_panel = new System.Windows.Forms.Panel();
            this.ucBtnImg1 = new HZH_Controls.Controls.UCBtnImg();
            this.Title_center = new HZH_Controls.Controls.UCBtnImg();
            this.label1 = new System.Windows.Forms.Label();
            this.Main_pic = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_adjust = new HZH_Controls.Controls.UCBtnFillet();
            this.Btn_set = new HZH_Controls.Controls.UCBtnFillet();
            this.Btn_color = new HZH_Controls.Controls.UCBtnFillet();
            this.Main_content = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.version = new System.Windows.Forms.ToolStripStatusLabel();
            this.Title_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pic)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title_panel
            // 
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(139, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color Calibration";
            // 
            // Main_pic
            // 
            this.Main_pic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Main_pic.Image = global::Color_Calibration.Properties.Resources.logo;
            this.Main_pic.Location = new System.Drawing.Point(0, 0);
            this.Main_pic.Name = "Main_pic";
            this.Main_pic.Size = new System.Drawing.Size(136, 67);
            this.Main_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Main_pic.TabIndex = 0;
            this.Main_pic.TabStop = false;
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_adjust, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_set, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_color, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 68);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Btn_adjust
            // 
            this.Btn_adjust.BackColor = System.Drawing.Color.Transparent;
            this.Btn_adjust.BtnImage = global::Color_Calibration.Properties.Resources.adjust;
            this.Btn_adjust.BtnText = "Adjustment                  ";
            this.Btn_adjust.ConerRadius = 5;
            this.Btn_adjust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_adjust.FillColor = System.Drawing.Color.White;
            this.Btn_adjust.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Btn_adjust.ForeColor = System.Drawing.Color.Purple;
            this.Btn_adjust.IsRadius = false;
            this.Btn_adjust.IsShowRect = false;
            this.Btn_adjust.Location = new System.Drawing.Point(609, 0);
            this.Btn_adjust.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_adjust.Name = "Btn_adjust";
            this.Btn_adjust.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_adjust.RectWidth = 1;
            this.Btn_adjust.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_adjust.Size = new System.Drawing.Size(307, 66);
            this.Btn_adjust.TabIndex = 2;
            this.Btn_adjust.BtnClick += new System.EventHandler(this.Btn_adjust_BtnClick);
            // 
            // Btn_set
            // 
            this.Btn_set.BackColor = System.Drawing.Color.White;
            this.Btn_set.BtnImage = global::Color_Calibration.Properties.Resources.设置;
            this.Btn_set.BtnText = "Set  COM                      ";
            this.Btn_set.ConerRadius = 5;
            this.Btn_set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_set.FillColor = System.Drawing.Color.White;
            this.Btn_set.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_set.ForeColor = System.Drawing.Color.Purple;
            this.Btn_set.IsRadius = false;
            this.Btn_set.IsShowRect = false;
            this.Btn_set.Location = new System.Drawing.Point(1, 0);
            this.Btn_set.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_set.Name = "Btn_set";
            this.Btn_set.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_set.RectWidth = 1;
            this.Btn_set.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_set.Size = new System.Drawing.Size(302, 66);
            this.Btn_set.TabIndex = 0;
            this.Btn_set.BtnClick += new System.EventHandler(this.Btn_set_BtnClick);
            // 
            // Btn_color
            // 
            this.Btn_color.BackColor = System.Drawing.Color.Transparent;
            this.Btn_color.BtnImage = global::Color_Calibration.Properties.Resources.calibration;
            this.Btn_color.BtnText = "Color Calibration          ";
            this.Btn_color.ConerRadius = 5;
            this.Btn_color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_color.FillColor = System.Drawing.Color.White;
            this.Btn_color.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_color.ForeColor = System.Drawing.Color.Purple;
            this.Btn_color.IsRadius = false;
            this.Btn_color.IsShowRect = false;
            this.Btn_color.Location = new System.Drawing.Point(305, 0);
            this.Btn_color.Margin = new System.Windows.Forms.Padding(1, 0, 1, 2);
            this.Btn_color.Name = "Btn_color";
            this.Btn_color.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Btn_color.RectWidth = 1;
            this.Btn_color.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Btn_color.Size = new System.Drawing.Size(302, 66);
            this.Btn_color.TabIndex = 1;
            this.Btn_color.BtnClick += new System.EventHandler(this.Btn_color_BtnClick);
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
            this.version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(917, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // version
            // 
            this.version.Name = "version";
            this.version.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.version.Size = new System.Drawing.Size(42, 17);
            this.version.Text = "V 0.1";
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
            this.Title_panel.ResumeLayout(false);
            this.Title_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_pic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}

