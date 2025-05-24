using System;
using ClinicSystem.UserLoginForm;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Collections.Generic;
using ClinicSystem.PatientForm;
using ClinicSystem.Appointments;
using System.Linq;
using ClinicSystem.DoctorClinic;

namespace ClinicSystem
{
    public partial class ViewPatientForm : Form
    {
        private DataTable dt;
        private List<Appointment> appointmentList;

        private AppointmentRepository db = new AppointmentRepository();
        private List<Appointment> filter = new List<Appointment>();
        public ViewPatientForm(Staff staff)
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Patient ID", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Middle Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Contact Number", typeof(string));


            dataGrid.AutoGenerateColumns = true;
            dataGrid.DataSource = dt;

            appointmentList = db.getAppointment();
            displayTable(appointmentList);
          
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGrid.RowsDefaultCellStyle.BackColor = Color.White;
            dataGrid.RowsDefaultCellStyle.SelectionBackColor = dataGrid.RowsDefaultCellStyle.BackColor;
            dataGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = dataGrid.AlternatingRowsDefaultCellStyle.BackColor;

        }



        public void displayTable(List<Appointment> appList)
        {
            dt.Clear();
            HashSet<string> seen = new HashSet<string>();

            foreach (Appointment pa in appList)
            {
                if (seen.Add(pa.Patient.Patientid.ToString()))
                {
                    dt.Rows.Add(
                        pa.Patient.Patientid,
                        pa.Patient.Firstname,
                        pa.Patient.Middlename,
                        pa.Patient.Lastname,
                        pa.Patient.Age,
                        pa.Patient.Gender,
                        pa.Patient.ContactNumber
                    );
                }
            }

       
        }

       
        private void ViewPatientForm_Load(object sender, EventArgs e)
        {

            SearchBar1.Focus();
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void SearchBar1_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchBar1.Text.Trim().ToLower().Replace("'", "''");

            if (dt == null || dt.Rows.Count == 0)
                return;

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format(
                "[Patient ID] LIKE '%{0}%' OR " +
                "[First Name] LIKE '{0}%' OR " +
                "[Middle Name] LIKE '{0}%' OR " +
                "[Last Name] LIKE '{0}%' ",
                keyword
            );
        }

        private void dataGrid_CellContentClick(object sender, MouseEventArgs e)
        {
            var hit = dataGrid.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrid.Rows[hit.RowIndex];

                if (row.Cells["Patient ID"]?.Value != null)
                {
                    string patientIdStr = row.Cells["Patient ID"].Value.ToString();

                    Appointment selected = appointmentList
                    .FirstOrDefault(a =>
                        a.Patient.Patientid.ToString().Equals(patientIdStr)
                    );


                    tbPatId.Text = selected.Patient.Patientid.ToString();
                    tbfullName.Text = $"{selected.Patient.Firstname} {selected.Patient.Middlename} {selected.Patient.Lastname}";
                    tbAge.Text = selected.Patient.Age.ToString();
                    tbGender.Text = selected.Patient.Gender;
                    tbAddress.Text = selected.Patient.Address;
                    datepickBirthDay.Value = selected.Patient.Birthdate;
                    tbContactNumber.Text = selected.Patient.ContactNumber;
                    guna2TextBox1.Text = selected.Prescription;
                    filter.Clear();
                    foreach (Appointment pas in appointmentList)
                    {
                        if (selected.Patient.Patientid == pas.Patient.Patientid)
                        {
                            filter.Add(pas);
                        }
                    }

                    if (filter != null && filter.Count > 0)
                    {
                       
                        foreach (Appointment f in filter)
                        {
                            comboAppNo.Items.Add(f.AppointmentDetailNo);                      
                        }
                        tbBill.Text = "₱ " + filter.Sum(x => x.Total).ToString("F2");
                    } 
                    tabPagePatientDetails.SelectedTab = tabPatientDetails;
                }

            }
        }

     
        


        private void clear()
        {
            tbPatId.Text = "";
            tbfullName.Text = "";
            tbAddress.Text = "";
            tbAge.Text = "";
            tbGender.Text = "";
            tbAddress.Text = "";
            tbContactNumber.Text = "";
            datepickBirthDay.Value = DateTime.Now;
            tbBill.Text = "";
            tbDoctor.Text = "";
            tbOperation.Text = "";
            tbDoctorDiagnosis.Text = "";
            comboAppNo.Items.Clear();
            filter.Clear();
        }

        private void comboAppNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAppNo.SelectedIndex == -1) return;

            int appointmentDetailNo = int.Parse(comboAppNo.SelectedItem.ToString());
            foreach (Appointment appointment in filter)
            {
                if (appointment.AppointmentDetailNo == appointmentDetailNo)
                {
                    string dr = $"{appointment.Doctor.DoctorID}  | {appointment.Doctor.DoctorLastName}, {appointment.Doctor.DoctorFirstName}  {appointment.Doctor.DoctorMiddleName}";
                    tbDoctor.Text = dr;
                    tbOperation.Text = appointment.Operation.OperationCode + "  |  "+appointment.Operation.OperationName;
                    tbDoctorDiagnosis.Text = appointment.Diagnosis;
                    cost.Text = "₱ " + appointment.Total.ToString("F2");
                    start.Text = appointment.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                    end.Text = appointment.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                    Status.Text = appointment.Status;
                    break;
                }
            }
        }

        bool isPatientList = true;
        private void tabPagePatientDetails_TabIndexChanged(object sender, EventArgs e)
        {
            if (!isPatientList)
            {
                clear();
                isPatientList = !isPatientList;
            } else
            {
                isPatientList = !isPatientList;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
