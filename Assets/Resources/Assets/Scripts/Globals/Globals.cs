﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Globals {

 public static DateTime startGameTime = DateTime.MinValue;
    // Array of four doors, reflecting open/closed state of each door
    public static bool[] openDoors = new bool[3];

    // What level/location are we at
    public static int level = 1;
    // Can player move to next location
    public static bool nextLevelAvailable = false;

    // Last camera position
    public static Vector3 lastCamPos = new Vector3(0.0f, 0.0f, -10.0f);

    // Scene names of puzzles, index=level-1
    public static string[,] levelPuzzleScenes = new string [3, 3] {
        { "L1_P1", "L1_P2", "L1_P3"},
        { "L2_P1", "L2_P2", "L2_P3"},
        { "L3_P1", "L3_P2", "L3_P3"}
    };

    public static string[] levelCountries = new string [3] {
        "norge", "eritrea", "syria"
    };

    public static bool controlroomDoor = true;

    //struct which summs up the progrssion one has in the game
    //at a given time
    public struct Progress
    {
        public int level;
        public int puzzle;
        public string timerStatus;
    }

    static Globals() {
        openDoors[0] = true;
        openDoors[1] = false;

        // For testing, do remove this line
        // openDoors[3] = true;

        // Debug.Log("OpenDoors: " + openDoors[0] + ", " + openDoors[1] + ", " + openDoors[2] + "," + openDoors[3]);
    }

    // Resets all doors so that only the first one is open
    public static void resetOpenDoors() {
        openDoors = new bool[3];
        openDoors[0] = true;

        //notify EventNotifier that the doors are reset
        EventNotifier.NotifyNewPuzzle(1);
        //Updates the notebook
        NotebookController.SetAccess(1, NotebookController.GetLevelKey(level));
    }

    // Sets the open/close-value of a door
    public static void setDoor(int door, bool open) {
        //notifies EventNotifier that a new door is open, if that door is not allready open
        if (open && !openDoors[door - 1])
        {
            EventNotifier.NotifyNewPuzzle(door);
        }
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

        //notify the event notifyer
        EventNotifier.NotifyOpenedControlRoom();
    }

    public static bool getControlroomDoor(int level) {
    	return controlroomDoor;
    }

    public static string getCurrentLevelString() {
        return levelCountries[level-1];
    }

    public static int getGurrentPuzzle() {
        int current_puzzle = 0;
        for(int i = 0; i < openDoors.Length; i++)
        {
            if(openDoors[i])
            {
                current_puzzle = i+1;
            }
            else
            {
                break;
            }
        }
        return current_puzzle;
    }

    public static Progress GetProgress()
    {
        Progress p;
        p.level = level;
        int current_puzzle = 0;
        for(int i = 0; i < openDoors.Length; i++)
        {
            if(openDoors[i])
            {
                current_puzzle = i + 1;
            }
            else
            {
                break;
            }
        }
        p.puzzle = current_puzzle;
        p.timerStatus = global::Timer.GetTimerStatus();
        return p;
    }

    public static bool ctrlRoomDoorOpen = false;

    public static string lastView = "";


    public static void ResetGlobals(){
        startGameTime = DateTime.MinValue;
        level = 1; 
        resetOpenDoors();
        ctrlRoomDoorOpen = false;
        setControlroomDoor(false);
        BackpackVariables.SetItemInSlot("L1P3KeySlot", BackpackVariables.Item.Key);
    }
}
