/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

//Class for handeling game progression through ASCII art
public class HangmanDisplay
{
    //String for storing different stages of the game
    private readonly string[] hangmanStages = {
        " +-----+\r\n O     |\r\n       |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n |     |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|     |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n/      |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n/ \\    |\r\n========"
    };

    //Returns corresponding stage of the game based on number of wrong guesses
    public string GetStage(int wrongGuess)
    {
        return hangmanStages[Math.Min(wrongGuess, hangmanStages.Length - 1)];
    }
}

