using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using DoctorClinic;

namespace ClinicSystem
{
    public partial class AddPatients : Form
    {
        //REPOSITORY
        private PatientRepository patientRepository = new PatientRepository();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private RoomRepository roomRepository = new RoomRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private OperationRepository operationRepository = new OperationRepository();

        //UTILITY
        private Staff staff;
        private List<Control> tab = new List<Control>();
        private int patx = 12;
        private int appx = 1100;
        private bool isPatPanelShowing = true;


        //APPOINTMENT
        private List<Room> rooms;
        private List<Operation> operationList;
        private List<Doctor> doctorList;
        private Operation selectedOperation;
        private Doctor selectedDoctor;
        private Patient patient;
        private Stack<string> text = new Stack<string>();
        private Operation lastSelected;
        private List<Appointment> patientSchedules = new List<Appointment>();
        public AddPatients(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();


            string id = patientRepository.getPatientId();
            lastPatientID.Text = id.ToString();
            rooms = roomRepository.getRooms();

            tab.Add(FirstName);
            tab.Add(MiddleName);
            tab.Add(LastName);  
            tab.Add(Address);
            tab.Add(BirthDate);     
            //tab.Add(Gender);
            tab.Add(ContactNo);

            foreach (Control control in tab)
            {
                control.PreviewKeyDown += taab;
            }

            appx = ClientSize.Width;
            appPanel.Location = new Point(ClientSize.Width, appPanel.Location.Y);
            BirthDate.Value = DateTime.Now;
            scheduleDate.Value = DateTime.Now;


        }
       

        private void TextOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private bool isInputValid()
        {
            string fname = FirstName.Text;
            string mname = MiddleName.Text;
            string lname = LastName.Text;
            string address = Address.Text;
            string age = Age.Text;
            DateTime bday = BirthDate.Value;
            string contact = ContactNo.Text;

            if (string.IsNullOrWhiteSpace(fname) ||
              string.IsNullOrWhiteSpace(mname) ||
              string.IsNullOrWhiteSpace(lname) ||
              string.IsNullOrWhiteSpace(address) ||
              string.IsNullOrWhiteSpace(age) ||
              string.IsNullOrWhiteSpace(bday.ToString()))
            {
                MessagePromp.ShowCenter(this, "Please fill up all fields", MessageBoxIcon.Error);
                return false;
            }

            if (!rMale.Checked && !rFemale.Checked)
            {
                MessagePromp.ShowCenter(this, "Choose gender", MessageBoxIcon.Error);
                return false;
            }
            string gender = rMale.Checked ? "Male" : "Female";

          
            if (bday > DateTime.Now)
            {
                MessagePromp.ShowCenter(this, "Invalid Birthdate", MessageBoxIcon.Error);
                return false;
            }

            int ageInt = 0;
            if (!int.TryParse(age, out ageInt))
            {
                MessagePromp.ShowCenter(this, "Invalid Age", MessageBoxIcon.Error);
                return false ;
            }

            if (ageInt > 120 || ageInt < 0)
            {
                MessagePromp.ShowCenter(this, "Invalid Age", MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(contact) && (!long.TryParse(contact, out _) || !Regex.IsMatch(contact, @"^9\d{9}$")))
            {
                MessagePromp.ShowCenter(this, "Invalid Contact Number", MessageBoxIcon.Error);
                return false;
            }
            if (contact.Length != 0)
            {
                contact = "0" + contact;
            }
            patient = new Patient(lastPatientID.Text, Capitalize(fname), Capitalize(mname), Capitalize(lname), address, ageInt, gender, bday, contact);
            return true;
        }

        public string Capitalize(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        private void taab(object sender, PreviewKeyDownEventArgs e)
        {
           if (e.KeyCode == Keys.Tab)
            {
                Control currentControl = sender as Control;
                int currentIndex = tab.IndexOf(currentControl);

                if (currentIndex >= 0)
                {
                    int nextIndex = (currentIndex + 1) % tab.Count;
                    tab[nextIndex].Focus();
                    e.IsInputKey = true;
                }
            }
        }

        private void BirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(BirthDate.Text, out DateTime birthDate))
            {
                DateTime todayDate = DateTime.Now;
                int age = todayDate.Year - birthDate.Year;

                if (todayDate.Month < birthDate.Month || (todayDate.Month == birthDate.Month && todayDate.Day < birthDate.Day))
                {
                    age--;
                }
                Age.Text = age.ToString();
            }
        }

       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!isInputValid()) return;
            showOperation();
            string opNumber = appointmentRepository.getAppointmentDetail();
            PatientAppointmentNo.Text = opNumber;

            switchButton.Image = isPatPanelShowing ? Properties.Resources.prev : Properties.Resources.next;
            slidePat.Start();
            slideApp.Start();           
        }

        //ANImATION
        private void slidePat_Tick(object sender, EventArgs e)
        {
            switchButton.Enabled = false;
            if (isPatPanelShowing)
            {
                patx -= 50;
             
                if (patx <= -patPanel.Width)
                {
                    patx = -patPanel.Width;
                    slidePat.Stop();
                    isPatPanelShowing = !isPatPanelShowing;
                    switchButton.Enabled = true;
                }
            }
            else
            {
                patx += 50;
                if (patx >= 12)
                {
                    patx = 12;
                    slidePat.Stop();
                    isPatPanelShowing = !isPatPanelShowing;
                    switchButton.Enabled = true;
                }
            }
            patPanel.Location = new Point(patx, patPanel.Location.Y);

        }

        private bool isAppShowing = false;

        private void slideApp_Tick(object sender, EventArgs e)
        {
            if (!isAppShowing)
            {
                appx -= 50;  
                if (appx <= 20)
                {
                    appx = 20;
                    isAppShowing = !isAppShowing;
                    slideApp.Stop();
                }
            }
            else
            {
                appx += 50;
                if (appx >= ClientSize.Width)
                {
                    isAppShowing = !isAppShowing;
                    slideApp.Stop();
                }

            }
            appPanel.Location = new Point(appx, appPanel.Location.Y);
        }


    
        // SHOW OPERATION
        private void showOperation()
        {
            comboOperation.Items.Clear();
            operationList = operationRepository.getOperations();
            if (operationList != null && operationList.Count != 0)
            {
                operationList.ForEach(op => comboOperation.Items.Add(op.OperationCode + "     |     " + op.OperationName));
            }
            else
            {
                comboOperation.Items.Add("No Operation Available");
            }
            comboOperation.SelectedIndex = -1;
        }

        // SETUP OPERATION SELECTED
        private void comboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedOperation == null) return;
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

        // DISPLAY CHECK
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
                MessagePromp.ShowCenter(this, "This room is occupied this time.", MessageBoxIcon.Error);
                return;
            }

            if (!appointmentRepository.isScheduleAvailable(appointment, "doctor"))
            {
                MessagePromp.ShowCenter(this, "Schedule conflicts with the doctor schedule.", MessageBoxIcon.Error);
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
            TotalBill.Text = totalBill.ToString("F2");
            reset();
        }


        // DISPLAY THE CURRENTLY ADDED APPOINTMENT
        private void displayAppointment(Appointment schedule)
        {
            string fullname = schedule.Doctor.DoctorLastName + ", " + schedule.Doctor.DoctorFirstName + " " + schedule.Doctor.DoctorMiddleName;
            string displayText = $"Appointment No.:  {schedule.AppointmentDetailNo.ToString()}  {Environment.NewLine}" +
                                 $"Operation Name:  {schedule.Operation.OperationName}  {Environment.NewLine}" +
                                 $"Operation Bill:  {schedule.Operation.Price.ToString("F2")}  {Environment.NewLine}" +
                                 $"Doctor Assigned: Dr.{fullname}  {Environment.NewLine}" +
                                 $"RoomNo:  {schedule.RoomNo} {Environment.NewLine}" +
                                 $"StartTime: {schedule.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt")} {Environment.NewLine}" +
                                 $"EndTime:  {schedule.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt")}{Environment.NewLine}" +
                                 "------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            tbListOperation.Clear();
            text.Push(displayText);
            foreach (string text in text)
            { 
                tbListOperation.Text += text;
            }
        }
     
        //SCHEDULE CHECKER
        private Appointment isScheduleValid()
        {
            DateTime date = scheduleDate.Value.Date;
            if (startC.SelectedIndex == -1)
            {
                MessagePromp.ShowCenter(this, "No StartTime", MessageBoxIcon.Error);
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
            return new Appointment(patient,selectedDoctor,selectedOperation,startSchedule,endSchedule,selectedOperation.Price, roomno, int.Parse(PatientAppointmentNo.Text));
        }


        //COMBO DOCTOR
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



        //CHECK IF COMBO SELECTED
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


        //CALCULATE THE ENDTIME
        private void startC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedOperation == null) return;

            DateTime date = scheduleDate.Value;
            if (startC.SelectedIndex == -1) return;
            
            DateTime start = DateTime.ParseExact(
                                    startC.SelectedItem.ToString(),
                                    "hh:mm:ss tt",
                                    CultureInfo.InvariantCulture
                                );
            start = date.Date
                   .AddHours(start.Hour)
                   .AddMinutes(start.Minute)
                   .AddSeconds(start.Second);

            DateTime end = start + selectedOperation.Duration;
            End.Text = end.ToString("hh:mm:ss tt");
            getDoctor();
            if (comboDoctor.SelectedIndex == -1)
            {

                comboDoctor.Items.Clear();
                List<Doctor> availableDoctor = appointmentRepository.getAvailableDoctors(selectedOperation, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
                if (availableDoctor != null && availableDoctor.Count != 0)
                {
                    foreach (Doctor doctor in availableDoctor)
                    {
                        comboDoctor.Items.Add(doctor.DoctorID + "   | " + doctor.DoctorLastName + ", " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName);
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


        //REMOVE CURRENTLY ADDED APPOINTMENT
        private void RemoveStack_Click(object sender, EventArgs e)
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


        //FINALIZE APPOINTMENT
        private void addAppointment_Click(object sender, EventArgs e)
        {
            

            if (patientSchedules.Count <= 0)
            {
                MessagePromp.ShowCenter(this, "Please Add an Operation.", MessageBoxIcon.Error);
                return;
            }
            
            DiscountChoicePromp.showChoices(this,"INSERT PATIENT", patient,staff.StaffId, patientSchedules, (confirmed, patientSchedules) =>
            {
                if (confirmed)
                {
                    PrintAppointmentReceipt prrr = new PrintAppointmentReceipt(patient, patientSchedules, "Add");
                    prrr.print();
                    slidePat.Start();
                    slideApp.Start();
                    MessagePromp.ShowCenter(this, "Appoinment Added", MessageBoxIcon.Information);
                    switchButton.Image = isPatPanelShowing ? Properties.Resources.prev : Properties.Resources.next;
                    scheduleDate.Value = DateTime.Now;
                    startC.SelectedIndex = -1;
                    End.Text = "";
                    TotalBill.Text = "";
                    text.Clear();
                    tbListOperation.Text = "";
                    selectedDoctor = null;
                    selectedOperation = null;
                    patient = null;
                    FirstName.Text = "";
                    MiddleName.Text = "";
                    LastName.Text = "";
                    Address.Text = "";
                    Age.Text = "";
                    ContactNo.Text = "";
                    rFemale.Checked = false;
                    rMale.Checked = false;
                    BirthDate.Value = DateTime.Now;
                    string id = patientRepository.getPatientId();
                    lastPatientID.Text = id.ToString();
                    PatientAppointmentNo.Text = "";
                    lastSelected = null;
                    this.patientSchedules.Clear();
                    patientSchedules.Clear();
                    comboRoom.Items.Clear();
                    comboOperation.Items.Clear();
                    comboDoctor.Items.Clear();


                }
            });
        }

        //PREVENT DOUBLE ADDED OPERAITON
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

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            appx = ClientSize.Width;
            appPanel.Location = new Point(ClientSize.Width, appPanel.Location.Y);
            appPanel.Invalidate();


            p1.Location = new Point((tbListOperation.Left - p1.Width) - 20, p1.Location.Y);
            p2.Location = new Point((tbListOperation.Left - p2.Width) - 20, p2.Location.Y);
            p3.Location = new Point((tbListOperation.Left - p3.Width) - 20, p3.Location.Y);
            p4.Location = new Point((tbListOperation.Left - p4.Width) - 20, p4.Location.Y);
            p5.Location = new Point((tbListOperation.Left - p5.Width) - 90, p5.Location.Y);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            scheduleDate.Value = DateTime.Now;
            startC.SelectedIndex = -1;
            selectedDoctor = null;
            selectedOperation = null;
            comboOperation.SelectedIndex = -1;
            //lastSelected = null;
            End.Text = "";
            comboRoom.Items.Clear();
            comboDoctor.Items.Clear();
        }
     


    }
}
