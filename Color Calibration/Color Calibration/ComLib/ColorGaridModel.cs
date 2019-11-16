using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.ComLib
{
    class ColorGaridModel
    {
        public string ID { get; set; }
        public string Backlight { get; set; }
        public string RGain { get; set; }
        public string GGain { get; set; }
        public string BGain { get; set; }
        public string Lum { get; set; }
        public string xValue { get; set; }
        public string yValue { get; set; }
    }
}
