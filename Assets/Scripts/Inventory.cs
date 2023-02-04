using System.Collections.Generic;

public static class Inventory
{
    private static Dictionary<ItemType, int> inventory;

    public static int GetItem(ItemType type, int amount)
    {
        var available = inventory[type];

        if (available >= amount)
        {
            inventory[type] -= amount;
            return amount;
        }
        else return 0;
    }

    public static void AddItem(ItemType type, int amount)
    {
        inventory[type] += amount;
    }

    public static void Clear()
    {
        inventory.Clear();
    }
}

public enum ItemType
{
    wood,
    metal,
    screw
}
