using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicSystem.Entity;
using ClinicSystem.PatientForm;

namespace ClinicSystem
{
    public class Appointment
    {

        private Doctor doctor;
        private Patient patient;
        private Operation operation;
        private PenaltyAppointment penaltyAppointment;
        private double subtotal;
        private int roomno;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime bookingDate;


        private int appointmentDetailNo;
        private double total;
        private string discounttype;
        private string diagnosis;
        private string status;
        private string prescription;


        public Appointment(Patient patient,
           Doctor doctor, Operation operation,
           DateTime startTime, DateTime endTime, double subtotal,
           int roomno, int appointmentDetailNo, double total, string discounttype, string diagnosis, DateTime bookingDate,string status,string prescription)
        {
            this.patient = patient;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctor = doctor;
            this.roomno = roomno;
            this.operation = operation;
            this.subtotal = subtotal;
            this.appointmentDetailNo = appointmentDetailNo;
            this.total = total;
            this.discounttype = discounttype;
            this.diagnosis = diagnosis;
            this.bookingDate = bookingDate;
            this.status = status;
            this.prescription = prescription;
        }

        public Appointment(Patient patient,
         Doctor doctor, Operation operation,
         DateTime startTime, DateTime endTime, double subtotal,
         int roomno, int appointmentDetailNo)
        {
            this.patient = patient;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctor = doctor;
            this.roomno = roomno;
            this.operation = operation;
            this.subtotal = subtotal;
            this.appointmentDetailNo = appointmentDetailNo;;
        }

        public Appointment(Patient patient,
           Operation operation,
           DateTime startTime, DateTime endTime, double subtotal,
           int roomno, int appointmentDetailNo, double total, string discounttype, string diagnosis, DateTime bookingDate, string status, string prescription)
        {
            this.patient = patient;
            this.startTime = startTime;
            this.endTime = endTime;
            this.roomno = roomno;
            this.operation = operation;
            this.subtotal = subtotal;
            this.appointmentDetailNo = appointmentDetailNo;
            this.total = total;
            this.discounttype = discounttype;
            this.diagnosis = diagnosis;
            this.bookingDate = bookingDate;
            this.prescription = prescription;
            this.status = status;
        }

 

        public Appointment(Patient patient,
           Doctor doctor, Operation operation,
           DateTime startTime, DateTime endTime, double subtotal,
           int roomno, int appointmentDetailNo, double total, string discounttype, string diagnosis, DateTime bookingDate, string status, PenaltyAppointment penaltyAppointment)
        {
            this.patient = patient;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctor = doctor;
            this.roomno = roomno;
            this.operation = operation;
            this.subtotal = subtotal;
            this.appointmentDetailNo = appointmentDetailNo;
            this.total = total;
            this.discounttype = discounttype;
            this.diagnosis = diagnosis;
            this.bookingDate = bookingDate;
            this.status = status;
            this.penaltyAppointment = penaltyAppointment;
        }



        public PenaltyAppointment PenaltyAppointment { get => penaltyAppointment; }
        public Doctor Doctor { get => doctor; }
        public Operation Operation { get => operation; }
        public Patient Patient { get => patient; }

        public DateTime StartTime { get => startTime; }
        public DateTime EndTime { get => endTime; }

        public DateTime BookingDate { get => bookingDate; }

        public double SubTotal { get => subtotal;  }
        public string Status { get => status; }
        public string Discounttype { get => discounttype; }

        public string Prescription { get => prescription; }
        public int RoomNo { get => roomno; }
        public string Diagnosis { get => diagnosis; }
        public int AppointmentDetailNo { get => appointmentDetailNo; }
        public double Total { get => total; }
    }
}