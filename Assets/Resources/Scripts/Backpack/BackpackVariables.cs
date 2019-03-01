using System.Collections.Generic;

public static class BackpackVariables
{
    public enum Item { Any, Empty, Coin, Stone, Man, Mushroom, Face, CoffeeCup ,Star };

    private static Dictionary<string, Item> items = new Dictionary<string, Item>(){
        {"1", Item.Empty},
        {"2", Item.Face },
        {"3", Item.Empty },
        {"4", Item.Star },
        {"5", Item.Empty },
        {"6", Item.Empty },
        {"7", Item.Stone },
        {"8", Item.Empty },
        {"9", Item.Empty },
        {"10", Item.Empty },
        {"Zone1", Item.Empty },
        {"Zone2", Item.Empty },
        {"Zone3", Item.Empty },
        {"Zone4", Item.Empty },
        {"BDZ", Item.Empty}
    };

    public static Item GetItemInSlot(string itemName){
        return items[itemName];
    }
    public static void setItemInSlot(string slotName, Item item){
        items[slotName] = item;
    }
}

