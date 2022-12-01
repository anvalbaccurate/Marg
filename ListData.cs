using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeRecordingManagement
{
    public partial class ListData : Form
    {
        TimerForm form1;
        public ListData(TimerForm form)
        {
            form1 = form;
            InitializeComponent();
            BindtheGrid();
        }

        private void BindtheGrid()
        {
            Operations operations = new Operations();
            string TimeKeeperID = UserDetails.timekeeperid;
            DataSet ds = operations.getRecordsForPaused(Convert.ToInt32(TimeKeeperID));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ListOfData.DataSource = ds.Tables[0];
                ListOfData.AutoGenerateColumns = false;
                ListOfData.Columns["Action"].Visible = false;
                ListOfData.Refresh();
            }

        }

     

        private void ListOfData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(form1._current!=0)
            {
                form1.PauseCurrentAction();
                if(form1.isPaused)
                {
                    string TimeManagementID = ListOfData.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string UserID = UserDetails.userid;
                    string TimeKeeperID = UserDetails.timekeeperid;
                    Operations operations = new Operations();
                    operations.OpenPausedEntry(Convert.ToInt32(UserID), Convert.ToInt32(TimeManagementID));

                    this.Close();
                    form1.checkedforactive();
                }
            }
            else
            {
                string TimeManagementID = ListOfData.Rows[e.RowIndex].Cells[4].Value.ToString();
                string UserID = UserDetails.userid;
                string TimeKeeperID = UserDetails.timekeeperid;
                Operations operations = new Operations();
                operations.OpenPausedEntry(Convert.ToInt32(UserID), Convert.ToInt32(TimeManagementID));

                this.Close();
                form1.checkedforactive();
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
