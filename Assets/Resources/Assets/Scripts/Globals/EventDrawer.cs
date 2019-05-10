﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventDrawer : MonoBehaviour
{
    //boolean value indicating whether or not a message should be drawn on screen at any given time
    private static bool displayMessage, initiateMessage = false;
    //message to be printed on screen due to event having occured
    private static List<string> messages = new List<string>();
    //style to use when making the message appear on screen
    private GUIStyle gs = new GUIStyle();

    private GameObject eventCanvas = null;

    //initializes variables before scenes are loaded
    private void Awake()
    {
        gs.fontSize = 30;
        gs.normal.textColor = Color.black;
    }

    //action to be done upon loadin a scene where the EwentDrawer is used
    private void Start()
    {
        //if a message did not play to completion last time a scene was loaded,
        //it is now discarded
        if(displayMessage)
        {
            displayMessage = false;
            messages.RemoveAt(0);
            if(messages.Count != 0)
            {
                initiateMessage = true;
            }
        }

        if(eventCanvas == null)
        {
            eventCanvas = GameObject.Find("EventCanvas");
        }
        eventCanvas.SetActive(false);


    }

    public static void DrawMessage(string text)
    {
        messages.Add(text);
        if(messages.Count == 1)
        {
            initiateMessage = true;
        }
    }


    IEnumerator ShowMessage()
    {
        displayMessage = true;
        yield return new WaitForSeconds(3);
        displayMessage = false;
        messages.RemoveAt(0);
        if(messages.Count != 0)
        {
            initiateMessage = true;
        }
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
            //GUI.Label(new Rect( (Screen.width / 8), (Screen.height / 8), 0, 0), messages[0], gs);
            Text t = eventCanvas.GetComponentInChildren<Text>();
            t.text = messages[0];
            eventCanvas.SetActive(true);
        }
        else if(messages.Count == 0)
        {
            eventCanvas.SetActive(false);
        }
    }
}