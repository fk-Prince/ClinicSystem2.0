using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.DoctorClinic;
using ClinicSystem.PatientForm;

namespace ClinicSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //List<Appointment> list = new List<Appointment>();
            //Patient p = new Patient(1, "ps", "ps", "ps", "ps", 5, "ps", DateTime.Now, "5454545454");
            //Doctor d = new Doctor(1, "ps", "ps", "ps", 5, "dfg", DateTime.Now, "5454545454", "5454545454", "5454545454");
            //Operation o = new Operation("casd", "ps", DateTime.Now, "ps", 5, TimeSpan.Parse("09:00:00"), "5454545454");
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount"));
            ////PrintDoctorReceipt pr = new PrintDoctorReceipt(p, list, "Reappointment");
            //PrintDoctorReceipt pr = new PrintDoctorReceipt(d,list);



           




            //pr.print();
            //Application.Run(pr);
            
            Application.Run(new LoginUserForm());
        }
    }
}
