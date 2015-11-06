using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.GameWorkflow;

namespace BattleShip.UI.GameWorkflow
{
    public class ShipSetup
    {

        public static ShipType[] _shipArray = { ShipType.Destroyer, ShipType.Battleship, ShipType.Carrier, ShipType.Cruiser, ShipType.Submarine };

        public static void PlayerShipSetup(Player player)
        {
            Coordinate coord = new Coordinate(0,0);
            bool isValidCoordinate = false;
            string userInput;
            //build ShipReq with coord, shiptype, direction
            PlaceShipRequest place = new PlaceShipRequest();
            //Talk
            SpeechSynthesizer talk = new SpeechSynthesizer();
            talk.SetOutputToDefaultAudioDevice();
            talk.SelectVoiceByHints(VoiceGender.Female);
            Console.Clear();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            talk.Speak("Obie one Konobie. You're our only hope!");
            System.Threading.Thread.Sleep(1000);
            talk.SelectVoiceByHints(VoiceGender.Male);
            talk.Speak(String.Format("{0}, It's time to place your ships.", player.Name));
            for (int i = 0; i < _shipArray.Length; i++)
            {
                ShipPlacement response;
              
                do
                {
                    Console.Clear();
                    GameWorkflow.DrawBoard.DrawBoardShips(player);
                    place.ShipType = _shipArray[i];
                    do
                    {
                    Console.WriteLine("\n\nEnter Coordinate for: {0}", _shipArray[i]);
                    userInput = Console.ReadLine();

                        coord = gameFlow.ConvertInputToCoordinate(userInput);
                         isValidCoordinate = gameFlow.CheckValidCoord(coord);
                    if (!isValidCoordinate)
                    {
                        Console.WriteLine("\nInvalid Coordinate - Reenter Coordinate");
                    }
                } while (!isValidCoordinate);

                //populate coord
                place.Coordinate = gameFlow.ConvertInputToCoordinate(userInput);

                    string userDirection = "";
                    do
                    {
                        Console.WriteLine("\nEnter direction for ship placement: 1-Up, 2-Down, 3-Right, 4-Left");
                        userDirection = Console.ReadLine();
                        
                    } while (!(userDirection == "1" || userDirection == "2" || userDirection == "3" || userDirection == "4"));

                    switch (userDirection)
                    {
                        case "1":
                            place.Direction = ShipDirection.Up;
                            break;
                        case "2":
                            place.Direction = ShipDirection.Down;
                            break;
                        case "3":
                            place.Direction = ShipDirection.Right;
                            break;
                        case "4":
                            place.Direction = ShipDirection.Left;
                            break;
                    }
                    response = player.PlayerBoard.PlaceShip(place);
                    //if statement If palcement ok move on if not go back to top
                    if (response != ShipPlacement.Ok)
                    {
                        Console.WriteLine("\nYour ship placement was: {0}, press Enter to try again. ", response);
                        Console.ReadLine();
                    }
                    
                } while (response != ShipPlacement.Ok);
            }

            Console.Clear();
            GameWorkflow.DrawBoard.DrawBoardShips(player);
            Console.WriteLine("\n\nGreat job! All your ships are setup. Press Enter to continue.");
            //SpeechSynthesizer talk = new SpeechSynthesizer();
            talk.SetOutputToDefaultAudioDevice();
            talk.Speak("Great place for your ships...I feel a disturbance in the force..");
            Console.ReadLine();
        }
    }

}

