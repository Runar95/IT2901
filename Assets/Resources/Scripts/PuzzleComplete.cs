using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour {

    public int level = 0;
    public int puzzle = 0;


    // Open next puzzle
    public void FinishLevel() {
        Debug.Log("Finish puzzle: " + puzzle);
        if (puzzle >= 0 && puzzle < 4) {
            Globals.openDoors[puzzle] = true;
        } else if (puzzle == 4) {
            Globals.nextLevelAvailable = true;
        }
    }
}
