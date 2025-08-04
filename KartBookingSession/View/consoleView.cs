using KartBookingSession.Model;
using KartBookingSession.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartBookingSession.View
{
    public class consoleView
    {
        private static StorageManager storageManager;

        public consoleView(StorageManager manager)
        {
            storageManager = manager;
        }

        public consoleView()
        {
        }

        public string MainMenu()
        {
            Console.WriteLine("Hello and welcome to the main menu of the KartBookingSession");
            Console.WriteLine("Please enter one of the two options");
            Console.WriteLine("1: Log In");
            Console.WriteLine("2. Register");

            return Console.ReadLine();
        }

        public void LoginMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter your login details: ");

                Console.WriteLine("Please enter your Username: ");
                string AccountUsername = Console.ReadLine();

                Console.WriteLine("Please enter your Password: ");
                string AccountPassword = Console.ReadLine();

                string Username = storageManager.getUsername(AccountUsername);
                string Password = storageManager.getPassword(AccountUsername);
                int roleID = storageManager.getRoleID(AccountUsername);
                int userID = storageManager.getUserID(AccountUsername);

                if (!string.IsNullOrEmpty(Username) && AccountUsername.Equals(Username) && AccountPassword.Equals(Password))
                {
                    if (roleID == 1)
                    {
                        Program.AdminOnlyMenu();
                    }

                    else if (roleID == 2)
                    {
                        Program.UserMenu();
                    }

                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please re enter your details");
                    Console.WriteLine("Press enter to re-try");
                    Console.ReadLine();
                }
            }
        }

        public string RegisterMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the User Registration");

                Console.WriteLine("(Max 50 characters)");
                Console.Write("Please enter a username: ");
                string newUsername = Console.ReadLine();

                Console.WriteLine("(Max 50 characters)");
                Console.Write("Please enter a password: ");
                string newPassword = Console.ReadLine();

                Console.WriteLine("(minimum age 20, max age 80)");
                Console.Write("Please enter your age: ");
                string ageInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
                {
                    Console.WriteLine("Username or Password cannot be empty.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (newUsername.Length > 100 || newPassword.Length > 100)
                {
                    Console.WriteLine("Username/Password must be under 100 characters.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (!int.TryParse(ageInput, out int newAge) || newAge < 13 || newAge > 100)
                {
                    Console.WriteLine("Invalid age. Please enter a number between 13 and 100.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (newUsername.Length > 100 || newPassword.Length > 100)
                {
                    Console.WriteLine("Username/Password must be under 100 characters.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                int rowsInserted = storageManager.RegisterUser(newUsername, newPassword, RoleID: 2, newAge);

                if (rowsInserted > 0)
                {
                    Console.WriteLine("Registration successful!");

                    while (true)
                    {
                        Console.Write("Press Y to go to login or N to exit: ");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice == "Y")
                        {
                            MainMenu();
                            return newUsername;
                        }
                        else if (choice == "N")
                        {
                            storageManager.CloseConnection();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter Y or N.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Registration failed. Please press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }

        public string DisplayAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Kart Booking session, Coach");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-7");


            Console.WriteLine("1. tblRecordLabel");
            Console.WriteLine("2. tblArtist");
            Console.WriteLine("3. tblVinyl");
            Console.WriteLine("4. tblGenre");
            Console.WriteLine("5. tblReviews");
            Console.WriteLine("6. tblReviewComments");
            Console.WriteLine("7. Queries");
            Console.WriteLine("8. Exit");

            return Console.ReadLine();
        }

        //Displays User menu
        public string DisplayUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MusicDB (user)");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-7");

            Console.WriteLine("1. RecordLabel");
            Console.WriteLine("2. Artist");
            Console.WriteLine("3. Vinyl");
            Console.WriteLine("4. Genre");
            Console.WriteLine("5. Reviews");
            Console.WriteLine("6. Review Comments");
            Console.WriteLine("7. Exit");

            return Console.ReadLine();
        }

        public void TblDisplayMenu()
        {
            Console.WriteLine("Choose an option from 1-9");
            Console.WriteLine("1: City ");
            Console.WriteLine("2: Coaches ");
            Console.WriteLine("3: CoachInfo ");
            Console.WriteLine("4: CoachLocation ");
            Console.WriteLine("5: KartManufacturers ");
            Console.WriteLine("6: Karts ");
            Console.WriteLine("7: Suburbs ");
            Console.WriteLine("8: Tracks");
        }

        public void DisplayQryOrUpdate()
        {
            Console.Clear();
            Console.WriteLine("Please choose an option from 1-3");
            Console.WriteLine("1: Querys");
            Console.WriteLine("2: Edit The Data");
            Console.WriteLine("3: Search the Database for a specific field");
        }
        public void QrysMenu()
        {
            Console.WriteLine("Which query would you like to view");
            Console.WriteLine("Please choose an option from 1-19");
            Console.WriteLine("1: See karts that have a price equal to or more than $190.00 and was made before 2021-01-01");
            Console.WriteLine("2:  See the number of coaches on each track");
            Console.WriteLine("3:  See coaches thats first name starts with ‘A’ then also are males");
            Console.WriteLine("4:  See the coaches that only are at outdoor tracks");
            Console.WriteLine("5:  See coaches older than 30");
            Console.WriteLine("6:  See all karts that were produced between 2020-01-01 and 2021-12-31 and gets it from booking");
            Console.WriteLine("7:  See total coaches that are females");
            Console.WriteLine("8:  displays the average kart price");
            Console.WriteLine("9:  displays the total amount of coaches that teaches at a advanced level");
            Console.WriteLine("10: displays the total amount of karts that have 250cc");
            Console.WriteLine("11: See all data in the City Table");
            Console.WriteLine("12: See all data in the Coach Table");
            Console.WriteLine("14: See all data in the CoachInfo Table");
            Console.WriteLine("15: See all data in the CoachLocation Table");
            Console.WriteLine("16: See of all data in the KartManufacturer Table");
            Console.WriteLine("17: See of all data in the Karts Table");
            Console.WriteLine("18: See of all data in the Suburb Table");
            Console.WriteLine("19: See of all data in the Tracks Table");

        }




        public void DisplayUpdate()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

        }


        public void DisplayUpdate()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void DisplayUpdate()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void DisplayUpdate()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }




        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tblDepartments()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tblStreet()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }


        public void tbl()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void DisplayTables()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void Display()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void DisplayLocation()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


        }

        internal string GetInputIDK()
        {
            throw new NotImplementedException();
        }

        public void DisplayCity(List<City> cityTEMP)
        {
            foreach (City city in cityTEMP)
            {
                Console.WriteLine($"City ID: {city.city_id}| City Name: {city.city_name}| Country: {city.country}");
            }
        }

        public string GetInput()
        {
            string input;
            bool loop = true;
            do
            {
                input = Console.ReadLine().ToUpper();
                if (input.IsNullOrEmpty())
                {
                    loop = true;
                    Console.WriteLine("please enter a valid option");
                }
                else
                {
                    loop = false;
                }
            } while (loop);


            return input;
        }


        //gets the input of an string variable without making it uppercase so it can be used for inputs such as insert and updates 
        public string GetInputNotUpper()
        {
            string input;
            bool loop = true;
            do
            {
                input = Console.ReadLine();
                if (input.IsNullOrEmpty())
                {
                    loop = true;
                    Console.WriteLine("please enter a valid option");
                }
                else
                {
                    loop = false;
                }
            } while (loop);


            return input;
        }

        //gets the input of an int variable 
        public int GetIntInput()
        {
            string input;
            int IntInput = 0;
            bool loop = true;
            do
            {
                input = Console.ReadLine();
                bool number = IsAllDigits(input);
                if (input.IsNullOrEmpty() | number == false)
                {
                    Console.WriteLine("please input a valid option");
                    loop = true;
                }
                else
                {
                    IntInput = Convert.ToInt32(input);
                    loop = false;
                }
            } while (loop);
            return IntInput;
        }

        //checks if a string contains numbers
        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
