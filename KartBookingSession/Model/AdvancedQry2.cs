using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    class AdvancedQry2
    {
        public int CoachID { get; set; }
        public string kart_name { get; set; }
        public string kart_type { get; set; }
        public string production_date { get; set; }
        public double kart_price { get; set; }

        public AdvancedQry1(int KartID, string KartName, string KartType, string ProductionDate, double KartPrice)
        {
            kart_id = KartID;
            kart_name = KartName;
            kart_type = KartType;
            production_date = ProductionDate;
            kart_price = KartPrice;

        }
    }

}
