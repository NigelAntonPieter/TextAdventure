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
        public string saveFileName { get; }
        private bool isGameRunning {  get; set; }
        private bool hasfoundClue {  get; set; }

        private string playerLocation {  get; set; }

        public GameLogic()
        {
            saveFileName = Path.Combine(Environment.CurrentDirectory, "savegame.txt");
            isGameRunning = false;
            hasfoundClue = false;
        }
        public void Endgame()
        {
            Console.WriteLine("\nPress 's' to save the game and exit, or press 'x' to exit the game without saving, or press Enter to choice who the killer is.");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.KeyChar == 's')
            {
                SaveGame();
                Console.WriteLine("Exiting the game.");
                isGameRunning = false;
                Environment.Exit(0);
            }
            else if (keyInfo.KeyChar == 'x')
            {
                Console.WriteLine("Exiting the game without saving.");
                isGameRunning = false;
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You have interrogated all four suspects.");
                Console.WriteLine("Who do you think the murderer is? (luna/wiardi/Nigel/collin)");
                Console.Write("> ");
                string murdererGuess = Console.ReadLine().ToLower();

                if (murdererGuess == "luna")
                {
                    Console.WriteLine("You have guessed the murderer correctly! Well done.");
                    Console.WriteLine("Now, who do you think helped Luna? (wiardi/Nigel/both/none)");
                    Console.Write("> ");
                    string accompliceGuess = Console.ReadLine().ToLower();

                    if (accompliceGuess == "wiardi" || accompliceGuess == "nigel")
                    {
                        Console.WriteLine("Congratulations! You have solved the case.");
                        Console.WriteLine("The suspects have been arrested and taken away.");
                        Console.WriteLine("Before Luna is put in the police car, she threatens you one more time.");
                        Console.WriteLine("You laugh it off and get promoted.");
                        Console.WriteLine("After a big celebration, you go home and sleep.");
                        Console.WriteLine("You wake up to a noise and see Luna standing in front of you with a knife.");
                        Console.WriteLine("She stabs you, but you solved the case.");
                        Console.WriteLine("Game over!");
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately, you didn't guess the accomplices correctly.");
                        Console.WriteLine("You are fired, your wife leaves you and takes the children.");
                        Console.WriteLine("You become addicted to alcohol and die from alcohol poisoning.");
                        Console.WriteLine("Game over!");
                    }
                }
                else
                {
                    Console.WriteLine("Unfortunately, you guessed the wrong murderer.");
                    Console.WriteLine("You are fired, your wife leaves you and takes the children.");
                    Console.WriteLine("You become addicted to alcohol and die from alcohol poisoning.");
                    Console.WriteLine("Game over!");
                }
            }
            isGameRunning = false;
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

            if (!string.IsNullOrEmpty(playerLocation))
            {
                Console.WriteLine($"You continue your investigation from {playerLocation}");
            }

            EnterFurther();

            while (isGameRunning)
            {
                Console.WriteLine("Do you wanna look at the dead body or do you wanna speak to suspects? (body/luna/wiardi/Nigel/collin)");
                Console.Write("> ");
                string investigateChoice = Console.ReadLine().ToLower();
                if (!hasfoundClue)
                {
                    if (investigateChoice == "collin")
                    {
                        Console.WriteLine("You choose to speak to Collin.");
                        Console.WriteLine("Collin appears agitated and tells you he hasn't seen Manderijn in days.");
                        EnterFurther();
                        playerLocation = investigateChoice;
                    }
                    else if (investigateChoice == "body")
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
                        }
                        else if (pocketItem.ToLower() == "no")
                        {
                            Console.WriteLine("Are you scared of the girl wauw thats is really bad. You are a bad detective, but the game continues.");
                        }
                        else
                        {
                            Console.WriteLine("You need to chose yes/no.");   
                        }
                        EnterFurther();
                        playerLocation = investigateChoice;
                    }
                    else if(investigateChoice == "wiardi")
                    {
                        Console.WriteLine("You choose to speak to Wiardi.");
                        Console.WriteLine("Wiardi seems nervous and avoids eye contact. you ask him where I saw Manderijn last.");
                        Console.WriteLine("Wiardi admits to cutting snail eyes but claims it has nothing to do with Manderijn's murder.");
                        Console.WriteLine("Do you believe Wiardi's story? (Yes/No)");
                        Console.Write("> ");
                        string believeStory = Console.ReadLine();

                        if (believeStory.ToLower() == "yes")
                        {
                            Console.WriteLine("You decide to give Wiardi the benefit of the doubt and continue your investigation.");
                            Console.WriteLine("As you explore the area, you come across a mysterious footprint near the scene of the crime.");
                            Console.WriteLine("Are you examining the footprint? (Yes/No)");
                            Console.Write("> ");
                            string examineFootprint = Console.ReadLine();

                            if (examineFootprint.ToLower() == "yes")
                            {
                                Console.WriteLine("Upon closer inspection, you realize that the footprint matches Wiardi's shoes.");
                                Console.WriteLine("This could be a crucial piece of evidence.");
                                hasfoundClue = true;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (examineFootprint.ToLower() == "no")
                            {
                                Console.WriteLine("You decide to leave the footprint alone and continue your search for clues.");
                            }
                            else
                            {
                                Console.WriteLine("You need to chose yes/no.");
                            }
                        }
                        else if (believeStory.ToLower() == "no")
                        {
                            Console.WriteLine("You have a gut feeling that Wiardi might be hiding something important.");
                            Console.WriteLine("You press him further, and he eventually breaks down, admitting that he was with Manderijn at the time of the murder.");
                            Console.WriteLine("Wiardi claims he witnessed someone else commit the murder and fears for his life.");
                            Console.WriteLine("What do you want to do next?");
                            Console.WriteLine("1. Confront Wiardi about the witness.");
                            Console.WriteLine("2. Investigate the area where Wiardi claims he saw the murder.");
                            Console.Write("> ");
                            int choice = int.Parse(Console.ReadLine());

                            if (choice == 1)
                            {
                                Console.WriteLine("You press Wiardi for more information about the witness.");
                                Console.WriteLine("He provides a vague description of the person and insists that he doesn't know their identity.");
                            }
                            else if (choice == 2)
                            {
                                Console.WriteLine("You decide to investigate the area where Wiardi claims he saw the murder.");
                                Console.WriteLine("As you search, you find a hidden knife covered in blood.");
                                Console.WriteLine("This could be a critical piece of evidence that might lead you to the real killer.");
                                hasfoundClue = true;
                            }
                            else
                            {
                                Console.WriteLine("You need to chose 1/2.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You need to chose yes/no.");
                        }

                        EnterFurther();
                        playerLocation = investigateChoice;
                    }
                    else if (investigateChoice == "Nigel")
                    {
                        Console.WriteLine("You choose to speak to Nigel.");
                        Console.WriteLine("Nigel is looking unbothered by the whole experience. you ask him where i saw Manderijn last");
                        Console.WriteLine("He said he saw him in class working on his project before he the teacher pulled him out off class.");
                        Console.WriteLine("Do you believe Nigel's story? (Yes/No)");
                        Console.Write("> ");
                        string believeStory = Console.ReadLine();

                        if (believeStory.ToLower() == "yes")
                        {
                            Console.WriteLine("You decide to give Nigel the benefit of the doubt and continue your investigation.");
                            Console.WriteLine("As you explore the area, you come across the teacher nigel said he talked too.");
                            Console.WriteLine("Are you talking to the teachter? (Yes/No)");
                            Console.Write("> ");
                            string examineTeachterStory = Console.ReadLine();

                            if (examineTeachterStory.ToLower() == "yes")
                            {
                                Console.WriteLine("You walk up to teachter and asked why he pulled nigel out of class.");
                                Console.WriteLine("\nHe said he never pulled him outta class, he had his own class to teach at the time of the murder");
                                Console.WriteLine("This could be a crucial piece of evidence.");
                                hasfoundClue = true;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (examineTeachterStory.ToLower() == "no")
                            {
                                Console.WriteLine("You decide to leave the footprint alone and continue your search for clues.");
                            }
                            else
                            {
                                Console.WriteLine("You need to chose yes/no.");
                            }
                        }
                        else if (believeStory.ToLower() == "no")
                        {
                            Console.WriteLine("You have a gut feeling that Nigel might be hiding something important.");
                            Console.WriteLine("You talk to him some more, but he sticks with his story, that he was pulled out of class.");
                            Console.WriteLine("What do you want to do next?");
                            Console.WriteLine("1. Leave Nigel alone.");
                            Console.WriteLine("2. Threaten him.");
                            Console.Write("> ");
                            int choice = int.Parse(Console.ReadLine());

                            if (choice == 1)
                            {
                                Console.WriteLine("You walk away from Nigel.");
                            }
                            else if (choice == 2)
                            {
                                Console.WriteLine("You say: if you dont talk now i will destroy car.");
                                Console.WriteLine("He sees that you are serious and admits that he didnt got pulled out of class.");
                                Console.WriteLine("This could be a critical piece of evidence that might lead you to the real killer.");
                                hasfoundClue = true;
                            }
                            else
                            {
                                Console.WriteLine("You need to chose 1/2.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You need to chose yes/no.");
                        }
                        EnterFurther();
                        playerLocation = investigateChoice;
                    }
                }
                if (investigateChoice == "quit")
                {
                    Endgame();
                }
                else
                {
                    continue;
                }
            }
        }

        public void ResumeGame()
        {
            isGameRunning = true;

            try
            {
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
                    else if (key == "HasFoundClue")
                    {
                        hasfoundClue = bool.Parse(value);
                    }
                }

                Console.WriteLine("Je hervat het opgeslagen spel op locatie: " + playerLocation);

                if (hasfoundClue = true)
                {
                    Console.WriteLine("Je hebt al een belangrijke aanwijzing gevonden");
                    Console.WriteLine("Je kunt doorgaan met je onderzoek vanaf dit punt.");
                }
                else
                {
                    Console.WriteLine("Je hebt nog geen belangrijke aanwijzingen gevonden.");
                    Console.WriteLine("Je kunt doorgaan met je onderzoek vanaf het begin van het spel.");
                    // Voeg hier logica toe om het spel te starten vanaf het begin, omdat er nog geen aanwijzingen zijn gevonden.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Er is een fout opgetreden bij het hervatten van het spel: " + ex.Message);
            }
        }
        public void SaveGame()
        {
            try
            {
                string gameDataToSave = $"PlayerLocation:{playerLocation}, hasFoundClue:{hasfoundClue}";

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

