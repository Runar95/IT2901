using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventNotifier : MonoBehaviour
{
    
    public static void NotifyNewPuzzle(int door)
    {
        string text = "Dør" + door + " har åpnet seg i hovedrommet";
        EventDrawer.DrawMessage(text);
    }

    public static void NotifyNewLevel()
    {
        string text = "Et nytt nivå er tilgjengelig";
        EventDrawer.DrawMessage(text);
    }

    public static void NotifyOpenedControlRoom()
    {
        string text = "kontrollrommet har åpnet seg";
        EventDrawer.DrawMessage(text);
    }

}
