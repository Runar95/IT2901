using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals {

    // Array of four doors, reflecting open/closed state of each door
    public static bool[] openDoors = new bool[4];

    // What level/location are we at 
    public static int level = 1;
    // Can player move to next location
    public static bool nextLevelAvailable = false;

    // Last camera position
    public static Vector3 lastCamPos = new Vector3(0.0f, 0.0f, -10.0f);

    // Scene names of puzzles, index=level-1
    public static string[,] levelPuzzleScenes = new string [2, 4] {
        { "L1_P1", "L1_P2", "L1_P3", "L1_P4"},
        { "L2_P1_Test", "L2_P2", "", ""}
    };
    
    public static bool controlroomDoor = true;

    static Globals() {
        openDoors[0] = true;
        openDoors[1] = false;

        // For testing, do remove this line
        // openDoors[3] = true;

        // Debug.Log("OpenDoors: " + openDoors[0] + ", " + openDoors[1] + ", " + openDoors[2] + "," + openDoors[3]);
    }

    // Resets all doors so that only the first one is open
    public static void resetOpenDoors() {
        openDoors = new bool[4];
        openDoors[0] = true;
    }

    // Sets the open/close-value of a door 
    public static void setDoor(int door, bool open) {
        openDoors[door - 1] = open;
    }

    // Gets the open/close-value of a door 
    public static bool getDoor(int door) {
        return openDoors[door -1];
    }

    // Sets next level
    public static void nextLevel() {
        level += 1;
        nextLevelAvailable = false;
    }

    public static string getPuzzleSceneString(int puzzle) {
        return levelPuzzleScenes[level - 1, puzzle - 1];
    }
    
    public static void setControlroomDoor(bool locked) {
    	controlroomDoor = locked;
    }
    
    public static bool getControlroomDoor(int level) {
    	return controlroomDoor;
    }
}
