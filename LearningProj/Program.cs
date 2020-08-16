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

            // Prompt for user tiles
            Console.WriteLine("Welcome to Skaranbble Cheater\nEnter your letters");
            string userInput = Console.ReadLine().ToUpper();

            var words = ScrabbleTools.Generate_Possible_Words(userInput);

            Console.WriteLine("Your top word is: " + words[0].Item1 + " and it's worth " + words[0].Item2 + " points");

            ScrabbleTools.Print_Top_Words(words, 100);
        }
    }
}
