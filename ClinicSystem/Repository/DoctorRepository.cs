using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClinicSystem;
using ClinicSystem.Helpers;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using ClinicSystem.UserLoginForm;
using MySql.Data.MySqlClient;

namespace DoctorClinic
{
    public class DoctorRepository
    {

        public List<Doctor> getAvailableDoctors(Operation operaiton)
        {
            List<Doctor> availableDoctors = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                SELECT * FROM patientappointment_tbl
                                LEFT JOIN doctor_tbl ON doctor_tbl.doctorid = patientappointment_tbl.doctorid
                                LEFT JOIN operation_tbl ON operation_tbl.operationcode = patientappointment_tbl.OperationCode
                                LEFT JOIN patient_tbl ON patient_tbl.patientid = patientappointment_tbl.patientid
                                LEFT JOIN appointmentdetails_tbl ON appointmentdetails_tbl.AppointmentDetailNo = patientappointment_tbl.AppointmentDetailNo
                                WHERE patientappointment_tbl.StartSchedule BETWEEN @Start AND @End AND Status = 'Upcoming' AND EndSchedule > Now()
                                AND patientappointment_tbl.doctorid = @doctorid";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
           
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                availableDoctors.Add(EntityMapping.GetDoctor(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getTodayAppointmentByDoctor() db" + ex.Message);
            }
            return availableDoctors;
        }

        public List<Appointment> getTodayAppointmentByDoctor(string doctorid)
        {
            List<Appointment> todayAppointment = new List<Appointment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                              SELECT * FROM appointmentRecord_tbl
                                 LEFT JOIN patientappointment_tbl ON appointmentRecord_tbl.AppointmentRecordNo = patientappointment_tbl.AppointmentRecordNo
                                 LEFT JOIN patient_tbl ON patient_tbl.patientid = appointmentRecord_tbl.patientid
                                 LEFT JOIN doctor_tbl ON doctor_tbl.doctorId = patientappointment_tbl.doctorId
                                 LEFT JOIN operation_tbl ON operation_tbl.operationCode = patientappointment_tbl.OperationCode
                                 LEFT JOIN appointmentdetails_tbl ON appointmentdetails_tbl.AppointmentDetailNo = patientappointment_tbl.AppointmentDetailNo
                                WHERE patientappointment_tbl.StartSchedule BETWEEN @Start AND @End AND Status = 'Upcoming' AND EndSchedule > Now()
                                AND patientappointment_tbl.doctorid = @doctorid";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Start", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@End", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@doctorid", doctorid);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                todayAppointment.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getTodayAppointmentByDoctor() db" + ex.Message);
            }
            return todayAppointment;
        }

        public Dictionary<Doctor, Operation> getDoctorOperations()
        {
            Dictionary <Doctor, Operation> doctorOperation = new Dictionary<Doctor, Operation>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"SELECT * FROM doctor_operation_mm_tbl
                        LEFT JOIN doctor_tbl ON doctor_operation_mm_tbl.DoctorID = doctor_tbl.DoctorID  
                        LEFT JOIN operation_tbl ON doctor_operation_mm_tbl.OperationCode = operation_tbl.OperationCode
                        ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor d = EntityMapping.GetDoctorWithImage(reader);
                                Operation o = EntityMapping.GetOperation(reader);
                                doctorOperation.Add(d, o);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctorOperation() db" + ex.Message);   
            }
            return doctorOperation;
        }
        public List<Appointment> getPatientByDoctor(string doctorID)
        {
            List<Appointment> appointments = new List<Appointment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                         SELECT * FROM appointmentRecord_tbl
                         LEFT JOIN patientappointment_tbl ON appointmentRecord_tbl.AppointmentRecordNo = patientappointment_tbl.AppointmentRecordNo
                         LEFT JOIN patient_tbl ON patient_tbl.patientid = appointmentRecord_tbl.patientid
                         LEFT JOIN doctor_tbl ON doctor_tbl.doctorId = patientappointment_tbl.doctorId
                         LEFT JOIN operation_tbl ON operation_tbl.operationCode = patientappointment_tbl.OperationCode
                         LEFT JOIN appointmentdetails_tbl ON appointmentdetails_tbl.AppointmentDetailNo = patientappointment_tbl.AppointmentDetailNo
                         WHERE patientappointment_tbl.DoctorId = @DoctorID";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("DoctorID", doctorID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointments.Add(EntityMapping.GetAppointmentByDoctor(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from getPati ents() DB" + ex.Message);
            }
            return appointments;
        }
        public bool setDiagnosis(Appointment updatedSchedule)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"UPDATE appointmentdetails_tbl 
                                 SET `Diagnosis` = @Diagnosis, `Prescription` = @Prescription
                                WHERE AppointmentDetailNo = @AppointmentDetailNo";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Diagnosis", updatedSchedule.Diagnosis);
                        command.Parameters.AddWithValue("@AppointmentDetailNo", updatedSchedule.AppointmentDetailNo);
                        command.Parameters.AddWithValue("@Prescription", updatedSchedule.Prescription);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from updateSchedule() DB" + ex.Message);
            }
            return false;
        }
        public List<Doctor> getDoctors()
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM doctor_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = EntityMapping.GetDoctorWithImage(reader);
                                doctorList.Add(doctor);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctors() db" + ex.Message);
            }
            return doctorList;
        }
        public List<Doctor> getDoctorsByOperation(Operation operation)
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                        SELECT *, doctor_tbl.* FROM doctor_operation_mm_tbl
                        LEFT JOIN doctor_tbl 
                        ON doctor_operation_mm_tbl.DoctorID = doctor_tbl.DoctorID
                        WHERE operationcode = @operationcode AND doctor_tbl.Active = 'Yes' 
                        ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@operationcode", operation.OperationCode);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = EntityMapping.GetDoctor(reader);
                                doctorList.Add(doctor);
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getDoctors DB" + e.Message);
            }
            return doctorList;
        }
        public bool AddDoctor(Doctor doctor)
        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();


                    string query = @"INSERT INTO doctor_tbl 
                    (DoctorID, doctorFirstName, doctorMiddleName, doctorLastName, doctorAge, Pin, doctorDateHired, 
                        doctorGender, doctorAddress, doctorcontactnumber, doctorImage, doctorRFID) 
                 VALUES 
                    (@DoctorID, @doctorFirstName, @doctorMiddleName, @doctorLastName, @doctorAge, @Pin, @doctorDateHired,
                        @doctorGender, @doctorAddress, @doctorcontactnumber, @doctorImage, @doctorRFID)";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                        command.Parameters.AddWithValue("@doctorFirstName", doctor.DoctorFirstName);
                        command.Parameters.AddWithValue("@doctorMiddleName", doctor.DoctorMiddleName);
                        command.Parameters.AddWithValue("@doctorLastName", doctor.DoctorLastName);
                        command.Parameters.AddWithValue("@doctorAge", doctor.DoctorAge);
                        command.Parameters.AddWithValue("@doctorDateHired", doctor.DateHired);
                        command.Parameters.AddWithValue("@doctorGender", doctor.Gender);
                        command.Parameters.AddWithValue("@doctorAddress", doctor.DoctorAddress);
                        command.Parameters.AddWithValue("@doctorcontactnumber", doctor.DoctorContactNumber);
                        if (doctor.DoctorRFID.Length == 0)
                        {
                            command.Parameters.AddWithValue("@doctorRFID", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@doctorRFID", doctor.DoctorRFID);
                        }
                        command.Parameters.AddWithValue("@Pin", doctor.Pin);

                        if (doctor.Image != null)
                        {
                            MemoryStream ms = new MemoryStream();
                            doctor.Image.Save(ms, doctor.Image.RawFormat);
                            byte[] doctorImage = ms.ToArray();
                            command.Parameters.Add("@doctorImage", MySqlDbType.LongBlob).Value = doctorImage;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@doctorImage", DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on AddDoctor() db: " + ex.Message );
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error on AddDoctor() IO: " + ex.Message);
            }
            
            return false;
        }   
        public string getDoctorLastID()
        {       
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT doctorid FROM doctor_tbl ORDER BY doctorid DESC LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            

                            return reader.Read()
                                    ? "D" + DateTime.Now.ToString("yyyy") + "-" + checkID(reader.GetString("doctorID"))
                                    : "D" + DateTime.Now.ToString("yyyy") + "-000001";
                            
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctorLastID() db" + ex.Message);
            }
            return "ERROR ON DATABASE PLEASE TRY AGAIN";
        }
        public string checkID(string n)
        {
            int number = int.Parse(n.Substring(6)) + 1;
            if (number < 1000000) return number.ToString("D6");
            else return number.ToString();
        }
        public Doctor doctorLogin(string doctorid, string pin)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT * FROM doctor_tbl WHERE PIN = @PIN AND DOCTORID = @DOCTORID";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DOCTORID", doctorid);
                        command.Parameters.AddWithValue("@PIN", pin);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Image doctorImage;
                                if (!reader.IsDBNull(reader.GetOrdinal("doctorImage")))
                                {
                                    byte[] imageBytes = (byte[])reader["doctorImage"];
                                    MemoryStream ms = new MemoryStream(imageBytes);
                                    doctorImage = Image.FromStream(ms);
                                }
                                else
                                {
                                    doctorImage = null;
                                }
                                Doctor doctor = EntityMapping.GetDoctorWithImage(reader);
                                return doctor;
                            }
                        }
                    }
                }
            } catch (MySqlException ex)
            {
                MessageBox.Show("Error on doctorLogin() db" + ex.Message);
            }
            return null;
        }
        public Doctor doctorScanned(string rfid)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT * FROM doctor_tbl WHERE doctorRFID = @doctorRFID LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@doctorRFID", rfid);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                Doctor doctor = EntityMapping.GetDoctorWithImage(reader);
                                return doctor;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on doctorLogin() db" + ex.Message);
            }
            return null;
        }
        public bool setPatientDischarged(int appointmentDetailNo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "UPDATE patientappointment_tbl SET Status = 'Discharged' WHERE AppointmentDetailNo = @AppointmentDetailNo";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@AppointmentDetailNo", appointmentDetailNo);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on setComplete() db" + ex.Message);
            }
            return false;
        }
        public void updateDoctorStatus(string doctorID, string active)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        "UPDATE doctor_tbl SET Active = @Active WHERE doctorid = @doctorid";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Active", active);
                        command.Parameters.AddWithValue("@doctorId", doctorID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM insertSpecialized() DB " + ex.Message);
            }
        }
    }
}
