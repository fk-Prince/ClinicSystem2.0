using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicSystem.PatientForm;
using ClinicSystem.UserLoginForm;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Helpers
{
    public class EntityMapping
    {
        public static Patient GetPatient(MySqlDataReader reader)
        {
            return new Patient(
                reader.GetString("patientid"),
                reader.GetString("patientfirstname"),
                reader.GetString("patientmiddlename"),
                reader.GetString("patientlastname"),
                reader.GetString("address"),
                reader.GetInt32("age"),
                reader.GetString("gender"),
                reader.GetDateTime("birthdate"),
                reader.IsDBNull(reader.GetOrdinal("contactnumber"))
                    ? "N/A"
                    : reader.GetString("contactnumber")
            );
        }

        public static Doctor GetDoctor(MySqlDataReader reader)
        {
            return new Doctor(
                reader.GetString("DoctorID"),
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
        }

        public static Operation GetOperation(MySqlDataReader reader)
        {
            return new Operation(
                reader.GetString("OperationCode"),
                reader.GetString("OperationName"),
                reader.GetDateTime("dateAdded"),
                reader.GetString("description"),
                reader.GetDouble("price"),
                reader.GetTimeSpan("duration"),
                reader.GetString("roomtype")
            );
        }

        public static Doctor GetDoctorWithImage(MySqlDataReader reader)
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
            return new Doctor(
               reader.GetString("DoctorID"),
               reader.GetString("doctorFirstName"),
               reader.GetString("doctorMiddleName"),
               reader.GetString("doctorLastName"),
               reader.GetInt32("doctorAge"),
               reader.GetString("Pin"),
               reader.GetDateTime("doctorDateHired"),
               reader.GetString("doctorGender"),
               reader.GetString("doctorAddress"),
               reader.GetString("doctorcontactnumber"),
               doctorImage,
               reader.GetString("Active") == "Yes"
            );
        }

        public static Discount GetDiscount(MySqlDataReader reader)
        {
            return new Discount(
                reader.GetString("DiscountType"),
                reader.GetString("DiscountDescription"),
                reader.GetDouble("DiscountRate")
            ); 
        }

        public static Appointment GetAppointment(MySqlDataReader reader)
        {
            return new Appointment(
                GetPatient(reader),
                GetDoctor(reader),
                GetOperation(reader),
                reader.GetDateTime("StartSchedule"),
                reader.GetDateTime("EndSchedule"),
                reader.GetDouble("subtotal"),
                reader.GetInt32("roomno"),
                reader.GetInt32("AppointmentDetailNo"),
                reader.GetDouble("totalWithDiscount"),
                reader.GetString("DiscountType"),
                reader.IsDBNull(reader.GetOrdinal("diagnosis")) ? "" : reader.GetString("diagnosis"),
                reader.GetDateTime("BookingDate"),
                reader.GetString("Status"),
                 reader.IsDBNull(reader.GetOrdinal("prescription")) ? "" : reader.GetString("prescription")
            );
        }


        public static Appointment GetAppointmentByDoctor(MySqlDataReader reader)
        {
            return new Appointment(
               GetPatient(reader),
               GetOperation(reader),
               reader.GetDateTime("StartSchedule"),
               reader.GetDateTime("EndSchedule"),
               reader.GetDouble("subtotal"),
               reader.GetInt32("roomno"),
               reader.GetInt32("AppointmentDetailNo"),
               reader.GetDouble("totalWithDiscount"),
               reader.GetString("DiscountType"),
               reader.IsDBNull(reader.GetOrdinal("diagnosis")) ? "" : reader.GetString("diagnosis"),
               reader.GetDateTime("BookingDate"),
               reader.GetString("Status"),
               reader.IsDBNull(reader.GetOrdinal("prescription")) ? "" : reader.GetString("prescription")
           );
        }


    }
}
