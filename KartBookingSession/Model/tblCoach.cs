using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Coach
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int coach_id { get; set; }

        public Coach(int CoachID, string FirstName, string LastName, string Gender, double Age)
        {
            coach_id = CoachID;
            first_name = FirstName;
            last_name = LastName;
            gender = Gender;
            age = Age;

        }


    }//Coach class
}
