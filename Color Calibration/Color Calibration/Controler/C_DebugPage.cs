using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration.Control
{
    public partial class C_DebugPage : Form
    {
        public event ComLib.ComEvent.DataSendHandler DataSend;
        public C_DebugPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 字符转十六进制
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes, int Length) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2") + " ");
                }
                hexString = strB.ToString() + "\r\n";
            }
            return hexString;
        }
        public void SendPrint(byte[] date)
        {
            richTextBox_print.AppendText(ToHexString(date, date.Length));
            this.richTextBox_print.SelectionStart = this.richTextBox_print.Text.Length;//设置插入符位置为文本框末
            this.richTextBox_print.ScrollToCaret();//滚动条滚到到最新插入行
        }
        public void ReceivePrint(byte[] date)
        {
            //Console.WriteLine(date[0]);
            /*
            this.Invoke(new MethodInvoker(delegate ()
            {
                emi_RichText_receive.AppendText(date);
            }));*/
            this.emi_RichText_receive.AppendText(ToHexString(date, date.Length));
            this.emi_RichText_receive.SelectionStart = this.emi_RichText_receive.Text.Length;//设置插入符位置为文本框末
            this.emi_RichText_receive.ScrollToCaret();//滚动条滚到到最新插入行
        }
        public void SendPrint(string date)
        {
            this.richTextBox_print.AppendText(date);
            this.richTextBox_print.SelectionStart = this.richTextBox_print.Text.Length;//设置插入符位置为文本框末
            this.richTextBox_print.ScrollToCaret();//滚动条滚到到最新插入行
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if(bytesBox.IsHex)
            {
                DataSend(bytesBox.GetByte());
            }
            else
            {
                DataSend(new ASCIIEncoding().GetBytes(bytesBox.Text.Trim()));
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            this.bytesBox.Text = "";
        }

        private void copy_Click(object sender, EventArgs e)
        {
            string selectText = (debugContextMenuStrip.SourceControl as RichTextBox).SelectedText;
            if (selectText != "")
            {
                Clipboard.SetText(selectText);
            }
        }

        private void paste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                RichTextBox txtBox = debugContextMenuStrip.SourceControl as RichTextBox;
                int index = txtBox.SelectionStart;  //记录下粘贴前的光标位置
                string text = txtBox.Text;
                //删除选中的文本
                text = text.Remove(txtBox.SelectionStart, txtBox.SelectionLength);
                //在当前光标输入点插入剪切板内容
                text = text.Insert(txtBox.SelectionStart, Clipboard.GetText());
                txtBox.Text = text;
                //重设光标位置
                txtBox.SelectionStart = index;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            RichTextBox txtBox = debugContextMenuStrip.SourceControl as RichTextBox;
            txtBox.Text = "";
        }

        private void debugContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //没有选择文本时，复制菜单禁用
            string selectText = (debugContextMenuStrip.SourceControl as RichTextBox).SelectedText;
            if (selectText != "")
                M_copy.Enabled = true;
            else
                M_copy.Enabled = false;
            //剪切板没有文本内容时，粘贴菜单禁用
            if (Clipboard.ContainsText())
            {
                M_paste.Enabled = true;
            }
            else
                M_paste.Enabled = false;
        }
    }
}
