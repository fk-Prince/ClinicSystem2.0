using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClinicSystem.PatientForm;
using ClinicSystem.Rooms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Appointments
{
    public class AppointmentDatabase
    {
        private string driver = "server=localhost;username=root;pwd=root;database=db_clinic";


        //public bool isRoomAvailable(int roomno, DateTime selectedDate, TimeSpan startTime, TimeSpan endTime, int appointmentDetailNo)
        //{
        //    try
        //    {
        //        MySqlConnection conn = new MySqlConnection(driver);
        //        conn.Open();
        //        //string query = @"SELECT patientappointment_tbl.* 
        //        //             FROM patientappointment_tbl  
        //        //             JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId 
        //        //             WHERE Roomno = @Roomno 
        //        //             AND 
        //        //            (                             
        //        //                (patientappointment_tbl.DateSchedule = @DateSchedule 
        //        //                 AND patientappointment_tbl.StartTime < @EndTime 
        //        //                 AND patientappointment_tbl.EndTime > @StartTime)
        //        //                OR 
        //        //                (patientappointment_tbl.DateSchedule < @DateSchedule 
        //        //                 AND patientappointment_tbl.EndTime > @StartTime)
        //        //                OR 
        //        //                (patientappointment_tbl.DateSchedule > @DateSchedule 
        //        //                 AND patientappointment_tbl.StartTime < @EndTime)
        //        //            )";
        //        //MySqlCommand command = new MySqlCommand(query, conn);
        //        //command.Parameters.AddWithValue("@Roomno", roomno);
        //        //command.Parameters.AddWithValue("@DateSchedule", selectedDate.ToString("yyyy-MM-dd"));
        //        //command.Parameters.AddWithValue("@StartTime", startTime);
        //        //command.Parameters.AddWithValue("@EndTime", endTime);
        //        //command.Parameters.AddWithValue("@AppointmentDetailNo", appointmentDetailNo);

        //        string query = $@"SELECT * FROM patientappointment_tbl 
        //                        JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId 
        //                        WHERE Roomno = @Roomno 
        //                        AND
        //                        (patientappointment_tbl.DateSchedule = @DateSchedule
        //                        AND patientappointment_tbl.StartTime < @EndTime
        //                        AND patientappointment_tbl.EndTime > @StartTime)
        //                         OR(
        //                            CONCAT(patientappointment_tbl.DateSchedule, ' ', patientappointment_tbl.StartTime) < @DateTimeEnd
        //                            AND CONCAT(patientappointment_tbl.DateSchedule, ' ', patientappointment_tbl.EndTime) > @DateTimeStart
        //                        )  AND AppointmentDetailNo != @AppointmentDetailNo";


        //        MySqlCommand command = new MySqlCommand(query, conn);
        //        command.Parameters.AddWithValue("@Roomno", roomno);
        //        command.Parameters.AddWithValue("@DateSchedule", selectedDate.ToString("yyyy-MM-dd"));
        //        command.Parameters.AddWithValue("@StartTime", startTime);
        //        command.Parameters.AddWithValue("@EndTime", endTime);
        //        command.Parameters.AddWithValue("@DateTimeStart", selectedDate.ToString("yyyy-MM-dd") + startTime);
        //        command.Parameters.AddWithValue("@DateTimeEnd", selectedDate.ToString("yyyy-MM-dd") + endTime);
        //        command.Parameters.AddWithValue("@AppointmentDetailNo", appointmentDetailNo);
        //        MySqlDataReader reader = command.ExecuteReader();
        //        return !reader.HasRows;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("ERROR ON isRoomAvailable() DB" + ex.Message);
        //    }
        //    return false;
        //}
        public List<Room> getRoomNo()
        {
            List<Room> rooms = new List<Room>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Rooms_tbl", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Room room = new Room(reader.GetInt32("RoomNo"), reader["Roomtype"].ToString());
                    rooms.Add(room);
                }
                conn.Close();
                reader.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getRoomNo DB" + e.Message);
            }
            return rooms;
        }
        public List<Appointment> getAppointments()
        {
            List<Appointment> list = new List<Appointment>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = @"SELECT patient_tbl.*, patientappointment_tbl.*, doctor_tbl.*, operation_tbl.*, clinichistory_tbl.* FROM patient_tbl
                                    LEFT JOIN patientappointment_tbl 
                                    ON patientappointment_tbl.patientId = patient_tbl.patientId
                                    LEFT JOIN doctor_operation_mm_tbl
                                    ON doctor_operation_mm_tbl.doctoroperationid = patientappointment_tbl.doctorOperationID
                                    LEFT JOIN doctor_tbl
                                    ON doctor_tbl.doctorId = doctor_operation_mm_tbl.doctorId
                                    LEFT JOIN operation_tbl
                                    ON operation_tbl.operationCode = doctor_operation_mm_tbl.OperationCode
                                    LEFT JOIN clinichistory_tbl
                                    ON clinichistory_tbl.patientid = patient_tbl.patientid
                                    WHERE patientappointment_tbl.AppointmentDetailNo IS NOT NULL";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Patient patient = new Patient(
                            reader.GetInt32("patientid"),
                            reader.GetString("patientfirstname"),
                            reader.GetString("patientmiddlename"),
                            reader.GetString("patientlastname"),
                            reader.GetString("address"),
                            reader.GetInt32("age"),
                            reader.GetString("gender"),
                            reader.GetDateTime("birthdate"),
                            reader.IsDBNull(reader.GetOrdinal("contactnumber")) ? "N/A" : reader.GetString("contactnumber")
                        );



                    Doctor doctor = new Doctor(
                            reader.GetInt32("doctorid"),
                            reader.GetString("doctorfirstname"),
                            reader.GetString("doctormiddlename"),
                            reader.GetString("doctorlastname"),
                            reader.GetInt32("doctorage"),
                            reader.GetString("pin"),
                            reader.GetDateTime("doctordatehired"),
                            reader.GetString("doctorgender"),
                            reader.GetString("doctoraddress"),
                            reader.GetString("doctorcontactnumber")
                        );

                    Operation operation = new Operation(
                             reader.GetString("OperationCode"),
                            reader.GetString("OperationName"),
                            reader.GetDateTime("dateAdded"),
                            reader.GetString("description"),
                            reader.GetDouble("price"),
                            reader.GetTimeSpan("duration"),
                            reader.GetString("roomtype")
                        );
                    int appointmentdetailno = reader.GetInt32("AppointmentDetailNo");

                    int roomno = reader.GetInt32("Roomno");
                    DateTime dateVisited = reader.GetDateTime("VisitDate");
                    DateTime dateRecentlyvisit = reader.GetDateTime("recentlyVisitDate");

                    Appointment app = new Appointment(
                        patient,
                        doctor,
                        operation,
                        reader.GetDateTime("DateSchedule"),
                        reader.GetTimeSpan("StartTime"),
                        reader.GetTimeSpan("EndTime"),
                        appointmentdetailno,
                        roomno,
                        dateVisited,
                        dateRecentlyvisit,
                        reader.GetInt32("Bill")
                    );

                    list.Add(app);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on get appointments() db" + ex.Message);
            }

            return list;
        }

        public List<Appointment> getAppointmentsbyDoctor(Doctor dr)
        {
            List<Appointment> list = new List<Appointment>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = @"SELECT * FROM patient_tbl
                            LEFT JOIN patientappointment_tbl 
                            ON patient_tbl.patientid = patientappointment_tbl.patientid
                            LEFT JOIN doctor_operation_mm_tbl
                            ON doctor_operation_mm_tbl.doctoroperationid = patientappointment_tbl.doctorOperationID
                            LEFT JOIN doctor_tbl
                            ON doctor_tbl.doctorId = doctor_operation_mm_tbl.doctorId
                            LEFT JOIN operation_tbl
                            ON operation_tbl.operationCode = doctor_operation_mm_tbl.OperationCode
                            LEFT JOIN clinichistory_tbl
                            ON clinichistory_tbl.patientid = patient_tbl.patientid
                            WHERE patient_tbl.patientid IS NOT NULL AND doctor_tbl.DOCTORID = @DOCTORID";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("DOCTORID", dr.DoctorID);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Patient patient = new Patient(
                            reader.GetInt32("patientid"),
                            reader.GetString("patientfirstname"),
                            reader.GetString("patientmiddlename"),
                            reader.GetString("patientlastname"),
                            reader.GetString("address"),
                            reader.GetInt32("age"),
                            reader.GetString("gender"),
                            reader.GetDateTime("birthdate"),
                            reader.IsDBNull(reader.GetOrdinal("contactnumber")) ? "N/A" : reader.GetString("contactnumber")
                        );
                    Doctor doctor = new Doctor(
                            reader.GetInt32("doctorid"),
                            reader.GetString("doctorfirstname"),
                            reader.GetString("doctormiddlename"),
                            reader.GetString("doctorlastname"),
                            reader.GetInt32("doctorage"),
                            reader.GetString("pin"),
                            reader.GetDateTime("doctordatehired"),
                            reader.GetString("doctorgender"),
                            reader.GetString("doctoraddress"),
                            reader.GetString("doctorcontactnumber")
                        );

                    Operation operation = new Operation(
                             reader.GetString("OperationCode"),
                            reader.GetString("OperationName"),
                            reader.GetDateTime("dateAdded"),
                            reader.GetString("description"),
                            reader.GetDouble("price"),
                            reader.GetTimeSpan("duration"),
                            reader.GetString("roomtype")
                        );

                    int roomno = reader.GetInt32("Roomno");
                    DateTime dateAdmitted = reader.GetDateTime("VisitDate");


                    Appointment app = new Appointment(
                        patient,
                        doctor,
                        operation,
                        reader.GetDateTime("DateSchedule"),
                        reader.GetTimeSpan("StartTime"),
                        reader.GetTimeSpan("EndTime"),
                        reader.GetInt32("AppointmentDetailNo"),
                        roomno,
                        dateAdmitted);
                    list.Add(app);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on get appointments() db" + ex.Message);
            }

            return list;
        }


        public bool isReAppointmentAvailable(Appointment app)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                //string query = $@"SELECT patientappointment_tbl.* 
                //            FROM patientappointment_tbl 
                //JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId
                //            WHERE doctor_operation_mm_tbl.DoctorID = @DoctorID
                //             AND 
                //            (                             
                //                (patientappointment_tbl.DateSchedule = @DateSchedule 
                //                 AND patientappointment_tbl.StartTime < @EndTime 
                //                 AND patientappointment_tbl.EndTime > @StartTime)
                //                OR 
                //                (patientappointment_tbl.DateSchedule < @DateSchedule 
                //                 AND patientappointment_tbl.EndTime > @StartTime)
                //                OR 
                //                (patientappointment_tbl.DateSchedule > @DateSchedule 
                //                 AND patientappointment_tbl.StartTime < @EndTime)
                //            )
                //            AND AppointmentDetailNo != @AppointmentDetailNo";
                //MySqlCommand command = new MySqlCommand(query, conn);             
                //command.Parameters.AddWithValue("@DoctorID", app.Doctor.DoctorID);
                //command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@EndTime", app.EndTime);
                //command.Parameters.AddWithValue("@StartTime", app.StartTime);
                //command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                string query = @"
                            SELECT patientappointment_tbl.*
                            FROM patientappointment_tbl
                            JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId
                            WHERE doctor_operation_mm_tbl.DoctorID = @DoctorID
                            AND 
                            (
                                (
                                    @StartTime > @EndTime 
                                    AND patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        patientappointment_tbl.StartTime >= @EndTime
                                        OR patientappointment_tbl.EndTime > @StartTime
                                    )
                                )
                                OR 
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        -- Check for overlapping appointments
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime = patientappointment_tbl.EndTime
                                        OR @EndTime = patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = DATE_SUB(@DateSchedule, INTERVAL 1 DAY)
                                    AND (
                                        patientappointment_tbl.EndTime > @StartTime
                                        OR patientappointment_tbl.EndTime = @StartTime
                                    )
                                )
                            )  AND AppointmentDetailNo != @AppointmentDetailNo;
                        ";


                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", app.Doctor.DoctorID);
                command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
                command.Parameters.AddWithValue("@StartTime", app.StartTime);
                command.Parameters.AddWithValue("@EndTime", app.EndTime);
                command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                MySqlDataReader reader = command.ExecuteReader();
                return !reader.HasRows;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on get isAvailable() db" + ex.Message);
            }
            return true;
        }

        public bool UpdateSchedule(Appointment app)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = @"UPDATE patientAppointment_tbl 
                                 SET `DateSchedule` = @DateSchedule, `StartTime` = @StartTime, `EndTime` = @EndTime 
                                WHERE AppointmentDetailNo = @AppointmentDetailNo";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
                command.Parameters.AddWithValue("@StartTime", app.StartTime);
                command.Parameters.AddWithValue("@EndTime", app.EndTime);
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from updateSchedule() DB" + ex.Message);
            }
            return false;

        }

        public bool AddAppointment(Patient patient, List<Appointment> ap)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                foreach (Appointment op in ap)
                {

                    int doctoroperationId = getDoctorOperationId(op.Doctor, op.Operation);

                    string query = "INSERT INTO patientappointment_tbl (doctoroperationID, patientid, dateSchedule, StartTime, EndTime, bill, roomno) " +
                               "VALUES " +
                               "(@doctoroperationID, @patientid, @dateSchedule, @StartTime, @EndTime, @bill, @roomno)";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    command.Parameters.AddWithValue("@patientid", patient.Patientid);
                    command.Parameters.AddWithValue("@doctoroperationID", doctoroperationId);
                    command.Parameters.AddWithValue("@dateSchedule", op.DateSchedule);
                    command.Parameters.AddWithValue("@StartTime", op.StartTime);
                    command.Parameters.AddWithValue("@EndTime", op.EndTime);
                    command.Parameters.AddWithValue("@bill", op.Bill.ToString("F2"));
                    command.Parameters.AddWithValue("@roomno", op.RoomNo);
                    command.ExecuteNonQuery();
                }
                updateRecentlyVisitDate(patient.Patientid);
                conn.Close();


                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on addApoinment() db " + ex.Message);
            }
            return false;
        }

        private void updateRecentlyVisitDate(int patientid)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query1 = @"UPDATE clinichistory_tbl 
                            SET RecentlyVisitDate = @RecentlyVisitDate
                            WHERE PatientID = @PatientID";
                MySqlCommand command1 = new MySqlCommand(query1, conn);
                command1.Parameters.AddWithValue("@RecentlyVisitDate", DateTime.Now.ToString("yyyy-MM-dd"));
                command1.Parameters.AddWithValue("@PatientID", patientid);
                command1.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on updateRecentlyVisitDate() db " + ex.Message);
            }
        }

        private int getDoctorOperationId(Doctor doctor, Operation operation)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT doctorOperationID FROM doctor_operation_mm_tbl WHERE DoctorID = @DoctorID AND OperationCode = @OperationCode";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
                command.Parameters.AddWithValue("@OperationCode", operation.OperationCode);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32("doctorOperationId");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on getDoctorOperationId() db " + ex.Message);
            }

            return -1;
        }

        public bool isRoomAvailable(Appointment app)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                //string query = "SELECT patientappointment_tbl.* " +
                //             "FROM patientappointment_tbl " +
                //             "JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId " +
                //             "WHERE Roomno = @Roomno " +
                //             "AND patientappointment_tbl.DateSchedule = @DateSchedule " +
                //             "AND (patientappointment_tbl.StartTime < @EndTime OR patientappointment_tbl.EndTime > @StartTime)";


                string query = @"
                            SELECT patientappointment_tbl.*
                            FROM patientappointment_tbl
                            WHERE patientappointment_tbl.RoomNo = @RoomNo
                            AND 
                            (
                                (
                                    @StartTime > @EndTime 
                                    AND patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        patientappointment_tbl.StartTime >= @EndTime
                                        OR patientappointment_tbl.EndTime > @StartTime
                                    )
                                )
                                OR 
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        -- Check for overlapping appointments
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime = patientappointment_tbl.EndTime
                                        OR @EndTime = patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = DATE_SUB(@DateSchedule, INTERVAL 1 DAY)
                                    AND (
                                        patientappointment_tbl.EndTime > @StartTime
                                        OR patientappointment_tbl.EndTime = @StartTime
                                    )
                                )
                            );
                        ";
                MySqlCommand command = new MySqlCommand(query, conn);
                DateTime startdate = app.DateSchedule + app.StartTime;
                DateTime enddate = app.DateSchedule + app.EndTime;
                command.Parameters.AddWithValue("@RoomNo", app.RoomNo);
                command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
                command.Parameters.AddWithValue("@StartTime", startdate.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@EndTime", enddate.ToString("HH:mm:ss"));
                MySqlDataReader reader = command.ExecuteReader();
                return !reader.HasRows;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR ON patientid() DB" + ex.Message);
            }
            return false;
        }

        public bool isScheduleAvailable(Appointment app)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                //string query = @"SELECT patientappointment_tbl.* 
                //                FROM patientappointment_tbl 
                //JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId
                //WHERE doctor_operation_mm_tbl.DoctorID = @DoctorID 
                //                AND (
                //                    (patientappointment_tbl.DateSchedule = @DateSchedule 
                //                     AND patientappointment_tbl.StartTime < @EndTime 
                //                     AND patientappointment_tbl.EndTime > @StartTime)
                //                    OR
                //                    (patientappointment_tbl.DateSchedule < @DateSchedule 
                //                     AND patientappointment_tbl.EndTime > @StartTime)
                //                    OR
                //                    (patientappointment_tbl.DateSchedule > @DateSchedule 
                //                     AND patientappointment_tbl.StartTime < @EndTime)
                //                )";
                //MySqlCommand command = new MySqlCommand(query, conn);
                //command.Parameters.AddWithValue("@DoctorID", schedule.Doctor.DoctorID);
                //command.Parameters.AddWithValue("@DateSchedule", schedule.DateSchedule.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                //command.Parameters.AddWithValue("@EndTime", schedule.EndTime);

                string query = @"
                            SELECT patientappointment_tbl.*
                            FROM patientappointment_tbl
                            JOIN doctor_operation_mm_tbl ON patientappointment_tbl.doctorOperationID = doctor_operation_mm_tbl.DoctorOperationId
                            WHERE doctor_operation_mm_tbl.DoctorID = @DoctorID 
                            AND 
                            (
                                (
                                    @StartTime > @EndTime 
                                    AND patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        patientappointment_tbl.StartTime >= @EndTime
                                        OR patientappointment_tbl.EndTime > @StartTime
                                    )
                                )
                                OR 
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        -- Check for overlapping appointments
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime = patientappointment_tbl.EndTime
                                        OR @EndTime = patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = DATE_SUB(@DateSchedule, INTERVAL 1 DAY)
                                    AND (
                                        patientappointment_tbl.EndTime > @StartTime
                                        OR patientappointment_tbl.EndTime = @StartTime
                                    )
                                )
                            );
                        ";


                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", app.Doctor.DoctorID);
                command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
                command.Parameters.AddWithValue("@StartTime", app.StartTime);
                command.Parameters.AddWithValue("@EndTime", app.EndTime);
                MySqlDataReader reader = command.ExecuteReader();

                return !reader.HasRows;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error from isScheduleAvailable DB" + ex.Message);
            }
            return false;
        }
        public List<Patient> getPatients()
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM patient_tbl", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient(
                            reader.GetInt32("patientid"),
                            reader.GetString("patientfirstname"),
                            reader.GetString("patientmiddlename"),
                            reader.GetString("patientlastname"),
                            reader.GetString("address"),
                            reader.GetInt32("age"),
                            reader.GetString("gender"),
                            reader.GetDateTime("birthdate"),
                            reader.IsDBNull(reader.GetOrdinal("contactnumber")) ? "Contact number not provided" : reader.GetString("contactnumber")
                        );
                    patients.Add(patient);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error from getPatients() db " + ex.Message);
            }
            return patients;
        }

        public string getAppointmentDetail()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT AppointmentDetailNo FROM patientappointment_tbl " +
                    "ORDER BY AppointmentDetailNo DESC LIMIT 1 ", conn);
                MySqlDataReader reader = command.ExecuteReader();
                int id = reader.Read() ? int.Parse(reader["AppointmentDetailNo"].ToString()) + 1 : 1;
                return id.ToString();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getAppointmentDetail DB" + e.Message);
            }
            return "0";
        }

        public List<Doctor> getDoctors(Operation operation)
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT *, doctor_tbl.* FROM doctor_operation_mm_tbl " +
                    "LEFT JOIN doctor_tbl " +
                    "ON doctor_operation_mm_tbl.DoctorID = doctor_tbl.DoctorID " +
                    "WHERE operationcode = @operationcode";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@operationcode", operation.OperationCode);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor(
                        reader.GetInt32("DoctorID"),
                        reader.GetString("doctorFirstName"),
                        reader.GetString("doctorMiddleName"),
                        reader.GetString("doctorLastName"),
                        reader.GetInt32("doctorAge"),
                        reader.GetString("Pin"),
                        reader.GetDateTime("doctorDateHired"),
                        reader.GetString("doctorGender"),
                        reader.GetString("doctorAddress"),
                        reader.GetString("doctorcontactnumber")
                     );
                    doctorList.Add(doctor);
                }
                conn.Close();
                reader.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getDoctors DB" + e.Message);
            }
            return doctorList;
        }

        public List<Operation> getOperations()
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM Operation_Tbl", conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operation operation = new Operation(
                        reader.GetString("OperationCode"),
                        reader.GetString("operationName"),
                        reader.GetDateTime("DateAdded"),
                        reader.GetString("Description"),
                        reader.GetDouble("Price"),
                        reader.GetTimeSpan("Duration"),
                        reader.GetString("roomtype")
                    );
                    operations.Add(operation);
                }
                conn.Close();
                reader.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error from getOperations DB" + e.Message);
            }
            return operations;
        }

        internal bool isPatientAvailable(Appointment app)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = @"
                            SELECT patientappointment_tbl.*
                            FROM patientappointment_tbl
                            WHERE patientappointment_tbl.PatientId = @PatientId
                            AND 
                            (
                                (
                                    @StartTime > @EndTime 
                                    AND patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        patientappointment_tbl.StartTime >= @EndTime
                                        OR patientappointment_tbl.EndTime > @StartTime
                                    )
                                )
                                OR 
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        -- Check for overlapping appointments
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime < patientappointment_tbl.EndTime
                                        AND @EndTime > patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = @DateSchedule
                                    AND (
                                        @StartTime = patientappointment_tbl.EndTime
                                        OR @EndTime = patientappointment_tbl.StartTime
                                    )
                                )
                                OR
                                (
                                    patientappointment_tbl.DateSchedule = DATE_SUB(@DateSchedule, INTERVAL 1 DAY)
                                    AND (
                                        patientappointment_tbl.EndTime > @StartTime
                                        OR patientappointment_tbl.EndTime = @StartTime
                                    )
                                )
                            );
                        ";



                MySqlCommand command = new MySqlCommand(query, conn);
                DateTime startdate = app.DateSchedule + app.StartTime;
                DateTime enddate = app.DateSchedule + app.EndTime;
                command.Parameters.AddWithValue("@PatientId", app.Patient.Patientid);
                //command.Parameters.AddWithValue("@AppointmentDetailNo", app.AppointmentDetailNo);
                command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
                command.Parameters.AddWithValue("@StartTime", startdate.ToString("HH:mm:ss"));
                command.Parameters.AddWithValue("@EndTime", enddate.ToString("HH:mm:ss"));
                //command.Parameters.AddWithValue("@StartDateTime", app.DateSchedule + app.StartTime);
                //command.Parameters.AddWithValue("@EndDateTime", app.DateSchedule + app.EndTime);

                MySqlDataReader reader = command.ExecuteReader();
                return !reader.HasRows;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error on isPatientAvailable() db" + ex.Message);
            }
            return false;
        }

        private bool endTimeGreaterThanStartTime(MySqlConnection conn, Appointment app)
        {
            string query = @"SELECT patientappointment_tbl.*
                            FROM patientappointment_tbl
                            WHERE patientappointment_tbl.PatientId = @PatientId
                              AND @StartTime > @EndTime
                              AND patientappointment_tbl.DateSchedule = @DateSchedule";
            MySqlCommand command = new MySqlCommand(query, conn);
            DateTime startdate = app.DateSchedule + app.StartTime;
            DateTime enddate = app.DateSchedule + app.EndTime;
            command.Parameters.AddWithValue("@PatientId", app.Patient.Patientid);
            command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
            command.Parameters.AddWithValue("@StartTime", startdate.ToString("HH:mm:ss"));
            command.Parameters.AddWithValue("@EndTime", enddate.ToString("HH:mm:ss"));
            MySqlDataReader reader = command.ExecuteReader();
            return !reader.HasRows;
        }

        public bool validCheckConflict(MySqlConnection conn, Appointment app)
        {
            string query = @"SELECT patientappointment_tbl.* 
                            FROM patientappointment_tbl 
                            WHERE patientappointment_tbl.PatientId = @PatientId
                            AND patientappointment_tbl.DateSchedule = @DateSchedule
                            AND @StartTime <= patientappointment_tbl.EndTime
                            OR @EndTime >= patientappointment_tbl.StartTime";
            MySqlCommand command = new MySqlCommand(query, conn);
            DateTime startdate = app.DateSchedule + app.StartTime;
            DateTime enddate = app.DateSchedule + app.EndTime;
            command.Parameters.AddWithValue("@PatientId", app.Patient.Patientid);
            command.Parameters.AddWithValue("@DateSchedule", app.DateSchedule);
            command.Parameters.AddWithValue("@StartTime", startdate.ToString("HH:mm:ss"));
            command.Parameters.AddWithValue("@EndTime", enddate.ToString("HH:mm:ss"));
            MySqlDataReader reader = command.ExecuteReader();
            return !reader.HasRows;
        }
    }
}
