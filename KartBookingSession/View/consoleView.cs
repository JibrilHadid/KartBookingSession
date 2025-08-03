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
                Console.WriteLine("Please enter your login credentials: ");

                Console.WriteLine("Please enter your Username: ");
                string InputtedUsername = Console.ReadLine();

                Console.WriteLine("Please enter your Password: ");
                string InputtedPassword = Console.ReadLine();

                string Username = storageManager.getUsername(InputtedUsername);
                string Password = storageManager.getPassword(InputtedUsername);
                int roleID = storageManager.getRoleID(InputtedUsername);
                int userID = storageManager.getUserID(InputtedUsername);

                if (!string.IsNullOrEmpty(Username) && InputtedUsername.Equals(Username) && InputtedPassword.Equals(Password))
                {
                    if (roleID == 1)
                    {
                        Program.AdminMenu();
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

        internal string GetInput()
        {
            throw new NotImplementedException();
        }
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
