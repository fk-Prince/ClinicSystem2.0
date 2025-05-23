using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Repository
{
    public class DatabaseConnection
    {

        private static string driver = "server=localhost;username=root;pwd=root;database=clinic";

        public static string getConnection()
        {
            return driver;
        }
    }
}
