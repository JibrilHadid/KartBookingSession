using KartBookingSession.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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

        public string getUsername(string Username)
        {
            string sqlString = "SELECT user_name FROM booking.tblDrivers WHERE Username = @Username";

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
            return (Username);
        }


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


        public int getRoleID(string Username)
        {
            int roleID = 0;

            string sqlString = "SELECT Role_ID FROM booking.tblDrivers WHERE User_Name = @Username";


            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        roleID = Convert.ToInt32(reader["Role_ID"]);
                    }
                }
            }
            return (roleID);
        }

        public int getUserID(string Username)
        {
            int userID = 0;

            string sqlString = "SELECT User_ID FROM booking.tblDriver WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.AddWithValue("@Username", Username);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userID = Convert.ToInt32(reader["User_ID"]);
                    }
                }
            }
            return (userID);
        }


        public int RegisterUser(string Username, string Password, int RoleID, int Age)
        {
            string sql = "INSERT INTO tblDrivers (Username, Password, Age, Role_ID) VALUES (@username, @password, @age, @roleID)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", Username);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@age", Age);
                cmd.Parameters.AddWithValue("@roleID", RoleID);


                return cmd.ExecuteNonQuery();
            }
        }

        public void AdvancedQry1()
        {
            string sqlString = "SELECT KM.manufacturerName, K.kartPrice, K.productionDate FROM booking.tblKartManufacturer as KM, " +
                "booking.tblKarts as K Where K.kartID = KM.kartID AND(kartPrice <= 190.00;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int KartID = Convert.ToInt32(reader["KartID"]);
                        string KartName = reader["KartName"].ToString();
                        string KartType = reader["KartType"].ToString();
                        string dateString = "2025-08-03 12:00:00 PM";
                        DateTime ProductionDate = DateTime.Parse(dateString);
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        Console.WriteLine(KartID);
                        Console.WriteLine(KartName);
                        Console.WriteLine(KartType);
                        Console.WriteLine(ProductionDate);
                        Console.WriteLine(KartPrice);
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
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        int TrackID = Convert.ToInt32(reader["TrackID"]);
                        string TrackName = reader["kartType"].ToString();
                        Console.WriteLine(CoachID);
                        Console.WriteLine(TrackID);
                        Console.WriteLine(TrackName);
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
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string FirstName = reader["FirstName"].ToString();
                        string Gender = reader["Gender"].ToString();
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        Console.WriteLine(CoachID);
                        Console.WriteLine(FirstName);
                        Console.WriteLine(Gender);
                        Console.WriteLine(ExperienceLvl);
                    }
                }

            }
        }

        public void AdvancedQry4()
        {
            string sqlString = "SELECT T.trackType, C.firstName, C.lastName FROM location.tblTracks as T, location.tblCoachLocation as CL, booking.tblCoach as C WHERE T.trackID " +
                "= CL.trackID AND CL.coachID = C.coachID AND T.trackType = 'outdoor' ORDER BY T.trackType, C.firstName, C.lastName;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        string TrackType = reader["TrackType"].ToString();
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["LastName"].ToString();
                        Console.WriteLine(TrackType);
                        Console.WriteLine(FirstName);
                        Console.WriteLine(LastName);
                    }
                }
            }
        }

        public void AdvancedQry5()
        {
            string sqlString = "SELECT C.firstName, C.lastName, CI.email, CI.phoneNumber FROM booking.tblCoach as C, booking.tblCoachInfo as CI WHERE C.coachID = " +
                "CI.coachID AND C.age > 30 ORDER BY C.firstName, C.lastName, C.age, CI.email, CI.phoneNumber;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        string FirstName = reader["FirstName"].ToString();
                        string LastName = reader["LastName"].ToString();
                        string Email = reader["Email"].ToString();
                        int PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
                        Console.WriteLine(FirstName);
                        Console.WriteLine(LastName);
                        Console.WriteLine(Email);
                        Console.WriteLine(PhoneNumber);
                    }
                }
            }
        }

        public void ComplexQry1()
        {
            string sqlString = "SELECT Count(KM.manufacturerID) as totalManufacturers, K.productionDate FROM  booking.tblKarts as K, booking.tblKartManufacturer as KM WHERE K.kartID = KM.kartID AND K.productionDate BETWEEN '2020-01-01' AND '2021-12-31' GROUP BY K.productionDate ORDER BY totalManufacturers, K.productionDate;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int ManufacturerID = Convert.ToInt32(reader["ManufacturerID"]);
                        string dateString = "2025-08-03 12:00:00 PM";
                        DateTime ProductionDate = DateTime.Parse(dateString);
                        Console.WriteLine(ManufacturerID);
                        Console.WriteLine(ProductionDate);
                    }
                }
            }
        }

        public void ComplexQry2()
        {
            string sqlString = "SELECT count(coachID) as totalCoaches, gender FROM booking.tblCoach WHERE gender = 'Female' GROUP BY gender ORDER BY totalcoaches, gender;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string Gender = reader["Gender"].ToString();
                        Console.WriteLine(CoachID);
                        Console.WriteLine(Gender);
                    }
                }
            }
        }

        public void ComplexQry3()
        {
            string sqlString = "SELECT avg(kartPrice) as avgKartPrice FROM booking.tblKarts ORDER BY avgKartPrice;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        Console.WriteLine(KartPrice);

                    }
                }
            }
        }

        public void ComplexQry4()
        {
            string sqlString = "SELECT Count(c.coachID) as totalCoach , CI.experienceLvl FROM booking.tblCoach as C, booking.tblCoachInfo as CI WHERE C.coachID = CI.coachID AND CI.experienceLvl = 'Advanced' GROUP BY CI.experienceLvl ORDER BY totalCoach, CI.experienceLvl;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        int CoachID = Convert.ToInt32(reader["CoachID"]);
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        Console.WriteLine(CoachID);
                        Console.WriteLine(ExperienceLvl);
                    }
                }
            }
        }

        public void ComplexQry5()
        {
            string sqlString = "SELECT Count(kartType) as totalKart250cc FROM booking.tblKarts WHERE kartType = '50cc' ORDER BY totalKart250cc;";

            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        string KartType = reader["KartType"].ToString();
                        Console.WriteLine(KartType);
                    }
                }
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
                        string dateString = "2025-08-03 12:00:00 PM";
                        DateTime ProductionDate = DateTime.Parse(dateString);
                        double KartPrice = Convert.ToDouble(reader["KartPrice"]);
                        karts.Add(new Karts(KartID, kartName, kartType, ProductionDate, KartPrice));
                    }
                }
            }
            return karts;
        }

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
                        string TrackName = reader["TrackName"].ToString();
                        string TrackType = reader["TrackType"].ToString();
                        tracks.Add(new Tracks(TrackID, TrackName, TrackType));
                    }
                }
            }
            return tracks;
        }

        public List<City> GetAllCity()
        {
            List<City> city = new List<City>();
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
                        city.Add(new City(CityID, CityName, Country));
                    }
                }
            }
            return city;
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
                        int KartID = Convert.ToInt32(reader["KartID"]);
                        string ManufacturerName = reader["ManufacturerName"].ToString();
                        kartmanufacturer.Add(new KartManufacturer(ManufacturerID, KartID, ManufacturerName));
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
                        int PhoneNumber = Convert.ToInt32(reader["PhoneNumber"]);
                        string Email = reader["Email"].ToString();
                        string ExperienceLvl = reader["ExperienceLvl"].ToString();
                        coachinfo.Add(new CoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl));
                    }
                }
            }
            return coachinfo;

        }
        //change tablename to the right name repeat set fieldname etc for each field in the table you will have a console write line for each field then you need to JUST IGNORE FOR NOW LACHLAN WILL GET A BETTER VERSION 
        //update on hold 

        public int UpdateCity(int CityID, string CityName, string Country)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblCity SET CityID = @CityID, CityName = @CityName, Country = @Country", conn))
            {

                cmd.Parameters.AddWithValue("@CityID", CityID);
                cmd.Parameters.AddWithValue("@CityName", CityName);
                cmd.Parameters.AddWithValue("@Country", Country);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateCoach(int CoachID, string FirstName, string LastName, string Gender, int Age)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblCoach SET CoachID = @CoachID, FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Age = @Age", conn))
            {

                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Age", Age);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateCoachInfo(int CoachInfoID, int CoachID, string Email, int PhoneNumber, string ExperienceLvl)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblCoachInfo SET CoachInfoID = @CoachInfoID, CoachID = @CoachID, Email = @Email, PhoneNumber = @PhoneNumber, ExperienceLvl = @ExperienceLvl", conn))
            {

                cmd.Parameters.AddWithValue("@CoachInfoID", CoachInfoID);
                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@ExperienceLvl", ExperienceLvl);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateKartManufacturer(int ManufacturerID, int KartID, string ManufacturerName)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblKartManufacturer SET ManufacturerID = @ManufacturerID, KartID = @KartID, ManufacturerName = @ManufacturerName", conn))
            {

                cmd.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
                cmd.Parameters.AddWithValue("@KartID", KartID);
                cmd.Parameters.AddWithValue("@ManufacturerName", ManufacturerName);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateKarts(int KartID, string KartName, string KartType, DateTime ProductionDate, double KartPrice)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE booking.tblKarts SET KartID = @KartID, KartName = @KartName, KartType = @KartType, ProductionDate = @ProductionDate, KartPrice = @KartPrice", conn))
            {

                cmd.Parameters.AddWithValue("@KartID", KartID);
                cmd.Parameters.AddWithValue("@KartName", KartName);
                cmd.Parameters.AddWithValue("@KartType", KartType);
                cmd.Parameters.AddWithValue("@ProductionDate", ProductionDate);
                cmd.Parameters.AddWithValue("@KartPrice", KartPrice);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateSuburb(int SuburbID, string SuburbName)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblSuburb SET SuburbID = @SuburbID, SuburbName = @SuburbName", conn))
            {

                cmd.Parameters.AddWithValue("@SuburbID", SuburbID);
                cmd.Parameters.AddWithValue("@SuburbName", SuburbName);
                return cmd.ExecuteNonQuery();

            }
        }

        public int UpdateTracks(int TrackID, string TrackName, string TrackType)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE location.tblTracks SET TrackID = @TrackID, TrackName = @TrackName, TrackType = @TrackType", conn))
            {

                cmd.Parameters.AddWithValue("@TrackID", TrackID);
                cmd.Parameters.AddWithValue("@TrackName", TrackName);
                cmd.Parameters.AddWithValue("@TrackType", TrackType);
                return cmd.ExecuteNonQuery();

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
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }



        public int InsertCity(int CityID, string CityName, string Country)
        { 

        using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblCity ( Country, CityName, CityID) VALUES (@Country, @CityName, @CityID); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@CityName ", CityName);
                cmd.Parameters.AddWithValue("@Country ", Country);
                cmd.Parameters.AddWithValue("@CityID ", CityID);
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

        public int InsertCoachInfo(int CoachInfoID, int CoachID, string Email, int PhoneNumber, string ExperienceLvl)
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

        public int InsertKartManufacturer(int ManufacturerID, int KartID, string ManufacturerName)
        {

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO booking.tblKartManufacturer ( ManufacturerID, KartID, ManufacturerName) VALUES (@ManufacturerID, @ManufacturerName, @KartID); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@ManufacturerID ", ManufacturerID);
                cmd.Parameters.AddWithValue("@KartID ", KartID);
                cmd.Parameters.AddWithValue("@ManufacturerName ", ManufacturerName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int InsertKarts(int KartID, string KartName, string KartType, DateTime ProductionDate, double KartPrice)
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

            using (SqlCommand cmd = new SqlCommand($"INSERT INTO location.tblTracks ( TrackID, TrackName, TrackType) VALUES (@TrackID, @TrackName, @TrackType); SELECT SCOPE_IDENTITY(); ", conn))
            {
                cmd.Parameters.AddWithValue("@TrackID ", TrackID);
                cmd.Parameters.AddWithValue("@TrackName ", TrackName);
                cmd.Parameters.AddWithValue("@TrackType ", TrackType);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteCity(int CityID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblCity WHERE CityID =@CityID", conn))
            {
                cmd.Parameters.AddWithValue("@CityID", CityID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteCoach(int CoachID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblCoach WHERE CoachID =@CoachID", conn))
            {
                cmd.Parameters.AddWithValue("@CoachID", CoachID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteCoachInfo(int CoachInfoID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblCoachInfo WHERE CoachInfoID =@CoachInfoID", conn))
            {
                cmd.Parameters.AddWithValue("@CoachInfoID", CoachInfoID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteKartManufacturer(int ManufacturerID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblKartManufacturer WHERE ManufacturerID =@ManufacturerID", conn))
            {
                cmd.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteKarts(int KartID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM booking.tblKarts WHERE KartID =@KartID", conn))
            {
                cmd.Parameters.AddWithValue("@KartID", KartID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteSuburb(int SuburbID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblSuburb WHERE SuburbID =@SuburbID", conn))
            {
                cmd.Parameters.AddWithValue("@SuburbID", SuburbID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteTracks(int TrackID)
        {
            using (SqlCommand cmd = new SqlCommand($"DELETE FROM location.tblTracks WHERE TrackID =@TrackID", conn))
            {
                cmd.Parameters.AddWithValue("@TrackID", TrackID);
                return cmd.ExecuteNonQuery();
            }
        }

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