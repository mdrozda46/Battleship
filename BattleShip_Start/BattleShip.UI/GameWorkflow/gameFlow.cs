using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System.Speech.Synthesis;


namespace BattleShip.UI.GameWorkflow
{
    public class gameFlow
    {
        SpeechSynthesizer talk = new SpeechSynthesizer();

        public string getPlayerName(string playerNum)
        {
           
            Console.WriteLine("\nPlayer {0} enter your name:", playerNum);
            string playerName = "Player" + playerNum.ToString();

            //Talking
            //SpeechSynthesizer talk = new SpeechSynthesizer();
            talk.SetOutputToDefaultAudioDevice();
            talk.Speak(String.Format("Player {0} enter your name.", playerNum));

            playerName = Console.ReadLine();
            if (playerName == "")
            {
                Console.WriteLine("Defaulting your name to Player{0}.", playerNum);
                return "Player" + playerNum;
            }

            return playerName;
        }

        public static Coordinate ConvertInputToCoordinate(string input)
        {
            int x = 11;
            int y = 11;// make invalid until check is done.

            if (input != "")
            {
                x = (int) Convert.ToChar(input.Substring(0, 1).ToUpper());
                int.TryParse(input.Substring(1, input.Length - 1), out y);
                x -= 64;
            }
            
            Coordinate coor = new Coordinate(x, y);
            return coor;
        }

        public static bool CheckValidCoord(Coordinate coor)
        {
            if ((coor.YCoordinate >= 1 && coor.YCoordinate <= 10) && (coor.XCoordinate >= 1 && coor.XCoordinate <= 10))
            {
                return true;

            }
            return false;
        }

        public static void AlternatePlayerGame(Player player1, Player player2)
        {
            bool isVictory = false;
            Player currentPlayer = player1;
            Player otherPlayer = player2;
            string userInput = "";


            while (!isVictory)
            {
                Console.Clear();
                DrawBoard.DrawBoardShotHistory(otherPlayer);
                DrawBoard.DrawBoardShips(currentPlayer);
                Coordinate coord;
                bool isValidCoordinate = false;
                FireShotResponse response = new FireShotResponse();

                do
                {
                    Console.ResetColor();
                    //Talking---this is repeated a bunch...possible loop to change/alternate the saying?? Or will have to leave out.
                    SpeechSynthesizer talk = new SpeechSynthesizer();
                    talk.SetOutputToDefaultAudioDevice();
                    talk.Speak(String.Format("{0}, it's your turn. Stay on target.", currentPlayer.Name));//maybe just say FIRE!
                    
                    Console.WriteLine("\n\n{0}, enter a coordinate to fire a shot.", currentPlayer.Name);
                    userInput = Console.ReadLine();
                    coord = ConvertInputToCoordinate(userInput);
                    isValidCoordinate = CheckValidCoord(coord);
                    if (!isValidCoordinate)
                    {
                        //Talking
                        talk.SetOutputToDefaultAudioDevice();
                        talk.Speak("  Those are not the coordinates we were looking for! ");
                        Console.WriteLine("\nInvalid Coordinate - Repeat Turn");
                    }
                    else
                    {
                        response = otherPlayer.PlayerBoard.FireShot(coord);
                        Console.Beep();
                        Console.Beep();
                        Console.Beep();
                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Hit:
                                //Talking
                                talk.SetOutputToDefaultAudioDevice();
                                talk.Speak(" It's a hit! ");
                                GameWorkflow.DisplayMessages.DisplayHitMessage();
                                Console.WriteLine("\nYou hit something!, Press Enter to continue....");
                                Console.ReadLine();
                                break;
                            case ShotStatus.HitAndSunk:
                                //Talking
                               // SpeechSynthesizer talk = new SpeechSynthesizer();
                                talk.SetOutputToDefaultAudioDevice();
                                talk.Speak(string.Format("  With great power comes great responsiblity. You sank your opponents {0}",response.ShipImpacted));
                                GameWorkflow.DisplayMessages.DisplaySinkingShip();
                                Console.WriteLine("\nYou sank your opponent's {0}!, Press Enter to continue....", response.ShipImpacted);
                                Console.ReadLine();
                                break;
                            case ShotStatus.Miss:
                                //Talking
                                //SpeechSynthesizer talk = new SpeechSynthesizer();
                                talk.SetOutputToDefaultAudioDevice();
                                talk.Speak("  These are not the ships you are looking for. You didn't hit squat!");
                                GameWorkflow.DisplayMessages.DisplayMissMessage();
                                Console.WriteLine("\nYour projectile splashes into the ocean, you missed! \n\nPress Enter to continue....");
                                Console.ReadLine();
                                break;
                            case ShotStatus.Duplicate:
                                //talking
                                //SpeechSynthesizer talk = new SpeechSynthesizer();
                                talk.SetOutputToDefaultAudioDevice();
                                talk.Speak("   Hey genius!  You already tried that!");


                                Console.WriteLine("\nDuplicate shot - repeat turn.  Press Enter to continue....");
                                Console.ReadLine();
                                break;
                            case ShotStatus.Victory:
                                //Talking
                                //SpeechSynthesizer talk = new SpeechSynthesizer();
                                talk.SetOutputToDefaultAudioDevice();
                                talk.Speak(String.Format("May the force be with {0}! You sank all of your opponents ships. You won the game!", currentPlayer.Name));
                                GameWorkflow.DisplayMessages.DisplayVictoryMessage();
                                Console.WriteLine("\n{0}, you have sunk all of your opponents ships, you win!- End Game", currentPlayer.Name);
                                System.Threading.Thread.Sleep(2000);
                                break;
                        }
                    }
                } while (!isValidCoordinate || response.ShotStatus == ShotStatus.Duplicate);

                if (response.ShotStatus == ShotStatus.Victory)
                {
                    isVictory = true;
                }
                else
                {
                    isVictory = false;
                    Player tempPlayer = currentPlayer;
                    currentPlayer = otherPlayer;
                    otherPlayer = tempPlayer;

                }
            }


        }


    }
}
