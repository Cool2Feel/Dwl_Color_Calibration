using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Color_Calibration.ComLib
{
    [Serializable]
    public class MainSetModel
    {
        public int H_Row { set; get; }
        public int V_Colu { set; get; }
        public int M_ComIndex { set; get; }
        public int M_PageIndex { set; get; }
        public int M_MeterType { set; get; }
        public int M_ModelType { set; get; }
        public int T_Gamma { set; get; }
        public int T_Temp { set; get; }
        public int T_Lum { set; get; }
        public int T_Custom { set; get; }
        public int T_ID { set; get; }
    }

    public class SerializeModel
    {
        static string strFile = System.Windows.Forms.Application.StartupPath + "\\Model\\main_set.xml";     
        public static string PathFile
        {
            get { return strFile; }
            set
            {
                strFile = value;
            }
        }

        public static string XMLSerialize<T>(T entity)
        {
            //StringBuilder buffer = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(strFile, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(fs, entity);
            }

            return "OK";

        }
        public static T DeXMLSerialize<T>()
        {
            T cloneObject = default(T);
            //StringBuilder buffer = new StringBuilder();
            //buffer.Append(xmlString);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(strFile, FileMode.Open))
            {
                Object obj = serializer.Deserialize(fs);
                cloneObject = (T)obj;
            }

            return cloneObject;
        }
    }
}
