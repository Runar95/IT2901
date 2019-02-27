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
    private GameObject lastCollider;

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
                        break;
                    case BackpackVariables.Item.Face:
                        //Face.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Face,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        break;
                    case BackpackVariables.Item.Mushroom:
                        //Mushroom.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Mushroom,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        break;
                    case BackpackVariables.Item.Stone:
                        //Stone.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Stone,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                        break;
                    case BackpackVariables.Item.Star:
                        //Star.GetComponent<Dragable2>().inSlot = slotName;
                        item = Instantiate(Star,this.transform);
                        item.GetComponent<Dragable2>().inSlot = slotName;
                        pos = new Vector3(this.transform.position.x, this.transform.position.y ,this.transform.position.z);
                        item.transform.position = pos;
                        OnTriggerEnter2D(item.GetComponent<Collider2D>());
                       break;
                    default:
                        //Debug.Log("Could not find item");
                        break;
                }
            }
    }


    // Item enters target-collider
    void OnTriggerEnter2D(Collider2D collision) {
        if(BackpackVariables.items[slotName] == BackpackVariables.Item.Empty){
            lastCollider = collision.gameObject;
            if (lastCollider != null) {
                Vector3 pos = gameObject.transform.position;
                pos.z = -1;
                lastCollider.SendMessage("SetSnapPos", pos);
                lastCollider.SendMessage("SetLastTarget", gameObject.transform);
                lastCollider.GetComponent<Dragable2>().inSlot = this.slotName;
                BackpackVariables.items[this.slotName] = lastCollider.GetComponent<Dragable2>().type;
                Debug.Log(this.slotName);
            }
        }

    }

    void OnTriggerStay2D(Collider2D c) {

        // Debug.Log("Stay");
        // lastCollider = c.gameObject;
        // Vector3 pos = gameObject.transform.position;
        // pos.z = -1;
        // lastCollider.SendMessage("SetSnapPos", pos);
        // lastCollider.SendMessage("SetLastTarget", gameObject.transform);
    }

    void OnTriggerExit2D(Collider2D collision) {
       BackpackVariables.items[this.slotName] = BackpackVariables.Item.Empty;
    }
}

