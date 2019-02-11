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
    public Transform[] tr;

    // Start is called before the first frame update
    void Start()
    {
        BackpackVariables.itemsInBackpack[3] = BackpackVariables.Item.CoffeeCup;
        //BackpackVariables.itemsInBackpack[5] = BackpackVariables.Item.Man;
        //BackpackVariables.itemsInBackpack[6] = BackpackVariables.Item.Man;

        Debug.Log("Loading variables");
        Debug.Log(BackpackVariables.itemsInBackpack.ToString());
        for (int i = 0; i < BackpackVariables.itemsInBackpack.Length; i++)
        {
            if(BackpackVariables.itemsInBackpack[i] != BackpackVariables.Item.Empty)
            {
                switch (BackpackVariables.itemsInBackpack[i])
                {
                    case BackpackVariables.Item.CoffeeCup:
                        CoffeeCup.GetComponent<Dragable>().inSlot = i;
                        Instantiate(CoffeeCup, tr[i-1]);
        
                        break;
                    case BackpackVariables.Item.Face:
                        Face.GetComponent<Dragable>().inSlot = i;
                        Instantiate(Face, tr[i-1]);
                        break;
                    case BackpackVariables.Item.Mushroom:
                        Mushroom.GetComponent<Dragable>().inSlot = i;
                        Instantiate(Mushroom, tr[i-1]);
                        break;
                    case BackpackVariables.Item.Stone:
                        Stone.GetComponent<Dragable>().inSlot = i;
                        Instantiate(Stone, tr[i-1]);
                        break;
                    //case BackpackVariables.Item.Man:
                       // Man.GetComponent<Dragable>().inSlot = i;
                      //  Instantiate(Man, tr[i-1]);
                       // break;
              
                }
            }
        }
    }

}
