using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ClinicSystem.MainClinic;
using ClinicSystem.PatientForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClinicSystem.ClinicHistory
{
    public partial class ClinicForm : Form
    {
        private ClinicRepository db = new ClinicRepository();
        private List<Appointment> patientList;
        private DataTable dt = new DataTable();
        public ClinicForm(UserLoginForm.Staff staff)
        {
            InitializeComponent();
            patientList = db.getAppointments();

            past.Columns.Add("Appointment No", typeof(int));
            past.Columns.Add("Operation", typeof(string));
            past.Columns.Add("Doctor", typeof(string));
            past.Columns.Add("Start Appointment", typeof(string));
            past.Columns.Add("End Appointment", typeof(string));
            past.Columns.Add("Booking Date", typeof(string));
            pastGrid.DataSource = past;

            upcomming.Columns.Add("Appointment No", typeof(int));
            upcomming.Columns.Add("Operation", typeof(string));
            upcomming.Columns.Add("Doctor", typeof(string));
            upcomming.Columns.Add("Start Appointment", typeof(string));
            upcomming.Columns.Add("End Appointment", typeof(string));
            upcomming.Columns.Add("Booking Date", typeof(string));
            upcomingGrid.DataSource = upcomming;

            dt.Columns.Add("Patient ID", typeof(string));
            dt.Columns.Add("Patient Name", typeof(string));
            searchGrid.DataSource = dt;

            comboYear.Items.Add("All-time");
            for (int i = 2025; i <= DateTime.Now.Year; i++)
            {
                comboYear.Items.Add(i);
            }
            comboYear.SelectedIndex = 0;
            displayPatientGrid("");
          
        }
            
        private void displayPatientGrid(string text)
        {
            dt.Clear();
            if (comboYear.SelectedIndex == -1) return;
            string year = comboYear.SelectedItem.ToString(); ;
      

            HashSet<string> patientIds = new HashSet<string>();
            foreach (Appointment appointment in patientList)
            {
                string patientId = appointment.Patient.Patientid;
                string patientName = $"{appointment.Patient.Firstname} {appointment.Patient.Middlename} {appointment.Patient.Lastname}";

                if (patientIds.Contains(patientId))
                {
                    continue;
                }
                patientIds.Add(patientId);

                if (string.IsNullOrEmpty(text))
                {
                    if (year.Equals("All-time"))
                    {
                        dt.Rows.Add(patientId, patientName);
                    }
                    else if (year.Equals(patientId.Substring(1, 4)))
                    {
                        dt.Rows.Add(patientId, patientName);
                    }            
                }
                else if (
                   patientId.EndsWith(text) ||
                    appointment.Patient.Lastname.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                    appointment.Patient.Firstname.StartsWith(text, StringComparison.OrdinalIgnoreCase))
                {
                    if (year.Equals("All-time"))
                    {
                        dt.Rows.Add(patientId, patientName);
                    }
                    else if (year.Equals(patientId.Substring(1,4)))
                    {
                        dt.Rows.Add(patientId, patientName);
                    }
                   
                }
   
            }
            if (searchGrid.Rows.Count > 0)
            {
                string patientId = searchGrid.Rows[0].Cells["Patient ID"].Value.ToString();
                display(patientId);
            }
        }

        private void tbPatientId_TextChanged(object sender, EventArgs e)
        {
            string text = tbPatient.Text;

            displayPatientGrid(text);

        }
        DataTable past = new DataTable();
        DataTable upcomming = new DataTable();
        private void ClinicForm_Load(object sender, EventArgs e)
        {

            searchGrid.EnableHeadersVisualStyles = false;
            searchGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            searchGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            searchGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            searchGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            pastGrid.EnableHeadersVisualStyles = false;
            pastGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            pastGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            pastGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            pastGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            pastGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pastGrid.Columns[0].Width = 50;

            upcomingGrid.EnableHeadersVisualStyles = false;
            upcomingGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            upcomingGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            upcomingGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            upcomingGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            upcomingGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            upcomingGrid.Columns[0].Width = 50;
            searchGrid.Columns[0].Width = 100;
            searchGrid.Columns[1].Width = 200;
            
        }

        private void searchGrid_MouseClick(object sender, MouseEventArgs e)
        {

            var hit = searchGrid.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                DataGridViewRow row = searchGrid.Rows[hit.RowIndex];

                string patientId = searchGrid.Rows[row.Index].Cells["Patient ID"].Value.ToString();
                display(patientId);
            }
        }
        private void display(string patientId)
        {
            past.Clear();
            DateTime now = DateTime.Now;
            upcomming.Clear();
            foreach (Appointment a in patientList)
            {
                if (a.Patient.Patientid == patientId)
                {

                    pName.Text = a.Patient.Firstname + " " + a.Patient.Middlename + " " + a.Patient.Lastname;
                    pAge.Text = a.Patient.Age.ToString();
                    pGender.Text = a.Patient.Gender;
                    pNo.Text = a.Patient.ContactNumber;
                    pAddress.Text = a.Patient.Address;
                    pBday.Text = a.Patient.Birthdate.ToString("yyyy-MM-dd");
                    if (now > a.StartTime)
                    {
                        past.Rows.Add(
                            a.AppointmentDetailNo,
                            a.Operation.OperationCode + " | " + a.Operation.OperationName,
                            a.Doctor.DoctorID + " | " + a.Doctor.DoctorFirstName + "  " + a.Doctor.DoctorMiddleName + "  " + a.Doctor.DoctorLastName,
                            a.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt"),
                            a.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt"),
                            a.BookingDate.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    }
                    else
                    {
                        upcomming.Rows.Add(
                           a.AppointmentDetailNo,
                           a.Operation.OperationCode + " | " + a.Operation.OperationName,
                           a.Doctor.DoctorID + " | " + a.Doctor.DoctorFirstName + "  " + a.Doctor.DoctorMiddleName + "  " + a.Doctor.DoctorLastName,
                           a.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt"),
                           a.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt"),
                           a.BookingDate.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    }
                }

            }
        }

        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = tbPatient.Text;

            displayPatientGrid(text);
        }
    }
}
