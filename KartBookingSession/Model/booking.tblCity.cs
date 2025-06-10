using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.Model
{
    public class City
    {
        public int city_id { get; set; }
        public string city_name { get; set; }
        public string country { get; set; }

        public City(int city_id, string CityName, string Country)
        {
            city_id = city_id;
            city_name = CityName;
            country = Country;
        }


    }//City class
}
