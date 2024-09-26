using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string playerName; // Variable to store the player's chosen name
        bool hasChest = false; // Tracks if the player has found the torch to enter the cave
        bool hasSword = false; // Tracks if the player has found the Sword of Light

        Console.WriteLine("Welcome to Quest for the Sword of Light!");
        Console.Write("What is your hero's name? ");
        playerName = Console.ReadLine(); // Get player's name

        bool talkedToOldMan = false; // Tracks if the player has talked to the Old Man
        while (!talkedToOldMan)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Talk to the Old Man");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine(); // Get player's choice

            // Talk to the Old Man action gives player quest dialogue and 1 quest item
            if (choice == "1")
            {
                Console.WriteLine($"\n{playerName} talks to the Old Man.");
                Console.WriteLine("\nOld Man: Evil forces have invaded our land! Please save us, You're our only hope!");
                Console.WriteLine("\nThere is a rumour of an Ancient Chest to be found within the Forest.");
                Console.WriteLine("\nOld Man: Take this Ancient Key. It is required before entering the Cave of Darkness!");
                Console.WriteLine($"\n{playerName} gained 1x Ancient Key!");
                talkedToOldMan = true;
            }
            else
            {
                Console.WriteLine("\nYou must talk to the Old Man first.");
            }
        }

        // Game loops if the player has not found the Sword
        while (!hasSword)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Explore Forest");
            Console.WriteLine("2. Enter Dark Cave");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine(); // Get player's choice again

            // Explore Forest action
            if (choice == "1")
            {
                Console.WriteLine($"\n{playerName} explores the forest.");
                if (!hasChest)
                {
                    Console.WriteLine("\nYou find an Ancient Chest! You use the key to open the Chest.");
                    Console.WriteLine("\nThe Chest contains a Torch!");
                    hasChest = true; // Player now has the key to open the chest
                }
                else
                {
                    Console.WriteLine("\nYou've already opened the chest.");
                }
            }
            // Enter Dark Cave action
            else if (choice == "2")
            {
                if (!hasChest)
                {
                    Console.WriteLine("\nYou can't enter the cave without the contents of the Chest.");
                }
                else
                {
                    Console.WriteLine($"\n{playerName} enters the cave and discovers the Sword of Light!");
                    Console.WriteLine("\nThe Sword of Light is a legendary artifact said to have the power to banish darkness and restore hope to the land.");
                    hasSword = true; // Player has the sword

                    // After receiving the sword, give the player the option to enter "Tower of Darkness" to determine a Win or Lose outcome
                    string enterTower = "";

                    while (string.IsNullOrEmpty(enterTower))
                    {
                        Console.WriteLine("\nYou now have the Sword of Light!");
                        Console.WriteLine("\nWould you like to enter the Tower of Darkness? (Yes or No)");
                        enterTower = Console.ReadLine().ToLower();

                        if (enterTower == "yes")
                        {
                            Console.WriteLine($"\n{playerName} enters the Tower of Darkness.");
                            Console.WriteLine("\nAs you step inside the Tower of Darkness, you feel the power of radiance flowing through your body.");
                            Console.WriteLine("\nWith the Sword of Light, you repel even the darkest corners of the world.");
                        }
                        else if (enterTower == "no")
                        {
                            Console.WriteLine("\nYou chose not to enter the Tower of Darkness. You decide to explore further into the cave.");
                            Console.WriteLine($"\n{playerName} wanders deeper into the cave, but the darkness closes in...");
                            Console.WriteLine("\nThe darkness consumes the land, and hope is lost.");
                            Console.WriteLine("\nYou have lost the game.");
                            Console.WriteLine("\nProgram By Ethan Gapic-Kott, 000923124");
                            return; // End the game
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid response. Please enter 'Yes' or 'No'.");
                            enterTower = ""; // Reset to prompt again if "Yes" or "No" are not entered
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Try again.");
            }
        }

        // Final message when the player wins
        if (hasSword)
        {
            Console.WriteLine("\nYou have completed your quest.");
            Console.WriteLine("\nHope is now restored thanks to you!");
        }
        Console.WriteLine("\nProgram By Ethan Gapic-Kott, 000923124");
    }
}
