using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.View
{
    public class UserInput
    {
        public string ReadString(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine().Trim();
                if(string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Enter a valid string.");
                    Console.WriteLine("Press any key to return & try input again.");
                    Console.ReadKey();
                }
                else
                {
                    return userInput;
                }
            }
        }
        public int ReadInt(string prompt)
        {
            int intValue;
            while(true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if(!int.TryParse(userInput, out intValue))
                {
                    Console.WriteLine("Enter a valid integer.");
                    Console.WriteLine("Press any key to return & try input again.");
                    Console.ReadKey();
                }
                else
                {
                    if(intValue <= 0)
                    {
                        Console.WriteLine("Input should be greater than 0.");
                        Console.WriteLine("Press any key to return & try input again.");
                        Console.ReadKey();
                    }
                    return intValue;
                }
            }
        }
        public int ReadIntLong(string prompt, int min, int max)
        {
            int intValue;
            
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out intValue))
                {
                    if(intValue >= min && intValue <= max)
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
                    Console.WriteLine("Please try again with valid input.");
                }
            }
            return intValue;
        }
        public decimal ReadDecimal(string prompt)
        {
            decimal deciValue;
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (!decimal.TryParse(userInput, out deciValue))
                {
                    Console.WriteLine("Enter a valid decimal.");
                    Console.WriteLine("Press any key to return & try input again.");
                    Console.ReadKey();
                }
                else
                {
                    if (deciValue <= 0)
                    {
                        Console.WriteLine("Input should be greater than 0.");
                        Console.WriteLine("Press any key to return & try input again.");
                        Console.ReadKey();
                    }
                    return deciValue;
                }
            }
        }
        public decimal ReadDecimalLong(string prompt, decimal min, decimal max)
        {
            decimal deciValue;
            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (decimal.TryParse(userInput, out deciValue))
                {
                    if (deciValue >= min && deciValue <= max)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter valid input.");
                    Console.WriteLine("Press any key to return & try input again.");
                    Console.ReadKey();
                }
            }
            return deciValue;
        }
    }
}
