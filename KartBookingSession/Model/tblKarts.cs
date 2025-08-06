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
        public DateTime production_date { get; set; }
        public double kart_price { get; set; }
        public int kart_id { get; set; } 

        public Karts(int KartID, string KartName, string KartType, DateTime ProductionDate, double KartPrice)
        {
            kart_id = KartID;
            kart_name = KartName;
            kart_type = KartType;
            production_date = ProductionDate;
            kart_price = KartPrice;
        }


    }//karts class
}
