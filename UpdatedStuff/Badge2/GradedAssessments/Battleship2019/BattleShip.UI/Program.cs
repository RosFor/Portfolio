using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                GameManager gameManager = new GameManager();
                string playAgain;
                while (true)
                {
                    Console.WriteLine("Would you like to start a new game? (Y = Yes, N = No)");
                    playAgain = Console.ReadLine().ToUpper();
                    if(playAgain.Equals("Y") || playAgain.Equals("N"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response.");
                    }
                }
                if (playAgain.Equals("N"))
                {
                    Console.WriteLine("Goodbye!");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
