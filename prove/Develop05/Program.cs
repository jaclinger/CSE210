using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureGame
{
    // Class to represent a single word in the scripture
    class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public override string ToString()
        {
            return IsHidden ? "_____" : Text;
        }
    }

    // Class to represent the reference (John 3:16 or Proverbs 3:5-6)
    class Reference
    {
        public string ReferenceText { get; private set; }

        public Reference(string reference)
        {
            ReferenceText = reference;
        }

        public override string ToString()
        {
            return ReferenceText;
        }
    }

    // Class to represent the scripture, containing the reference and the list of words
    class Scripture
    {
        public Reference ScriptureReference { get; private set; }
        public List<Word> Words { get; private set; }

        public Scripture(string reference, string text)
        {
            ScriptureReference = new Reference(reference);
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        // Method to hide a random word in the scripture
        public void HideRandomWord()
        {
            Random rand = new Random();
            var nonHiddenWords = Words.Where(w => !w.IsHidden).ToList();
            if (nonHiddenWords.Any())
            {
                var wordToHide = nonHiddenWords[rand.Next(nonHiddenWords.Count)];
                wordToHide.IsHidden = true;
            }
        }

        // Method to display the scripture with hidden words
        public void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine(ScriptureReference.ToString());
            Console.WriteLine(string.Join(" ", Words));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Scripture data
            string reference = "John 3:16";
            string text = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life.";

            // Create a scripture instance
            Scripture scripture = new Scripture(reference, text);

            // Display the complete scripture
            scripture.DisplayScripture();

            // Keep prompting the user until all words are hidden
            while (true)
            {
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
                else if (input == "")
                {
                    scripture.HideRandomWord();
                    scripture.DisplayScripture();

                    // Check if all words are hidden
                    if (scripture.Words.All(w => w.IsHidden))
                    {
                        Console.WriteLine("\nAll words are hidden! Game over.");
                        break;
                    }
                }
            }
        }
    }
}
