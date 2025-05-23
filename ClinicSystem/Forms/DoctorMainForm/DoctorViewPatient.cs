using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.DoctorClinic;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using DoctorClinic;
using Google.Protobuf.WellKnownTypes;

namespace ClinicSystem
{
    public partial class DoctorViewPatient : Form
    {

        private DoctorRepository doctorRepository = new DoctorRepository();   

        private List<Appointment> patientAppointments;
        private DataTable dt;
        private Doctor dr;
        private Appointment selectedPatient = null;
        private int limitCharacter = 200;
        private List<Appointment> filtered = new List<Appointment>();
        private Appointment selectedAppointment;
        public DoctorViewPatient(Doctor dr)
        {
            this.dr = dr;
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Patient ID", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Birth-Date", typeof(DateTime));
            patientAppointments = doctorRepository.getPatientByDoctor(dr.DoctorID);
            addRows(patientAppointments);
            dataGrid.DataSource = dt;
            dataGrid.Columns["Birth-Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

            datePickerSchedule.Value = DateTimePicker.MinimumDateTime;
            datePickerBDay.Value = DateTimePicker.MinimumDateTime;
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGrid.Rows[e.RowIndex];

                string patientID = row.Cells["PatientID"].Value.ToString();

                foreach (Appointment pa in patientAppointments)
                {
                    if (pa.Patient.Patientid.Equals(patientID))
                    {
                        selectedPatient = pa;
                        break;
                    }
                }
                //if (lastSelectedRow != null)
                //{
                //    lastSelectedRow.DefaultCellStyle.BackColor = Color.White;
                //    lastSelectedRow.DefaultCellStyle.ForeColor = Color.Black;
                //}

                //row.DefaultCellStyle.ForeColor = Color.White; 
                //row.DefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
                //lastSelectedRow = row;

                if (selectedPatient != null)
                {
                    tabControl.SelectedIndex = 1;
                    //clear();
                    patientDetails(selectedPatient);
                }
            }
        }

        private void addRows(List<Appointment> patientAppointments)
        {
            dt.Clear();
            HashSet<string> seen = new HashSet<string>();
            foreach (Appointment pa in patientAppointments)

                if (seen.Add(pa.Patient.Patientid.ToString()))
                {
                    dt.Rows.Add(
                        pa.Patient.Patientid,
                        pa.Patient.Firstname,
                        pa.Patient.Middlename,
                        pa.Patient.Lastname,
                        pa.Patient.Gender,
                        pa.Patient.Age,
                        Convert.ToDateTime(pa.Patient.Birthdate.ToString("yyyy-MM-dd"))
                    );
                }
        }





        private void clear()
        {
            appointmentDetailNoCombo.Items.Clear();
            operationName.Text = "";
            tbPatientId.Text = "";
            roomNo.Text = "";
            tbFullName.Text = "";
            tbAddress.Text = "";
            tbAge.Text = "";
            tbGender.Text = "";
            tbContact.Text = "";
            datePickerSchedule.Value = DateTimePicker.MinimumDateTime;
            datePickerBDay.Value = DateTimePicker.MinimumDateTime;
            tbStartTime.Text = "";
            tbEndTime.Text = "";
            status.Text = "";
            tbDiagnosis.Text = "";
            filtered.Clear();
            selectedPatient = null;
        }

        private void patientDetails(Appointment pa)
        {
            tbPatientId.Text = pa.Patient.Patientid.ToString();
            tbFullName.Text = pa.Patient.Firstname + "  " + pa.Patient.Middlename + "  " + pa.Patient.Lastname;
            tbAddress.Text = pa.Patient.Address;
            tbAge.Text = pa.Patient.Age.ToString();
            tbGender.Text = pa.Patient.Gender;
            tbContact.Text = pa.Patient.ContactNumber;
            datePickerBDay.Value = pa.Patient.Birthdate;
            foreach (Appointment pas in patientAppointments)
            {
                if (pa.Patient.Patientid == pas.Patient.Patientid)
                {
                    filtered.Add(pas);
                    appointmentDetailNoCombo.Items.Add(pas.AppointmentDetailNo);
                }
            }
        }

        private void selectedAppointmentNo(object sender, EventArgs e)
        {
            if (appointmentDetailNoCombo.SelectedIndex == -1) return;

            int appointmentDetailNo = int.Parse(appointmentDetailNoCombo.SelectedItem.ToString());
            foreach (Appointment app in filtered)
            {
                if (app.AppointmentDetailNo == appointmentDetailNo)
                {
                    operationName.Text = app.Operation.OperationName;
                    datePickerSchedule.Value = app.StartTime;
                    roomNo.Text = app.RoomNo.ToString();
                    tbDiagnosis.Text = app.Diagnosis;
                    tbStartTime.Text = app.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                    tbEndTime.Text = app.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                    status.Text = app.Status;
                    selectedAppointment = app;
                    if (app.Status.Equals("Discharged", StringComparison.OrdinalIgnoreCase) || app.Status.Equals("Absent",StringComparison.OrdinalIgnoreCase))
                    {
                        guna2Button4.Visible = false;
                        save.Visible = false;
                    } else
                    {
                        guna2Button4.Visible = true;
                        save.Visible = true;
                    }
                    break;
                }
            }
        }

        private void searchPatient_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchPatient.Text))
            {
                addRows(patientAppointments);
            }
            else
            {
                string text = searchPatient.Text;
                List<Appointment> filtered = new List<Appointment>();
              
                filtered = patientAppointments.Where(pa =>
                pa.Patient.Firstname.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                pa.Patient.Middlename.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                pa.Patient.Lastname.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                pa.Patient.Patientid.StartsWith(text, StringComparison.OrdinalIgnoreCase) ||
                pa.Patient.Patientid.EndsWith(text, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                
                addRows(filtered);
            }
        }
        private bool isPatientList = true;
        private void TabChanged(object sender, EventArgs e)
        {
            if (!isPatientList)
            {
                clear();
                isPatientList = !isPatientList;
            }
            else
            {
                isPatientList = !isPatientList;
            }
        }

        private void tbDiagnosis_TextChanged(object sender, EventArgs e)
        {
            string diagnosis = tbDiagnosis.Text.Trim(); 

            limitCheck(diagnosis, limitD);
        }

        public void limitCheck(string text,Label limit)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int total = limitCharacter - text.Length;
                if (total == 0)
                {
                    limit.Text = $"You reached limit 200 characters.";
                }
                else
                {
                    limit.Text = $"Up to {total.ToString()} characters.";
                }
            }
            else
            {
                limit.Text = $"Up to 200 characters.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (appointmentDetailNoCombo.SelectedIndex == -1 || selectedPatient == null)
            {
                MessagePromp.MainShowMessage(this, "There is nothing to print.", MessageBoxIcon.Error);
                return;
            }
            List<Appointment> temp = new List<Appointment>();
            temp.Add(selectedAppointment);
            PrintDoctorReceipt diagnos = new PrintDoctorReceipt(dr, temp,"");
            diagnos.print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Appointment> temp = new List<Appointment>();
            if (selectedPatient == null)
            {
                MessagePromp.MainShowMessageBig(this, "Nothing to print. Select a patient.", MessageBoxIcon.Error);
                return;
            }
            foreach (Appointment pa in patientAppointments)
            {
                if (pa.Patient.Patientid == selectedPatient.Patient.Patientid)
                {
                    temp.Add(pa);
                }
            }
            PrintDoctorReceipt diagnos = new PrintDoctorReceipt(dr, temp, "");
            diagnos.print();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (appointmentDetailNoCombo.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessageBig(this, "Please Select an Appointment ID.", MessageBoxIcon.Error);
                return;
            }

            if (selectedAppointment.Diagnosis.Trim() == tbDiagnosis.Text.Trim() && selectedAppointment.Prescription.Trim() == prescription.Text.Trim())
            {
                return;
            }

            Appointment updatedSchedule = new Appointment(
                selectedAppointment.Patient,
                selectedAppointment.Operation,
                selectedAppointment.StartTime,
                selectedAppointment.EndTime,
                selectedAppointment.SubTotal,
                selectedAppointment.RoomNo,
                selectedAppointment.AppointmentDetailNo,
                selectedAppointment.Total,
                selectedAppointment.Discounttype,
                tbDiagnosis.Text.Trim(),
                selectedAppointment.BookingDate,
                selectedAppointment.Status,
                prescription.Text.Trim());

            bool success = doctorRepository.setDiagnosis(updatedSchedule);
            if (success)
            {
                for (int i = 0; i < filtered.Count; i++)
                {
                    if (filtered[i].AppointmentDetailNo == selectedAppointment.AppointmentDetailNo)
                    {
                        filtered[i] = updatedSchedule;
                       
                        selectedAppointment = updatedSchedule;
                        selectedPatient = updatedSchedule;
                        int index = patientAppointments.FindIndex(pa => pa.AppointmentDetailNo == selectedAppointment.AppointmentDetailNo);
                        if (index != -1)
                        {
                            patientAppointments[index] = updatedSchedule;
                        }
                        break;
                    }
                }

                MessagePromp.MainShowMessage(this, "Appointment Updated", MessageBoxIcon.Information);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void DoctorViewPatient_Load(object sender, EventArgs e)
        {
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {

            var hit = dataGrid.HitTest(e.X, e.Y); 

            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrid.Rows[hit.RowIndex];

                if (row.Cells["Patient ID"]?.Value != null)
                {
                    string patientID = row.Cells["Patient ID"].Value.ToString();

                    foreach (Appointment pa in patientAppointments)
                    {
                        if (pa.Patient.Patientid.Equals(patientID))
                        {
                            selectedPatient = pa;
                            break;
                        }
                    }
                    if (selectedPatient != null)
                    {
                        tabControl.SelectedIndex = 1;
                        //clear();
                        patientDetails(selectedPatient);
                    }


                }

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (appointmentDetailNoCombo.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessage(this, "Please Select an Appointment ID.", MessageBoxIcon.Error);
                return;
            }

            int appointmentDetailNo = int.Parse(appointmentDetailNoCombo.SelectedItem.ToString());

            if (doctorRepository.setPatientDischarged(appointmentDetailNo))
            {
                List<Appointment> tmp = new List<Appointment>();
                tmp.Add(selectedAppointment);
                PrintDoctorReceipt pr = new PrintDoctorReceipt(dr, tmp, "Discharged");

                MessagePromp.MainShowMessage(this, "Succefully Discharged .", MessageBoxIcon.Information);
                guna2Button4.Visible = false;
                save.Visible = false;
                status.Text = "Discharged";
              
                patientAppointments = doctorRepository.getPatientByDoctor(dr.DoctorID);
                foreach (Appointment pas in patientAppointments)
                {
                    if (selectedAppointment.Patient.Patientid == pas.Patient.Patientid)
                    {
                        filtered.Add(pas);
                    }
                }
            }
        }

        private void prescription_TextChanged(object sender, EventArgs e)
        {
            string p = prescription.Text.Trim();

            limitCheck(p, limitP);
        }
    }
}
