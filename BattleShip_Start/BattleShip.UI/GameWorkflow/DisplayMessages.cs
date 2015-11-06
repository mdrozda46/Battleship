using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.GameWorkflow
{
    public class DisplayMessages
    {
        public static void StartScreen()

        {
            SpeechSynthesizer talk = new SpeechSynthesizer();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Write("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n **********************************BATTLESHIP**********************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");
            Console.Write("\n ******************************************************************************");

            //Talking
            //SpeechSynthesizer talk = new SpeechSynthesizer();
            talk.SetOutputToDefaultAudioDevice();
            talk.Speak("Welcome to battleship");

            //SpeechSynthesizer talk4 = new SpeechSynthesizer();
            talk.SetOutputToDefaultAudioDevice();
            talk.Speak("A long time ago in a galaxy far far away....");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n \n \n \n \n                     Press Enter to start the game...");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayHitMessage()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("       ******      ******    ******    *******************    ******");
                Console.WriteLine("       ******      ******    ******    *******************    ******");
                Console.WriteLine("       ******      ******    ******    *******************    ******");
                Console.WriteLine("       ******      ******    ******    *******************    ******");
                Console.WriteLine("       ******      ******                    *******          ******");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("       ******************    ******          *******          ******");
                Console.WriteLine("       ******************    ******          *******          ******");
                Console.WriteLine("       ******************    ******          *******          ******");
                Console.WriteLine("       ******************    ******          *******          ******");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("       ******      ******    ******          *******                ");
                Console.WriteLine("       ******      ******    ******          *******                ");
                Console.WriteLine("       ******      ******    ******          *******          ******");
                Console.WriteLine("       ******      ******    ******          *******          ******");
                Console.WriteLine("       ******      ******    ******          *******          ******");

                System.Threading.Thread.Sleep(250);
                Console.Clear();
                System.Threading.Thread.Sleep(250);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayMissMessage()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    *****        *****    ******       *************         *************  ");
                Console.WriteLine("    ******      ******    ******      ***************       *************** ");
                Console.WriteLine("    *******    *******    ******     *****************     *****************");
                Console.WriteLine("    ********  ********    ******    ******       *****    ******       *****");
                Console.WriteLine("    ******************    ******    ******                ******            ");
                Console.WriteLine("    ******************              ******                ******            ");
                Console.WriteLine("    ******************    ******    ****************      ****************  ");
                Console.WriteLine("    *****  ****  *****    ******     ****************      **************** ");
                Console.WriteLine("    *****   **   *****    ******      ****************      ****************");
                Console.WriteLine("    *****        *****    ******                 *****                 *****");
                Console.WriteLine("    *****        *****    ******                 *****                 *****");
                Console.WriteLine("    *****        *****    ******     *****       *****     *****       *****");
                Console.WriteLine("    *****        *****    ******     *****************     *****************");
                Console.WriteLine("    *****        *****    ******      ***************       *************** ");
                Console.WriteLine("    *****        *****    ******       *************         ************* ");

                System.Threading.Thread.Sleep(250);
                Console.Clear();
                System.Threading.Thread.Sleep(250);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void RollCredits()
        {
            Console.Clear();
            string newLine = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            string displayCreditList = "";
            string[] creditsArray = new[]
            {
                "         Visual Effects - Mike Drozda",
                "         Gamework Flow  - Lara Caves",
                "         Gamework Flow  - Mike Drozda",
                "         Gamework Flow  - James McManus",
                "         Sound Effects  - Lara Caves      ",
                "         Game Tester    - James McManus   ",
                "\n",
                "         Game Logic     - Some Random Dude",
                "\n",
                "         Instructor     - Victor Pudelski",
                "\n",
                "         Game Studio    - Software Guild",
                "\n",
                "  ** Special thanks to Lebron James for coming home! **"
            };

            for (int i = 0; i < 15; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n\n                                 CREDITS              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n      -----------------------------------------------------------------");
                Console.WriteLine(newLine);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(displayCreditList);
                System.Threading.Thread.Sleep(300);

                // Leave on the screen for the last loop
                if (i < 14)
                {
                    Console.Clear();
                    newLine = newLine.Substring(0, newLine.Length - 2);
                }

                // rolling credits
                if (i < creditsArray.Length)
                {
                    displayCreditList += "\n              " + creditsArray[i];
                }
            }

            System.Threading.Thread.Sleep(10000);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void DisplaySinkingShip()
        {
            Console.Clear();
            string newLine = "\n\n\n\n";
            string[] shipDisplayArray = new[]
            {


                "                                       *******                ****          ",
                "                                    *************           ****            ",
                "                                  *****************       ****              ",
                "                                  ********    *****     ****                ",
                "                                  ********    *****   ****                  ",
                "                               **************************                   ",
                "                          *********************************                 ",
                "                          *********************************                 ",
                "    **********************************************************************  ",
                " ************************************************************************** ",
                " ********************  ***  ****      *****    *****************************",
                " ********************  ***  ****   ******  ****  ***************************",
                " ********************  ***  *******   ***        ************************** ",
                "  ********************     *****      ***  ****  *************************  ",
                "    ********************************************************************    ",
                "      ****************************************************************      ",
                "        ************************************************************        ",
                "          *******************************************************           "
            };

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 1; i < shipDisplayArray.Length; i++)
            {
                Console.WriteLine(newLine);
                for (int j = 0; j <= shipDisplayArray.Length-i; j++)
                {
                    Console.WriteLine(shipDisplayArray[j]);
                }
                
                
                System.Threading.Thread.Sleep(150);

                Console.Clear();
                newLine += "\n";
            }


            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayVictoryMessage()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("                                                                     ");
                Console.WriteLine("                                     **                              ");
                Console.WriteLine("                                    ****                             ");
                Console.WriteLine("                                   ******                         ");
                Console.WriteLine("                                  *********                          ");
                Console.WriteLine("                                ************                        ");
                Console.WriteLine("                               ***************                      ");
                Console.WriteLine("                             *******************                   ");
                Console.WriteLine("                           ***********************                  ");
                Console.WriteLine("                         ***************************                ");
                Console.WriteLine("                       *******************************         ");
                Console.WriteLine("*************************************************************************");
                Console.WriteLine(" ***********************************************************************  ");
                Console.WriteLine("   *******************************************************************   ");
                Console.WriteLine("      *************************************************************   ");
                Console.WriteLine("        *********************************************************     ");
                Console.WriteLine("          *****************************************************       ");
                Console.WriteLine("            *************************************************         ");
                Console.WriteLine("               ********************************************           ");
                Console.WriteLine("                  *************************************               ");
                Console.WriteLine("                 ***************************************              ");
                Console.WriteLine("                *****************************************             ");
                Console.WriteLine("               *******************************************            ");
                Console.WriteLine("              *********************   *********************           ");
                Console.WriteLine("             *******************         *******************          ");
                Console.WriteLine("            *****************               *****************         ");
                Console.WriteLine("           **************                       **************        ");
                Console.WriteLine("          ************                             ************       ");
                Console.WriteLine("         **********                                   **********      ");
                Console.WriteLine("        ********                                         ********     ");
                Console.WriteLine("       ******                                               ******    "); 
                Console.WriteLine("      *****                                                   *****   ");
                


                System.Threading.Thread.Sleep(250);
                Console.Clear();
                System.Threading.Thread.Sleep(250);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
