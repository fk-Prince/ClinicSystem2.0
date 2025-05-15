using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.DoctorClinic;
using ClinicSystem.Entity;
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
            //PenaltyAppointment x = new PenaltyAppointment("Absent", 3000, "Sick", DateTime.Now);
            //Patient p = new Patient("P2025-000001", "Jake Juluis", "Maunas", "Maunas",
            //    "506 J.P. Laurel Ave, Poblacion District, Davao City, 8000 Davao del Sur", 22, "Male", DateTime.Now, "09771171913");
            //Doctor d = new Doctor("D2025-000001", "Prince Aeyc", "Iba", "Sestoso", 22, "0977", DateTime.Now, "Male", "Roxas Avenue Davao City", "09771171913");
            //Operation o = new Operation("DE44", "Dental Extraction", DateTime.Now, "lhjfgklh,jbgkljhcvklfghiocljioglvokdgfg",
            //    2000, TimeSpan.Parse("09:00:00"), "Examination Room");
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //    "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //    " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //    "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //    " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //                "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //                " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //                "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //                " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //                "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //                " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //                "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //                " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));
            //list.Add(new Appointment(p, d, o, DateTime.Now, DateTime.Now, 5000, 401, 2, 5000, "No Discount",
            //                "Patient diagnosed with Type 2 Diabetes Mellitus, presenting with elevated blood glucose levels and fatigue." +
            //                " Recommended lifestyle changes and initiation of metformin therapy.", DateTime.Now, "Ongoing", x));


            //PrintAppointmentReceipt pr = new PrintAppointmentReceipt(p, list, "Penalty");
            ////PrintDoctorReceipt pr = new PrintDoctorReceipt(d, list);
            //pr.print();
            //Application.Run(pr);

            Application.Run(new LoginUserForm());
        }
    }
}
