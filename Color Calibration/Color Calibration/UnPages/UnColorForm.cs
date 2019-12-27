using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;
using Color_Calibration.ComLib;
using System.IO;
using System.Threading;
using HZH_Controls.Forms;

namespace Color_Calibration.UnPages
{
    public partial class UnColorForm : UserControl
    {
        #region ColorPgae Object
        List<object> lstSource = new List<object>();
        private List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
        public event ComLib.ComEvent.DataSendHandler DataSend;
        private UCPagerControl2 page = new UCPagerControl2();
        private IntPtr i1d3Handle;
        private byte Index = 1;
        private MainForm _mainForm;
        #region GB
        private int uColorTempNCW = 0;                       // Cool, Normal, Warm color temp
        private int[,] uColorTempStd = new int[4, 3];        // x, y ,Lv
        private int uColorTempMode = 0;                      // customer
        private float[,] uColorTempCurr = new float[4, 3];   // x, y, Lv result
        private int[] uColorTempNCW_OK = new int[5];         // result, 0 for succuss, 1 for fail
        private int[] NCW_OK = new int[4];

        private int Adjust_State = 0;                        // for timer event state
        private int Adjust_Repeat = 0;
        private byte Adjust_StepLength = 8;
        private byte Adjust_MaxValue = 128;
        private byte Adjust_MaxValue_Backup = 128;
        private int Adjust_Result = 0;
        private int TVReturnStatus = 1;
        private bool TargetType_Monitor = false;

        private bool uUartReceiveFlag = false;
        private int LvMinus_Count = 5;     // 0:100%, 1:95%, 2:90%, 3:85%; 4:80%, 5:75%, 6:70%, 7:65%, 8:60%, 9:55%, 10:50%
        private int starColor = 0;

        private float Panel_Lv_max = 250;
        private float Brightness_Tolerance = 20;
        private float Temp_Tolerance = 50;
        private float Cool_TargetBrightness = 210;
        private float Standard_TargetBrightness = 210;
        private float Warm_TargetBrightness = 210;
        private float User_TargetBrightness = 210;
        // for Measure
        public float uCompare_Sx = 2600;
        public float uCompare_Sy = 2400;
        public float uCompare_Lv = 210;

        public float ucMeasure_Sx = 2600;
        public float ucMeasure_Sy = 2400;
        public float ucMeasure_Lv = 210;
        public float ucPrevMeasure_Sx = 2750;
        public float ucPrevMeasure_Sy = 2880;
        public float ucPrevMeasure_Lv = 250;

        private TimeSpan ts_total = new TimeSpan();
        private TimeSpan ts_diff = new TimeSpan();

        private DateTime startTime = new DateTime();
        private DateTime stopTime = new DateTime();
        private DateTime beginningTime = new DateTime();
        private DateTime endTime = new DateTime();

        private InitValue InitValueType = InitValue.DefaultValue;
        private bool UseMaxPanelLv75Percent = false;
        private bool StandardGGainGreaterThan128 = false;
        private bool SaveDefaultData = false;

        private byte[,] uColorTemp_Table = new byte[4, 3]
        {
            {
                128,128,128
            },
            {
                128,128,128
            },
            {
                128,128,128
            },
            {
                128,128,128
            }
        };

        private byte[,] uColorTempAdj_Data = new byte[4, 3]
        {
            {
                128,128,128
            },
            {
                128,128,128
            },
            {
                128,128,128
            },
            {
                128,128,128
            }
        };

        private int[,] uColorTemp_StartStepSum = new int[4, 4]
        {
            {
                0,0,0,0
            },
            {
                0,0,0,0
            },
            {
                0,0,0,0
            },
            {
                0,0,0,0
            }
        };

        private int[] uColorTemp_StartStepIndex = new int[4] { 0, 0, 0, 0 };


        private int flag = (int)ColorTempNCW.Cool;
        #endregion
        #endregion
        #region Enum TypeData
        private enum InitValue
        {
            DefaultValue,       //0
            AverageVaule        //1
        };
        private enum RS232_CMD
        {
            INPUT_SOURCE_com,           //0x00
            TEMPERATURE_com,            //0x01
            R_GAIN_com,                 //0x02
            G_GAIN_com,                 //0x03
            B_GAIN_com,                 //0x04
            R_OFFSET_com,               //0x05
            G_OFFSET_com,               //0x06
            B_OFFSET_com,               //0x07
            COPY_TO_All_SOURCE_com,     //0x08
            ADC_CALIBRATION_com,        //0x09
            WHITE_PATTERN_com,          //0x0A
            GET_RGB_GAIN_DATA_com,      //0x0B
            RGB_GAIN_VALUE_com,         //0x0C
            R_GAIN_VALUE_com,           //0x0D
            G_GAIN_VALUE_com,           //0x0E
            B_GAIN_VALUE_com,           //0x0F
            AUTO_ADJUST_MODE_com,       //0x10
        };
        private enum ColorTempNCW
        {
            Cool,       //0
            Normal,     //1
            Warm,        //2
            User         //3
        };
        private enum ColorTempGain
        {
            Red,       //0
            Green,     //1
            Blue       //2
        };
        #endregion
        public UnColorForm()
        {
            InitializeComponent();
            //Init_Timer();
        }
        public void InitUmainForm(MainForm f)
        {
            _mainForm = f;
        }

        private void UnColorForm_Load(object sender, EventArgs e)
        {
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "ID", Width = 70, WidthType = SizeType.Absolute });
            //lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Backlight", HeadText = "Backlight", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "RGain", HeadText = "R Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "GGain", HeadText = "G Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "BGain", HeadText = "B Gain", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Lum", HeadText = "Luminance", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "xValue", HeadText = " X ", Width = 50, WidthType = SizeType.Percent });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "yValue", HeadText = " Y ", Width = 50, WidthType = SizeType.Percent });
            this.ucDataGridView_result.Columns = lstCulumns;
            this.ucDataGridView_result.IsShowCheckBox = false;
            /*
            for (int i = 0; i < 5; i++)
            {
                ColorGaridModel model = new ColorGaridModel()
                {
                    ID = (i + 1).ToString(),
                    Backlight = "100",
                    RGain = "128",
                    GGain = "128",
                    BGain = "128",
                    Lum = "80",
                    xValue = "0.285",
                    yValue = "0.293",
                };
                lstSource.Add(model);
            }
            */
            InitialGridData();
            page.Width = 34;
            page.DataSource = lstSource;
            //page.FirstPage();
            this.ucDataGridView_result.Page = page;
            //ucDataGridView_result.ReloadSource();
            this.ucDataGridView_result.First();

        }

        private void ucCheckBox_out_CheckedChangeEvent(object sender, EventArgs e)
        {
            if (ucCheckBox_out.Checked)
            {
                ucDataGridView_result.Columns[5].isVisible = false;
                ucDataGridView_result.Columns[6].isVisible = false;
                ucDataGridView_result.Columns[7].isVisible = false;
            }
            else
            {
                ucDataGridView_result.Columns[5].isVisible = true;
                ucDataGridView_result.Columns[6].isVisible = true;
                ucDataGridView_result.Columns[7].isVisible = true;
            }
            ucDataGridView_result.ReloadSource();
        }

        public void DataReceived(byte[] data)
        {
            int len = data.Length;
            byte Checksum = 0;
            if ((len == 12) && (data[0] == 0xAC) && (data[1] == 0x0C))
            {
                Checksum = (byte)(0xFF - (0xFF & (data[0] + data[1] + data[2] + data[3] + data[4] + data[5] + data[6] + data[7] + data[8] + data[9] + data[10])));
                if (Checksum == data[11])
                {
                    uUartReceiveFlag = true;
                    //ReceiveFlag = true;
                    //TVReturnStatus = 0;
                    if ((InitValueType == InitValue.DefaultValue) && (SaveDefaultData == false))
                    {
                        uColorTemp_Table[0, 0] = data[2];
                        uColorTemp_Table[0, 1] = data[3];
                        uColorTemp_Table[0, 2] = data[4];
                        uColorTemp_Table[1, 0] = data[5];
                        uColorTemp_Table[1, 1] = data[6];
                        uColorTemp_Table[1, 2] = data[7];
                        uColorTemp_Table[2, 0] = data[8];
                        uColorTemp_Table[2, 1] = data[9];
                        uColorTemp_Table[2, 2] = data[10];

                        SaveDefaultData = true;
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        Adjust_State = 0;
                        MessageBox.Show("获取屏幕默认参数失败! ");
                    }));
                }
            }
            else if ((len == 15) && (data[0] == 0xAC) && (data[1] == 0x0C))
            {
                Checksum = (byte)(0xFF - (0xFF & (data[0] + data[1] + data[2] + data[3] + data[4] + data[5] + data[6] + data[7] + data[8] + data[9] + data[10] + data[11] + data[12] + data[13])));
                if (Checksum == data[14])
                {
                    uUartReceiveFlag = true;
                    //ReceiveFlag = true;
                    //TVReturnStatus = 0;
                    if ((InitValueType == InitValue.DefaultValue) && (SaveDefaultData == false))
                    {
                        uColorTemp_Table[0, 0] = data[2];
                        uColorTemp_Table[0, 1] = data[3];
                        uColorTemp_Table[0, 2] = data[4];
                        uColorTemp_Table[1, 0] = data[5];
                        uColorTemp_Table[1, 1] = data[6];
                        uColorTemp_Table[1, 2] = data[7];
                        uColorTemp_Table[2, 0] = data[8];
                        uColorTemp_Table[2, 1] = data[9];
                        uColorTemp_Table[2, 2] = data[10];
                        uColorTemp_Table[3, 0] = data[11];
                        uColorTemp_Table[3, 1] = data[12];
                        uColorTemp_Table[3, 2] = data[13];
                        
                        SaveDefaultData = true;
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        Adjust_State = 0;
                        MessageBox.Show("获取屏幕色温参数失败! ");
                    }));
                }
            }
            else if ((len == 4) && (data[0] == 0xAC) && (data[1] == 0x04))
            {
                Checksum = (byte)(0xFF - (0xFF & (data[0] + data[1] + data[2])));
                if (Checksum == data[3])
                {
                    uUartReceiveFlag = true;
                    if (data[2] == 0)
                    {
                        TVReturnStatus = 0;
                    }
                    else
                    {
                        TVReturnStatus = 1;
                    }
                }
            }
        }

        #region Init && Get Set function
        private System.Windows.Forms.Timer timerClock = new System.Windows.Forms.Timer();
        public void Init_Timer()
        {
            timerClock.Tick += new EventHandler(this.OnTimerEvent);
            timerClock.Interval = 80;
            timerClock.Start();
        }

        private void Init_Var()
        {
            uColorTempStd[0, 0] = GlobalClass._t_ColorTempStd[0, 0];
            uColorTempStd[0, 1] = GlobalClass._t_ColorTempStd[0, 1];
            uColorTempStd[1, 0] = GlobalClass._t_ColorTempStd[1, 0];
            uColorTempStd[1, 1] = GlobalClass._t_ColorTempStd[1, 1];
            uColorTempStd[2, 0] = GlobalClass._t_ColorTempStd[2, 0];
            uColorTempStd[2, 1] = GlobalClass._t_ColorTempStd[2, 1];
            uColorTempStd[3, 0] = GlobalClass._t_ColorTempStd[3, 0];
            uColorTempStd[3, 1] = GlobalClass._t_ColorTempStd[3, 1];
            Cool_TargetBrightness = GlobalClass._t_ColorTempStd[0, 2];
            Standard_TargetBrightness = GlobalClass._t_ColorTempStd[1, 2];
            Warm_TargetBrightness = GlobalClass._t_ColorTempStd[2, 2];
            User_TargetBrightness = GlobalClass._t_ColorTempStd[3, 2];
            SetAdjustError(starColor);
            NCW_OK[0] = 0;
        }

        private byte GetNextId(byte id)
        {
            int all = MainColorModel.H_Row * MainColorModel.V_Colu;
            if(id < all)
            {
                return id++;
            }
            return (byte)all;
        }

        private void SetAdjustError(int uMode)
        {
            if (GlobalClass._t_ColorEeror[uMode])
            {
                Temp_Tolerance = GlobalClass._t_ColorEerorxy[uMode];
                Brightness_Tolerance = GlobalClass._t_ColorEerorlv[uMode];
                if (Temp_Tolerance < 10)
                    Temp_Tolerance = 10;
                if (Temp_Tolerance > 100)
                    Temp_Tolerance = 100;
                if (Brightness_Tolerance < 10)
                    Brightness_Tolerance = 10;
                if (Brightness_Tolerance > 100)
                    Brightness_Tolerance = 100;
            }
            else
            {
                Temp_Tolerance = 50;
                Brightness_Tolerance = 20;
            }
            //Console.WriteLine(Temp_Tolerance);
        }
        #endregion
        #region Math
        private float ABS(float x, float y)
        {
            if (x >= y)
                return x - y;
            else
                return y - x;
        }
        private float MAX(float x, float y)
        {
            if (x > y)
                return x;
            else
                return y;
        }
        private float MIN(float x, float y)
        {
            if (x < y)
                return x;
            else
                return y;
        }
        #endregion
        #region check function
        private bool checkrun(byte id)
        {
            int all = MainColorModel.H_Row * MainColorModel.V_Colu;
            if (all == id)
                return false;
            else
                return true;
        }
        private bool check(float stand_low_value, float stand_high_value, float currrent_value)
        {
            if ((stand_high_value >= currrent_value) && (stand_low_value <= currrent_value))
                return true;
            else
                return false;

        }

        private bool Check_lv_ok(float lv_compare, float lv_distance)
        {
            if (check(lv_compare - lv_distance, lv_compare + lv_distance, ucMeasure_Lv))    //Lv ok
            {
                return true;
            }
            return false;
        }

        private bool Check_y_temp_ok(float fy_type, float fxy_distance)
        {
            if (check(fy_type - fxy_distance, fy_type + fxy_distance, ucMeasure_Sy))    //fy ok
            {
                return true;
            }
            return false;
        }

        private bool Check_x_temp_ok(float fx_type, float fxy_distance)
        {
            if (check(fx_type - fxy_distance, fx_type + fxy_distance, ucMeasure_Sx))    //fx ok
            {
                return true;
            }
            return false;
        }

        private bool Check_temp_ok(float fx_type, float fy_type, float fxy_distance)
        {
            if (check(fy_type - fxy_distance, fy_type + fxy_distance, ucMeasure_Sy))    //fy ok
            {
                if (check(fx_type - fxy_distance, fx_type + fxy_distance, ucMeasure_Sx))    //fx ok
                {
                    return true;
                }
            }
            return false;
        }

        private bool Check_lv_temp_ok(float fx_type, float fy_type, float fxy_distance, float lv_compare, float lv_distance)
        {
            if (check(fy_type - fxy_distance, fy_type + fxy_distance, ucMeasure_Sy))    //fy ok
            {
                if (check(fx_type - fxy_distance, fx_type + fxy_distance, ucMeasure_Sx))    //fx ok
                {
                    if (check(lv_compare - lv_distance, lv_compare + lv_distance, ucMeasure_Lv))    //Lv ok
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Check_RGB_saturation()
        {
            if (ABS(ucPrevMeasure_Lv, ucMeasure_Lv) < 2)
            {
                return true;
            }
            return false;
        }

        private bool Check_saturation()
        {
            if ((ABS(ucPrevMeasure_Lv, ucMeasure_Lv) < 0.5) && (ABS(ucPrevMeasure_Sy, ucMeasure_Sy) < 5) && (ABS(ucPrevMeasure_Sx, ucMeasure_Sx) < 5))
            {
                return true;
            }
            return false;
        }

        private bool check_cmd_return()
        {
            if (uUartReceiveFlag == true)
            {
                uUartReceiveFlag = false;
                if (TVReturnStatus == 0)
                {
                    //Console.WriteLine(true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Console.WriteLine(false);
            return false;
        }
        #endregion
        #region Measure & ColorTemp
        // measure color temp
        private void Measure_CA210()
        {
            //m_ICa.Measure(1);

            ucPrevMeasure_Sx = ucMeasure_Sx;
            ucPrevMeasure_Sy = ucMeasure_Sy;
            ucPrevMeasure_Lv = ucMeasure_Lv;

            //ucMeasure_Sx = m_IProbe.sx * 10000;
            //ucMeasure_Sy = m_IProbe.sy * 10000;
            //ucMeasure_Lv = m_IProbe.Lv;
        }
        private void Measure_i1d3()
        {
            CalibrationSDK.i1dColorSDK.i1d3Yxy_t m_dYxyMeas = new CalibrationSDK.i1dColorSDK.i1d3Yxy_t();

            CalibrationSDK.i1dColorSDK.i1d3Status_t m_err = CalibrationSDK.i1dColorSDK.i1d3MeasureYxy(i1d3Handle, ref m_dYxyMeas);
            if (m_err != CalibrationSDK.i1dColorSDK.i1d3Status_t.i1d3Success)
            {
                FrmDialog.ShowDialog(this, "   Error for " + m_err.ToString(), "提示", false);
                return;
            }
            string lv = string.Format("{0:N3}", m_dYxyMeas.Y);
            string x = string.Format("{0:N3}", m_dYxyMeas.x);
            string y = string.Format("{0:N3}", m_dYxyMeas.y);

            ucPrevMeasure_Sx = ucMeasure_Sx;
            ucPrevMeasure_Sy = ucMeasure_Sy;
            ucPrevMeasure_Lv = ucMeasure_Lv;

            //Console.WriteLine("OK =" + lv + " - " + x + " - " + y);
            ucMeasure_Sx = float.Parse(x) * 10000;
            ucMeasure_Sy = float.Parse(y) * 10000;
            ucMeasure_Lv = float.Parse(lv);
        }
        private void SetColorTempNCW(int uMode)
        {
            uColorTempNCW = uMode;
        }

        private void ColorTempAdjStepUpdate(int uCompare_Step)
        {
            if (uCompare_Step == (int)ColorTempNCW.Cool)
            {
                uCompare_Sx = uColorTempStd[0, 0];
                uCompare_Sy = uColorTempStd[0, 1];
            }
            else if (uCompare_Step == (int)ColorTempNCW.Normal)
            {
                uCompare_Sx = uColorTempStd[1, 0];
                uCompare_Sy = uColorTempStd[1, 1];
            }
            else if (uCompare_Step == (int)ColorTempNCW.Warm)
            {
                uCompare_Sx = uColorTempStd[2, 0];
                uCompare_Sy = uColorTempStd[2, 1];
            }
            else if (uCompare_Step == (int)ColorTempNCW.User)
            {
                uCompare_Sx = uColorTempStd[3, 0];
                uCompare_Sy = uColorTempStd[3, 1];
            }
            else
            {
                uCompare_Sx = uColorTempStd[0, 0];
                uCompare_Sy = uColorTempStd[0, 1];
            }
        }

        private int GetColorTempNCW()
        {
            return uColorTempNCW;
        }
        #endregion
        private int key = 30;
        #region  OnTimer 调整过程
        public void OnTimerEvent(Object myObject, EventArgs myEventArgs)
        {
            //Console.WriteLine("Adjust_State:" + Adjust_State + "=" + Adjust_Repeat);
            //ucledNums1.Value = Adjust_State.ToString();
            switch (Adjust_State)
            {
                #region initial
                case 0:     // waiting
                    // do nothing
                    {
                        {
                            Adjust_Repeat = 0;
                            Adjust_State = 0;
                            Application.DoEvents();
                        }
                    }
                    break;

                case 1:     // start white balance adjust
                    {
                        startTime = DateTime.Now;
                        ucledNums1.Visible = false;
                        //richTextBox3.Text = "调整时间: ";
                        timerClock.Interval = 150;
                        timerClock.Start();
                        TVReturnStatus = 1;
                        if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 1, 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 2;
                    }
                    break;

                case 2:     // get RGB Gain data
                    {
                        Thread.Sleep(200);
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            if (InitValueType == InitValue.DefaultValue)
                            {
                                if (SaveDefaultData == false)
                                {
                                    if (send_normal_com((byte)RS232_CMD.GET_RGB_GAIN_DATA_com, 0, 0, 0))
                                    {
                                        break;
                                    }
                                }
                            }
                            Adjust_State = 3;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat < 10)
                            {
                                if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 1, 0, 0))
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Adjust_Repeat = 0;
                                timerClock.Stop();
                                FrmDialog.ShowDialog(this, "   无法正常接收设备的调试反馈信息，请停止校准调试，     检查设备的连线和设备的开启情况 ! ", "提示", false);
                                break;
                            }
                        }
                    }
                    break;

                case 3:     // change input source to hdmi
                    {
                        if (check_cmd_return())
                        {
                            //send_normal_com((byte)RS232_CMD.INPUT_SOURCE_com, 0, 0, 0);     // 0 for hdmi
                            uColorTempNCW_OK[0] = 1;
                            uColorTempNCW_OK[1] = 1;
                            uColorTempNCW_OK[2] = 1;
                            uColorTempNCW_OK[3] = 1;
                            uColorTempNCW_OK[4] = 1;
                            
                            Adjust_Result = 0;
                            Adjust_Repeat = 0;
                            if (UseMaxPanelLv75Percent)
                            {
                                if (InitValueType == InitValue.DefaultValue)
                                {
                                    LvMinus_Count = 5;
                                }
                                else
                                {
                                    LvMinus_Count = 5 + uColorTemp_StartStepIndex[(int)ColorTempNCW.Cool];
                                }
                            }

                            if (TargetType_Monitor == false)
                            {
                                if (InitValueType == InitValue.DefaultValue)
                                {
                                    timerClock.Interval = 80;
                                    Adjust_State = 10;
                                }
                                else
                                {
                                    Adjust_MaxValue = Adjust_MaxValue_Backup;
                                    timerClock.Interval = 75;
                                    Adjust_State = 14;
                                }
                            }
                            else
                            {
                                Adjust_MaxValue = 128;
                                timerClock.Interval = 75;
                                Adjust_State = 14;
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.GET_RGB_GAIN_DATA_com, 0, 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 10:
                    {
                        Adjust_Repeat = 0;
                        SetColorTempNCW(starColor);
                        SetAdjustError(starColor);
                        if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 11;
                    }
                    break;

                case 11:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] = 128;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] = 128;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] = 128;
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }
                            Adjust_State = 12;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 12:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;

                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                //MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
                                FrmDialog.ShowDialog(this, "请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！", "提示", false);
                                break;
                            }

                            Adjust_StepLength = 8;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] += Adjust_StepLength;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] += Adjust_StepLength;
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] += Adjust_StepLength;
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }

                            Adjust_State = 13;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 13:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;

                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                //MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
                                FrmDialog.ShowDialog(this, "请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！", "提示", false);
                                break;
                            }

                            if (Check_RGB_saturation())
                            {
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] -= (byte)(Adjust_StepLength * 2);
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] -= (byte)(Adjust_StepLength * 2);
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] -= (byte)(Adjust_StepLength * 2);
                                Adjust_StepLength = (byte)(Adjust_StepLength / 2);
                                if (Adjust_StepLength == 1)
                                {
                                    Adjust_MaxValue = (byte)(uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green]);
                                    if (Adjust_MaxValue < Adjust_MaxValue_Backup)
                                    {
                                        Adjust_MaxValue = Adjust_MaxValue_Backup;
                                    }
                                    else
                                    {
                                        if (InitValueType == InitValue.DefaultValue)
                                        {
                                            Adjust_MaxValue_Backup = Adjust_MaxValue;
                                        }
                                    }

                                    timerClock.Interval = 75;
                                    Adjust_State = 14;
                                    break;
                                }
                            }
                            else
                            {
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] += Adjust_StepLength;
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] += Adjust_StepLength;
                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] += Adjust_StepLength;
                            }

                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }
                            Adjust_State = 13;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 14:    // turn on white pattern
                    {
                        Adjust_Repeat = 0;
                        if (send_normal_com((byte)RS232_CMD.WHITE_PATTERN_com, 1, 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 15;
                    }
                    break;

                case 15:    // turn off white pattern
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            timerClock.Stop();
                            Thread.Sleep(300);
                            Measure_i1d3();
                            Thread.Sleep(200);
                            timerClock.Interval = 100;
                            timerClock.Start();
                            Panel_Lv_max = ucMeasure_Lv;
                            //richTextBox11.Text = Panel_Lv_max.ToString().Substring(0, 5);
                            Console.WriteLine(ucMeasure_Lv + "=" + Adjust_MaxValue);
                            if (Panel_Lv_max < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                //MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
                                FrmDialog.ShowDialog(this, "请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！", "提示", false);
                            }
                            else
                            {
                                if (send_normal_com((byte)RS232_CMD.WHITE_PATTERN_com, 0, 0, 0))
                                {
                                    break;
                                }
                                Adjust_State = 25;
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.WHITE_PATTERN_com, 1, 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region loop adjust
                // load default table, case 25 to case 27
                case 25:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            SetColorTempNCW(starColor);
                            timerClock.Interval = 100;
                            Adjust_State = 26;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.WHITE_PATTERN_com, 0, 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 26:
                    {
                        Adjust_Repeat = 0;
                        beginningTime = DateTime.Now;
                        timerClock.Start();
                        ColorTempAdjStepUpdate(GetColorTempNCW());
                        if (uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Red] > Adjust_MaxValue)
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] = Adjust_MaxValue;
                        }
                        else
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] = uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Red];
                        }
                        if (uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Green] > Adjust_MaxValue)
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] = Adjust_MaxValue;
                        }
                        else
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] = uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Green];
                        }
                        if (uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Blue] > Adjust_MaxValue)
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] = Adjust_MaxValue;
                        }
                        else
                        {
                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] = uColorTemp_Table[GetColorTempNCW(), (int)ColorTempGain.Blue];
                        }
                        if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 27;
                    }
                    break;

                case 27:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }

                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15))
                                {
                                    if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                    {
                                        uCompare_Lv = (float)(float.Parse("75") / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                    {
                                        uCompare_Lv = (float)(float.Parse("75") / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                    {
                                        uCompare_Lv = (float)(float.Parse("75") / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                    {
                                        uCompare_Lv = (float)(float.Parse("75") / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                }
                                else
                                {
                                    uCompare_Lv = (float)(Panel_Lv_max * (1 - 0.05 * LvMinus_Count));
                                }
                            }
                            else
                            {
                                if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                {
                                    uCompare_Lv = Cool_TargetBrightness;
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                {
                                    uCompare_Lv = Standard_TargetBrightness;
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                {
                                    uCompare_Lv = Warm_TargetBrightness;
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                {
                                    uCompare_Lv = User_TargetBrightness;
                                }
                            }
                            //Brightness_Tolerance = float.Parse(richTextBox33.Text) * Panel_Lv_max / 100;
                            //Brightness_Tolerance = float.Parse(richTextBox33.Text) * uCompare_Lv / 100;//目标亮度误差计算
                            Adjust_StepLength = 2;
                            Adjust_State = 30;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
                // load default table, case 25 to case 27
                case 30:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                //MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
                                FrmDialog.ShowDialog(this, "请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！", "提示", false);
                                break;
                            }

                            if (Check_lv_temp_ok(uCompare_Sx, uCompare_Sy, Temp_Tolerance, uCompare_Lv, Brightness_Tolerance))
                            {
                                if (ucMeasure_Sx < ucMeasure_Sy)
                                {
                                    uColorTempNCW_OK[GetColorTempNCW()] = 0;
                                    Adjust_State = 98;
                                }
                                else
                                {
                                    uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] -= 6;
                                    uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] += 1;
                                    uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] -= 2;
                                    if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                    {
                                        break;
                                    }
                                    Adjust_State = 30;
                                }
                            }
                            else
                            {
                                Adjust_State = 31;

                                endTime = DateTime.Now;
                                ts_diff = endTime - beginningTime;
                                if (ts_diff.TotalSeconds > 50)
                                {
                                    Adjust_State = 99;
                                    break;
                                }

                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 31:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;

                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                break;
                            }
                            else
                            {
                                if (!Check_lv_ok(uCompare_Lv, Brightness_Tolerance))
                                {
                                    if (ABS(ucMeasure_Lv, uCompare_Lv) > 100)
                                    {
                                        Adjust_StepLength = (byte)(ABS(ucMeasure_Lv, uCompare_Lv) / 30 * 2);
                                    }
                                    else if (ABS(ucMeasure_Lv, uCompare_Lv) > 30)
                                    {
                                        Random r = new Random();
                                        Adjust_StepLength = (byte)r.Next(2, 3);
                                    }
                                    else if (ABS(ucMeasure_Lv, uCompare_Lv) > 20)
                                    {
                                        Random r = new Random();
                                        Adjust_StepLength = (byte)r.Next(1, 2);
                                    }
                                    else
                                        Adjust_StepLength = 1;

                                    if (ucMeasure_Lv > uCompare_Lv + Brightness_Tolerance)
                                    {
                                        uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] -= Adjust_StepLength;
                                    }
                                    else if (ucMeasure_Lv < uCompare_Lv - Brightness_Tolerance)
                                    {
                                        if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] < (Adjust_MaxValue - Adjust_StepLength))
                                        {
                                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] += Adjust_StepLength;
                                        }
                                        else
                                        {
                                            if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] >= Adjust_MaxValue)
                                            {
                                                Adjust_State = 34;
                                                break;
                                            }
                                            else
                                            {
                                                uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green] = Adjust_MaxValue;
                                            }
                                        }
                                    }

                                    Adjust_State = 31;
                                }
                                else
                                {
                                    Adjust_State = 32;
                                }
                            }
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 32:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;

                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                break;
                            }

                            if (!Check_y_temp_ok(uCompare_Sy, Temp_Tolerance))
                            {
                                if (ABS(ucMeasure_Sy, uCompare_Sy) > 100)
                                {
                                    Adjust_StepLength = (byte)(ABS(ucMeasure_Sy, uCompare_Sy) / 30 * 2);
                                }
                                else if (ABS(ucMeasure_Sy, uCompare_Sy) > 50)
                                {
                                    Random r = new Random();
                                    Adjust_StepLength = (byte)r.Next(2, 3);
                                }
                                else if (ABS(ucMeasure_Sy, uCompare_Sy) > 20)
                                {
                                    Adjust_StepLength = 2;
                                }
                                else
                                    Adjust_StepLength = 1;
                                
                                if (ucMeasure_Sy > uCompare_Sy + Temp_Tolerance)
                                {
                                    if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] <= (Adjust_MaxValue - Adjust_StepLength))
                                    {
                                        uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] += Adjust_StepLength;
                                    }
                                    else
                                    {
                                        if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] >= Adjust_MaxValue)
                                        {
                                            Adjust_State = 34;
                                            break;
                                        }
                                        else
                                        {
                                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] = Adjust_MaxValue;
                                        }
                                    }
                                }
                                else if (ucMeasure_Sy < uCompare_Sy - Temp_Tolerance)
                                {
                                    uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue] -= Adjust_StepLength;
                                }

                                Adjust_State = 32;
                            }
                            else
                            {
                                Adjust_State = 33;
                            }
                            
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 20)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 33:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;

                            Measure_i1d3();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                break;
                            }

                            if (!Check_x_temp_ok(uCompare_Sx, Temp_Tolerance))
                            {
                                if (ABS(ucMeasure_Sx, uCompare_Sx) > 100)
                                {
                                    Adjust_StepLength = (byte)(ABS(ucMeasure_Sx, uCompare_Sx) / 35 * 3);
                                }
                                else if (ABS(ucMeasure_Sy, uCompare_Sy) > 50)
                                {
                                    Random r = new Random();
                                    Adjust_StepLength = (byte)r.Next(2, 3);
                                }
                                else if (ABS(ucMeasure_Sx, uCompare_Sx) > 30)
                                {
                                    Random r = new Random();
                                    Adjust_StepLength = (byte)r.Next(1, 2);
                                }
                                else
                                    Adjust_StepLength = 1;

                                if (ucMeasure_Sx > uCompare_Sx + Temp_Tolerance)
                                {
                                    uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] -= Adjust_StepLength;
                                }
                                else if (ucMeasure_Sx < uCompare_Sx - Temp_Tolerance)
                                {
                                    if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] <= (Adjust_MaxValue - Adjust_StepLength))
                                    {
                                        uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] += Adjust_StepLength;
                                    }
                                    else
                                    {
                                        if (uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] >= Adjust_MaxValue)
                                        {
                                            Adjust_State = 34;
                                            break;
                                        }
                                        else
                                        {
                                            uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red] = Adjust_MaxValue;
                                        }
                                    }
                                }

                                Adjust_State = 33;
                            }
                            else
                            {
                                Adjust_State = 30;
                            }
                            
                            if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                            {
                                break;
                            }
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 20)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.RGB_GAIN_VALUE_com, uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Red], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Green], uColorTempAdj_Data[GetColorTempNCW(), (int)ColorTempGain.Blue]))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 34:
                    {
                        if (UseMaxPanelLv75Percent)
                        {
                            Adjust_Repeat = 0;
                            LvMinus_Count++;
                            Adjust_State = 26;

                            if ((uColorTempMode == 15))
                            {
                                uColorTempNCW_OK[GetColorTempNCW()] = 1;
                                Adjust_State = 99;
                            }
                            else
                            {
                                if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                {
                                    if (LvMinus_Count > 10)
                                    {
                                        LvMinus_Count = 5;
                                        uColorTempNCW_OK[GetColorTempNCW()] = 1;
                                        Adjust_State = 99;
                                    }
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                {
                                    if (LvMinus_Count > 8)
                                    {
                                        LvMinus_Count = 5;
                                        uColorTempNCW_OK[GetColorTempNCW()] = 1;
                                        Adjust_State = 99;
                                    }
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                {
                                    if (LvMinus_Count > 10)
                                    {
                                        LvMinus_Count = 5;
                                        uColorTempNCW_OK[GetColorTempNCW()] = 1;
                                        Adjust_State = 99;
                                    }
                                }
                                else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                {
                                    if (LvMinus_Count > 10)
                                    {
                                        LvMinus_Count = 5;
                                        uColorTempNCW_OK[GetColorTempNCW()] = 1;
                                        Adjust_State = 99;
                                    }
                                }
                            }
                        }
                        else
                        {
                            uColorTempNCW_OK[GetColorTempNCW()] = 1;
                            Adjust_State = 99;
                        }
                    }
                    break;
                #endregion
                #region Adjust result
                #region Result set UI
                case 98:
                    {
                        Adjust_Repeat = 0;
                        if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                        {
                            uColorTempCurr[0, 0] = ucMeasure_Sx / 10000;
                            uColorTempCurr[0, 1] = ucMeasure_Sy / 10000;
                            uColorTempCurr[0, 2] = ucMeasure_Lv;

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ColorGaridModel model = new ColorGaridModel();
                                model.ID = Index.ToString();
                                model.RGain = uColorTempAdj_Data[0, 0].ToString();
                                model.GGain = uColorTempAdj_Data[0, 1].ToString();
                                model.BGain = uColorTempAdj_Data[0, 2].ToString();
                                model.xValue = uColorTempCurr[0, 0].ToString();
                                model.yValue = uColorTempCurr[0, 1].ToString();
                                model.Lum = uColorTempCurr[0, 2].ToString();
                                //model.Backlight = "100";
                                UpdateGaridSource(model);

                            }));

                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15))
                                {
                                    //richTextBox34.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox34.ForeColor = Color.Green;
                                }
                                else
                                {
                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Cool, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                        {
                            uColorTempCurr[1, 0] = ucMeasure_Sx / 10000;
                            uColorTempCurr[1, 1] = ucMeasure_Sy / 10000;
                            uColorTempCurr[1, 2] = ucMeasure_Lv;

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ColorGaridModel model = new ColorGaridModel();
                                model.ID = Index.ToString();
                                model.RGain = uColorTempAdj_Data[1, 0].ToString();
                                model.GGain = uColorTempAdj_Data[1, 1].ToString();
                                model.BGain = uColorTempAdj_Data[1, 2].ToString();
                                model.xValue = uColorTempCurr[1, 0].ToString();
                                model.yValue = uColorTempCurr[1, 1].ToString();
                                model.Lum = uColorTempCurr[1, 2].ToString();
                                //model.Backlight = "100";
                                UpdateGaridSource(model);
                            }));


                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15))
                                {
                                    //richTextBox35.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox35.ForeColor = Color.Green;
                                }
                                else
                                {

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Normal, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                        {
                            uColorTempCurr[2, 0] = ucMeasure_Sx / 10000;
                            uColorTempCurr[2, 1] = ucMeasure_Sy / 10000;
                            uColorTempCurr[2, 2] = ucMeasure_Lv;

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ColorGaridModel model = new ColorGaridModel();
                                model.ID = Index.ToString();
                                model.RGain = uColorTempAdj_Data[2, 0].ToString();
                                model.GGain = uColorTempAdj_Data[2, 1].ToString();
                                model.BGain = uColorTempAdj_Data[2, 2].ToString();
                                model.xValue = uColorTempCurr[2, 0].ToString();
                                model.yValue = uColorTempCurr[2, 1].ToString();
                                model.Lum = uColorTempCurr[2, 2].ToString();
                                //model.Backlight = "100";
                                UpdateGaridSource(model);
                            }));

                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15))
                                {
                                    //richTextBox36.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox36.ForeColor = Color.Green;
                                }
                                else
                                {

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Warm, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                        {
                            uColorTempCurr[3, 0] = ucMeasure_Sx / 10000;
                            uColorTempCurr[3, 1] = ucMeasure_Sy / 10000;
                            uColorTempCurr[3, 2] = ucMeasure_Lv;

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ColorGaridModel model = new ColorGaridModel();
                                model.ID = Index.ToString();
                                model.RGain = uColorTempAdj_Data[3, 0].ToString();
                                model.GGain = uColorTempAdj_Data[3, 1].ToString();
                                model.BGain = uColorTempAdj_Data[3, 2].ToString();
                                model.xValue = uColorTempCurr[3, 0].ToString();
                                model.yValue = uColorTempCurr[3, 1].ToString();
                                model.Lum = uColorTempCurr[3, 2].ToString();
                                //model.Backlight = "100";
                                UpdateGaridSource(model);
                            }));

                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15))
                                {
                                    //richTextBox53.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox53.ForeColor = Color.Green;
                                }
                                else
                                {
                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.User, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                            }
                        }

                        // adjust
                        while (uColorTempNCW_OK[GetColorTempNCW()] == 0)
                        {
                            switch (starColor)
                            {
                                case 0:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(1);
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(2);
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(3);
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(4);
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            if (GetColorTempNCW() > flag)
                            {
                                Adjust_State = 99;
                                break;
                            }
                        }

                        if (GetColorTempNCW() <= flag)
                        {
                            if (UseMaxPanelLv75Percent)
                            {
                                if (InitValueType == InitValue.DefaultValue)
                                {
                                    if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                    {
                                        LvMinus_Count = 5;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                    {
                                        LvMinus_Count = 5;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                    {
                                        LvMinus_Count = 5;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                    {
                                        LvMinus_Count = 5;
                                    }
                                }
                                else
                                {
                                    if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                    {
                                        LvMinus_Count = 5 + uColorTemp_StartStepIndex[(int)ColorTempNCW.Normal];
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                    {
                                        LvMinus_Count = 5 + uColorTemp_StartStepIndex[(int)ColorTempNCW.Cool];
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                    {
                                        LvMinus_Count = 5 + uColorTemp_StartStepIndex[(int)ColorTempNCW.Warm];
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                    {
                                        LvMinus_Count = 5 + uColorTemp_StartStepIndex[(int)ColorTempNCW.User];
                                    }
                                }
                            }
                            Adjust_State = 26;
                        }
                    }
                    break;

                case 99:
                    {
                        Adjust_Repeat = 0;
                        if ((uColorTempNCW_OK[starColor] == NCW_OK[starColor]))
                        {
                            if (StandardGGainGreaterThan128)
                            {
                                if (uColorTempAdj_Data[1, 1] < 128)
                                {
                                    Adjust_Result = 2;    // fail to < 128
                                    Adjust_State = 120;
                                    break;
                                }
                            }
                            if (send_normal_com((byte)RS232_CMD.COPY_TO_All_SOURCE_com, 0, 0, 0))
                            {
                                break;
                            }

                            timerClock.Interval = 100;
                            Adjust_State = 100;    // pass
                        }
                        else
                        {
                            Adjust_Result = 1;    // fail
                            Adjust_State = 120;
                        }
                    }
                    break;

                case 100:
                    {
                        Adjust_Repeat++;
                        if (Adjust_Repeat > 10)
                        {
                            Adjust_Repeat = 0;
                            Adjust_State = 110;
                        }
                    }
                    break;

                case 110:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            Adjust_State = 111;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.COPY_TO_All_SOURCE_com, 0, 0, 0))
                                {
                                    break;
                                }
                                Adjust_State = 100;
                            }
                        }
                    }
                    break;

                case 111:
                    {
                        Adjust_Repeat = 0;
                        timerClock.Interval = 100;
                        Adjust_Result = 3;    // pass
                        Adjust_State = 118;
                    }
                    break;

                case 118:
                    {
                        Adjust_Repeat = 0;
                        SetColorTempNCW(starColor);
                        if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 119;
                    }
                    break;

                case 119:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            Measure_i1d3();
                            Adjust_State = 120;
                        }
                        else
                        {
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.TEMPERATURE_com, (byte)GetColorTempNCW(), 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 120:
                    {
                        Adjust_Repeat = 0;
                        if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 0, 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 121;
                    }
                    break;
                #endregion
                case 121:
                    {
                        if (check_cmd_return())
                        {
                            if (Adjust_Result == 3)
                            {
                                //richTextBox21.ForeColor = Color.Green;
                                //richTextBox21.Text = "成功";
                                //timerClock.Stop();
                                //Console.WriteLine("ID = "+ Index + " 的屏幕色温校准完成！");
                                //Thread.Sleep(2000);
                                if (Index <= MainColorModel.H_Row * MainColorModel.V_Colu && MainColorModel.M_ModelType == 1)
                                {
                                    timerClock.Interval = 2000;
                                    FrmTips.ShowTipsInfo(_mainForm, " ID = " + Index + " 的屏幕色温校准完成！");
                                    Index++;
                                    label1_tips.Text = "Put the sensor on monitor : ID = " + Index + ", Wait for adjustments to occur automatically.";
                                    label1_tips.ForeColor = Color.Purple;
                                    ucledNums1.Visible = true;
                                    break;
                                }
                            }
                            else if (Adjust_Result == 2)
                            {
                                //richTextBox21.ForeColor = Color.Yellow;
                                //richTextBox21.Text = "失败";
                                Console.WriteLine("失败");
                            }
                            else
                            {
                                Adjust_State = 0;
                                timerClock.Stop();
                                FrmTips.ShowTips(_mainForm, "ID = < " + Index + " > 的屏幕色温校准失败！", 1500, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                                Console.WriteLine("失败");
                                break;
                            }

                            Adjust_Repeat = 0;
                            Adjust_Result = 0;
                            stopTime = DateTime.Now;
                            ts_total = stopTime - startTime;
                            timerClock.Interval = 2000;
                            //button2.Text = "开始";
                            //richTextBox3.Text = "调整时间: " + ((int)ts_total.TotalSeconds).ToString() + "秒";
                            //uColorTempControlEnable(true);
                            //if (!Adjust_DateOk)
                            //MessageBox.Show("调整后的数据对比有误，请重新进行调整！","提示");
                            FrmTips.ShowTips(_mainForm, "当前设备的屏幕色温校准完成！", 2000, true, ContentAlignment.MiddleCenter, null, TipsSizeMode.Large, new Size(300, 50), TipsState.Info);
                        }
                        else
                        {
                            if (Adjust_Result == 3)
                            {
                                timerClock.Interval = 1200;
                                ucledNums1.Value = key.ToString();
                                //Application.DoEvents();
                                FrmTips.ShowTipsInfo(_mainForm, "请在" + key + "S 内完成校色设备的调整！");
                                key--;
                                if (key < 1)
                                {
                                    timerClock.Stop();
                                    key = 30;
                                    ucledNums1.Visible = false;
                                    Adjust_State = 1;
                                    timerClock.Interval = 200;
                                    timerClock.Start();
                                }
                                break;
                            }
                            Adjust_Repeat++;
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 0, 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
                #endregion
                default:
                    Adjust_State = 0;
                    Adjust_Repeat = 0;
                    Adjust_Result = 0;
                    break;
            }
        }
        #endregion
        
        #region DataSend & GridUI
        /// <summary>
        /// 调整数据发送接口
        /// </summary>
        /// <param name="com"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <returns></returns>
        private bool send_normal_com(byte com, byte value1, byte value2, byte value3)
        {
            // TODO: Add your control notification handler code here
            byte[] P = new byte[8];
            P[0] = 0xAB;
            P[1] = 0x8;
            if(MainColorModel.M_ModelType == 1)
                P[2] = Index;
            else
                P[2] = 0xFD;
            P[3] = com;
            P[4] = value1;
            P[5] = value2;
            P[6] = value3;
            P[7] = (byte)(0xFF - (byte)(0xFF & (P[0] + P[1] + P[2] + P[3] + P[4] + P[5] + P[6])));

            try
            {
                DataSend(P);
                //Console.WriteLine("send" + P[2]);
            }
            catch
            {
                //serialPort1.Close();
                Adjust_State = 0;
                FrmDialog.ShowDialog(this, " 串口连接中断,请检查USB连线！\n并且，请关闭本软件，重新打开！", "提示", false);
                //MessageBox.Show("");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 结果列表更新
        /// </summary>
        /// <param name="model"></param>
        private void UpdateGaridSource(ColorGaridModel model)
        {
            bool mach = true;
            for (int i = 0; i < lstSource.Count; i++)
            {
                ColorGaridModel md = lstSource[i] as ColorGaridModel;
                if (md.ID == model.ID)
                {
                    lstSource.RemoveAt(i);
                    lstSource.Insert(i, model);
                    mach = false;
                }
            }
            if(mach)
                lstSource.Add(model);
            page.DataSource = lstSource;
            this.ucDataGridView_result.Page = page;
            if (mach)
            {
                ucDataGridView_result.End();
                page.EndPage();
            }
            //ucDataGridView_result.Refresh();
        }
        #endregion
        #region RunButton
        /// <summary>
        /// 执行控制按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucBtn_Execute_BtnClick(object sender, EventArgs e)
        {
            i1d3Handle = GlobalClass.i1d3Handle;
            //_mainForm.UpdateUIStatus();
            if (GlobalClass.m_cIsRunning == false)
            {
                if (GlobalClass.m_bIsOpen && GlobalClass.c_bIsOpen)
                {
                    starColor = MainColorModel.T_Temp;
                    if (Adjust_State == 0)
                    {
                        Index = 1;
                        Adjust_State = 1;
                        flag = starColor;
                        Init_Var();
                        timerClock.Enabled = true;
                        Init_Timer();
                    }
                    else if (Adjust_State == 121)
                    {
                        timerClock.Start();
                        //Console.WriteLine("countinue 121 =" + Index);

                    }
                    else
                    {
                        //Console.WriteLine("stop = " + Index);
                        Adjust_Result = 0;    // fail
                        Init_Timer();
                    }
                    GlobalClass.m_cIsRunning = true;
                    ucBtn_Execute.Text = "Stop...";
                    ucBtn_Execute.ForeColor = Color.Red;
                }
                else
                {
                    FrmDialog.ShowDialog(this, "  校色设备或者串口通讯没有正常连接 ! ", "连接提示", false);
                    return;
                }
            }
            else
            {
                timerClock.Stop();
                if (Adjust_Result != 3)
                {
                    Index = 1;
                    Adjust_State = 0;
                    timerClock.Enabled = false;
                }
                GlobalClass.m_cIsRunning = false;
                ucBtn_Execute.Text = "Execute";
                ucBtn_Execute.ForeColor = Color.Purple;
            }
        }
        #endregion
        #region 调整数据初始化，保存，清空
        private void Init_SavePath()
        {
            string _path = Application.StartupPath + "\\ColorData";
            if (!Directory.Exists(_path + "\\"))
            {
                Directory.CreateDirectory(_path + "\\");
                //Console.WriteLine("create");
            }
        }
        private void SaveGridData()
        {
            try
            {
                string path = Application.StartupPath + "\\ColorData\\adjust_data.xml";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                SerializeModel.PathFile = path;
                
                List<ColorGaridModel> ListData = new List<ColorGaridModel>();
                
                for (int i = 0; i < lstSource.Count; i++)
                {
                    ListData.Add(lstSource[i] as ColorGaridModel);
                    //SerializeModel.XMLSerialize<ColorGaridModel>(model);
                }
                string Ok = "";
                if (ListData != null)
                    Ok = "(成功) " + SerializeModel.XMLSerialize<List<ColorGaridModel>>(ListData);
                else
                    Ok = "(失败) failed";
                FrmDialog.ShowDialog(this, " 保存调整的色温数据 " + Ok +"!", "提示", false);
            }
            catch (Exception e)
            {
                FrmDialog.ShowDialog(this, " 保存调整的色温数据出错！" + e, "提示", false);
                return;
            }
        }

        private void InitialGridData()
        {
            string path = Application.StartupPath + "\\ColorData\\adjust_data.xml";
            if (File.Exists(path))
            {
                SerializeModel.PathFile = path;

                List<ColorGaridModel> ListData = new List<ColorGaridModel>();
                ListData = SerializeModel.DeXMLSerialize<List<ColorGaridModel>>();
                if (ListData != null)
                {
                    for (int i = 0; i < ListData.Count; i++)
                    {
                        UpdateGaridSource(ListData[i]);
                    }
                }
            }
        }
        private void ucBtn_clear_BtnClick(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\ColorData\\adjust_data.xml";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            lstSource.Clear();
            page.DataSource = lstSource;
            this.ucDataGridView_result.Page = page;
        }

        private void ucBtn_save_Click(object sender, EventArgs e)
        {
            Init_SavePath();
            SaveGridData();
        }
        #endregion
    }
}
