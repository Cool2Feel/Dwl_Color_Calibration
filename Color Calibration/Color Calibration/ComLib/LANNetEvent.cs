using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.ComLib
{
    public class LANNetEvent
    {
        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void TCPDataReceivedHandler(object sender, byte[] data);

        /// <summary>
        /// 数据接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void TCPConnectdHandler(object sender,bool ok);

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="data"></param>
        public delegate bool TCPDataSendHandler(byte[] data);
    }
}
