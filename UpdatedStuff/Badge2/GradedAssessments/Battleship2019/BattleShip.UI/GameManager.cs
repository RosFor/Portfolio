using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameManager
    {
        public enum PlayerTurn
        {
            One,
            Two
        }

        UserInput userInput = new UserInput();
        GameView gameDisplay = new GameView();
        PlayerTurn playerTurn;

        string p1Name;
        string p2Name;

        Board p1Board = new Board();
        Board p2Board = new Board();

        bool gameOver = false;

        public GameManager()
        {
            gameDisplay.DisplayWelcome();
            InitializePlayers();
            InitializeShips();

            while(gameOver == false)
            {
                if (playerTurn == PlayerTurn.One)
                {
                    PlayerOneTurn();
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (playerTurn == PlayerTurn.Two)
                {
                    PlayerTwoTurn();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        public void RandomPlayer()
        {
            Random rng = new Random();
            playerTurn  = (PlayerTurn)rng.Next(2);
        }
        public void InitializePlayers()
        {
            p1Name = userInput.GetPlayerName("Player 1");
            p2Name = userInput.GetPlayerName("Player 2");
            RandomPlayer();
        }
        public void InitializeShips()
        {
            InitializeP1Ships();
            InitializeP2Ships();
        }
        private void InitializeP1Ships()
        {
            foreach (int ships in Enum.GetValues(typeof(ShipType)))
            {
                while (true)
                {
                    Coordinate p1Coordinate = userInput.GetShipCoordinateFromUser(p1Name, p1Board, (ShipType)ships);
                    ShipDirection p1ShipDirection = userInput.GetShipDirectionFromUser(p1Name, p1Board, (ShipType)ships);
                    if (isShipPlacementValid(p1Coordinate, p1ShipDirection, (ShipType)ships, p1Board))
                    {
                        break;
                    }
                }
            }
            Console.Clear();
        }

        private void InitializeP2Ships()
        {
            foreach (int ships in Enum.GetValues(typeof(ShipType)))
            {
                while (true)
                {
                    Coordinate p2Coordinate = userInput.GetShipCoordinateFromUser(p2Name, p2Board, (ShipType)ships);
                    ShipDirection p2ShipDirection = userInput.GetShipDirectionFromUser(p2Name, p2Board, (ShipType)ships);
                    if (isShipPlacementValid(p2Coordinate, p2ShipDirection, (ShipType)ships, p2Board))
                    {
                        break;
                    }
                }
            }
            Console.Clear();
        }
        private void PlayerOneTurn()
        {
            gameDisplay.DisplayGameBoard(p2Board);
            Coordinate p1ShotCoordinate = userInput.GetShotCoordinateFromUser(p1Name);
            FireShotResponse p1FireShotResponse = p2Board.FireShot(p1ShotCoordinate);
            gameDisplay.DisplayGameBoard(p2Board);
            switch (p1FireShotResponse.ShotStatus)
            {
                case ShotStatus.Invalid:
                    Console.WriteLine("Shot is invalid. Try a new coordinate.");
                    break;
                case ShotStatus.Duplicate:
                    Console.WriteLine("Shot has already been made. Try a new coordinate.");
                    break;
                case ShotStatus.Miss:
                    Console.WriteLine("Shot missed. {0}'s turn.", p2Name);
                    playerTurn = PlayerTurn.Two;
                    break;
                case ShotStatus.Hit:
                    Console.WriteLine("A ship was hit!");
                    playerTurn = PlayerTurn.Two;
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine("{0} was hit, and sunk!", p1FireShotResponse.ShipImpacted);
                    playerTurn = PlayerTurn.Two;
                    break;
                case ShotStatus.Victory:
                    Console.WriteLine("{0} has sunk all of {1}'s ships! {2} wins!", p1Name, p2Name, p1Name);
                    gameOver = true;
                    break;
            }
        }
        private void PlayerTwoTurn()
        {
            gameDisplay.DisplayGameBoard(p1Board);
            Coordinate p2ShotCoordinate = userInput.GetShotCoordinateFromUser(p2Name);
            FireShotResponse p2FireShotResponse = p1Board.FireShot(p2ShotCoordinate);
            gameDisplay.DisplayGameBoard(p1Board);
            switch (p2FireShotResponse.ShotStatus)
            {
                case ShotStatus.Invalid:
                    Console.WriteLine("Shot is invalid. Try a new coordinate.");
                    break;
                case ShotStatus.Duplicate:
                    Console.WriteLine("Shot has already been made. Try a new coordinate.");
                    break;
                case ShotStatus.Miss:
                    Console.WriteLine("Shot missed. {0}'s turn.", p1Name);
                    playerTurn = PlayerTurn.One;
                    break;
                case ShotStatus.Hit:
                    Console.WriteLine("A ship was hit!");
                    playerTurn = PlayerTurn.One;
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine("{0} was hit, and sunk!", p2FireShotResponse.ShipImpacted);
                    playerTurn = PlayerTurn.One;
                    break;
                case ShotStatus.Victory:
                    Console.WriteLine("{0} has sunk all of {1}'s ships! {2} wins!", p2Name, p1Name, p2Name);
                    gameOver = true;
                    break;
            }
        }
        private bool isShipPlacementValid(Coordinate coordinate, ShipDirection shipDirection, ShipType shipType, Board board)
        {
            ShipPlacementRequest request = new ShipPlacementRequest();
            request.Coordinate = coordinate;
            request.Direction = shipDirection;
            request.ShipType = shipType;

            ShipPlacement shipPlacement = board.PlaceShip(request);

            if (shipPlacement == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("There is not enough space to place the ship. Try a new coordinate.");
                return false;
            }
            else if (shipPlacement == ShipPlacement.Overlap)
            {
                Console.WriteLine("Placing this ship will overlap an already placed ship. Try a new coordinate.");
                return false;
            }
            else if (shipPlacement == ShipPlacement.Ok)
            {
                Console.WriteLine("Ship was successfully placed.");
                return true;
            }
            return false;
        }
    }
}
