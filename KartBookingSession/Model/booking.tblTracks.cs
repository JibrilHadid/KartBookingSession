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

        public Tracks(int Track_id, string TrackName)
        {
            track_id = Track_id;
            track_name = TrackName;
        }


    }//tracks class
}
