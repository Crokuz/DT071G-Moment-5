/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

using System;
using System.IO;

namespace Moment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Let's play hangman!\r\n");

            string[] words;
            
            //While-loop for input validation
            while (true)
            {
                Console.WriteLine("Pick a difficulty: ");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard \r\n");

                string difficulty = Console.ReadLine();
                string fileName = difficulty + ".txt";

                //Loads text file corresponding to previous input
                WordLoader wordLoader = new WordLoader();
                words = wordLoader.LoadWordsFromFile(fileName);

                if (words.Length > 0)
                {
                    break;
                }

                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.\r\n");
            }

            //Creates new instance of class Game to handle game logic
            Game game = new Game(words);
            game.Play();
        }
    }
}

