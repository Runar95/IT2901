using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBackpack : MonoBehaviour
{
    //public GameObject Man;
    public GameObject Face;
    public GameObject Mushroom;
    public GameObject Stone;
    public GameObject CoffeeCup;
    public GameObject Star;
    public Transform[] tr;

    // Start is called before the first frame update
//    void Start()
//    {
//        for (int i = 1; i <= 1; i++)
//        {
//            if(BackpackVariables.items["" + i] != BackpackVariables.Item.Empty)
//            {
//                switch (BackpackVariables.items["" + i])
//                {
//                    case BackpackVariables.Item.CoffeeCup:
//                        CoffeeCup.GetComponent<Dragable>().inSlot = "" + i;
//                        Instantiate(CoffeeCup, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Face:
//                        Face.GetComponent<Dragable>().inSlot = "" + i;
//                        Instantiate(Face, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Mushroom:
//                        Mushroom.GetComponent<Dragable>().inSlot = "" + i;
//                        Instantiate(Mushroom, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Stone:
//                        Stone.GetComponent<Dragable>().inSlot = "" + i;
//                        Instantiate(Stone, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Star:
//                       Star.GetComponent<Dragable>().inSlot = "" + i;
//                       Instantiate(Star, tr[i-1]);
//                       break;
//              
//                }
//            }
//        }
//        foreach(var item in BackpackVariables.items)
//        {
//            if(item.Value != BackpackVariables.Item.Empty)
//            {
//                switch (item.Value)
//                {
//                    case BackpackVariables.Item.CoffeeCup:
//                        CoffeeCup.GetComponent<Dragable>().inSlot = item.Key;
//                        Instantiate(CoffeeCup, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Face:
//                        Face.GetComponent<Dragable>().inSlot = item.Key; 
//                        Instantiate(Face, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Mushroom:
//                        Mushroom.GetComponent<Dragable>().inSlot = item.Key; 
//                        Instantiate(Mushroom, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Stone:
//                        Stone.GetComponent<Dragable>().inSlot = item.Key;
//                        Instantiate(Stone, tr[i-1]);
//                        break;
//                    case BackpackVariables.Item.Star:
//                       Star.GetComponent<Dragable>().inSlot = item.Key; 
//                       Instantiate(Star, tr[i-1]);
//                       break;
//              
//                }
//            }
//        }
//    }
}