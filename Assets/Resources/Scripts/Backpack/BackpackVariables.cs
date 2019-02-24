using System.Collections.Generic;

public static class BackpackVariables
{
    public enum Item { Any, Empty, Coin, Stone, Man, Mushroom, Face, CoffeeCup ,Star };
//    public static Item[] itemsInBackpack = { Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty, 
//                          Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty,
//                          Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty,
//                          Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty, Item.Empty };
    public static Dictionary<string, Item> items = new Dictionary<string, Item>(){
        {"1", Item.Empty},
        {"2", Item.Empty },
        {"3", Item.Empty },
        {"4", Item.Empty },
        {"5", Item.Empty },
        {"6", Item.Empty },
        {"7", Item.Empty },
        {"8", Item.Empty },
        {"9", Item.Empty },
        {"10", Item.Empty },
        {"Zone1", Item.Empty },
        {"Zone2", Item.Empty },
        {"Zone3", Item.Empty },
        {"BDZ", Item.Empty}
    };
}

