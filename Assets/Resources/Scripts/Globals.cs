using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals {
    public static bool[] openDoors = new bool[4];

    static Globals() {
        openDoors[0] = true;
        openDoors[1] = false;

        Debug.Log("OpenDoors: " + openDoors[0] + ", " + openDoors[1] + ", " + openDoors[2] + "," + openDoors[3]);
    }

    public static void resetOpenDoors() {
        openDoors = new bool[4];
    }

    public static void setDoor(int door, bool open) {
        openDoors[door - 1] = open;
    }

    public static bool getDoor(int door) {
        return openDoors[door -1];
    }
}
