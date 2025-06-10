using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartBookingSession.Model;
using Microsoft.Data.SqlClient;

namespace KartBookingSession.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Coneection successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection NOT successful\n");
                Console.WriteLine(e.Message);
                throw;
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        public List<Karts> GetAllKarts()
        {
            List<Karts> karts = new List<Karts>();
            string sqlString = "SELECT * FROM booking.KARTS";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int kartid = Convert.ToInt32(reader["KartID"]);
                        string kartName = reader["KartName"].ToString();
                        string kartType = reader["KartType"].ToString();
                        karts.Add(new Karts(kartid, kartName, kartType));
                    }
                }
            }
            return karts;
        }

        public List<Tracks> GetAlltracks()
        {
            List<Tracks> tracks = new List<Tracks>();
            string sqlString = "SELECT * FROM booking.tracks";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int trackid = Convert.ToInt32(reader["TracksID"]);
                        string trackName = reader["TrackName"].ToString();
                        tracks.Add(new Tracks(trackid, trackName));
                    }
                }
            }
            return tracks;
        }

        public List<City> GetAllCity()
        {
            List<City> tracks = new List<City>();
            string sqlString = "SELECT * FROM booking.tracks";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cityid = Convert.ToInt32(reader["CityID"]);
                        string CityName = reader["CityName"].ToString();
                        string Country = reader["Country"].ToString();
                        tracks.Add(new City(cityid, CityName, Country));
                    }
                }
            }
            return tracks;


        }

    }
}
