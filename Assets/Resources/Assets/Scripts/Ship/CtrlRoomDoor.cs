﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class CtrlRoomDoor : MonoBehaviour {

    // Doornumber of gameObject
    public Sprite openDoor;
    public Sprite peekDoor;
    public Sprite closedDoor;

    public AudioClip doorSound;

    private bool hoverEnabled = false;
    private bool doorOpen = Globals.ctrlRoomDoorOpen; 

    private Flowchart flowchart;

    // Start is called before the first frame update
    void Start() {

        hoverEnabled = doorOpen;

        // Set clickable, based on global game state
        gameObject.GetComponent<Clickable2D>().ClickEnabled = doorOpen;

        // Set sprite to closedDoor
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

    }


    void OnMouseDown() {
        flowchart.ExecuteBlock("MH2_ToCtrl");
    }

    void OnMouseEnter() {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (hoverEnabled) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = peekDoor;
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(doorSound, 0.7f);
            }
        }
    }

    void OnMouseExit() {
        if (hoverEnabled) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;
        }
    }
    public void openTheDoor(){
        this.doorOpen = true;
        hoverEnabled = doorOpen;
    }
}
