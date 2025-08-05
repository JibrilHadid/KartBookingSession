using KartBookingSession.Model;
using KartBookingSession.Repositories;
using KartBookingSession.View;

namespace KartBookingSession
{
    public class Program
    {
        private static StorageManager storageManager;
        private static consoleView view;

        string choice;

        static bool Notvalid = false;

        //things to do whilst other items are on hold 
        //code the prpgram part which is 
        /*
            switching between methods 
        log in function 
        having the displays and navigation betwen the methods 
        code the program parts of the update inserts and deletes 
        storage manager part of the inserts 

        3 roles 
        coaches are adimds of the database can view all and do all 
        tracks can view and edit there data 
        drivets same as tracks  
        tracks and drivers are going to have paramretized queries for only viewing their data (add a and statement in the sql query saying driver id = the driver id of the loged in person )
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KartBookingSession;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


            storageManager = new StorageManager(connectionString);
            view = new consoleView();


            while (true)
            {

                string choice = view.MainMenu();

                switch (choice)
                {
                    case "1":
                        {
                            view.LoginMenu();
                        }
                        break;
                    case "2":
                        {
                            view.RegisterMenu();
                        }
                        break;
                    default:
                        Console.WriteLine("Please input the correct option");
                        break;
                }
            }

        }


        


        public static void UserMenu()
        {
            while (true)
            {
                string choice = view.DisplayUserMenu();

                switch (choice)
                {
                    case "1":
                        view.tblCityForDriver();
                        break;
                    case "2":
                        view.tblCoachForDriver();
                        break;
                    case "3":
                        view.tblCoachInfoForDriver();
                        break;
                    case "4":
                        view.tblKartManufacturerForDriver();
                        break;
                    case "5":
                        view.tblKartsForDriver();
                        break;
                    case "6":
                        view.tblSuburbForDriver();
                        break;
                    case "7":
                        view.tblTracksForDriver();
                        break;
                    case "8":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void AdminOnlyMenu()
        {
            while (true)
            {
                string choice = view.DisplayAdminMenu();

                switch (choice)
                {
                    case "1":
                        view.tblCityForCoach();
                        break;
                    case "2":
                        view.tblCoachForCoach();
                        break;
                    case "3":
                        view.tblCoachInfoForCoach();
                        break;
                    case "4":
                        view.tblKartManufacturerForCoach();
                        break;
                    case "5":
                        view.tblKartsForCoach();
                        break;
                    case "6":
                        view.tblSuburbForCoach();
                        break;
                    case "7":
                        view.tblTracksForCoach();
                        break;
                    case "8":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static void UpdateCity()
        {
            Console.WriteLine("enter the id that you wish to update");
            int CityID = view.GetIntInput();

            Console.WriteLine("Which city name would you like to update ");
            string CityName = view.GetInput();

            Console.WriteLine("Which country would you like to update ");
            string Country = view.GetInput();

            int rowsaffected = storageManager.UpdateCity(CityID, CityName, Country);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateCoach()
        {
            Console.WriteLine("enter the id that you wish to update");
            int CoachID = view.GetIntInput();

            Console.WriteLine("enter the firstname you would like to update");
            string FirstName = view.GetInput();

            Console.WriteLine("enter the lastname you would like to update");
            string LastName = view.GetInput();

            Console.WriteLine("enter the which gender you would like to enter ");
            string Gender = view.GetInput();

            Console.WriteLine("enter which age you would like to update");
            int Age = view.GetIntInput();

            int rowsaffected = storageManager.UpdateCoach(CoachID, FirstName, LastName, Gender, Age);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateCoachInfo()
        {
            Console.WriteLine("enter the id that you wish to update");
            int CoachInfoID = view.GetIntInput();

            Console.WriteLine("enter the id that you wish to update ");
            int CoachID = view.GetIntInput();

            Console.WriteLine("enter the email you would like to update");
            string Email = view.GetInput();

            Console.WriteLine("enter the phonenumber you would like to update");
            int PhoneNumber = view.GetIntInput();

            Console.WriteLine("enter the which experience level you would like to update");
            string ExperienceLvl = view.GetInput();

            int rowsaffected = storageManager.UpdateCoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateKartManufacturer()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int ManufacturerID = view.GetIntInput();

            Console.WriteLine("enter the id that you wish to update ");
            int KartID = view.GetIntInput();

            Console.WriteLine("enter the manufacturer name you would like to update ");
            string ManufacturerName = view.GetInput();

            int rowsaffected = storageManager.UpdateKartManufacturer(ManufacturerID, KartID, ManufacturerName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateKarts()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int KartID = view.GetIntInput();

            Console.WriteLine("enter the kart name you would like to update");
            string KartName = view.GetInput();

            Console.WriteLine("enter the kart type you would like to update ");
            string KartType = view.GetInput();

            Console.WriteLine("enter the productiondate you would like to update ");
            DateTime ProductionDate = Convert.ToDateTime(view.GetIntInput());

            Console.WriteLine("enter the kart price you would like to update");
            double KartPrice = Convert.ToDouble(view.GetIntInput());

            int rowsaffected = storageManager.UpdateKarts(KartID, KartName, KartType, ProductionDate, KartPrice);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateSuburb()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int SuburbID = view.GetIntInput();

            Console.WriteLine("enter the suburb name you would like to update ");
            string SuburbName = view.GetInput();

            int rowsaffected = storageManager.UpdateSuburb(SuburbID, SuburbName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateTracks()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int TrackID = view.GetIntInput();

            Console.WriteLine("enter the track name you would like to update");
            string TrackName = view.GetInput();

            Console.WriteLine("enter the track type you would like to update");
            string TrackType = view.GetInput();

            int rowsaffected = storageManager.UpdateTracks(TrackID, TrackName, TrackType);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }










        public static void InsertCity()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int CityID = view.GetIntInput();

            Console.WriteLine("enter the new city name ");
            string CityName = view.GetInput();

            Console.WriteLine("enter the new country name ");
            string Country = view.GetInput();

            int rowsaffected = storageManager.InsertCity(CityID, CityName, Country);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertCoach()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int CoachID = view.GetIntInput();

            Console.WriteLine("enter the new first name ");
            string FirstName = view.GetInput();

            Console.WriteLine("enter the new last name ");
            string LastName = view.GetInput();

            Console.WriteLine("enter the new gender ");
            string Gender = view.GetInput();

            Console.WriteLine("enter the new age ");
            int Age = view.GetIntInput();

            int rowsaffected = storageManager.InsertCoach(CoachID, FirstName, LastName, Gender, Age);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertCoachInfo()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int CoachInfoID = view.GetIntInput();

            Console.WriteLine("enter the the new id you wuld like to add ");
            int CoachID = view.GetIntInput();

            Console.WriteLine("enter the new email ");
            string Email = view.GetInput();

            Console.WriteLine("enter the new phonenumber ");
            int PhoneNumber = view.GetIntInput();

            Console.WriteLine("enter the new experienceLvl ");
            string ExperienceLvl = view.GetInput();

            int rowsaffected = storageManager.InsertCoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertKartManufacturer()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int ManufacturerID = view.GetIntInput();

            Console.WriteLine("enter the the new id you wuld like to add ");
            int KartID = view.GetIntInput();

            Console.WriteLine("enter the new Manufacturer name ");
            string ManufacturerName = view.GetInput();

            int rowsaffected = storageManager.InsertKartManufacturer(ManufacturerID, KartID, ManufacturerName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertKarts()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int KartID = view.GetIntInput();

            Console.WriteLine("enter the new kart type ");
            string KartName = view.GetInput();

            Console.WriteLine("enter the new kart type ");
            string KartType = view.GetInput();

            Console.WriteLine("enter the new Production date ");
            DateTime ProductionDate = Convert.ToDateTime(view.GetIntInput());

            Console.WriteLine("enter the new Kart Price ");
            double KartPrice = Convert.ToDouble(view.GetIntInput());

            int rowsaffected = storageManager.InsertKarts(KartID, KartName, KartType, ProductionDate, KartPrice);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertSuburb()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int SuburbID = view.GetIntInput();

            Console.WriteLine("enter the new suburb name ");
            string SuburbName = view.GetInput();

            int rowsaffected = storageManager.InsertSuburb(SuburbID, SuburbName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertTracks()
        {
            Console.WriteLine("enter the the new id you wuld like to add ");
            int TrackID = view.GetIntInput();

            Console.WriteLine("enter the new track name ");
            string TrackName = view.GetInput();

            Console.WriteLine("enter the new track type ");
            string TrackType = view.GetInput();

            int rowsaffected = storageManager.InsertTracks(TrackID, TrackName, TrackType);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }






        public static void DeleteCity()
        {
            Console.WriteLine("enter the id that you wish to delete");
            int CityID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteCity(CityID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteCoach()
        {
            Console.WriteLine("enter the id that you wish to delete");
            int CoachID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteCoach(CoachID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteCoachInfo()
        {
            Console.WriteLine("enter the id that you wish to delete");
            int CoachInfoID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteCoachInfo(CoachInfoID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteKartManufacturer()
        {
            Console.WriteLine("enter the id that you wish to delete ");
            int ManufacturerID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteKartManufacturer(ManufacturerID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteKarts()
        {
            Console.WriteLine("enter the id that you wish to delete ");
            int KartID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteKarts(KartID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteSuburb()
        {
            Console.WriteLine("enter the id that you wish to delete ");
            int SuburbID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteSuburb(SuburbID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void DeleteTracks()
        {
            Console.WriteLine("enter the id that you wish to delete ");
            int TrackID = view.GetIntInput();

            int rowsaffected = storageManager.DeleteTracks(TrackID);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        /*
         * in your log in you get 4 things username password role and id
         * for the drivers update id is hard coded the id selected in the login
         */
    }
    }
    
