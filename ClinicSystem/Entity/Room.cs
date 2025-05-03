using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Rooms
{
    public class Room
    {
        private int roomNo;
        private string roomtype;
        private string roomDescription;

        public Room(int roomNo, string roomtype)
        {
            this.roomNo = roomNo;
            this.roomtype = roomtype;
        }

        public Room(int roomNo, string roomtype, string roomDescription)
        {
            this.roomNo = roomNo;
            this.roomtype = roomtype;
            this.roomDescription = roomDescription;
        }


        public Room (string roomtype, string roomDescription)
        {
            this.roomDescription = roomDescription;
            this.roomtype = roomtype;
        }


        public string RoomDescription { get => roomDescription; }
        public int RoomNo { get => roomNo; }
        public string Roomtype { get => roomtype; }
    }
}
