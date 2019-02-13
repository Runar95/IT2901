using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class DoorScript : MonoBehaviour {

    // Doornumber of gameObject
    public int doorNumber = 0;

    // Start is called before the first frame update
    void Start() {
        /* 
        if (Globals.openDoors[doorNumber-1]) {
            // Set visible and clickable
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.GetComponent<Clickable2D>().ClickEnabled = true;
        } else {
            // Set invisible and unclickable
            gameObject.GetComponent<Clickable2D>().ClickEnabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        */
        // Set visible and clickable
        gameObject.transform.GetChild(0).gameObject.SetActive(Globals.openDoors[doorNumber-1]);
        if (doorNumber < 4) {
            gameObject.transform.GetChild(1).gameObject.SetActive(Globals.openDoors[doorNumber]);
        } else {
            gameObject.transform.GetChild(1).gameObject.SetActive(Globals.nextLevelAvailable);
        }
        gameObject.GetComponent<Clickable2D>().ClickEnabled = Globals.openDoors[doorNumber-1];
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnMouseDown() {
        if (Globals.openDoors[doorNumber-1]) {
            // SceneManager.LoadScene("L1_P1", LoadSceneMode.Single);
            SceneManager.LoadScene(Globals.getPuzzleSceneString(doorNumber), LoadSceneMode.Single);
        }
    }
}
