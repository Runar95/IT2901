using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class unlockCrDoor : MonoBehaviour
{
    private bool check = true;
    public Flowchart flowchart;
    public GameObject keySlot;
    void Update()
    {
        if(keySlot.GetComponent<DropZone>().itemInSlot != null && check){
            Invoke("UnlockDoor", 2);
            check = false;
        }
    }

    void UnlockDoor(){
         if(keySlot.GetComponent<DropZone>().itemInSlot != null){
            flowchart.ExecuteBlock("UnlcokCtrlRoom");
            gameObject.SetActive(false);
            BackpackVariables.SetItemInSlot("keyHole", BackpackVariables.Item.Empty);
            Globals.ctrlRoomDoorOpen = true;
        }else{
            check = true;
        }

    }
}