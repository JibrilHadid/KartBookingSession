using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class KartManufacturer
    {
        public string manufacturer_name { get; set; }
        public int manufacturer_id { get; set; }
        public int kart_id { get; set; }

        public KartManufacturer(int ManufacturerID, int KartID, string ManufacturerName)
        {
            manufacturer_id = ManufacturerID;
            manufacturer_name = ManufacturerName;
            kart_id = KartID;
        }


    }//KartManufacturer class
}
