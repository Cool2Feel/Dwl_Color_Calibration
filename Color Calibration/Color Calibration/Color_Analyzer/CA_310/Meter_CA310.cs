using CA200SRVRLib;
using Color_Calibration.ComLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Color_Calibration.Color_Analyzer.CA_310
{
    public class Meter_CA310
    {
        /*
         * CA-310
         * Declaration of objects
         */
        private ICa200 m_ICa200;
        private ICas m_ICas;
        private ICa m_ICa;
        private IProbe m_IProbe;
        private IMemory m_IMemory;


        public bool uPowerStatus = false;                   // power on state
        private bool uUSBConnect = false;                    // CA210 connection state

        public Meter_CA310()
        {
            m_ICa200 = new CA200SRVRLib.Ca200Class();
        }

        private bool Connect_CA310()
        {
            if (!uPowerStatus)
            {
                try
                {
                    m_ICa200.AutoConnect();
                }
                catch
                {
                    //FrmDialog.ShowDialog(this, "  Connection error, check USB connection!", "Tips", false);
                    //MessageBox.Show("连接出错,检查USB连接! ");
                    return false;
                }
                uPowerStatus = true;
                uUSBConnect = true;
                //create obj
                m_ICas = m_ICa200.Cas;
                m_ICa = m_ICas.get_ItemOfNumber(1);
                m_IProbe = m_ICa.SingleProbe;
                m_IMemory = m_ICa.Memory;
                //GlobalClass.m_ICa = m_ICa;
                //GlobalClass.m_IProbe = m_IProbe;

            }
            else if (!uUSBConnect)
            {
                try
                {
                    m_ICa.RemoteMode = 1;
                    uPowerStatus = true;
                    uUSBConnect = true;
                }
                catch
                {
                    //FrmDialog.ShowDialog(this, "  Connection error, check USB connection!", "Tips", false);
                    //MessageBox.Show("连接出错,检查USB连接! ");
                    return false;
                }
            }
            try
            {
                Init_CA310();
                return true;
            }
            catch
            {
                m_ICa.RemoteMode = 0;
                uUSBConnect = false;
                //FrmDialog.ShowDialog(this, "  Communication error, try again!", "Tips", false);
                //MessageBox.Show("通讯出错,再试一次! ");
                return false;
            }
        }

        private bool DisConnect_CA310()
        {
            try
            {
                if (uUSBConnect)
                {
                    m_ICa.RemoteMode = 0;
                    uUSBConnect = false;
                    uPowerStatus = true;
                    return true;
                }
            }
            catch
            {
                //FrmDialog.ShowDialog(this, "  CA310/CA410 connection error!", "Tips", false);
                //MessageBox.Show("CA310 连接出错! ");
                return false;
            }
            return false;
        }
        
        // measure color temp
        private MeasureData Measure_CA310()
        {
            double Lv = 0.0;
            double sx = 0.0;
            double sy = 0.0;
            m_ICa.Measure(1);
            
            sx = m_IProbe.sx;
            sy = m_IProbe.sy;
            Lv = m_IProbe.Lv;
            Console.WriteLine("Lv:" + Lv + " x:" + sx + " y:" + sy);

            MeasureData _md = new MeasureData();
            _md.Lv = Lv;
            _md.sx = sx;
            _md.sy = sy;
            return _md;
        }
        // init CA310
        private void Init_CA310()
        {
            if (uUSBConnect)
            {
                // set Memory No to 90
                m_IMemory.ChannelNO = 90;
                Thread.Sleep(100);

                m_ICa.SetAnalogRange((float)2.5, (float)2.5);
                if (m_ICa.DisplayMode != 0)
                    m_ICa.DisplayMode = 0;

                // set Channel ID
                m_IMemory.SetChannelID(" ");
                if (m_IMemory.ChannelID != "WB AutoAdj")
                    m_IMemory.SetChannelID("WB AutoAdj");

                Measure_CA310();
            }
            else
            {
                //FrmDialog.ShowDialog(this, "  CA310/CA410 is not connected!", "Tips", false);
                //MessageBox.Show("CA310 未连接");
                return;
            }
        }


        public bool GetCA310_connect
        {
            get { return uUSBConnect; }
        }

        public MeasureData GetCA310Measure_Data()
        {
            if (uUSBConnect)
                return Measure_CA310();
            else
                return null;
        }

        public bool StartConnect_CA310()
        {
            return Connect_CA310();
        }
        public bool CloseConnect_CA310()
        {
            return DisConnect_CA310();
        }
    }
}
