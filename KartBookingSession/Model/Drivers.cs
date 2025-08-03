using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Drivers
    {
        public string username { get; set; }
        public string password { get; set; }

        public Drivers(string Username, string Password)
        {
            username = Username;
            password = Password;
        }
    }
}