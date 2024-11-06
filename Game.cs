/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

//Class for handeling game logic
public class Game
{
    private readonly string randomWord;
    private string guessWord;
    private int wrongGuess;
    private string guesses;
    private bool win;

    //Constructor for Game class
    public Game(string[] words)
    {
        //Generates pseudo-random number for fetching word from text file
        Random random = new Random();
        randomWord = words[random.Next(words.Length)];
        guessWord = new string('_', randomWord.Length);
        wrongGuess = 0;
        guesses = "";
        win = false;
    }

    //Main game method for user interaction
    public void Play()
    {
        //Creates new instance of class HangmanDisplay to display game progression
        HangmanDisplay display = new HangmanDisplay();

        while (wrongGuess < 5 && !win)
        {
            Console.Clear();
            //Prints display for corresponding number of wrong guesses
            Console.WriteLine(display.GetStage(wrongGuess));
            //Prints string of previous guesses
            Console.WriteLine("Letters guessed: " + guesses);
            //Prints word progression
            Console.WriteLine("Progression: " + guessWord);

            string letter = GetLetterFromUser();
            ProcessGuess(letter);

            //If the string guessWord no longer contains any placeholder characters, the game is won
            if (!guessWord.Contains('_'))
            {
                win = true;
            }
        }

        //Displays endgame information
        EndGame(display.GetStage(wrongGuess));
    }

    //Method for getting and validating user input
    private string GetLetterFromUser()
    {
        while (true)
        {
            Console.WriteLine("Enter a letter:");
            string letter = Console.ReadLine()?.ToUpper();

            //Validates that input is not null and is a single letter
            if (!string.IsNullOrEmpty(letter) && letter.Length == 1 && char.IsLetter(letter[0]))
            {
                guesses += letter;
                return letter;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
            }
        }
    }

    //Method for handeling game progression
    private void ProcessGuess(string letter)
    {
        bool found = false;

        for (int i = 0; i < randomWord.Length; i++)
        {
            //Reveals the letter at it's corresponding location if guessed correctly 
            if (randomWord[i].ToString().Equals(letter, StringComparison.OrdinalIgnoreCase))
            {
                guessWord = guessWord.Remove(i, 1).Insert(i, letter);
                found = true;
            }
        }

        if (!found)
        {
            wrongGuess++;
        }
    }

    //Method for displaying endgame information
    private void EndGame(string hangman)
    {
        Console.Clear();
        if (wrongGuess == 5)
        {
            Console.WriteLine(hangman);
            Console.WriteLine("The word was: " + randomWord);
            Console.WriteLine("Better luck next time!");
        }
        else
        {
            Console.WriteLine(hangman);
            Console.WriteLine("The word was: " + randomWord);
            Console.WriteLine("Congratulations!");
        }
    }
}
