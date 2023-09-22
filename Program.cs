using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace TextAdventure
{
    internal class Program
    {
        public static bool isGameRunning = false;
        private static GameLogic gameLogic = new GameLogic();

        static void Main(string[] ags)
        {
            Console.WriteLine("Doel: Vind de moordenaar\n");
            isGameRunning = true;
            while(isGameRunning) 
            {
                Console.WriteLine("Welcome to Detective Black: Curio Chronicles");
                Console.WriteLine("You're Detective James Black, tasked with solving a murder at curio School");
                Console.WriteLine("follow clues and identify the victim to bring justice to this mysterious case.");
                Console.WriteLine("Can you crack the case?");
                Console.WriteLine("Typ Quit if you save the game or if you wanna guess who de killer is ");
                gameLogic.EnterFurther();
                Console.WriteLine("Typ 'start'om te beginnen");
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input == "start")
                {
                    gameLogic.StartNewGame();
                }
            }
        }
    }
}

