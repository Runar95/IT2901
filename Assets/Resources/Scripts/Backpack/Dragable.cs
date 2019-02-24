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
    public string inSlot;
    public bool isLocked;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!isLocked){
            BackpackVariables.items[inSlot] = BackpackVariables.Item.Empty;
            parent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;//Make sure dropZone can accsess mouse information
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       if(!isLocked){ 
            this.transform.position = eventData.position;
       }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!isLocked){
            this.transform.SetParent(parent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (oldParent != parent || parent == null && oldParent == null)
            {
                BackpackVariables.items[this.inSlot] = this.type;
                oldParent = parent;
            }
            else
            {
                BackpackVariables.items[this.inSlot] = this.type;
            }
        }
    }
}

