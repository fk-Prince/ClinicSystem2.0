using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Entity
{
    public class DoctorStats
    {

        private Doctor doctor;
        private int totalAppointments;
        private int totalPatient;
        private double totalRevenue;

        public DoctorStats(Doctor doctor, int totalPatient, int totalAppointments, double totalRevenue)
        {
            this.doctor = doctor;
            this.totalPatient = totalPatient;
            this.totalAppointments = totalAppointments;
            this.totalRevenue = totalRevenue;
        }

        public Doctor Doctor { get => doctor;  }
        public int TotalAppointments { get => totalAppointments; }
        public int TotalPatient { get => totalPatient;  }
        public double TotalRevenue { get => totalRevenue; }
    }
}
