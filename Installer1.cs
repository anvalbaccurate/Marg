using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeRecordingManagement
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }
       
        protected override void OnAfterInstall(IDictionary savedState)
        {
            string execPath = "";
            try
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("ALBTimer");
                    key = Registry.ClassesRoot.CreateSubKey("ALBTimer");
                    key.SetValue("", "URL: ALBTimer Protocol");
                    key.SetValue("URL Protocol", "");
                    key = key.CreateSubKey(@"shell\open\command");
                    execPath =  Context.Parameters["TargetDir"].Remove(Context.Parameters["TargetDir"].Length-1,1) + "TimeRecordingManagement.exe";
                    key.SetValue("","\""+execPath+"\""+" "+ "\""+"%1" +"\"");
                    key.Close();
                
              
            }
            catch(Exception ex)
            {
                
                throw new Exception( execPath);
            }
        }
    }
}
