using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            string sqlString = "SELECT * FROM booking.Karts";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int KartID = Convert.ToInt32(reader["KartID"]);
                        string kartName = reader["KartName"].ToString();
                        string kartType = reader["KartType"].ToString();
                        karts.Add(new Karts(KartID, kartName, kartType));
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
                        int TrackID = Convert.ToInt32(reader["TracksID"]);
                        string trackName = reader["TrackName"].ToString();
                        tracks.Add(new Tracks(TrackID, trackName));
                    }
                }
            }
            return tracks;
        }

        public List<City> GetAllCity()
        {
            List<City> tracks = new List<City>();
            string sqlString = "SELECT * FROM booking.city";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        string CityName = reader["CityName"].ToString();
                        string Country = reader["Country"].ToString();
                        tracks.Add(new City(CityID, CityName, Country));
                    }
                }
            }
            return tracks;
        }

        public List<Suburb> GetAllSuburb()
        {
            List<Suburb> suburb = new List<Suburb>();
            string sqlString = "SELECT * FROM booking.suburb";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int SuburbID = Convert.ToInt32(reader["SuburbID"]);
                        string SuburbName = reader["SuburbName"].ToString();
                        suburb.Add(new Suburb(SuburbID, SuburbName));
                    }
                }
            }
            return suburb;

        }

        public List<KartManufacturer> GetAllKartManufacturer()
        {
            List<KartManufacturer> kartmanufacturer = new List<KartManufacturer>();
            string sqlString = "SELECT * FROM booking.KartManufacturer";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ManufacturerID = Convert.ToInt32(reader["ManufacturerID"]);
                        string ManufacturerName = reader["ManufacturerName"].ToString();
                        kartmanufacturer.Add(new KartManufacturer(ManufacturerID, ManufacturerName));
                    }
                }
            }
            return kartmanufacturer;

        }

        public List<Coach> GetAllCoach()
        {
            List<Coach> coach = new List<Coach>();
            string sqlString = "SELECT * FROM booking.Coach";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string CoachName = reader["CoachName"].ToString();
                        coach.Add(new Coach(CoachID, CoachName));
                    }
                }
            }
            return coach;

        }

        public List<CoachLocation> GetAllCoachLocation()
        {
            List<CoachLocation> coachlocation = new List<CoachLocation>();
            string sqlString = "SELECT * FROM booking.CoachLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        int TrackID = Convert.ToInt32(reader["TrackID"]);
                        coachlocation.Add(new CoachLocation(CoachID, TrackID));
                    }
                }
            }
            return coachlocation;

        }

        public List<CoachInfo> GetAllCoachInfo()
        {
            List<CoachInfo> coachinfo = new List<CoachInfo>();
            string sqlString = "SELECT * FROM booking.CoachLocation";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachInfoID = Convert.ToInt32(reader["CoachInfoID"]);
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string Email = reader["Email"].ToString();
                        string PhoneNumber = reader["PhoneNumber"].ToString();
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        coachinfo.Add(new CoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl));
                    }
                }
            }
            return coachinfo;

        }

    }
}
