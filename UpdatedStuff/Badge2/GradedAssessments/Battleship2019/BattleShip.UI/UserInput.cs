using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class UserInput
    {
        public string GetPlayerName(string playerName)
        {
            string inputPlayerName;
            while(true)
            {
                Console.Write("{0} enter your name: ", playerName);
                inputPlayerName = Console.ReadLine().ToUpper();
                if (inputPlayerName.Length >= 3) 
                    break;
                else
                {
                    Console.WriteLine("Press any key to return to question, then " +
                        "\nEnter a valid string of at least 3 characters. ");
                    Console.ReadKey();
                }
            }
            return inputPlayerName;
        }
        public Coordinate GetShipCoordinateFromUser(string playerName, Board board, ShipType shipType)
        {
            int coordAlpha;
            int coordNumeric;

            while (true)
            {
                Console.WriteLine("{0}, use A-J for column, and 1-10 for row.", playerName);
                Console.Write("Enter coordinate for {0}: ", shipType);
                string coord = Console.ReadLine().ToUpper();

                if (coord.Length == 2 || coord.Length == 3)
                {
                    char xChar = coord[0];
                    coordAlpha = xChar - 64;

                    string yString = coord;
                    yString = yString.Remove(0, 1);
                    int.TryParse(yString, out coordNumeric);

                    bool xCoordinateIsValid = coordAlpha >= 1 && coordAlpha <= 10;
                    bool yCoordinateIsValid = coordNumeric >= 1 && coordNumeric <= 10;

                    if (xCoordinateIsValid && yCoordinateIsValid)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid coordinate.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid coordinate.");
                }
            }
            Coordinate coordinate = new Coordinate(coordAlpha, coordNumeric);
            return coordinate;
        }
        public ShipDirection GetShipDirectionFromUser(string playerName, Board board, ShipType shipType)
        {
            ShipDirection shipDirection;
            while (true)
            {
                Console.WriteLine("{0}, use UP, DOWN, LEFT, and RIGHT for direction", playerName);
                Console.Write("Enter direction for {0}: ", shipType);
                string inputDirection = Console.ReadLine().ToUpper();

                if (inputDirection.Equals("UP") || inputDirection.Equals("U"))
                {
                    shipDirection = ShipDirection.Up;
                    break;
                }
                else if (inputDirection.Equals("DOWN") || inputDirection.Equals("D"))
                {
                    shipDirection = ShipDirection.Down;
                    break;
                }
                else if (inputDirection.Equals("LEFT") || inputDirection.Equals("L"))
                {
                    shipDirection = ShipDirection.Left;
                    break;
                }
                else if (inputDirection.Equals("RIGHT") || inputDirection.Equals("R"))
                {
                    shipDirection = ShipDirection.Right;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid direction.");
                }
            }
            return shipDirection;
        }
        public Coordinate GetShotCoordinateFromUser(string playerName)
        {
            int coordAlpha;
            int coordNumeric;

            while (true)
            {
                Console.Write("{0}, enter shot coordinate: ", playerName);
                string coord = Console.ReadLine().ToUpper();

                if (coord.Length == 2 || coord.Length == 3)
                {
                    char xChar = coord[0];
                    coordAlpha = xChar - 64;

                    string yString = coord;
                    yString = yString.Remove(0, 1);
                    int.TryParse(yString, out coordNumeric);

                    bool xCoordinateIsValid = coordAlpha >= 1 && coordAlpha <= 10;
                    bool yCoordinateIsValid = coordNumeric >= 1 && coordNumeric <= 10;

                    if (xCoordinateIsValid && yCoordinateIsValid)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid coordinate.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid coordinate.");
                }
            }

            Coordinate coordinate = new Coordinate(coordAlpha, coordNumeric);
            return coordinate;
        }
    }
}
