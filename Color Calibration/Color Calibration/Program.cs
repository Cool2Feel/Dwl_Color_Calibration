using Color_Calibration.ComLib;
using System;
using System.IO;
using System.Windows.Forms;

namespace Color_Calibration
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRuned;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out isRuned);
            if (isRuned)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                    mutex.ReleaseMutex();
                }
                catch (Exception e)
                {
                    //Console.WriteLine("message =" + e.Message);
                    ExceptionLog.getLog().WriteLogFile(e, "LogFile.txt");
                }
            }
            else
            {
                MessageBox.Show("      The current program is started  !    ", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
