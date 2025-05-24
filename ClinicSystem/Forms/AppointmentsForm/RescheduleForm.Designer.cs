namespace ClinicSystem.Appointments
{
    partial class RescheduleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateAppointmentB = new Guna.UI2.WinForms.Guna2Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panelRoomNo = new System.Windows.Forms.Panel();
            this.roomNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.EndTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelAppNo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboAppointment = new System.Windows.Forms.ComboBox();
            this.panelDentName = new System.Windows.Forms.Panel();
            this.doctorL = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.StartTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDateSched = new System.Windows.Forms.Panel();
            this.dateSchedulePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panelPatName = new System.Windows.Forms.Panel();
            this.tbPname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOperName = new System.Windows.Forms.Panel();
            this.tbOname = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panelRoomNo.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelAppNo.SuspendLayout();
            this.panelDentName.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelDateSched.SuspendLayout();
            this.panelPatName.SuspendLayout();
            this.panelOperName.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.updateAppointmentB);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel1.MinimumSize = new System.Drawing.Size(1089, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 566);
            this.panel1.TabIndex = 0;
            // 
            // updateAppointmentB
            // 
            this.updateAppointmentB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateAppointmentB.BackColor = System.Drawing.Color.Transparent;
            this.updateAppointmentB.BorderColor = System.Drawing.Color.Transparent;
            this.updateAppointmentB.BorderRadius = 18;
            this.updateAppointmentB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateAppointmentB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateAppointmentB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateAppointmentB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateAppointmentB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.updateAppointmentB.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.updateAppointmentB.ForeColor = System.Drawing.Color.White;
            this.updateAppointmentB.Location = new System.Drawing.Point(726, 498);
            this.updateAppointmentB.Name = "updateAppointmentB";
            this.updateAppointmentB.Size = new System.Drawing.Size(337, 42);
            this.updateAppointmentB.TabIndex = 10090;
            this.updateAppointmentB.Text = "Update";
            this.updateAppointmentB.Click += new System.EventHandler(this.updateAppointmentB_Click);
            // 
            // panel12
            // 
            this.panel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel12.Controls.Add(this.panelRoomNo);
            this.panel12.Controls.Add(this.panel6);
            this.panel12.Controls.Add(this.panelAppNo);
            this.panel12.Controls.Add(this.panelDentName);
            this.panel12.Controls.Add(this.panel5);
            this.panel12.Controls.Add(this.panelDateSched);
            this.panel12.Controls.Add(this.panelPatName);
            this.panel12.Controls.Add(this.panelOperName);
            this.panel12.Location = new System.Drawing.Point(161, 26);
            this.panel12.MaximumSize = new System.Drawing.Size(1000, 1080);
            this.panel12.MinimumSize = new System.Drawing.Size(788, 419);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(788, 419);
            this.panel12.TabIndex = 10089;
            // 
            // panelRoomNo
            // 
            this.panelRoomNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelRoomNo.BackColor = System.Drawing.Color.Transparent;
            this.panelRoomNo.Controls.Add(this.roomNo);
            this.panelRoomNo.Controls.Add(this.label9);
            this.panelRoomNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRoomNo.Location = new System.Drawing.Point(111, 177);
            this.panelRoomNo.Name = "panelRoomNo";
            this.panelRoomNo.Size = new System.Drawing.Size(559, 42);
            this.panelRoomNo.TabIndex = 10085;
            // 
            // roomNo
            // 
            this.roomNo.BorderRadius = 5;
            this.roomNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.roomNo.DefaultText = "";
            this.roomNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.roomNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.roomNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.roomNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.roomNo.Enabled = false;
            this.roomNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.roomNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomNo.Location = new System.Drawing.Point(229, 8);
            this.roomNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roomNo.Name = "roomNo";
            this.roomNo.PlaceholderText = "";
            this.roomNo.SelectedText = "";
            this.roomNo.Size = new System.Drawing.Size(323, 25);
            this.roomNo.TabIndex = 10091;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Room No.";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.EndTime);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(111, 366);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(559, 42);
            this.panel6.TabIndex = 10087;
            // 
            // EndTime
            // 
            this.EndTime.BorderRadius = 5;
            this.EndTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EndTime.DefaultText = "";
            this.EndTime.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EndTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EndTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EndTime.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EndTime.Enabled = false;
            this.EndTime.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EndTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EndTime.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EndTime.Location = new System.Drawing.Point(229, 11);
            this.EndTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EndTime.Name = "EndTime";
            this.EndTime.PlaceholderText = "";
            this.EndTime.SelectedText = "";
            this.EndTime.Size = new System.Drawing.Size(323, 25);
            this.EndTime.TabIndex = 10093;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "End-Time";
            // 
            // panelAppNo
            // 
            this.panelAppNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAppNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelAppNo.BackColor = System.Drawing.Color.Transparent;
            this.panelAppNo.Controls.Add(this.label2);
            this.panelAppNo.Controls.Add(this.comboAppointment);
            this.panelAppNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAppNo.Location = new System.Drawing.Point(26, 18);
            this.panelAppNo.Name = "panelAppNo";
            this.panelAppNo.Size = new System.Drawing.Size(503, 42);
            this.panelAppNo.TabIndex = 10083;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appointment No.";
            // 
            // comboAppointment
            // 
            this.comboAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboAppointment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboAppointment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboAppointment.BackColor = System.Drawing.Color.White;
            this.comboAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAppointment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboAppointment.FormattingEnabled = true;
            this.comboAppointment.IntegralHeight = false;
            this.comboAppointment.Location = new System.Drawing.Point(120, 6);
            this.comboAppointment.MaximumSize = new System.Drawing.Size(374, 0);
            this.comboAppointment.MinimumSize = new System.Drawing.Size(374, 0);
            this.comboAppointment.Name = "comboAppointment";
            this.comboAppointment.Size = new System.Drawing.Size(374, 29);
            this.comboAppointment.TabIndex = 0;
            this.comboAppointment.SelectedIndexChanged += new System.EventHandler(this.comboAppointment_SelectedIndexChanged);
            this.comboAppointment.TextChanged += new System.EventHandler(this.comboAppointment_TextChanged);
            this.comboAppointment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboAppointment_KeyDown);
            // 
            // panelDentName
            // 
            this.panelDentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDentName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDentName.BackColor = System.Drawing.Color.Transparent;
            this.panelDentName.Controls.Add(this.doctorL);
            this.panelDentName.Controls.Add(this.label8);
            this.panelDentName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelDentName.Location = new System.Drawing.Point(111, 129);
            this.panelDentName.Name = "panelDentName";
            this.panelDentName.Size = new System.Drawing.Size(559, 42);
            this.panelDentName.TabIndex = 10085;
            // 
            // doctorL
            // 
            this.doctorL.BorderRadius = 5;
            this.doctorL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.doctorL.DefaultText = "";
            this.doctorL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.doctorL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.doctorL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.doctorL.Enabled = false;
            this.doctorL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.doctorL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.doctorL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.doctorL.Location = new System.Drawing.Point(229, 9);
            this.doctorL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.doctorL.Name = "doctorL";
            this.doctorL.PlaceholderText = "";
            this.doctorL.SelectedText = "";
            this.doctorL.Size = new System.Drawing.Size(323, 25);
            this.doctorL.TabIndex = 10091;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Doctor Name";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.StartTime);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(111, 318);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(559, 42);
            this.panel5.TabIndex = 10086;
            // 
            // StartTime
            // 
            this.StartTime.BackColor = System.Drawing.Color.White;
            this.StartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartTime.Enabled = false;
            this.StartTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartTime.FormattingEnabled = true;
            this.StartTime.IntegralHeight = false;
            this.StartTime.ItemHeight = 21;
            this.StartTime.Items.AddRange(new object[] {
            "09:00:00 AM",
            "09:30:00 AM",
            "10:00:00 AM",
            "10:30:00 AM",
            "11:00:00 AM",
            "11:30:00 AM",
            "12:00:00 PM",
            "12:30:00 PM",
            "01:00:00 PM",
            "01:30:00 PM",
            "02:00:00 PM",
            "02:30:00 PM",
            "03:00:00 PM",
            "03:30:00 PM",
            "04:00:00 PM",
            "04:30:00 PM",
            "05:00:00 PM",
            "05:30:00 PM",
            "06:00:00 PM",
            "06:30:00 PM",
            "07:00:00 PM",
            "07:30:00 PM",
            "08:00:00 PM",
            "08:30:00 PM",
            "09:00:00 PM"});
            this.StartTime.Location = new System.Drawing.Point(229, 7);
            this.StartTime.MaxDropDownItems = 5;
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(323, 29);
            this.StartTime.TabIndex = 10104;
            this.StartTime.SelectedIndexChanged += new System.EventHandler(this.StartTime_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Start Time";
            // 
            // panelDateSched
            // 
            this.panelDateSched.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDateSched.BackColor = System.Drawing.Color.Transparent;
            this.panelDateSched.Controls.Add(this.dateSchedulePicker);
            this.panelDateSched.Controls.Add(this.label4);
            this.panelDateSched.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDateSched.Location = new System.Drawing.Point(111, 270);
            this.panelDateSched.Name = "panelDateSched";
            this.panelDateSched.Size = new System.Drawing.Size(559, 42);
            this.panelDateSched.TabIndex = 10085;
            // 
            // dateSchedulePicker
            // 
            this.dateSchedulePicker.BorderRadius = 5;
            this.dateSchedulePicker.Checked = true;
            this.dateSchedulePicker.FillColor = System.Drawing.Color.PaleGreen;
            this.dateSchedulePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateSchedulePicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateSchedulePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateSchedulePicker.Location = new System.Drawing.Point(229, 8);
            this.dateSchedulePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateSchedulePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateSchedulePicker.Name = "dateSchedulePicker";
            this.dateSchedulePicker.Size = new System.Drawing.Size(323, 28);
            this.dateSchedulePicker.TabIndex = 2;
            this.dateSchedulePicker.Value = new System.DateTime(2025, 4, 25, 13, 32, 14, 754);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Date-Scheduled";
            // 
            // panelPatName
            // 
            this.panelPatName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPatName.BackColor = System.Drawing.Color.Transparent;
            this.panelPatName.Controls.Add(this.tbPname);
            this.panelPatName.Controls.Add(this.label3);
            this.panelPatName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPatName.Location = new System.Drawing.Point(26, 66);
            this.panelPatName.Name = "panelPatName";
            this.panelPatName.Size = new System.Drawing.Size(559, 42);
            this.panelPatName.TabIndex = 10084;
            // 
            // tbPname
            // 
            this.tbPname.AutoSize = true;
            this.tbPname.Location = new System.Drawing.Point(124, 10);
            this.tbPname.Name = "tbPname";
            this.tbPname.Size = new System.Drawing.Size(0, 20);
            this.tbPname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Patient Name";
            // 
            // panelOperName
            // 
            this.panelOperName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelOperName.BackColor = System.Drawing.Color.Transparent;
            this.panelOperName.Controls.Add(this.tbOname);
            this.panelOperName.Controls.Add(this.label7);
            this.panelOperName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelOperName.Location = new System.Drawing.Point(111, 225);
            this.panelOperName.Name = "panelOperName";
            this.panelOperName.Size = new System.Drawing.Size(559, 39);
            this.panelOperName.TabIndex = 10085;
            // 
            // tbOname
            // 
            this.tbOname.BorderRadius = 5;
            this.tbOname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOname.DefaultText = "";
            this.tbOname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbOname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbOname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbOname.Enabled = false;
            this.tbOname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbOname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbOname.Location = new System.Drawing.Point(229, 6);
            this.tbOname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOname.Name = "tbOname";
            this.tbOname.PlaceholderText = "";
            this.tbOname.SelectedText = "";
            this.tbOname.Size = new System.Drawing.Size(323, 25);
            this.tbOname.TabIndex = 10092;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Operation Name";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.panel10.Controls.Add(this.label13);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.MaximumSize = new System.Drawing.Size(1920, 96);
            this.panel10.MinimumSize = new System.Drawing.Size(1089, 96);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1089, 96);
            this.panel10.TabIndex = 10086;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(388, 22);
            this.label10.MaximumSize = new System.Drawing.Size(1920, 37);
            this.label10.MinimumSize = new System.Drawing.Size(323, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(323, 37);
            this.label10.TabIndex = 10059;
            this.label10.Text = "Appointment Details";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.Location = new System.Drawing.Point(0, 102);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1080, 2);
            this.panel11.TabIndex = 10082;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(2, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(432, 13);
            this.label13.TabIndex = 10085;
            this.label13.Text = "Note:  Rescheduling is only allowed within 3 days before the original appointment" +
    "\r\n";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RescheduleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(1089, 659);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1089, 659);
            this.Name = "RescheduleForm";
            this.Text = "RescheduleForm";
            this.panel1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panelRoomNo.ResumeLayout(false);
            this.panelRoomNo.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelAppNo.ResumeLayout(false);
            this.panelAppNo.PerformLayout();
            this.panelDentName.ResumeLayout(false);
            this.panelDentName.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelDateSched.ResumeLayout(false);
            this.panelDateSched.PerformLayout();
            this.panelPatName.ResumeLayout(false);
            this.panelPatName.PerformLayout();
            this.panelOperName.ResumeLayout(false);
            this.panelOperName.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDateSched;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelPatName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAppNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboAppointment;
        private System.Windows.Forms.Panel panelOperName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelDentName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelRoomNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel11;
        private Guna.UI2.WinForms.Guna2TextBox EndTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateSchedulePicker;
        private System.Windows.Forms.ComboBox StartTime;
        private Guna.UI2.WinForms.Guna2Button updateAppointmentB;
        private Guna.UI2.WinForms.Guna2TextBox tbOname;
        private Guna.UI2.WinForms.Guna2TextBox roomNo;
        private Guna.UI2.WinForms.Guna2TextBox doctorL;
        private System.Windows.Forms.Label tbPname;
        private System.Windows.Forms.Label label13;
    }
}