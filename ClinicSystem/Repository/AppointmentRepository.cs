using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.Helpers;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Appointments
{
    public class AppointmentRepository
    {
        // List Rooms
        public List<Room> getRoomNo()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM Rooms_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Room room = new Room(reader.GetInt32("RoomNo"), reader["Roomtype"].ToString());
                                rooms.Add(room);
                            }
                        }
                    }               
                }         
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getRoomNo DB" + e.Message);
            }
            return rooms;
        }

        // List of appointment of doctor
        public List<Appointment> getAppointmentsbyDoctor(Doctor dr)
        {
            List<Appointment> list = new List<Appointment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                            SELECT * FROM patientappointment_tbl
                            LEFT JOIN patient_tbl 
                            ON patient_tbl.patientid = patientappointment_tbl.patientid
                            LEFT JOIN doctor_tbl
                            ON doctor_tbl.doctorId = patientappointment_tbl.doctorId
                            LEFT JOIN operation_tbl
                            ON operation_tbl.operationCode = patientappointment_tbl.OperationCode
                            LEFT JOIN appointmentdetails_tbl
                            ON appointmentdetails_tbl.AppointmentDetailNo = patientappointment_tbl.AppointmentDetailNo
                            WHERE patientappointment_tbl.DOCTORID = @DOCTORID";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("DOCTORID", dr.DoctorID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                list.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on get appointments() db" + ex.Message);
            }

            return list;
        }

        // Discount
        public List<Discount> getDiscounts()
        {
            List<Discount> list = new List<Discount>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();

                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM discount_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Discount discount = EntityMapping.GetDiscount(reader);
                                list.Add(discount);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON getDiscount()" + ex.Message);
            }
            return list;
        }

        // Discount
        public Discount getDiscountsbyType(string type)
        {
           
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM discount_tbl WHERE discounttype = @discounttype", conn))
                    {
                        command.Parameters.AddWithValue("discounttype", type);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return EntityMapping.GetDiscount(reader);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON getDiscount()" + ex.Message);
            }
            return null;
        }

        // Insert appointment
        public bool insertOnlyAppointment(List<Appointment> ap)
        {
            try
            {
               
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                { 
                    conn.Open();
                    insertAppointmentDetails(ap);
                    
                    //int patientid = 0;
                    string query = @"
                            INSERT INTO patientappointment_tbl 
                                (AppointmentDetailNo, PatientID, DoctorID, OperationCode, StartSchedule, EndSchedule, roomno)
                            VALUES 
                                (@AppointmentDetailNo, @PatientID, @DoctorID, @OperationCode, @StartSchedule, @EndSchedule, @roomno);";
                    foreach (Appointment op in ap)
                    {
                        //patientid = op.Patient.Patientid;
                       

                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
                            command.Parameters.AddWithValue("@PatientID", op.Patient.Patientid);
                            command.Parameters.AddWithValue("@DoctorID", op.Doctor.DoctorID);
                            command.Parameters.AddWithValue("@OperationCode", op.Operation.OperationCode);
                            command.Parameters.AddWithValue("@StartSchedule", op.StartTime);
                            command.Parameters.AddWithValue("@EndSchedule", op.EndTime);
                            command.Parameters.AddWithValue("@roomno", op.RoomNo);
                            command.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on addApoinment() db " + ex.Message);
            }
            return false;
        }

        // Insert appointmentdetail
        private void insertAppointmentDetails(List<Appointment> ap)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                            INSERT INTO appointmentdetails_tbl 
                                   (AppointmentDetailNo, Subtotal, TotalWithDiscount, DiscountType, BookingDate)
                            VALUES 
                                   (@AppointmentDetailNo, @Subtotal, @TotalWithDiscount, @DiscountType, @BookingDate)";
                    foreach (Appointment op in ap)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
                            command.Parameters.AddWithValue("@Subtotal", op.SubTotal.ToString("F2"));
                            command.Parameters.AddWithValue("@DiscountType", op.Discounttype);
                            command.Parameters.AddWithValue("@TotalWithDiscount", op.Total.ToString("F2"));
                            command.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                            command.ExecuteNonQuery();
                        }          
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR on insertAppointmentDetails() " + ex.Message);
            }
        }

        // Patient List
        public List<Patient> getPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM patient_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = EntityMapping.GetPatient(reader);
                                patients.Add(patient);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error from getPatients() db " + ex.Message);
            }
            return patients;
        }

        // Last Appointment Detail No
        public string getAppointmentDetail()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT AppointmentDetailNo FROM appointmentdetails_tbl ORDER BY AppointmentDetailNo DESC LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            int id = reader.Read() ? int.Parse(reader["AppointmentDetailNo"].ToString()) + 1 : 1;
                            return id.ToString();
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getAppointmentDetail DB" + e.Message);
            }
            return "0";
        }

        // Doctor List by Operation 
        public List<Doctor> getDoctors(Operation operation)
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
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

        // Operaetion List
        public List<Operation> getOperations()
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM Operation_Tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Operation operation = EntityMapping.GetOperation(reader);
                                operations.Add(operation);
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getOperations DB" + e.Message);
            }
            return operations;
        }


        // Appointment List
        public List<Appointment> getAppointment()
        {
            List<Appointment> active = new List<Appointment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();

                string query = @"
                            SELECT * FROM patientappointment_tbl 
                                LEFT JOIN patient_tbl ON patientappointment_tbl.patientID = patient_tbl.PatientID 
                                LEFT JOIN Operation_tbl ON patientappointment_tbl.OperationCode = Operation_tbl.OperationCode
                                LEFT JOIN Doctor_tbl ON patientappointment_tbl.DoctorID = Doctor_tbl.DoctorID
                                LEFT JOIN appointmentdetails_tbl ON patientappointment_tbl.appointmentdetailNo = appointmentdetails_tbl.appointmentdetailNo";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                active.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getActiveAppointment() DB " + ex.Message);
            }
            return active;
        }

        public List<Appointment> getReAppointment()
        {
            List<Appointment> active = new List<Appointment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();

                    string query = @"
                            SELECT * FROM patientappointment_tbl 
                                LEFT JOIN patient_tbl ON patientappointment_tbl.patientID = patient_tbl.PatientID 
                                LEFT JOIN Operation_tbl ON patientappointment_tbl.OperationCode = Operation_tbl.OperationCode
                                LEFT JOIN Doctor_tbl ON patientappointment_tbl.DoctorID = Doctor_tbl.DoctorID
                                LEFT JOIN appointmentdetails_tbl ON patientappointment_tbl.appointmentdetailNo = appointmentdetails_tbl.appointmentdetailNo
                                WHERE Status = 'Upcoming' AND StartSchedule >= NOW()";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                active.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getActiveAppointment() DB " + ex.Message);
            }
            return active;
        }

        // Appointment New Checker
        public bool isScheduleAvailable(Appointment appointment, string choice)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = "";
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;

                    switch (choice)
                    {
                        case "room":
                                    query = @"
                                    SELECT 1 FROM patientappointment_tbl
                                    WHERE RoomNo = @RoomNo AND (
                                        (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                        (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                    )";
                                    command.CommandText = query;
                                    command.Parameters.AddWithValue("@RoomNo", appointment.RoomNo);
                                    break;

                        case "doctor":
                                    query = @"
                                    SELECT 1 FROM patientappointment_tbl
                                    WHERE DoctorID = @DoctorID AND (
                                        (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                        (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                    )";
                                    command.CommandText = query;    
                                    command.Parameters.AddWithValue("@DoctorID", appointment.Doctor.DoctorID);
                                    break;

                        case "patient":
                                    query = @"
                                        SELECT 1 FROM patientappointment_tbl
                                        WHERE PatientID = @PatientID AND (
                                            (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                            (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                            (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                            (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                        )";
                                    command.CommandText = query;
                                    command.Parameters.AddWithValue("@PatientID", appointment.Patient.Patientid);
                                    break;

                        default:
                            return true; 
                    }
                   
                    command.Parameters.AddWithValue("@StartSchedule", appointment.StartTime);
                    command.Parameters.AddWithValue("@EndSchedule", appointment.EndTime);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        return !reader.HasRows;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error o isScheduleAvailable() DB " + ex.Message);
                return false;
            }
        }


        // Appointment ReSchedule Checker
        public bool isScheduleAvailableNotEqualAppointmentNo(Appointment appointment, string choice)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = "";
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;

                    switch (choice)
                    {
                        case "room":
                            query = @"
                                    SELECT 1 FROM patientappointment_tbl
                                    WHERE RoomNo = @RoomNo AND (
                                        (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                        (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                    ) AND AppointmentDetailNo != @AppointmentDetailNo";
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@RoomNo", appointment.RoomNo);
                            command.Parameters.AddWithValue("@AppointmentDetailNo", appointment.AppointmentDetailNo);
                            break;

                        case "doctor":
                            query = @"
                                    SELECT 1 FROM patientappointment_tbl
                                    WHERE DoctorID = @DoctorID AND (
                                        (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                        (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                        (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                    ) AND AppointmentDetailNo != @AppointmentDetailNo";
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@DoctorID", appointment.Doctor.DoctorID);
                            command.Parameters.AddWithValue("@AppointmentDetailNo", appointment.AppointmentDetailNo);
                            break;

                        case "patient":
                            query = @"
                                        SELECT 1 FROM patientappointment_tbl
                                        WHERE PatientID = @PatientID AND (
                                            (@StartSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                            (@EndSchedule BETWEEN StartSchedule AND EndSchedule) OR
                                            (StartSchedule BETWEEN @StartSchedule AND @EndSchedule) OR
                                            (EndSchedule BETWEEN @StartSchedule AND @EndSchedule)
                                        ) AND AppointmentDetailNo != @AppointmentDetailNo";
                            command.CommandText = query;
                            command.Parameters.AddWithValue("@PatientID", appointment.Patient.Patientid);
                            command.Parameters.AddWithValue("@AppointmentDetailNo", appointment.AppointmentDetailNo);
                            break;

                        default:
                            return true;
                    }

                    command.Parameters.AddWithValue("@StartSchedule", appointment.StartTime);
                    command.Parameters.AddWithValue("@EndSchedule", appointment.EndTime);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        return !reader.HasRows;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error o isScheduleAvailableNotEqualAppointmentNo() DB " + ex.Message);
                return false;
            }
        }

        // Update Reschedule
        public bool UpdateSchedule(Appointment app)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"UPDATE patientAppointment_tbl 
                                 SET `StartSchedule` = @StartSchedule, `EndSchedule` = @EndSchedule 
                                WHERE AppointmentDetailNo = @AppointmentDetailNo";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                        command.Parameters.AddWithValue("@StartSchedule", app.StartTime);
                        command.Parameters.AddWithValue("@EndSchedule", app.EndTime);
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


        // PATIENT INSERTION
        public bool insertPatientWithAppointment(int staffId, Patient patient,List<Appointment> appList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();

                    string query = "INSERT INTO patient_tbl (patientid, patientfirstname, patientmiddlename, patientlastname, address, age, gender, birthdate, contactnumber) " +
                                    "VALUES (@patientid, @patientfirstname, @patientmiddlename, @patientlastname, @address, @age, @gender, @birthdate, @contactnumber); ";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@patientid", patient.Patientid);
                        command.Parameters.AddWithValue("@patientfirstname", patient.Firstname);
                        command.Parameters.AddWithValue("@patientmiddlename", patient.Middlename);
                        command.Parameters.AddWithValue("@patientlastname", patient.Lastname);
                        command.Parameters.AddWithValue("@address", patient.Address);
                        command.Parameters.AddWithValue("@age", patient.Age);
                        command.Parameters.AddWithValue("@gender", patient.Gender);
                        command.Parameters.AddWithValue("@birthdate", patient.Birthdate.ToString("yyyy-MM-dd"));
                        if (!string.IsNullOrEmpty(patient.ContactNumber)) command.Parameters.AddWithValue("@contactnumber", patient.ContactNumber);
                        else command.Parameters.AddWithValue("@contactnumber", DBNull.Value);

                        command.ExecuteNonQuery();
                      
                        insertStaffPatient(patient.Patientid, staffId);
                    }
                }
                insertOnlyAppointment(appList);
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERRO ON INSERTPATIENT() DB " + ex.Message);
            }

            return false;
        }

        private void insertStaffPatient(string patientid, int staffId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
                {
                    conn.Open();
                    string query = "INSERT INTO patient_staff_tbl (staffid, patientid) VALUES (@staffid, @patientid)";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@staffid", staffId);
                        command.Parameters.AddWithValue("@patientid", patientid);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on insertStaffPatient() db" + ex.Message);
            }
        }

    }
}
