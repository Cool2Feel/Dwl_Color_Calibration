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
            this.ucTrack_x.Location = new System.Drawing.Point(373, 87);
            this.ucTrack_x.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_x.MaxValue = 0.8F;
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
            this.ucTrack_y.Location = new System.Drawing.Point(372, 123);
            this.ucTrack_y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucTrack_y.MaxValue = 0.8F;
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
            this.ucBtn_set.BackColor = System.Drawing.Color.White;
            this.ucBtn_set.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_set.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtn_set.BtnText = "OK";
            this.ucBtn_set.ConerRadius = 10;
            this.ucBtn_set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_set.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtn_set.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.IsRadius = true;
            this.ucBtn_set.IsShowRect = false;
            this.ucBtn_set.IsShowTips = false;
            this.ucBtn_set.Location = new System.Drawing.Point(548, 262);
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
            this.ucBtnExt1.BackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtnExt1.BtnText = "Cancle";
            this.ucBtnExt1.ConerRadius = 10;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = false;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(384, 262);
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
            this.label1.Location = new System.Drawing.Point(246, 88);
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
            this.label2.Location = new System.Drawing.Point(246, 124);
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
            this.label_x.Location = new System.Drawing.Point(317, 88);
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
            this.label_y.Location = new System.Drawing.Point(320, 124);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(49, 19);
            this.label_y.TabIndex = 29;
            this.label_y.Text = "0.293";
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(710, 366);
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
    }
}