using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace TextAdventure
{
    internal class Program
    {
        private static string SaveFileName = Path.Combine(Environment.CurrentDirectory, "savegame.txt");
        private static bool isGameRunning = false;
        private static bool hasFoundClue = false;
        private static string playerLocation = SaveFileName;
        
        static void Main(string[] args)
        {
            isGameRunning = true;
            while (isGameRunning)
            {
                Console.WriteLine("\nWelcome to Detective Black: Curio Chronicles");
                Console.WriteLine("You're Detective James Black, tasked with solving a murder at curio School");
                Console.WriteLine("follow clues and identify the victim to bring justice to this mysterious case.");
                Console.WriteLine("Can you crack the case? (press enter to continue)");
                Console.ReadKey();

                Console.WriteLine("Typ 'start'om het spel te beginnen of typ 'hervat' om verder te gaan");
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input == "start")
                {
                    StartNewGame();
                    
                }
                else if (input == "hervat")
                {
                    if (File.Exists(SaveFileName))
                    {
                        ResumeGame();
                        
                    }
                    else
                    {
                        Console.WriteLine("Geen opgeslagen spel gevonden. Begin een nieuw spel");
                        StartNewGame();
                        
                    }
                }
                else if (input == "stop")
                {
                    if (isGameRunning)
                    {
                        SaveGame();
                    }
                    Console.WriteLine("het spel wordt afgesloten");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Ongeldig commando. Typ 'start' om een nieuw spel te beginnen of 'hervat' om verder te gaan.");
                }

            }



        }

        static void StartNewGame()
        {
            isGameRunning = true;
            Console.WriteLine("\nYou get to the location where the dead body is, the name of the victim is Nigel");
            Console.WriteLine(" there are 3 people getting accused for this crime.");
            Console.WriteLine("\nThe first one is luna, short girl is friends with the victim but does say she wants to kill him with a knife");
            Console.WriteLine("\nthe second one is Wiardi, looks like jeffrey dahmer also a friend of the victim. Likes to cut of snail eyes");
            Console.WriteLine("\nand the last one is Collin, he is a weird guy dropped out of school. is friends with the victim but not really that close (press enter)");
            Console.ReadKey();
            Console.Clear();
            while (isGameRunning)
            {
                Console.WriteLine("Do you wanna look at the dead body or do you wanna speak to suspects? (body/luna/wiardi/collin)");

                Console.Write("> ");
                string InvestigateChoice = Console.ReadLine().ToLower();

                

                if (InvestigateChoice == "luna")
                {
                    Console.WriteLine("You choose to speak to Luna.");
                    Console.WriteLine("\nLuna tells you she was with Nigel last night and they had an argument.");
                    Console.WriteLine("\nYou ask here what the fight was about");
                    Console.WriteLine("she said they had i figth about that he was to afraid to ride with her in the car");

                    Console.Clear();

                }
                else if (InvestigateChoice == "wiardi")
                {
                    Console.WriteLine("You choose to speak to Wiardi.");
                    Console.WriteLine("Wiardi seems nervous and avoids eye contact. you ask him where i saw Nigel last");
                    Console.WriteLine("Wiardi admits to cutting snail eyes but claims it has nothing to do with Nigel's murder.");

                }
                else if (InvestigateChoice == "collin")
                {
                    Console.WriteLine("You choose to speak to Collin.");
                    Console.WriteLine("Collin appears agitated and tells you he hasn't seen Nigel in days.");

                }
            

                if (!hasFoundClue)
                {


                    if (InvestigateChoice == "body")
                    {
                        Console.WriteLine("You bend down to the body and see that he was stabbed.");
                        Console.WriteLine("You see something laying beside his head, do you pick it up? (Yes/No)");

                        Console.Write("> ");
                        string PickUpItem = Console.ReadLine();

                        if (PickUpItem.ToLower() == "yes")
                        {
                            Console.WriteLine("You see snail eyes next to his head, you found an important clue.");
                            hasFoundClue = true;
                            Console.ReadKey();
                            Console.Clear();
                            
                        }
                        else if (PickUpItem.ToLower() == "no")
                        {
                            Console.WriteLine("You left the clue. You are a bad detective, but the game continues.");
                        }
                        else
                        {
                            
                            Console.WriteLine("Now that you have found an important clue, you can continue with the story.");
                        }
                    }

                }

            }
            SaveGame();
        }
        static void ResumeGame()
        {
            isGameRunning = true;

            string savedGameData = File.ReadAllText(SaveFileName);

           
            string[] savedDataParts = savedGameData.Split(',');

            foreach (string dataPart in savedDataParts)
            {
                string[] keyValue = dataPart.Split(':');
                string key = keyValue[0];
                string value = keyValue[1];

                if (key == "PlayerLocation")
                {
                    playerLocation = value;
                }
                
               
            }

            Console.WriteLine("Je hervat het opgeslagen spel op locatie: " + playerLocation);
        }

        static void SaveGame()
        {
            try
            {
                
                string gameDataToSave = $"PlayerLocation:{playerLocation}";

               
                File.WriteAllText(SaveFileName, gameDataToSave);

                Console.WriteLine("Spel opgeslagen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er is een fout opgetreden bij het opslaan van het spel: " + ex.Message);
            }
        }
    }
}

// VRAGEN TIM

    //1. verder gaan naar hervatten 
    //2 . terug gaan naar vorige vragen.
    //3 . opslaan 