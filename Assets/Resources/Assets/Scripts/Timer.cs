using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text text;
    private int timeLimitMinutes = 40;
    TimeSpan  timePassed;
  
    void Star(){
        if(Globals.startGameTime == DateTime.MinValue){
            text.enabled = false;
        }
    }
    void Update()
    {
        timePassed = Globals.startGameTime - DateTime.Now;
        if(Globals.startGameTime == DateTime.MinValue){
            //Do nothing - time is not started 
        }else if(timePassed.Minutes + timeLimitMinutes <= 0){
            text.text = "Tiden er ute";
        }else{
            text.text = "Tid igjen: " + string.Format(String.Format("{0:D2}", ((timeLimitMinutes-1 + timePassed.Minutes)))) + ":" 
            + string.Format(String.Format("{0:D2}", ((timeLimitMinutes*60 + timePassed.Seconds-1)%60)));
        }
    }

    public void StartTimer(){
        Globals.startGameTime = DateTime.Now;
        text.enabled = true;
    }
}
