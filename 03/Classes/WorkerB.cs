namespace _03.Classes;

public class WorkerB
{
    public List<ElfGroup> ElfGroups { get; }
    
    public WorkerB(string fileName)
    {
        ElfGroups = new List<ElfGroup>();
        ParseFile(fileName);
    }

    public int TotalBadgePriority => ElfGroups.Sum(x => x.BadgePriority);

    private void ParseFile(string fileName)
    {
        var rawData = File.ReadAllLines(fileName);
        var numGroups = rawData.Length / 3;

        for (var i = 0; i < numGroups; i++)
        {
            ElfGroups.Add(new ElfGroup(rawData[i*3], rawData[i*3+1], rawData[i*3+2]));
        }
    }
    

    public static void PartB()
    {
        var worker = new WorkerB("Input.txt");
        Console.WriteLine(worker.TotalBadgePriority);
    }
}