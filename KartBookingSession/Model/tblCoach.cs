using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Coach
    {
        public string coach_name { get; set; }
        public int coach_id { get; set; }

        public Coach(int CoachID, string CoachName)
        {
            coach_id = CoachID;
            coach_name = CoachName;
        }


    }//Coach class
}
