using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;

namespace ClinicSystem.Appointments
{
    public partial class RescheduleForm : Form
    {
        private List<Appointment> activeAppointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private Appointment selectedAppointment;
        public RescheduleForm()
        {
            InitializeComponent();
            activeAppointments = appointmentRepository.getReAppointment();

            DateTime currentDate = DateTime.Now;
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Appointment appointment in activeAppointments)
            {
                comboAppointment.Items.Add(appointment.AppointmentDetailNo + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + " " + appointment.Patient.Middlename);
                auto.Add(appointment.AppointmentDetailNo + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  ");
                auto.Add(appointment.Patient.Patientid + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  " + " | " + appointment.AppointmentDetailNo);
                auto.Add(appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  | " + appointment.Patient.Patientid + " | " + appointment.AppointmentDetailNo);
            }
            comboAppointment.AutoCompleteCustomSource = auto;
            dateSchedulePicker.Value = DateTime.Now;
        }
        private void comboAppointment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (selectedAppointment != null)
                {
                    display(selectedAppointment);
                }
                else
                {
                    clear();
                }
            }
        }
        private void comboAppointment_TextChanged(object sender, EventArgs e)
        {
            string id = comboAppointment.Text;
            if (string.IsNullOrWhiteSpace(id)) return;

            string[] ids = id.Split('|');


            // for app id
            selectedAppointment = activeAppointments.FirstOrDefault(p =>
                p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(0)?.Trim(), StringComparison.OrdinalIgnoreCase));

            // for patientid
            if (selectedAppointment == null)
            {
                selectedAppointment = activeAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            //full name
            if (selectedAppointment == null)
            {
                selectedAppointment = activeAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            //for general
            if (selectedAppointment == null)
            {
                selectedAppointment = activeAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(0)?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                     p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase)
                );
            }

        }

        private void clear()
        {
            StartTime.Enabled = false;
            doctorL.Text = "";
            tbPname.Text = "";
            tbOname.Text = "";
            roomNo.Text = "";
            dateSchedulePicker.Value = DateTime.Now;
            StartTime.SelectedIndex = -1;
            EndTime.Text = "";
        }

        private void display(Appointment selectedAppointment)
        {
            comboAppointment.Text = selectedAppointment.AppointmentDetailNo.ToString();
            string fullname = $"{selectedAppointment.Patient.Firstname}  " +
                                 $"{selectedAppointment.Patient.Middlename}  " +
                                 $"{selectedAppointment.Patient.Lastname}";
            tbPname.Text = fullname;
            tbOname.Text = selectedAppointment.Operation.OperationName;


            string dfullname = $"{selectedAppointment.Doctor.DoctorFirstName} " +
                               $"{selectedAppointment.Doctor.DoctorMiddleName}  " +
                               $"{selectedAppointment.Doctor.DoctorLastName}";
            doctorL.Text = dfullname;
            roomNo.Text = selectedAppointment.RoomNo.ToString();
            StartTime.Enabled = true;
            dateSchedulePicker.Value = selectedAppointment.StartTime;
            StartTime.SelectedItem = selectedAppointment.StartTime.ToString("hh:mm:ss tt");
            EndTime.Text = selectedAppointment.EndTime.ToString("hh:mm:ss tt");
            StartTime.Enabled = true;
        }
        private void comboAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAppointment.SelectedIndex == -1) return;
            int comboA = int.Parse(comboAppointment.SelectedItem.ToString().Split('|')[0].Trim());
            foreach (Appointment selected in activeAppointments)
            {
                if (selected.AppointmentDetailNo == comboA)
                {
                    selectedAppointment = selected;
                    break;
                }
            }
            if (selectedAppointment != null)
            {
                display(selectedAppointment);
            }
        }

        private void StartTime_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DateTime date = dateSchedulePicker.Value;
            if (StartTime.SelectedIndex == -1) return;

            DateTime start = DateTime.ParseExact(
                                    StartTime.SelectedItem.ToString(),
                                    "hh:mm:ss tt",
                                    CultureInfo.InvariantCulture
                                );
            DateTime end = start + selectedAppointment.Operation.Duration;
            EndTime.Text = end.ToString("hh:mm:ss tt");
        }


        private void updateAppointmentB_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
            {
                MessagePromp.ShowCenter(this, "No Appointment Selected.", MessageBoxIcon.Error);
                return;
            }


            Appointment app = isAppointmentValid();
            if (app == null) return;

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "room"))
            {
                MessagePromp.ShowCenter(this, "This room is occupied this time.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "doctor"))
            {
                MessagePromp.ShowCenter(this, "Schedule conflicts with the doctor schedule.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "patient"))
            {
                MessagePromp.ShowCenter(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
                return;
            }

            if (selectedAppointment.StartTime.Equals(app.StartTime))
            {
                return;
            }

            if (appointmentRepository.UpdateSchedule(app))
            {
                List<Appointment> temp = new List<Appointment>();
                temp.Add(app);
                for (int i = 0; i < activeAppointments.Count; i++)
                {
                    Appointment a = activeAppointments[i];
                    if (a.AppointmentDetailNo == app.AppointmentDetailNo)
                    {
                        activeAppointments[i] = app;
                        break;
                    }
                }
                PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(app.Patient, temp, "Reappointment");
                prrr.print();
                MessagePromp.ShowCenter(this, "Appointment successfully updated.", MessageBoxIcon.Information);
                clear();
                comboAppointment.SelectedIndex = -1;
                comboAppointment.Text = "";
                selectedAppointment = null;
            }

        }
        private Appointment isAppointmentValid()
        {
            DateTime date = dateSchedulePicker.Value.Date;
            if (StartTime.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessageBig(this, "No StartTime", MessageBoxIcon.Error);
                return null;
            }
            DateTime start = DateTime.ParseExact(
                                    StartTime.SelectedItem.ToString(),
                                    "hh:mm:ss tt",
                                    CultureInfo.InvariantCulture
                                );


            DateTime startSchedule = date
                                .AddHours(start.Hour)
                                .AddMinutes(start.Minute);

            DateTime currentDateTime = DateTime.Now;
            if (startSchedule < currentDateTime)
            {
                MessagePromp.ShowCenter(this, "Time is already past.", MessageBoxIcon.Error);
                return null;
            }
            DateTime endSchedule = startSchedule + selectedAppointment.Operation.Duration;


            return new Appointment(
                selectedAppointment.Patient,
                selectedAppointment.Doctor,
                selectedAppointment.Operation,
                startSchedule,
                endSchedule,
                selectedAppointment.SubTotal,
                selectedAppointment.RoomNo,
                selectedAppointment.AppointmentDetailNo,
                selectedAppointment.Total,
                selectedAppointment.Discounttype,
                selectedAppointment.Diagnosis,
                selectedAppointment.BookingDate,
                selectedAppointment.Status,
                selectedAppointment.Prescription);
        }
    }
}