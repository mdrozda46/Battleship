using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.GameWorkflow
{
    class DrawBoard
    {
        public static void DrawBoardShotHistory(Player player)
        {
            //Board Header
            string[] letterArray = new string[] { "\n      A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n  Your Attacks On {0}'s Board\n", player.Name );//********


            for (int col = 0; col < 10; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;// makes letters red
                Console.Write(letterArray[col]);
            }
            Console.Write("\n----------------------------------");


            //set each element with a value 
            for (int row = 1; row < 11; row++)
            {
                if (row < 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" \n {0} | ", row);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" \n{0} | ", row);
                }
                for (int col = 1; col < 11; col++)
                {
                    Console.ResetColor();
                    Coordinate coord = new Coordinate(col, row);
                    if (player.PlayerBoard.ShotHistory.ContainsKey(coord))
                    {
                        switch (player.PlayerBoard.ShotHistory[coord])
                        {
                            case ShotHistory.Hit:
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(" H ");
                                    break;
                                }
                            case ShotHistory.Miss:
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(" M ");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
            }
        }
        public static void DrawBoardShips(Player player)
        {
            string[] letterArray = new string[] { "\n\n      A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n\n  {0}'s Ships & Opponents Attacks", player.Name);//////******************
            for (int col = 0; col < 10; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;// makes letters red
                Console.Write(letterArray[col]);
            }
            Console.Write("\n----------------------------------");
           
            //set each element with a value 
            for (int row = 1; row < 11; row++)
            {
                if (row < 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" \n {0} | ", row);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" \n{0} | ", row);
                }
                for (int col = 1; col < 11; col++)
                {
                    Console.ResetColor();
                    Coordinate coord = new Coordinate(col, row);
                    //if in both dictionary's 
                    if (player.PlayerBoard.ShipHistory.ContainsKey(coord) || player.PlayerBoard.ShotHistory.ContainsKey(coord))
                    {
                        if (player.PlayerBoard.ShotHistory.ContainsKey(coord))
                        {
                            switch (player.PlayerBoard.ShotHistory[coord])
                            {
                                case ShotHistory.Hit:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" H ");
                                        break;
                                    }

                                case ShotHistory.Miss:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(" M ");
                                        break;
                                    }

                            }
                        }

                        else
                        {
                            switch (player.PlayerBoard.ShipHistory[coord])
                            {
                                case ShipType.Battleship:

                                    Console.Write(" B ");
                                    break;

                                case ShipType.Carrier:

                                    Console.Write(" C ");
                                    break;

                                case ShipType.Cruiser:

                                    Console.Write(" R ");
                                    break;

                                case ShipType.Destroyer:

                                    Console.Write(" D ");
                                    break;

                                case ShipType.Submarine:

                                    Console.Write(" S ");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
            }
        }

    }
}
