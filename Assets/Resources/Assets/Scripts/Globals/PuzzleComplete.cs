using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour {

    public int level = 0;
    public int puzzle = 0;


    // Open next puzzle
    public void FinishLevel() {
        Debug.Log("Finish puzzle: " + puzzle);
        if (puzzle >= 0 && puzzle < 3) {
            Globals.setDoor(puzzle + 1, true);
        } else if (puzzle == 3) {
            Globals.nextLevelAvailable = true;

            //Alerts EventNotifier that one can now travel to a new location
            //Debug.Log("Hallo");
            EventNotifier.NotifyNewLevel();
        }
    }
}
