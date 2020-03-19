﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static Color_Calibration.ComLib.LANNetEvent;

namespace Color_Calibration.NetCommand.IOCPClinet
{
    public class IOCPClient
    {
        #region Members
        public Socket m_socket;
        IPEndPoint m_endPoint;
        private SocketAsyncEventArgs m_connectSAEA;
        private SocketAsyncEventArgs m_sendSAEA;
        //private MainForm lm;
        public TCPDataReceivedHandler DataReceived;
        public TCPConnectdHandler ConnectReceived;
        public bool Connected { get; set; }
        //public List<Socket> m_clients; //客户端列表
        #endregion

        public IOCPClient(string ip, int port)
        {
            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //m_socket.Bind(LocalIP);
            Connected = false;
            IPAddress iPAddress = IPAddress.Parse(ip);
            m_endPoint = new IPEndPoint(iPAddress, port);
            m_connectSAEA = new SocketAsyncEventArgs { RemoteEndPoint = m_endPoint };
            //Console.WriteLine(m_socket.RemoteEndPoint);
        }

        public bool Start()
        {
            m_connectSAEA.Completed += OnConnectedCompleted;
            bool con = m_socket.ConnectAsync(m_connectSAEA);
            //Console.WriteLine(con);
            //lm.clientEndPoint = m_socket.LocalEndPoint;
            //Console.WriteLine(m_socket.LocalEndPoint.ToString());
            return con;
        }

        public void OnConnectedCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                //lm.tcpConnect = false;
                return;
            }
            Socket socket = sender as Socket;
            string iPRemote = socket.RemoteEndPoint.ToString();
            //lm.tcpConnect = true;
            //Console.WriteLine("Client : 连接服务器 [ {0} ] 成功",iPRemote);
            //m_clients.Add(socket);
            //_clientCount++;
            Connected = true;
            ConnectReceived(this,true);
            SocketAsyncEventArgs receiveSAEA = new SocketAsyncEventArgs();
            byte[] receiveBuffer = new byte[1024 * 4];
            receiveSAEA.SetBuffer(receiveBuffer, 0, receiveBuffer.Length);
            receiveSAEA.Completed += OnReceiveCompleted;
            receiveSAEA.RemoteEndPoint = m_endPoint;
            socket.ReceiveAsync(receiveSAEA);
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.OperationAborted) return;

            Socket socket = sender as Socket;

            if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
            {
                string ipAdress = socket.RemoteEndPoint.ToString();
                int lengthBuffer = e.BytesTransferred;
                byte[] receiveBuffer = e.Buffer;
                byte[] buffer = new byte[lengthBuffer];
                Buffer.BlockCopy(receiveBuffer, 0, buffer, 0, lengthBuffer);

                string msg = Encoding.Default.GetString(buffer);
                //Console.WriteLine("Client : receive message[ {0} ],from Server[ {1} ]", msg, ipAdress);
                //char[] c = "end".ToCharArray();
                //lm.newReceiveData(msg);
                /*
                lm.Invoke(new MethodInvoker(delegate ()
                {
                    lm.Receive_data(buffer, buffer.Length, ipAdress);
                }));
                */
                DataReceived(this, buffer);
                socket.ReceiveAsync(e);
            }
            else if (e.SocketError == SocketError.ConnectionReset || e.BytesTransferred == 0)
            {
                //Console.WriteLine("Client: 服务器断开连接 ");
                Connected = false;
                ConnectReceived(this,false);
            }
            else
            {
                return;
            }
        }

        public void Send(string msg)
        {
            byte[] sendBuffer = Encoding.Default.GetBytes(msg);
            if (m_sendSAEA == null)
            {
                m_sendSAEA = new SocketAsyncEventArgs();
                m_sendSAEA.Completed += OnSendCompleted;
            }

            m_sendSAEA.SetBuffer(sendBuffer, 0, sendBuffer.Length);
            if (m_socket != null)
            {
                m_socket.SendAsync(m_sendSAEA);
            }
        }
        
        public void Send(byte[] sendBuffer)
        {
            //byte[] sendBuffer = Encoding.Default.GetBytes(msg);
            if (m_sendSAEA == null)
            {
                m_sendSAEA = new SocketAsyncEventArgs();
                m_sendSAEA.Completed += OnSendCompleted;
            }

            m_sendSAEA.SetBuffer(sendBuffer, 0, sendBuffer.Length);
            if (m_socket != null)
            {
                m_socket.SendAsync(m_sendSAEA);
            }
        }

        private void OnSendCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success) return;
            Socket socket = sender as Socket;
            byte[] sendBuffer = e.Buffer;

            //string sendMsg = Encoding.Default.GetString(sendBuffer);

            //Console.WriteLine("Client : Send message [ {0} ] to Serer[ {1} ]", sendMsg, socket.RemoteEndPoint.ToString());
        }

        public void DisConnect()
        {
            if (m_socket != null)
            {
                try
                {
                    m_socket.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException se)
                {
                    throw se;
                }
                finally
                {
                    m_socket.Close();
                }
            }
        }
        
    }
}
