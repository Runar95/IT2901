using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string slotName;
    public Type type;
    public enum Type
    {
        dropAndTake,
        drop,
        take
    }

    void Start(){
        BackpackVariables.Item slotContains = BackpackVariables.items[slotName];
        if(slotContains != BackpackVariables.Item.Empty)
            {
                GameObject Face = GameObject.Find("Backpack_Map").GetComponent<LoadBackpack>().Face;
                GameObject Stone = GameObject.Find("Backpack_Map").GetComponent<LoadBackpack>().Stone;
                GameObject Mushroom = GameObject.Find("Backpack_Map").GetComponent<LoadBackpack>().Mushroom;
                GameObject CoffeeCup = GameObject.Find("Backpack_Map").GetComponent<LoadBackpack>().CoffeeCup;
                GameObject Star = GameObject.Find("Backpack_Map").GetComponent<LoadBackpack>().Star;
                switch (slotContains)
                {
                    case BackpackVariables.Item.CoffeeCup:
                        CoffeeCup.GetComponent<Dragable>().inSlot = slotName;
                        Instantiate(CoffeeCup, this.transform);
                        break;
                    case BackpackVariables.Item.Face:
                        Face.GetComponent<Dragable>().inSlot = slotName; 
                        Instantiate(Face, this.transform);
                        break;
                    case BackpackVariables.Item.Mushroom:
                        Mushroom.GetComponent<Dragable>().inSlot = slotName; 
                        Instantiate(Mushroom,this.transform);
                        break;
                    case BackpackVariables.Item.Stone:
                        Stone.GetComponent<Dragable>().inSlot = slotName;
                        Instantiate(Stone, this.transform);
                        break;
                    case BackpackVariables.Item.Star:
                       Star.GetComponent<Dragable>().inSlot = slotName; 
                       Instantiate(Star, this.transform);
                       break;
                    default:
                        Debug.Log("Could not find item");
                        break;
                }
            }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("Drop enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Drop exit");
    }
    public void OnDrop(PointerEventData eventData)
    {
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();//get reference to the object you are draging
        
        if(type == Type.drop){
            d.parent = this.transform;
            d.inSlot = this.slotName;
            d.isLocked = true;
        }
        else if(type != Type.take && d != null && this.slotName == "0" || BackpackVariables.items[this.slotName] == BackpackVariables.Item.Empty)
        {
            d.parent = this.transform;
            d.inSlot = this.slotName;
       }
    }
}