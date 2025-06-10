using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Suburb
    {
        public string suburb_name { get; set; }
        public int suburb_id { get; set; }

        public Suburb(int SuburbID, string SuburbName)
        {
            suburb_id = SuburbID;
            suburb_name = SuburbName;
        }


    }//Suburb class
}
