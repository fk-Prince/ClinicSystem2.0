using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.Repository;
using MySql.Data.MySqlClient;

namespace ClinicSystem.Rooms
{
    public class RoomRepository
    {
       
        public List<Room> getRooms()
        {
            List<Room> roomList = new List<Room>(); 
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    string query = "SELECT * FROM Rooms_tbl LEFT JOIN roomtype_tbl ON Rooms_tbl.RoomType = roomtype_tbl.RoomType";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Room room = new Room(reader.GetInt32("roomno"), reader.GetString("roomtype"), reader.GetString("RoomDescription"));
                                roomList.Add(room);
                            }
                        }
                    }
                }    
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on getRooms() DB" + ex.Message);
            }
            return roomList; 
        }

        public void insertRoom(Room room)
        {
           try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();

                    string query = "INSERT INTO rooms_tbl (Roomno, RoomType ) VALUES (@RoomNo, @RoomType)";
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {   
                        command.Parameters.AddWithValue("@RoomNo", room.RoomNo);
                        command.Parameters.AddWithValue("@RoomType", room.Roomtype);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on insertRoom() db" + ex.Message);
            }
        }

        public List<Room> getRoomType()
        {
            List<Room> roomList = new List<Room>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection.getConnection()))
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM roomtype_tbl", conn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                roomList.Add(new Room(reader.GetString("RoomType"), reader.GetString("RoomDescription")));
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error on insertRoom() db" + ex.Message);
            }
            return roomList;
        }

       
    }
}
