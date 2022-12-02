using _02.Data;

namespace _02.Classes;

public class WorkerA
{
    private int _score = 0;

    public int Score => _score;

    public WorkerA(string fileName)
    {
        ParseFile(fileName);
    }

    public static void SolveSample()
    {
        var worker = new WorkerA("Sample.txt");
        Console.WriteLine(worker.Score);
    }
    
    public static void SolvePartA()
    {
        var worker = new WorkerA("Input.txt");
        Console.WriteLine(worker.Score);
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

        _score += ScoreMap.CalculateMatchScore(matchData[0], matchData[1]);
        
        Console.WriteLine($"Total: {_score}");
    }
}