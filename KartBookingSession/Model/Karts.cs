using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class Karts
    {
        public string kart_name { get; set; }
        public int kart_id { get; set; } 

        public Karts(int Kart_id, string KartName)
        {
            kart_id = Kart_id;
            kart_name = KartName;
        }


    }//karts class
}
