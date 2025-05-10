using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Numerics;
using System.Windows.Forms;
using ClinicSystem.Entity;
using ClinicSystem.Helpers;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using MySql.Data.MySqlClient;

namespace ClinicSystem.MainClinic
{
    public class ClinicRepository
    {
      

        public int TotalPatientLastMonth()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) as COUNT FROM patient_tbl";
                    using (MySqlCommand command = new MySqlCommand(query, conn)) {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            return reader.GetInt32("COUNT");
                        }
                    }
                }       
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on TotalPatientLastMonth() db" + ex.Message);
            }
            return 0;
        }
        public int TotalActiveDoctor()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) as COUNT FROM doctor_tbl WHERE active = 'Yes'";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            return reader.GetInt32("COUNT");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctor() db" + ex.Message);
            }
            return 0;
        }

        internal int getEarnings()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                    SELECT 
                                        COALESCE(SUM(appointmentdetails_tbl.totalWithDiscount), 0) + COALESCE(SUM(appointmentpenalty_tbl.Amount), 0) AS Earnings
                                    FROM appointmentdetails_tbl 
                                    LEFT JOIN appointmentpenalty_tbl 
                                        ON appointmentdetails_tbl.AppointmentDetailNo = appointmentpenalty_tbl.AppointmentDetailNo";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            return reader.IsDBNull(reader.GetOrdinal("EARNINGS")) ? 0 : reader.GetInt32("EARNINGS");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctor() db" + ex.Message);
            }
            return 0;
        }

        public List<Appointment> getTodayAppointment()
        {
            List<Appointment> todayAppointment = new List<Appointment>();
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
                                WHERE patientappointment_tbl.StartSchedule BETWEEN @Start AND @End AND Status = 'Upcoming' AND EndSchedule > Now()";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Start", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@End", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
 
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
                MessageBox.Show("Error on getTodayAppointment() db");
            }
            return todayAppointment;
        }

        public DoctorStats getDoctorStats()
        {
        
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                SELECT 
                                COUNT(patientappointment_tbl.appointmentdetailno) AS totalAppointment,
                                COUNT(DISTINCT patientappointment_tbl.patientid) AS totalPatient,
                                doctor_tbl.*,
                                sum(totalWithDiscount) as REVENUE
                                FROM patientappointment_tbl
                                LEFT JOIN appointmentdetails_tbl
                                ON appointmentdetails_tbl.appointmentdetailno = patientappointment_tbl.appointmentdetailno
                                LEFT JOIN doctor_tbl ON patientappointment_tbl.doctorid = doctor_tbl.doctorid
                                WHERE appointmentdetails_tbl.BookingDate BETWEEN DATE_FORMAT(CURRENT_DATE, '%Y-%m-01') AND LAST_DAY(CURRENT_DATE)
                                GROUP BY doctor_tbl.doctorid
                                ORDER BY revenue DESC
                                LIMIT 1
                                ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {         
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = EntityMapping.GetDoctor(reader);
                                int totalApp = reader.GetInt32("totalAppointment");
                                int totalPat = reader.GetInt32("totalPatient");
                                double revenue = reader.GetDouble("REVENUE");
                                return new DoctorStats(doctor, totalPat, totalApp, revenue);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctorStats() db");
            }
            return null;
        }

        internal DoctorStats getDoctorStatsLast()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                SELECT 
                                COUNT(patientappointment_tbl.appointmentdetailno) AS totalAppointment,
                                COUNT(DISTINCT patientappointment_tbl.patientid) AS totalPatient,
                                doctor_tbl.*,
                                sum(totalWithDiscount) as REVENUE
                                FROM patientappointment_tbl
                                LEFT JOIN appointmentdetails_tbl
                                ON appointmentdetails_tbl.appointmentdetailno = patientappointment_tbl.appointmentdetailno
                                LEFT JOIN doctor_tbl ON patientappointment_tbl.doctorid = doctor_tbl.doctorid
                                WHERE appointmentdetails_tbl.BookingDate BETWEEN DATE_FORMAT(CURRENT_DATE - INTERVAL 1 MONTH, '%Y-%m-01') AND LAST_DAY(CURRENT_DATE - INTERVAL 1 MONTH)
                                GROUP BY doctor_tbl.doctorid
                                ORDER BY revenue DESC
                                LIMIT 1 
                            ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = EntityMapping.GetDoctor(reader);
                                int totalApp = reader.GetInt32("totalAppointment");
                                int totalPat = reader.GetInt32("totalPatient");
                                double revenue = reader.GetDouble("REVENUE");
                                return new DoctorStats(doctor, totalPat, totalApp, revenue);
                            }
                        }
                    }
                }
            }catch (MySqlException ex)
            {
                MessageBox.Show("Error on getDoctorStatsLast() db");
            }
            return null;
        }


        internal List<Appointment> getAppointments()
        {
            List<Appointment> patientList = new List<Appointment>();
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
                                ";
                    //StartSchedule < NOW() AND Status = 'Pending'
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patientList.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getPatients() db" + ex.Message);
            }
            return patientList;
        }
        internal List<Appointment> getUpcomingAppointment()
        {
            List<Appointment> patientList = new List<Appointment>();
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
                                 WHERE EndSchedule < NOW() AND Status = 'Upcoming'
                                ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patientList.Add(EntityMapping.GetAppointment(reader));
                            }
                        }
                    }
                }
            }catch (MySqlException ex)
            {
                MessageBox.Show("Error on getPatients() db" + ex.Message);
            }
            return patientList;
        }

        public void updateAppointmentStatus(Appointment a)
        {
            try
            {


                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"UPDATE patientappointment_tbl SET Status = 'Absent' WHERE AppointmentDetailNo = @AppointmentDetailNo ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@AppointmentDetailNo", a.AppointmentDetailNo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on updateAppointmentStatus() db" + ex.Message);
            }

        }

        public int getAppointmentCountMissed()
        {
            try
            {


                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) AS miss FROM patientappointment_tbl  WHERE StartSchedule < NOW() AND Status = 'Upcoming'";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.Read() ? reader.GetInt32("miss") : 0;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on updateAppointmentStatus() db" + ex.Message);
            }
            return 0;
        }

        public double getPercentageIncrease()
        {
            try
            {


                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                 SELECT 
                                 COALESCE(currentmonth.Revenue, 0) AS currentRevenue,
                                 COALESCE(lastmonth.Revenue, 0) AS lastRevenue,
                                    CASE 
                                        WHEN COALESCE(lastmonth.Revenue, 0) = 0 THEN 0
                                        ELSE ROUND(((currentmonth.Revenue - lastmonth.Revenue) / lastmonth.Revenue) * 100, 2)
                                    END AS percentage
                                 FROM 
                                    (
                                        SELECT 
                                        COALESCE(SUM(totalwithdiscount), 0) + COALESCE(SUM(appointmentpenalty_tbl.amount), 0) AS Revenue
                                        FROM appointmentdetails_tbl
                                        LEFT JOIN appointmentpenalty_tbl 
                                        ON appointmentdetails_tbl.appointmentdetailno = appointmentpenalty_tbl.appointmentdetailno
                                        WHERE appointmentdetails_tbl.BookingDate BETWEEN DATE_FORMAT(CURRENT_DATE, '%Y-%m-01') AND LAST_DAY(CURRENT_DATE)
                                    ) AS currentmonth,
                                    (
                                        SELECT 
                                        COALESCE(SUM(totalwithdiscount), 0) + COALESCE(SUM(appointmentpenalty_tbl.amount), 0) AS Revenue
                                        FROM appointmentdetails_tbl
                                        LEFT JOIN appointmentpenalty_tbl 
                                        ON appointmentdetails_tbl.appointmentdetailno = appointmentpenalty_tbl.appointmentdetailno
                                        WHERE appointmentdetails_tbl.BookingDate 
                                        BETWEEN DATE_FORMAT(CURRENT_DATE - INTERVAL 1 MONTH, '%Y-%m-01') AND LAST_DAY(CURRENT_DATE - INTERVAL 1 MONTH)
                                    ) AS lastmonth
                                ";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            return reader.Read() ? reader.GetDouble("percentage") : 0;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getPatients() db" + ex.Message);
            }

            return 0;
        }
    }
}