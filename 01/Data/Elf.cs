namespace _01.Classes;

public class Elf
{
    public List<InventoryItem> Inventory { get; set; }

    public Elf()
    {
        Inventory = new List<InventoryItem>();
    }

    public int TotalCalories => Inventory.Sum(x => x.Calories);
}