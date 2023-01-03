namespace _03.Classes;

public class ElfGroup
{
    public string A { get; init; }
    public string B { get; init; }
    public string C { get; init; }

    public ElfGroup(string a, string b, string c)
    {
        A = a;
        B = b;
        C = c;
    }

    public char Badge => A.Intersect(B).Intersect(C).First();
    public int BadgePriority => Constants.Priorities.IndexOf(Badge) + 1;
}