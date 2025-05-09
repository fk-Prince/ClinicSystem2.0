namespace ClinicSystem
{
    partial class FormPatient
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.addPatientB = new Guna.UI2.WinForms.Guna2Button();
            this.viewPatientB = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel2.MinimumSize = new System.Drawing.Size(1080, 668);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 668);
            this.panel2.TabIndex = 4;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // addPatientB
            // 
            this.addPatientB.BackColor = System.Drawing.Color.Transparent;
            this.addPatientB.BorderColor = System.Drawing.Color.Gray;
            this.addPatientB.BorderRadius = 18;
            this.addPatientB.BorderThickness = 1;
            this.addPatientB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPatientB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPatientB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPatientB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPatientB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.addPatientB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addPatientB.ForeColor = System.Drawing.Color.Black;
            this.addPatientB.Location = new System.Drawing.Point(14, 9);
            this.addPatientB.Name = "addPatientB";
            this.addPatientB.Size = new System.Drawing.Size(203, 34);
            this.addPatientB.TabIndex = 5;
            this.addPatientB.Text = "Add Patient";
            this.addPatientB.Click += new System.EventHandler(this.mouseClicked);
            this.addPatientB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addPatientClicked);
            // 
            // viewPatientB
            // 
            this.viewPatientB.BackColor = System.Drawing.Color.Transparent;
            this.viewPatientB.BorderColor = System.Drawing.Color.Gray;
            this.viewPatientB.BorderRadius = 18;
            this.viewPatientB.BorderThickness = 1;
            this.viewPatientB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewPatientB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewPatientB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewPatientB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewPatientB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.viewPatientB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.viewPatientB.ForeColor = System.Drawing.Color.Black;
            this.viewPatientB.Location = new System.Drawing.Point(239, 9);
            this.viewPatientB.Name = "viewPatientB";
            this.viewPatientB.Size = new System.Drawing.Size(203, 34);
            this.viewPatientB.TabIndex = 6;
            this.viewPatientB.Text = "View Patients";
            this.viewPatientB.Click += new System.EventHandler(this.mouseClicked);
            this.viewPatientB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.viewPatientClicked);
            // 
            // FormPatient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1080, 719);
            this.Controls.Add(this.viewPatientB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.addPatientB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1080, 719);
            this.Name = "FormPatient";
            this.Text = "PatientForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Guna.UI2.WinForms.Guna2Button viewPatientB;
        private Guna.UI2.WinForms.Guna2Button addPatientB;
    }
}