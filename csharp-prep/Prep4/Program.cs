using System;
using System.Collections.Generic; // Required for List

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<string> words = new List<string>();

        // Add initial words to the list

        int userInput = -1; // Initialize userInput

        while (userInput != 0)
        {
            Console.Write("Enter a number or word to add to the list (0 to quit): ");

            string userResponse = Console.ReadLine();

            // Try parsing the user input to an integer
            if (int.TryParse(userResponse, out userInput))
            {
                if (userInput != 0)
                {
                    // Add the user's input as a string to the list
                    words.Add(userResponse);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Display all words in the list
        Console.WriteLine("\nHere are the words/numbers in the list:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
