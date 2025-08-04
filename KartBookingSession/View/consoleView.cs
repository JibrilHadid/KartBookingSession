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
                    Console.WriteLine("Registration failed. Please press Enter to try again");
                    Console.ReadLine();
                }
            }
        }

        public string DisplayAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Kart Booking session, Coach");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-9");


            Console.WriteLine("1. tblCity");
            Console.WriteLine("2. tblCoach");
            Console.WriteLine("3. tblCoachInfo");
            Console.WriteLine("4. tblKartManufacturer");
            Console.WriteLine("5. tblKarts");
            Console.WriteLine("6. tblSuburb");
            Console.WriteLine("7. tblTracks");
            Console.WriteLine("8. Queries");
            Console.WriteLine("9. Exit");

            return Console.ReadLine();
        }

        //Displays User menu
        public string DisplayUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Kart Booking Session, driver");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-9");

            Console.WriteLine("1. City");
            Console.WriteLine("2. Coach");
            Console.WriteLine("3. CoachInfo");
            Console.WriteLine("4. KartManufacturer");
            Console.WriteLine("5. Karts");
            Console.WriteLine("6. Suburb");
            Console.WriteLine("7. Tracks");
            Console.WriteLine("8. Queries");
            Console.WriteLine("9. Exit");

            return Console.ReadLine();
        }

        //Displays tblCity options for Admin
        public void tblCityForCoach()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblCityForCoach");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all fields in tblCityForCoach");
                Console.WriteLine("2: Update a field in tblCityForCoach");
                Console.WriteLine("3: Insert a field in tblCityForCoach");
                Console.WriteLine("4: Delete a field in tblCityForCoach");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<City> city = storageManager.GetAllCity();
                        DisplayCity(city);
                        break;

                    case "2":
                        Program.UpdateCity();
                        break;

                    case "3":
                        Program.InsertCity();
                        break;

                    case "4":
                        Program.DeleteCity();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Displays tblCity options for Admin
        public void tblCoachForCoach()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblCoachForCoach");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all fields in tblCoachForCoach");
                Console.WriteLine("2: Update a field in tblCoachForCoach");
                Console.WriteLine("3: Insert a field in tblCoachForCoach");
                Console.WriteLine("4: Delete a field in tblCoachForCoach");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Coach> coach = storageManager.GetAllCoach();
                        DisplayCoach(coach);
                        break;

                    case "2":
                        Program.UpdateCity();
                        break;

                    case "3":
                        Program.InsertCity();
                        break;

                    case "4":
                        Program.DeleteCity();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Displays tblRecordLabel options for User
        public void tblCityForDriver()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblRecordlabel");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all existing Record Labels");
                Console.WriteLine("2: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<City> city = storageManager.GetAllCity();
                        DisplayCity(city);
                        break;

                    case "2":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
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

        public void DisplayCoach(List<Coach> coachTEMP)
        {
            foreach (Coach coach in coachTEMP)
            {
                Console.WriteLine($"Coach ID: {coach.coach_id}| FirstName: {coach.first_name}| LastName: {coach.last_name}| Gender: {coach.gender}| Age: {coach.age}");
            }
        }

        public void DisplayCoachInfo(List<CoachInfo> coachinfoTEMP)
        {
            foreach (CoachInfo coachinfo in coachinfoTEMP)
            {
                Console.WriteLine($"CoachInfo ID: {coachinfo.coachinfo_id}| Coach ID: {coachinfo.coach_id}| Email: {coachinfo.email}| PhoneNumber: {coachinfo.phone_number}| ExperienceLvl: {coachinfo.experience_lvl}");
            }
        }

        public void DisplayCoachLocation(List<CoachLocation> coachlocationTEMP)
        {
            foreach (CoachLocation coachlocation in coachlocationTEMP)
            {
                Console.WriteLine($"Coach ID: {coachlocation.coach_id}| Track ID: {coachlocation.track_id}");
            }
        }

        public void DisplayKartManufacturer(List<KartManufacturer> kartmanufacturerTEMP)
        {
            foreach (KartManufacturer kartmanufacturer in kartmanufacturerTEMP)
            {
                Console.WriteLine($"Manufacturer ID: {kartmanufacturer.manufacturer_id}| Kart ID: {kartmanufacturer.kart_id}| ManufacturerName: {kartmanufacturer.manufacturer_name}");
            }
        }

        public void DisplayKarts(List<Karts> kartsTEMP)
        {
            foreach (Karts karts in kartsTEMP)
            {
                Console.WriteLine($"Kart ID: {karts.kart_id}| KartName: {karts.kart_name}| KartType: {karts.kart_type}| ProductionDate: {karts.production_date}| KartPrice: {karts.kart_price}| ");
            }
        }

        public void DisplaySuburb(List<Suburb> suburbTEMP)
        {
            foreach (Suburb suburb in suburbTEMP)
            {
                Console.WriteLine($"Suburb ID: {suburb.suburb_id}| SuburbName: {suburb.suburb_name}");
            }
        }

        public void DisplayTracks(List<Tracks> tracksTEMP)
        {
            foreach (Tracks tracks in tracksTEMP)
            {
                Console.WriteLine($"Track ID: {tracks.track_id}| TrackName: {tracks.track_name}| TrackType: {tracks.track_type}");
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
