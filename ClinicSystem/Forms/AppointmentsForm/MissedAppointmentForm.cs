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
using ClinicSystem.Rooms;
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
            autoComplete();
            dateSchedulePicker.Value = DateTime.Now;
        }

        private void autoComplete()
        {
            comboAppointment.Items.Clear();
            missedAppointments = appointmentRepository.getMissedAppointments();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Appointment appointment in missedAppointments)
            {
                comboAppointment.Items.Add(appointment.AppointmentDetailNo + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + " " + appointment.Patient.Middlename);
                auto.Add(appointment.AppointmentDetailNo + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  ");
                auto.Add(appointment.Patient.Patientid + " | " + appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  " + " | " + appointment.AppointmentDetailNo);
                auto.Add(appointment.Patient.Lastname + ", " + appointment.Patient.Firstname + $" {appointment.Patient.Middlename}  | " + appointment.Patient.Patientid + " | " + appointment.AppointmentDetailNo);
            }
            comboAppointment.AutoCompleteCustomSource = auto;
        }
        
        private void comboAppointment_TextChanged(object sender, EventArgs e)
        {
            string id = comboAppointment.Text;
            if (string.IsNullOrWhiteSpace(id)) return;

            string[] ids = id.Split('|');

            // for app id
            selectedAppointment = missedAppointments.FirstOrDefault(p =>
                p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(0)?.Trim(), StringComparison.OrdinalIgnoreCase));

            // for patientid
            if (selectedAppointment == null)
            {
                selectedAppointment = missedAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            //full name
            if (selectedAppointment == null)
            {
                selectedAppointment = missedAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase));
            }

            //for general
            if (selectedAppointment == null)
            {
                selectedAppointment = missedAppointments.FirstOrDefault(p =>
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(0)?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                     p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    p.AppointmentDetailNo.ToString().Equals(ids.ElementAtOrDefault(2)?.Trim(), StringComparison.OrdinalIgnoreCase)
                );
            }
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
                    reset();
                }
            }
        }


        private void comboAppointment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAppointment.SelectedIndex == -1) return;
            int comboA = int.Parse(comboAppointment.SelectedItem.ToString().Split('|')[0].Trim());
            foreach (Appointment selected in missedAppointments)
            {
                if (selected.AppointmentDetailNo == comboA)
                {
                    selectedAppointment = selected;
                }
            }
            if (selectedAppointment != null)
            {
                display(selectedAppointment);
            }
        }
        private void display(Appointment selectedAppointmemnt)
        {
            comboAppointment.Text = selectedAppointment.AppointmentDetailNo.ToString();
            string fullname = $"{selectedAppointment.Patient.Firstname}  " +
                                 $"{selectedAppointment.Patient.Middlename}  " +
                                 $"{selectedAppointment.Patient.Lastname}";
            tbFname.Text = fullname;
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
            totalFee.Text = (selectedAppointment.SubTotal * 0.15).ToString("F2");
            StartTime.Enabled = true;
        }

        private void reset()
        {
            tbFname.Text = "";
            doctorL.Text = "";
            tbOname.Text = "";
            roomNo.Text = "";
            dateSchedulePicker.Value = DateTime.Now;
            StartTime.SelectedIndex = -1;
            EndTime.Text = "";
            reason.Text = "";
            total.Text = "";
            totalFee.Text = "";
            StartTime.Enabled = false;
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

            if (appointmentRepository.penaltyAppointment(app))
            {
                List<Appointment> temp = new List<Appointment>();
                temp.Add(app);
                autoComplete();
                PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(app.Patient, temp, "Penalty");
                prrr.print();
                MessagePromp.ShowCenter(this, "Appointment successfully updated.", MessageBoxIcon.Information);
                reset();
                comboAppointment.SelectedIndex = -1;
                comboAppointment.Text = "";
                selectedAppointment = null;
            }
        }

      

        private Appointment isAppointmentValid()
        {
            if (string.IsNullOrWhiteSpace(reason.Text))
            {
                MessagePromp.ShowCenter(this, "Please provide a reason.", MessageBoxIcon.Error);
                return null;
            } 
            DateTime date = dateSchedulePicker.Value.Date;
            if (StartTime.SelectedIndex == -1)
            {
                MessagePromp.ShowCenter(this, "No StartTime", MessageBoxIcon.Error);
                return null;
            }
            DateTime start = DateTime.ParseExact(
                                    StartTime.SelectedItem.ToString(),
                                    "hh:mm:ss tt",
                                    CultureInfo.InvariantCulture
                                );


            DateTime startSchedule = date.AddHours(start.Hour) .AddMinutes(start.Minute);

            DateTime currentDateTime = DateTime.Now;
            if (startSchedule < currentDateTime)
            {
                MessagePromp.ShowCenter(this, "Time is already past.", MessageBoxIcon.Error);
                return null;
            }
            DateTime endSchedule = startSchedule + selectedAppointment.Operation.Duration;

            PenaltyAppointment p = new PenaltyAppointment("Absent",selectedAppointment.Total * 0.15, reason.Text,DateTime.Now);

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

        private void StartTime_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
