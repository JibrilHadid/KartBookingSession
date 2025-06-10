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
        public string kart_type { get; set; }
        public int kart_id { get; set; } 

        public Karts(int Kart_id, string KartName, string KartType)
        {
            kart_id = Kart_id;
            kart_name = KartName;
            kart_type = KartType;
        }


    }//karts class
}
