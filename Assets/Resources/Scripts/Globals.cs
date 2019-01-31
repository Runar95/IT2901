using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals {

    // Array of four doors, reflecting open/closed state of each door
    public static bool[] openDoors = new bool[4];

    static Globals() {
        openDoors[0] = true;
        openDoors[1] = false;

        Debug.Log("OpenDoors: " + openDoors[0] + ", " + openDoors[1] + ", " + openDoors[2] + "," + openDoors[3]);
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
}
