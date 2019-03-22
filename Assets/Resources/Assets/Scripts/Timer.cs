using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    public Text text;
    private static string status;
    private int timeLimitMinutes = 3;
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
            status = "Tiden er ute";
            text.text = status;
            //goes to end screen
            SceneManager.LoadScene("EndState_TimeRunOut");
            return;
        }else{
            status = "Tid igjen: " + string.Format(String.Format("{0:D2}", ((timeLimitMinutes-1 + timePassed.Minutes)))) + ":"
            + string.Format(String.Format("{0:D2}", ((timeLimitMinutes*60 + timePassed.Seconds-1)%60)));
        }
        text.text = status;
    }

    public void StartTimer(){
        Globals.startGameTime = DateTime.Now;
        text.enabled = true;
    }

    public static string GetTimerStatus()
    {
        return status;
    }
}
