using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Entity
{
    public class PenaltyAppointment
    {
        private string penaltyType;
        private double penaltyAmount;
        private string penaltyReason; 
        private DateTime dateIssued;

        public PenaltyAppointment(string penaltyType, double penaltyAmount, string penaltyReason, DateTime dateIssued)
        {
            this.penaltyType = penaltyType;
            this.penaltyAmount = penaltyAmount;
            this.penaltyReason = penaltyReason;
            this.dateIssued = dateIssued;
        }

        public string PenaltyType { get => penaltyType; }
        public double PenaltyAmount { get => penaltyAmount; }
        public string PenaltyReason { get => penaltyReason;  }
        public DateTime PenaltyDate { get => dateIssued; }
    }
}
