using System.Runtime.InteropServices;
using _02.Classes;
using _02.Data;

namespace _02;

public class PartATests
{
    [Theory]
    [InlineData(TheirShape.Rock, YourShape.Rock, ScoreMap.Draw)]
    [InlineData(TheirShape.Scissors, YourShape.Scissors, ScoreMap.Draw)]
    [InlineData(TheirShape.Paper, YourShape.Paper, ScoreMap.Draw)]
    [InlineData(TheirShape.Rock, YourShape.Paper, ScoreMap.Win)]
    [InlineData(TheirShape.Scissors, YourShape.Rock, ScoreMap.Win)]
    [InlineData(TheirShape.Paper, YourShape.Scissors, ScoreMap.Win)]
    [InlineData(TheirShape.Rock, YourShape.Scissors, ScoreMap.Lose)]
    [InlineData(TheirShape.Scissors, YourShape.Paper, ScoreMap.Lose)]
    [InlineData(TheirShape.Paper, YourShape.Rock, ScoreMap.Lose)]
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
    [InlineData(TheirShape.Rock, YourShape.Rock, ScoreMap.Draw + 1)]
    [InlineData(TheirShape.Scissors, YourShape.Scissors, ScoreMap.Draw + 3)]
    [InlineData(TheirShape.Paper, YourShape.Paper, ScoreMap.Draw + 2)]
    [InlineData(TheirShape.Rock, YourShape.Paper, ScoreMap.Win + 2)]
    [InlineData(TheirShape.Scissors, YourShape.Rock, ScoreMap.Win + 1)]
    [InlineData(TheirShape.Paper, YourShape.Scissors, ScoreMap.Win + 3)]
    [InlineData(TheirShape.Rock, YourShape.Scissors, ScoreMap.Lose + 3)]
    [InlineData(TheirShape.Scissors, YourShape.Paper, ScoreMap.Lose + 2)]
    [InlineData(TheirShape.Paper, YourShape.Rock, ScoreMap.Lose + 1)]
    public void MatchScoresAreCorrect(string theirs, string yours, int expectedScore)
    {
        Assert.Equal(expectedScore, ScoreMap.CalculateMatchScore(theirs, yours));
    }

    [Fact]
    public void SampleIsCorrect()
    {
        var worker = new WorkerA("Sample.txt");
        Assert.Equal(15, worker.Score);
    }
}