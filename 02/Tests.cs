using System.Runtime.InteropServices;
using _02.Classes;
using _02.Data;

namespace _02;

public class Tests
{
    [Theory]
    [InlineData(TheirShape.Rock, YourShape.Rock, ScoreMap.DrawScore)]
    [InlineData(TheirShape.Scissors, YourShape.Scissors, ScoreMap.DrawScore)]
    [InlineData(TheirShape.Paper, YourShape.Paper, ScoreMap.DrawScore)]
    [InlineData(TheirShape.Rock, YourShape.Paper, ScoreMap.WinScore)]
    [InlineData(TheirShape.Scissors, YourShape.Rock, ScoreMap.WinScore)]
    [InlineData(TheirShape.Paper, YourShape.Scissors, ScoreMap.WinScore)]
    [InlineData(TheirShape.Rock, YourShape.Scissors, ScoreMap.LoseScore)]
    [InlineData(TheirShape.Scissors, YourShape.Paper, ScoreMap.LoseScore)]
    [InlineData(TheirShape.Paper, YourShape.Rock, ScoreMap.LoseScore)]
    public void ResultsAreCorrect(string theirs, string yours, int expectedScore)
    {
        Assert.Equal(expectedScore, ScoreMap.CalculateResultScore(theirs, yours));
    }

    [Theory]
    [InlineData(YourShape.Rock, 1)]
    [InlineData(YourShape.Paper, 2)]
    [InlineData(YourShape.Scissors, 3)]
    public void SelectionsAreCorrect(string yours, int expectedScore)
    {
        Assert.Equal(expectedScore, ScoreMap.CalculateSelectionScore(yours));
    }

    [Theory]
    [InlineData(TheirShape.Rock, YourShape.Rock, ScoreMap.DrawScore + 1)]
    [InlineData(TheirShape.Scissors, YourShape.Scissors, ScoreMap.DrawScore + 3)]
    [InlineData(TheirShape.Paper, YourShape.Paper, ScoreMap.DrawScore + 2)]
    [InlineData(TheirShape.Rock, YourShape.Paper, ScoreMap.WinScore + 2)]
    [InlineData(TheirShape.Scissors, YourShape.Rock, ScoreMap.WinScore + 1)]
    [InlineData(TheirShape.Paper, YourShape.Scissors, ScoreMap.WinScore + 3)]
    [InlineData(TheirShape.Rock, YourShape.Scissors, ScoreMap.LoseScore + 3)]
    [InlineData(TheirShape.Scissors, YourShape.Paper, ScoreMap.LoseScore + 2)]
    [InlineData(TheirShape.Paper, YourShape.Rock, ScoreMap.LoseScore + 1)]
    public void MatchScoresAreCorrect(string theirs, string yours, int expectedScore)
    {
        Assert.Equal(expectedScore, ScoreMap.CalculateMatchScore(theirs, yours));
    }

    [Fact]
    public void WorkerASampleIsCorrect()
    {
        var worker = new WorkerA("Sample.txt");
        Assert.Equal(15, worker.Score);
    }

    [Theory]
    [InlineData(TheirShape.Rock, WorkerB.Win, YourShape.Paper)]
    [InlineData(TheirShape.Rock, WorkerB.Draw, YourShape.Rock)]
    [InlineData(TheirShape.Rock, WorkerB.Lose, YourShape.Scissors)]
    [InlineData(TheirShape.Paper, WorkerB.Win, YourShape.Scissors)]
    [InlineData(TheirShape.Paper, WorkerB.Draw, YourShape.Paper)]
    [InlineData(TheirShape.Paper, WorkerB.Lose, YourShape.Rock)]
    [InlineData(TheirShape.Scissors, WorkerB.Win, YourShape.Rock)]
    [InlineData(TheirShape.Scissors, WorkerB.Draw, YourShape.Scissors)]
    [InlineData(TheirShape.Scissors, WorkerB.Lose, YourShape.Paper)]
    public void ResultMappingIsCorrect(string theirs, string result, string expected)
    {
        Assert.Equal(expected, WorkerB.SelectionMap[theirs][result]);
    }
}