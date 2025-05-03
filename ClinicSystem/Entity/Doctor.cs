using System;
using System.Drawing;

namespace ClinicSystem
{
    public class Doctor
    {
        private string doctorID;
        private string doctorFirstName;
        private string doctorMiddleName;
        private string doctorLastName;
        private int doctorAge;
        private string pin;
        private DateTime dateHired;
        private string gender;
        private string address;
        private string contactnumber;
        private Image image;
        private string doctorRFID;
        private bool active;

        public Doctor(string doctorID, string doctorFirstName, string doctorMiddleName, string doctorLastName,
            int doctorAge, string pin, DateTime dateHired, string gender, string address, string contactnumber)
        {
            this.address = address;
            this.doctorID = doctorID;
            this.doctorFirstName = doctorFirstName;
            this.doctorMiddleName = doctorMiddleName;
            this.doctorLastName = doctorLastName;
            this.doctorAge = doctorAge;
            this.pin = pin;
            this.dateHired = dateHired;
            this.gender = gender;
            this.contactnumber = contactnumber;
        }

        public Doctor(string doctorID, string doctorFirstName, string doctorMiddleName, string doctorLastName,
            int doctorAge, string pin, DateTime dateHired, string gender, string address, string contactnumber, Image image,bool active)
        {
            this.address = address;
            this.doctorID = doctorID;
            this.doctorFirstName = doctorFirstName;
            this.doctorMiddleName = doctorMiddleName;
            this.doctorLastName = doctorLastName;
            this.doctorAge = doctorAge;
            this.pin = pin;
            this.dateHired = dateHired;
            this.gender = gender;
            this.contactnumber = contactnumber;
            this.image = image;
            this.active = active;
        }

        public Doctor(string doctorID, string doctorFirstName, string doctorMiddleName, string doctorLastName,
            int doctorAge, string pin, DateTime dateHired, string gender, string address, string contactnumber, Image image, string doctorRFID)
        {
            this.address = address;
            this.doctorID = doctorID;
            this.doctorFirstName = doctorFirstName;
            this.doctorMiddleName = doctorMiddleName;
            this.doctorLastName = doctorLastName;
            this.doctorAge = doctorAge;
            this.pin = pin;
            this.dateHired = dateHired;
            this.gender = gender;
            this.contactnumber = contactnumber;
            this.image = image;
            this.doctorRFID = doctorRFID;
        }
        public bool DoctorActive { get => active; }
        public string DoctorRFID { get => doctorRFID; }
        public Image Image {   get => image;  }
        public string DoctorContactNumber { get => contactnumber; }
        public string DoctorAddress { get => address; }
        public string DoctorID { get => doctorID; }
        public string DoctorFirstName { get => doctorFirstName; }
        public string DoctorMiddleName { get => doctorMiddleName; }
        public string DoctorLastName { get => doctorLastName; }
        public int DoctorAge { get => doctorAge; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime DateHired { get => dateHired; }
        public string Gender { get => gender; }
    }
}