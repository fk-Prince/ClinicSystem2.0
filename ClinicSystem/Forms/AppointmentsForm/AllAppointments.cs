using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;

namespace ClinicSystem.Appointments
{
    public partial class AllAppointments : Form
    {

        private List<Appointment> patientAppointments;
        private AppointmentRepository db = new AppointmentRepository();
        public AllAppointments()
        {
            InitializeComponent();
          
            patientAppointments = db.getAppointment();

            DateTime today = DateTime.Today;
            List<Appointment> filtered = patientAppointments
             .Where(pa => pa.StartTime.Date == today.Date)
             .ToList();
            displaySchedules(filtered, "TODAY");

        }

        private void displaySchedules(List<Appointment> patientAppointments, string comboText)
        {
            flowPanel.Controls.Clear();
            if (patientAppointments.Count > 0)
            {
                foreach (Appointment pa in patientAppointments)
                {
                    Guna2Panel panel = new Guna2Panel();
                    panel.Size = new Size(300, 340);
                    panel.FillColor = Color.FromArgb(111, 168, 166);
                    panel.Margin = new Padding(40, 10, 10, 10);
                    panel.Padding = new Padding(10, 10, 10, 10);
                    panel.BorderRadius = 20;
                    panel.BackColor = Color.Transparent;
                    //panel.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 50, 50));
                    Label label = createLabel("Appointment No", pa.AppointmentDetailNo.ToString(), 10, 15);
                    panel.Controls.Add(label);
                    string dr = $"{pa.Doctor.DoctorFirstName} {pa.Doctor.DoctorMiddleName} {pa.Doctor.DoctorLastName}";
                    label = createLabel("Doctor Name", dr, 10, 35);
                    panel.Controls.Add(label);

                    label = createLabel("Room No", pa.RoomNo.ToString(), 10, 55);
                    panel.Controls.Add(label);

                    label = createLabel("Operation Code", pa.Operation.OperationCode, 10, 75);
                    panel.Controls.Add(label);

                    label = createLabel("Operation Name", pa.Operation.OperationName, 10, 95);
                    panel.Controls.Add(label);

               
                    label = createLabel("Start-Time", pa.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 115);
                    panel.Controls.Add(label);


                    label = createLabel("End-Time", pa.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 135);
                    panel.Controls.Add(label);

                    label = createLabel("Status", pa.Status, 10, 155);
                    panel.Controls.Add(label);

                    label = createLabel("Booking Date", pa.BookingDate.ToString("yyyy-MM-dd hh:mm:ss tt"), 10, 175);
                    panel.Controls.Add(label);

                    Panel panel2 = new Panel();
                    panel2.BackColor = Color.Gray;
                    panel2.Size = new Size(270, 2);
                    panel2.Location = new Point(15, 215);
                    panel.Controls.Add(panel2);

                    label = createLabel("Patient ID", pa.Patient.Patientid.ToString(), 10, 225);
                    panel.Controls.Add(label);

                    string fullname = pa.Patient.Firstname + " " + pa.Patient.Middlename + " " + pa.Patient.Lastname;
                    label = createLabel("Name", fullname, 10, 245);
                    panel.Controls.Add(label);

                    label = createLabel("Age", pa.Patient.Age.ToString(), 10, 265);
                    panel.Controls.Add(label);

                    label = createLabel("Gender", pa.Patient.Gender, 10, 285);
                    panel.Controls.Add(label);

                    label = createLabel("Contact Number", pa.Patient.ContactNumber, 10, 305);
                    panel.Controls.Add(label);

                    flowPanel.Controls.Add(panel);
                }
            }
            else
            {            
                Label label = new Label();
                label.Text = $"CLINIC HAS NO APPOINTMENT {comboText}.";
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.ForeColor = Color.Black;
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                Panel panel = new Panel();
                panel.Size = new Size(flowPanel.Width, 500);
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

            foreach (Appointment pa in patientAppointments)
            {
                //if (pa.DateSchedule >= dateNow)
                //{
                filtered.Add(pa);
                //}
            }
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
            DateTime date = Convert.ToDateTime(datePickDate.Value.ToString("yyyy-MM-dd"));
            List<Appointment> filtered = patientAppointments
           .Where(pa => pa.StartTime == date)
           .ToList();
            displaySchedules(filtered, "THIS DATE");
        }
        private void SearchBar1_TextChanged(object sender, EventArgs e)
        {
            radioToday.Checked = false;
            weekRadio.Checked = false;
            monthRadio.Checked = false;
            allSchedule.Checked = false;
            selection.Checked = false;
            datePickDate.Visible = false;

            string text = SearchBar1.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                radioToday.Checked = true;
                List<Appointment> filtered = patientAppointments
                .Where(pa => pa.StartTime.Day == DateTime.Now.Day)
                .ToList();
                displaySchedules(filtered, "TODAY");
            } else
            {
                List<Appointment> filtered = patientAppointments
                .Where(pa => pa.Operation.OperationName.StartsWith(text,StringComparison.OrdinalIgnoreCase) || pa.Operation.OperationCode.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                             pa.Doctor.DoctorLastName.StartsWith(text, StringComparison.OrdinalIgnoreCase) || pa.Doctor.DoctorFirstName.StartsWith(text, StringComparison.OrdinalIgnoreCase) || pa.Doctor.DoctorID.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                             pa.AppointmentDetailNo.ToString().Equals(text, StringComparison.OrdinalIgnoreCase))
                .ToList();
                displaySchedules(filtered, "");
            }
        }

        private void AllAppointments_Shown(object sender, EventArgs e)
        {
            List<Appointment> filtered = patientAppointments
             .Where(pa => pa.StartTime.Date == DateTime.Today.Date)
             .ToList();
            displaySchedules(filtered, "TODAY");
        }
    }
}