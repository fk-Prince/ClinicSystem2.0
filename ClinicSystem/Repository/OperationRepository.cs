using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicSystem.Helpers;
using ClinicSystem.Repository;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public class OperationRepository
    {

        public List<Operation> getOperations()
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
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
        public List<Operation> getOperationOnDoctors()
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT * FROM operation_tbl";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Operation operation = EntityMapping.GetOperation(reader);
                                getDoctorByOperation(operation);
                                operations.Add(operation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FROM GETOPERATIONS() DB " + ex.Message);
            }
            return operations;
        }
        private void getDoctorByOperation(Operation operation)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        @"SELECT * FROM doctor_operation_mm_tbl 
                        LEFT JOIN doctor_tbl ON doctor_operation_mm_tbl.DoctorId = doctor_tbl.doctorId
                        WHERE OperationCode = @OperationCode";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@OperationCode", operation.OperationCode);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                operation.Doctor.Add(EntityMapping.GetDoctor(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM GETDOCTOR() DB " + ex.Message);
            }
        }
        public bool insertOperation(Operation operation)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        "INSERT INTO operation_tbl(operationcode, OperationName, dateadded, description, price, duration, roomtype) "
                        + "VALUES(@OperationCode, @OperationName, @DateAdded, @Description, @Price, @Duration, @roomtype)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OperationCode", operation.OperationCode);
                        cmd.Parameters.AddWithValue("@OperationName", operation.OperationName);
                        cmd.Parameters.AddWithValue("@DateAdded", operation.DateAdded);
                        cmd.Parameters.AddWithValue("@Description", operation.Description);
                        cmd.Parameters.AddWithValue("@Price", operation.Price);
                        cmd.Parameters.AddWithValue("@Duration", operation.Duration);
                        cmd.Parameters.AddWithValue("@roomtype", operation.OperationRoomType);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FROM INSERT() DB " + ex.Message);
            }
            return false;
        }
        public List<Operation> getOperationByDoctor(string id)
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        @"SELECT doctor_operation_mm_tbl.OperationCode, Operation_tbl.* 
                         FROM doctor_operation_mm_tbl 
                         LEFT JOIN Operation_tbl 
                         ON Operation_tbl.OperationCode = doctor_operation_mm_tbl.OperationCode 
                         WHERE DOCTORID = @DoctorID;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@DoctorID", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        operations.Add(EntityMapping.GetOperation(reader));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM getOperationByDoctor() DB " + ex.Message);
            }

            return operations;
        }
        public List<string> getAvailableRoomType()
        {
            List<string> roomTypes = new List<string>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM roomtype_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            roomTypes.Add(reader.GetString("roomtype"));
                        }
                    }          
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM getAvailableRoomType() DB " + ex.Message);
            }
            return roomTypes;
        }

        //public Dictionary<Doctor, Operation> getDoctorOperation()
        //{
        //    Dictionary<Doctor, Operation> docOp = new Dictionary<Doctor, Operation>();

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
        //        {
        //            conn.Open();
        //            string query =
        //                  @"SELECT * FROM doctor_operation_mm_tbl 
        //                  LEFT JOIN doctor_tbl 
        //                  ON 
        //                  doctor_operation_mm_tbl.doctorID = doctor_tbl.doctorID 
        //                  LEFT JOIN operation_tbl 
        //                  ON 
        //                  doctor_operation_mm_tbl.OperationCode = operation_tbl.OperationCode";
        //            using (MySqlCommand command = new MySqlCommand(query, conn))
        //            {
        //                using (MySqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Operation operation = EntityMapping.GetOperation(reader);
        //                        Doctor doctor = EntityMapping.GetDoctor(reader);
        //                        docOp[doctor] = operation;
        //                    }
        //                }
        //            }
                   
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("ERROR FROM getAvailableRoomType() DB " + ex.Message);
        //    }

        //    return docOp;
        //}
        //public List<Doctor> getDoctors()
        //{
        //    List<Doctor> doctorList = new List<Doctor>();
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(DBConnection.getConnection()))
        //        {
        //            conn.Open();
        //            using (MySqlCommand command = new MySqlCommand("SELECT * FROM doctor_tbl WHERE Active = 'Yes'", conn))
        //            {
        //                using (MySqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        doctorList.Add(EntityMapping.GetDoctor(reader));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("ERROR FROM getDoctors() DB " + ex.Message);
        //    }
        //    return doctorList;
        //}
        public List<Doctor> getDoctorHaveNoOperation(Operation operation)
        {
            List<Doctor> doctorList = new List<Doctor>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = @"
                                SELECT doctor_tbl.*
                                FROM doctor_tbl
                                WHERE doctor_tbl.doctorid NOT IN (
                                    SELECT doctor_operation_mm_tbl.doctorid
                                    FROM doctor_operation_mm_tbl 
                                    WHERE doctor_operation_mm_tbl.operationcode = @OperationCode
                                );
                                ";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@OperationCode", operation.OperationCode);
                        using (MySqlDataReader reader = command.ExecuteReader()) { 
                            while (reader.Read())
                            {                         
                                doctorList.Add(EntityMapping.GetDoctor(reader));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM getOperations2() DB " + ex.Message);
            }
            return doctorList;
        }
        public bool insertDoctorOperation(Doctor doc, Operation op)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        "INSERT INTO doctor_operation_mm_tbl (operationcode, doctorId) VALUES (@operationcode, @doctorId)";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@operationcode", op.OperationCode);
                        command.Parameters.AddWithValue("@doctorId", doc.DoctorID);
                        command.ExecuteNonQuery();
                    }                  
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM insertSpecialized() DB " + ex.Message);
            }
            return false;
        }
        internal void setDoctorOperation(string docid, string operationcode)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query =
                        @"INSERT INTO doctor_operation_mm_tbl (operationCode, doctorId) VALUES (@operationCode, @doctorId)";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@doctorId", docid);
                        command.Parameters.AddWithValue("@operationCode", operationcode);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR FROM setDoctorOperation() DB " + ex.Message);
            }
        }
    }
}
