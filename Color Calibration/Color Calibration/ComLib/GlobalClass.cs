using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.ComLib
{
    public class GlobalClass
    {
        public static IntPtr i1d3Handle { set; get; }
        public static bool m_bIsOpen { set; get; }
        public static bool c_bIsOpen { set; get; }
        public static float m_uCompare_lv { set; get; }
        public static float m_uCompare_x { set; get; }
        public static float m_uCompare_y { set; get; }
        public static bool m_cIsRunning { set; get; }

        public static int[,] _t_ColorTempStd = new int[4, 3] { { 2700, 2700, 250 }, { 2800, 2900, 250 }, { 3000, 3050, 250 }, { 3130, 3290, 250 } };       // x, y ,Lv
        public static int[] _t_ColorEerorxy = new int[4] { 50, 50, 50, 50 };
        public static int[] _t_ColorEerorlv = new int[4] { 20, 20, 20, 20 };
        public static bool[] _t_ColorEeror = new bool[4] { false, false, false, false };
    }
}
