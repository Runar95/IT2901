using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDrawer : MonoBehaviour
{
    //boolean value indicating whether or not a message should be drawn on screen at any given time
    private static bool displayMessage, initiateMessage = false; 
    //message to be printed on screen due to event having occured
    private static string message;
    //style to use when making the message appear on screen
    private GUIStyle gs = new GUIStyle();

    private void Awake()
    {
        gs.fontSize = 30;
        gs.normal.textColor = Color.cyan;
    }

    public static void DrawMessage(string text)
    {
        message = text;
        initiateMessage = true;
    }


    IEnumerator ShowMessage()
    {
        displayMessage = true;
        yield return new WaitForSeconds(5);
        displayMessage = false;
    }

    private void Update()
    {
        if (initiateMessage)
        {
            initiateMessage = false;
            StartCoroutine(ShowMessage());
        }
    }

    private void OnGUI()
    {
        if (displayMessage) {
            GUI.Label(new Rect( Screen.width - (Screen.width / 2), Screen.height - (Screen.height / 7), 200, 200), message, gs);
        }
    }
}
