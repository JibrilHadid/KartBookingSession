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

        public KartManufacturer(int ManufacturerID, string ManufacturerName)
        {
            manufacturer_id = ManufacturerID;
            manufacturer_name = ManufacturerName;
        }


    }//KartManufacturer class
}
