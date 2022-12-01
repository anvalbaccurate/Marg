using CredentialManagement;
using System;
using System.Data;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using log4net;

namespace TimeRecordingManagement
{

    public static class UserDetails
    {
        public static string username = "";
        public static string password = "";
        public static string timekeeperid = "";
        public static string userid = "";

    }
    static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            try
            {
                bool apprunning = false;
                if (args.Any())
                {
                    try
                    {
                        var f = MemoryMappedFile.CreateNew("ALBTimer", 1);
                    }
                    catch
                    {
                        apprunning = true;
                    }
                    if (apprunning)
                    {

                        using (var ff = MemoryMappedFile.CreateNew("ALBTimer2", 1))
                        {
                            Thread.Sleep(6000);

                        }
                        System.Environment.Exit(0);
                    }
                }
                try
                {
                    var dsd = MemoryMappedFile.CreateNew("ALBTimer", 1);
                }
                catch
                {
                    if(apprunning)
                    System.Environment.Exit(0);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (var cred = new Credential())
                {
                    cred.Target = "ALPAppPWD";
                    cred.Load();
                    if (!string.IsNullOrEmpty(cred.Password))
                    {
                        UserDetails.username = cred.Username;
                        UserDetails.password = cred.Password;
                        Operations operations = new Operations();
                        DataSet ds = operations.getUserRecords(UserDetails.username, UserDetails.password);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            UserDetails.timekeeperid = ds.Tables[0].Rows[0][1].ToString();
                            UserDetails.userid = ds.Tables[0].Rows[0][0].ToString();
                        }
                        else
                        {
                            Application.Run(new UserCredentials());
                        }
                        Application.Run(new TimerForm());
                    }
                    else
                        Application.Run(new UserCredentials());
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Exception "+ UserDetails.username, ex);
            }

        }
       
    }
}
