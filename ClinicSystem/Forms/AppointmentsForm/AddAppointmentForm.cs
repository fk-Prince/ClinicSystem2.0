using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.MessagePromps;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using DoctorClinic;


namespace ClinicSystem.Appointments
{
    public partial class AddAppointmentForm : Form
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private RoomRepository roomRepository = new RoomRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private OperationRepository operationRepository = new OperationRepository();

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
        private int staffid;
        public AddAppointmentForm(int staffid)
        {
            this.staffid = staffid;
            InitializeComponent();
            patientList = patientRepository.getPatient();
            rooms = roomRepository.getRooms();
            operationList = operationRepository.getOperations();

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();   
            foreach (Patient patient in patientList)
            {
                comboPatientID.Items.Add(patient.Patientid + " | " + patient.Lastname);
                auto.Add(patient.Patientid + " | " + patient.Lastname);
                auto.Add(patient.Lastname + ", " + patient.Firstname + $" {patient.Middlename} | " + patient.Patientid);
            }
            comboPatientID.AutoCompleteCustomSource = auto;

            scheduleDate.Value = DateTime.Now;
        }
        private void close(object sender, EventArgs e)
        {
            DiscountChoicePromp.closePanel();
        }

        private void reset23()
        {
            comboDoctor.Items.Clear();
            comboOperation.Items.Clear();
            comboRoom.Items.Clear();
            if (patientSchedules.Count > 0)
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
        }

        // Patient SELECTED
        private void comboPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPatientID.SelectedIndex == -1) return;
            reset23();


            selectedPatient = patientList.FirstOrDefault(p => p.Patientid.Equals(comboPatientID.SelectedItem.ToString().Split('|')[0].Trim()));
            fName.Text = selectedPatient.Firstname;
            mName.Text = selectedPatient.Middlename;
            lName.Text = selectedPatient.Lastname;
            string opNumber = appointmentRepository.getAppointmentDetail();
            PatientAppointmentNo.Text = opNumber;
            Add.Enabled = true;
            Remove.Enabled = true;
            operationList.ForEach(op => comboOperation.Items.Add(op.OperationCode + "     |     " + op.OperationName));
        }


        private void comboPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (selectedPatient != null)
                {
                    reset23();
                    fName.Text = selectedPatient.Firstname;
                    mName.Text = selectedPatient.Middlename;
                    lName.Text = selectedPatient.Lastname;
                    comboPatientID.Text = selectedPatient.Patientid;
                    comboOperation.Items.Clear();
                    operationList.ForEach(op => comboOperation.Items.Add(op.OperationCode + "  |  " + op.OperationName));
                    string opNumber = appointmentRepository.getAppointmentDetail();
                    PatientAppointmentNo.Text = opNumber;
                    Add.Enabled = true;
                    Remove.Enabled = true;
                } else
                {
                    fName.Text = "";
                    mName.Text = "";
                    lName.Text = "";
                }
            }
        }
        private void comboPatientID_TextChanged(object sender, EventArgs e)
        {
            string id = comboPatientID.Text;
            if (string.IsNullOrWhiteSpace(id)) return;

            selectedPatient = patientList.FirstOrDefault(p =>
                p.Patientid.Equals(id.Split('|')[0].Trim(), StringComparison.OrdinalIgnoreCase) ||
                p.Lastname.Equals(id.Split(',')[0].Trim(), StringComparison.OrdinalIgnoreCase)
            );
            if (selectedPatient != null)
            {
                reset23();
                fName.Text = selectedPatient.Firstname;
                mName.Text = selectedPatient.Middlename;
                lName.Text = selectedPatient.Lastname;    
            }
        }

        // Operation Selected
        private void comboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboOperation.SelectedIndex == -1) return;
            selectedOperation = operationList.Find(op => op.OperationCode == comboOperation.SelectedItem.ToString().Split('|')[0].Trim());
            startC.Enabled = true;
            startC.SelectedIndex = -1;
            End.Text = "";
            comboDoctor.Items.Clear();
            comboRoom.Items.Clear();
            doctorList = doctorRepository.getDoctorsByOperation(selectedOperation);
            if (doctorList != null && doctorList.Count != 0)
            {
                foreach (Doctor doctor in doctorList)
                {
                    comboDoctor.Items.Add(doctor.DoctorID + "    |  " + doctor.DoctorLastName + ", " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName);
                }
            }
            else
            {
                comboDoctor.Items.Add("No Doctor Available");
                comboDoctor.SelectedIndex = 0;
            }
            List<Room> filter = new List<Room>();
            foreach (Room room in rooms)
            {
                if (selectedOperation.OperationRoomType.Equals(room.Roomtype))
                {
                    filter.Add(room);
                    comboRoom.Items.Add(room.RoomNo + "  |  " + room.Roomtype);
                }
            }
            if (filter.Count == 0)
            {
                comboRoom.Items.Add("No Room Available");
                comboRoom.SelectedIndex = 0;
            }
        }

       

        // Doctor Selected
        private void comboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDoctor();
        }
        private void getDoctor()
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

            if (!appointmentRepository.isScheduleAvailable(appointment, "doctor"))
            {
                MessagePromp.ShowCenter(this, "Schedule conflicts with the doctor schedule.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "room"))
            {
                MessagePromp.ShowCenter(this, "This room is occupied this time.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "patient"))
            {
                MessagePromp.ShowCenter(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
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
                    MessagePromp.ShowCenter(this, "Schedule conflicts with the patient schedule.", MessageBoxIcon.Error);
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
            reset2(); 
            TotalBill.Text = totalBill.ToString("F2");
        }

        private Appointment isScheduleValid()
        {
            DateTime date = scheduleDate.Value.Date;
            if (startC.SelectedIndex == -1)
            { 
                MessagePromp.ShowCenter(this, "No StartTime.", MessageBoxIcon.Error);
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
                MessagePromp.ShowCenter(this, "Time is already past.", MessageBoxIcon.Error);
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
                        DialogResult result = MessageBox.Show("Operation already added. Do you want to add again?", "Operation Already Added", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        return result == DialogResult.No;
                     }
                 }
             }

             return false;
         }
        private bool isComboValid()
        {
            if (comboOperation.SelectedItem == null || string.IsNullOrWhiteSpace(comboOperation.SelectedItem.ToString()))
            {
                MessagePromp.ShowCenter(this, "No Operation Selected.", MessageBoxIcon.Error);
                return false;
            }
            if (comboOperation.SelectedItem.Equals("No Operation Available"))
            {
                MessagePromp.ShowCenter(this, "No Operation Available.", MessageBoxIcon.Error);
                return false;
            }
            if (comboDoctor.SelectedItem == null || string.IsNullOrWhiteSpace(comboDoctor.SelectedItem.ToString()))
            {
                MessagePromp.ShowCenter(this, "No Doctor Selected.", MessageBoxIcon.Error);
                return false;
            }
            if (comboDoctor.SelectedItem.Equals("No Doctor Available"))
            {
                MessagePromp.ShowCenter(this, "No Doctor Available.", MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void displayAppointment(Appointment appointment)
        {
            string fullname = appointment.Doctor.DoctorLastName + ", " + appointment.Doctor.DoctorFirstName + " " + appointment.Doctor.DoctorMiddleName;
            string displayText =
                                 $"Appointment No.:  {appointment.AppointmentDetailNo.ToString()}  {Environment.NewLine}" +
                                 $"Operation Name:  {appointment.Operation.OperationName}  {Environment.NewLine}" +
                                 $"Operation Bill:  {appointment.Operation.Price.ToString("F2")}  {Environment.NewLine}" +
                                 $"Doctor Assigned: Dr.{fullname}  {Environment.NewLine}" +
                                 $"RoomNo:  {appointment.RoomNo} {Environment.NewLine}" +
                                 $"StartTime: {appointment.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt")} {Environment.NewLine}" +
                                 $"EndTime:  {appointment.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt")}{Environment.NewLine}" +
                                 "------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            tbListOperation.Clear();
            text.Push(displayText);
            foreach (string text in text)
            {
                  tbListOperation.Text += text;
            }
        }
        private void removeLast(object sender, EventArgs e)
        {
            if (text == null || text.Count == 0) return;
            text.Pop();
            tbListOperation.Text = "";
       
            if (patientSchedules.Count > 0)
            {
                Appointment lastSchedule = patientSchedules.Last();
                patientSchedules.Remove(lastSchedule);

                if (double.TryParse(TotalBill.Text, out double bill))
                {
                    bill -= lastSchedule.Operation.Price;
                    TotalBill.Text = bill.ToString("F2");
                }

            }

            foreach (string t in text)
            {
                tbListOperation.Text = t;
            }

            PatientAppointmentNo.Text = (int.Parse(PatientAppointmentNo.Text) - 1).ToString();
        }
        private void addAppointment_Click(object sender, EventArgs e)
        {

            if (selectedPatient == null)
            {
                MessagePromp.ShowCenter(this, "No Selected Patient.", MessageBoxIcon.Error);
                return;
            }
            if (patientSchedules.Count <= 0)
            {
                MessagePromp.ShowCenter(this, "Please Add an Operation.", MessageBoxIcon.Error);
                return;
            }

            DiscountChoicePromp.showChoices(this,"", selectedPatient, staffid, patientSchedules, (confirmed, patientSchedules) =>
            {
                if (confirmed)
                {
                    PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(selectedPatient, patientSchedules, "Add");
                    prrr.print();
                    MessagePromp.ShowCenter(this, "Appointment added successfully.", MessageBoxIcon.Information);
                    //MessagePromp.MainShowMessage(this, "Appoinment Added", MessageBoxIcon.Information);
                    reset();
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


            start = date.Date.AddHours(start.Hour).AddMinutes(start.Minute).AddSeconds(start.Second);

            DateTime end = start + selectedOperation.Duration;
            End.Text = end.ToString("hh:mm:ss tt");

            //DateTime startSchedule = date
            //                    .AddHours(start.Hour)
            //                    .AddMinutes(start.Minute);
            //DateTime endSchedule = startSchedule + selectedOperation.Duration;
            getDoctor();
            if (comboDoctor.SelectedIndex == -1)
            {

                comboDoctor.Items.Clear();
                List<Doctor> availableDoctor = appointmentRepository.getAvailableDoctors(selectedOperation, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
                if (availableDoctor != null && availableDoctor.Count != 0)
                {
                    foreach (Doctor doctor in availableDoctor)
                    {
                        comboDoctor.Items.Add(doctor.DoctorID + "  |  " + doctor.DoctorLastName + ", " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName);
                    }
                }
                else
                {
                    comboDoctor.Items.Add("No Doctor Available");
                }
                comboDoctor.SelectedIndex = 0;
            }
            if (comboRoom.SelectedIndex == -1)
            {
                comboRoom.Items.Clear();
                List<Room> availableRoom = appointmentRepository.getRoomAvailable(selectedOperation, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
                availableRoom.ForEach(room => comboRoom.Items.Add(room.RoomNo + "  |  " + room.Roomtype));

                if (availableRoom.Count() == 0) comboRoom.Items.Add("No Room Available");
                comboRoom.SelectedIndex = 0;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
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
            comboPatientID.Text = "";
            fName.Text = "";
            mName.Text = "";
            lName.Text = "";
            Add.Enabled = false;
            startC.Enabled = false;
            Remove.Enabled = false;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            reset2();
        }

        private void reset2()
        {
            scheduleDate.Value = DateTime.Now;
            startC.SelectedIndex = -1;
            selectedDoctor = null;
            selectedOperation = null;
            startC.Enabled = false;
            comboOperation.SelectedIndex = -1;
            //lastSelected = null;
            End.Text = "";
            comboRoom.Items.Clear();
            comboDoctor.Items.Clear();
        }

        private void AddAppointmentForm_SizeChanged(object sender, EventArgs e)
        {
            mP.Location = new Point(fP.Right + 25, mP.Location.Y);
            lP.Location = new Point(mP.Right + 25, lP.Location.Y);
            p1.Location = new Point((tbListOperation.Left - p1.Width) - 20, p1.Location.Y);
            p2.Location = new Point((tbListOperation.Left - p2.Width) - 20, p2.Location.Y);
            p3.Location = new Point((tbListOperation.Left - p3.Width) - 20, p3.Location.Y);
            p4.Location = new Point((tbListOperation.Left - p4.Width) - 20, p4.Location.Y);
            p5.Location = new Point((tbListOperation.Left - p5.Width) - 90, p5.Location.Y);
            p1.Invalidate();
            p2.Invalidate();
            p3.Invalidate();
            p4.Invalidate();
            p5.Invalidate();
            lP.Invalidate();
            mP.Invalidate();

        }
    }
}
