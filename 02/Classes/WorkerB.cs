using _02.Data;

namespace _02.Classes;

public class WorkerB
{
    private int _score = 0;
    public int Score => _score;

    public const string Lose = "X";
    public const string Draw = "Y";
    public const string Win = "Z";

    public static readonly Dictionary<string, string> ResultCharMap = new Dictionary<string, string>
    {
        { Lose, "Lose" },
        { Draw, "Draw" },
        { Win, "Win" }
    };

    public static readonly Dictionary<string, Dictionary<string, string>> SelectionMap = new Dictionary<string, Dictionary<string, string>>
    {
        {
            TheirShape.Rock, new Dictionary<string, string>
            {
                {Lose, YourShape.Scissors},
                {Draw, YourShape.Rock},
                {Win, YourShape.Paper}
            }
        },
        {
            TheirShape.Paper, new Dictionary<string, string>()
            {
                {Lose, YourShape.Rock},
                {Draw, YourShape.Paper},
                {Win, YourShape.Scissors}
            }
        },
        {
            TheirShape.Scissors, new Dictionary<string, string>
            {
                {Lose, YourShape.Paper},
                {Draw, YourShape.Scissors},
                {Win, YourShape.Rock}
            }
        }
    };

    public WorkerB(string fileName)
    {
        ParseFile(fileName);
    }

    public static void SolveSamplePartB()
    {
        var worker = new WorkerB("Sample.txt");
        Console.WriteLine(worker.Score);
    }
    
    public static void SolvePartB()
    {
        var worker = new WorkerB("Input.txt");
        Console.WriteLine(worker.Score);
    }

    public static string ChooseShape(string theirs, string result)
    {
        var selection = SelectionMap[theirs][result];
        Console.WriteLine($"{ResultCharMap[result]} against {ScoreMap.charMap[theirs]}: {ScoreMap.charMap[selection]}");
        return selection;
    }

    private void ParseFile(string fileName)
    {
        var rawData = File.ReadAllLines(fileName);
        foreach (var matchString in rawData)
        {
            ParseMatchString(matchString);
        }
    }

    private void ParseMatchString(string matchString)
    {
        var matchData = matchString.Split(" ");

        var selection = ChooseShape(matchData[0], matchData[1]);

        _score += ScoreMap.CalculateMatchScore(matchData[0], selection);

        Console.WriteLine($"Total: {_score}");
    }
}