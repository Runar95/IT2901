using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone: MonoBehaviour{
    public string slotName;
    public Type type;
    public BackpackVariables.Item acceptingItem;
    public enum Type{dropAndTake, drop, take}
    public GameObject itemInSlot = null;

    void Start(){//Load correct item in this slot
        BackpackVariables.Item slotContains = BackpackVariables.GetItemInSlot(this.slotName);
        //Debug.Log(slotName + ": " + slotContains);
        if(slotContains != BackpackVariables.Item.Empty){
                switch (slotContains){
                    case BackpackVariables.Item.CoffeeCup:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().CoffeeCup);
                        break;
                    case BackpackVariables.Item.Face:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().Face);
                        break;
                    case BackpackVariables.Item.Mushroom:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().Mushroom);
                        break;
                    case BackpackVariables.Item.Stone:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().Stone);
                        break;
                    case BackpackVariables.Item.Star:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().Star);
                        break;
                    case BackpackVariables.Item.Key:
                        loadItem(GameObject.Find("Main Camera/Backpack_NC").GetComponent<LoadBackpack>().Key);
                        break;
                    default:
                        //Debug.Log("Could not find item");
                        break;
                }
            }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(this.itemInSlot == null
        && IsDraggableObject(collision.gameObject)
        && this.type != Type.take
        && (this.acceptingItem == BackpackVariables.Item.Any || this.acceptingItem == collision.gameObject.GetComponent<Dragable>().itemType))
        {
            this.itemInSlot = collision.gameObject;
            this.itemInSlot.SendMessage("SetSnapPos", gameObject.transform.position);
            collision.gameObject.transform.SetParent(this.gameObject.transform);
            this.itemInSlot.GetComponent<Dragable>().inSlot = this;
            BackpackVariables.SetItemInSlot(this.slotName, itemInSlot.GetComponent<Dragable>().itemType);
        }
    }
    void OnTriggerExit2D(Collider2D collision) {//When item is dragged out of this slot.
        if(this.itemInSlot == collision.gameObject){
            BackpackVariables.SetItemInSlot(this.slotName, BackpackVariables.Item.Empty);
            this.itemInSlot = null;
        }
    }
     void OnTriggerStay2D(Collider2D collision) {
         if (IsDraggableObject(collision.gameObject))
            this.itemInSlot.SendMessage("SetSnapPos", gameObject.transform.position);
     }
    private void loadItem(GameObject itemType){//load correct item from loadbackpack into this slot.
            GameObject item = Instantiate(itemType, this.transform);
            item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
            OnTriggerEnter2D(item.GetComponent<Collider2D>());
            this.itemInSlot = item;
    }

    private bool IsDraggableObject(GameObject g) {
        return g.GetComponent<Dragable>() != null;
    }
}
