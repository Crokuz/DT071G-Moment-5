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
            Console.WriteLine("Pick a difficulty: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard \r\n");

            string difficulty = Console.ReadLine();
            string fileName = difficulty + ".txt";

            WordLoader wordLoader = new WordLoader();
            string[] words = wordLoader.LoadWordsFromFile(fileName);

            if (words.Length == 0)
            {
                Console.WriteLine("The file is empty or not found.");
                return;
            }

            Game game = new Game(words);
            game.Play();
        }
    }
}

