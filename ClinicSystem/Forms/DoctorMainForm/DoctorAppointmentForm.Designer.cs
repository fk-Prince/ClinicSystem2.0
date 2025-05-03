namespace ClinicSystem.Main2
{
    partial class DoctorAppointmentForm
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
            this.monthRadio = new System.Windows.Forms.RadioButton();
            this.allSchedule = new System.Windows.Forms.RadioButton();
            this.selection = new System.Windows.Forms.RadioButton();
            this.weekRadio = new System.Windows.Forms.RadioButton();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.datePickDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.monthRadio);
            this.panel1.Controls.Add(this.allSchedule);
            this.panel1.Controls.Add(this.selection);
            this.panel1.Controls.Add(this.weekRadio);
            this.panel1.Controls.Add(this.radioToday);
            this.panel1.Controls.Add(this.datePickDate);
            this.panel1.Location = new System.Drawing.Point(-1, 123);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 46);
            this.panel1.MinimumSize = new System.Drawing.Size(1090, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 46);
            this.panel1.TabIndex = 10088;
            // 
            // monthRadio
            // 
            this.monthRadio.AutoSize = true;
            this.monthRadio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthRadio.Location = new System.Drawing.Point(187, 12);
            this.monthRadio.Name = "monthRadio";
            this.monthRadio.Size = new System.Drawing.Size(70, 24);
            this.monthRadio.TabIndex = 16;
            this.monthRadio.Text = "Month";
            this.monthRadio.UseVisualStyleBackColor = true;
            this.monthRadio.CheckedChanged += new System.EventHandler(this.monthRadio_CheckedChanged);
            // 
            // allSchedule
            // 
            this.allSchedule.AutoSize = true;
            this.allSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allSchedule.Location = new System.Drawing.Point(276, 11);
            this.allSchedule.Name = "allSchedule";
            this.allSchedule.Size = new System.Drawing.Size(137, 24);
            this.allSchedule.TabIndex = 15;
            this.allSchedule.Text = "All Appointment";
            this.allSchedule.UseVisualStyleBackColor = true;
            this.allSchedule.CheckedChanged += new System.EventHandler(this.allSchedule_CheckedChanged);
            // 
            // selection
            // 
            this.selection.AutoSize = true;
            this.selection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selection.Location = new System.Drawing.Point(437, 11);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(101, 24);
            this.selection.TabIndex = 14;
            this.selection.Text = "Pick a Date";
            this.selection.UseVisualStyleBackColor = true;
            this.selection.CheckedChanged += new System.EventHandler(this.selection_CheckedChanged);
            // 
            // weekRadio
            // 
            this.weekRadio.AutoSize = true;
            this.weekRadio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekRadio.Location = new System.Drawing.Point(107, 12);
            this.weekRadio.Name = "weekRadio";
            this.weekRadio.Size = new System.Drawing.Size(63, 24);
            this.weekRadio.TabIndex = 13;
            this.weekRadio.Text = "Week";
            this.weekRadio.UseVisualStyleBackColor = true;
            this.weekRadio.CheckedChanged += new System.EventHandler(this.weekRadio_CheckedChanged);
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.Checked = true;
            this.radioToday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioToday.Location = new System.Drawing.Point(26, 12);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(67, 24);
            this.radioToday.TabIndex = 12;
            this.radioToday.TabStop = true;
            this.radioToday.Text = "Today";
            this.radioToday.UseVisualStyleBackColor = true;
            this.radioToday.CheckedChanged += new System.EventHandler(this.radioToday_CheckedChanged);
            // 
            // datePickDate
            // 
            this.datePickDate.BorderRadius = 5;
            this.datePickDate.Checked = true;
            this.datePickDate.FillColor = System.Drawing.Color.PaleGreen;
            this.datePickDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datePickDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.datePickDate.Location = new System.Drawing.Point(559, 3);
            this.datePickDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.datePickDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.datePickDate.Name = "datePickDate";
            this.datePickDate.Size = new System.Drawing.Size(249, 36);
            this.datePickDate.TabIndex = 6;
            this.datePickDate.Value = new System.DateTime(2025, 4, 25, 11, 40, 22, 388);
            this.datePickDate.Visible = false;
            this.datePickDate.ValueChanged += new System.EventHandler(this.datePickDate_ValueChanged_1);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.panel9.Controls.Add(this.label7);
            this.panel9.Location = new System.Drawing.Point(-1, 0);
            this.panel9.MaximumSize = new System.Drawing.Size(1920, 129);
            this.panel9.MinimumSize = new System.Drawing.Size(1090, 129);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1090, 129);
            this.panel9.TabIndex = 10089;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(346, 27);
            this.label7.MaximumSize = new System.Drawing.Size(1920, 37);
            this.label7.MinimumSize = new System.Drawing.Size(337, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(337, 37);
            this.label7.TabIndex = 10059;
            this.label7.Text = "Doctor Appointments";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.flowPanel.Location = new System.Drawing.Point(0, 168);
            this.flowPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowPanel.MinimumSize = new System.Drawing.Size(1083, 550);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1083, 550);
            this.flowPanel.TabIndex = 10087;
            // 
            // DoctorAppointmentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(1079, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.flowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1079, 718);
            this.Name = "DoctorAppointmentForm";
            this.Text = "DoctorScheduleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker datePickDate;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.RadioButton monthRadio;
        private System.Windows.Forms.RadioButton allSchedule;
        private System.Windows.Forms.RadioButton selection;
        private System.Windows.Forms.RadioButton weekRadio;
        private System.Windows.Forms.RadioButton radioToday;
    }
}