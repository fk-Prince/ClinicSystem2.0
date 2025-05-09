using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using ClinicSystem.Entity;
using ClinicSystem.UserLoginForm;

namespace ClinicSystem.Forms.AppointmentsForm
{
    public partial class MissedAppointmentForm : Form
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private List<Appointment> missedAppointments;
        private Appointment selectedAppointment;
        public MissedAppointmentForm()
        {
            InitializeComponent();
            missedAppointments = appointmentRepository.getMissedAppointments();
            missedAppointments.ForEach(e => comboAppointment.Items.Add(e.AppointmentDetailNo));
        }

        private void comboAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAppointment.SelectedIndex == -1) return;
            int comboA = int.Parse(comboAppointment.SelectedItem.ToString());
            foreach (Appointment selected in missedAppointments)
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
                total.Text = selectedAppointment.Total.ToString("F2");
                totalFee.Text = (selectedAppointment.SubTotal * 0.2).ToString("F2");
            }
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

            if (appointmentRepository.penaltyAppointment(app))
            {
                List<Appointment> temp = new List<Appointment>();
                temp.Add(app);
                for (int i = 0; i < missedAppointments.Count; i++)
                {
                    Appointment a = missedAppointments[i];
                    if (a.AppointmentDetailNo == app.AppointmentDetailNo)
                    {
                        missedAppointments[i] = app;
                        selectedAppointment = app;
                        break;
                    }
                }
                PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(app.Patient, temp, "Penalty");
                prrr.print();
                MessagePromp.MainShowMessage(this, "Appointment is updated.", MessageBoxIcon.Information);
            }
        }

        private Appointment isAppointmentValid()
        {
            if (string.IsNullOrWhiteSpace(reason.Text))
            {
                MessagePromp.MainShowMessage(this, "Please provide a reason.", MessageBoxIcon.Error);
                return null;
            } 
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

            PenaltyAppointment p = new PenaltyAppointment("Absent",selectedAppointment.Total * 0.20, reason.Text,DateTime.Now);

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
                 p);
        }

        private void guna2Panel1_SizeChanged(object sender, EventArgs e)
        {
            //if (ClientSize.Height > 750)
            //{
              
            //    panel2.Location = new Point(panel3.Right + 30, panel3.Location.Y + 50);
            //    panel1.Location = new Point(panel3.Right + 30, panel2.Bottom + 30);
            //}
            //panel1.Invalidate();
            //panel2.Invalidate();
        
        }
    }
}
