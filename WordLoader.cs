/*
Leander Norberg
leno2003@student.miun.se
Programmering i C#.NET (DT071G)
Moment 5
*/

namespace Moment_5;

//Class for loading words from tex files
public class WordLoader
{
    //Loads words form text file if possible
    public string[] LoadWordsFromFile(string fileName)
    {
        try
        {
            return File.ReadAllLines(fileName);
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }
}
