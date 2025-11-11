using KartBookingSession.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KartBookingSession.Repositories
{
    public class StorageManager
    {
        private static SqlConnection conn;

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
                
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred");
                Console.WriteLine(ex.Message);
            }
        }

       

        // gets username from the database
        public string getUsername(string Username)
        {
            string sqlString = "SELECT username FROM booking.tblDrivers WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Username = reader["Username"].ToString();
                    }
                }
            }
            return Username;
        }

        // gets password from the database
        public string getPassword(string Username)
        {
            string Password = "";
            string sqlString = "SELECT Password FROM booking.tblDrivers WHERE Username = @Username";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Password = reader["Password"].ToString();
                    }
                }
            }
            return Password;
        }

        // gets roleID from the database
        public int getRoleID(string Username)
        {
            int roleID = 0;

            string sqlString = "SELECT RoleID FROM booking.tblDrivers WHERE Username = @Username";


            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        roleID = Convert.ToInt32(reader["RoleID"]);
                    }
                }
            }
            return roleID;
        }
        // gets userID from the database
        public int getUserID(string Username)
        {
            int userID = 0;

            string sqlString = "SELECT RoleID FROM booking.tblDrivers WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userID = Convert.ToInt32(reader["RoleID"]);
                    }
                }
            }
            return userID;
        }

        // Registers a new user in the database
        public int RegisterUser(string Username, string Password, int RoleID, int Age)
        {
            string sql = "INSERT INTO booking.tblDrivers (Username, Password, RoleID) VALUES (@username, @password, @roleID);";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@age", Age);
                cmd.Parameters.AddWithValue("@roleID", RoleID);


                return cmd.ExecuteNonQuery();
            }
        }
        // runs advanced qry 1
        public void AdvancedQry1()
        {
            string sqlString = "SELECT KartID, KartPrice, ProductionDate FROM booking.tblKarts WHERE KartPrice >= 190.00 AND ProductionDate <= '2021-01-01' ";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int kartID = Convert.ToInt32(reader["kartID"]);
                        DateTime ProductionDate = Convert.ToDateTime(reader["ProductionDate"]);
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        Console.WriteLine($"Kart ID: {kartID}");
                        Console.WriteLine(ProductionDate);
                        Console.WriteLine($"Kart Price:{KartPrice}");
                        Console.WriteLine("---------------------");
                    }



                }
            }
        }

        // runs advanced qry 2
        public void AdvancedQry2()
        {
            string sqlString = "SELECT count(C.coachID) as totalCoaches, T.TrackID, T.trackName FROM location.tblTracks AS T, location.tblCoachLocation AS CL, booking.tblCoach as " +
                "C WHERE T.trackID = CL.trackID AND CL.coachID = C.coachID GROUP BY T.TrackID, T.trackName ORDER BY totalCoaches desc;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int coachID = Convert.ToInt32(reader["totalCoaches"]);
                        int TrackID = Convert.ToInt32(reader["TrackID"]);
                        string TrackName = reader["TrackName"].ToString();
                        Console.WriteLine($"Amount of coaches:{coachID}");
                        Console.WriteLine($"TrackID:{TrackID}");
                        Console.WriteLine(TrackName);
                        Console.WriteLine("---------------------");
                    }



                }
            }
        }

        // runs advanced qry 3
        public void AdvancedQry3()
        {
            string sqlString = "SELECT distinct(C.coachID), C.firstName, C.gender, CI.experienceLvl FROM booking.tblCoach as C, booking.tblCoachInfo as CI " +
                "WHERE C.coachID = CI.coachID AND C.gender = 'Male' AND C.firstName LIKE 'A%' ORDER BY C.firstName, C.gender, CI.experienceLvl;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string FirstName = reader["FirstName"].ToString();
                        string Gender = reader["Gender"].ToString();
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        Console.WriteLine($"Coach ID: {CoachID}");
                        Console.WriteLine(FirstName);
                        Console.WriteLine(Gender);
                        Console.WriteLine(ExperienceLvl);
                        Console.WriteLine("---------------------");
                    }
                }

            }
        }

        // runs advanced qry 4
        public void AdvancedQry4()
        {
            string sqlString = "SELECT T.trackType, C.firstName, C.lastName FROM location.tblTracks as T, location.tblCoachLocation as CL, booking.tblCoach as C WHERE T.trackID " +
                "= CL.trackID AND CL.coachID = C.coachID AND T.trackType = 'outdoor' ORDER BY T.trackType, C.firstName, C.lastName;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string TrackType = reader["TrackType"].ToString();
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["LastName"].ToString();
                        Console.WriteLine(TrackType);
                        Console.WriteLine($"Firstname:{FirstName}");
                        Console.WriteLine($"LastName:{LastName}");
                        Console.WriteLine("---------------------");


                    }
                }
            }
        }

        // runs advanced qry 5
        public void AdvancedQry5()
        {
            string sqlString = "SELECT C.firstName, C.lastName, CI.email, CI.phoneNumber FROM booking.tblCoach as C, booking.tblCoachInfo as CI WHERE C.coachID = " +
                "CI.coachID AND C.age > 30 ORDER BY C.firstName, C.lastName, C.age, CI.email, CI.phoneNumber;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["LastName"].ToString();
                        string Email = reader["Email"].ToString();
                        BigInteger PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                        Console.WriteLine(FirstName);
                        Console.WriteLine(LastName);
                        Console.WriteLine(Email);
                        Console.WriteLine(PhoneNumber);
                        Console.WriteLine("---------------------");
                    }
                }
            }
        }
        //runs complex qry 1
        public void ComplexQry1()
        {
            string sqlString = "SELECT Count(KM.manufacturerID) as totalManufacturers, K.productionDate FROM  booking.tblKarts as K, booking.tblKartManufacturer as KM WHERE K.kartID = KM.kartID AND K.productionDate BETWEEN '2020-01-01' AND '2021-12-31' GROUP BY K.productionDate ORDER BY totalManufacturers, K.productionDate;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ManufacturerID = Convert.ToInt32(reader["totalManufacturers"]);
                        DateTime ProductionDate = Convert.ToDateTime(reader["ProductionDate"]);
                        //string dateString = "2025-08-03 12:00:00 PM";
                        //DateTime ProductionDate = DateTime.Parse(dateString);
                        Console.WriteLine($"Total manufacturers:{ ManufacturerID}");
                        Console.WriteLine(ProductionDate);
                        Console.WriteLine("---------------------");
                    }
                }
            }
        }

        // runs complex qry 2
        public void ComplexQry2()
        {
            string sqlString = "SELECT count(coachID) as totalCoaches, gender FROM booking.tblCoach WHERE gender = 'Female' GROUP BY gender ORDER BY totalcoaches, gender;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["totalCoaches"]);
                        string Gender = reader["Gender"].ToString();
                        Console.WriteLine(CoachID);
                        Console.WriteLine(Gender);
                        Console.WriteLine("---------------------");
                    }
                }
            }
        }

        // runs complex qry 3
        public void ComplexQry3()
        {
            string sqlString = "SELECT avg(kartPrice) AS avgKartPrice FROM booking.tblKarts;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double KartPrice = Convert.ToDouble(reader["avgkartPrice"]);
                        Console.WriteLine($"Avg kart Price:{ KartPrice}");
                        Console.WriteLine("---------------------");

                    }
                }
            }
        }

        // runs complex qry 4
        public void ComplexQry4()
        {
            string sqlString = "SELECT Count(c.coachID) as totalCoach , CI.experienceLvl FROM booking.tblCoach as C, booking.tblCoachInfo as CI WHERE C.coachID = CI.coachID AND CI.experienceLvl = 'Advanced' GROUP BY CI.experienceLvl ORDER BY totalCoach, CI.experienceLvl;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["totalCoach"]);
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        Console.WriteLine("---------------------");
                        Console.WriteLine(CoachID);
                        Console.WriteLine(ExperienceLvl);
                        Console.WriteLine("---------------------");
                    }
                }
            }
        }

        // runs complex qry 5
        public void ComplexQry5()
        {
            string sqlString = "SELECT Count(kartType) as totalKart250cc FROM booking.tblKarts WHERE kartType = '250cc' ORDER BY totalKart250cc;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string KartType = reader["totalKart250cc"].ToString();
                        Console.WriteLine($" Amount of karts: {KartType}");
                        Console.WriteLine("---------------------");
                    }
                }
            }
        }




        // Retrieves all data from tblkarts
        public List<Karts> GetAllKarts()
        {
            List<Karts> karts = new List<Karts>();
            string sqlString = "SELECT * FROM booking.tblKarts";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int KartID = Convert.ToInt32(reader["KartID"]);
                        string kartName = reader["KartName"].ToString();
                        string kartType = reader["KartType"].ToString();
                        string dateString = "2025-08-03 12:00:00 PM";
                        DateTime ProductionDate = Convert.ToDateTime(reader["ProductionDate"]);
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        karts.Add(new Karts(KartID, kartName, kartType, ProductionDate, KartPrice));
                    }
                }
            }
            return karts;
        }
        // Retrieves all data from tblDrivers
        public List<Drivers> GetAllDrivers()
        {
            List<Drivers> drivers = new List<Drivers>();
            string sqlString = "SELECT * FROM booking.tblDrivers";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int RoleID = Convert.ToInt32(reader["RoleID"]);
                        string Username = reader["Username"].ToString();
                        string Password = reader["Password"].ToString();
                        drivers.Add(new Drivers(RoleID, Username, Password));
                    }
                }
            }
            return drivers;
        }
        // Retrieves all data from tblTracks
        public List<Tracks> GetAlltracks()
        {
            List<Tracks> tracks = new List<Tracks>();
            string sqlString = "SELECT * FROM location.tbltracks";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int TrackID = Convert.ToInt32(reader["TrackID"]);
                        string TrackName = reader["TrackName"].ToString();
                        string TrackType = reader["TrackType"].ToString();
                        tracks.Add(new Tracks(TrackID, TrackName, TrackType));
                    }
                }
            }
            return tracks;
        }
        // Retrieves all data from tblCity
        public List<City> GetAllCity()
        {
            List<City> city = new List<City>();
            string sqlString = "SELECT * FROM location.tblCity";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CityID = Convert.ToInt32(reader["CityID"]);
                        string CityName = reader["CityName"].ToString();
                        string Country = reader["Country"].ToString();
                        city.Add(new City(CityID, CityName, Country));
                    }
                }
            }
            return city;
        }
        // Retrieves all data from tblSuburb
        public List<Suburb> GetAllSuburb()
        {
            List<Suburb> suburb = new List<Suburb>();
            string sqlString = "SELECT * FROM location.tblsuburb";
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
        // Retrieves all data from tblKartManufacturer
        public List<KartManufacturer> GetAllKartManufacturer()
        {
            List<KartManufacturer> kartmanufacturer = new List<KartManufacturer>();
            string sqlString = "SELECT * FROM booking.tblKartManufacturer";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ManufacturerID = Convert.ToInt32(reader["ManufacturerID"]);
                        int KartID = Convert.ToInt32(reader["KartID"]);
                        string ManufacturerName = reader["ManufacturerName"].ToString();
                        kartmanufacturer.Add(new KartManufacturer(ManufacturerID, KartID, ManufacturerName));
                    }
                }
            }
            return kartmanufacturer;

        }
        // Retrieves all data from tblCoach
        public List<Coach> GetAllCoach()
        {
            List<Coach> coach = new List<Coach>();
            string sqlString = "SELECT * FROM booking.tblCoach";
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


        
        // Retrieves all data from tblCoachInfo
        public List<CoachInfo> GetAllCoachInfo()
        {
            List<CoachInfo> coachinfo = new List<CoachInfo>();
            string sqlString = "SELECT * FROM booking.tblCoachInfo";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int CoachInfoID = Convert.ToInt32(reader["CoachInfoID"]);
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        BigInteger PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                        string Email = reader["Email"].ToString();
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        coachinfo.Add(new CoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl));
                    }
                }
            }
            return coachinfo;

        }
 
        // runs the sql update city query
        public int UpdateCity(int CityID, string CityName, string Country)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblCity SET CityName = @CityName, Country = @Country", conn))
            {

                cmd.Parameters.AddWithValue("@CityID", CityID);
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@Country", Country);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update coach query
        public int UpdateCoach(int CoachID, string FirstName, string LastName, string Gender, int Age)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblCoach SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Age = @Age", conn))
            {

                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Age", Age);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update coachinfo query
        public int UpdateCoachInfo(int CoachInfoID, int CoachID, string Email, int PhoneNumber, string ExperienceLvl)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblCoachInfo SET Email = @Email, PhoneNumber = @PhoneNumber, ExperienceLvl = @ExperienceLvl", conn))
            {
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@ExperienceLvl", ExperienceLvl);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update kartmanufacturer query
        public int UpdateKartManufacturer(int ManufacturerID, int KartID, string ManufacturerName)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblKartManufacturer SET KartID = @KartID, ManufacturerName = @ManufacturerName", conn))
            {
                cmd.Parameters.AddWithValue("@KartID", KartID);
                cmd.Parameters.AddWithValue("@ManufacturerName", ManufacturerName);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update karts query
        public int UpdateKarts(int KartID, string KartName, string KartType, double KartPrice)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblKarts SET KartName = @KartName, KartType = @KartType, KartPrice = @KartPrice", conn))
            {

                cmd.Parameters.AddWithValue("@KartName", KartName);
                cmd.Parameters.AddWithValue("@KartType", KartType);
                cmd.Parameters.AddWithValue("@KartPrice", KartPrice);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update suburb query
        public int UpdateSuburb(int SuburbID, string SuburbName)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblSuburb SET SuburbName = @SuburbName", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbName", SuburbName);
                return cmd.ExecuteNonQuery();

            }
        }
        // runs the sql update tracks query
        public int UpdateTracks(int TrackID, string TrackName, string TrackType)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblTracks SET TrackName = @TrackName, TrackType = @TrackType", conn))
            {

                cmd.Parameters.AddWithValue("@TrackName", TrackName);
                cmd.Parameters.AddWithValue("@TrackType", TrackType);
                return cmd.ExecuteNonQuery();

            }
        }

        // Inserts a new location into the database
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
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        // Inserts a new city into the database
        public int InsertCity(string CityName, string Country)
        { 

        using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblCity (Country, CityName) VALUES (@Country, @CityName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CityName ", CityName);
                cmd.Parameters.AddWithValue("@Country ", Country);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new coach into the database
        public int InsertCoach(string FirstName, string LastName, string Gender, int Age)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblCoach ( FirstName, LastName, Gender, Age) VALUES (@FirstName, @LastName, @Gender, @Age); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@FirstName ", FirstName);
                cmd.Parameters.AddWithValue("@LastName ", LastName);
                cmd.Parameters.AddWithValue("@Gender ", Gender);
                cmd.Parameters.AddWithValue("@Age ", Age); 
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new coach info into the database
        public int InsertCoachInfo(int CoachID, string Email, int PhoneNumber, string ExperienceLvl)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblCoachInfo (CoachID, Email, PhoneNumber, ExperienceLvl) VALUES (@CoachID, @Email, @PhoneNumber, @ExperienceLvl); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CoachID ", CoachID);
                cmd.Parameters.AddWithValue("@Email ", Email);
                cmd.Parameters.AddWithValue("@PhoneNumber ", PhoneNumber);
                cmd.Parameters.AddWithValue("@ExperienceLvl ", ExperienceLvl);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new kart manufacturer into the database
        public int InsertKartManufacturer(int KartID, string ManufacturerName)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblKartManufacturer (KartID, ManufacturerName) VALUES (@KartID, @ManufacturerName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@KartID ", KartID);
                cmd.Parameters.AddWithValue("@ManufacturerName ", ManufacturerName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new kart into the database
        public int InsertKarts(string KartName, string KartType, DateTime ProductionDate, double KartPrice)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblKarts (KartName, KartType, ProductionDate, KartPrice) VALUES (@KartName, @KartType, @ProductionDate, @KartPrice); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@KartName ", KartName);
                cmd.Parameters.AddWithValue("@KartType ", KartType);
                cmd.Parameters.AddWithValue("@ProductionDate ", ProductionDate);
                cmd.Parameters.AddWithValue("@KartPrice ", KartPrice);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new suburb into the database
        public int InsertSuburb(int CityID,string SuburbName)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblSuburb (CityID, SuburbName) VALUES (@CityID, @SuburbName); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CityID ", CityID);
                cmd.Parameters.AddWithValue("@SuburbName ", SuburbName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Inserts a new track into the database
        public int InsertTracks(int SuburbID, string TrackName, string TrackType)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblTracks (SuburbID, TrackName, TrackType) VALUES (@SuburbID, @TrackName, @TrackType); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID ", SuburbID);
                cmd.Parameters.AddWithValue("@TrackName ", TrackName);
                cmd.Parameters.AddWithValue("@TrackType ", TrackType);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Deletes a location from the database
        public int DeleteCity(int CityID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblCity WHERE CityID =@CityID", conn))
            {
                cmd.Parameters.AddWithValue("@CityID", CityID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a coach from the database
        public int DeleteCoach(int CoachID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblCoach WHERE CoachID =@CoachID", conn))
            {
                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a coach info from the database
        public int DeleteCoachInfo(int CoachInfoID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblCoachInfo WHERE CoachInfoID =@CoachInfoID", conn))
            {
                cmd.Parameters.AddWithValue("@CoachInfoID", CoachInfoID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a kart manufacturer from the database
        public int DeleteKartManufacturer(int ManufacturerID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblKartManufacturer WHERE ManufacturerID =@ManufacturerID", conn))
            {
                cmd.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a kart from the database
        public int DeleteKarts(int KartID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblKarts WHERE KartID =@KartID", conn))
            {
                cmd.Parameters.AddWithValue("@KartID", KartID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a suburb from the database
        public int DeleteSuburb(int SuburbID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblSuburb WHERE SuburbID =@SuburbID", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID", SuburbID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Deletes a track from the database
        public int DeleteTracks(int TrackID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblTracks WHERE TrackID =@TrackID", conn))
            {
                cmd.Parameters.AddWithValue("@TrackID", TrackID);
                return cmd.ExecuteNonQuery();
            }
        }

        // Closes the database connection
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed.");
            }
        }

    }
}
    





