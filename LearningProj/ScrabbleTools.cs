using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Threading.Tasks.Sources;

namespace LearningProj
{
    static class ScrabbleTools
    {
        private static string[] sowpods;

        // Method to instantiate the sowpods
        public static void ScrabbleTools_Init()
        {
            sowpods = File.ReadAllText("C:\\Users\\karan\\source\\repos\\LearningProj\\LearningProj\\resources\\sowpods.txt").Split('\n');
            for(int i = 0; i < sowpods.Length; i++)
            {
                sowpods[i] = sowpods[i].Trim();
            }
        }
        
        private static Dictionary<char, int> pointValues = new Dictionary<char, int>(){
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1},
            {'U', 1}, {'N', 1}, {'R', 1}, {'T', 1},
            {'L', 1}, {'S', 1}, {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4},
            {'Y', 4}, {'K', 5}, {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10},
        };
        public static int Calculate_Score(string aWord)
        {
            int score = 0;
            aWord = aWord.ToUpper();
            try
            {
                foreach (char letter in aWord)
                    score += ScrabbleTools.pointValues[letter];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return score;
        }

        public static bool Is_Word_Legal(string aWord)
        {
            return sowpods.Contains(aWord.ToUpper());
        }

        public static List<(string, int)> Generate_Possible_Words(string tiles)
        {
            ArrayList possibleWords = new ArrayList();
            foreach(string word in sowpods)
            {
                if (word.Length <= tiles.Length)
                {
                    if(Is_Word_Spellable(tiles, word))
                    {
                        possibleWords.Add(word);
                    }
                }   
            }
            return Calculate_Possible_Word_Scores(possibleWords);
        }

        private static bool Is_Word_Spellable(string tiles, string word)
        {
            string remainingTiles = tiles;
            foreach(char letter in word)
            {
                if(!remainingTiles.Contains(letter))
                {
                    //Console.WriteLine("Tiles remaining: " + remainingTiles + "\nLetter under test: " + letter);
                    return false;
                }
                else
                {
                    remainingTiles = remainingTiles.Remove(remainingTiles.IndexOf(letter),1);
                }
            }
            return true;
        }

        private static List<(string,int)> Calculate_Possible_Word_Scores(ArrayList words)
        {
            List<(string, int)> scores = new List<(string, int)>();
            foreach(string word in words)
            {
                scores.Add((word, Calculate_Score(word)));
            }
            return Sort_Score_List(scores);
        }

        private static List<(string,int)> Sort_Score_List(List<(string ,int)> scores)
        {
            return scores.OrderByDescending(scores => scores.Item2).ToList();
        }

        public static void Print_Top_Words(List<(string, int)> words, int x)
        {
            words = Sort_Score_List(words);
            for(int i = 0; i < x; i++)
            {
                Console.WriteLine("Option " + i + ": " + words[i]);
            }
        }
        
    }
}
