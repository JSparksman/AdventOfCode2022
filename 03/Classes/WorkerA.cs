namespace _03.Classes;

public class WorkerA
{
    public List<Rucksack> Rucksacks { get; }

    public WorkerA(string fileName)
    {
        Rucksacks = new List<Rucksack>();
        ParseFile(fileName);
    }

    public static void PartA()
    {
        var worker = new WorkerA("Input.txt");
        Console.WriteLine(worker.TotalPriority);
    }

    public int TotalPriority => Rucksacks.Sum(x => x.CommonItemPriority);

    private void ParseFile(string fileName)
    {
        var rawData = File.ReadAllLines(fileName);
        Rucksacks.AddRange(rawData.Select(x => new Rucksack(x)));
    }

    private Rucksack ParseRucksack(string rawString)
    {
        return new Rucksack(rawString);
    }

}