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
                        view.tblCity();
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
                                    Console.Clear();
                                    storageManager.simpleQry1();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
                                    break;

                                case "2":
                                    Console.Clear();
                                    storageManager.simpleQry2();
                                    Console.WriteLine("Press Enter to return to the query menu");
                                    Console.ReadLine();
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

                    case "8":
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
