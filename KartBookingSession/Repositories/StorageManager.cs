using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
                        Console.WriteLine(kartID);
                        Console.WriteLine(kartName);
                        Console.WriteLine(kartType);
                        Console.WriteLine(productionDate);
                        Console.WriteLine(kartPrice);
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
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int coachID = Convert.ToInt32(reader["coachID"]);
                        int trackID = Convert.ToInt32(reader["trackID"]);
                        string trackName = reader["kartType"].ToString();
                        Console.WriteLine(coachID);
                        Console.WriteLine(trackID);
                        Console.WriteLine(trackName);
                    }



                }
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
        //change tablename to the right name repeat set fieldname etc for each field in the table you will have a console write line for each field then you need to JUST IGNORE FOR NOW LACHLAN WILL GET A BETTER VERSION 
        //update on hold 
        public string UpdateDept(string fieldChoice, int LocationID, string Change)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE TableNAME SET FieldName =@ FieldNameChange Where ID = @inputedID", conn))
            {
                cmd.Parameters.AddWithValue("@fieldChoice", fieldChoice);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@Change", Change);
                return cmd.ExecuteNonQuery().ToString();
            }
        }

        //change the table to the right name change the values for each field in your porject and add the console view and program part 
        //console view part you can just code the writelines in the program.cs with the inputs eg enter a new streetnumber etc for each field in that table 
        //program part is just you get the inputs for the fields and then call this method parameters of the values 
        public int InsertLocation(string LocationName, int CountryID, int SuburbID, int StreetID, int CityID, int StreetNumber)
        {
            bool Active = true;
            using (SqlCommand cmd = new SqlCommand($"INSERT INTO Location.tblLocation (locationName, CountryID, SuburbID, StreetID, CityID, StreetNumber, Active) VALUES (@LocationName ,@CountryID,  @SuburbID ,@StreetID ,@CityID ,@StreetNumber ,@Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@LocationName ", LocationName);
                cmd.Parameters.AddWithValue("@CountryID  ", CountryID);
                cmd.Parameters.AddWithValue("@SuburbID", SuburbID);
                cmd.Parameters.AddWithValue("@StreetID ", StreetID);
                cmd.Parameters.AddWithValue("@CityID  ", CityID);
                cmd.Parameters.AddWithValue("@StreetNumber", StreetNumber);
                cmd.Parameters.AddWithValue("@Active", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }



        public int InsertCity(int CityID, string CityName, string Country)
        { 

        using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblCity ( Country, CityName, CityID, Active) VALUES (@Country, @CityName, @CityID, @Active); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CityName ", CityName);
                cmd.Parameters.AddWithValue("@Country ", Country);
                cmd.Parameters.AddWithValue("@CityID ", CityID);
                cmd.Parameters.AddWithValue("@Active ", Active);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertCoach(int CoachID, string FirstName, string LastName, string Gender, int Age)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblCoach ( CoachID , FirstName, LastName, Gender, Age) VALUES (@CoachID, @FirstName, @LastName, @Gender, @Age); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CoachID ", CoachID);
                cmd.Parameters.AddWithValue("@FirstName ", FirstName);
                cmd.Parameters.AddWithValue("@LastName ", LastName);
                cmd.Parameters.AddWithValue("@Gender ", Gender);
                cmd.Parameters.AddWithValue("@Age ", Age); 
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertCoachInfo(int CoachInfoID, int CoachID, string Email, string PhoneNumber, string ExperienceLvl)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblCoachInfo ( CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl) VALUES (@CoachInfoID, @CoachID, @Email, @PhoneNumber, @ExperienceLvl); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CoachInfoID ", CoachInfoID);
                cmd.Parameters.AddWithValue("@CoachID ", CoachID);
                cmd.Parameters.AddWithValue("@Email ", Email);
                cmd.Parameters.AddWithValue("@PhoneNumber ", PhoneNumber);
                cmd.Parameters.AddWithValue("@ExperienceLvl ", ExperienceLvl);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertCoachLocation(int CoachID, int TrackID)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblCoachLocation ( CoachID, TrackID) VALUES (@CoachID, @TrackID); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CoachID ", CoachID);
                cmd.Parameters.AddWithValue("@TrackID ", TrackID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertKartManufacturer(int ManufacturerID, string ManufacturerName)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblKartManufacturer ( ManufacturerID, ManufacturerName) VALUES (@ManufacturerID, @ManufacturerName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@ManufacturerID ", ManufacturerID);
                cmd.Parameters.AddWithValue("@ManufacturerName ", ManufacturerName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertKarts(int KartID, string KartName, string KartType, string ProductionDate, double KartPrice)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblKarts ( KartID, KartName, KartType, ProductionDate, KartPrice) VALUES (@KartID, @KartName, @KartType, @ProductionDate, @KartPrice); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@KartID ", KartID);
                cmd.Parameters.AddWithValue("@KartName ", KartName);
                cmd.Parameters.AddWithValue("@KartType ", KartType);
                cmd.Parameters.AddWithValue("@ProductionDate ", ProductionDate);
                cmd.Parameters.AddWithValue("@KartPrice ", KartPrice);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertSuburb(int SuburbID, string SuburbName)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblSuburb ( SuburbID, SuburbName) VALUES (@SuburbID, @SuburbName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID ", SuburbID);
                cmd.Parameters.AddWithValue("@SuburbName ", SuburbName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertTracks(int TrackID, string TrackName, string TrackType)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblSuburb ( SuburbID, SuburbName) VALUES (@SuburbID, @SuburbName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID ", SuburbID);
                cmd.Parameters.AddWithValue("@SuburbName ", SuburbName);
                cmd.Parameters.AddWithValue("@SuburbName ", SuburbName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
        //deletes are on hold 
    





/*
          public int Insert--(string --, int --, int --)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO ___ ( --------,--------,-------- ) VALUES (--------,--------,--------); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@_______ ", ____);
                cmd.Parameters.AddWithValue("@_-----  ", ____);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
*/