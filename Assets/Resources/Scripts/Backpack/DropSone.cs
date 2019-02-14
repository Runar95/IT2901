using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public int slotNumber;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Drop enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Drop exit");
    }
    public void OnDrop(PointerEventData eventData)
    {
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();//get reference to the object you are draging
        if(d != null && this.slotNumber == 0 || BackpackVariables.itemsInBackpack[this.slotNumber] == BackpackVariables.Item.Empty)
        {
            d.parent = this.transform;
            d.inSlot = this.slotNumber;
        }
    }
} 