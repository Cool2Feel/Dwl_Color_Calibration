using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Color_Calibration.ComLib
{
    public partial class BytesBox : TextBox
    {
        ContextMenuStrip CMenu = new ContextMenuStrip();
        ToolStripMenuItem CM_Type = new ToolStripMenuItem();
        ToolStripMenuItem CM_Clear = new ToolStripMenuItem();
        Command Cmd = new Command();
        public BytesBox()
        {
            #region 快捷菜单
            CM_Type.Name = "CM_Type";
            CM_Type.Size = new System.Drawing.Size(127, 22);
            CM_Type.Text = "ASCII";
            CM_Type.Click += new System.EventHandler(CM_Type_Click);
            CM_Clear.Name = "CM_Clear";
            CM_Clear.Size = new System.Drawing.Size(127, 22);
            CM_Clear.Text = "Clear";
            CM_Clear.Click += new System.EventHandler(CM_Clear_Click);
            CMenu.Name = "CMenu";
            CMenu.ShowImageMargin = false;
            CMenu.Size = new System.Drawing.Size(128, 48);
            CMenu.Items.AddRange(new ToolStripItem[] {
            CM_Type,CM_Clear});

            this.ContextMenuStrip = CMenu;
            #endregion
        }

        #region 属性
        bool _IsHex = true;
        [Description("True:Hex;False:ASCII"), Category("Input formatting")]
        public bool IsHex
        {
            set
            {
                _IsHex = value;
                if (_IsHex)
                {
                    CM_Type.Text = "ASCII";
                }
                else
                {
                    CM_Type.Text = "Hex";
                }
            }
            get
            {
                return _IsHex;
            }
        }
        #endregion

        #region 菜单操作
        /// <summary>
        /// HEX/ASCII 格式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CM_Type_Click(object sender, EventArgs e)
        {
            if (IsHex)
            {//切换到ASCII格式
                IsHex = false;
                if (this.Text.Length > 0)
                {
                    string[] HexStr = this.Text.Trim().Split(' ');
                    byte[] data = new byte[HexStr.Length];
                    for (int i = 0; i < HexStr.Length; i++)
                    {
                        data[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                    }
                    this.Text = new ASCIIEncoding().GetString(data);
                }
            }
            else
            {//切换到Hex格式
                IsHex = true;

                if (this.Text.Length > 0)
                {
                    byte[] data = new ASCIIEncoding().GetBytes(this.Text.Trim());
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.AppendFormat("{0:x2}", data[i]);
                    }
                    this.Text = sb.ToString();
                }
            }

        }
        /// <summary>
        /// 清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CM_Clear_Click(object sender, EventArgs e)
        {
            this.Text = "";
        }
        #endregion

        #region 输入控制
        protected override void OnTextChanged(EventArgs e)
        {
            if (_IsHex)
            {//Hex输入
                string Content = this.Text.Replace(" ", "");//获取去除空格后的字符内容
                int SpaceCount = Content.Length / 2;
                int StartIndex = 2;
                for (int i = 0; i < SpaceCount; i++)
                {
                    Content = Content.Insert(StartIndex, " ");
                    StartIndex = StartIndex + 3;
                }
                this.Text = Content.TrimEnd().ToUpper();
            }
            this.SelectionStart = this.Text.Length;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (_IsHex)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9')//数字0-9键   
                     || (e.KeyChar >= 'A' && e.KeyChar <= 'F')//字母A-F 
                     || (e.KeyChar >= 'a' && e.KeyChar <= 'f')//字母a-f 
                     || e.KeyChar == 0x08//退格键
                     || e.KeyChar == 0x03//拷贝
                     || e.KeyChar == 0x18)//剪切
                {
                    e.Handled = false;
                    return;
                }
            }
            else
            {
                if ((e.KeyChar >= 0x20 && e.KeyChar <= 0x7E)
                     || e.KeyChar == 0x08//退格键
                     || e.KeyChar == 0x0D//回车键
                     || e.KeyChar == 0x03//拷贝
                     || e.KeyChar == 0x18)//剪切
                {
                    e.Handled = false;
                    return;
                }
            }
            if (e.KeyChar == 0x16)//粘贴
            {//粘贴前数据格式检查
                if (CheckPaste())
                {
                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }

        /// <summary>
        /// 粘贴数据格式检查
        /// </summary>
        /// <returns></returns>
        private bool CheckPaste()
        {
            try
            {
                char[] PasteChar = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString().ToCharArray();
                if (_IsHex)
                {
                    foreach (char data in PasteChar)
                    {
                        if (!((data >= '0' && data <= '9')//数字0-9键   
                         || (data >= 'A' && data <= 'F')//字母A-F 
                         || (data >= 'a' && data <= 'f')//字母a-f
                         || data == 0x20))//空格
                        {
                            MessageBox.Show("粘贴数据含有非法字符，只能包含数字0-9,大写英文字母A-F,小写英文字母a-f以及空格！", "非法的粘贴", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                else
                {
                    foreach (char data in PasteChar)
                    {
                        if (!((data >= 0x20 && data <= 0x7E)
                         || data == 0x0A
                         || data == 0x0D))//回车键
                        {
                            MessageBox.Show("粘贴数据含有非法字符，只能包含ASCII码字符！", "非法的粘贴", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取命令对象
        /// </summary>
        /// <returns></returns>
        public Command GetCMD()
        {
            try
            {
                if (this.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Disallowed content is empty！");
                    return null;
                }
                Cmd.IsHex = _IsHex;
                if (Cmd.IsHex)
                {//Hex
                    string[] HexStr = this.Text.Trim().Split(' ');
                    Cmd.DataBytes = new byte[HexStr.Length];
                    for (int i = 0; i < HexStr.Length; i++)
                    {
                        Cmd.DataBytes[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                    }
                }
                else
                { //ASCII
                    Cmd.DataBytes = new ASCIIEncoding().GetBytes(this.Text.Trim());
                }
                return Cmd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 设置命令对象
        /// </summary>
        /// <param name="Cmd"></param>
        public void SetCMD(Command Cmd)
        {
            try
            {
                this._IsHex = Cmd.IsHex;
                if (this._IsHex)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Cmd.DataBytes.Length; i++)
                    {
                        sb.AppendFormat("{0:x2}", Cmd.DataBytes[i]);
                    }
                    this.Text = sb.ToString();
                }
                else
                {
                    this.Text = new ASCIIEncoding().GetString(Cmd.DataBytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public byte[] GetByte()
        {
            GetCMD();
            if (Cmd.IsHex)
                return Cmd.DataBytes;
            else
                return null;
        }
        #endregion
        
    }
}
