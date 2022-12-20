namespace _02.Data;

public static class ScoreMap
{
    public const int WinScore = 6;
    public const int DrawScore = 3;
    public const int LoseScore = 0;
    
    public static Dictionary<string, Dictionary<string, int>> ResultScores = new Dictionary<string, Dictionary<string, int>>
    {
        {
            TheirShape.Rock, new Dictionary<string, int>
            {
                {YourShape.Rock, DrawScore},
                {YourShape.Scissors, LoseScore},
                {YourShape.Paper, WinScore}
            }
        },
        {
            TheirShape.Scissors, new Dictionary<string, int>
            {
                {YourShape.Rock, WinScore},
                {YourShape.Scissors, DrawScore},
                {YourShape.Paper, LoseScore}
            }
        },
        {
            TheirShape.Paper, new Dictionary<string, int>
            {
                {YourShape.Rock, LoseScore},
                {YourShape.Scissors, WinScore},
                {YourShape.Paper, DrawScore}
            }
        }
    };

    public static Dictionary<string, int> SelectionScores = new Dictionary<string, int>
    {
        { YourShape.Rock, 1 },
        { YourShape.Scissors, 3 },
        { YourShape.Paper, 2 }
    };

    public static Dictionary<string, string> charMap = new Dictionary<string, string>
    {
        { TheirShape.Paper, "Paper" },
        { TheirShape.Rock, "Rock" },
        { TheirShape.Scissors, "Scissors" },
        { YourShape.Paper, "Paper" },
        { YourShape.Rock, "Rock" },
        { YourShape.Scissors, "Scissors" }
    };

    public static int CalculateResultScore(string theirs, string yours)
    {
        var score = ResultScores[theirs][yours];
        Console.WriteLine($"Result: {score}");
        return score;
    }
        

    public static int CalculateSelectionScore(string yours) {
        var score = SelectionScores[yours];
        Console.WriteLine($"Selection: {score}");
        return score;
    }

    public static int CalculateMatchScore(string theirs, string yours)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine($"{charMap[theirs]}, {charMap[yours]}");

        var score = CalculateResultScore(theirs, yours) + CalculateSelectionScore(yours);
        
        Console.WriteLine($"Match: {score}");
        
        return score;
    }
}

public struct YourShape
{
    public const string Rock = "X";
    public const string Paper = "Y";
    public const string Scissors = "Z";
}

public struct TheirShape
{
    public const string Rock = "A";
    public const string Paper = "B";
    public const string Scissors = "C";
}
