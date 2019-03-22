using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndStatePlayerTimeOut : MonoBehaviour
{
    global::Globals.Progress progress;

    void Start()
    {
        global::Globals.Progress progress = Globals.GetProgress();
        if(progress.timerStatus == "Tiden er ute")
        PlayersTimeRanOut();
    }

    void PlayersTimeRanOut()
    {
        string endString = "Desverre, har tiden gått ut\n";
        endString += "Du kom deg til puzzle " + (progress.puzzle + 1) + " på nivå " + (progress.level +1);
        endString += " Det er kjempebra";
        Debug.Log(endString);
    }

}
