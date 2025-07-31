using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Tracks
    {

        public string track_name { get; set; }
        public int track_id { get; set; }
        public string track_type { get; set; }

        public Tracks(int TrackID, string TrackName, string TrackType)
        {
            track_id = TrackID;
            track_name = TrackName;
            track_type = TrackType;
        }


    }//tracks class
}
