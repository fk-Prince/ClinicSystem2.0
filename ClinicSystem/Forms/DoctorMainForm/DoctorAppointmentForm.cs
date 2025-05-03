using System;
using System.Collections.Generic;

using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using Guna.UI2.WinForms;


namespace ClinicSystem.Main2
{
    public partial class DoctorAppointmentForm : Form
    {
        
        private List<Appointment> patientAppointments;
        private AppointmentRepository db = new AppointmentRepository();
        private Doctor dr;

        public DoctorAppointmentForm(Doctor dr)
        {
            this.dr = dr;
            InitializeComponent();
            patientAppointments = db.getAppointmentsbyDoctor(dr);
            DateTime today = DateTime.Today;
            List<Appointment> filtered = patientAppointments
             .Where(pa => pa.StartTime.Date == today.Date)
             .ToList();
            displaySchedules(filtered, "TODAY");
        }

        private void displaySchedules(List<Appointment> filtered, string type)
        {


            flowPanel.Controls.Clear();
            if (filtered.Count > 0)
            {
                foreach (Appointment pa in patientAppointments)
                {
                    Guna2Panel panel = new Guna2Panel();
                    panel.Size = new Size(300, 330);
                    panel.FillColor = Color.FromArgb(111, 168, 166);
                    panel.Margin = new Padding(40, 10, 10, 10);
                    panel.Padding = new Padding(10, 10, 10, 10);
                    panel.BorderRadius = 20;
                    panel.BackColor = Color.Transparent;

                    Label label = createLabel("Appointment No", pa.AppointmentDetailNo.ToString(), 10, 15);
                    panel.Controls.Add(label);


                    label = createLabel("Room No", pa.RoomNo.ToString(), 10, 35);
                    panel.Controls.Add(label);

                    label = createLabel("Operation Code", pa.Operation.OperationCode, 10, 55);
                    panel.Controls.Add(label);

                    label = createLabel("Operation Name", pa.Operation.OperationName, 10, 75);
                    panel.Controls.Add(label);


                    label = createLabel("Start-Time", pa.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 95);
                    panel.Controls.Add(label);


                    label = createLabel("End-Time", pa.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 115);
                    panel.Controls.Add(label);


                    label = createLabel("Status", pa.Status, 10, 135);
                    panel.Controls.Add(label);

                    label = createLabel("Booking Date", pa.BookingDate.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 155);
                    panel.Controls.Add(label);

                    Panel panel2 = new Panel();
                    panel2.BackColor = Color.Gray;
                    panel2.Size = new Size(270, 2);
                    panel2.Location = new Point(15, 195);
                    panel.Controls.Add(panel2);

                    label = createLabel("Patient ID", pa.Patient.Patientid.ToString(), 10, 215);
                    panel.Controls.Add(label);

                    string fullname = pa.Patient.Firstname + " " + pa.Patient.Middlename + " " + pa.Patient.Lastname;
                    label = createLabel("Name", fullname, 10, 235);
                    panel.Controls.Add(label);

                    label = createLabel("Age", pa.Patient.Age.ToString(), 10, 255);
                    panel.Controls.Add(label);

                    label = createLabel("Gender", pa.Patient.Gender, 10, 275);
                    panel.Controls.Add(label);

                    label = createLabel("Contact Number", pa.Patient.ContactNumber, 10, 295);
                    panel.Controls.Add(label);

                    flowPanel.Controls.Add(panel);
                }
            }
            else
            {

                Label label = new Label();
                label.Text = $"YOU HAS NO APPOINTMENT {type}.";
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new Point(250, 100);
                Panel panel = new Panel();
                panel.Size = new Size(900, 400);
                panel.Controls.Add(label);
                flowPanel.Controls.Add(panel);
            }
        }

        public Label createLabel(string title, string value, int x, int y)
        {
            Label label = new Label();
            label.Text = $"{title}:   {value}";
            label.MaximumSize = new Size(280, 30);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            return label;
        }

        // TODAY APPOINTMENT
        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
            radioTodayChecked();
        }

        private void radioTodayChecked()
        {
            DateTime today = DateTime.Today;
           
            List<Appointment> filtered = patientAppointments
              .Where(pa => pa.StartTime.Date == today.Date)
              .ToList();
            displaySchedules(filtered, "TODAY");
        }

        // WEEK APPOINTMENT
        private void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioWeekChecked();
        }
        
        private void radioWeekChecked()
        {
            DateTime week = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
           
            List<Appointment> filtered = patientAppointments
            .Where(pa => week <= pa.StartTime && pa.StartTime < week.AddDays(7))
            .ToList();

            displaySchedules(filtered, "THIS WEEK");
        }


        //MONTH APPOINTMENT
        private void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            radioMonthChecked();
        }
        
        private void radioMonthChecked()
        {
            DateTime month = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime start = new DateTime(month.Year, month.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);

            
            List<Appointment> filtered = patientAppointments
             .Where(pa => pa.StartTime >= start && pa.StartTime <= end)
             .ToList();

            displaySchedules(filtered, "THIS MONTH");
        }

        //ALL APPOINTMENT
        private void allSchedule_CheckedChanged(object sender, EventArgs e)
        {
            radioAllChecked();
        }
      
        private void radioAllChecked()
        {
            DateTime dateNow = DateTime.Now;
            List<Appointment> filtered = new List<Appointment>();

            filtered = patientAppointments;
            displaySchedules(filtered, "");
        }

        // APPOINTMENT SELECTION
        private void selection_CheckedChanged(object sender, EventArgs e)
        {
            if (selection.Checked)
            {
                datePickDate.Visible = true;
                pickDate();
            }
            else
            {
                datePickDate.Visible = false;
            }
        }
        private void datePickDate_ValueChanged_1(object sender, EventArgs e)
        {
            pickDate();
        }
        public void pickDate()
        {
            DateTime date = datePickDate.Value.Date;

            List<Appointment> filtered = patientAppointments
                .Where(pa => pa.StartTime.Date == date) 
                .ToList();
            displaySchedules(filtered, "THIS DATE");
        }
        private void label5_Click(object sender, EventArgs e)
        {
            selection.Checked = !selection.Checked;
            if (selection.Checked)
            {
                datePickDate.Visible = true;
                pickDate();
            }
            else
            {
                datePickDate.Visible = false;
            }
        }
    }
}
