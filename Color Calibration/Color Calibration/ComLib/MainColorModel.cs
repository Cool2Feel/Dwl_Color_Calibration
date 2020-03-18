using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Color_Calibration.ComLib
{
    public class MainColorModel
    {
        #region Attributes
        private static int _h_Row = 1;
        private static int _v_Colu = 1;
        private static int _m_PageIndex = 0;
        private static int _m_ComIndex = 0;
        private static int _m_LanIndex = 0;
        private static int _m_MeterType = 0;
        private static int _m_ModelType = 0;
        private static int _t_Gamma = 0;
        private static int _t_Temp = 0;
        private static int _t_Lum;
        private static int _t_Custom;
        private static int _t_ID = 0;
        private static bool _t_ComLan = false;
        private static List<KeyValuePair<string, string>> _id_List;
        #endregion

        #region  Method
        public static int H_Row
        {
            get { return _h_Row; }
            set
            {
                _h_Row = value;
            }
        }
        public static int V_Colu
        {
            get { return _v_Colu; }
            set
            {
                _v_Colu = value;
            }
        }
        public static int M_PageIndex
        {
            get { return _m_PageIndex; }
            set
            {
                _m_PageIndex = value;
            }
        }
        public static int M_ComIndex
        {
            get { return _m_ComIndex; }
            set
            {
                _m_ComIndex = value;
            }
        }

        public static int M_LanIndex
        {
            get { return _m_LanIndex; }
            set
            {
                _m_LanIndex = value;
            }
        }
        public static int M_MeterType
        {
            get { return _m_MeterType; }
            set
            {
                _m_MeterType = value;
            }
        }
        public static int M_ModelType
        {
            get { return _m_ModelType; }
            set
            {
                _m_ModelType = value;
            }
        }
        public static int T_Gamma
        {
            get { return _t_Gamma; }
            set
            {
                _t_Gamma = value;
            }
        }
        public static int T_Temp
        {
            get { return _t_Temp; }
            set
            {
                _t_Temp = value;
            }
        }
        public static int T_Lum
        {
            get { return _t_Lum; }
            set
            {
                _t_Lum = value;
            }
        }
        public static int T_Custom
        {
            get { return _t_Custom; }
            set
            {
                _t_Custom = value;
            }
        }
        public static int T_ID
        {
            get { return _t_ID; }
            set
            {
                _t_ID = value;
            }
        }
        public static bool T_ComLan
        {
            get { return _t_ComLan; }
            set
            {
                _t_ComLan = value;
            }
        }
        public static List<KeyValuePair<string, string>> Id_List
        {
            get { return _id_List; }
            set
            {
                _id_List = value;
            }
        }

        #endregion
    }
}
