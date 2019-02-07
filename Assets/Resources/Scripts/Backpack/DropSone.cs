using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public int slotNUmber;

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
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if(d != null && this.slotNUmber == 0 || BackpackVariables.itemsInBackpack[this.slotNUmber] == BackpackVariables.Item.Empty)
        {
            d.parentToReturnTo = this.transform;
            d.inSlot = this.slotNUmber;
        }
    }
}
