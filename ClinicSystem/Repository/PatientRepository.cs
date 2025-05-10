using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using ClinicSystem.Helpers;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using ClinicSystem.Rooms;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public class PatientRepository
    {
        public List<Patient> getPatient()
        {
            List<Patient> patientList = new List<Patient>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM patient_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                patientList.Add(EntityMapping.GetPatient(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error ON getPatient() DB" + ex.Message);
            }
            return patientList;
        }

        public string checkID(string n)
        {
            
            int number = int.Parse(n.Substring(6)) + 1;
            if (number < 1000000) return number.ToString("D6"); 
            else return number.ToString(); 
        }

        public string getPatientId()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT patientid FROM patient_tbl ORDER BY patientId DESC LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            return reader.Read()
                             ? "P" + DateTime.Now.ToString("yyyy") + "-" + checkID(reader.GetString("PatientID"))
                             : "P" + DateTime.Now.ToString("yyyy") + "-000001";
                        }
                    }
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON patientid() DB" + ex.Message);
            }
            return "ERROR ON DATABASE PLEASE TRY AGAIN";
        }   
    }
}