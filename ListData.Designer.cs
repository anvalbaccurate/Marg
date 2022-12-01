namespace TimeRecordingManagement
{
    partial class ListData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListData));
            this.ListOfData = new System.Windows.Forms.DataGridView();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListOfData)).BeginInit();
            this.SuspendLayout();
            // 
            // ListOfData
            // 
            this.ListOfData.AllowUserToAddRows = false;
            this.ListOfData.AllowUserToDeleteRows = false;
            this.ListOfData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ListOfData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActivityName,
            this.ActivityDate,
            this.Time,
            this.Status});
            this.ListOfData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ListOfData.Location = new System.Drawing.Point(12, 36);
            this.ListOfData.Name = "ListOfData";
            this.ListOfData.Size = new System.Drawing.Size(695, 334);
            this.ListOfData.TabIndex = 0;
            this.ListOfData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListOfData_CellDoubleClick);
            // 
            // ActivityName
            // 
            this.ActivityName.DataPropertyName = "ActivityName";
            this.ActivityName.Frozen = true;
            this.ActivityName.HeaderText = "Activity Name";
            this.ActivityName.MinimumWidth = 200;
            this.ActivityName.Name = "ActivityName";
            this.ActivityName.Width = 200;
            // 
            // ActivityDate
            // 
            this.ActivityDate.DataPropertyName = "ActivityDate";
            this.ActivityDate.Frozen = true;
            this.ActivityDate.HeaderText = "Activity Date";
            this.ActivityDate.MinimumWidth = 150;
            this.ActivityDate.Name = "ActivityDate";
            this.ActivityDate.Width = 150;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.Frozen = true;
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 150;
            this.Time.Name = "Time";
            this.Time.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 150;
            this.Status.Name = "Status";
            this.Status.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Please double click to resume an activity.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 423);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListOfData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListData";
            this.Text = "ALB - Time Paused Activity Details";
            ((System.ComponentModel.ISupportInitialize)(this.ListOfData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ListOfData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}