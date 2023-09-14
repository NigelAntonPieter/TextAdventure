using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace TextAdventure
{
    internal class Program
    {
        private static string saveFileName = Path.Combine(Environment.CurrentDirectory, "savegame.txt");
        private static bool isGameRunning = false;
        private static bool hasfoundClue = false;
        private static string playerLocation = "start";
        
        static void Main(string[] ags)
        {
            isGameRunning = true;
            
            
                Console.WriteLine("\nWelcome to Detective Black: Curio Chronicles");
                Console.WriteLine("You're Detective James Black, tasked with solving a murder at curio School");
                Console.WriteLine("follow clues and identify the victim to bring justice to this mysterious case.");
                Console.WriteLine("Can you crack the case?");
                EnterFurther();
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
                    if (File.Exists(saveFileName))
                    {
                        ResumeGame();
                    }
                    else
                    {
                        Console.WriteLine("Geen opgeslagen spel gevonden. Begin een nieuw spel");
                        StartNewGame();
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldig commando. Typ 'start' om een nieuw spel te beginnen of 'hervat' om verder te gaan.");
                }

            

        }

        static void EnterFurther()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        
        static void StartNewGame()
        {
           
            isGameRunning = true;
            Console.WriteLine("\nYou get to the location where the dead body is, the name of the victim is Manderijn");
            Console.WriteLine(" there are 4 people getting accused for this crime.");
            Console.WriteLine("\nThe first one is Luna, short girl , red hair doesnt like the victim says she wants to kill him all the time, her alibi is that she was on the toilet when it happend");
            Console.WriteLine("\nthe second one is Wiardi, looks like jeffrey dahmer can tolerate the victim. Likes to cut of snail eyes. He says he was talking to Nigel about a project outside the class");
            Console.WriteLine("\nThe third one is Nigel, a tall handsome black guy (if i say so myself hehehe) also doesnt like the victim. Says he really wanna get rid of him but will never kill him. He says he was talking with a teacher");
            Console.WriteLine("\nand the last one is Collin, he is a weird guy dropped out of school. is friends with the victim but not really that close ");
            EnterFurther();
           
            while (isGameRunning)
            {

                if(!isGameRunning)
                {
                    break;
                }
                Console.WriteLine("Do you wanna look at the dead body or do you wanna speak to suspects? (body/luna/wiardi/Nigel/collin)");
                Console.Write("> ");
      
                string investigateChoice = Console.ReadLine().ToLower();

                if (investigateChoice == "luna")
                {
                    Console.WriteLine("You choose to speak to Luna.");
                    Console.WriteLine("\nLuna tells you she was with Nigel last night and they had an argument.");
                    Console.WriteLine("\nYou ask here what the fight was about");
                    Console.WriteLine("she said they had i figth about that he was to afraid to ride with her in the car");
                    EnterFurther();
                    

                }
                else if (investigateChoice == "wiardi")
                {
                    Console.WriteLine("You choose to speak to Wiardi.");
                    Console.WriteLine("Wiardi seems nervous and avoids eye contact. you ask him where i saw Manderijn last");
                    Console.WriteLine("Wiardi admits to cutting snail eyes but claims it has nothing to do with Manderijn's murder.");
                    EnterFurther();
                    playerLocation = "wiardi";
                   

                }
                else if(investigateChoice == "Nigel")
                {

                }
                else if (investigateChoice == "collin")
                {
                    Console.WriteLine("You choose to speak to Collin.");
                    Console.WriteLine("Collin appears agitated and tells you he hasn't seen Manderijn in days.");
                    EnterFurther();
                }
                else if(investigateChoice == "save")
                {
                    if (isGameRunning)
                    {
                        SaveGame();
                        Console.WriteLine("Het spel wordt afgesloten");
                        isGameRunning = false; 
                        Environment.Exit(0);
                    }
                }
                

                if (!hasfoundClue)
                {
                    if (investigateChoice == "body")
                    {
                        Console.WriteLine("You bend down to the body and see that he was stabbed.");
                        Console.WriteLine("You see something laying beside his head, do you pick it up? (Yes/No)");

                        Console.Write("> ");
                        string pickUpItem = Console.ReadLine();

                        if (pickUpItem.ToLower() == "yes")
                        {
                            Console.WriteLine("You see snail eyes next to his head, you found an important clue.");
                            hasfoundClue = true;
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (pickUpItem.ToLower() == "no")
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
                
            

            
        }
         static void ResumeGame()
        {
            isGameRunning = true;

            string savedGameData = File.ReadAllText(saveFileName);

           
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

               
                File.WriteAllText(saveFileName, gameDataToSave);

                Console.WriteLine("Spel opgeslagen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er is een fout opgetreden bij het opslaan van het spel: " + ex.Message);
            }
        }

        
    }
}

