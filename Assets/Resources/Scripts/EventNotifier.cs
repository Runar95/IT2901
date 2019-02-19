using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNotifier
{
    public static void NotifyNewPuzzle(int door)
    {
        Debug.Log("Door" + door + " has nor been opened");
    }

    public static void NotifyNewLevel()
    {
        Debug.Log("New level available");
    }

    public static void NotifyOpenedControlRoom()
    {
        Debug.Log("Controll room opened");
    }


}
