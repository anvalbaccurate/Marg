using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeRecordingManagement
{
    public enum Action
    {
        
        Call =4,
        Draft=2,
        Review=3,
        Email=1
    }
    public partial class Information : Form
    {
        public DataTable Dt;
        public Action current;
        public string _purpose = string.Empty;
        public string _participants = string.Empty;
        public string _documentName = string.Empty;
        public string _noPages = string.Empty;
        public int _matter = 0;
        public string _guidelineExist ="Y";
        public Information(Action activity)
        {
            current = activity;
            InitializeComponent();
            this.ActiveControl = txtSearchMatter;
           
            
        }
        public void Data()
        {

        }
        private void BindData(object sender, EventArgs e)
        {

            Operations operations = new Operations();
            DataSet ds = operations.getClientMatter(Convert.ToInt32( UserDetails.timekeeperid));
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                Dt = ds.Tables[0];
                ddlMatter.DataSource = ds.Tables[0];
                ddlMatter.ValueMember = "ClientMatterId";
                ddlMatter.DisplayMember = "Matter";
             
            }
            HideOrShowControls();
        }
        private void HideOrShowControls()
        {
            _matter= Convert.ToInt32(ddlMatter.SelectedValue.ToString());
            DataRow data = Dt.AsEnumerable()
            .Where(x => x.Field<int>("ClientMatterId") == _matter).First();
            _guidelineExist = data["GuidelineExist"].ToString();
            switch (current)
            {
                case Action.Call:
                    DocumentHide();
                    if (_guidelineExist == "Y")
                        CallEmailShow();
                    else
                        CallEmailHide();
                    break;
                case Action.Draft:
                    if (_guidelineExist == "Y")
                        DocumentShow();
                    else
                        DocumentHide();
                    CallEmailHide();
                    break;
                case Action.Review:
                    if (_guidelineExist == "Y")
                        DocumentShow();
                    else
                        DocumentHide();
                    CallEmailHide();
                    break;
                case Action.Email:
                    DocumentHide();
                    if (_guidelineExist == "Y")
                        CallEmailShow();
                    else
                        CallEmailHide();
                    break;
            }
        }
        private void DocumentHide()
        {
            lblNoPages.Hide();
            txtNoPages.Hide();
        }
        private void DocumentShow()
        {
            lblNoPages.Show();
            txtNoPages.Show();

        }
        private void CallEmailShow()
        {
            lblParticipants.Show();
            txtParticipants.Show();

        }
        private void CallEmailHide()
        {
            lblParticipants.Hide();
            txtParticipants.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _purpose = txtPurpose.Text;
            _noPages = txtNoPages.Text;
            _participants = txtParticipants.Text;
            _matter = Convert.ToInt32( ddlMatter.SelectedValue.ToString());
            //current = Action.Call;
           this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ddlMatter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSearchMatter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchMatter.Text))
            {
                ddlMatter.DataSource = Dt; //your origin data

            }
            else
            {
               DataTable newTable = new DataTable();
               var data=Dt.AsEnumerable()
              .Where(x => x.Field<string>("Matter").ToUpper().Contains(txtSearchMatter.Text.ToUpper()));
                if (data.Count() > 0)
                {
                    newTable = data.CopyToDataTable();
                    ddlMatter.DataSource = newTable;
                }

            }

        }

        private void ddlMatter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj= ddlMatter.SelectedValue;
            if(obj is  int)
            {
                HideOrShowControls();
            }
            
        }

        private void Information_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
