using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.ComLib
{
    /// <summary>
    /// 命令对象
    /// </summary>
    public class Command
    {
        bool _IsHex = true;
        byte[] _DataBytes = null;

        /// <summary>
        /// 是否16进制数据
        /// </summary>
        public bool IsHex
        {
            set
            {
                _IsHex = value;
            }
            get
            {
                return _IsHex;
            }
        }

        /// <summary>
        /// byte数据
        /// </summary>
        public byte[] DataBytes
        {
            set
            {
                _DataBytes = value;
            }
            get
            {
                return _DataBytes;
            }
        }
    }


    public class MeasureData
    {
        public double Lv { get; set; }
        public double sx { get; set; }
        public double sy { get; set; }
    }

    /// <summary>
    /// 连接设备对象
    /// </summary>
    [Serializable]
    public class DeviceMonitor
    {
        public string name { get; set; }
        public string ip { get; set; }
        public bool status { get; set; }
        public string mac { get; set; }

        public int port { get; set; }
    }
}
