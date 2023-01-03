using _03.Classes;
using Xunit.Abstractions;

namespace _03;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData("Sample.txt")]
    public void Rucksack_ParsesCorrectly(string fileName)
    {
        var worker = new WorkerA(fileName);

        foreach (var rucksack in worker.Rucksacks)
        {
            Assert.Equal(rucksack.RawData, $"{rucksack.Compartment1}{rucksack.Compartment2}");
        }
    }

    [Fact]
    public void Rucksack_CalculatesCommonItemCorrectly_ForSample()
    {
        var worker = new WorkerA("Sample.txt");
        char[] answers = { 'p', 'L', 'P', 'v', 't', 's' };

        for (var i = 0; i < answers.Length; i++)
        {
            Assert.Equal(answers[i], worker.Rucksacks[i].CommonItem);
        }
    }

    [Fact]
    public void Rucksack_CalculatesPriorityCorrectly_ForSample()
    {
        var worker = new WorkerA("Sample.txt");
        int[] answers = { 16, 38, 42, 22, 20, 19 };
        
        for (var i = 0; i < answers.Length; i++)
        {
            Assert.Equal(answers[i], worker.Rucksacks[i].CommonItemPriority);
        }
    }

    [Fact]
    public void WorkerA_CalculatesPrioritySumCorrectly_ForSample()
    {
        var worker = new WorkerA("Sample.txt");
        Assert.Equal(157, worker.TotalPriority);
    }

    [Fact]
    public void WorkerB_CalculatesBadgeCorrectly_ForSample()
    {
        var worker = new WorkerB("Sample.txt");
        char[] answers = { 'r', 'Z' };

        for (var i = 0; i < answers.Length; i++)
        {
            _testOutputHelper.WriteLine(worker.ElfGroups[i].A);
            _testOutputHelper.WriteLine(worker.ElfGroups[i].B);
            _testOutputHelper.WriteLine(worker.ElfGroups[i].C);
            _testOutputHelper.WriteLine(worker.ElfGroups[i].Badge.ToString());
            Assert.Equal(answers[i], worker.ElfGroups[i].Badge);
        }
    }

    [Fact]
    public void WorkerB_CalculatesPriorityCorrectly_ForSample()
    {
        var worker = new WorkerB("Sample.txt");
        Assert.Equal(70, worker.TotalBadgePriority);
    }
}