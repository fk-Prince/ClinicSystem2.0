namespace ClinicSystem
{
    partial class ClinicSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicSystem));
            this.sliding = new System.Windows.Forms.Timer(this.components);
            this.dateTimer = new System.Windows.Forms.Timer(this.components);
            this.hoursTimer = new System.Windows.Forms.Timer(this.components);
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StaffIdentity = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dashboardB = new System.Windows.Forms.Button();
            this.patientHistoryB = new System.Windows.Forms.Button();
            this.roomsB = new System.Windows.Forms.Button();
            this.appointmentsB = new System.Windows.Forms.Button();
            this.patientsB = new System.Windows.Forms.Button();
            this.dentistsB = new System.Windows.Forms.Button();
            this.operationsB = new System.Windows.Forms.Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Clock = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xTimer = new System.Windows.Forms.Timer(this.components);
            this.mainpanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sliding
            // 
            this.sliding.Interval = 1;
            // 
            // dateTimer
            // 
            this.dateTimer.Enabled = true;
            this.dateTimer.Interval = 43200;
            this.dateTimer.Tick += new System.EventHandler(this.dateTimer_Tick);
            // 
            // hoursTimer
            // 
            this.hoursTimer.Enabled = true;
            this.hoursTimer.Interval = 1000;
            this.hoursTimer.Tick += new System.EventHandler(this.hoursTimer_Tick);
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.mainpanel.Controls.Add(this.panel4);
            this.mainpanel.Location = new System.Drawing.Point(215, -2);
            this.mainpanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.mainpanel.MinimumSize = new System.Drawing.Size(1084, 724);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1084, 724);
            this.mainpanel.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel4.Location = new System.Drawing.Point(0, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 718);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(215, 719);
            this.panel6.TabIndex = 110;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel3.Controls.Add(this.StaffIdentity);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.guna2Button1);
            this.panel3.Controls.Add(this.Clock);
            this.panel3.Controls.Add(this.Date);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.MaximumSize = new System.Drawing.Size(215, 1080);
            this.panel3.MinimumSize = new System.Drawing.Size(215, 719);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 719);
            this.panel3.TabIndex = 0;
            // 
            // StaffIdentity
            // 
            this.StaffIdentity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StaffIdentity.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffIdentity.Location = new System.Drawing.Point(58, 671);
            this.StaffIdentity.Name = "StaffIdentity";
            this.StaffIdentity.Size = new System.Drawing.Size(151, 18);
            this.StaffIdentity.TabIndex = 100003;
            this.StaffIdentity.Text = "label1";
            this.StaffIdentity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.dashboardB);
            this.panel2.Controls.Add(this.patientHistoryB);
            this.panel2.Controls.Add(this.roomsB);
            this.panel2.Controls.Add(this.appointmentsB);
            this.panel2.Controls.Add(this.patientsB);
            this.panel2.Controls.Add(this.dentistsB);
            this.panel2.Controls.Add(this.operationsB);
            this.panel2.Location = new System.Drawing.Point(0, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 313);
            this.panel2.TabIndex = 100002;
            // 
            // dashboardB
            // 
            this.dashboardB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dashboardB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dashboardB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.dashboardB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dashboardB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardB.FlatAppearance.BorderSize = 0;
            this.dashboardB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardB.ForeColor = System.Drawing.Color.White;
            this.dashboardB.Image = global::ClinicSystem.Properties.Resources.dashboard;
            this.dashboardB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardB.Location = new System.Drawing.Point(0, 2);
            this.dashboardB.MaximumSize = new System.Drawing.Size(215, 46);
            this.dashboardB.MinimumSize = new System.Drawing.Size(215, 46);
            this.dashboardB.Name = "dashboardB";
            this.dashboardB.Size = new System.Drawing.Size(215, 46);
            this.dashboardB.TabIndex = 10000;
            this.dashboardB.TabStop = false;
            this.dashboardB.Text = "Dashboard";
            this.dashboardB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dashboardB.UseVisualStyleBackColor = false;
            this.dashboardB.Click += new System.EventHandler(this.dashboardClicked);
            this.dashboardB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // patientHistoryB
            // 
            this.patientHistoryB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientHistoryB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patientHistoryB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.patientHistoryB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patientHistoryB.FlatAppearance.BorderSize = 0;
            this.patientHistoryB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patientHistoryB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientHistoryB.ForeColor = System.Drawing.Color.White;
            this.patientHistoryB.Image = global::ClinicSystem.Properties.Resources.clinicrecord;
            this.patientHistoryB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientHistoryB.Location = new System.Drawing.Point(0, 270);
            this.patientHistoryB.MaximumSize = new System.Drawing.Size(215, 46);
            this.patientHistoryB.MinimumSize = new System.Drawing.Size(215, 46);
            this.patientHistoryB.Name = "patientHistoryB";
            this.patientHistoryB.Size = new System.Drawing.Size(215, 46);
            this.patientHistoryB.TabIndex = 10000;
            this.patientHistoryB.TabStop = false;
            this.patientHistoryB.Text = "Patient History";
            this.patientHistoryB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.patientHistoryB.UseVisualStyleBackColor = false;
            this.patientHistoryB.Click += new System.EventHandler(this.button8_Click);
            this.patientHistoryB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // roomsB
            // 
            this.roomsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomsB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roomsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.roomsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roomsB.FlatAppearance.BorderSize = 0;
            this.roomsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsB.ForeColor = System.Drawing.Color.White;
            this.roomsB.Image = global::ClinicSystem.Properties.Resources.rooms;
            this.roomsB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roomsB.Location = new System.Drawing.Point(0, 180);
            this.roomsB.MaximumSize = new System.Drawing.Size(215, 46);
            this.roomsB.MinimumSize = new System.Drawing.Size(215, 46);
            this.roomsB.Name = "roomsB";
            this.roomsB.Size = new System.Drawing.Size(215, 46);
            this.roomsB.TabIndex = 10000;
            this.roomsB.TabStop = false;
            this.roomsB.Text = "Rooms";
            this.roomsB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.roomsB.UseVisualStyleBackColor = false;
            this.roomsB.Click += new System.EventHandler(this.roomClicked);
            this.roomsB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // appointmentsB
            // 
            this.appointmentsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentsB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.appointmentsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.appointmentsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.appointmentsB.FlatAppearance.BorderSize = 0;
            this.appointmentsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appointmentsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsB.ForeColor = System.Drawing.Color.White;
            this.appointmentsB.Image = global::ClinicSystem.Properties.Resources.appointment;
            this.appointmentsB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appointmentsB.Location = new System.Drawing.Point(0, 225);
            this.appointmentsB.MaximumSize = new System.Drawing.Size(215, 46);
            this.appointmentsB.MinimumSize = new System.Drawing.Size(215, 46);
            this.appointmentsB.Name = "appointmentsB";
            this.appointmentsB.Size = new System.Drawing.Size(215, 46);
            this.appointmentsB.TabIndex = 10000;
            this.appointmentsB.TabStop = false;
            this.appointmentsB.Text = "Appointments";
            this.appointmentsB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.appointmentsB.UseVisualStyleBackColor = false;
            this.appointmentsB.Click += new System.EventHandler(this.appointmentButton_Click);
            this.appointmentsB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // patientsB
            // 
            this.patientsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientsB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.patientsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.patientsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patientsB.FlatAppearance.BorderSize = 0;
            this.patientsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patientsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientsB.ForeColor = System.Drawing.Color.White;
            this.patientsB.Image = global::ClinicSystem.Properties.Resources.patient;
            this.patientsB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patientsB.Location = new System.Drawing.Point(0, 47);
            this.patientsB.MaximumSize = new System.Drawing.Size(215, 46);
            this.patientsB.MinimumSize = new System.Drawing.Size(215, 46);
            this.patientsB.Name = "patientsB";
            this.patientsB.Size = new System.Drawing.Size(215, 46);
            this.patientsB.TabIndex = 10000;
            this.patientsB.TabStop = false;
            this.patientsB.Text = "Patients";
            this.patientsB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.patientsB.UseVisualStyleBackColor = false;
            this.patientsB.Click += new System.EventHandler(this.AddPatientS_Click_1);
            this.patientsB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // dentistsB
            // 
            this.dentistsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dentistsB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dentistsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.dentistsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dentistsB.FlatAppearance.BorderSize = 0;
            this.dentistsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dentistsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentistsB.ForeColor = System.Drawing.Color.White;
            this.dentistsB.Image = global::ClinicSystem.Properties.Resources.doctor2;
            this.dentistsB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dentistsB.Location = new System.Drawing.Point(0, 135);
            this.dentistsB.MaximumSize = new System.Drawing.Size(215, 46);
            this.dentistsB.MinimumSize = new System.Drawing.Size(215, 46);
            this.dentistsB.Name = "dentistsB";
            this.dentistsB.Size = new System.Drawing.Size(215, 46);
            this.dentistsB.TabIndex = 10000;
            this.dentistsB.TabStop = false;
            this.dentistsB.Text = "Doctor";
            this.dentistsB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dentistsB.UseVisualStyleBackColor = false;
            this.dentistsB.Click += new System.EventHandler(this.button5_Click);
            this.dentistsB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // operationsB
            // 
            this.operationsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationsB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.operationsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.operationsB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.operationsB.FlatAppearance.BorderSize = 0;
            this.operationsB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operationsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsB.ForeColor = System.Drawing.Color.White;
            this.operationsB.Image = global::ClinicSystem.Properties.Resources.operation;
            this.operationsB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.operationsB.Location = new System.Drawing.Point(0, 90);
            this.operationsB.MaximumSize = new System.Drawing.Size(215, 46);
            this.operationsB.MinimumSize = new System.Drawing.Size(215, 46);
            this.operationsB.Name = "operationsB";
            this.operationsB.Size = new System.Drawing.Size(215, 46);
            this.operationsB.TabIndex = 10000;
            this.operationsB.TabStop = false;
            this.operationsB.Text = "Operations";
            this.operationsB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.operationsB.UseVisualStyleBackColor = false;
            this.operationsB.Click += new System.EventHandler(this.OperationClicked);
            this.operationsB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.guna2Button1.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(69, 693);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(130, 23);
            this.guna2Button1.TabIndex = 100001;
            this.guna2Button1.Text = "SIGN OUT";
            this.guna2Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Clock
            // 
            this.Clock.AutoSize = true;
            this.Clock.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock.ForeColor = System.Drawing.Color.Black;
            this.Clock.Location = new System.Drawing.Point(18, 8);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(94, 40);
            this.Clock.TabIndex = 100000;
            this.Clock.Text = "ascda";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.Color.White;
            this.Date.Location = new System.Drawing.Point(51, 46);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(43, 25);
            this.Date.TabIndex = 100000;
            this.Date.Text = "dfg";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 671);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 44);
            this.pictureBox2.TabIndex = 103;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.mainpanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel1.MinimumSize = new System.Drawing.Size(1300, 720);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 720);
            this.panel1.TabIndex = 1;
            // 
            // xTimer
            // 
            this.xTimer.Interval = 1;
            this.xTimer.Tick += new System.EventHandler(this.xTimer_Tick);
            // 
            // ClinicSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1300, 720);
            this.Name = "ClinicSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClinicSystem";
            this.mainpanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer dateTimer;
        private System.Windows.Forms.Timer hoursTimer;
        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Clock;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button patientHistoryB;
        private System.Windows.Forms.Button appointmentsB;
        private System.Windows.Forms.Button roomsB;
        private System.Windows.Forms.Button dentistsB;
        private System.Windows.Forms.Button operationsB;
        private System.Windows.Forms.Button patientsB;
        private System.Windows.Forms.Button dashboardB;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer xTimer;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer sliding;
        private System.Windows.Forms.Label StaffIdentity;
    }
}