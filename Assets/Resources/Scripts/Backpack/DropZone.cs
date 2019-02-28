using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone: MonoBehaviour
{   
    public string slotName;
    public Type type;
    public enum Type
    {
        dropAndTake,
        drop,
        take
    }
    private GameObject item = null;

    void Start(){
        BackpackVariables.Item slotContains = BackpackVariables.items[slotName];
        //Debug.Log(slotName + slotContains);
        if(slotContains != BackpackVariables.Item.Empty)
            {
                GameObject Face = GameObject.Find("Main Camera").GetComponent<LoadBackpack>().Face;
                GameObject Stone = GameObject.Find("Main Camera").GetComponent<LoadBackpack>().Stone;
                GameObject Mushroom = GameObject.Find("Main Camera").GetComponent<LoadBackpack>().Mushroom;
                GameObject CoffeeCup = GameObject.Find("Main Camera").GetComponent<LoadBackpack>().CoffeeCup;
                GameObject Star = GameObject.Find("Main Camera").GetComponent<LoadBackpack>().Star;
                switch (slotContains)
                {
                    case BackpackVariables.Item.CoffeeCup:
                        //CoffeeCup.GetComponent<Dragable2>().inSlot = slotName;
                        GameObject item = Instantiate(CoffeeCup,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        this.item = item;
                        break;
                    case BackpackVariables.Item.Face:
                        //Face.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Face,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        this.item = item;
                        break;
                    case BackpackVariables.Item.Mushroom:
                        //Mushroom.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Mushroom,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        this.item = item;
                        break;
                    case BackpackVariables.Item.Stone:
                        //Stone.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Stone,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        this.item = item;
                        break;
                    case BackpackVariables.Item.Star:
                        //Star.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Star,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        this.item = item;
                       break;
                    default:
                        //Debug.Log("Could not find item");
                        break;
                }
            }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if(this.item == null){
            this.item = collision.gameObject;
            if (this.item != null) {
                Vector3 pos = gameObject.transform.position;
                this.item.SendMessage("SetSnapPos", pos);
                this.item.SendMessage("SetLastTarget", gameObject.transform);
                BackpackVariables.items[this.slotName] = item.GetComponent<Dragable2>().type;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(this.item == collision.gameObject){
            BackpackVariables.items[this.slotName] = BackpackVariables.Item.Empty;
            this.item = null;
        }  
    }
}

