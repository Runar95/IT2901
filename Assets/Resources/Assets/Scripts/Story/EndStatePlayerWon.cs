using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Fungus;

public class EndStatePlayerWon : MonoBehaviour
{
    Flowchart flowchart;

    private SpriteRenderer screen;
    public Sprite countdown1;
    public Sprite countdown2;
    public Sprite countdown3;
    public Sprite blackScreen;
    public Sprite gratulerer;
    public Sprite vandreren;
    private SpriteRenderer hani;
    private SpriteRenderer reza;

    private int act = 0;
    private bool playNewScene = false;

    private bool showCongratulation = false;

    void Start()
    {
        //retrieves needed variables from the scene
        GameObject screenObj = GameObject.Find("controlroom_screen");
        screen = screenObj.GetComponent<SpriteRenderer>();
        GameObject flowchartObject = GameObject.Find("Flowchart");
        flowchart = flowchartObject.GetComponent<Flowchart>();
        hani = GameObject.Find("Hani-full-size").GetComponent<SpriteRenderer>();
        reza = GameObject.Find("Reza_Full").GetComponent<SpriteRenderer>();
        hani.color = new Color(1f, 1f, 1f, 0f);
        reza.color = new Color(1f, 1f, 1f, 0f);
        //enables the first part of the scene to be played
        playNewScene = true;
    }

    void PlayScene()
    {
        //will play different scenes depending on where one is in the sequence
        switch(act)
        {
            case 1:
                StartCoroutine("ScreenCountDown");
                break;
            case 2:
                StartCoroutine("EnterHaniAndReza");
                break;
            case 3:
                StartCoroutine("VillainMonolog");
                break;
        }
    }

    IEnumerator ScreenCountDown()
    {
          for(int i = 0; i < 3; i++)
          {
              switch(i)
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

    IEnumerator EnterHaniAndReza()
    {
        showCongratulation = true;
        StartCoroutine("FlashCongratulation");
        yield return new WaitForSeconds(1);
        flowchart.ExecuteBlock("dialog1");
        while(flowchart.HasExecutingBlocks()){
            yield return new WaitForSeconds(0.3f);
        }
        for(int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            hani.color = new Color(1f, 1f, 1f, 0.02f*i);
            reza.color = new Color(1f, 1f, 1f, 0.02f*i);
        }
        flowchart.ExecuteBlock("dialog2");
        while(flowchart.HasExecutingBlocks()){
            yield return new WaitForSeconds(0.3f);
        }
        playNewScene = true;
    }



    IEnumerator FlashCongratulation()
    {
        while(showCongratulation)
        {
            screen.sprite = gratulerer;
            yield return new WaitForSeconds(0.5f);
            screen.sprite = blackScreen;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator VillainMonolog()
    {
        showCongratulation = false;
        screen.sprite = blackScreen;
        SpriteRenderer wanderer = GameObject.Find("ship_outside").GetComponent<SpriteRenderer>();
        wanderer.sortingOrder = 3;
        for(int i = 0; i < 50; i++)
        {
            screen.color = new Color(1f, 1f, 1f, 0.2f*i);
            yield return new WaitForSeconds(0.04f);
        }
        yield return null;
    }

    public void Update()
    {
        //if the flag saying that one is to play the next scene is set
        //next scene is played
        if(playNewScene)
        {
            act++;
            playNewScene = false;
            PlayScene();
        }
    }

}
