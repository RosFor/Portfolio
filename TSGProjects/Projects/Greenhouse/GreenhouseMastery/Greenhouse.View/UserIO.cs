using Greenhouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenhouse.View
{
    public class UserIO
    {
        public string GetUserString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter a valid string. Press any key to try again.");
                    continue;
                }
                else
                {
                    return userInput;
                }
            }
        }
        public string EditPlantType(string plantType)
        {
            while (true)
            {
                return plantType;
            }
        }
        public string GetNewCustomerName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter a valid string. Press any key to try again.");
                    continue;
                }
                if (CheckCustomerName(userInput) == false)
                {
                    Console.WriteLine("Enter a valid string. Press any key to try again.");
                    continue;
                }
                if (CheckCustomerName(userInput) == true)
                {
                    return userInput;
                }
            }
        }
        public string EditCustomerName(string customerName)
        {
            while (true)
            {
                if (CheckCustomerName(customerName) == false)
                {
                    Console.WriteLine("Enter a valid string. Press any key to try again.");
                    continue;
                }
                if (CheckCustomerName(customerName) == true)
                {
                    return customerName;
                }
            }
        }
        public string GetUserStateAbbr(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter a valid string. Press any key to try again.");
                    continue;
                }
                else if(userInput.Length > 2)
                {
                    Console.WriteLine("Enter the state abbreviation.Press any key to try again.");
                    continue;
                }
                else
                {
                    return userInput;
                }
            }
        }
        public string EditStateAbbr(string state)
        {
            while (true)
            {
                if (state.Length > 2)
                {
                    Console.WriteLine("Enter the state abbreviation.Press any key to try again.");
                    continue;
                }
                else
                {
                    return state;
                }
            }
        }
        public int GetUserInt(string prompt)
        {
            int intValue;

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out intValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Press any key to try again.");
                }
            }
            return intValue;
        }
        public int GetUserInt(string prompt, int min, int max)
        {
            int intValue;

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out intValue))
                {
                    if (intValue >= min && intValue <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not between {0} and {1}. Please try again.", min, max);
                    }
                }
                else
                {
                    Console.WriteLine("Press any key to try again.");
                }
            }
            return intValue;
        }
        public int EditOrderQuantity(string prompt, int orderQuantity, int min, int max)
        {
            int intValue;

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out intValue))
                {
                    if (intValue >= min && intValue <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not between {0} and {1}. Please try again.", min, max);
                    }
                }
                else
                {
                    if(userInput == string.Empty)
                    {
                        intValue = orderQuantity;
                        break;
                    }
                    Console.WriteLine("Press any key to try again.");
                }
            }
            return intValue;
        }
        public DateTime GetOrderDate(string prompt)
        {
            DateTime minDate;
            DateTime maxDate;
            DateTime userDate;
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                
                if (!DateTime.TryParse(userInput, out userDate))
                {
                    Console.WriteLine("Please enter a date. Press any key to try again.");
                    continue;
                }
                if (userDate <= DateTime.Today)
                {
                    Console.WriteLine("Please enter a future date. Press any key to try again.");
                    continue;
                }
                
                minDate = new DateTime(userDate.Year, 3, 1);
                maxDate = new DateTime(userDate.Year, 8, 31);
                
                //Range: 3/1/?? & 8/31/??
                if (userDate >= minDate && userDate <= maxDate)
                {
                    return userDate;
                }
                else
                {
                    Console.WriteLine("Choose a date between 3/1 and 8/31. Press any key to try again.");
                    continue;
                }
            }
        }
        public DateTime GetLookupDate(string prompt)
        {
            DateTime minDate = new DateTime(DateTime.Now.Year, 3, 1);
            DateTime maxDate = new DateTime(DateTime.Now.Year, 8, 31);
            DateTime userDate;
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (!DateTime.TryParse(userInput, out userDate))
                {
                    Console.WriteLine("Please enter a date. Press any key to try again.");
                    continue;
                }
                else
                {
                    return userDate;
                }
            }
        }
        public string GetUserYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " Y/N?: ");
                string userInput = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter Y or N. Press any key to try again.");
                    continue;
                }
                else
                {
                    if (userInput != "Y" && userInput != "N")
                    {
                        Console.WriteLine("Please enter Y or N. Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                    return userInput;
                }
            }
        }
        private bool CheckCustomerName(string customerName)
        {
            foreach (char c in customerName)
            {
                if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z') && !(c >= '0' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
