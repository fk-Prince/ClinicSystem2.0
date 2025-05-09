using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
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

            foreach (Appointment appointment in activeAppointments)
            {
                comboAppointment.Items.Add(appointment.AppointmentDetailNo);
            }
            dateSchedulePicker.Value = DateTime.Now;
        }
        private void comboAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAppointment.SelectedIndex == -1) return;
            int comboA = int.Parse(comboAppointment.SelectedItem.ToString());
            foreach (Appointment selected in activeAppointments)
            {
                if (selected.AppointmentDetailNo == comboA)
                {
                    selectedAppointment = selected;
                }
            }
            if (selectedAppointment != null)
            {

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
   
                dateSchedulePicker.Value = selectedAppointment.StartTime;
                StartTime.SelectedItem = selectedAppointment.StartTime.ToString("hh:mm:ss tt");
                EndTime.Text = selectedAppointment.EndTime.ToString("hh:mm:ss tt");
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
            if (comboAppointment.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessage(this, "No Appointment Selected.", MessageBoxIcon.Error);
                return;
            }


            Appointment app = isAppointmentValid();
            if (app == null) return;

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "room"))
            {
                MessagePromp.MainShowMessageBig(this, "This room is occupied this time.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "doctor"))
            {
                MessagePromp.MainShowMessageBig(this, "Schedule conflicts with the doctor schedule.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailableNotEqualAppointmentNo(app, "patient"))
            {
                MessagePromp.MainShowMessageBig(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
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
                MessagePromp.MainShowMessage(this, "Appointment is updated.", MessageBoxIcon.Information);
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
                MessagePromp.MainShowMessageBig(this, "Time is already past.", MessageBoxIcon.Error);
                return null;
            }
            DateTime endSchedule = startSchedule + selectedAppointment.Operation.Duration;
     

            return new  Appointment(
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
                selectedAppointment.Status);

        }

        
    }
}