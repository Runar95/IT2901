using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel(){
        Globals.nextLevel();
        Globals.resetOpenDoors();
    }
    public void openDoors(){
        Globals.setDoor(2, true);
        Globals.setDoor(3,true);
        Globals.nextLevelAvailable = true;
        EventNotifier.NotifyNewLevel();
        Globals.Debug = true; 
    }
}
