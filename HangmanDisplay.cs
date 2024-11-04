/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

public class HangmanDisplay
{
    private readonly string[] _hangmanStages = {
        " +-----+\r\n O     |\r\n       |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n |     |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|     |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n       |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n/      |\r\n========",
        " +-----+\r\n O     |\r\n/|\\    |\r\n/ \\    |\r\n========"
    };

    public string GetStage(int wrongGuess)
    {
        return _hangmanStages[Math.Min(wrongGuess, _hangmanStages.Length - 1)];
    }
}

