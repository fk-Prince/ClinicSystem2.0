namespace ClinicSystem.UserLoginForm
{
    partial class DoctorLogin
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
            this.lblDentistPortal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.doctorPin = new Guna.UI2.WinForms.Guna2TextBox();
            this.doctorID = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2ImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDentistPortal
            // 
            this.lblDentistPortal.AutoSize = true;
            this.lblDentistPortal.BackColor = System.Drawing.Color.Transparent;
            this.lblDentistPortal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDentistPortal.Location = new System.Drawing.Point(12, 19);
            this.lblDentistPortal.Name = "lblDentistPortal";
            this.lblDentistPortal.Size = new System.Drawing.Size(198, 25);
            this.lblDentistPortal.TabIndex = 1;
            this.lblDentistPortal.Text = "Welcome, Doctor!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(310, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.colorEnter);
            this.label1.MouseLeave += new System.EventHandler(this.colorExit);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderRadius = 20;
            this.panel1.Controls.Add(this.guna2Button2);
            this.panel1.Controls.Add(this.guna2ImageButton1);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.doctorPin);
            this.panel1.Controls.Add(this.doctorID);
            this.panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 280);
            this.panel1.TabIndex = 3;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(25, 238);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(260, 27);
            this.guna2Button2.TabIndex = 4;
            this.guna2Button2.Text = "Login via RFID?";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.BackColor = System.Drawing.Color.White;
            this.guna2ImageButton1.Image = global::ClinicSystem.Properties.Resources.shows;
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.InitialImage = global::ClinicSystem.Properties.Resources.shows;
            this.guna2ImageButton1.Location = new System.Drawing.Point(265, 110);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.Size = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2ImageButton1.TabIndex = 110;
            this.guna2ImageButton1.TabStop = false;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.guna2Button1.Location = new System.Drawing.Point(87, 159);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(138, 33);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "LOGIN";
            this.guna2Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // doctorPin
            // 
            this.doctorPin.BorderRadius = 5;
            this.doctorPin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.doctorPin.DefaultText = "0977";
            this.doctorPin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.doctorPin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.doctorPin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorPin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorPin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.doctorPin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.doctorPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.doctorPin.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.doctorPin.IconLeft = global::ClinicSystem.Properties.Resources.Lock;
            this.doctorPin.IconLeftSize = new System.Drawing.Size(30, 30);
            this.doctorPin.Location = new System.Drawing.Point(25, 102);
            this.doctorPin.Name = "doctorPin";
            this.doctorPin.Padding = new System.Windows.Forms.Padding(10, 0, 50, 0);
            this.doctorPin.PlaceholderText = "PIN";
            this.doctorPin.SelectedText = "";
            this.doctorPin.Size = new System.Drawing.Size(267, 36);
            this.doctorPin.TabIndex = 108;
            this.doctorPin.UseSystemPasswordChar = true;
            // 
            // doctorID
            // 
            this.doctorID.BorderRadius = 5;
            this.doctorID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.doctorID.DefaultText = "D2025-000001";
            this.doctorID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.doctorID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.doctorID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.doctorID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.doctorID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.doctorID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.doctorID.IconLeft = global::ClinicSystem.Properties.Resources.user;
            this.doctorID.IconLeftSize = new System.Drawing.Size(30, 30);
            this.doctorID.Location = new System.Drawing.Point(25, 44);
            this.doctorID.Name = "doctorID";
            this.doctorID.PlaceholderText = "ID";
            this.doctorID.SelectedText = "";
            this.doctorID.Size = new System.Drawing.Size(267, 36);
            this.doctorID.TabIndex = 107;
            // 
            // DoctorLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(333, 339);
            this.Controls.Add(this.lblDentistPortal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor Login";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2ImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDentistPortal;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox doctorPin;
        private Guna.UI2.WinForms.Guna2TextBox doctorID;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}