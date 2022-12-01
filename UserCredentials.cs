using CredentialManagement;
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
    public partial class UserCredentials : Form
    {
        private const string PasswordName = "ALPAppPWD";
        public UserCredentials()
        {
           
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {

                Operations operations = new Operations();
                DataSet ds = operations.getUserRecords(txtEmail.Text, txtPassword.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblError.Visible = false;
                    using (var cred = new Credential())
                    {
                        cred.Password = txtPassword.Text;
                        cred.Username = txtEmail.Text;
                        cred.Target = PasswordName;
                        cred.Type = CredentialType.Generic;
                        cred.PersistanceType = PersistanceType.LocalComputer;
                        cred.Save();
                        UserDetails.username = cred.Username;
                        UserDetails.password = cred.Password;
                    }
                    
                    DataTable dt = ds.Tables[0];
                    UserDetails.timekeeperid = ds.Tables[0].Rows[0][1].ToString();
                    UserDetails.userid = ds.Tables[0].Rows[0][0].ToString();
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        var f = new TimerForm();
                        f.Show();
                    }
                }
                else
                {
                    lblError.Visible = true;
                }

            }
           
        }

     

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            bool isValid = true;
            if(string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                isValid = false;
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email should not be empty");
            }
            
            if(isValid == true)
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
               
                

            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                isValid = false;
                e.Cancel = true;
                errorProvider2.SetError(txtPassword, "Email should not be empty");
            }
            if (isValid == true)
            {
                e.Cancel = false;
                errorProvider2.SetError(txtEmail, "");



            }

        }
    }
}
