using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parent = null;
    private Transform oldParent = null;
    public BackpackVariables.Item type;
    public int id;
    public int inSlot;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begining drag");
        BackpackVariables.itemsInBackpack[inSlot] = BackpackVariables.Item.Empty;
        parent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        

        if (oldParent != parent || parent == null && oldParent == null)
        {
            BackpackVariables.itemsInBackpack[this.inSlot] = this.type;
            oldParent = parent;
        }
        else
        {
            BackpackVariables.itemsInBackpack[this.inSlot] = this.type;
        }
    }
}
