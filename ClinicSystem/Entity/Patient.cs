using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.PatientForm
{
    public class Patient
    {

        private string patientid;
        private string firstname;
        private string middlename;
        private string lastname;
        private string address;
        private int age;
        private string gender;
        private DateTime birthdate;
        private string contactNumber;

        public Patient(string firstname, string middlename, string lastname, string address, int age, string gender, DateTime birthdate, string contactNumber)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.address = address;
            this.age = age;
            this.gender = gender;
            this.birthdate = birthdate;
            this.contactNumber = contactNumber;
        }

        public Patient(string patientid, string firstname, string middlename, string lastname, string address, int age, string gender, DateTime birthdate, string contactNumber)
        {
            this.patientid = patientid;
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.address = address;
            this.age = age;
            this.gender = gender;
            this.birthdate = birthdate;
            this.contactNumber = contactNumber;
        }



        public string Patientid { get => patientid; }
        public string Firstname { get => firstname; }
        public string Middlename { get => middlename; }
        public string Lastname { get => lastname;  }
        public string Address { get => address; }
        public int Age { get => age;  }
        public string Gender { get => gender;}
        public DateTime Birthdate { get => birthdate; }
        public string ContactNumber { get => contactNumber; }
    }
}
