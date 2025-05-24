using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.Helpers;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Appointments
{
    public class AppointmentRepository
    {

        // List of appointment of doctor
        public List<Appointment> getAppointmentsbyDoctor(Doctor dr)
        {
            List<Appointment> list = new List<Appointment>();
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

        // Insert appointment
        public bool insertAppointment(long id ,List<Appointment> ap)
        {
            try
            {
               
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                { 
                    conn.Open();
                    insertAppointmentDetails(ap);
                    
                    string query = @"
                            INSERT INTO patientappointment_tbl 
                                (AppointmentRecordNo, AppointmentDetailNo, DoctorID, OperationCode, StartSchedule, EndSchedule, roomno)
                            VALUES 
                                (@AppointmentRecordNo, @AppointmentDetailNo, @DoctorID, @OperationCode, @StartSchedule, @EndSchedule, @roomno);";
                    foreach (Appointment op in ap)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@AppointmentRecordNo", id);
                            command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
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
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                            INSERT INTO appointmentdetails_tbl 
                                   (AppointmentDetailNo, Subtotal)
                            VALUES 
                                   (@AppointmentDetailNo, @Subtotal)";
                    foreach (Appointment op in ap)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
                            command.Parameters.AddWithValue("@Subtotal", op.SubTotal.ToString("F2"));
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

        // Last Appointment Detail No
        public string getAppointmentDetail()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
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



        // Appointment List
        public List<Appointment> getAppointment()
        {
            List<Appointment> active = new List<Appointment>();
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
                            LEFT JOIN appointmentdetails_tbl ON appointmentdetails_tbl.AppointmentDetailNo = patientappointment_tbl.AppointmentDetailNo";

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
                                  WHERE Status = 'Upcoming' OR Status = 'Reappointment' AND DATE(StartSchedule) < CURDATE() - INTERVAL 3 DAY";

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
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
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
                                        LEFT JOIN AppointmentRecord_tbl ON AppointmentRecord_tbl.AppointmentRecordNo =  patientappointment_tbl.AppointmentRecordNo
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
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
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
                                        LEFT JOIN AppointmentRecord_tbl ON AppointmentRecord_tbl.AppointmentRecordNo =  patientappointment_tbl.AppointmentRecordNo
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
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
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
        public bool insertAppointment(int staffId, Patient patient, List<Appointment> appList, string type)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (type.Equals("INSERT PATIENT"))
                            {
                                // Insert patient_tbl
                                string query = @"
                                                INSERT INTO patient_tbl 
                                                    (patientid, patientfirstname, patientmiddlename, patientlastname, address, age, gender, birthdate, contactnumber) 
                                                VALUES 
                                                    (@patientid, @patientfirstname, @patientmiddlename, @patientlastname, @address, @age, @gender, @birthdate, @contactnumber);";

                                using (MySqlCommand command = new MySqlCommand(query, conn, transaction))
                                {
                                    command.Parameters.AddWithValue("@patientid", patient.Patientid);
                                    command.Parameters.AddWithValue("@patientfirstname", patient.Firstname);
                                    command.Parameters.AddWithValue("@patientmiddlename", patient.Middlename);
                                    command.Parameters.AddWithValue("@patientlastname", patient.Lastname);
                                    command.Parameters.AddWithValue("@address", patient.Address);
                                    command.Parameters.AddWithValue("@age", patient.Age);
                                    command.Parameters.AddWithValue("@gender", patient.Gender);
                                    command.Parameters.AddWithValue("@birthdate", patient.Birthdate.ToString("yyyy-MM-dd"));
                                    command.Parameters.AddWithValue("@contactnumber", string.IsNullOrEmpty(patient.ContactNumber) ? DBNull.Value : (object)patient.ContactNumber);

                                    command.ExecuteNonQuery();
                                }
                            }

                            // Insert appointmentrecord_tbl
                            string query2 = @"
                                            INSERT INTO appointmentrecord_tbl 
                                                (staffid, patientid, discounttype, Bookingdate, TotalWithDiscount) 
                                            VALUES 
                                                (@staffid, @patientid, @discounttype, @Bookingdate, @TotalWithDiscount); 
                                            SELECT LAST_INSERT_ID();";

                            long appointmentRecordId;
                            using (MySqlCommand command = new MySqlCommand(query2, conn, transaction))
                            {
                                command.Parameters.AddWithValue("@staffid", staffId);
                                command.Parameters.AddWithValue("@patientid", patient.Patientid);
                                command.Parameters.AddWithValue("@discounttype", appList[0].Discounttype);
                                command.Parameters.AddWithValue("@Bookingdate", DateTime.Now);
                                command.Parameters.AddWithValue("@TotalWithDiscount", appList.Sum(e => e.Total));

                                appointmentRecordId = Convert.ToInt64(command.ExecuteScalar());
                            }

                            // Insert appointmentdetails_tbl
                            string query3 = @" 
                                                INSERT INTO appointmentdetails_tbl 
                                                    (AppointmentDetailNo, Subtotal) 
                                                VALUES 
                                                    (@AppointmentDetailNo, @Subtotal)";

                            foreach (Appointment op in appList)
                            {
                                using (MySqlCommand command = new MySqlCommand(query3, conn, transaction))
                                {
                                    command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
                                    command.Parameters.AddWithValue("@Subtotal", op.SubTotal.ToString("F2"));

                                    command.ExecuteNonQuery();
                                }
                            }

                            // Insert patientappointment_tbl
                            string query4 = @"
                                            INSERT INTO patientappointment_tbl 
                                                (AppointmentRecordNo, AppointmentDetailNo, DoctorID, OperationCode, StartSchedule, EndSchedule, roomno) 
                                            VALUES 
                                                (@AppointmentRecordNo, @AppointmentDetailNo, @DoctorID, @OperationCode, @StartSchedule, @EndSchedule, @roomno);";

                            foreach (Appointment op in appList)
                            {
                                using (MySqlCommand command = new MySqlCommand(query4, conn, transaction))
                                {
                                    command.Parameters.AddWithValue("@AppointmentRecordNo", appointmentRecordId);
                                    command.Parameters.AddWithValue("@AppointmentDetailNo", op.AppointmentDetailNo);
                                    command.Parameters.AddWithValue("@DoctorID", op.Doctor.DoctorID);
                                    command.Parameters.AddWithValue("@OperationCode", op.Operation.OperationCode);
                                    command.Parameters.AddWithValue("@StartSchedule", op.StartTime);
                                    command.Parameters.AddWithValue("@EndSchedule", op.EndTime);
                                    command.Parameters.AddWithValue("@roomno", op.RoomNo);

                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("TRANSACTION ROLLED BACK: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON insertPatient() DB: " + ex.Message);
                return false;
            }
        }

        private void insertRecord(string patientid, int staffId, List<Appointment> appList)
        {
            try
            {
                long insertedId;
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "INSERT INTO appointmentrecord_tbl (staffid, patientid, discounttype, Bookingdate, TotalWithDiscount) " +
                             "VALUES (@staffid, @patientid, @discounttype, @Bookingdate, @TotalWithDiscount); " +
                             "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@staffid", staffId);
                        command.Parameters.AddWithValue("@patientid", patientid);
                        command.Parameters.AddWithValue("@discounttype", appList[0].Discounttype);
                        command.Parameters.AddWithValue("@Bookingdate", DateTime.Now);
                        command.Parameters.AddWithValue("@TotalWithDiscount", appList.Sum(e => e.Total));
                        insertedId = Convert.ToInt64(command.ExecuteScalar());
                    }

                    insertAppointment(insertedId,appList);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on insertRecord() db" + ex.Message);
            }
        }


        // MISSED APPOINTMENT
        public List<Appointment> getMissedAppointments()
        {
            List<Appointment> miseed = new List<Appointment>();
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
                         WHERE Status = 'Absent' AND EndSchedule BETWEEN CURRENT_DATE - INTERVAL 7 DAY AND NOW()";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                miseed.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getMissedAppointments() DB " + ex.Message);
            }
            return miseed;
        }
        public bool penaltyAppointment(Appointment app)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"UPDATE patientAppointment_tbl 
                                 SET `Status` = 'Reappointment', `StartSchedule` = @StartSchedule, `EndSchedule` = @EndSchedule 
                                WHERE AppointmentDetailNo = @AppointmentDetailNo";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                        command.Parameters.AddWithValue("@StartSchedule", app.StartTime);
                        command.Parameters.AddWithValue("@EndSchedule", app.EndTime);
                        command.ExecuteNonQuery();
                        insertPenalty(app);
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from penaltyAppointment() DB" + ex.Message);
            }
            return false;
        }
        private void insertPenalty(Appointment app)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                            INSERT INTO appointmentpenalty_tbl (AppointmentDetailNo, PenaltyType, Amount, Reason, DateIssued) 
                            VALUES (@AppointmentDetailNo, @PenaltyType, @Amount, @Reason, @DateIssued)";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                        command.Parameters.AddWithValue("@Amount", app.PenaltyAppointment.PenaltyAmount);
                        command.Parameters.AddWithValue("@Reason", app.PenaltyAppointment.PenaltyReason);
                        command.Parameters.AddWithValue("@DateIssued", app.PenaltyAppointment.PenaltyDate);
                        command.Parameters.AddWithValue("@PenaltyType", app.PenaltyAppointment.PenaltyType);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from insertPenalty() DB" + ex.Message);
            }       
        }

        internal List<Doctor> getAvailableDoctors(Operation selectedOperation, string startSchedule, string endSchedule)
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                            SELECT distinct doctor_tbl.* FROM doctor_tbl 
                                LEFT JOIN doctor_operation_mm_tbl ON doctor_tbl.doctorid = doctor_operation_mm_tbl.doctorid
                            WHERE doctor_operation_mm_tbl.operationcode = @OperationCode AND doctor_tbl.Active = 'Yes' AND doctor_operation_mm_tbl.doctorid NOT IN (
	                            SELECT  
                                    patientappointment_tbl.doctorid 
                                FROM patientappointment_tbl
                                WHERE 
                                    (@StartTime BETWEEN StartSchedule AND EndSchedule) OR
                                    (@EndTime  BETWEEN StartSchedule AND EndSchedule) OR
                                    (StartSchedule BETWEEN @StartTime AND @EndTime ) OR
                                    (EndSchedule BETWEEN @StartTime  AND @EndTime)
                            )
                            ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@OperationCode", selectedOperation.OperationCode);
                        command.Parameters.AddWithValue("@StartTime", startSchedule);
                        command.Parameters.AddWithValue("@EndTime", endSchedule);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                doctorList.Add(EntityMapping.GetDoctor(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from getAvailableDoctors() DB" + ex.Message);
            }
         
            return doctorList;
        }

        public List<Room> getRoomAvailable(Operation selectedOperation, string startSchedule, string endSchedule)
        {
            List<Room> roomAvailable = new List<Room>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"               
                            SELECT DISTINCT rooms_tbl.* FROM rooms_tbl
                                LEFT JOIN operation_tbl on operation_tbl.roomtype = rooms_tbl.roomtype
                                LEFT JOIN doctor_operation_mm_tbl ON doctor_operation_mm_tbl.operationcode = operation_tbl.operationcode
                                LEFT JOIN patientappointment_tbl ON patientappointment_tbl.RoomNo = rooms_tbl.roomNo
                            WHERE operation_tbl.operationcode = @OperationCode AND rooms_tbl.roomNo NOT IN (
	                            SELECT 
                                    patientappointment_tbl.roomno 
                                FROM patientappointment_tbl
                                WHERE 
                                    (@StartTime BETWEEN StartSchedule AND EndSchedule) OR
                                    (@EndTime  BETWEEN StartSchedule AND EndSchedule) OR
                                    (StartSchedule BETWEEN @StartTime  AND @EndTime ) OR
                                    (EndSchedule BETWEEN @StartTime  AND @EndTime )
                            )
                            ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@OperationCode", selectedOperation.OperationCode);
                        command.Parameters.AddWithValue("@StartTime", startSchedule);
                        command.Parameters.AddWithValue("@EndTime", endSchedule);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Room room = new Room(reader.GetInt32("roomno"), reader.GetString("roomtype"));
                                roomAvailable.Add(room);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from getRoomAvailable() DB" + ex.Message);
            }

            return roomAvailable;
        }

        internal void setDiscount()
        {
           try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"               
                                INSERT INTO discount_tbl (DiscountType , DiscountRate, DiscountDescription) 
                                  VALUES
                               (@DiscountType , @DiscountRate, @DiscountDescription);
                            ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DiscountType","No Discount");
                        command.Parameters.AddWithValue("@DiscountRate", "0.000");
                        command.Parameters.AddWithValue("@DiscountDescription", "No Discount");
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from setDiscount() DB" + ex.Message);
            }
        }
    }
}
