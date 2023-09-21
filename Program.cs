using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace TextAdventure
{
    internal class Program
    {
        private static bool isGameRunning = false;
        private static GameLogic gameLogic = new GameLogic();

        static void Main(string[] ags)
        {
            isGameRunning = true;
            while (isGameRunning)
            {
                Console.WriteLine("Welcome to Detective Black: Curio Chronicles");
                Console.WriteLine("You're Detective James Black, tasked with solving a murder at curio School");
                Console.WriteLine("follow clues and identify the victim to bring justice to this mysterious case.");
                Console.WriteLine("Can you crack the case?");
                Console.WriteLine("Typ Quit if you save the game or if you wanna guess who de killer is ");
                gameLogic.EnterFurther();
                Console.WriteLine("Typ 'start'om het spel te beginnen of typ 'hervat' om verder te gaan");
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input == "start")
                {
                    gameLogic.StartNewGame();
                }
                else if (input == "hervat")
                {
                    if (File.Exists(gameLogic.saveFileName))
                    {
                        gameLogic.ResumeGame();
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldig commando. Typ 'start' om een nieuw spel te beginnen of 'hervat' om verder te gaan.");
                }
            }
        }
    }
}

