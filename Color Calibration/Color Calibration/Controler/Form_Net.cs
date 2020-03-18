using Color_Calibration.ComLib;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Color_Calibration.Control
{
    public partial class Form_Net : FrmBase
    {
        private int ip1, ip2, ip3, ip4;
        string[] t = new string[5];
        string ss = null;
        string ee = null;
        Thread fThread = null;
        private static byte[] receivebuffer;
        private static SocketAsyncEventArgs ReceiveSocketArgs;
        private string LcoalIP = "192.168.0.1";
        private string BroadCastIP = "192.168.0.255";
        private int Port = 4352;

        List<DeviceMonitor> _Device_list = new List<DeviceMonitor>();
        public Form_Net()
        {
            InitializeComponent();
            if (Com_Class.GetLocalIP().Count > 0)
            {
                LcoalIP = Com_Class.GetLocalIP()[0];
                string[] sip = LcoalIP.Split('.');
                sip1.Text = sip[0];
                sip2.Text = sip[1];
                sip3.Text = sip[2];

                eip1.Text = sip[0];
                eip2.Text = sip[1];
                eip3.Text = sip[2];
            }
            sip1.Enabled = false;
            sip2.Enabled = false;
            sip3.Enabled = false;
            sip4.Enabled = false;
            eip1.Enabled = false;
            eip2.Enabled = false;
            eip3.Enabled = false;
            eip4.Enabled = false;
            //List<Device_class> dl = new List<Device_class>();

            //_tcpClient = new TcpClient();
            Initialize();
        }

        private Socket _socket;

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ss = this.sip1.Text + "." + sip2.Text + "." + sip3.Text + "." + sip4.Text;
                ee = this.eip1.Text + "." + eip2.Text + "." + eip3.Text + "." + eip4.Text;
                //this.timer1.Enabled = true;
                Port = (int)emi_port.Value;
                btnSend.Enabled = false;
                bt_Create.Enabled = false;
                bt_Cancel.Enabled = false;
                this.label_loop.Text = "Please wait, searching...";
                dataGridView1.Rows.Clear();
                fThread = new Thread(new ThreadStart(runs));
                fThread.Start();
            }
            else
            {
                Port = 4352;
                BroadCastIP = this.sip1.Text + "." + sip2.Text + "." + sip3.Text + "." + "255";
                byte[] sendbytes = Com_Class.hexStringToByte("FF 01 01 02");
                SendData(sendbytes, IPAddress.Parse(BroadCastIP), 1500);
            }
        }

        /// <summary>
        /// 初始化端口
        /// </summary>
        public void Initialize()
        {
            try
            {
                IPEndPoint _local = new IPEndPoint(IPAddress.Parse(LcoalIP), 6568);
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                _socket.Bind(_local);

                receivebuffer = new byte[1024];
                ReceiveSocketArgs = new SocketAsyncEventArgs();
                ReceiveSocketArgs.RemoteEndPoint = _local;
                ReceiveSocketArgs.SetBuffer(receivebuffer, 0, receivebuffer.Length);
                ReceiveSocketArgs.Completed += new EventHandler<SocketAsyncEventArgs>(ReceiveSocketArgs_Completed);

                StartReceive();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        /// <summary>
        /// 开始接收数据
        /// </summary>
        public void StartReceive()
        {
            try
            {
                if (!_socket.ReceiveFromAsync(ReceiveSocketArgs))
                {
                    processReceived(ReceiveSocketArgs);
                }
            }
            catch
            {

            }
        }

        private void processReceived(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                Int32 byteTransferred = e.BytesTransferred;
                //String strData = Encoding.ASCII.GetString(e.Buffer, 0, byteTransferred);
                //Console.WriteLine(e.Buffer[0]);
                Ajust_str(e.Buffer);
            }

            StartReceive();
        }
        private void ReceiveSocketArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.ReceiveFrom:
                    this.processReceived(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive");
            }
        }

        private void SendData(byte[] data, IPAddress remoteIP, int remotePort)
        {
            _socket.SendTo(data, new IPEndPoint(remoteIP, remotePort));
        }
        
        public void ipstart_get(string ff)
        {
            t = ff.Split('.');
            ip1 = Convert.ToInt16(t[0].ToString().Trim());
            ip2 = Convert.ToInt16(t[1].ToString().Trim());
            ip3 = Convert.ToInt16(t[2].ToString().Trim());
            ip4 = Convert.ToInt16(t[3].ToString().Trim());
        }
        /// <summary>
        /// 这个算法的用处是：将你的IP 增加1  如果你将此方法用 for循环的话，你可以循环出指定IP段的所有IP地址
        /// </summary>
        public void IPAdd()
        {
            if (++ip4 > 255)
            {
                ip3++;
                ip4 = 1;
            }

            if (ip3 > 255)
            {
                ip2++;
                ip3 = 1;
            }

            if (ip2 > 255)
            {
                ip1++;
                ip2 = 1;
            }

            if (ip1 > 255)
            {
                ip1 = 1;
            }
        }

        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        /// <summary>
        /// 判断连接
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="portNum"></param>
        /// <param name="timeoutMSec"></param>
        /// <returns></returns>
        private bool CheckConnect(string ipAddress, int portNum, int timeoutMSec)
        {
            try
            {
                TimeoutObject.Reset();
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint point = new IPEndPoint(ip, portNum);
                using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    sock.BeginConnect(point, CallBackMethod, sock);
                    //sock.Connect(point);//阻塞当前线程           
                    if (TimeoutObject.WaitOne(timeoutMSec, false))
                    {
                        //MessageBox.Show("网络正常");
                        //Console.WriteLine("网络正常");
                        sock.Close();
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("连接超时");
                        //Console.WriteLine("连接超时");
                        return false;
                    }
                }
                //return false;
            }
            catch (SocketException e)
            {
                //Console.WriteLine("fff");
                return false;
            }
        }

        //--异步回调方法       
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            //使阻塞的线程继续        
            TimeoutObject.Set();

        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="yy"></param>
        public void Startscan(string yy)
        {
            Int32 port = Convert.ToInt32("1500");
            try
            {
                //IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(ss), port);
                byte[] sendbytes = Com_Class.hexStringToByte("FF 01 01 02");
                SendData(sendbytes, IPAddress.Parse(ss), port);
                //this.richTextBox1.AppendText(ss + "   端口：" + port.ToString() + "开放\n");
                Thread.Sleep(200);

                if (CheckConnect(yy, Port, 100))
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        dataGridView1.Rows.Add(false, "--", yy, "");
                    }));
                }
            }
            catch
            {
                //this.richTextBox1.AppendText(ss + "  端口：" + port.ToString() + "未开放\n");
                return;
            }

        }

        public void runs()
        {
            while (true) //这个是死循环  循环计算出 IP
            {
                Thread.Sleep(100);
                Application.DoEvents();
                // Console.WriteLine("test=" + ss + "==" + ee);
                if (!ss.Equals(ee))//当初始地址 不等于结束地址的时候  继续操作  如果相等  就结束循环
                {
                    Startscan(ss);
                    ipstart_get(ss);
                    IPAdd();
                    ss = ip1.ToString() + "." + ip2.ToString() + "." + ip3.ToString() + "." + ip4.ToString();
                    Thread.Sleep(100);
                    //Console.WriteLine(ss);
                    continue;
                }
                else
                {
                    //Console.WriteLine(ss);
                    Startscan(ss);
                    break;
                }
            }
            this.Invoke(new MethodInvoker(delegate ()
            {
                btnSend.Enabled = true;
                bt_Create.Enabled = true;
                bt_Cancel.Enabled = true;
                this.label_loop.Text = "Complete search...";
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_socket != null)
                _socket.Close();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                sip1.Enabled = false;
                sip2.Enabled = false;
                sip3.Enabled = false;
                sip4.Enabled = false;
                eip1.Enabled = false;
                eip2.Enabled = false;
                eip3.Enabled = false;
                eip4.Enabled = false;
                label_loop.Enabled = false;
                radioButton2.Checked = false;
                label_port.Visible = false;
                emi_port.Visible = false;
                Port = 4352;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checkbox 勾上
            if (e.RowIndex < dataGridView1.Rows.Count)
            {
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int rs = dataGridView1.Rows.Count;
            if (checkBox1.Checked)
            {
                if (rs > 0)
                {
                    for (int i = 0; i < rs; i++)
                    {
                        ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = true;
                    }
                }
            }
            else
            {
                if (rs > 0)
                {
                    for (int i = 0; i < rs; i++)
                    {
                        ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = false;
                    }
                }
            }
        }

        private void bt_Craet_Click(object sender, EventArgs e)
        {
            _Device_list = new List<DeviceMonitor>();
            int rs = dataGridView1.Rows.Count;
            //ff._TcpServer.Stop();
            //Console.WriteLine(dataGridView1.Rows[0].Cells[0].Value.ToString());
            if (rs > 0)
            {
                for (int i = 0; i < rs; i++)
                {
                    DeviceMonitor d = new DeviceMonitor();
                    d.name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    d.ip = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    d.mac = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    d.port = Port;
                    d.status = false;
                    if (((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value.ToString() == "True")
                    {
                        d.status = true;
                        _Device_list.Add(d);
                    }
                }
            }
            //ff.deveice_List = list;
            //ff.Get_Device(list);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public List<DeviceMonitor> Get_deviceList()
        {
            if (_Device_list.Count > 0)
                return _Device_list;
            else
                return null;
        }

        private void Form_Net_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                sip1.Enabled = true;
                sip2.Enabled = true;
                sip3.Enabled = true;
                sip4.Enabled = true;
                eip1.Enabled = true;
                eip2.Enabled = true;
                eip3.Enabled = true;
                eip4.Enabled = true;
                label_loop.Enabled = true;
                radioButton1.Checked = false;
                label_port.Visible = true;
                emi_port.Visible = true;
                Port = (int)emi_port.Value;
            }
        }

        /// <summary>
        /// 自动搜索数据更新
        /// </summary>
        /// <param name="buffer"></param>
        private void Ajust_str(byte[] buffer)
        {
            string ip;
            string mac;
            if (buffer[0] == 0xff && buffer[1] == 0x24)
            {
                ip = buffer[5] + "." + buffer[6] + "." + buffer[7] + "." + buffer[8];
                mac = buffer[9].ToString("X2") + " " + buffer[10].ToString("X2") + " " + buffer[11].ToString("X2") + " " + buffer[12].ToString("X2") + " " + buffer[13].ToString("X2") + " " + buffer[14].ToString("X2");
                byte[] byteArray = new byte[16];
                for (int i = 19, j = 0; i <= 34; i++, j++)
                    byteArray[j] = buffer[i];
                string name = Encoding.ASCII.GetString(byteArray).Trim('\0');
                //Console.WriteLine(buffer[0] + "----" + ip + "===" + name);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    dataGridView1.Rows.Add(false, name, ip, mac);
                }));
            }
            else if (buffer[0] == 0xff && buffer[1] == 0x01)
            {

                Console.WriteLine(buffer[4]);
            }
        }
    }
}
