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
        List<object> lstSource = new List<object>();
        private List<DataGridViewColumnEntity> lstCulumns = new List<DataGridViewColumnEntity>();
        public event ComLib.ComEvent.DataSendHandler DataSend;
        private UCPagerControl2 page = new UCPagerControl2();
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
        private float Brightness_Tolerance = 10;
        private float Temp_Tolerance = 50;
        private float Cool_TargetBrightness = 210;
        private float Standard_TargetBrightness = 210;
        private float Warm_TargetBrightness = 210;
        private float User_TargetBrightness = 210;
        // for Measure
        public float uCompare_Sx = 2800;
        public float uCompare_Sy = 2900;
        public float uCompare_Lv = 250;

        public float ucMeasure_Sx = 2800;
        public float ucMeasure_Sy = 2900;
        public float ucMeasure_Lv = 250;
        public float ucPrevMeasure_Sx = 2800;
        public float ucPrevMeasure_Sy = 2900;
        public float ucPrevMeasure_Lv = 250;

        private TimeSpan ts_total = new TimeSpan();
        private TimeSpan ts_diff = new TimeSpan();

        private DateTime startTime = new DateTime();
        private DateTime stopTime = new DateTime();
        private DateTime beginningTime = new DateTime();
        private DateTime endTime = new DateTime();

        private InitValue InitValueType = InitValue.DefaultValue;
        private bool UseMaxPanelLv75Percent = true;
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


        private int flag = (int)ColorTempNCW.Warm;
        #endregion
        
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
        public UnColorForm()
        {
            InitializeComponent();
            //Init_Timer();
        }

        private void UnColorForm_Load(object sender, EventArgs e)
        {
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "ID", HeadText = "ID", Width = 70, WidthType = SizeType.Absolute });
            lstCulumns.Add(new DataGridViewColumnEntity() { DataField = "Backlight", HeadText = "Backlight", Width = 50, WidthType = SizeType.Percent });
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
                        if (Adjust_State < 10)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                /*
                                //COOL
                                richTextBox30.Text = uColorTemp_Table[0, 0].ToString();
                                richTextBox27.Text = uColorTemp_Table[0, 1].ToString();
                                richTextBox24.Text = uColorTemp_Table[0, 2].ToString();
                                //NORMAL
                                richTextBox29.Text = uColorTemp_Table[1, 0].ToString();
                                richTextBox26.Text = uColorTemp_Table[1, 1].ToString();
                                richTextBox23.Text = uColorTemp_Table[1, 2].ToString();
                                //WARM
                                richTextBox28.Text = uColorTemp_Table[2, 0].ToString();
                                richTextBox25.Text = uColorTemp_Table[2, 1].ToString();
                                richTextBox22.Text = uColorTemp_Table[2, 2].ToString();
                                //USER
                                //richTextBox47.Text = uColorTemp_Table[3, 0].ToString();
                                //richTextBox46.Text = uColorTemp_Table[3, 1].ToString();
                                //richTextBox45.Text = uColorTemp_Table[3, 2].ToString();

                                richTextBox39.Text = uColorTemp_Table[1, 1].ToString();
                                //richTextBox57.Text = uColorTemp_Table[1, 1].ToString();
                                */
                            }));
                        }
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
                        if (Adjust_State < 10)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                /*
                                //COOL
                                richTextBox30.Text = uColorTemp_Table[0, 0].ToString();
                                richTextBox27.Text = uColorTemp_Table[0, 1].ToString();
                                richTextBox24.Text = uColorTemp_Table[0, 2].ToString();
                                //NORMAL
                                richTextBox29.Text = uColorTemp_Table[1, 0].ToString();
                                richTextBox26.Text = uColorTemp_Table[1, 1].ToString();
                                richTextBox23.Text = uColorTemp_Table[1, 2].ToString();
                                //WARM
                                richTextBox28.Text = uColorTemp_Table[2, 0].ToString();
                                richTextBox25.Text = uColorTemp_Table[2, 1].ToString();
                                richTextBox22.Text = uColorTemp_Table[2, 2].ToString();
                                //USER
                                richTextBox47.Text = uColorTemp_Table[3, 0].ToString();
                                richTextBox46.Text = uColorTemp_Table[3, 1].ToString();
                                richTextBox45.Text = uColorTemp_Table[3, 2].ToString();

                                richTextBox39.Text = uColorTemp_Table[1, 1].ToString();
                                */
                            }));
                        }
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

        private System.Windows.Forms.Timer timerClock = new System.Windows.Forms.Timer();
        public void Init_Timer()
        {
            //timerClock.Tick += new EventHandler(this.OnTimerEvent);
            timerClock.Interval = 75;
            timerClock.Start();
        }

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
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        #endregion
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
        private void SetColorTempNCW(int uMode)
        {
            uColorTempNCW = uMode;
        }

        private int GetColorTempNCW()
        {
            return uColorTempNCW;
        }
        #region  OnTimer
        public void OnTimerEvent(Object myObject, EventArgs myEventArgs)
        {
            switch (Adjust_State)
            {
                case 0:     // waiting
                    // do nothing
                    {
                        {
                            Adjust_Repeat = 0;
                            Adjust_State = 0;
                        }
                    }
                    break;

                case 1:     // start white balance adjust
                    {
                        startTime = DateTime.Now;
                        //richTextBox3.Text = "调整时间: ";
                        timerClock.Interval = 80;
                        timerClock.Start();

                        Adjust_Repeat = 0;
                        if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 1, 0, 0))
                        {
                            break;
                        }
                        Adjust_State = 2;
                    }
                    break;

                case 2:     // get RGB Gain data
                    {
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
                            if (Adjust_Repeat > 15)
                            {
                                Adjust_Repeat = 0;
                                if (send_normal_com((byte)RS232_CMD.AUTO_ADJUST_MODE_com, 1, 0, 0))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 3:     // change input source to hdmi
                    {
                        if (check_cmd_return())
                        {
                            //send_normal_com((byte)RS232_CMD.INPUT_SOURCE_com, 0, 0, 0);     // 0 for hdmi
                            //uColorTempNCW_OK[0] = 1;
                            //uColorTempNCW_OK[1] = 1;
                            //uColorTempNCW_OK[2] = 1;
                            //uColorTempNCW_OK[3] = 1;
                            //uColorTempNCW_OK[4] = 1;


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
                                    timerClock.Interval = 65;
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
                        SetColorTempNCW((int)ColorTempNCW.Normal);
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

                            Measure_CA210();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
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

                            Measure_CA210();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
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
                            Measure_CA210();
                            Thread.Sleep(200);
                            timerClock.Interval = 100;
                            timerClock.Start();
                            Panel_Lv_max = ucMeasure_Lv;
                            //richTextBox11.Text = Panel_Lv_max.ToString().Substring(0, 5);

                            if (Panel_Lv_max < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
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

                // load default table, case 25 to case 27
                case 25:
                    {
                        if (check_cmd_return())
                        {
                            Adjust_Repeat = 0;
                            //SetColorTempNCW(starColor);
                            timerClock.Interval = 80;
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
                        //timerClock.Start();
                        //ColorTempAdjStepUpdate(GetColorTempNCW());
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
                                if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17) || (uColorTempMode == 28) || (uColorTempMode == 29) || (uColorTempMode == 19)
                                 || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13) || (uColorTempMode == 21) || (uColorTempMode == 22) || (uColorTempMode == 23) || (uColorTempMode == 24) || (uColorTempMode == 25) || (uColorTempMode == 26) || (uColorTempMode == 27))
                                {
                                    if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                                    {
                                        //uCompare_Lv = (float)(float.Parse(richTextBox31.Text) / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                                    {
                                        //uCompare_Lv = (float)(float.Parse(richTextBox40.Text) / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                                    {
                                        //uCompare_Lv = (float)(float.Parse(richTextBox41.Text) / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
                                    }
                                    else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                                    {
                                        //uCompare_Lv = (float)(float.Parse(richTextBox52.Text) / 100 - 0.05 * (LvMinus_Count - 5)) * Panel_Lv_max;
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
                            Measure_CA210();
                            if (ucMeasure_Lv < 100)
                            {
                                Adjust_State = 99;     // finish auto adjust
                                MessageBox.Show("请确认色彩分析仪正常测试，信号发生器HDMI输出白场正常！");
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

                            Measure_CA210();
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
                                    else if (ABS(ucMeasure_Lv, uCompare_Lv) > 10)
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

                            Measure_CA210();
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
                                else if (ABS(ucMeasure_Sy, uCompare_Sy) > 30)
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

                            Measure_CA210();
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

                            if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17)
                             || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13))
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

                case 98:
                    {
                        Adjust_Repeat = 0;
                        if (GetColorTempNCW() == (int)ColorTempNCW.Cool)
                        {
                            uColorTempCurr[0, 0] = ucMeasure_Sx / 10000;
                            //richTextBox10.Text = uColorTempCurr[0, 0].ToString().Substring(0, 5);
                            uColorTempCurr[0, 1] = ucMeasure_Sy / 10000;
                            //richTextBox14.Text = uColorTempCurr[0, 1].ToString().Substring(0, 5);
                            uColorTempCurr[0, 2] = ucMeasure_Lv;
                            //richTextBox17.Text = uColorTempCurr[0, 2].ToString().Substring(0, 5);

                            //richTextBox30.Text = uColorTempAdj_Data[0, 0].ToString();
                            //richTextBox27.Text = uColorTempAdj_Data[0, 1].ToString();
                            //richTextBox24.Text = uColorTempAdj_Data[0, 2].ToString();

                            //richTextBox34.ReadOnly = true;
                            //richTextBox34.BackColor = SystemColors.Control;
                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17) || (uColorTempMode == 28) || (uColorTempMode == 29) || (uColorTempMode == 19)
                                 || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13) || (uColorTempMode == 21) || (uColorTempMode == 22) || (uColorTempMode == 23) || (uColorTempMode == 24) || (uColorTempMode == 25) || (uColorTempMode == 26) || (uColorTempMode == 27))
                                {
                                    //richTextBox34.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox34.ForeColor = Color.Green;
                                }
                                else
                                {
                                    //richTextBox34.Text = (100 - LvMinus_Count * 5).ToString() + "%";
                                    //richTextBox34.ForeColor = Color.Green;

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Cool, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                                //richTextBox34.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                //richTextBox34.ForeColor = Color.Green;
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.Normal)
                        {
                            uColorTempCurr[1, 0] = ucMeasure_Sx / 10000;
                            //richTextBox13.Text = uColorTempCurr[1, 0].ToString().Substring(0, 5);
                            uColorTempCurr[1, 1] = ucMeasure_Sy / 10000;
                            //richTextBox16.Text = uColorTempCurr[1, 1].ToString().Substring(0, 5);
                            uColorTempCurr[1, 2] = ucMeasure_Lv;
                            //richTextBox19.Text = uColorTempCurr[1, 2].ToString().Substring(0, 5);

                            //richTextBox29.Text = uColorTempAdj_Data[1, 0].ToString();
                            //richTextBox26.Text = uColorTempAdj_Data[1, 1].ToString();
                            //richTextBox23.Text = uColorTempAdj_Data[1, 2].ToString();

                            //richTextBox39.ReadOnly = true;
                            //richTextBox39.Text = uColorTempAdj_Data[1, 1].ToString();
                            //richTextBox39.BackColor = SystemColors.Control;
                            if (uColorTempAdj_Data[1, 1] < 128)
                            {
                                //richTextBox39.ForeColor = Color.Black;
                            }
                            else
                            {
                                //richTextBox39.ForeColor = Color.Green;
                            }

                            //richTextBox35.ReadOnly = true;
                            //richTextBox35.BackColor = SystemColors.Control;
                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17) || (uColorTempMode == 28) || (uColorTempMode == 29) || (uColorTempMode == 19)
                                 || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13) || (uColorTempMode == 21) || (uColorTempMode == 22) || (uColorTempMode == 23) || (uColorTempMode == 24) || (uColorTempMode == 25) || (uColorTempMode == 26) || (uColorTempMode == 27))
                                {
                                    //richTextBox35.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox35.ForeColor = Color.Green;
                                }
                                else
                                {
                                    //richTextBox35.Text = (100 - LvMinus_Count * 5).ToString() + "%";
                                    //richTextBox35.ForeColor = Color.Green;

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Normal, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                                //richTextBox35.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                //richTextBox35.ForeColor = Color.Green;
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.Warm)
                        {
                            uColorTempCurr[2, 0] = ucMeasure_Sx / 10000;
                            //richTextBox12.Text = uColorTempCurr[2, 0].ToString().Substring(0, 5);
                            uColorTempCurr[2, 1] = ucMeasure_Sy / 10000;
                            //richTextBox15.Text = uColorTempCurr[2, 1].ToString().Substring(0, 5);
                            uColorTempCurr[2, 2] = ucMeasure_Lv;
                            //richTextBox18.Text = uColorTempCurr[2, 2].ToString().Substring(0, 5);

                            //richTextBox28.Text = uColorTempAdj_Data[2, 0].ToString();
                            //richTextBox25.Text = uColorTempAdj_Data[2, 1].ToString();
                            //richTextBox22.Text = uColorTempAdj_Data[2, 2].ToString();

                            //richTextBox36.ReadOnly = true;
                            //richTextBox36.BackColor = SystemColors.Control;
                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17) || (uColorTempMode == 28) || (uColorTempMode == 29) || (uColorTempMode == 19)
                                 || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13) || (uColorTempMode == 21) || (uColorTempMode == 22) || (uColorTempMode == 23) || (uColorTempMode == 24) || (uColorTempMode == 25) || (uColorTempMode == 26) || (uColorTempMode == 27))
                                {
                                    //richTextBox36.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox36.ForeColor = Color.Green;
                                }
                                else
                                {
                                    //richTextBox36.Text = (100 - LvMinus_Count * 5).ToString() + "%";
                                    //richTextBox36.ForeColor = Color.Green;

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.Warm, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                                //richTextBox36.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                //richTextBox36.ForeColor = Color.Green;
                            }
                        }
                        else if (GetColorTempNCW() == (int)ColorTempNCW.User)
                        {
                            uColorTempCurr[3, 0] = ucMeasure_Sx / 10000;
                            //richTextBox56.Text = uColorTempCurr[3, 0].ToString().Substring(0, 5);
                            uColorTempCurr[3, 1] = ucMeasure_Sy / 10000;
                            //richTextBox55.Text = uColorTempCurr[3, 1].ToString().Substring(0, 5);
                            uColorTempCurr[3, 2] = ucMeasure_Lv;
                            //richTextBox54.Text = uColorTempCurr[3, 2].ToString().Substring(0, 5);

                            //richTextBox47.Text = uColorTempAdj_Data[3, 0].ToString();
                            //richTextBox46.Text = uColorTempAdj_Data[3, 1].ToString();
                            //richTextBox45.Text = uColorTempAdj_Data[3, 2].ToString();

                            //richTextBox53.ReadOnly = true;
                            //richTextBox53.BackColor = SystemColors.Control;
                            if (UseMaxPanelLv75Percent)
                            {
                                if ((uColorTempMode == 15) || (uColorTempMode == 16) || (uColorTempMode == 17) || (uColorTempMode == 28) || (uColorTempMode == 29) || (uColorTempMode == 19)
                                 || (uColorTempMode == 11) || (uColorTempMode == 12) || (uColorTempMode == 13) || (uColorTempMode == 21) || (uColorTempMode == 22) || (uColorTempMode == 23) || (uColorTempMode == 24) || (uColorTempMode == 25) || (uColorTempMode == 26) || (uColorTempMode == 27))
                                {
                                    //richTextBox53.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                    //richTextBox53.ForeColor = Color.Green;
                                }
                                else
                                {
                                    //richTextBox53.Text = (100 - LvMinus_Count * 5).ToString() + "%";
                                    //richTextBox53.ForeColor = Color.Green;

                                    if (InitValueType == InitValue.DefaultValue)
                                    {
                                        uColorTemp_StartStepSum[(int)ColorTempNCW.User, LvMinus_Count - 5]++;
                                    }
                                }
                            }
                            else
                            {
                                //richTextBox53.Text = ((int)((ucMeasure_Lv / Panel_Lv_max) * 100)).ToString() + "%";
                                //richTextBox53.ForeColor = Color.Green;
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
                                            starColor = 1;
                                        }
                                        else if (true)
                                        {
                                            SetColorTempNCW(2);
                                            starColor = 2;
                                        }
                                        else if (true)
                                        {
                                            SetColorTempNCW(3);
                                            starColor = 3;
                                        }
                                        else
                                        {
                                            flag = 0;
                                            SetColorTempNCW(1);
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(2);
                                            starColor = 2;
                                        }
                                        else if (true)
                                        {
                                            SetColorTempNCW(3);
                                            starColor = 3;
                                        }
                                        else
                                        {
                                            flag = 1;
                                            SetColorTempNCW(2);
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if (true)
                                        {
                                            SetColorTempNCW(3);
                                            starColor = 3;
                                        }
                                        else
                                        {
                                            flag = 2;
                                            SetColorTempNCW(3);
                                        }
                                    }
                                    break;

                                case 3:
                                    {
                                        flag = 3;
                                        SetColorTempNCW(4);
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
                        if ((uColorTempNCW_OK[0] == NCW_OK[0]) && (uColorTempNCW_OK[1] == NCW_OK[1]) && (uColorTempNCW_OK[2] == NCW_OK[2]) && (uColorTempNCW_OK[3] == NCW_OK[3]))
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
                        /*
                        if (SaveDataNumber < 10)
                        {
                            button4.Enabled = false;
                            button4.BackColor = Color.Green;
                            button5.Enabled = false;
                            button5.BackColor = SystemColors.Control;
                            InitValueType = InitValue.DefaultValue;

                            SaveDataNumber++;
                            richTextBox20.Text = SaveDataNumber.ToString();

                            if (!File.Exists(TEMP_DATA_FILE))
                            {
                                //Console.WriteLine("{0} does not exist.", TEMP_DATA_FILE);
                                return;
                            }
                            using (StreamWriter sw = new StreamWriter(TEMP_DATA_FILE, true))
                            {
                                sw.WriteLine(SaveDataNumber + "0," + uColorTempAdj_Data[0, 0] + "," + uColorTempAdj_Data[0, 1] + "," + uColorTempAdj_Data[0, 2]);
                                sw.WriteLine(SaveDataNumber + "1," + uColorTempAdj_Data[1, 0] + "," + uColorTempAdj_Data[1, 1] + "," + uColorTempAdj_Data[1, 2]);
                                sw.WriteLine(SaveDataNumber + "2," + uColorTempAdj_Data[2, 0] + "," + uColorTempAdj_Data[2, 1] + "," + uColorTempAdj_Data[2, 2]);
                                sw.WriteLine(SaveDataNumber + "3," + uColorTempAdj_Data[3, 0] + "," + uColorTempAdj_Data[3, 1] + "," + uColorTempAdj_Data[3, 2]);

                                sw.Close();
                            }
                            /*
                            if (SaveDataNumber >= 10)
                            {
                                button4.Enabled = true;
                                button4.BackColor = SystemColors.Control;
                                button5.Enabled = false;
                                button5.BackColor = Color.Green;
                                InitValueType = InitValue.AverageVaule;

                                if (!File.Exists(TEMP_DATA_FILE))
                                {
                                    //Console.WriteLine("{0} does not exist.", TEMP_DATA_FILE);
                                    return;
                                }
                                using (StreamReader sr = File.OpenText(TEMP_DATA_FILE))
                                {
                                    string input;
                                    string[] s;
                                    int[] total_R = new int[4] { 0, 0, 0, 0};
                                    int[] total_G = new int[4] { 0, 0, 0, 0};
                                    int[] total_B = new int[4] { 0, 0, 0, 0};
                                    while ((input = sr.ReadLine()) != null)
                                    {
                                        s = input.Split(new char[] { ',' });
                                        if (int.Parse(s[0]) >= 10)
                                        {
                                            total_R[int.Parse(s[0]) % 10] += int.Parse(s[1]);
                                            total_G[int.Parse(s[0]) % 10] += int.Parse(s[2]);
                                            total_B[int.Parse(s[0]) % 10] += int.Parse(s[3]);
                                            SaveDataNumber = int.Parse(s[0]) / 10;
                                        }
                                    }

                                    try
                                    {
                                        uColorTemp_Table[0, 0] = (byte)(total_R[0] / SaveDataNumber);
                                        uColorTemp_Table[0, 1] = (byte)(total_G[0] / SaveDataNumber);
                                        uColorTemp_Table[0, 2] = (byte)(total_B[0] / SaveDataNumber);

                                        uColorTemp_Table[1, 0] = (byte)(total_R[1] / SaveDataNumber);
                                        uColorTemp_Table[1, 1] = (byte)(total_G[1] / SaveDataNumber);
                                        uColorTemp_Table[1, 2] = (byte)(total_B[1] / SaveDataNumber);

                                        uColorTemp_Table[2, 0] = (byte)(total_R[2] / SaveDataNumber);
                                        uColorTemp_Table[2, 1] = (byte)(total_G[2] / SaveDataNumber);
                                        uColorTemp_Table[2, 2] = (byte)(total_B[2] / SaveDataNumber);

                                        uColorTemp_Table[3, 0] = (byte)(total_R[3] / SaveDataNumber);
                                        uColorTemp_Table[3, 1] = (byte)(total_G[3] / SaveDataNumber);
                                        uColorTemp_Table[3, 2] = (byte)(total_B[3] / SaveDataNumber);
                                    }
                                    catch
                                    {
                                        MessageBox.Show(" 尚未保存数据! ");
                                    }

                                    //COOL
                                    richTextBox30.Text = uColorTemp_Table[0, 0].ToString();
                                    richTextBox27.Text = uColorTemp_Table[0, 1].ToString();
                                    richTextBox24.Text = uColorTemp_Table[0, 2].ToString();
                                    //NORMAL
                                    richTextBox29.Text = uColorTemp_Table[1, 0].ToString();
                                    richTextBox26.Text = uColorTemp_Table[1, 1].ToString();
                                    richTextBox23.Text = uColorTemp_Table[1, 2].ToString();
                                    //WARM
                                    richTextBox28.Text = uColorTemp_Table[2, 0].ToString();
                                    richTextBox25.Text = uColorTemp_Table[2, 1].ToString();
                                    richTextBox22.Text = uColorTemp_Table[2, 2].ToString();
                                    //USER
                                    richTextBox47.Text = uColorTemp_Table[3, 0].ToString();
                                    richTextBox46.Text = uColorTemp_Table[3, 1].ToString();
                                    richTextBox45.Text = uColorTemp_Table[3, 2].ToString();

                                    sr.Close();
                                }
                            }
                            
                            if (UseMaxPanelLv75Percent)
                            {
                                if (!File.Exists(START_DATA_FILE))
                                {
                                    //Console.WriteLine("{0} does not exist.", START_DATA_FILE);
                                    return;
                                }
                                using (StreamWriter sw = new StreamWriter(START_DATA_FILE, false))
                                {
                                    sw.WriteLine((int)ColorTempNCW.Cool + "," + uColorTemp_StartStepSum[0, 0] + "," + uColorTemp_StartStepSum[0, 1] + "," + uColorTemp_StartStepSum[0, 2] + "," + uColorTemp_StartStepSum[0, 3]);
                                    sw.WriteLine((int)ColorTempNCW.Normal + "," + uColorTemp_StartStepSum[1, 0] + "," + uColorTemp_StartStepSum[1, 1] + "," + uColorTemp_StartStepSum[1, 2] + "," + uColorTemp_StartStepSum[1, 3]);
                                    sw.WriteLine((int)ColorTempNCW.Warm + "," + uColorTemp_StartStepSum[2, 0] + "," + uColorTemp_StartStepSum[2, 1] + "," + uColorTemp_StartStepSum[2, 2] + "," + uColorTemp_StartStepSum[2, 3]);
                                    sw.WriteLine((int)ColorTempNCW.User + "," + uColorTemp_StartStepSum[3, 0] + "," + uColorTemp_StartStepSum[3, 1] + "," + uColorTemp_StartStepSum[3, 2] + "," + uColorTemp_StartStepSum[3, 3]);
                                    sw.WriteLine(4 + "," + Adjust_MaxValue_Backup);
                                    sw.Close();
                                }

                                for (int i = 0; i <= 3; i++)
                                {
                                    uColorTemp_StartStepIndex[i] = 0;
                                    for (int j = 1; j < 4; j++)
                                    {
                                        if (uColorTemp_StartStepSum[i, j] > uColorTemp_StartStepSum[i, uColorTemp_StartStepIndex[i]])
                                        {
                                            uColorTemp_StartStepIndex[i] = j;
                                        }
                                    }
                                }
                            }
                        }
                        */
                        timerClock.Interval = 100;
                        Adjust_Result = 3;    // pass
                        Adjust_State = 118;
                    }
                    break;

                case 118:
                    {
                        Adjust_Repeat = 0;
                        if (uColorTempMode == 29)
                            SetColorTempNCW((int)ColorTempNCW.Warm);
                        else
                            SetColorTempNCW((int)ColorTempNCW.Normal);
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
                            Measure_CA210();
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

                case 121:
                    {
                        if (check_cmd_return())
                        {
                            if (Adjust_Result == 3)
                            {
                                //richTextBox21.ForeColor = Color.Green;
                                //richTextBox21.Text = "成功";
                            }
                            else if (Adjust_Result == 2)
                            {
                                //richTextBox21.ForeColor = Color.Yellow;
                                //richTextBox21.Text = "失败";
                            }
                            else
                            {
                                //richTextBox21.ForeColor = Color.Red;
                                //richTextBox21.Text = "失败";
                            }

                            Adjust_State = 0;
                            Adjust_Repeat = 0;
                            Adjust_Result = 0;
                            stopTime = DateTime.Now;
                            ts_total = stopTime - startTime;
                            //button2.Text = "开始";
                            //richTextBox3.Text = "调整时间: " + ((int)ts_total.TotalSeconds).ToString() + "秒";
                            //uColorTempControlEnable(true);
                            //if (!Adjust_DateOk)
                            //MessageBox.Show("调整后的数据对比有误，请重新进行调整！","提示");
                        }
                        else
                        {
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

                default:
                    Adjust_State = 0;
                    Adjust_Repeat = 0;
                    Adjust_Result = 0;
                    //button2.Text = "开始";
                    break;
            }
        }
        #endregion

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
            byte[] P;
            //if (true)
            {
                P = new byte[8];
                P[0] = 0xAB;
                P[1] = 0x8;
                P[2] = 0xFD;
                P[3] = com;
                P[4] = value1;
                P[5] = value2;
                P[6] = value3;
                P[7] = (byte)(0xFF - (byte)(0xFF & (P[0] + P[1] + P[2] + P[3] + P[4] + P[5] + P[6])));
            }
            try
            {
                DataSend(P);
            }
            catch
            {
                //serialPort1.Close();
                Adjust_State = 0;
                MessageBox.Show("串口连接中断,请检查USB连线！\n并且，请关闭本软件，重新打开！");
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

        private void ucBtn_Execute_BtnClick(object sender, EventArgs e)
        {
        }

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
    }
}
