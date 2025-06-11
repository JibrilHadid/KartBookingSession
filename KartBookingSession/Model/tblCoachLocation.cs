using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class CoachLocation
    {
        public int track_id { get; set; }
        public int coach_id { get; set; }

        public CoachLocation(int CoachID, int TrackID)
        {
            coach_id = CoachID;
            track_id = TrackID;
        }


    }//CoachLocation class
}
