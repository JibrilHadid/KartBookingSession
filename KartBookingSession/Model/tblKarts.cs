using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Karts
    {
        public string Kart_name { get; set; }
        public string Kart_id { get; set; } 

        public Karts(int Kart_id, string KartName)
        {
            Kart_id = Kart_id;
            Kart_name = KartName;
        }


    }//karts class
}
