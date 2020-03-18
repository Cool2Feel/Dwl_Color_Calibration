namespace Color_Calibration.Control
{
    partial class Form_Net
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.eip3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eip2 = new System.Windows.Forms.TextBox();
            this.eip4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sip1 = new System.Windows.Forms.TextBox();
            this.sip3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.eip1 = new System.Windows.Forms.TextBox();
            this.sip2 = new System.Windows.Forms.TextBox();
            this.sip4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_port = new System.Windows.Forms.Label();
            this.emi_port = new EASkins.Emi_NumericUpDown();
            this.label_loop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_Create = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.eip3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.eip2);
            this.panel2.Controls.Add(this.eip4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.sip1);
            this.panel2.Controls.Add(this.sip3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.eip1);
            this.panel2.Controls.Add(this.sip2);
            this.panel2.Controls.Add(this.sip4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(14, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 150);
            this.panel2.TabIndex = 22;
            // 
            // eip3
            // 
            this.eip3.Location = new System.Drawing.Point(127, 109);
            this.eip3.Name = "eip3";
            this.eip3.Size = new System.Drawing.Size(43, 23);
            this.eip3.TabIndex = 7;
            this.eip3.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start IP address：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "End IP address：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = ".";
            // 
            // eip2
            // 
            this.eip2.Location = new System.Drawing.Point(71, 109);
            this.eip2.Name = "eip2";
            this.eip2.Size = new System.Drawing.Size(43, 23);
            this.eip2.TabIndex = 6;
            this.eip2.Text = "168";
            // 
            // eip4
            // 
            this.eip4.Location = new System.Drawing.Point(183, 109);
            this.eip4.Name = "eip4";
            this.eip4.Size = new System.Drawing.Size(43, 23);
            this.eip4.TabIndex = 8;
            this.eip4.Text = "254";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = ".";
            // 
            // sip1
            // 
            this.sip1.Location = new System.Drawing.Point(15, 42);
            this.sip1.Name = "sip1";
            this.sip1.Size = new System.Drawing.Size(43, 23);
            this.sip1.TabIndex = 1;
            this.sip1.Text = "192";
            // 
            // sip3
            // 
            this.sip3.Location = new System.Drawing.Point(127, 42);
            this.sip3.Name = "sip3";
            this.sip3.Size = new System.Drawing.Size(43, 23);
            this.sip3.TabIndex = 3;
            this.sip3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = ".";
            // 
            // eip1
            // 
            this.eip1.Location = new System.Drawing.Point(15, 109);
            this.eip1.Name = "eip1";
            this.eip1.Size = new System.Drawing.Size(43, 23);
            this.eip1.TabIndex = 5;
            this.eip1.Text = "192";
            // 
            // sip2
            // 
            this.sip2.Location = new System.Drawing.Point(71, 42);
            this.sip2.Name = "sip2";
            this.sip2.Size = new System.Drawing.Size(43, 23);
            this.sip2.TabIndex = 2;
            this.sip2.Text = "168";
            // 
            // sip4
            // 
            this.sip4.Location = new System.Drawing.Point(183, 42);
            this.sip4.Name = "sip4";
            this.sip4.Size = new System.Drawing.Size(43, 23);
            this.sip4.TabIndex = 4;
            this.sip4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = ".";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(172, 21);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "Specified Address Range";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 21);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Auto Search (LAN)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSend.Location = new System.Drawing.Point(164, 275);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(92, 32);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Start Search";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_port);
            this.groupBox1.Controls.Add(this.emi_port);
            this.groupBox1.Controls.Add(this.label_loop);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(38, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 313);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search method";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.ForeColor = System.Drawing.Color.Black;
            this.label_port.Location = new System.Drawing.Point(171, 37);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(105, 17);
            this.label_port.TabIndex = 26;
            this.label_port.Text = "Destination port:";
            this.label_port.Visible = false;
            // 
            // emi_port
            // 
            this.emi_port.BackColor = System.Drawing.Color.Transparent;
            this.emi_port.Font = new System.Drawing.Font("Tahoma", 11F);
            this.emi_port.ForeColor = System.Drawing.Color.Black;
            this.emi_port.Location = new System.Drawing.Point(192, 62);
            this.emi_port.Maximum = ((long)(65535));
            this.emi_port.Minimum = ((long)(1024));
            this.emi_port.MinimumSize = new System.Drawing.Size(62, 28);
            this.emi_port.Name = "emi_port";
            this.emi_port.Size = new System.Drawing.Size(82, 28);
            this.emi_port.TabIndex = 25;
            this.emi_port.TextAlignment = EASkins.Emi_NumericUpDown._TextAlignment.Near;
            this.emi_port.Value = ((long)(4352));
            this.emi_port.Visible = false;
            // 
            // label_loop
            // 
            this.label_loop.AutoSize = true;
            this.label_loop.Enabled = false;
            this.label_loop.Location = new System.Drawing.Point(18, 256);
            this.label_loop.Name = "label_loop";
            this.label_loop.Size = new System.Drawing.Size(0, 17);
            this.label_loop.TabIndex = 24;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(20, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 242);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(273, 242);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IP Add.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 110;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mac.";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Select All / Not Select";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(339, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 313);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bt_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_Cancel.Location = new System.Drawing.Point(541, 354);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(109, 35);
            this.bt_Cancel.TabIndex = 26;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_Create
            // 
            this.bt_Create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(38)))), ((int)(((byte)(143)))));
            this.bt_Create.ForeColor = System.Drawing.Color.White;
            this.bt_Create.Location = new System.Drawing.Point(339, 354);
            this.bt_Create.Name = "bt_Create";
            this.bt_Create.Size = new System.Drawing.Size(109, 35);
            this.bt_Create.TabIndex = 25;
            this.bt_Create.Text = "Create";
            this.bt_Create.UseVisualStyleBackColor = false;
            this.bt_Create.Click += new System.EventHandler(this.bt_Craet_Click);
            // 
            // Form_Net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(699, 401);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Create);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_Net";
            this.Text = "Form_Net";
            this.Load += new System.EventHandler(this.Form_Net_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox eip3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eip2;
        private System.Windows.Forms.TextBox eip4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sip1;
        private System.Windows.Forms.TextBox sip3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox eip1;
        private System.Windows.Forms.TextBox sip2;
        private System.Windows.Forms.TextBox sip4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_loop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_Create;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private EASkins.Emi_NumericUpDown emi_port;
        private System.Windows.Forms.Label label_port;
    }
}