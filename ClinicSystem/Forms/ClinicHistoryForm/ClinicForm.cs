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
using ClinicSystem.Appointments;
using ClinicSystem.MainClinic;
using ClinicSystem.PatientForm;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClinicSystem.ClinicHistory
{
    public partial class ClinicForm : Form
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private List<Appointment> patientList;
        private DataTable dt = new DataTable();
        private DataTable ap = new DataTable();

        public ClinicForm(UserLoginForm.Staff staff)
        {
            InitializeComponent();
            patientList = appointmentRepository.getAppointment();

            date1.Value = new DateTime(2025, 1, 1);
            date2.Value = new DateTime(2100, 1, 1);

            ap.Columns.Add("Appointment No", typeof(int));
            ap.Columns.Add("Operation", typeof(string));
            ap.Columns.Add("Doctor", typeof(string));
            ap.Columns.Add("Start Appointment", typeof(string));
            ap.Columns.Add("End Appointment", typeof(string));
            ap.Columns.Add("Booking Date", typeof(string));
            ap.Columns.Add("Status", typeof(string));
            dataGrid.DataSource = ap;

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
        string patientId;
        private void displayPatientGrid(string text)
        {
            dt.Clear();
            if (comboYear.SelectedIndex == -1) return;
            string year = comboYear.SelectedItem.ToString();

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
                    else if (year.Equals(patientId.Substring(1, 4)))
                    {
                        dt.Rows.Add(patientId, patientName);
                    }
                }
            }

            if (searchGrid.Rows.Count > 0)
            {  
                patientId = searchGrid.Rows[0].Cells["Patient ID"].Value.ToString();
                string type = "";
                if (radioButton1.Checked) type = "Both";
                if (radioButton2.Checked) type = "Upcoming";
                if (radioButton3.Checked) type = "Past";
                display(patientId, type);
            }
        }

        private void tbPatientId_TextChanged(object sender, EventArgs e)
        {
            string text = tbPatient.Text;
            displayPatientGrid(text);
        }

        private void ClinicForm_Load(object sender, EventArgs e)
        {
            searchGrid.EnableHeadersVisualStyles = false;
            searchGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            searchGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            searchGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            searchGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
           
            dataGrid.RowTemplate.Height = 70;

            dataGrid.Columns[0].Width = 50;
            searchGrid.Columns[0].Width = 100;
            searchGrid.Columns[1].Width = 200;
        }

        private void searchGrid_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = searchGrid.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                DataGridViewRow row = searchGrid.Rows[hit.RowIndex];
                patientId = searchGrid.Rows[row.Index].Cells["Patient ID"].Value.ToString();
                
                string type = "";
                if (radioButton1.Checked) type = "Both";
                if (radioButton2.Checked) type = "Upcoming";
                if (radioButton3.Checked) type = "Past";
                display(patientId, type);
            }
        }

        private void display(string patientId, string appointmentType)
        {
            ap.Clear();
         

            bill.Text = "₱ " + patientList.Where(e => patientId == e.Patient.Patientid).ToList().Sum(p => p.Total).ToString("F2");

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

                    if (
                        (appointmentType == "Upcoming" && a.EndTime >= DateTime.Now) ||
                        (appointmentType == "Past" && a.EndTime <= DateTime.Now) ||
                        (appointmentType == "Both" && (a.StartTime.Date > date1.Value.Date && a.EndTime.Date < date2.Value.Date))
                        )
                    {
                        ap.Rows.Add(
                             a.AppointmentDetailNo,
                             a.Operation.OperationCode + Environment.NewLine + a.Operation.OperationName,
                             a.Doctor.DoctorID + Environment.NewLine + a.Doctor.DoctorFirstName + "  " + a.Doctor.DoctorMiddleName + "  " + a.Doctor.DoctorLastName,
                             a.StartTime.ToString("yyyy-MM-dd") + Environment.NewLine + a.StartTime.ToString("hh:mm:ss tt"),
                             a.EndTime.ToString("yyyy-MM-dd") + Environment.NewLine + a.EndTime.ToString("hh:mm:ss tt"),
                             a.BookingDate.ToString("yyyy-MM-dd") + Environment.NewLine + a.BookingDate.ToString("hh:mm:ss tt"),
                             a.Status
                        );
                    }
              
                }
            }
        }


        private void comboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = tbPatient.Text;
            displayPatientGrid(text);
        }

        private void ClinicForm_SizeChanged(object sender, EventArgs e)
        {
            upP.Location = new Point(upP.Location.X, p1.Bottom + 30);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked && date1.Value.Date < date2.Value.Date)
            {
                date1.Visible = radioButton1.Checked;
                date2.Visible = radioButton1.Checked;
                arrow.Visible = radioButton1.Checked;
                label11.Visible = radioButton1.Checked;
                label9.Visible = radioButton1.Checked;
                string text = tbPatient.Text;
                display(patientId, "Both");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked && date1.Value.Date < date2.Value.Date)
            {
                date1.Visible = false;
                date2.Visible = false;
                arrow.Visible = false;
                label11.Visible = false;
                label9.Visible = false;
                display(patientId, "Upcoming");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked && date1.Value.Date < date2.Value.Date)
            {
                date1.Visible = false;
                date2.Visible = false;
                arrow.Visible = false;
                label11.Visible = false;
                label9.Visible = false;
                display(patientId, "Past");
            }
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            if (date1.Value.Date < date2.Value.Date)
            {
                string type = "";
                if (radioButton1.Checked) type = "Both";
                if (radioButton2.Checked) type = "Upcoming";
                if (radioButton3.Checked) type = "Past";
                string text = tbPatient.Text;
                display(patientId, type);
            }
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            if (date1.Value.Date < date2.Value.Date)
            {
                string type = "";
                if (radioButton1.Checked) type = "Both";
                if (radioButton2.Checked) type = "Upcoming";
                if (radioButton3.Checked) type = "Past";
                string text = tbPatient.Text;
                display(patientId, type);
            }
        }

        private void searchGrid_Sorted(object sender, EventArgs e)
        {
            if (searchGrid.Rows.Count > 0)
            {
                string text = tbPatient.Text;
                displayPatientGrid(text);
                searchGrid.ClearSelection();
                searchGrid.Rows[0].Selected = true;
                searchGrid.CurrentCell = searchGrid.Rows[0].Cells[0];
            }
        }
    }
}
