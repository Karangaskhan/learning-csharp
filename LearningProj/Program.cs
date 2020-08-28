using System;
using System.IO;
using System.Collections;
using System.Linq;


namespace LearningProj
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up scrabble tools
            ScrabbleTools.ScrabbleTools_Init();
            string userInput = "test";
            while (userInput != "")
            {
                // Prompt for user tiles
                Console.WriteLine("Welcome to Skaranbble Cheater\nEnter your letters");
                userInput = Console.ReadLine().ToUpper();

                var words = ScrabbleTools.Generate_Possible_Words(userInput);
                try
                {
                    Console.WriteLine("Your top word is: " + words[0].Item1 + " and it's worth " + words[0].Item2 + " points");
                }
                catch(System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

                ScrabbleTools.Print_Top_Words(words, 10);
            }
        }
    }
}
