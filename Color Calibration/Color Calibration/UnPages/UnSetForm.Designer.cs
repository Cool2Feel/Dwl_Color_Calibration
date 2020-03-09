namespace Color_Calibration.UnPages
{
    partial class UnSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnSetForm));
            this.label_cp = new System.Windows.Forms.Label();
            this.label_cm = new System.Windows.Forms.Label();
            this.label_mm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ucComTL = new HZH_Controls.Controls.UCCombox();
            this.ucComTC = new HZH_Controls.Controls.UCCombox();
            this.ucComTG = new HZH_Controls.Controls.UCCombox();
            this.ucComVM = new HZH_Controls.Controls.UCCombox();
            this.ucComHM = new HZH_Controls.Controls.UCCombox();
            this.Uncom_model = new HZH_Controls.Controls.UCCombox();
            this.Uncom_meter = new HZH_Controls.Controls.UCCombox();
            this.Uncom_port = new HZH_Controls.Controls.UCCombox();
            this.ucBtn_set = new HZH_Controls.Controls.UCBtnExt();
            this.ucSplitLine_H3 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H2 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucSplitLine_H1 = new HZH_Controls.Controls.UCSplitLine_H();
            this.ucBtn_id = new HZH_Controls.Controls.UCBtnExt();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_connect = new EASkins.Ami_Button_1();
            this.Unbt_meter = new EASkins.Ami_Button_1();
            this.SuspendLayout();
            // 
            // label_cp
            // 
            this.label_cp.AutoSize = true;
            this.label_cp.BackColor = System.Drawing.Color.Transparent;
            this.label_cp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cp.Location = new System.Drawing.Point(23, 19);
            this.label_cp.Name = "label_cp";
            this.label_cp.Size = new System.Drawing.Size(154, 19);
            this.label_cp.TabIndex = 2;
            this.label_cp.Text = "Communication Port";
            // 
            // label_cm
            // 
            this.label_cm.AutoSize = true;
            this.label_cm.BackColor = System.Drawing.Color.Transparent;
            this.label_cm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cm.Location = new System.Drawing.Point(23, 138);
            this.label_cm.Name = "label_cm";
            this.label_cm.Size = new System.Drawing.Size(92, 19);
            this.label_cm.TabIndex = 5;
            this.label_cm.Text = "Color Meter";
            // 
            // label_mm
            // 
            this.label_mm.AutoSize = true;
            this.label_mm.BackColor = System.Drawing.Color.Transparent;
            this.label_mm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_mm.Location = new System.Drawing.Point(23, 267);
            this.label_mm.Name = "label_mm";
            this.label_mm.Size = new System.Drawing.Size(114, 19);
            this.label_mm.TabIndex = 8;
            this.label_mm.Text = "Monitor Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(690, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "H Moniters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(690, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "V Moniters:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(662, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Target Gamma:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(632, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Target Color Temp.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(641, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Target Luminance:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(643, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Custom Target xy:";
            // 
            // ucComTL
            // 
            this.ucComTL.BackColor = System.Drawing.Color.Transparent;
            this.ucComTL.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTL.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucComTL.ConerRadius = 5;
            this.ucComTL.DropPanelHeight = -1;
            this.ucComTL.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucComTL.IsRadius = true;
            this.ucComTL.IsShowRect = false;
            this.ucComTL.ItemWidth = 114;
            this.ucComTL.Location = new System.Drawing.Point(790, 132);
            this.ucComTL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComTL.Name = "ucComTL";
            this.ucComTL.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTL.RectWidth = 1;
            this.ucComTL.SelectedIndex = -1;
            this.ucComTL.SelectedValue = "";
            this.ucComTL.Size = new System.Drawing.Size(114, 24);
            this.ucComTL.Source = null;
            this.ucComTL.TabIndex = 31;
            this.ucComTL.TextValue = null;
            this.ucComTL.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucComTL.SelectedChangedEvent += new System.EventHandler(this.ucComTL_SelectedChangedEvent);
            // 
            // ucComTC
            // 
            this.ucComTC.BackColor = System.Drawing.Color.Transparent;
            this.ucComTC.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTC.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucComTC.ConerRadius = 5;
            this.ucComTC.DropPanelHeight = -1;
            this.ucComTC.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucComTC.IsRadius = true;
            this.ucComTC.IsShowRect = false;
            this.ucComTC.ItemWidth = 114;
            this.ucComTC.Location = new System.Drawing.Point(790, 96);
            this.ucComTC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComTC.Name = "ucComTC";
            this.ucComTC.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTC.RectWidth = 1;
            this.ucComTC.SelectedIndex = -1;
            this.ucComTC.SelectedValue = "";
            this.ucComTC.Size = new System.Drawing.Size(114, 24);
            this.ucComTC.Source = null;
            this.ucComTC.TabIndex = 30;
            this.ucComTC.TextValue = null;
            this.ucComTC.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucComTC.SelectedChangedEvent += new System.EventHandler(this.ucComTC_SelectedChangedEvent);
            // 
            // ucComTG
            // 
            this.ucComTG.BackColor = System.Drawing.Color.Transparent;
            this.ucComTG.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTG.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucComTG.ConerRadius = 5;
            this.ucComTG.DropPanelHeight = -1;
            this.ucComTG.Enabled = false;
            this.ucComTG.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTG.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucComTG.IsRadius = true;
            this.ucComTG.IsShowRect = false;
            this.ucComTG.ItemWidth = 114;
            this.ucComTG.Location = new System.Drawing.Point(790, 296);
            this.ucComTG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComTG.Name = "ucComTG";
            this.ucComTG.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComTG.RectWidth = 1;
            this.ucComTG.SelectedIndex = -1;
            this.ucComTG.SelectedValue = "";
            this.ucComTG.Size = new System.Drawing.Size(114, 24);
            this.ucComTG.Source = null;
            this.ucComTG.TabIndex = 29;
            this.ucComTG.TextValue = null;
            this.ucComTG.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucComTG.Visible = false;
            // 
            // ucComVM
            // 
            this.ucComVM.BackColor = System.Drawing.Color.Transparent;
            this.ucComVM.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComVM.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucComVM.ConerRadius = 5;
            this.ucComVM.DropPanelHeight = -1;
            this.ucComVM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComVM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucComVM.IsRadius = true;
            this.ucComVM.IsShowRect = false;
            this.ucComVM.ItemWidth = 38;
            this.ucComVM.Location = new System.Drawing.Point(790, 59);
            this.ucComVM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComVM.Name = "ucComVM";
            this.ucComVM.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComVM.RectWidth = 1;
            this.ucComVM.SelectedIndex = -1;
            this.ucComVM.SelectedValue = "";
            this.ucComVM.Size = new System.Drawing.Size(114, 24);
            this.ucComVM.Source = null;
            this.ucComVM.TabIndex = 28;
            this.ucComVM.TextValue = null;
            this.ucComVM.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucComVM.SelectedChangedEvent += new System.EventHandler(this.ucComVM_SelectedChangedEvent);
            // 
            // ucComHM
            // 
            this.ucComHM.BackColor = System.Drawing.Color.Transparent;
            this.ucComHM.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComHM.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ucComHM.ConerRadius = 5;
            this.ucComHM.DropPanelHeight = -1;
            this.ucComHM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComHM.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucComHM.IsRadius = true;
            this.ucComHM.IsShowRect = false;
            this.ucComHM.ItemWidth = 38;
            this.ucComHM.Location = new System.Drawing.Point(790, 25);
            this.ucComHM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComHM.Name = "ucComHM";
            this.ucComHM.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComHM.RectWidth = 1;
            this.ucComHM.SelectedIndex = -1;
            this.ucComHM.SelectedValue = "";
            this.ucComHM.Size = new System.Drawing.Size(114, 24);
            this.ucComHM.Source = null;
            this.ucComHM.TabIndex = 27;
            this.ucComHM.TextValue = null;
            this.ucComHM.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucComHM.SelectedChangedEvent += new System.EventHandler(this.ucComHM_SelectedChangedEvent);
            // 
            // Uncom_model
            // 
            this.Uncom_model.BackColor = System.Drawing.Color.Transparent;
            this.Uncom_model.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_model.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uncom_model.ConerRadius = 5;
            this.Uncom_model.DropPanelHeight = -1;
            this.Uncom_model.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_model.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Uncom_model.IsRadius = true;
            this.Uncom_model.IsShowRect = true;
            this.Uncom_model.ItemWidth = 160;
            this.Uncom_model.Location = new System.Drawing.Point(36, 306);
            this.Uncom_model.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Uncom_model.Name = "Uncom_model";
            this.Uncom_model.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_model.RectWidth = 1;
            this.Uncom_model.SelectedIndex = -1;
            this.Uncom_model.SelectedValue = "";
            this.Uncom_model.Size = new System.Drawing.Size(161, 24);
            this.Uncom_model.Source = null;
            this.Uncom_model.TabIndex = 26;
            this.Uncom_model.TextValue = null;
            this.Uncom_model.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.Uncom_model.SelectedChangedEvent += new System.EventHandler(this.Uncom_model_SelectedChangedEvent);
            // 
            // Uncom_meter
            // 
            this.Uncom_meter.BackColor = System.Drawing.Color.Transparent;
            this.Uncom_meter.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_meter.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uncom_meter.ConerRadius = 5;
            this.Uncom_meter.DropPanelHeight = -1;
            this.Uncom_meter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_meter.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Uncom_meter.IsRadius = true;
            this.Uncom_meter.IsShowRect = true;
            this.Uncom_meter.ItemWidth = 160;
            this.Uncom_meter.Location = new System.Drawing.Point(38, 177);
            this.Uncom_meter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Uncom_meter.Name = "Uncom_meter";
            this.Uncom_meter.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_meter.RectWidth = 1;
            this.Uncom_meter.SelectedIndex = -1;
            this.Uncom_meter.SelectedValue = "";
            this.Uncom_meter.Size = new System.Drawing.Size(161, 24);
            this.Uncom_meter.Source = null;
            this.Uncom_meter.TabIndex = 25;
            this.Uncom_meter.TextValue = null;
            this.Uncom_meter.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            // 
            // Uncom_port
            // 
            this.Uncom_port.BackColor = System.Drawing.Color.Transparent;
            this.Uncom_port.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_port.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Uncom_port.ConerRadius = 5;
            this.Uncom_port.DropPanelHeight = -1;
            this.Uncom_port.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_port.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Uncom_port.IsRadius = true;
            this.Uncom_port.IsShowRect = false;
            this.Uncom_port.ItemWidth = 160;
            this.Uncom_port.Location = new System.Drawing.Point(37, 63);
            this.Uncom_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Uncom_port.Name = "Uncom_port";
            this.Uncom_port.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Uncom_port.RectWidth = 1;
            this.Uncom_port.SelectedIndex = -1;
            this.Uncom_port.SelectedValue = "";
            this.Uncom_port.Size = new System.Drawing.Size(161, 24);
            this.Uncom_port.Source = null;
            this.Uncom_port.TabIndex = 24;
            this.Uncom_port.TextValue = null;
            this.Uncom_port.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            // 
            // ucBtn_set
            // 
            this.ucBtn_set.BackColor = System.Drawing.Color.White;
            this.ucBtn_set.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_set.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucBtn_set.BtnText = "Set";
            this.ucBtn_set.ConerRadius = 10;
            this.ucBtn_set.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_set.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtn_set.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_set.IsRadius = true;
            this.ucBtn_set.IsShowRect = false;
            this.ucBtn_set.IsShowTips = false;
            this.ucBtn_set.Location = new System.Drawing.Point(790, 168);
            this.ucBtn_set.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_set.Name = "ucBtn_set";
            this.ucBtn_set.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_set.RectWidth = 1;
            this.ucBtn_set.Size = new System.Drawing.Size(114, 24);
            this.ucBtn_set.TabIndex = 23;
            this.ucBtn_set.TabStop = false;
            this.ucBtn_set.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_set.TipsText = "";
            this.ucBtn_set.BtnClick += new System.EventHandler(this.ucBtn_set_BtnClick);
            // 
            // ucSplitLine_H3
            // 
            this.ucSplitLine_H3.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H3.Location = new System.Drawing.Point(38, 296);
            this.ucSplitLine_H3.Name = "ucSplitLine_H3";
            this.ucSplitLine_H3.Size = new System.Drawing.Size(160, 2);
            this.ucSplitLine_H3.TabIndex = 7;
            this.ucSplitLine_H3.TabStop = false;
            // 
            // ucSplitLine_H2
            // 
            this.ucSplitLine_H2.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H2.Location = new System.Drawing.Point(38, 167);
            this.ucSplitLine_H2.Name = "ucSplitLine_H2";
            this.ucSplitLine_H2.Size = new System.Drawing.Size(160, 2);
            this.ucSplitLine_H2.TabIndex = 4;
            this.ucSplitLine_H2.TabStop = false;
            // 
            // ucSplitLine_H1
            // 
            this.ucSplitLine_H1.BackColor = System.Drawing.Color.Purple;
            this.ucSplitLine_H1.Location = new System.Drawing.Point(38, 48);
            this.ucSplitLine_H1.Name = "ucSplitLine_H1";
            this.ucSplitLine_H1.Size = new System.Drawing.Size(160, 2);
            this.ucSplitLine_H1.TabIndex = 1;
            this.ucSplitLine_H1.TabStop = false;
            // 
            // ucBtn_id
            // 
            this.ucBtn_id.BackColor = System.Drawing.Color.White;
            this.ucBtn_id.BtnBackColor = System.Drawing.Color.White;
            this.ucBtn_id.BtnFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_id.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(22)))), ((int)(((byte)(124)))));
            this.ucBtn_id.BtnText = "Set";
            this.ucBtn_id.ConerRadius = 10;
            this.ucBtn_id.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtn_id.FillColor = System.Drawing.SystemColors.Control;
            this.ucBtn_id.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtn_id.IsRadius = true;
            this.ucBtn_id.IsShowRect = false;
            this.ucBtn_id.IsShowTips = false;
            this.ucBtn_id.Location = new System.Drawing.Point(790, 208);
            this.ucBtn_id.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtn_id.Name = "ucBtn_id";
            this.ucBtn_id.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.ucBtn_id.RectWidth = 1;
            this.ucBtn_id.Size = new System.Drawing.Size(114, 24);
            this.ucBtn_id.TabIndex = 33;
            this.ucBtn_id.TabStop = false;
            this.ucBtn_id.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtn_id.TipsText = "";
            this.ucBtn_id.BtnClick += new System.EventHandler(this.ucBtn_id_BtnClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(637, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 19);
            this.label7.TabIndex = 32;
            this.label7.Text = "Monitor ID setting:";
            // 
            // Btn_connect
            // 
            this.Btn_connect.BackColor = System.Drawing.Color.Transparent;
            this.Btn_connect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_connect.Image = null;
            this.Btn_connect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_connect.Location = new System.Drawing.Point(37, 95);
            this.Btn_connect.Name = "Btn_connect";
            this.Btn_connect.Size = new System.Drawing.Size(161, 30);
            this.Btn_connect.TabIndex = 34;
            this.Btn_connect.Text = "Connect";
            this.Btn_connect.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Btn_connect.Click += new System.EventHandler(this.Btn_connect_BtnClick);
            // 
            // Unbt_meter
            // 
            this.Unbt_meter.BackColor = System.Drawing.Color.Transparent;
            this.Unbt_meter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unbt_meter.Image = null;
            this.Unbt_meter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Unbt_meter.Location = new System.Drawing.Point(38, 217);
            this.Unbt_meter.Name = "Unbt_meter";
            this.Unbt_meter.Size = new System.Drawing.Size(161, 30);
            this.Unbt_meter.TabIndex = 35;
            this.Unbt_meter.Text = "Connect";
            this.Unbt_meter.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Unbt_meter.Click += new System.EventHandler(this.Unbt_meter_BtnClick);
            // 
            // UnSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Unbt_meter);
            this.Controls.Add(this.Btn_connect);
            this.Controls.Add(this.ucBtn_id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ucComTL);
            this.Controls.Add(this.ucComTC);
            this.Controls.Add(this.ucComTG);
            this.Controls.Add(this.ucComVM);
            this.Controls.Add(this.ucComHM);
            this.Controls.Add(this.Uncom_model);
            this.Controls.Add(this.Uncom_meter);
            this.Controls.Add(this.Uncom_port);
            this.Controls.Add(this.ucBtn_set);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_mm);
            this.Controls.Add(this.ucSplitLine_H3);
            this.Controls.Add(this.label_cm);
            this.Controls.Add(this.ucSplitLine_H2);
            this.Controls.Add(this.label_cp);
            this.Controls.Add(this.ucSplitLine_H1);
            this.Name = "UnSetForm";
            this.Size = new System.Drawing.Size(915, 374);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H1;
        private System.Windows.Forms.Label label_cp;
        private System.Windows.Forms.Label label_cm;
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H2;
        private System.Windows.Forms.Label label_mm;
        private HZH_Controls.Controls.UCSplitLine_H ucSplitLine_H3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private HZH_Controls.Controls.UCBtnExt ucBtn_set;
        private HZH_Controls.Controls.UCCombox Uncom_port;
        private HZH_Controls.Controls.UCCombox Uncom_meter;
        private HZH_Controls.Controls.UCCombox Uncom_model;
        private HZH_Controls.Controls.UCCombox ucComHM;
        private HZH_Controls.Controls.UCCombox ucComVM;
        private HZH_Controls.Controls.UCCombox ucComTG;
        private HZH_Controls.Controls.UCCombox ucComTC;
        private HZH_Controls.Controls.UCCombox ucComTL;
        private HZH_Controls.Controls.UCBtnExt ucBtn_id;
        private System.Windows.Forms.Label label7;
        private EASkins.Ami_Button_1 Btn_connect;
        private EASkins.Ami_Button_1 Unbt_meter;
    }
}
