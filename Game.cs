/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

public class Game
{
    private readonly string _randomWord;
    private string _guessWord;
    private int _wrongGuess;
    private string _guesses;
    private bool _win;

    public Game(string[] words)
    {
        Random random = new Random();
        _randomWord = words[random.Next(words.Length)];
        _guessWord = new string('_', _randomWord.Length);
        _wrongGuess = 0;
        _guesses = "";
        _win = false;
    }

    public void Play()
    {
        HangmanDisplay display = new HangmanDisplay();

        while (_wrongGuess < 5 && !_win)
        {
            Console.Clear();
            Console.WriteLine("Letters guessed: " + _guesses);
            Console.WriteLine("Progression: " + _guessWord);
            Console.WriteLine(display.GetStage(_wrongGuess));

            string letter = GetLetterFromUser();
            ProcessGuess(letter);

            if (!_guessWord.Contains('_'))
            {
                _win = true;
            }
        }

        EndGame();
    }

    private string GetLetterFromUser()
    {
        while (true)
        {
            Console.WriteLine("Enter a letter:");
            string letter = Console.ReadLine()?.ToUpper();

            if (!string.IsNullOrEmpty(letter) && letter.Length == 1 && char.IsLetter(letter[0]))
            {
                _guesses += letter;
                return letter;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
            }
        }
    }

    private void ProcessGuess(string letter)
    {
        bool found = false;

        for (int i = 0; i < _randomWord.Length; i++)
        {
            if (_randomWord[i].ToString().Equals(letter, StringComparison.OrdinalIgnoreCase))
            {
                _guessWord = _guessWord.Remove(i, 1).Insert(i, letter);
                found = true;
            }
        }

        if (!found)
        {
            _wrongGuess++;
        }
    }

    private void EndGame()
    {
        Console.Clear();
        if (_wrongGuess == 5)
        {
            Console.WriteLine("The word was: " + _randomWord);
            Console.WriteLine("Better luck next time!");
        }
        else
        {
            Console.WriteLine("The word was: " + _randomWord);
            Console.WriteLine("Congratulations!");
        }
    }
}
