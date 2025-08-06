using KartBookingSession.Model;
using KartBookingSession.Repositories;
using KartBookingSession.View;
using System.Data;

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
            string mdfPath = Path.Combine(AppContext.BaseDirectory, "Databasev2.mdf");
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={mdfPath};Integrated Security=True;Connect Timeout=30;";
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"kart booking sessions v2\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            storageManager = new StorageManager(connectionString);
            view = new consoleView(connectionString);




            bool loop = true;
            do
            {

                string choice = view.MainMenu();

                switch (choice)
                {
                    case "1":
                        {
                            view.LoginMenu();
                            loop = false;
                        }
                        break;
                    case "2":
                        {
                            view.RegisterMenu();
                            loop = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Please input the correct option");
                        break;
                }
            } while (loop);
            view.CloseConnection();
            storageManager.CloseConnection();
        }





        public static void UserMenu()
        {
            bool loop = true;
            bool loopQuerys = true;
            do
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
                        loop = false;
                        string input = "";
                        do
                        {
                            input = view.DisplayQurys();
                            switch (input)
                            {
                                case "1":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry1();
                                    break;
                                case "2":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry2();
                                    break;
                                case "3":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry3();
                                    break;
                                case "4":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry4();
                                    break;
                                case "5":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry5();
                                    break;
                                case "6":
                                    loopQuerys = false;
                                    storageManager.ComplexQry1();
                                    break;
                                case "7":
                                    loopQuerys = false;
                                    storageManager.ComplexQry2();
                                    break;
                                case "8":
                                    loopQuerys = false;
                                    storageManager.ComplexQry3();
                                    break;
                                case "9":
                                    loopQuerys = false;
                                    storageManager.ComplexQry4();
                                    break;
                                case "10":
                                    loopQuerys = false;
                                    storageManager.ComplexQry5();
                                    break;
                                case "11":
                                    storageManager.CloseConnection();
                                    Environment.Exit(0);
                                    loop = false;
                                    break;
                                default:
                                    Console.WriteLine("Please input the correct option");
                                    break;
                            }
                        } while (loopQuerys);
                        break;
                    case "9":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please input the correct option");
                        break;
                }
            } while (loop);
            bool MainMenuLoop = true;
            do
            {
                Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                string choiceloopans = view.GetInput().ToUpper();
                switch (choiceloopans)
                {
                    case "Y":
                        {
                            UserMenu();
                        }
                        break;
                    case "N":
                        {
                            Console.Clear();
                            Console.WriteLine("Good-Bye");
                            MainMenuLoop = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        MainMenuLoop = true;
                        break;
                }
            } while (MainMenuLoop);
        }

        public static void AdminOnlyMenu()
        {
            bool loop = true;
            bool loopQuerys = true;

            do
            {
                string choice = view.DisplayAdminMenu();

                switch (choice)
                {
                    case "1":
                        view.tblCityForCoach();
                        loop = false;
                        break;
                    case "2":
                        view.tblCoachForCoach();
                        loop = false;
                        break;
                    case "3":
                        view.tblCoachInfoForCoach();
                        loop = false;
                        break;
                    case "4":
                        view.tblKartManufacturerForCoach();
                        loop = false;
                        break;
                    case "5":
                        view.tblKartsForCoach();
                        loop = false;
                        break;
                    case "6":
                        view.tblSuburbForCoach();
                        loop = false;
                        break;
                    case "7":
                        view.tblTracksForCoach();
                        loop = false;
                        break;
                    case "8":
                        loop = false;
                        string input = "";
                        do
                        {
                            input = view.DisplayQurys();
                            switch (input)
                            {
                                case "1":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry1();
                                    break;
                                case "2":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry2();
                                    break;
                                case "3":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry3();
                                    break;
                                case "4":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry4();
                                    break;
                                case "5":
                                    loopQuerys = false;
                                    storageManager.AdvancedQry5();
                                    break;
                                case "6":
                                    loopQuerys = false;
                                    storageManager.ComplexQry1();
                                    break;
                                case "7":
                                    loopQuerys = false;
                                    storageManager.ComplexQry2();
                                    break;
                                case "8":
                                    loopQuerys = false;
                                    storageManager.ComplexQry3();
                                    break;
                                case "9":
                                    loopQuerys = false;
                                    storageManager.ComplexQry4();
                                    break;
                                case "10":
                                    loopQuerys = false;
                                    storageManager.ComplexQry5();
                                    break;
                                case "11":
                                    storageManager.CloseConnection();
                                    Environment.Exit(0);
                                    loop = false;
                                    break;
                                default:
                                    Console.WriteLine("Please input the correct option");
                                    break;
                            }
                        } while (loopQuerys);
                        break;
                    case "9":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Please input the correct option");
                        break;
                }
            } while (loop);
            bool MainMenuLoop = true;
            do
            {
                Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                string choiceloopans = view.GetInput().ToUpper();
                switch (choiceloopans)
                {
                    case "Y":
                        {
                            AdminOnlyMenu();
                        }
                        break;
                    case "N":
                        {
                            Console.Clear();
                            Console.WriteLine("Good-Bye");
                            MainMenuLoop = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        MainMenuLoop = true;
                        break;
                }
            } while (MainMenuLoop);
        }


        public static void UpdateCity()
        {
            Console.WriteLine("enter the id that you wish to update");
            int CityID = view.GetIntInput();

            Console.WriteLine("enter the new name of the city ");
            string CityName = view.GetInput();

            Console.WriteLine("enter the new name of the country ");
            string Country = view.GetInput();

            int rowsaffected = storageManager.UpdateCity(CityID, CityName, Country);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateCoach()
        {
            Console.WriteLine("enter the id that you wish to update");
            int CoachID = view.GetIntInput();

            Console.WriteLine("enter the new uptaded name for firstname ");
            string FirstName = view.GetInput();

            Console.WriteLine("enter the the new updated name for lastname ");
            string LastName = view.GetInput();

            Console.WriteLine("enter the new gender ");
            string Gender = view.GetInput();

            Console.WriteLine("enter the new age");
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

            Console.WriteLine("enter the new email");
            string Email = view.GetInput();

            Console.WriteLine("enter the new phonenumber");
            int PhoneNumber = view.GetIntInput();

            Console.WriteLine("enter the new experiencelvl");
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

            Console.WriteLine("enter the new name of the manufacturer ");
            string ManufacturerName = view.GetInput();

            int rowsaffected = storageManager.UpdateKartManufacturer(ManufacturerID, KartID, ManufacturerName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateKarts()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int KartID = view.GetIntInput();

            Console.WriteLine("enter the new name for the kart");
            string KartName = view.GetInput();

            Console.WriteLine("enter the new kart type for the kart");
            string KartType = view.GetInput();

            Console.WriteLine("enter the new date for the productiondate ");
            DateTime ProductionDate = Convert.ToDateTime(view.GetIntInput());

            Console.WriteLine("enter the new price for the kart");
            double KartPrice = Convert.ToDouble(view.GetIntInput());

            int rowsaffected = storageManager.UpdateKarts(KartID, KartName, KartType, ProductionDate, KartPrice);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateSuburb()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int SuburbID = view.GetIntInput();

            Console.WriteLine("enter the new name of the suburb ");
            string SuburbName = view.GetInput();

            int rowsaffected = storageManager.UpdateSuburb(SuburbID, SuburbName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void UpdateTracks()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int TrackID = view.GetIntInput();

            Console.WriteLine("enter the new name of the track");
            string TrackName = view.GetInput();

            Console.WriteLine("enter the new track type for the track");
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
            Console.WriteLine("add the the new id you wuld like to add ");
            int CoachID = view.GetIntInput();

            Console.WriteLine("add the new first name ");
            string FirstName = view.GetInput();

            Console.WriteLine("add the new last name ");
            string LastName = view.GetInput();

            Console.WriteLine("add the new gender ");
            string Gender = view.GetInput();

            Console.WriteLine("add the new age ");
            int Age = view.GetIntInput();

            int rowsaffected = storageManager.InsertCoach(CoachID, FirstName, LastName, Gender, Age);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertCoachInfo()
        {
            Console.WriteLine("add the the new id you wuld like to add ");
            int CoachInfoID = view.GetIntInput();

            Console.WriteLine("add the the new id you wuld like to add ");
            int CoachID = view.GetIntInput();

            Console.WriteLine("add the new email ");
            string Email = view.GetInput();

            Console.WriteLine("add the new phonenumber ");
            int PhoneNumber = view.GetIntInput();

            Console.WriteLine("add the new experienceLvl ");
            string ExperienceLvl = view.GetInput();

            int rowsaffected = storageManager.InsertCoachInfo(CoachInfoID, CoachID, Email, PhoneNumber, ExperienceLvl);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertKartManufacturer()
        {
            Console.WriteLine("add the the new id you wuld like to add ");
            int ManufacturerID = view.GetIntInput();

            Console.WriteLine("add the the new id you wuld like to add ");
            int KartID = view.GetIntInput();

            Console.WriteLine("add the new Manufacturer name ");
            string ManufacturerName = view.GetInput();

            int rowsaffected = storageManager.InsertKartManufacturer(ManufacturerID, KartID, ManufacturerName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertKarts()
        {
            Console.WriteLine("add the the new id you wuld like to add ");
            int KartID = view.GetIntInput();

            Console.WriteLine("add the new kart type ");
            string KartName = view.GetInput();

            Console.WriteLine("add the new kart type ");
            string KartType = view.GetInput();

            Console.WriteLine("add the new Production date ");
            DateTime ProductionDate = Convert.ToDateTime(view.GetIntInput());

            Console.WriteLine("add the new Kart Price ");
            double KartPrice = Convert.ToDouble(view.GetIntInput());

            int rowsaffected = storageManager.InsertKarts(KartID, KartName, KartType, ProductionDate, KartPrice);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertSuburb()
        {
            Console.WriteLine("add the the new id you wuld like to add ");
            int SuburbID = view.GetIntInput();

            Console.WriteLine("add the new suburb name ");
            string SuburbName = view.GetInput();

            int rowsaffected = storageManager.InsertSuburb(SuburbID, SuburbName);
            Console.WriteLine($"Rows affected: {rowsaffected}");
        }

        public static void InsertTracks()
        {
            Console.WriteLine("add the the new id you wuld like to add ");
            int TrackID = view.GetIntInput();

            Console.WriteLine("add the new track name ");
            string TrackName = view.GetInput();

            Console.WriteLine("add the new track type ");
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


       
    }
}
    
