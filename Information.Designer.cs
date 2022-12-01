
namespace TimeRecordingManagement
{
    partial class Information
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ddlMatter = new System.Windows.Forms.ComboBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.txtParticipants = new System.Windows.Forms.TextBox();
            this.lblNoPages = new System.Windows.Forms.Label();
            this.txtNoPages = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearchMatter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ddlMatter
            // 
            this.ddlMatter.AllowDrop = true;
            this.ddlMatter.DropDownHeight = 70;
            this.ddlMatter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMatter.FormattingEnabled = true;
            this.ddlMatter.IntegralHeight = false;
            this.ddlMatter.Location = new System.Drawing.Point(160, 44);
            this.ddlMatter.Name = "ddlMatter";
            this.ddlMatter.Size = new System.Drawing.Size(382, 28);
            this.ddlMatter.TabIndex = 0;
            this.ddlMatter.SelectedIndexChanged += new System.EventHandler(this.ddlMatter_SelectedIndexChanged);
            this.ddlMatter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ddlMatter_KeyPress);
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(160, 100);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(383, 26);
            this.txtPurpose.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Matter";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purpose";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Location = new System.Drawing.Point(18, 162);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(92, 20);
            this.lblParticipants.TabIndex = 4;
            this.lblParticipants.Text = "Participants";
            this.lblParticipants.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtParticipants
            // 
            this.txtParticipants.Location = new System.Drawing.Point(160, 156);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(383, 26);
            this.txtParticipants.TabIndex = 5;
            // 
            // lblNoPages
            // 
            this.lblNoPages.AutoSize = true;
            this.lblNoPages.Location = new System.Drawing.Point(18, 211);
            this.lblNoPages.Name = "lblNoPages";
            this.lblNoPages.Size = new System.Drawing.Size(96, 20);
            this.lblNoPages.TabIndex = 8;
            this.lblNoPages.Text = "No of Pages";
            this.lblNoPages.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtNoPages
            // 
            this.txtNoPages.Location = new System.Drawing.Point(160, 208);
            this.txtNoPages.Name = "txtNoPages";
            this.txtNoPages.Size = new System.Drawing.Size(106, 26);
            this.txtNoPages.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearchMatter
            // 
            this.txtSearchMatter.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSearchMatter.Location = new System.Drawing.Point(160, 12);
            this.txtSearchMatter.Name = "txtSearchMatter";
            this.txtSearchMatter.Size = new System.Drawing.Size(382, 26);
            this.txtSearchMatter.TabIndex = 11;
            this.txtSearchMatter.TextChanged += new System.EventHandler(this.txtSearchMatter_TextChanged);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 292);
            this.Controls.Add(this.txtSearchMatter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNoPages);
            this.Controls.Add(this.lblNoPages);
            this.Controls.Add(this.txtParticipants);
            this.Controls.Add(this.lblParticipants);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.ddlMatter);
            this.Name = "Information";
            this.Text = "Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Information_FormClosing);
            this.Load += new System.EventHandler(this.BindData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlMatter;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.TextBox txtParticipants;
        private System.Windows.Forms.Label lblNoPages;
        private System.Windows.Forms.TextBox txtNoPages;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearchMatter;
    }
}