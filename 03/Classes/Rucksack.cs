namespace _03.Classes;

public class Rucksack
{
    public Rucksack(string input)
    {
        RawData = input;
        Compartment1 = input[..(input.Length / 2)];
        Compartment2 =  input[(input.Length / 2)..];
    }
    
    public string RawData { get; init; }
    public string Compartment1 { get; init; }
    public string Compartment2 { get; init; }

    public char CommonItem => Compartment1.Intersect(Compartment2).First();
    public int CommonItemPriority => Constants.Priorities.IndexOf(CommonItem) + 1;
}