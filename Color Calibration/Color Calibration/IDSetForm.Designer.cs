namespace Color_Calibration
{
    partial class IDSetForm
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
            this.ucStep_set = new HZH_Controls.Controls.UCStep();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSwitch_sn = new HZH_Controls.Controls.UCSwitch();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.ucSwitch_id = new HZH_Controls.Controls.UCSwitch();
            this.ucComVM = new HZH_Controls.Controls.UCCombox();
            this.ucComHM = new HZH_Controls.Controls.UCCombox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucNumTextBox1 = new HZH_Controls.Controls.UCNumTextBox();
            this.ucBtn_setid = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnImg1 = new HZH_Controls.Controls.UCBtnImg();
            this.SuspendLayout();
            // 
            // ucStep_set
            // 
            this.ucStep_set.BackColor = System.Drawing.Color.Transparent;
            this.ucStep_set.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucStep_set.ImgCompleted = null;
            this.ucStep_set.LineWidth = 3;
            this.ucStep_set.Location = new System.Drawing.Point(108, 28);
            this.ucStep_set.Name = "ucStep_set";
            this.ucStep_set.Size = new System.Drawing.Size(565, 71);
            this.ucStep_set.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucStep_set.StepFontColor = System.Drawing.Color.White;
            this.ucStep_set.StepForeColor = System.Drawing.Color.Purple;
            this.ucStep_set.StepIndex = 0;
            this.ucStep_set.Steps = new string[] {
        "step1",
        "step2",
        "step3"};
            this.ucStep_set.StepWidth = 35;
            this.ucStep_set.TabIndex = 0;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(140, 112);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(500, 3);
            this.ucSplitLine_H1.TabIndex = 1;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucSwitch_sn
            // 
            this.ucSwitch_sn.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch_sn.Checked = false;
            this.ucSwitch_sn.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch_sn.Location = new System.Drawing.Point(75, 287);
            this.ucSwitch_sn.Name = "ucSwitch_sn";
            this.ucSwitch_sn.Size = new System.Drawing.Size(83, 31);
            this.ucSwitch_sn.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch_sn.TabIndex = 2;
            this.ucSwitch_sn.Texts = null;
            this.ucSwitch_sn.TrueColor = System.Drawing.Color.Purple;
            this.ucSwitch_sn.Click += new System.EventHandler(this.ucSwitch_sn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Purple;
            this.richTextBox1.Location = new System.Drawing.Point(47, 130);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(162, 130);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "step 1:                           打开(或关闭)显示所有拼接的SN（序列号），查看对应的信息。    ";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox2.ForeColor = System.Drawing.Color.Purple;
            this.richTextBox2.Location = new System.Drawing.Point(301, 122);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(181, 130);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "step 2:                              根据每个屏幕显示的SN（序列号）和当前屏幕的位置，在编辑框输入，依次进行ID号的绑定。";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox3.ForeColor = System.Drawing.Color.Purple;
            this.richTextBox3.Location = new System.Drawing.Point(555, 130);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(162, 130);
            this.richTextBox3.TabIndex = 5;
            this.richTextBox3.Text = "step 3:                           打开(或关闭)显示所有拼接的绑定后ID号进行检查，确认所有的屏幕全部设置完成。";
            // 
            // ucSwitch_id
            // 
            this.ucSwitch_id.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch_id.Checked = false;
            this.ucSwitch_id.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ucSwitch_id.Location = new System.Drawing.Point(605, 287);
            this.ucSwitch_id.Name = "ucSwitch_id";
            this.ucSwitch_id.Size = new System.Drawing.Size(83, 31);
            this.ucSwitch_id.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch_id.TabIndex = 6;
            this.ucSwitch_id.Texts = null;
            this.ucSwitch_id.TrueColor = System.Drawing.Color.Purple;
            this.ucSwitch_id.Click += new System.EventHandler(this.ucSwitch_id_Click);
            // 
            // ucComVM
            // 
            this.ucComVM.BackColor = System.Drawing.Color.Transparent;
            this.ucComVM.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComVM.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ucComVM.ConerRadius = 5;
            this.ucComVM.DropPanelHeight = -1;
            this.ucComVM.FillColor = System.Drawing.Color.White;
            this.ucComVM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucComVM.IsRadius = true;
            this.ucComVM.IsShowRect = false;
            this.ucComVM.ItemWidth = 38;
            this.ucComVM.Location = new System.Drawing.Point(483, 306);
            this.ucComVM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComVM.Name = "ucComVM";
            this.ucComVM.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucComVM.RectWidth = 1;
            this.ucComVM.SelectedIndex = -1;
            this.ucComVM.SelectedValue = "";
            this.ucComVM.Size = new System.Drawing.Size(88, 24);
            this.ucComVM.Source = null;
            this.ucComVM.TabIndex = 32;
            this.ucComVM.TextValue = null;
            this.ucComVM.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // ucComHM
            // 
            this.ucComHM.BackColor = System.Drawing.Color.Transparent;
            this.ucComHM.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComHM.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ucComHM.ConerRadius = 5;
            this.ucComHM.DropPanelHeight = -1;
            this.ucComHM.FillColor = System.Drawing.Color.White;
            this.ucComHM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucComHM.IsRadius = true;
            this.ucComHM.IsShowRect = false;
            this.ucComHM.ItemWidth = 38;
            this.ucComHM.Location = new System.Drawing.Point(299, 306);
            this.ucComHM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComHM.Name = "ucComHM";
            this.ucComHM.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucComHM.RectWidth = 1;
            this.ucComHM.SelectedIndex = -1;
            this.ucComHM.SelectedValue = "";
            this.ucComHM.Size = new System.Drawing.Size(88, 24);
            this.ucComHM.Source = null;
            this.ucComHM.TabIndex = 31;
            this.ucComHM.TextValue = null;
            this.ucComHM.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(392, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "V Moniters:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(205, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "H Moniters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(236, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "SN Moniters:";
            // 
            // ucNumTextBox1
            // 
            this.ucNumTextBox1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucNumTextBox1.InputType = HZH_Controls.TextInputType.Number;
            this.ucNumTextBox1.IsNumCanInput = true;
            this.ucNumTextBox1.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
            this.ucNumTextBox1.Location = new System.Drawing.Point(350, 258);
            this.ucNumTextBox1.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ucNumTextBox1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucNumTextBox1.Name = "ucNumTextBox1";
            this.ucNumTextBox1.Num = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ucNumTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.ucNumTextBox1.Size = new System.Drawing.Size(175, 37);
            this.ucNumTextBox1.TabIndex = 34;
            // 
            // ucBtn_setid
            // 
            this.ucBtn_setid.BackColor = System.Drawing.Color.White;
            this.ucBtn_setid.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_setid.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_setid.BtnForeColor = System.Drawing.Color.Purple;
            this.ucBtn_setid.BtnText = "Set";
            this.ucBtn_setid.ConerRadius = 10;
            this.ucBtn_setid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_setid.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtn_setid.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_setid.IsRadius = true;
            this.ucBtn_setid.IsShowRect = true;
            this.ucBtn_setid.IsShowTips = false;
            this.ucBtn_setid.Location = new System.Drawing.Point(320, 354);
            this.ucBtn_setid.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_setid.Name = "ucBtn_setid";
            this.ucBtn_setid.RectColor = System.Drawing.Color.Purple;
            this.ucBtn_setid.RectWidth = 2;
            this.ucBtn_setid.Size = new System.Drawing.Size(139, 36);
            this.ucBtn_setid.TabIndex = 35;
            this.ucBtn_setid.TabStop = false;
            this.ucBtn_setid.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_setid.TipsText = "";
            this.ucBtn_setid.BtnClick += new System.EventHandler(this.ucBtn_setid_BtnClick);
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
            this.ucBtnImg1.Location = new System.Drawing.Point(740, 9);
            this.ucBtnImg1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnImg1.Name = "ucBtnImg1";
            this.ucBtnImg1.RectColor = System.Drawing.Color.White;
            this.ucBtnImg1.RectWidth = 1;
            this.ucBtnImg1.Size = new System.Drawing.Size(30, 30);
            this.ucBtnImg1.TabIndex = 36;
            this.ucBtnImg1.TabStop = false;
            this.ucBtnImg1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucBtnImg1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnImg1.TipsText = "";
            this.ucBtnImg1.BtnClick += new System.EventHandler(this.ucBtnImg1_Click);
            // 
            // IDSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(779, 421);
            this.Controls.Add(this.ucBtnImg1);
            this.Controls.Add(this.ucBtn_setid);
            this.Controls.Add(this.ucNumTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucComVM);
            this.Controls.Add(this.ucComHM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucSwitch_id);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ucSwitch_sn);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Controls.Add(this.ucStep_set);
            this.Name = "IDSetForm";
            this.Text = "IDSetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCStep ucStep_set;
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private HZH_Controls.Controls.UCSwitch ucSwitch_sn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private HZH_Controls.Controls.UCSwitch ucSwitch_id;
        private HZH_Controls.Controls.UCCombox ucComVM;
        private HZH_Controls.Controls.UCCombox ucComHM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private HZH_Controls.Controls.UCNumTextBox ucNumTextBox1;
        private HZH_Controls.Controls.UCBtnExt ucBtn_setid;
        private HZH_Controls.Controls.UCBtnImg ucBtnImg1;
    }
}