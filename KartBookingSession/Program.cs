using KartBookingSession.Repositories;
using KartBookingSession.View;

namespace KartBookingSession
{
    public class Program
    {
        private static StorageManager storageManager;
        private static consoleView view;
        static int role;

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

            MainMenu();
            storageManager.CloseConnection(); 
        }

        public static void MainMenu()
        {

            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            string MainChoice;
            do 
            {
                view.MainMenu(); 
                MainChoice = view.GetInput(); 
                switch (MainChoice)
                {

                    case "1":
                        {
                            Console.Clear();
                            LogIn();
                            loop = false;
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            RegisterUser();
                            loop = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter a valid option");
                            logInBool = true;
                        }
                        break;
                }
            } while (loop);
        }

        public static void SwitchMainAdmin()
        {

            Console.Clear();

            bool NotValidMain = true;
            string tblchoice;
            string choice;
            bool loop = true;
            bool logInBool = true;
            string employeeChoice;
            logInBool = false;
            Console.WriteLine("welcome admin");
            do
            {
                do
                {
                    view.DisplayQryOrUpdate();
                    string choiceQry = view.GetInput();
                    switch (choiceQry)
                    {
                        case "1":
                            {
                                DisplayQrySwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        case "2":
                            {
                                DisplayUpdatesSwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        case "3":
                            {
                                searchQrySwitch();
                                loop = false;
                                NotValidMain = false;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Please enter a valid Username and Password");
                                loop = true;
                                NotValidMain = true;
                            }
                            break;
                    }
                } while (NotValidMain);
                bool MainMenuLoop = true;
                do
                {
                    Console.WriteLine("Do you wish to go back to the main menu enter Y/N");
                    string choiceloopans = view.GetInput().ToUpper();
                    switch (choiceloopans)
                    {
                        case "Y":
                            {
                                MainMenuLoop = false;
                                loop = true;
                            }
                            break;
                        case "N":
                            {
                                Console.Clear();
                                Console.WriteLine("Good-Bye");
                                MainMenuLoop = false;
                                loop = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid option please try again.");
                            NotValidMain = false;
                            break;
                    }
                } while (MainMenuLoop);
            } while (loop);
        }

        public static void searchQrySwitch()
        {
            string Table = "";
            string Field = "";
            string choice = "";
            bool NotValidMain = true;
            bool loop = true;
            string TableChoice;
            string FieldChoice;
            int TableChoiceInt;
            int FieldChoiceInt;
            Console.Clear();
            do
            {
                view.DisplayTables();
                TableChoiceInt = view.GetIntInput();
                TableChoice = TableChoiceInt.ToString();
                switch (TableChoice)
                {
                    case "1":
                        {
                            NotValidMain = false;
                            Table = "booking.tblKarts";
                            do
                            {
                                view.DisplayKartsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "kartID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "kartType";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "kartName";
                                        }
                                        break;
                                    case "4":
                                        {
                                            loop = false;
                                            Field = "productionDate";
                                        }
                                        break;
                                    case "5":
                                        {
                                            loop = false;
                                            Field = "kartPrice";
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid option please try again.");
                                            loop = true;
                                        }
                                        break;
                                }
                            } while (loop); 
                        }
                        break; 
                    default:
                        {
                            Console.WriteLine("Invalid table option, please try again.");
                            NotValidMain = true;
                        }
                        break;
                }
            } while (NotValidMain);
           
        }
    }
}
                           

                       
              
