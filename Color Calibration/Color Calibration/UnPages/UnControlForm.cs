using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using unvell.ReoGrid.Events;
using System.Threading;
using System.IO;
using Color_Calibration.ComLib;
using unvell.ReoGrid;
using Guifreaks.NavigationBar;
using HZH_Controls.Forms;
using WallControl;
using Color_Calibration.Control;

namespace Color_Calibration.UnPages
{
    public partial class UnControlForm : UserControl
    {
        //private int oldLeftTopCol = 0;//鼠标选择的老的左上角的列
        //private int oldLeftTopRow = 0;//鼠标选择的老的左上角的行
        //private int oldRightBottomCol = 0;//鼠标选择的老的右下角的列
        //private int oldRightBottomRow = 0;//鼠标选择的老的右下上的行
        private static String currentSceneName = "scene.rgf";//当前场景名
        private static String currentConnectionName = "ColorData";//当前连接名
        private static String defaultSignalName = "HDMI1";//默认的信源
        public event ComLib.ComEvent.DataSendHandler DataSend;
        private unvell.ReoGrid.Worksheet sheet_back;
        public static int rowsCount = 2;//行
        public static int colsCount = 2;//列
        private static int rowStar = 0;
        private static int rowEnd = 0;
        private static int colStar = 0;
        private static int colEnd = 0;
        private Color_Calibration.ComLib.Screen[] screens;
        public Thread myThread = null;
        private AdjustColorPage _adjustCP;
        public UnControlForm()
        {
            InitializeComponent();
            initRoGridSet();
            initRoGridFromFile("");
        }
        #region 初始化界面显示
        /// <summary>
        /// 初始化grid设置
        /// </summary>
        public void initRoGridSet()
        {
            sheet_back = reoGridControl2.CurrentWorksheet;
            sheet_back.Reset();
            Thread.Sleep(100);
            reoGridControl2.Readonly = true;

            sheet_back.SelectionRangeChanging += sheet_backSelectionRangeChanging;
            sheet_back.SelectionRangeChanged += sheet_backSelectionRangeChanged;
            // reoGridControl1.CurrentWorksheet.RowHeaderWidth = 0;
            reoGridControl2.SetSettings(unvell.ReoGrid.WorkbookSettings.View_ShowScrolls, false);//关闭滚动条
            reoGridControl2.CurrentWorksheet.SetSettings(unvell.ReoGrid.WorksheetSettings.View_ShowHeaders, false);//关闭行头和列头
            
            reoGridControl2.CurrentWorksheet.AutoFitColumnWidth(0, true);
            reoGridControl2.CurrentWorksheet.AutoFitRowHeight(0, true);
        }

        /// <summary>
        /// 默认从文件中初始化grid,初始化串口，地址
        /// </summary>
        /// <param name="directName">文件夹路径</param>
        public void initRoGridFromFile(String directName)
        {
            //settingFile = new IniFiles(Application.StartupPath + "\\setting.ini");
            currentConnectionName = Application.StartupPath + "\\ColorData";
            
            currentSceneName = "scene.rgf";
            
            FileInfo file = new FileInfo(currentConnectionName + "\\" + currentSceneName);
            if ((!file.Exists))
            {
                initRoGridControl(MainColorModel.H_Row, MainColorModel.V_Colu);//默认2行2列
                //saveSceneFile(currentConnectionName + "\\" + currentSceneName);
            }
            else
            {
                //readSceneFile(currentConnectionName + "\\" + currentSceneName);
                //reoGridControl1.Readonly = true;
                reoGridControl2.Readonly = true;
                //initAddress(sheet.RowCount * sheet.ColumnCount);   
                initReoGridConrol2();
            }
        }
        private void initReoGridConrol2()
        {
            reoGridControl2.CurrentWorksheet.SetRows(rowsCount);//行数
            reoGridControl2.CurrentWorksheet.SetCols(colsCount);//列数
            reoGridControl2.CurrentWorksheet.Resize(rowsCount, colsCount);
            sheet_back.SetRowsHeight(0, sheet_back.RowCount, (ushort)((reoGridControl2.Size.Height) / rowsCount));//改行的高度，从0行开始，改ColumnCount行
            sheet_back.SetColumnsWidth(0, sheet_back.ColumnCount, (ushort)((reoGridControl2.Size.Width) / colsCount));//改列的宽度，从0列开始，改ColumnCount列
            for (int i = 0; i < colsCount; i++)//初始值
            {
                for (int j = 0; j < rowsCount; j++)
                {
                    //Console.WriteLine(j * colCount + i + "===块");
                    //screens[j * colsCount + i] = new Screen();
                    //screens[j * colsCount + i].IntputType = defaultSignalName;
                    //screens[j * colsCount + i].Name = "U" + (j * colsCount + i + 1);
                    //screens[j * colsCount + i].Number = (j * colsCount + i + 1);
                    //sheet.SetCellData(j, i, screens[j * colsCount + i]);
                    sheet_back.SetCellData(j, i, screens[j * colsCount + i]);
                }
            }
            if (rowsCount * colsCount > 40 || rowsCount > 6 || colsCount > 6)//9*9以上
            {
                sheet_back.SetRangeStyles(new RangePosition(0, 0, rowsCount, colsCount), new WorksheetRangeStyle//0,0开始，rowCount行colCount列，左上角
                {
                    Flag = PlainStyleFlag.All,
                    HAlign = ReoGridHorAlign.Left,
                    VAlign = ReoGridVerAlign.Top,
                    TextColor = Color.FromArgb(74, 22, 124),
                    FontSize = 8,

                });
            }
            else
            {//9*9以下
                sheet_back.SetRangeStyles(new RangePosition(0, 0, rowsCount, colsCount), new WorksheetRangeStyle//0,0开始，rowCount行colCount列，左上角
                {
                    Flag = PlainStyleFlag.All,
                    HAlign = ReoGridHorAlign.Left,
                    VAlign = ReoGridVerAlign.Top,
                    TextColor = Color.FromArgb(74, 22, 124),
                    FontSize = 10,
                    //BackColor = Color.Silver,
                    //FillPatternColor = Color.Green,
                });
            }
        }

        /// <summary>
        /// 初始化grid行列
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public void initRoGridControl(int rowCount, int colCount)
        {
            // Console.WriteLine("rowCount=" + rowCount);
            //reoGridControl1.Reset();
            reoGridControl2.CurrentWorksheet.SetRows(rowCount);//行数
            reoGridControl2.CurrentWorksheet.SetCols(colCount);//列数
            //Console.WriteLine("============");
            reoGridControl2.CurrentWorksheet.Resize(rowCount, colCount);
            rowsCount = rowCount;
            colsCount = colCount;
            
            sheet_back.SetRowsHeight(0, sheet_back.RowCount, (ushort)((reoGridControl2.Size.Height - 40) / rowCount));//改行的高度，从0行开始，改ColumnCount行
            sheet_back.SetColumnsWidth(0, sheet_back.ColumnCount, (ushort)((reoGridControl2.Size.Width) / colCount));//改列的宽度，从0列开始，改ColumnCount列
            //reoGridControl1.CurrentWorksheet.Resize(rowCount, colCount);
            screens = new Color_Calibration.ComLib.Screen[rowsCount * colsCount];
            //Console.WriteLine(screens.Length + "===length");
            for (int i = 0; i < colCount; i++)//初始值
            {
                for (int j = 0; j < rowCount; j++)
                {
                    //Console.WriteLine(j * colCount + i + "===块");
                    screens[j * colCount + i] = new Color_Calibration.ComLib.Screen();
                    screens[j * colCount + i].IntputType = defaultSignalName;
                    screens[j * colCount + i].Name = "U" + (j * colCount + i + 1);
                    //if ((j * colCount + i + 1) < 10)
                    //screens[j * colCount + i].Name = "U" + (j * colCount + i + 1).ToString() + " ";
                    screens[j * colCount + i].Number = (j * colCount + i + 1);
                    sheet_back.SetCellData(j, i, screens[j * colCount + i]);
                }
            }
            if (rowsCount * colsCount > 40 || rowsCount > 6 || colsCount > 6)//9*9以上
            {
                sheet_back.SetRangeStyles(new RangePosition(0, 0, rowCount, colCount), new WorksheetRangeStyle//0,0开始，rowCount行colCount列，左上角
                {
                    Flag = PlainStyleFlag.All,
                    HAlign = ReoGridHorAlign.Left,
                    VAlign = ReoGridVerAlign.Top,
                    TextColor = Color.FromArgb(74, 22, 124),
                    FontSize = 8,

                });
            }
            else
            {//9*9以下
                sheet_back.SetRangeStyles(new RangePosition(0, 0, rowCount, colCount), new WorksheetRangeStyle//0,0开始，rowCount行colCount列，左上角
                {
                    Flag = PlainStyleFlag.All,
                    HAlign = ReoGridHorAlign.Left,
                    VAlign = ReoGridVerAlign.Top,
                    TextColor = Color.FromArgb(74, 22, 124),
                    FontSize = 10,
                });
            }

        }
        private void sheet_backSelectionRangeChanging(object sender, RangeEventArgs args)
        {
            for (int i = 0; i < 256; i++)
                GlobalClass.select_address[i] = 0;
            for (int j = sheet_back.SelectionRange.Row; j <= sheet_back.SelectionRange.EndRow; j++)
            {
                for (int i = sheet_back.SelectionRange.Col; i <= sheet_back.SelectionRange.EndCol; i++)
                {
                    int num = screens[((i + 1) + j * colsCount) - 1].Number;
                    GlobalClass.select_address[num] = (byte)num;
                    //Console.WriteLine("select_address[num] = " + select_address[num]);
                }
            }
            rowStar = sheet_back.SelectionRange.Row;
            rowEnd = sheet_back.SelectionRange.EndRow;
            colStar = sheet_back.SelectionRange.Col;
            colEnd = sheet_back.SelectionRange.EndCol;
        }

        private void sheet_backSelectionRangeChanged(object sender, RangeEventArgs args)
        {
            //Console.WriteLine("选择完成");
            rowStar = sheet_back.SelectionRange.Row;
            rowEnd = sheet_back.SelectionRange.EndRow;
            colStar = sheet_back.SelectionRange.Col;
            colEnd = sheet_back.SelectionRange.EndCol;
        }
        #endregion
        public void Data_Update()
        {
            initRoGridControl(MainColorModel.H_Row, MainColorModel.V_Colu);//默认2行2列
            naviBar1.Refresh();
        }
        private void UnControlFrom_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("Load...");
            naviBar1.Bands.Clear();
            naviBar1.Bands.Add(naviBand1);
            naviBar1.Bands.Add(naviBand2);
            naviBar1.Bands.Add(naviBand4);
            naviBar1.Bands.Add(naviBand3);
            naviBar1.Bands.Add(naviBand5);

            naviBar1.ActiveBand = naviBand1;
            naviBar1.VisibleLargeButtons = 3;
            naviBar1.Refresh();
            com_signal.SelectedIndex = 0;
            comb_scene.SelectedIndex = 0;
        }
        public void DataReceived(byte[] data)
        {
            try
            {
                if (data.Length > 0)
                {
                    string str = Encoding.Default.GetString(data);
                    if (str.Contains("COLOR_BALANCE") || str.Contains("COLOR_DATA"))
                    {
                        if (_adjustCP != null)
                            _adjustCP.DataReceived(str);
                    }
                    //Console.Write("adjustcolorpage:" + str);
                }
                //Console.Write(str);
            }
            catch
            {

            }
        }

        #region 切换信源执行
        private void button_run_Click(object sender, EventArgs e)
        {
            int k = com_signal.SelectedIndex;
            if (k < 5)
            {
                //startProgress(0);//开启进度条显示
                if (k == 2)
                    k = 3;
                else if (k == 3)
                    k = 4;
                else if (k == 4)
                    k = 6;
                if(GlobalClass.c_bIsOpen)
                {
                    //myThread = new Thread(new ThreadStart(delegate ()
                    //{
                    //})); //开线程          
                    //myThread.Start(); //启动线程 
                    do_select_Clik(rowStar, rowEnd, colStar, colEnd, k);
                    select_Clik(k, com_signal.Text);
                }
                //LogHelper.WriteLog("======切换信源【" + comboBox4.Text + "】======");
            }
        }
        
        /// <summary>
        /// 切换本地信源指令
        /// </summary>
        /// <param name="A_0">地址</param>
        /// <param name="A_1">通道</param>
        private void Send_Signa(byte A_0, byte A_1)//本地通道的信源切换指令
        {
            byte[] array = new byte[6];
            array[0] = 0xE6;
            array[1] = A_0;
            array[2] = 0x20;
            array[3] = 0x50;
            array[4] = A_1;
            array[5] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3] + array[4]));
            try
            {
                if (GlobalClass.c_bIsOpen)
                {
                    DataSend(array);
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
            catch
            {
                FrmDialog.ShowDialog(this, "     Error sending data from serial port！", "Tips", false);
                return;
            }
        }

        /// <summary>
        /// 执行指令发送
        /// </summary>
        /// <param name="rowS"></param>
        /// <param name="rowE"></param>
        /// <param name="colS"></param>
        /// <param name="colE"></param>
        /// <param name="m"></param>
        private void do_select_Clik(int rowS, int rowE, int colS, int colE, int m)
        {
            for (int j = rowS; j <= rowE; j++)
            {
                for (int i = colS; i <= colE; i++)
                {
                    int num = screens[((i + 1) + j * colsCount) - 1].Number;
                    Send_Signa((byte)num, (byte)m);
                }
            }
        }

        /// <summary>
        /// 执行切换界面信源
        /// </summary>
        /// <param name="n"></param>
        /// <param name="str"></param>
        private void select_Clik(int n, string str)
        {
            string x = "";
            {
                for (int j = rowStar; j <= rowEnd; j++)
                {
                    for (int i = colStar; i <= colEnd; i++)
                    {
                        int num = screens[((i + 1) + j * colsCount) - 1].Number;
                        //if (n == 3 || n == 6)
                        {
                            sheet_back.SetCellData(j, i, screens[j * sheet_back.ColumnCount + i].Name + " " + str);
                            screens[j * sheet_back.ColumnCount + i].IntputType = str;//改screens里对应屏幕的信源
                        }
                        x += num.ToString() + " , ";
                        //if (!sheet.IsMergedCell(sheet.SelectionRange.Row, sheet.SelectionRange.Col))
                        //Send_Signa((byte)num, (byte)m);
                    }
                }
                LogHelper.WriteLog("=====切换屏幕【" + x + "】的" + str + "信源=====");
            }
        }

        private void SourceToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            int index = 0;
            if (item.Text == "HDMI2")
                index = 1;
            else if (item.Text == "OPS")
                index = 2;
            else if (item.Text == "DVI")
                index = 3;
            else if (item.Text == "DP")
                index = 4;
            else if (item.Text == "VGA")
                index = 6;
            else
                index = 0;
            myThread = new Thread(new ThreadStart(delegate ()
            {
                do_select_Clik(rowStar, rowEnd, colStar, colEnd, index);
            })); //开线程          
            myThread.Start(); //启动线程 
            //Console.WriteLine(index);
            select_Clik(index, item.Text);
        }
        #endregion

        #region 拼接合并、分解操作

        /// <summary>
        /// 分解、合成指令
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="a3"></param>
        /// <param name="a4"></param>
        private void Send_merge(byte a1, byte a2, byte a3, byte a4)
        {
            byte[] array = new byte[10];
            array[0] = 0xEA;
            array[1] = 0xFD;
            array[2] = 0x20;
            array[3] = 0x01;
            array[4] = a1;
            array[5] = (byte)(a2 | 0x80);
            array[6] = (byte)(a3 | 0x80);
            array[7] = a4;
            array[8] = 0x10;
            array[9] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3] + array[4] + array[5] + array[6] + array[7] + array[8]));

            //startProgress(new SendDataMap(serialPort1, array, 0, 10, 2));//serialport1发送数据15次
            try
            {
                if (GlobalClass.c_bIsOpen)
                {
                    DataSend(array);
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
            catch
            {
                //Rs232Con = false;
            }
        }

        /// <summary>
        /// 合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mergeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //点击的是鼠标左键
            {
                if (!GlobalClass.c_bIsOpen)
                {
                    //sheet.SelectionStyle = WorksheetSelectionStyle.FocusRect;
                    return;
                }
                int mergeStartCol = sheet_back.SelectionRange.Col;
                int mergeStartRow = sheet_back.SelectionRange.Row;
                int mergeEndCol = sheet_back.SelectionRange.EndCol;
                int mergeEndRow = sheet_back.SelectionRange.EndRow;
                try
                {
                    //group++;
                    int A_0 = rowStar;
                    int A_1 = colStar + 1;
                    byte A = (byte)(A_1 + A_0 * colsCount);
                    int B_0 = rowEnd;
                    int B_1 = colEnd + 1;
                    byte B = (byte)(B_1 + B_0 * colsCount);
                    int num = (rowEnd - rowStar + 1) * (colEnd - colStar + 1);
                    string str = screens[A - 1].IntputType;
                    //Console.WriteLine(num + "num--------");
                    if (str.Contains("("))
                        str = str.Split('(')[0];
                    byte souce = 0x00;
                    if (true)//3458
                    {
                        if (str.Contains("HDMI"))
                        {
                            //if (checkBox2.Checked)
                            //UartSendSwitchMainSignalCmd(str, 0, num, "HDMI");
                            if (str.Contains("HDMI1"))
                            {
                                souce = 0x00;
                            }
                            else if (str.Contains("HDMI2"))
                            {
                                souce = 0x01;
                            }
                        }
                        else if (str.Contains("OPS"))
                        {
                            //UartSendSwitchMainSignalCmd(str, 0, num, "DVI");
                            souce = 0x02;
                        }
                        else if (str.Contains("DVI"))
                        {
                            //if (checkBox2.Checked)
                            //UartSendSwitchMainSignalCmd(str, 0, num, "DVI");
                            souce = 0x03;
                        }
                        else if (str.Contains("DP"))
                        {
                            //UartSendSwitchMainSignalCmd(str, 0, num, "VIDEO");
                            souce = 0x04;
                        }
                        else if (str.Contains("VGA"))
                        {
                            //UartSendSwitchMainSignalCmd(str, 0, num, "VIDEO");
                            souce = 0x06;
                        }
                    }
                    byte C = 0;
                    C = (byte)(0x08 | ((1 << 4) & 0xF0) | (0x08) | souce);
                    myThread = new Thread(new ThreadStart(delegate ()
                    {
                        Send_merge((byte)1, A, B, C);
                    })); //开线程         
                    myThread.Start(); //启动线程 

                    string x = "";
                    for (int i = rowStar; i <= rowEnd; i++)
                    {
                        for (int j = colStar; j <= colEnd; j++)
                        {
                            x += ((j + 1) + i * colsCount).ToString() + " , ";//(j * colsCount + i).ToString();
                        }
                    }
                    //Console.WriteLine(x);
                    LogHelper.WriteLog("=====拼接合并画面操作,屏幕【" + x + "】合并显示=====");
                }
                catch (unvell.ReoGrid.RangeIntersectionException exception)
                {
                    //MessageBox.Show("不允许这样合成!" + exception.Message, "温馨提示");
                }
            }
        }
        
        /// <summary>
        /// 分解
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unMergeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //点击的是鼠标左键
            {
                if (!GlobalClass.c_bIsOpen)
                {
                    return;
                }
                int A_0 = rowStar;
                int A_1 = colStar + 1;
                byte A = (byte)(A_1 + A_0 * colsCount);
                int B_0 = rowEnd;
                int B_1 = colEnd + 1;
                byte B = (byte)(B_1 + B_0 * colsCount);
                string str = screens[A - 1].IntputType;
                if (str.Contains("("))
                    str = str.Split('(')[0];
                //Console.WriteLine(str);
                byte souce = 0x00;
                if (true)
                {
                    if (str.Contains("HDMI"))
                    {
                        if (str.Contains("HDMI1"))
                        {
                            souce = 0x00;
                        }
                        else if (str.Contains("HDMI2"))
                        {
                            souce = 0x01;
                        }
                    }
                    else if (str.Contains("OPS"))
                    {
                        //UartSendSwitchMainSignalCmd(str, 0, num, "DVI");
                        souce = 0x02;
                    }
                    else if (str.Contains("DVI"))
                    {
                        //if (checkBox2.Checked)
                        //UartSendSwitchMainSignalCmd(str, 0, num, "DVI");
                        souce = 0x03;
                    }
                    else if (str.Contains("DP"))
                    {
                        //UartSendSwitchMainSignalCmd(str, 0, num, "VIDEO");
                        souce = 0x04;
                    }
                    else if (str.Contains("VGA"))
                    {
                        //UartSendSwitchMainSignalCmd(str, 0, num, "VGA");
                        souce = 0x06;
                    }
                }
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    Send_merge((byte)1, A, B, souce);
                })); //开线程         
                myThread.Start(); //启动线程 

                string x = "";
                for (int i = rowStar; i <= rowEnd; i++)
                {
                    for (int j = colStar; j <= colEnd; j++)
                    {
                        x += ((j + 1) + i * colsCount).ToString() + " , ";//(j * colsCount + i).ToString();
                    }
                }
                LogHelper.WriteLog("=====拼接分解画面操作,屏幕【" + x + "】分开显示=====");
            }
        }
        #endregion

        #region 开关机操作
        private void Power_off(byte A1)//单个屏幕的关机指令
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = A1;
            array[2] = 0x20;
            array[3] = 0xAE;
            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
            try
            {
                if (GlobalClass.c_bIsOpen)
                {
                    DataSend(array);
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
            catch
            {
                //MessageBox.Show(ts, tp);
            }
        }

        private void Power_on(byte A1)//单个屏幕的开机指令
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[1] = A1;
            array[2] = 0x20;
            array[3] = 0xAD;
            array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));
            try
            {
                if (GlobalClass.c_bIsOpen)
                {
                    DataSend(array);
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
            catch
            {
                //MessageBox.Show(ts, tp);
            }
        }

        /// <summary>
        /// 开机线程
        /// </summary>
        /// <param name="rowS"></param>
        /// <param name="rowE"></param>
        /// <param name="colS"></param>
        /// <param name="colE"></param>
        /// <param name="on_off"></param>
        private void power_onThread(int rowS, int rowE, int colS, int colE, bool on_off)
        {
            int num = 0;
            string x = "";
            {
                for (int i = rowS; i <= rowE; i++)
                {
                    for (int j = colS; j <= colE; j++)
                    {
                        num = screens[((j + 1) + i * colsCount) - 1].Number;//对应的单元地址
                        Power_on((byte)num);
                        x = num.ToString() + " , ";
                        Thread.Sleep(200);
                        //Console.WriteLine("select_address[num] = " + num);
                    }
                }
            }
            LogHelper.WriteLog("=====开机操作，屏幕【" + x + "】开机=====");
        }

        /// <summary>
        /// 关机线程
        /// </summary>
        /// <param name="rowS"></param>
        /// <param name="rowE"></param>
        /// <param name="colS"></param>
        /// <param name="colE"></param>
        /// <param name="on_off"></param>
        private void power_offThread(int rowS, int rowE, int colS, int colE, bool on_off)
        {
            int num = 0;
            string x = "";
            {
                for (int i = rowE; i >= rowS; i--)
                {
                    for (int j = colE; j >= colS; j--)
                    {
                        num = screens[((j + 1) + i * colsCount) - 1].Number;//对应的单元地址
                        //Console.WriteLine(rowE);
                        Power_off((byte)num);
                        x = num.ToString() + " , ";
                        Thread.Sleep(100);
                    }
                }
            }
            LogHelper.WriteLog("=====关机操作，屏幕【" + x + "】关机=====");
        }
        private void button_on_Click(object sender, EventArgs e)
        {
            if (GlobalClass.c_bIsOpen)
            {
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    power_onThread(rowStar, rowEnd, colStar, colEnd, false);
                })); //开线程         
                myThread.Start(); //启动线程 
                //Console.WriteLine("===" + myThread.Name);
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                return;
            }
        }
        
        private void button_off_Click(object sender, EventArgs e)
        {
            if (GlobalClass.c_bIsOpen)
            {
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    power_offThread(rowStar, rowEnd, colStar, colEnd, false);
                })); //开线程         
                myThread.Start(); //启动线程 
                                  //Console.WriteLine("===" + myThread.Name);
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                return;
            }
        }

        #endregion

        #region 系统设置操作

        /// <summary>
        /// 参数调整指令线程
        /// </summary>
        /// <param name="rowS"></param>
        /// <param name="rowE"></param>
        /// <param name="colS"></param>
        /// <param name="colE"></param>
        /// <param name="A1"></param>
        private void Control_FuncThread(int rowS, int rowE, int colS, int colE, byte A1)
        {
            byte[] array = new byte[5];
            array[0] = 0xE5;
            array[2] = 0x20;
            array[3] = A1;
            for (int j = rowS; j <= rowE; j++)
            {
                for (int i = colS; i <= colE; i++)
                {
                    array[1] = (byte)screens[(i + j * colsCount)].Number;
                    array[4] = (byte)(255 - (255 & array[0] + array[1] + array[2] + array[3]));
                    if (A1 == 0xD0 || A1 == 0xEF)
                    {
                        //screen_V[screens[(i + j * colsCount)].Number - 1] = 0;//复位拼缝的数值
                        //screen_H[screens[(i + j * colsCount)].Number - 1] = 0;//复位拼缝的数值
                    }
                    //Console.WriteLine("array[1] = " + array[1]);
                    try
                    {
                        if (GlobalClass.c_bIsOpen)
                        {
                            DataSend(array);
                        }
                        else
                        {
                            FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                            return;
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 参数调整函数
        /// </summary>
        /// <param name="A1"></param>
        private void Send_Func(byte A1)
        {
            myThread = new Thread(new ThreadStart(delegate ()
            {
                Control_FuncThread(rowStar, rowEnd, colStar, colEnd, A1);
            })); //开线程         
            myThread.Start(); //启动线程 
        }
        private void ucSwitch_ageing_CheckedChanged(object sender, EventArgs e)
        {
            if (ucSwitch_ageing.Checked == true)
            {
                Send_Func(0xE1);
                LogHelper.WriteLog("=====打开老化设置=====");
            }
            else
            {
                Send_Func(0xE2);
                LogHelper.WriteLog("=====关闭老化设置=====");
            }
        }

        private void ucSwitch_blue_CheckedChanged(object sender, EventArgs e)
        {
            if (ucSwitch_blue.Checked == true)
            {
                Send_Func(0xEA);
                LogHelper.WriteLog("=====打开蓝屏设置=====");
            }
            else
            {
                Send_Func(0xEB);
                LogHelper.WriteLog("=====关闭蓝屏设置=====");
            }
        }

        private void ucSwitch_white_CheckedChanged(object sender, EventArgs e)
        {
            if (ucSwitch_white.Checked == true)
            {
                Send_Func(0xD1);
                LogHelper.WriteLog("=====打开白场设置=====");
            }
            else
            {
                Send_Func(0xD2);
                LogHelper.WriteLog("=====关闭白场设置=====");
            }
        }
        /// <summary>
        /// 用户复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            //DialogResult t = MessageBox.Show(" Make sure to Reset the selected screen unit !", " Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            DialogResult t = FrmDialog.ShowDialog(this, "Make sure to Reset the selected screen unit !", " Tips", true);
            if (t == DialogResult.Yes || t == DialogResult.OK)
            {
                Send_Func(0xEF);
                ucSwitch_ageing.Checked = false;
                ucSwitch_blue.Checked = false;
                ucSwitch_white.Checked = false;
                //Rest_form(false, true);
                LogHelper.WriteLog("=====进行用户复位操作=====");
            }
        }
        /// <summary>
        /// 工厂复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult t = MessageBox.Show(" Make sure to factory reset the selected screen unit !", " Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            DialogResult t = FrmDialog.ShowDialog(this, "Make sure to factory reset the selected screen unit !", " Tips", true);
            if (t == DialogResult.Yes || t == DialogResult.OK)
            {
                Send_Func(0xD0);
                ucSwitch_ageing.Checked = false;
                ucSwitch_blue.Checked = false;
                ucSwitch_white.Checked = false;
                //Rest_form(false, true);
                LogHelper.WriteLog("=====进行工厂复位操作=====");
            }
        }
        /// <summary>
        /// 升级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //DialogResult t = MessageBox.Show(" Make sure to perform a USB upgrade on the selected screen unit!", " Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            DialogResult t = FrmDialog.ShowDialog(this, " Make sure to perform a USB upgrade on the selected screen unit!", " Tips",true);
            if (t == DialogResult.Yes || t == DialogResult.OK)
            {
                //MessageBox.Show(" Make sure to perform a USB upgrade on the selected screen unit!", " Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                Send_Func(0xE5);
                ucSwitch_ageing.Checked = false;
                ucSwitch_blue.Checked = false;
                ucSwitch_white.Checked = false;
                //Rest_form(false, true);
                LogHelper.WriteLog("=====进行系统升级操作=====");
            }
        }

        #endregion

        #region 预案、遥控操作
        private void Send_to_Scene(byte A_0, byte A_1)//  屏幕的预案管理指令
        {
            byte[] array = new byte[6];
            array[0] = 0xE6;
            array[1] = 0xFD;
            array[2] = 0X20;
            array[3] = A_0;
            array[4] = A_1;
            array[5] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3] + array[4]));
            try
            {
                if (GlobalClass.c_bIsOpen)
                {
                    DataSend(array);
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
            catch
            {
            }
        }

        private void button_save_scen_Click(object sender, EventArgs e)
        {
            byte index = (byte)(comb_scene.SelectedIndex + 1);

            Send_to_Scene(0xCC, index);
        }

        private void button_read_scen_Click(object sender, EventArgs e)
        {
            byte index = (byte)(comb_scene.SelectedIndex + 1);

            Send_to_Scene(0xCD, index);
        }

        private void ucBtnImg1_BtnClick(object sender, EventArgs e)
        {
            if (GlobalClass.c_bIsOpen)
            {
                int count = 0;
                for (int i = 0; i < 256; i++)
                    GlobalClass.select_address[i] = 0;
                int num = 0;
                //if (tabControl3.SelectedIndex == 0)
                {
                    for (int j = rowStar; j <= rowEnd; j++)
                    {
                        for (int i = colStar; i <= colEnd; i++)
                        {
                            num = screens[((i + 1) + j * colsCount) - 1].Number;
                            GlobalClass.select_address[count] = (byte)num;
                            count++;
                            //Console.WriteLine("select_address[num] = " + select_address[num]);
                        }
                    }
                }

                Form_UartIrCmd_3458 f = new Form_UartIrCmd_3458(count);
                f.DataSend += this.DataSend;
                f.ShowDialog();
            }
            else
            {
                FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                return;
            }
        }
        #endregion

        #region 背光开关
        /// <summary>
        /// 背光开关线程
        /// </summary>
        /// <param name="rowS"></param>
        /// <param name="rowE"></param>
        /// <param name="colS"></param>
        /// <param name="colE"></param>
        private void Back_lightThread(int rowS, int rowE, int colS, int colE, bool on_off)
        {
            for (int i = rowS; i <= rowE; i++)
            {
                for (int j = colS; j <= colE; j++)
                {
                     int num = screens[((j + 1) + i * colsCount) - 1].Number;//对应的单元地址
                    byte[] array = new byte[5];
                    array[0] = 0xE5;
                    array[1] = (byte)num;//check_address[A_2];
                    array[2] = 0x20;
                    if (on_off)
                    {
                        array[3] = 0x73;//表示 --- 开
                    }
                    else
                    {
                        array[3] = 0x72;//表示 --- 关
                    }
                    array[4] = (byte)(0xFF - (0xFF & array[0] + array[1] + array[2] + array[3]));

                    if (GlobalClass.c_bIsOpen)
                    {
                        DataSend(array);
                    }
                    else
                    {
                        FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                        return;
                    }
                }
            }
        }
        private void BKOffToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //点击的是鼠标左键
            {
                if (GlobalClass.c_bIsOpen)
                {
                    myThread = new Thread(new ThreadStart(delegate ()
                {
                    Back_lightThread(rowStar, rowEnd, colStar, colEnd, false);
                })); //开线程         
                    myThread.Start(); //启动线程 
                    LogHelper.WriteLog("=====关闭背光操作=====");
                }
                else
                {
                    FrmDialog.ShowDialog(this, "Serial port is not open ！", "Tips", true);
                    return;
                }
            }
        }

        private void BLOnToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //点击的是鼠标左键
            {
                myThread = new Thread(new ThreadStart(delegate ()
                {
                    Back_lightThread(rowStar, rowEnd, colStar, colEnd, true);
                })); //开线程         
                myThread.Start(); //启动线程 
                LogHelper.WriteLog("=====打开背光操作=====");
            }
        }

        #endregion

        #region 色温参数调整
        private void AdjustStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            _adjustCP = new AdjustColorPage();
            _adjustCP.DataSend += this.DataSend;
            _adjustCP.ShowDialog();
        }
        #endregion

    }
}
