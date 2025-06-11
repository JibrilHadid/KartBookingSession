using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class CoachInfo
    {
        public int coachinfo_id { get; set; }
        public int coach_id { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string experience_lvl { get; set; }

        public CoachInfo(int CoachInfoID, int CoachID, string Email, string PhoneNumber, string ExperienceLvl)
        {
            coachinfo_id = CoachInfoID;
            coach_id = CoachID;
            email = Email;
            phone_number = PhoneNumber;
            experience_lvl = ExperienceLvl;

        }


    }//CoachInfo class
}
