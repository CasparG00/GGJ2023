using System.Collections.Generic;

public static class Inventory
{
    private static readonly Dictionary<ItemType, int> inventory = new();

    public static int GetItem(ItemType type, int amount)
    {
        var available = inventory[type];

        if (available >= amount)
        {
            inventory[type] -= amount;
            return amount;
        }
        return 0;
    }

    public static int CheckItem(ItemType type)
    {
        if (!inventory.ContainsKey(type))
        {
            inventory.Add(type, 0);
            return 0;
        }
        return inventory[type];
    }

    public static void AddItem(ItemType type, int amount)
    {
        if (!inventory.ContainsKey(type))
        {
            inventory.Add(type, 0);
        }
        inventory[type] += amount;
    }

    public static void Clear()
    {
        inventory.Clear();
    }
}

public enum ItemType
{
    Wood,
    Metal,
    Screw
}
