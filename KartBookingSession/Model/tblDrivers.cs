using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Drivers
    {
        public int role_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Drivers(int RoleID, string Username, string Password)
        {
            role_id = RoleID;
            username = Username;
            password = Password;
        }
    }
}