using CASDK2;
using Color_Calibration.ComLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Color_Calibration.Color_Analyzer.CA_410
{
    public class Meter_CA410
    {
        /*
         * CA-410
         * Declaration of objects
         */
        private CASDK2Ca200 objCa200;
        //private CASDK2Cas objCas;
        private CASDK2Ca objCa;
        //private CASDK2Probes objProbes;
        //private CASDK2OutputProbes objOutputProbes;
        private CASDK2Probe objProbe;
        private CASDK2Memory objMemory;

        int err = 0;
        bool autoconnectflag = true; // auro or manual
        bool _CA410_connet = false;

        const int MAXPROBE = 10;
        const int MODE_Lvxy = 0;
        const int MODE_Tduv = 1;
        const int MODE_Lvdudv = 5;
        const int MODE_FMA = 6;
        const int MODE_XYZ = 7;
        const int MODE_JEITA = 8;
        const int MODE_LvPeld = 9;
        const int MODE_Waveform = 10;
        const int MODE_FMA2 = 11;
        const int MODE_JEITA2 = 12;
        const int MODE_Waveform2 = 13;

        
        ///<summary>
        ///[SetSDK and connect device]
        ///This method connect CA-410 Automatically and set objects 
        ///</summary>
        private bool AutoConnect()
        {
            if (!autoconnectflag)
            {
                try
                {
                    objCa200 = new CASDK2Ca200();   // Generate application object
                    GetErrorMessage(objCa200.AutoConnect());
                    // Substitute object variables
                    //GetErrorMessage(objCa200.get_Cas(ref objCas));
                    GetErrorMessage(objCa200.get_SingleCa(ref objCa));
                    //GetErrorMessage(objCa.get_Probes(ref objProbes));
                    //GetErrorMessage(objCa.get_OutputProbes(ref objOutputProbes));
                    GetErrorMessage(objCa.get_Memory(ref objMemory));
                    GetErrorMessage(objCa.get_SingleProbe(ref objProbe));
                    _CA410_connet = true;
                    autoconnectflag = true;
                    DefaultSetting();
                    return true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return false;
        }

        ///<summary>
        ///[SetSDK and connect device]
        ///This method disconnect CA-410 and delete objects 
        ///</summary>
        private bool Disconnect()
        {
            //while (!triggerfinish)
            //{
            //    System.Threading.Thread.Sleep(10);  //wait for completion of trigger measurement
            //}
            //Disconnect CA-410
            try
            {
                if (autoconnectflag)
                {
                    GetErrorMessage(objCa200.AutoDisconnect()); //Disconnect probe connected automatically
                }
                else
                {
                    GetErrorMessage(objCa200.DisconnectAll());  //Disconnect probe connected manually
                }
                _CA410_connet = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///<summary>
        ///[Set measurement conditions]
        ///This method set measurement configuration 
        ///</summary>
        private void DefaultSetting()
        {
            int freqmode = 4;   // SyncMode : INT 
            double freq = 60.0; //frequency = 60.0Hz
            int speed = 1;      //Measurement speed : FAST
            int Lvmode = 1;     //Lv : cd/m2

            GetErrorMessage(objCa.CalZero());                       //Zero-Calibration
            GetErrorMessage(objCa.put_DisplayProbe("P1"));          //Set display probe to P1
            GetErrorMessage(objCa.put_SyncMode(freqmode, freq));    //Set sync mode and frequency
            GetErrorMessage(objCa.put_AveragingMode(speed));        //Set measurement speed
            GetErrorMessage(objCa.put_BrightnessUnit(Lvmode));      //SetBrightness unit

            string PID = "";
            string dispprobe = "";
            int syncmode = 0;
            double syncfreq = 0.0;
            int measspeed = 0;

            //Get settings
            GetErrorMessage(objCa.get_PortID(ref PID));                             //Get connection interface
            Console.WriteLine("PortID:" + PID);
            GetErrorMessage(objCa.get_DisplayProbe(ref dispprobe));                 //Get display probe
            Console.WriteLine("DisplayProbe:" + dispprobe);
            GetErrorMessage(objCa.get_SyncMode(ref syncmode, ref syncfreq));        //Get sync mode and frequency
            Console.WriteLine("SyncMode:" + syncmode + ",Syncfreq:" + syncfreq);
            GetErrorMessage(objCa.get_AveragingMode(ref measspeed));                //Get measurement speed
            Console.WriteLine("MeasurementSpeed:" + measspeed);
        }

        ///<summary>
        ///[Measurement]
        ///This method measure color and flicker(JEITA and FMA) by CH1 
        ///</summary>
        private MeasureData Measurement()
        {
            SetZeroCalEvent();
            int chnum = 1;      //CalibrationCH : 1
            GetErrorMessage(objMemory.put_ChannelNO(chnum));

            //measurement result
            double Lv = 0.0;
            double sx = 0.0;
            double sy = 0.0;
            //double X = 0.0;
            //double Y = 0.0;
            //double Z = 0.0;
            //double JEITA = 0.0;
            //double FMA = 0.0;

            GetErrorMessage(objCa.put_DisplayMode(MODE_Lvxy));  //Set mode:Color Lvxy

            GetErrorMessage(objCa.Measure());                   //Color measurement

            //Get Color result
            GetErrorMessage(objProbe.get_Lv(ref Lv));
            GetErrorMessage(objProbe.get_sx(ref sx));
            GetErrorMessage(objProbe.get_sy(ref sy));
            //GetErrorMessage(objProbe.get_X(ref X));
            //GetErrorMessage(objProbe.get_Y(ref Y));
            //GetErrorMessage(objProbe.get_Z(ref Z));
            /*
            GetErrorMessage(objCa.put_DisplayMode(MODE_JEITA)); //Set mode:Flicker JEITA
            GetErrorMessage(objCa.Measure());                   //JEITA measurement

            //Get JEITA result
            GetErrorMessage(objProbe.get_FlckrJEITA(ref JEITA));

            GetErrorMessage(objCa.put_DisplayMode(MODE_FMA));   //Set mode:Flicker FMA
            GetErrorMessage(objCa.Measure());                   //FMA measurement

            //Get FMA result
            GetErrorMessage(objProbe.get_FlckrFMA(ref FMA));
            */
            Console.WriteLine("Lv:" + Lv + " x:" + sx + " y:" + sy);
            //Console.WriteLine("X:" + X + " Y:" + Y + " Z:" + Z);
            //Console.WriteLine("JEITA:" + JEITA + " FMA:" + FMA);

            GetErrorMessage(objCa.put_DisplayMode(MODE_Lvxy));  //Set mode:Color Lvxy

            MeasureData _md = new MeasureData();
            _md.Lv = Lv;
            _md.sx = sx;
            _md.sy = sy;

            return _md;
        }

        ///<summary>
        ///[Errorhandling]
        ///This method display Error message from Error number
        ///</summary>
        ///<param name = "errornum">Error number from API of SDK</param>
        private void GetErrorMessage(int errornum)
        {
            string errormessage = "";
            if (errornum != 0)
            {
                //Get Error message from Error number
                err = GlobalFunctions.CASDK2_GetLocalizedErrorMsgFromErrorCode(0, errornum, ref errormessage);
                Console.WriteLine(errormessage);
                return; 
            }
        }

        ///<summary>
        ///[Set Zero Calibration event]
        ///This method execute zerocalibration when temperature changes significantly
        ///</summary>
        private int ExeCalZero(int dummy)
        {
            Console.WriteLine("Performing Zero Calibration");
            GetErrorMessage(objCa.CalZero());   //Zero calibration
            return err;
        }

        ///<summary>
        ///[Set Zero Calibration event]
        ///This method set zero calibration event
        ///</summary>
        private void SetZeroCalEvent()
        {
            Func<int, int> funczerocal = ExeCalZero;
            GetErrorMessage(objCa.SetExeCalZeroCallback(funczerocal));      //Set function for zero calibration event
        }

        public bool GetCA410_Connect
        {
            get { return _CA410_connet; }
        }

        public MeasureData GetCA410Measure_Data()
        {
            if (_CA410_connet)
                return Measurement();
            else
                return null;
        }

        public bool StartConnect_CA410()
        {
            return AutoConnect();
        }
        public bool CloseConnect_CA410()
        {
            return Disconnect();
        }

    }
}
