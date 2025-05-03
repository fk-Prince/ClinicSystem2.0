using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using static System.Net.Mime.MediaTypeNames;

namespace ClinicSystem.Appointments
{
    public partial class AddAppointmentForm : Form
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();   


        private List<Patient> patientList;
        private List<Room> rooms;
        private List<Operation> operationList;
        private List<Doctor> doctorList;
        private Stack<string> text = new Stack<string>();
        private Operation lastSelected;
        private List<Appointment> patientSchedules = new List<Appointment>();

        private Patient selectedPatient;
        private Operation selectedOperation;
        private Doctor selectedDoctor;
        public AddAppointmentForm()
        {
            InitializeComponent();
            patientList = appointmentRepository.getPatients();
            foreach (Patient patient in patientList)
            {
                comboPatientID.Items.Add(patient.Patientid);
            }
            rooms = appointmentRepository.getRoomNo();
            operationList = appointmentRepository.getOperations();
            scheduleDate.Value = DateTime.Now;
        }
        private void close(object sender, EventArgs e)
        {
            DiscountChoicePromp.closePanel();
        }

        // Patient SELECTED
        private void comboPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPatientID.SelectedIndex == -1) return;
            comboDoctor.Items.Clear();
            comboOperation.Items.Clear();
            comboRoom.Items.Clear();
            if (selectedOperation != null)
            {
                startC.Enabled = false;
                scheduleDate.Value = DateTime.Now;
                startC.SelectedIndex = -1;
                End.Text = "";
                TotalBill.Text = "";
                text.Clear();
                tbListOperation.Text = "";
                patientSchedules.Clear();
            }
            selectedPatient = patientList.FirstOrDefault(p => p.Patientid.Equals(comboPatientID.SelectedItem.ToString()));
            fName.Text = selectedPatient.Firstname;
            mName.Text = selectedPatient.Middlename;
            lName.Text = selectedPatient.Lastname;
            string opNumber = appointmentRepository.getAppointmentDetail();
            PatientAppointmentNo.Text = opNumber;
            operationList.ForEach(op => comboOperation.Items.Add(op.OperationCode + "  |  " +op.OperationName));
        }

        // Operation Selected
        private void comboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOperation.SelectedIndex == -1) return;
            selectedOperation = operationList.Find(op => op.OperationCode == comboOperation.SelectedItem.ToString().Split('|')[0].Trim());
            startC.Enabled = true;
            comboDoctor.Items.Clear();
            comboRoom.Items.Clear();
            doctorList = appointmentRepository.getDoctors(selectedOperation);
            if (doctorList != null && doctorList.Count != 0)
            {
                foreach (Doctor doctor in doctorList)
                {     
                   comboDoctor.Items.Add(doctor.DoctorID + "  |  " + doctor.DoctorLastName + ", " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName);                
                }
            }
            else
            {
                comboDoctor.Items.Add("No Doctor Available");
            }
            comboDoctor.SelectedIndex = 0;
            List<Room> filter = new List<Room>();
            foreach (Room room in rooms)
            {
                if (selectedOperation.OperationRoomType.Equals(room.Roomtype))
                {
                    filter.Add(room);
                    comboRoom.Items.Add(room.RoomNo + "  |  " + room.Roomtype);
                }
            }
            if (filter.Count == 0) comboRoom.Items.Add("No Room Available");
            comboRoom.SelectedIndex = 0;
        }

        // Doctor Selected
        private void comboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDoctor.SelectedIndex == -1) return;
            string[] doc = comboDoctor.SelectedItem.ToString().Split('|');
            if (doctorList != null && doctorList.Count != 0)
            {
                foreach (Doctor doctor in doctorList)
                {
                    if (doc[0].Trim().Equals(doctor.DoctorID))
                    {
                        selectedDoctor = doctor;
                        break;
                    }
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!isComboValid()) return;
            if (isAlreadyAdded()) return;
            Appointment appointment = isScheduleValid();
            if (appointment == null)
            {
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "room"))
            {
                MessagePromp.MainShowMessageBig(this, "This room is occupied this time.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "doctor"))
            {
                MessagePromp.MainShowMessageBig(this, "Schedule conflicts with the doctor schedule.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "patient"))
            {
                MessagePromp.MainShowMessageBig(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
                return;
            }

            foreach (Appointment sc in patientSchedules)
            {
                DateTime existStart = sc.StartTime;
                DateTime existEnd = sc.EndTime;
                DateTime newStart = appointment.StartTime;
                DateTime newEnd = appointment.EndTime;



                bool isOverlap =
                    (newStart >= existStart && newStart < existEnd) ||
                    (newEnd > existStart && newEnd <= existEnd) ||
                    (existStart >= newStart && existStart < newEnd) ||
                    (existEnd > newStart && existEnd <= newEnd);

                if (isOverlap)
                {
                    MessagePromp.MainShowMessageBig(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
                    return;
                }
            }

            Operation op = selectedOperation;
            Doctor doc = selectedDoctor;
            lastSelected = op;
            patientSchedules.Add(appointment);
            displayAppointment(appointment);
            PatientAppointmentNo.Text = (int.Parse(PatientAppointmentNo.Text) + 1).ToString();
            double totalBill = 0;
            foreach (Appointment ap in patientSchedules)
            {
                totalBill += ap.SubTotal;
            }
            TotalBill.Text = totalBill.ToString("F2");
        }

        private Appointment isScheduleValid()
        {
            DateTime date = scheduleDate.Value.Date;
            if (startC.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessageBig(this, "No StartTime", MessageBoxIcon.Error);
                return null;
            }
            DateTime start = DateTime.ParseExact(
                                    startC.SelectedItem.ToString(),
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
            DateTime endSchedule = startSchedule + selectedOperation.Duration;
            int roomno = int.Parse(comboRoom.SelectedItem.ToString().Split(' ')[0].Trim());
            return new Appointment(selectedPatient, selectedDoctor, selectedOperation,
                startSchedule, endSchedule, selectedOperation.Price, 
                roomno, int.Parse(PatientAppointmentNo.Text));
        }
        private bool isAlreadyAdded()
        {
            if (patientSchedules != null && patientSchedules.Count != 0)
            {
                foreach (Appointment vb in patientSchedules)
                {
                    if (vb.Operation.OperationName.Equals(selectedOperation.OperationName))
                    {
                        MessagePromp.MainShowMessageBig(this, "This operation is already added.", MessageBoxIcon.Error);
                        return true;
                    }
                }
            }

            return false;
        }
        private bool isComboValid()
        {
            if (comboOperation.SelectedItem == null || string.IsNullOrWhiteSpace(comboOperation.SelectedItem.ToString()))
            {
                MessagePromp.MainShowMessage(this, "No Operation Selected.", MessageBoxIcon.Error);
                return false;
            }
            if (comboOperation.SelectedItem.Equals("No Operation Available"))
            {
                MessagePromp.MainShowMessage(this, "No Operation Available.", MessageBoxIcon.Error);
                return false;
            }
            if (comboDoctor.SelectedItem == null || string.IsNullOrWhiteSpace(comboDoctor.SelectedItem.ToString()))
            {
                MessagePromp.MainShowMessage(this, "No Doctor Selected.", MessageBoxIcon.Error);
                return false;
            }
            if (comboDoctor.SelectedItem.Equals("No Doctor Available"))
            {
                MessagePromp.MainShowMessage(this, "No Doctor Available.", MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void displayAppointment(Appointment appointment)
        {
            string fullname = appointment.Doctor.DoctorLastName + ", " + appointment.Doctor.DoctorFirstName + " " + appointment.Doctor.DoctorMiddleName;
            string displayText = $"Operation Name:  {selectedOperation.OperationName}  {Environment.NewLine}" +
                                 $"Operation Bill:  {selectedOperation.Price.ToString("F2")}  {Environment.NewLine}" +
                                 $"Doctor Assigned: Dr.{fullname}  {Environment.NewLine}" +
                                 $"RoomNo:  {appointment.RoomNo} {Environment.NewLine}" +
                                 $"StartTime: {appointment.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt")} {Environment.NewLine}" +
                                 $"EndTime:  {appointment.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt")}{Environment.NewLine}" +
                                 "------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            tbListOperation.Text += displayText;
            text.Push(displayText);
        }
        private void removeLast(object sender, EventArgs e)
        {
            if (text == null || text.Count == 0) return;
            text.Pop();
            tbListOperation.Text = "";
            foreach (string t in text)
            {
                tbListOperation.Text += t;
            }

            if (patientSchedules.Count >= 0)
            {
                Appointment lastSchedule = patientSchedules.Last();
                patientSchedules.Remove(lastSchedule);

                if (double.TryParse(TotalBill.Text, out double bill))
                {
                    bill -= lastSelected.Price;
                    TotalBill.Text = bill.ToString("F2");
                }
            }

            if (patientSchedules.Count > 0)
            {
                Appointment lastPatientSchedule = patientSchedules.Last();
                patientSchedules.Remove(lastPatientSchedule);
            }

            foreach (string t in text)
            {
                tbListOperation.Text += t;
            }

            PatientAppointmentNo.Text = (int.Parse(PatientAppointmentNo.Text) - 1).ToString();
        }
        private void addAppointment_Click(object sender, EventArgs e)
        {
            if (patientSchedules.Count <= 0)
            {
                MessagePromp.MainShowMessage(this, "Please Add an Operation.", MessageBoxIcon.Error);
                return;
            }

            DiscountChoicePromp.showChoices(this, selectedPatient,0, patientSchedules, (confirmed, patientSchedules) =>
            {
                if (confirmed)
                {
                    PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(selectedPatient, patientSchedules, "Add");
                    prrr.print();

                    MessagePromp.MainShowMessage(this, "Appoinment Added", MessageBoxIcon.Information);
                    scheduleDate.Value = DateTime.Now;
                    startC.SelectedIndex = -1;
                    End.Text = "";
                    TotalBill.Text = "";
                    text.Clear();
                    tbListOperation.Text = "";
                    selectedPatient = null;
                    selectedDoctor = null;
                    selectedOperation = null;
                    PatientAppointmentNo.Text = "";
                    lastSelected = null;
                    patientSchedules.Clear();
                    comboRoom.Items.Clear();
                    comboOperation.Items.Clear();
                    comboDoctor.Items.Clear();
                    comboPatientID.SelectedIndex = -1;
                    fName.Text = "";
                    mName.Text = "";
                    lName.Text = "";
                }
            });
        }
        private void startC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime date = scheduleDate.Value;
            if (startC.SelectedIndex == -1) return;

            DateTime start = DateTime.ParseExact(
                                    startC.SelectedItem.ToString(),
                                    "hh:mm:ss tt",
                                    CultureInfo.InvariantCulture
                                );
            DateTime end = start + selectedOperation.Duration;
            End.Text = end.ToString("hh:mm:ss tt");
        }
    }
}
