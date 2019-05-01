 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class DoorScript : MonoBehaviour {

    // Doornumber of gameObject
    public int doorNumber = 0;
    public Sprite openDoor;
    public Sprite peekDoor;
    public Sprite closedDoor;

    public AudioClip doorSound;

    private bool hoverEnabled = false;

    private Flowchart flowchart;

    // Start is called before the first frame update
    void Start() {
        bool doorOpen = Globals.openDoors[doorNumber-1];

        hoverEnabled = doorOpen;

        // Set star state, based on globals
        if (doorNumber < 3) {
            gameObject.transform.GetChild(1).gameObject.SetActive(Globals.openDoors[doorNumber]);
        } else {
            gameObject.transform.GetChild(1).gameObject.SetActive(Globals.nextLevelAvailable);
        }
        gameObject.GetComponent<Clickable2D>().ClickEnabled = Globals.openDoors[doorNumber-1];

        // Set clickable, based on global game state
        gameObject.GetComponent<Clickable2D>().ClickEnabled = doorOpen;

        // Set sprite to closedDoor
        //gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseDown() {
        if (Globals.Debug || (Globals.openDoors[doorNumber-1] && !Globals.nextLevelAvailable)) {
            if (!Globals.Debug && Globals.getGurrentPuzzle() != doorNumber) {
                flowchart.ExecuteBlock("DoorVisited");
            } else {
                SceneManager.LoadScene(Globals.getPuzzleSceneString(doorNumber), LoadSceneMode.Single);
            }
        } else if (!Globals.nextLevelAvailable) {
            flowchart.ExecuteBlock("DoorLocked");
        } else {
            flowchart.ExecuteBlock("DoorLocked"); 
            // TODO: chage this to new block...
            // tell user to go to ctr-room and travel
        }
    }

    void OnMouseEnter() {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (hoverEnabled) {
            gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = peekDoor;
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(doorSound, 0.7f);
            }
        }
    }

    void OnMouseExit() {
        if (hoverEnabled) {
            gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;
        }
    }
}
