using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.UI.GameWorkflow;
using System.Speech.Synthesis;

namespace BattleShip.UI
{
    class Program
    {
        private static void Main(string[] args)
        {


            // Setup new game board
            gameFlow game = new gameFlow();
            bool KeepPlaying = true;
            bool[] gameOptions = new bool[]
            {
                true,
                true
            };

    do
            {

                // Create new players
                Player player1 = new Player();
                Player player2 = new Player();


                // Display splash screen
                Console.Clear();
                GameWorkflow.DisplayMessages.StartScreen();
                Console.ReadLine();

                // Gather player 1 name and ship placement
                Console.Clear();
                player1.Name = game.getPlayerName("1");
                GameWorkflow.ShipSetup.PlayerShipSetup(player1);

                // Gather player 2 name and ship placement
                Console.Clear();
                player2.Name = game.getPlayerName("2");
                GameWorkflow.ShipSetup.PlayerShipSetup(player2);

                // Start game play &&&& Talking
                SpeechSynthesizer talk = new SpeechSynthesizer();
                talk.SetOutputToDefaultAudioDevice();
                talk.Speak("Lets play the game.");

                Console.WriteLine("\nLet's Play the Game!");
                gameFlow.AlternatePlayerGame(player1, player2);

                // Roll game credits
                GameWorkflow.DisplayMessages.RollCredits();

                // Do you want to play again
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("\n\nWould you like to play again? Enter N for new game enter Q for quit.");

                //Talk
                talk.SetOutputToDefaultAudioDevice();
                talk.Speak("Would you like to play again?");
                string UserInput = Console.ReadLine().ToUpper();

                if (UserInput != "N")
                {
                    KeepPlaying = false;
                }
            } while (KeepPlaying);

            //Closing application
            Console.Clear();
            Console.WriteLine("Press any key to close");
            Console.ReadLine();


        }
    }
}
