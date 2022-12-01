using Microsoft.Office.Interop.Word;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;
using Timer = System.Windows.Forms.Timer;

namespace TimeRecordingManagement
{
    public partial class TimerForm : Form
    {
        public Action _current;
        private Action _prev;
        private Timer _timer;
        private Timer timer1;

        private DateTime _startTime = DateTime.MinValue;
        private TimeSpan _currentElapsedTime = TimeSpan.Zero;
        private TimeSpan _totalElapsedTime = TimeSpan.Zero;
        public bool _timerRunning = false;
        private bool _isCallSelected = false;
        private bool _isDocumentSelected = false;
        private bool _isEmailSelected = false;
        private bool _isDraftSelected = false;
        private string _purpose = string.Empty;
        private string _participants = string.Empty;
        private string _documentName = string.Empty;
        private string _noPages = string.Empty;
        private int _clientMatterId = 0;
        int TimeManagementID = -1;
        public bool isPaused = false;
        public TimerForm()
        {
            Shell32.Shell objShel = new Shell32.Shell();
            objShel.ToggleDesktop();
            InitializeComponent();
            _timer = new Timer();

            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);

            buttonColor();
            checkedforactive();
            InitTimer();

        }
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(checkActivityResume);
            timer1.Interval = 5000; // in miliseconds
            timer1.Start();
        }
        private async Task CheckForUpdate()
        {
            using(var manager = new UpdateManager(""))
            {
                await manager.UpdateApp();
            }
        }
        void checkActivityResume(object sender, EventArgs e)
        {
            try
            {
                    var mmf = MemoryMappedFile.OpenExisting("ALBTimer2");
                    mmf.Dispose();
                    PauseCurrentAction();
                    if (this.isPaused)
                    {
                        
                            checkedforactive();
                        
                    }
                
            }
            catch
            {

            }
        }
        public void checkedforactive()
        {
            string UserID = UserDetails.userid;
            Operations operations = new Operations();
            DataSet ds = operations.getRecords(Convert.ToInt32(UserID));
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                string TypeOfTaskID = Convert.ToString(ds.Tables[0].Rows[0]["TypeOfTaskID"]);
                DateTime dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ToTime"]);
                TimeManagementID = Convert.ToInt32(ds.Tables[0].Rows[0]["TaskTimeManagementId"]);
                _currentElapsedTime = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
                string TaskName = "";
                if (TypeOfTaskID == "4")
                {
                    _isCallSelected = true;
                    TaskName = "Call";
                    _prev = _current;
                    _current = Action.Call;


                }
                if (TypeOfTaskID == "1")
                {
                    _isEmailSelected = true;
                    TaskName = "Draft an Email";
                    _prev = _current;
                    _current = Action.Email;
                }
                if (TypeOfTaskID == "2")
                {
                    _isDocumentSelected = true;
                    TaskName = "Draft a Document";
                    _prev = _current;
                    _current = Action.Draft;
                }

                if (TypeOfTaskID == "3")
                {
                    _isDraftSelected = true;
                    TaskName = "Review a Document";
                    _prev = _current;
                    _current = Action.Review;
                }

                buttonColor();
                Start_Click(null, null);
            }
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            // We do this to 'chop off' any stray milliseconds
            // resulting from the Timer's inherent inaccuracy,
            // with the bonus that the TimeSpan.ToString() method
            // will now show the correct HH:MM:SS format
            var timeSinceStartTime = DateTime.Now - _startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);

            // The current elapsed time is the time since the start button
            // was clicked, plus the total time elapsed since the last reset
            _currentElapsedTime = timeSinceStartTime + _totalElapsedTime;
            bool _timerto = true;
            if (_currentElapsedTime.Minutes % 6 == 0 && _currentElapsedTime.Minutes != 0 && _currentElapsedTime.Seconds == 1 && _timerto)
            {
                //string message = "Current activity is running from last 6 minutes, do you still want to continue it ?";
                //string title = "Confirmation !";
                //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                //DialogResult result = MessageBox.Show(message, title, buttons);
                //_timerto = false;
                //if (result == DialogResult.Yes)
                //{
                //    _timerto = true;
                //    // These are just two Label controls which display the current
                //    // elapsed time and total elapsed time
                //    label2.Text = _currentElapsedTime.Hours.ToString("D2") + " : " + _currentElapsedTime.Minutes.ToString("D2") + " : " + _currentElapsedTime.Seconds.ToString("D2");
                //}
                //else {
                //    _timerto = true;
                //    btnStop_Click(null, null);
                //}
            }
            else
            {

                label2.Text = _currentElapsedTime.Hours.ToString("D2") + " : " + _currentElapsedTime.Minutes.ToString("D2") + " : " + _currentElapsedTime.Seconds.ToString("D2");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form form1 = (TimerForm)sender;
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = new System.Drawing.Point(1050, 550);
        }
        private void Call_Click(object sender, EventArgs e)
        {
            PauseCurrentAction();
            if(isPaused)
            {
                _current = Action.Call;
                if (StartActivity())
                    Start_Click(null, null);
                else
                    _current = 0;
            }
        }
        private void Email_Click(object sender, EventArgs e)
        {
            PauseCurrentAction();
            if(isPaused)
            {
                _current = Action.Email;
                if (StartActivity())
                {
                    Start_Click(null, null);
                    EmailAction();
                }
                else
                    _current = 0;
            }
        }
        private void Document_Click(object sender, EventArgs e)
        {
            PauseCurrentAction();
            if(isPaused)
            {
                _current = Action.Draft;
                if(StartActivity())
                {
                    Start_Click(null, null);
                }
                else
                    _current = 0;
            }
        }
        private void Review_Click(object sender, EventArgs e)
        {
            PauseCurrentAction();
            if (isPaused)
            {
                _current = Action.Review;
                if(StartActivity())
                {
                    Start_Click(null, null);
                    ReviewActions();
                }
                else
                    _current = 0;

            }
        }
        private void EmailAction()
        {
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            oMailItem.To = "";
            // body, bcc etc...
            oMailItem.Display(false);

        }
        private void DraftAction()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    System.Diagnostics.Process.Start(filePath);
                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();
                    //Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                    //Document document = ap.Documents.Open(filePath);

                }
            }

        }
        private void ReviewActions()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    System.Diagnostics.Process.Start(filePath);
                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();
                    //Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                    //Document document = ap.Documents.Open(filePath);

                }
            }

        }
        private bool StartActivity()
        {
            bool Notcancel = true;
            Information information = new Information(_current);
            var result = information.ShowDialog();
            if (result == DialogResult.OK)
            {
                _documentName = information._documentName;
                _participants = information._participants;
                _purpose = information._purpose;
                _noPages = information._noPages;
                _clientMatterId = information._matter;
            }
            else
            {
                Notcancel= false;
            }
            return Notcancel;
        }
        private string DisplayText(Action action)
        {
            string actionText = "";
            switch (action)
            {
                case Action.Call: actionText = "Call";
                    break;
                case Action.Draft:
                    actionText = "Draft a Document";
                    break;
                case Action.Email:
                    actionText = "Draft an Email";
                    break;
                case Action.Review:
                    actionText = "Review a Document";
                    break;
            }
            return actionText;
        }
        private void PausePrevAction()
        {
            isPaused = false;
            string messagein = "";
            string titlein = "Confirmation !";
            messagein = $"You are trying to switch from {DisplayText(_prev)} to {DisplayText(_current)} so your timing for {DisplayText(_prev)} will be paused and  {DisplayText(_current)} timing will be started. Do you want to continue ?";
            MessageBoxButtons buttonsin = MessageBoxButtons.YesNo;
            DialogResult resultin = MessageBox.Show(messagein, titlein, buttonsin);
            if (resultin == DialogResult.Yes)
            {
                string TypeOfTaskID = "0";
                string TaskName = "";
                TypeOfTaskID = ((int)_prev).ToString();
                TaskName = DisplayText(_prev);
                string UserID = UserDetails.userid;
                string TimeKeeperID = UserDetails.timekeeperid;
                Operations operations = new Operations();
                int value = operations.SaveRecords(Convert.ToInt32(TypeOfTaskID), TaskName, label2.Text, "Pause - In Progress", Convert.ToInt32(UserID), Convert.ToInt32(TimeKeeperID), TimeManagementID, _purpose, _participants, _documentName, _noPages, _clientMatterId);
                isPaused = true;
                Reset();
            }
            

        }

        private void Reset()
        {
             _purpose = string.Empty;
             _participants = string.Empty;
             _documentName = string.Empty;
             _noPages = string.Empty;
             _clientMatterId = 0;
             TimeManagementID = -1;
            _current = 0;
            _prev = 0;
            clearTimer();

        }
        public void PauseCurrentAction()
        {
                isPaused = false;
                if (_current != 0)
                {
                    string messagein = "";
                    string titlein = "Confirmation !";
                    messagein = $"Do you want to start new activity pausing the current running activity?";
                    MessageBoxButtons buttonsin = MessageBoxButtons.YesNo;
                    DialogResult resultin = MessageBox.Show(messagein, titlein, buttonsin);
                    if (resultin == DialogResult.Yes)
                    {
                        isPaused = true;
                        string TypeOfTaskID = "0";
                        string TaskName = "";
                        TypeOfTaskID = ((int)_current).ToString();
                        TaskName = DisplayText(_current);
                        string UserID = UserDetails.userid;
                        string TimeKeeperID = UserDetails.timekeeperid;
                        Operations operations = new Operations();
                        int value = operations.SaveRecords(Convert.ToInt32(TypeOfTaskID), TaskName, label2.Text, "Pause - In Progress", Convert.ToInt32(UserID), Convert.ToInt32(TimeKeeperID), TimeManagementID, _purpose, _participants, _documentName, _noPages, _clientMatterId);
                        Reset();
                    }
                }
                else
                {
                    isPaused = true;
                }
        }
        void buttonColor()
        {
            Review.FlatAppearance.BorderColor = _isDraftSelected ? Color.Green : Color.White;
            Review.FlatAppearance.BorderSize = 1;
            Email.FlatAppearance.BorderColor = _isEmailSelected ? Color.Green : Color.White;
            Email.FlatAppearance.BorderSize = 1;
            Document.FlatAppearance.BorderColor = _isDocumentSelected ? Color.Green : Color.White;
            Document.FlatAppearance.BorderSize = 1;
            Call.FlatAppearance.BorderColor = _isCallSelected ? Color.Green : Color.White;
            Call.FlatAppearance.BorderSize = 1;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            
            if (_current!=0)
            {
                if ( true)
                { 
                    
                    Start.Visible = false;
                    Pause.Visible = true;
                    if (!_timerRunning)
                    {
                        // Set the start time to Now
                        _startTime = DateTime.Now;

                        // Store the total elapsed time so far
                        _totalElapsedTime = _currentElapsedTime;

                        _timer.Start();
                        _timerRunning = true;
                    }
                    else // If the timer is already running
                    {
                        _timer.Stop();
                        _timerRunning = false;
                    }
                }
                buttonColor();
            }
            else {
                MessageBox.Show("Please select atleast one activity for Time recording.");
            }
        }
        private void Pause_Click(object sender, EventArgs e)
        {
            if (!_timerRunning )
            {
                MessageBox.Show("Timer is not started yet.");
            }
            else // If the timer is already running
            {
                string messagein = "Do you want to pause this activity? ";
                string titlein = "Confirmation !";
                if (true)
                {
                    MessageBoxButtons buttonsin = MessageBoxButtons.YesNo;
                    DialogResult resultin = MessageBox.Show(messagein, titlein, buttonsin);
                    if (resultin == DialogResult.Yes)
                    {
                            
                            Pause.Visible = false;
                            Start.Visible = true;
                            _timer.Stop();
                            _timerRunning = false;

                    }
                    
                }
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.Exit();
            string message = "Do you want to reset your timer?";
            string title = "Confirmation !";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Reset();
            }

        }
        private void SaveActivity()
        {
            Operations operations = new Operations();
            string TypeOfTaskID = "0";
            string TaskName = "";
            TypeOfTaskID = ((int)_current).ToString();
            TaskName = DisplayText(_current);
            string UserID = UserDetails.userid;
            string TimeKeeperID = UserDetails.timekeeperid;
            int value = operations.SaveRecords(Convert.ToInt32(TypeOfTaskID), TaskName, label2.Text, "Completed-Not Billed", Convert.ToInt32(UserID), Convert.ToInt32(TimeKeeperID), TimeManagementID, _purpose, _participants, _documentName, _noPages, _clientMatterId);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings["url"];
            if (label2.Text.ToString().Trim() != "HH : MM : SS")
            {
                _timer.Stop();
                string message = "Do you want to bill this task/activity?";
                string title = "Confirmation !";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                
                SaveActivity();
                Reset();
                if (result == DialogResult.Yes)
                {
                    
                    string target = url + "TimeRecordingManagement/index";
                    System.Diagnostics.Process.Start(target);
                }
                
            }
        }
        public void clearTimer()
        {
            Pause.Visible = false;
            Start.Visible = true;
            _timer.Stop();
            _timerRunning = false;
            label2.Text = "HH : MM : SS";
          _startTime = DateTime.MinValue;
          _currentElapsedTime = TimeSpan.Zero;
          _totalElapsedTime = TimeSpan.Zero;
        }
        private void BackToWeb_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings["url"];
            string target = url + "TimeRecordingManagement/Index";
            System.Diagnostics.Process.Start(target);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string url = ConfigurationManager.AppSettings["url"];
            ListData listData = new ListData(this);
            listData.ShowDialog();
            //this.Hide();
            //string target = url + "TimeRecordingManagement/Index";
            //System.Diagnostics.Process.Start(target);
        }

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var mmf = MemoryMappedFile.OpenExisting("ALBTimer1");
                mmf.Dispose();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
