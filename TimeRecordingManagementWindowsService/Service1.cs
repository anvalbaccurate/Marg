using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimeRecordingManagementWindowsService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        int i = 0;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 1000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
        }
        public void WriteToFile(string Message)
        {
            if (i == 0)
            {
                ProcessStartInfo info = new ProcessStartInfo(@"F:\ALB\sourcecode\TimeManagementConsole\bin\Debug\TimeManagementConsole.exe");
                //info.UseShellExecute = false;
                //info.RedirectStandardError = true;
                //info.RedirectStandardInput = true;
                //info.RedirectStandardOutput = true;
                info.Verb = "runas";
                // info.CreateNoWindow = true;
                //info.ErrorDialog = false;
                //  info.WindowStyle = ProcessWindowStyle.Hidden;

                Process process = Process.Start(info);
                i = i + 1;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message+ "updated");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message + "updated");
                }
            }
        }
    }
}
