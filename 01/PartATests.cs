using _01.Classes;
using Xunit.Abstractions;

namespace _01;

public class PartATests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PartATests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("Sample1.txt", 24000)]
    public void Day1(string fileName, int expectedAnswer)
    {
        var partA = new Worker(fileName);

        Assert.Equal(5, partA.Elves.Count);
        Assert.Equal(expectedAnswer, partA.HighestCalories);
        _testOutputHelper.WriteLine(partA.HighestCalories.ToString());
    }

}