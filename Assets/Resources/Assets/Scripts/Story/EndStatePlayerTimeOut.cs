using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Fungus;

public class EndStatePlayerTimeOut : MonoBehaviour
{
    //keeps track of which part of a scene to play
    private int act = 0;

    //flowchart with dialog
    Flowchart flowchart;

    //sprites to be changed in the scene
    public Sprite blackScreen;
    public Sprite countdown1;
    public Sprite countdown2;
    public Sprite countdown3;
    public Sprite timeIsOut;
    public Sprite vandreren;
    public Sprite wanderersInfrontOfScreen;
    public Sprite knowledgeCollage;
    public Sprite foodCollage;
    public Sprite friendsCollage;


    private bool playNewScene = false;
    private bool showTimesOut = false;

    private SpriteRenderer screen;
    private Vector3 screenPos;

    private bool drawProgress = false;

    private string progressMessage;


    void Start()
    {
        //retrieves needed variables from the scene
        GameObject screenObj = GameObject.Find("controlroom_screen");
        GameObject flowchartObject = GameObject.Find("Flowchart");
        flowchart = flowchartObject.GetComponent<Flowchart>();
        screenPos = screenObj.transform.localPosition;
        screen = screenObj.GetComponent<SpriteRenderer>();
        playNewScene = true;
        PlayScene();
    }

    void PlayScene()
    {
        //will play different scenes depending on where one is in the sequence
        switch (act)
        {
            case 1:
                StartCoroutine("ScreenCountDown");
                break;
            case 2:
                StartCoroutine("TimesOut");
                break;
            case 3:
                StartCoroutine("VillainMonolog");
                break;
            case 4:
                StartCoroutine("ShowProgressOnScreen");
                break;
        }
    }

    //counts down on screen in scene
    IEnumerator ScreenCountDown()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    screen.sprite = countdown3;
                    break;
                case 1:
                    screen.sprite = countdown2;
                    break;
                case 2:
                    screen.sprite = countdown1;
                    break;
            }
            yield return new WaitForSeconds(1);
        }
        screen.sprite = blackScreen;
        playNewScene = true;
    }

    //flashes times out on screen
    IEnumerator TimesOut()
    {
        showTimesOut = true;
        StartCoroutine("FlashTimesOut");
        yield return new WaitForSeconds(1f);
        flowchart.ExecuteBlock("dialog");
        while(flowchart.HasExecutingBlocks()){
            yield return new WaitForSeconds(0.3f);
        }
        playNewScene = true;
    }

    IEnumerator FlashTimesOut()
    {
        while (showTimesOut)
        {
            screen.sprite = timeIsOut;
            yield return new WaitForSeconds(0.5f);
            screen.sprite = blackScreen;
            yield return new WaitForSeconds(0.5f);
        }
    }

    //plays the part of the scene where the villain is performing a monolog
    IEnumerator VillainMonolog()
    {
        showTimesOut = false;
        screen.sprite = blackScreen;
        SpriteRenderer wanderer = GameObject.Find("ship_outside").GetComponent<SpriteRenderer>();
        for(int i = 1; i < 6; i++)
        {
            if(i == 1)
            {
                for(int j = 0; j <= 200; j++)
                {
                    yield return new WaitForSeconds(0.01f);
                    screen.color = new Color(1f, 1f, 1f, 1f - 0.005f*j);
                }
                flowchart.ExecuteBlock("villainMonolog");
            }else
            {
                flowchart.ExecuteBlock("villainMonolog_part" + i);
            }
            while (flowchart.HasExecutingBlocks())
            {
                yield return new WaitForSeconds(0.5f);
            }

            switch(i)
            {
                case 1:
                    screen.color = new Color(1f, 1f, 1f, 1f);
                    screen.sprite = wanderersInfrontOfScreen;
                    break;
                case 2:
                    screen.color = new Color(1f, 1f, 1f, 0f);
                    break;
                case 3:
                    screen.color = new Color(1f, 1f, 1f, 1f);
                    screen.sprite = knowledgeCollage;
                    break;
                case 5:
                    screen.color = new Color(1f, 1f, 1f, 0f);
                    break;
            }
        }
        screen.sprite = blackScreen;
        screen.color = new Color(1f, 1f, 1f, 1f);
        playNewScene = true;
    }

    IEnumerator ShowProgressOnScreen()
    {
        global::Globals.Progress prog = Globals.GetProgress();
        int l = prog.level;
        int p = prog.puzzle;
        progressMessage = "Dere nådde puzzle " + p + " på nivå " + l + ".";
        drawProgress = true;
        yield return null;
    }

    public void Update()
    {
        //if the flag saying that one is to play the next scene is set
        //next scene is played
        if (playNewScene)
        {
            act++;
            playNewScene = false;
            PlayScene();
        }
    }

    public void OnGUI()
    {
        if (drawProgress)
        {
            GUI.Label(new Rect(Screen.width / 2 - Screen.width / 8, Screen.height / 2 - Screen.height / 25, 200, 200), "Tiden er ute.");
            GUI.Label(new Rect(Screen.width / 2 - Screen.width / 8, (Screen.height / 2) - Screen.height / 25 + 30, 200, 200), progressMessage);
        }
    }

}
