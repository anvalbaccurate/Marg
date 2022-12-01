 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeManagementConsole
{
    class Program
    {
        private  Timer _timer;
        private DateTime _startTime = DateTime.MinValue;
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;
        private static int i = 0;
        static void Main(string[] args)
        {
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 0);


            Timer t = new Timer(TimerCallback, null, 0, 1000);
            Console.ReadLine();
        }
        private static string AssemblyDirectory1
        {
            get { return Path.GetDirectoryName(typeof(Program).Assembly.Location); }
        }
        private static void TimerCallback(Object o)
        {
            

            string UserID = ConfigurationManager.AppSettings["UserID"];
            string TimeKeeperID = ConfigurationManager.AppSettings["TimeKeeperID"];
            OperationManagement operationManagement = new OperationManagement();
            if (operationManagement.checkAvailabilityForOpenApplication(Convert.ToInt32(UserID), Convert.ToInt32(TimeKeeperID)) == 1)
            {
                

                Console.WriteLine(i);
                string configLogPath = AssemblyDirectory1+ "\\Windows\\TimeRecordingManagement.exe";
         
                using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                {

                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(configLogPath);
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.ErrorDialog = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    // process.Verb = "runas";
                    //  process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process.Start();
                }
                // Display the date/time when this method got called.
                Console.WriteLine("In TimerCallback: " + DateTime.Now);
                // Force a garbage collection to occur for this demo.
                GC.Collect();

                i = 2;
                Console.WriteLine(i);
            }
            
        }
    }
}
