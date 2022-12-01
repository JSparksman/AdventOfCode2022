namespace _01.Classes;

public class Worker
{
    public List<Elf> Elves;
    
    public Worker(string fileName)
    {
        Elves = new List<Elf>();

        ParseFile(fileName);
    }

    public static void SolvePartA()
    {
        var worker = new Worker("Input.txt");
        Console.WriteLine(worker.HighestCalories);
    }

    public static void SolvePartB()
    {
        var worker = new Worker("Input.txt");
        var top3Calories = worker.Elves
            .OrderByDescending(x => x.TotalCalories)
            .Take(3)
            .Sum(x => x.TotalCalories);
        Console.WriteLine(top3Calories);
    }

    public int HighestCalories => Elves.MaxBy(x => x.TotalCalories)!.TotalCalories;

    private void ParseFile(string fileName)
    {
        var rawData = File.ReadAllLines(fileName).ToList();

        while (rawData.Any())
        {
            var separatorIndex = rawData.IndexOf("");
            List<string> elfData;
            
            if (separatorIndex == -1)
            {
                Elves.Add(ParseElf(rawData));
                break;
            }
            
            elfData = rawData.Take(separatorIndex).ToList();

            Elves.Add(ParseElf(elfData));
             
             rawData.RemoveRange(0, separatorIndex + 1);
        }
    }

    private static Elf ParseElf(IEnumerable<string> elfData)
    {
        var elf = new Elf();
        
        elf.Inventory.AddRange(elfData.Select(x => new InventoryItem(int.Parse(x))));

        return elf;
    }
}