using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.ComLib
{
    [Serializable]
    public class ColorGaridModel
    {
        public string ID { get; set; }
        //public string Backlight { get; set; }
        public string RGain { get; set; }
        public string GGain { get; set; }
        public string BGain { get; set; }
        public string Lum { get; set; }
        public string xValue { get; set; }
        public string yValue { get; set; }
    }

    [Serializable]
    public class ColorTempModel
    {
        public int ID { get; set; }
        public int C_ColorTemp_lv { set; get; }
        public int C_ColorTemp_x { set; get; }
        public int C_ColorTemp_y { set; get; }
        public string C_ColorEeror_xy { set; get; }
        public string C_ColorEeror_lv { set; get; }
        public bool C_ColorEeror { set; get; }
    }
}
