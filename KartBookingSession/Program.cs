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
                            RegisterMenu();
                        }
                        break;
                    default:
                        Console.WriteLine("Please input the correct option");
                        break;
                }
            }

        }

        public static void AdminOnlyMenu()
        {
            while (true)
            {
                Console.Clear();
                string choice = view.DisplayAdminMenu();

                switch (choice)
                {
                    case "1":
                        bool loop = true;
                       
                        do
                        {
                            view.MainMenu(); // change it to the name of the view method that has the writelines for this table 
                            input = view.GetIntInput();
                            switch (input)
                            {
                                case "1":
                                    storageManager.GetAllCity();
                                    loop = false;
                                    List<City> cities = storageManager.GetAllCity();
                                    view.DisplayCity(cities);
                                    //view data for the tab;le 
                                    break;
                                case "2":
                                    UpdateCity();
                                    loop = false;
                                    break;
                                default:
                                    break;
                            }
                        } while (loop);
                        break;
                    case "2":
                        ;
                        view.tblCoach();
                        break;

                    case "3":
                        view.tblCoachInfo();
                        break;

                    case "4":
                        view.tblCoachLocation();
                        break;

                    case "5":
                        view.tblKartManufacturer();
                        break;

                    case "6":
                        view.tblKarts();
                        break;

                    case "7":
                        view.tblSuburb();
                        break;

                    case "8":
                        view.tblTracks();
                        break;

                    case "9":
                        view.tblDrivers();
                        break;

                    case "10":
                        while (true)
                        {
                            view.QueryOptions();

                            Console.Write("Please enter one of the following options: ");
                            string queryChoice = Console.ReadLine();

                            switch (queryChoice)
                            {
                                case "1":
                                    {
                                        Console.Clear();
                                        storageManager.GetAllCity();
                                        loop = false;
                                        List<City> cities = storageManager.GetAllCity();
                                        view.DisplayCity(cities);
                                        //view data for the table 
                                        break;
                                    }
                                case "2":
                                    {
                                        UpdateCity();
                                        loop = false;
                                        break;
                                    } while (loop) ;
                                    break;
                                case "3":
                                    {
                                        InsertCity();
                                        loop = false;
                                        break;
                                    } while (loop) ;
                                    break;
                            }




                                case "2":
                                    Console.Clear();
                                    storageManager.GetAlltracks();
                                    loop = false;
                                    List<Tracks> tracks = storageManager.GetAlltracks();
                                    view.DisplayCity(tracks);
                                    break;

                                case "3":
                                    Console.Clear();
                                    storageManager.simpleQry3();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "4":
                                    Console.Clear();
                                    storageManager.SimpleQry4();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "5":
                                    Console.Clear();
                                    storageManager.SimpleQry5();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "6":
                                    Console.Clear();
                                    storageManager.AdvancedQry1();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "7":
                                    Console.Clear();
                                    storageManager.AdvancedQry2();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "8":
                                    Console.Clear();
                                    storageManager.AdvancedQry3();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "9":
                                    Console.Clear();
                                    storageManager.AdvancedQry4();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "10":
                                    Console.Clear();
                                    storageManager.AdvancedQry5();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "11":
                                    Console.Clear();
                                    storageManager.ComplexQry1();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "12":
                                    Console.Clear();
                                    storageManager.ComplexQry2();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "13":
                                    Console.Clear();
                                    storageManager.ComplexQry3();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "14":
                                    Console.Clear();
                                    storageManager.ComplexQry4();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "15":
                                    Console.Clear();
                                    storageManager.ComplexQry5();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "16":
                                    break;

                                default:
                                    Console.WriteLine("Invalid query option. Try again.");
                                    continue;
                            }
                            if (queryChoice == "16")
                            {
                                break;
                            }
                        }
                        break;

                    case "17":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
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
                        view.tblRecordLabelU();
                        break;
                    case "2":
                        view.tblArtistU();
                        break;
                    case "3":
                        view.tblVinylU();
                        break;
                    case "4":
                        view.tblGenreU();
                        break;
                    case "5":
                        view.tblReviewsU();
                        break;
                    case "6":
                        view.tblReviewCommentsU();
                        break;
                    case "7":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void UpdateRecordLabelsName()
        {
            int RecordLabelID;
            while (true)
            {
                view.DisplayMessage("Enter the RecordLabel_ID to update: ");
                RecordLabelID = view.GetIntInput();

                if (storageManager.RecordLabelExists(RecordLabelID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Record Label ID does not exist or was not found, please try again.");
                }
            }

            string RecordLabelName;
            while (true)
            {
                view.DisplayMessage("Enter the new Record Label name: ");
                RecordLabelName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(RecordLabelName) && RecordLabelName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Record Label Name cannot be empty or more than 100 characters, please try again.");
                }
            }
            ;
            int rowsAffected = storageManager.UpdateRecordLabelsName(RecordLabelID, RecordLabelName);
            view.DisplayMessage($"Rows affected {rowsAffected}");

            public static void UpdateCity()
        {
            Console.WriteLine("enter the id that you wish to update ");
            int CityID = view.GetIntInput();

            Console.WriteLine("enter the new city name ");
            string CityName = view.GetInput();

            Console.WriteLine("enter the new country name ");
            string Country = view.GetInput();

            int rowsaffected = storageManager.UpdateCity(CityID,CityName,Country);
            Console.WriteLine($"Rows affected: {rowsaffected}");

            /*
             * in your log in you get 4 things username password role and id
             * for the drivers update id is hard coded the id selected in the login
             */
        }
    }
    }
