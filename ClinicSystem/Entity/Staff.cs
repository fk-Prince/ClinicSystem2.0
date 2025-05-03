using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.UserLoginForm
{
    public class Staff
    {
        private int staffId;
        private string username;
        private string password;

        public Staff(int staffId, string username, string password)
        {
            this.staffId = staffId;
            this.username = username;
            this.password = password;
        }

        public int StaffId { get => staffId;}
        public string Username { get => username; }
        public string Password { get => password;  }
    }
}
