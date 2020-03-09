namespace Color_Calibration.Control
{
    partial class C_DebugPage
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_print = new System.Windows.Forms.RichTextBox();
            this.debugContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.M_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.M_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.M_clear = new System.Windows.Forms.ToolStripMenuItem();
            this.emi_RichText_receive = new System.Windows.Forms.RichTextBox();
            this.bytesBox = new Color_Calibration.ComLib.BytesBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.debugContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 22);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(649, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Received Data :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(377, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send Data :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_clear);
            this.panel2.Controls.Add(this.button_send);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.bytesBox);
            this.panel2.Controls.Add(this.richTextBox_print);
            this.panel2.Controls.Add(this.emi_RichText_receive);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 123);
            this.panel2.TabIndex = 2;
            // 
            // button_clear
            // 
            this.button_clear.AutoSize = true;
            this.button_clear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_clear.Location = new System.Drawing.Point(204, 77);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 30);
            this.button_clear.TabIndex = 6;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_send
            // 
            this.button_send.AutoSize = true;
            this.button_send.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_send.Location = new System.Drawing.Point(296, 77);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 30);
            this.button_send.TabIndex = 5;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter :";
            // 
            // richTextBox_print
            // 
            this.richTextBox_print.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_print.ContextMenuStrip = this.debugContextMenuStrip;
            this.richTextBox_print.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox_print.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_print.Location = new System.Drawing.Point(377, 0);
            this.richTextBox_print.Name = "richTextBox_print";
            this.richTextBox_print.Size = new System.Drawing.Size(272, 123);
            this.richTextBox_print.TabIndex = 1;
            this.richTextBox_print.Text = "";
            // 
            // debugContextMenuStrip
            // 
            this.debugContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.M_copy,
            this.M_paste,
            this.M_clear});
            this.debugContextMenuStrip.Name = "debugContextMenuStrip";
            this.debugContextMenuStrip.ShowImageMargin = false;
            this.debugContextMenuStrip.Size = new System.Drawing.Size(99, 70);
            this.debugContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.debugContextMenuStrip_Opening);
            // 
            // M_copy
            // 
            this.M_copy.Name = "M_copy";
            this.M_copy.Size = new System.Drawing.Size(98, 22);
            this.M_copy.Text = "(&C)Copy";
            this.M_copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // M_paste
            // 
            this.M_paste.Name = "M_paste";
            this.M_paste.Size = new System.Drawing.Size(98, 22);
            this.M_paste.Text = "(&V)Paste";
            this.M_paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // M_clear
            // 
            this.M_clear.Name = "M_clear";
            this.M_clear.Size = new System.Drawing.Size(98, 22);
            this.M_clear.Text = "(&D)Clear";
            this.M_clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // emi_RichText_receive
            // 
            this.emi_RichText_receive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emi_RichText_receive.ContextMenuStrip = this.debugContextMenuStrip;
            this.emi_RichText_receive.Dock = System.Windows.Forms.DockStyle.Right;
            this.emi_RichText_receive.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.emi_RichText_receive.Location = new System.Drawing.Point(649, 0);
            this.emi_RichText_receive.Name = "emi_RichText_receive";
            this.emi_RichText_receive.Size = new System.Drawing.Size(268, 123);
            this.emi_RichText_receive.TabIndex = 2;
            this.emi_RichText_receive.Text = "";
            // 
            // bytesBox
            // 
            this.bytesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bytesBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bytesBox.IsHex = true;
            this.bytesBox.Location = new System.Drawing.Point(57, 1);
            this.bytesBox.Multiline = true;
            this.bytesBox.Name = "bytesBox";
            this.bytesBox.Size = new System.Drawing.Size(319, 62);
            this.bytesBox.TabIndex = 3;
            // 
            // C_DebugPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(917, 146);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "C_DebugPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "C_DebugPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.debugContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox emi_RichText_receive;
        private System.Windows.Forms.RichTextBox richTextBox_print;
        private ComLib.BytesBox bytesBox;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip debugContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem M_copy;
        private System.Windows.Forms.ToolStripMenuItem M_paste;
        private System.Windows.Forms.ToolStripMenuItem M_clear;
    }
}