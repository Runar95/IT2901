using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour {

    public int level = 0;
    public int puzzle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Open next puzzle
    public void FinishLevel() {
        if (puzzle >= 0 && puzzle < 4) {
            Globals.openDoors[puzzle] = true;
        } else if (puzzle == 4) {
            // Make next travel location available
            // Globals.nextLevel();
            // Globals.resetOpenDoors();
            // Moved this functionality to MapScreen

            Globals.nextLevelAvailable = true;
        }
    }
}
