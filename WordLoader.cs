/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

public class WordLoader
{
    public string[] LoadWordsFromFile(string fileName)
    {
        try
        {
            return File.ReadAllLines(fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
            return Array.Empty<string>();
        }
    }
}
