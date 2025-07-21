using KartBookingSession.Repositories;
using KartBookingSession.View;

namespace KartBookingSession
{
    public class Program
    {
        private static StorageManager storageManager;
        private static consoleView view;
        static int role;
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
                            Table = "Employee.tblEmployeesDetails";
                            do
                            {
                                view.DisplayEmployeeDetailsFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "EmployeeID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "FirstName";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "LastName";
                                        }
                                        break;
                                    case "4":
                                        {
                                            loop = false;
                                            Field = "HireDate";
                                        }
                                        break;
                                    case "5":
                                        {
                                            loop = false;
                                            Field = "JobID";
                                        }
                                        break;
                                    case "6":
                                        {
                                            loop = false;
                                            Field = "RoleID";
                                        }
                                        break;
                                    case "7":
                                        {
                                            loop = false;
                                            Field = "Email";
                                        }
                                        break;
                                    case "8":
                                        {
                                            loop = false;
                                            Field = "PhoneNumber";
                                        }
                                        break;
                                    case "9":
                                        {
                                            loop = false;
                                            Field = "Wage";
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
                            if (Field.Equals("HireDate"))
                            {
                                Console.WriteLine("what date do you wish to see ");
                                Console.WriteLine("Use the format dd-mm-yyyy");
                                choice = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"what {Field} do you wish to see:");
                                choice = view.GetInput();
                            }
                            List<SearchEmployeeDetails> employee = storageManager.GetSearchQryEmpDet(Table, Field, choice);
                            view.DisplaySearchEmployeeDetailsPages(employee);

                        }
                        break;
                    case "2":
                        {
                            NotValidMain = false;
                            Table = "Location.tblLocation";
                            do
                            {
                                view.DisplayLocationFields();
                                FieldChoiceInt = view.GetIntInput();
                                FieldChoice = FieldChoiceInt.ToString();
                                switch (FieldChoice)
                                {
                                    case "1":
                                        {
                                            loop = false;
                                            Field = "LocationID";
                                        }
                                        break;
                                    case "2":
                                        {
                                            loop = false;
                                            Field = "LocationName";
                                        }
                                        break;
                                    case "3":
                                        {
                                            loop = false;
                                            Field = "CountryID";
                                        }
                                        break;
                                    case "4":
                                        {
                                            loop = false;
                                            Field = "SuburbID";
                                        }
                                        break;
                                    case "5":
                                        {
                                            loop = false;
                                            Field = "StreetID";
                                        }
                                        break;
                                    case "6":
                                        {
                                            loop = false;
                                            Field = "CityID";
                                        }
                                        break;
                                    case "7":
                                        {
                                            loop = false;
                                            Field = "StreetNumber";
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
                            Console.WriteLine($"what {Field} do you wish to see:");
                            choice = view.GetInput();
                            List<SearchLocation> locations = storageManager.GetSearchQryLocation(Table, Field, choice);
                            view.DisplaySearchLocationPages(locations);
                        }
