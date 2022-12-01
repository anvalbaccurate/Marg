namespace TimeRecordingManagement
{
    partial class TimerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerForm));
            this.Start = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Call = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.Button();
            this.Document = new System.Windows.Forms.Button();
            this.Review = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BackToWeb = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.YellowGreen;
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.ForeColor = System.Drawing.Color.Transparent;
            this.Start.Location = new System.Drawing.Point(117, 157);
            this.Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(40, 35);
            this.Start.TabIndex = 1;
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Pause
            // 
            this.Pause.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pause.BackgroundImage")));
            this.Pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pause.ForeColor = System.Drawing.Color.Transparent;
            this.Pause.Location = new System.Drawing.Point(117, 154);
            this.Pause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(45, 40);
            this.Pause.TabIndex = 2;
            this.Pause.UseVisualStyleBackColor = false;
            this.Pause.Visible = false;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Call
            // 
            this.Call.BackColor = System.Drawing.Color.Green;
            this.Call.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Call.BackgroundImage")));
            this.Call.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Call.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.Call.FlatAppearance.BorderSize = 2;
            this.Call.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Call.Location = new System.Drawing.Point(44, 12);
            this.Call.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Call.Name = "Call";
            this.Call.Size = new System.Drawing.Size(50, 51);
            this.Call.TabIndex = 4;
            this.toolTip1.SetToolTip(this.Call, "Call");
            this.Call.UseVisualStyleBackColor = false;
            this.Call.Click += new System.EventHandler(this.Call_Click);
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Email.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Email.BackgroundImage")));
            this.Email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Email.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Email.Location = new System.Drawing.Point(140, 12);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(51, 51);
            this.Email.TabIndex = 5;
            this.toolTip1.SetToolTip(this.Email, "Email");
            this.Email.UseVisualStyleBackColor = false;
            this.Email.Click += new System.EventHandler(this.Email_Click);
            // 
            // Document
            // 
            this.Document.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Document.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Document.BackgroundImage")));
            this.Document.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Document.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Document.Location = new System.Drawing.Point(242, 12);
            this.Document.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Document.Name = "Document";
            this.Document.Size = new System.Drawing.Size(50, 51);
            this.Document.TabIndex = 6;
            this.toolTip1.SetToolTip(this.Document, "Draft");
            this.Document.UseVisualStyleBackColor = false;
            this.Document.Click += new System.EventHandler(this.Document_Click);
            // 
            // Review
            // 
            this.Review.BackColor = System.Drawing.Color.Violet;
            this.Review.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Review.BackgroundImage")));
            this.Review.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Review.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Review.Location = new System.Drawing.Point(346, 12);
            this.Review.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Review.Name = "Review";
            this.Review.Size = new System.Drawing.Size(50, 51);
            this.Review.TabIndex = 7;
            this.toolTip1.SetToolTip(this.Review, "Review");
            this.Review.UseVisualStyleBackColor = false;
            this.Review.Click += new System.EventHandler(this.Review_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Castellar", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(100, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "HH : MM : SS";
            // 
            // BackToWeb
            // 
            this.BackToWeb.BackColor = System.Drawing.Color.White;
            this.BackToWeb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackToWeb.BackgroundImage")));
            this.BackToWeb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackToWeb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackToWeb.Location = new System.Drawing.Point(366, 154);
            this.BackToWeb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BackToWeb.Name = "BackToWeb";
            this.BackToWeb.Size = new System.Drawing.Size(51, 49);
            this.BackToWeb.TabIndex = 11;
            this.BackToWeb.UseVisualStyleBackColor = false;
            this.BackToWeb.Click += new System.EventHandler(this.BackToWeb_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(3, 154);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 49);
            this.button3.TabIndex = 12;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Crimson;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.Transparent;
            this.btnStop.Location = new System.Drawing.Point(192, 154);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(45, 40);
            this.btnStop.TabIndex = 13;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(266, 157);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 37);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(422, 208);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BackToWeb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Call);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Document);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "TimerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time Recording";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Call;
        private System.Windows.Forms.Button Email;
        private System.Windows.Forms.Button Document;
        private System.Windows.Forms.Button Review;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BackToWeb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

