namespace ClinicSystem.Doctors
{
    partial class DoctorMainForm
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
            this.doctorpanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewDentistB = new Guna.UI2.WinForms.Guna2Button();
            this.addDentistB = new Guna.UI2.WinForms.Guna2Button();
            this.doctorpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // doctorpanel
            // 
            this.doctorpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorpanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.doctorpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.doctorpanel.Controls.Add(this.panel2);
            this.doctorpanel.Location = new System.Drawing.Point(0, 64);
            this.doctorpanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.doctorpanel.MinimumSize = new System.Drawing.Size(1089, 655);
            this.doctorpanel.Name = "doctorpanel";
            this.doctorpanel.Size = new System.Drawing.Size(1089, 655);
            this.doctorpanel.TabIndex = 106;
            this.doctorpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.doctorpanel_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel2.MinimumSize = new System.Drawing.Size(1084, 655);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 655);
            this.panel2.TabIndex = 109;
            // 
            // viewDentistB
            // 
            this.viewDentistB.BackColor = System.Drawing.Color.Transparent;
            this.viewDentistB.BorderColor = System.Drawing.Color.Gray;
            this.viewDentistB.BorderRadius = 18;
            this.viewDentistB.BorderThickness = 1;
            this.viewDentistB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewDentistB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewDentistB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewDentistB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewDentistB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(234)))), ((int)(((byte)(224)))));
            this.viewDentistB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.viewDentistB.ForeColor = System.Drawing.Color.Black;
            this.viewDentistB.Location = new System.Drawing.Point(27, 12);
            this.viewDentistB.Name = "viewDentistB";
            this.viewDentistB.Size = new System.Drawing.Size(203, 34);
            this.viewDentistB.TabIndex = 110;
            this.viewDentistB.Text = "View Doctor";
            this.viewDentistB.Click += new System.EventHandler(this.viewDoctorB_Click);
            this.viewDentistB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // addDentistB
            // 
            this.addDentistB.BackColor = System.Drawing.Color.Transparent;
            this.addDentistB.BorderColor = System.Drawing.Color.Gray;
            this.addDentistB.BorderRadius = 18;
            this.addDentistB.BorderThickness = 1;
            this.addDentistB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addDentistB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addDentistB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addDentistB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addDentistB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(234)))), ((int)(((byte)(224)))));
            this.addDentistB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addDentistB.ForeColor = System.Drawing.Color.Black;
            this.addDentistB.Location = new System.Drawing.Point(276, 12);
            this.addDentistB.Name = "addDentistB";
            this.addDentistB.Size = new System.Drawing.Size(203, 34);
            this.addDentistB.TabIndex = 111;
            this.addDentistB.Text = "Add Doctor";
            this.addDentistB.Click += new System.EventHandler(this.addDoctorB_Click);
            this.addDentistB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // DoctorMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1084, 719);
            this.Controls.Add(this.doctorpanel);
            this.Controls.Add(this.addDentistB);
            this.Controls.Add(this.viewDentistB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1084, 719);
            this.Name = "DoctorMainForm";
            this.Text = "1080, 719";
            this.doctorpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel doctorpanel;
        private Guna.UI2.WinForms.Guna2Button viewDentistB;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button addDentistB;
    }
}