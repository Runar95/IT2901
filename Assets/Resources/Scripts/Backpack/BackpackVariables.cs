using System.Collections.Generic;

public static class BackpackVariables
{
    public enum Item { wrong, Any, Key, Empty, Coin, Stone, Man, Mushroom, Face, CoffeeCup ,Star };

    private static Dictionary<string, Item> items = new Dictionary<string, Item>(){
        {"1", Item.Empty},
        {"2", Item.Star },
        {"3", Item.Empty },
        {"4", Item.Empty },
        {"5", Item.Empty },
        {"6", Item.Empty },
        {"7", Item.Empty },
        {"8", Item.Empty },
        {"9", Item.Empty },
        {"10", Item.Empty },
        {"L1P3KeySlot", Item.Key },
        {"Zone2", Item.Empty },
        {"Zone3", Item.Empty },
        {"Zone4", Item.Empty },
        {"BDZ", Item.Empty}
    };

    public static Item GetItemInSlot(string itemName){
        return items[itemName];
    }
    public static void SetItemInSlot(string slotName, Item item){
        items[slotName] = item;
    }

    public static bool BackpackContainsKey(Item item){
        for(int i = 1; i<=10; i++){
            if(items[i.ToString()] == item){
                return true;
            }
        }
        return false;
        
    } 
}

