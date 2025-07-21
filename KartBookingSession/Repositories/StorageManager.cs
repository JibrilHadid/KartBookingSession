using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        public void AdvancedQuery1()
        {
            List<AdvancedQry1> advancedQry1 = new List<AdvancedQry1>();
            string sqlString = "SELECT KM.manufacturerName, K.kartPrice, K.productionDate FROM booking.tblKartManufacturer as KM, " +
                "booking.tblKarts as K Where K.kartID = KM.kartID AND(kartPrice <= 190.00;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int kartID = Convert.ToInt32(reader["kartID"]);
                        string kartName = reader["kartName"].ToString();
                        string kartType = reader["kartType"].ToString();
                        string productionDate = reader["productionDate"].ToString();
                        double kartPrice = Convert.ToDouble(reader["kartPrice"]);
                        advancedQry1 = new AdvancedQry1(kartID, kartName, kartType, productionDate, kartPrice);
                    }
                
             

                }
            }
        }

        public void AdvancedQry2()
        {
            string sqlString = "SELECT count(C.coachID) as totalCoaches, T.trackName FROM location.tblTracks AS T, location.tblCoachLocation AS CL, booking.tblCoach as " +
                "C WHERE T.trackID = CL.trackID AND CL.coachID = C.coachID GROUP BY T.trackName ORDER BY totalCoaches desc;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                //using
            }
        }

        public void AdvancedQry3()
        {
            string sqlString = "SELECT distinct(C.coachID), C.firstName, C.gender, CI.experienceLvl FROM booking.tblCoach as C, booking.tblCoachInfo as CI " +
                "WHERE C.coachID = CI.coachID AND C.gender = 'Male' AND C.firstName LIKE 'A%' ORDER BY C.firstName, C.gender, CI.experienceLvl;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                //using
            }
        }

        public void AdvancedQry4()
        {
            string sqlString = "SELECT T.trackType, C.firstName, C.lastName FROM location.tblTracks as T, location.tblCoachLocation as CL, booking.tblCoach as C WHERE T.trackID " +
                "= CL.trackID AND CL.coachID = C.coachID AND T.trackType = 'outdoor' ORDER BY T.trackType, C.firstName, C.lastName;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                //using
            }
        }

        public void AdvancedQry5()
        {
            string sqlString = "SELECT C.firstName, C.lastName, CI.email, CI.phoneNumber FROM booking.tblCoach as C, booking.tblCoachInfo as CI WHERE C.coachID = " +
                "CI.coachID AND C.age > 30 ORDER BY C.firstName, C.lastName, C.age, CI.email, CI.phoneNumber;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                //using
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
                        string ProductionDate = reader["ProductionDate"].ToString();
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        karts.Add(new Karts(KartID, kartName, kartType, ProductionDate, KartPrice));
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
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["LastName"].ToString();
                        string Gender = reader["Gender"].ToString();
                        int Age = Convert.ToInt32(reader["CoachID"]);
                        coach.Add(new Coach(CoachID, FirstName, LastName, Gender, Age));
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
        public string UpdateCity(string CityName, string CityNameChange);
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.city SET CityName = @CityNameChange WHERE CityName = @CityName", conn))
            {
                cmd.Parameters.AddWithValue("@CityNameChange", CityNameChange);
                cmd.Parameters.AddWithValue("@CityName", CityName);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return "City name updated successfully.";
               
                } 
            }
        }
    }
}
