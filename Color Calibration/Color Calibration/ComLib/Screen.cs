using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Management;

namespace Color_Calibration.ComLib
{
    /// <summary>
    /// 屏幕的属性实体类
    /// </summary>
    public class Screen
    {
        private String name;//名字，U+第几块
        private String intputType;//信源的类型
        private int number;//第几块

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        public String IntputType
        {
            get { return intputType; }
            set { intputType = value; }
        }


        public override string ToString()
        {
            return name + " " + intputType;
        }


    }


    public static class Com_Class
    {
        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalIP()
        {
            List<string> listIP = new List<string>();
            try
            {
                ManagementClass mcNetworkAdapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc_NetworkAdapterConfig = mcNetworkAdapterConfig.GetInstances();
                foreach (ManagementObject mo in moc_NetworkAdapterConfig)
                {
                    string mServiceName = mo["ServiceName"] as string;

                    //过滤非真实的网卡  
                    if (!(bool)mo["IPEnabled"])
                    { continue; }
                    if (mServiceName.ToLower().Contains("vmnetadapter")
                     || mServiceName.ToLower().Contains("ppoe")
                     || mServiceName.ToLower().Contains("bthpan")
                     || mServiceName.ToLower().Contains("tapvpn")
                     || mServiceName.ToLower().Contains("ndisip")
                     || mServiceName.ToLower().Contains("sinforvnic"))
                    { continue; }

                    //bool mDHCPEnabled = (bool)mo["IPEnabled"];//是否开启了DHCP  
                    //string mCaption = mo["Caption"] as string;  
                    //string mMACAddress = mo["MACAddress"] as string;  
                    string[] mIPAddress = mo["IPAddress"] as string[];

                    if (mIPAddress != null)
                    {
                        foreach (string ip in mIPAddress)
                        {
                            if (ip != "0.0.0.0")
                            {
                                if (IPAddress.Parse(ip).AddressFamily == AddressFamily.InterNetwork)
                                {
                                    listIP.Add(ip);
                                    //Console.WriteLine(ip);
                                }
                            }
                        }
                    }
                    mo.Dispose();
                }
                return listIP;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("获取本机IP出错:" + ex.Message);
                return listIP;
            }
        }

        public static int toByte(char c)
        {
            byte b = (byte)"0123456789ABCDEF".IndexOf(c);
            return b;
        }
        /**
        * 把16进制字符串转换成字节数组
        * @param hexString
        * @return byte[]
        */
        public static byte[] hexStringToByte(String hex)
        {
            hex = hex.Replace(" ", "");
            byte[] array = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return array;
        }


        /// <summary>
        /// 转十六进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Get_CRC(string str)
        {
            byte[] array = hexStringToByte(str);
            byte bb = 0x00;
            for (int i = 1; i < array.Length; i++)
            {
                bb += array[i];
            }
            //bb = bb && (byte)0xff;
            return bb.ToString("X2");
        }

    }
}
