using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameView
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\tWelcome");
            Console.WriteLine("\t  To");
            Console.WriteLine("\tBattleShip");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        public void DisplayGameBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("Key: H - Hit, M - Miss, _ - Unknown");
            Console.WriteLine(" A  B  C  D  E  F  G  H  I  J ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Coordinate coordinate = new Coordinate(y, x);
                    ShotHistory shotHistory = board.CheckCoordinate(coordinate);

                    if (shotHistory == ShotHistory.Hit)
                    {
                        Console.Write(" H ");
                    }
                    else if (shotHistory == ShotHistory.Miss)
                    {
                        Console.Write(" M ");
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
