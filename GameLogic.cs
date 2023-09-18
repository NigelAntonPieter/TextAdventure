using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextAdventure
{
    internal class GameLogic
    {
        public string saveFileName;
        private bool isGameRunning;
        private bool hasfoundClue;
        private string playerLocation;

        public GameLogic()
        {
            saveFileName = Path.Combine(Environment.CurrentDirectory, "savegame.txt");
            isGameRunning = false;
            hasfoundClue = false;
            playerLocation = "start";
        }

        public void Endgame()
        {
            Console.WriteLine("\nDruk op 's' om het spel op te slaan en af te sluiten, of druk op 'x' om het spel direct af te sluiten.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.KeyChar == 's')
            {
                SaveGame();
                Console.WriteLine("Het spel wordt afgesloten.");
                isGameRunning = false;
                Environment.Exit(0);
            }
            else if (keyInfo.KeyChar == 'x')
            {
                Console.WriteLine("Het spel wordt afgesloten zonder op te slaan.");
                isGameRunning = false;
                Environment.Exit(0);
            }
        }

        public void EnterFurther()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartNewGame()
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

                Console.WriteLine("Do you wanna look at the dead body or do you wanna speak to suspects? (body/luna/wiardi/Nigel/collin)");
                Console.Write("> ");

                string investigateChoice = Console.ReadLine().ToLower();


                if (investigateChoice == "wiardi")
                {
                    Console.WriteLine("You choose to speak to Wiardi.");
                    Console.WriteLine("Wiardi seems nervous and avoids eye contact. you ask him where i saw Manderijn last");
                    Console.WriteLine("Wiardi admits to cutting snail eyes but claims it has nothing to do with Manderijn's murder.");
                    EnterFurther();
                    playerLocation = investigateChoice;
                }
                else if (investigateChoice == "nigel")
                {
                    Console.WriteLine("You choose to speak to Nigel.");
                    Console.WriteLine("Nigel is looking unbothered by the whole experience. you ask him where i saw Manderijn last");
                    Console.WriteLine("He said he saw him in class working on his project before he the teacher pulled him out off class.");
                    EnterFurther();
                    playerLocation = investigateChoice;

                }
                else if (investigateChoice == "collin")
                {
                    Console.WriteLine("You choose to speak to Collin.");
                    Console.WriteLine("Collin appears agitated and tells you he hasn't seen Manderijn in days.");
                    EnterFurther();
                    playerLocation = investigateChoice;
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
                            Console.WriteLine("You need to pick one of them genius .");
                        }
                    }
                    else if (investigateChoice == "luna")
                    {
                        Console.WriteLine("You choose to speak to Luna.");
                        Console.WriteLine("\nLuna tells you she was with Manderijn today but she had a argument with him.");
                        Console.WriteLine("\nYou ask here what the argument was about");
                        Console.WriteLine("\nShe lost patience with him because he kept telling her he liked her but she didnt feel the same way ");
                        Console.WriteLine("Are you asking her to empty her pockets(Yes/No)");
                        Console.Write("> ");
                        string pocketItem = Console.ReadLine();

                        if (pocketItem.ToLower() == "yes")
                        {
                            Console.WriteLine("She says she does not wanna do that and runs away, are you chasing her? (Yes/no) .");
                            Console.Write("> ");
                            string runAfter = Console.ReadLine();

                            if (runAfter.ToLower() == "yes")
                            {
                                Console.WriteLine("You run after her and tackle her, when she falls a bloody cloth falls out her pocket, you found an important clue .");
                                hasfoundClue = true;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (runAfter.ToLower() == "no")
                            {
                                Console.WriteLine("You are one lazy detective are you. You're getting real close to getting fired, but the game continues.");
                            }
                            else
                            {
                                Console.WriteLine("Now that you have found an important clue, you can continue with the story.");
                            }

                        }
                        else if (pocketItem.ToLower() == "no")
                        {
                            Console.WriteLine("Are you scared of the girl wauw thats is really bad. You are a bad detective, but the game continues.");
                        }
                        else
                        {
                            Console.WriteLine("Now that you have found an important clue, you can continue with the story.");
                        }
                        EnterFurther();
                        playerLocation = investigateChoice;
                    }
                }

            }


        }
        public void ResumeGame()
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

        public void SaveGame()
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

