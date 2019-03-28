using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Fungus;

public class EndStatePlayerWon : MonoBehaviour
{
    //flowchart where dialog is kept
    Flowchart flowchart;

    //sprites and spreitrenderers used in the scene
    private SpriteRenderer screen;
    public Sprite countdown1;
    public Sprite countdown2;
    public Sprite countdown3;
    public Sprite blackScreen;
    public Sprite gratulerer;
    public Sprite vandreren;
    public Sprite wanderersInfrontOfScreen;
    public Sprite knowledgeCollage;
    public Sprite foodCollage;
    public Sprite friendsCollage;

    //variable that keeps track of which part of the scene one is at
    private int act = 0;
    //variable that alerts the update function on when to play a new scene part
    private bool playNewScene = false;

    private bool showCongratulation = false;

    //image to be faded in on screen
    private Image fadeImage;

    void Start()
    {
        //retrieves needed variables from the scene
        GameObject screenObj = GameObject.Find("controlroom_screen");
        screen = screenObj.GetComponent<SpriteRenderer>();
        GameObject flowchartObject = GameObject.Find("Flowchart");
        flowchart = flowchartObject.GetComponent<Flowchart>();
        //sets the fade-to-black screen
        fadeImage = GameObject.Find("Image").GetComponent<Image>();
        Color c = fadeImage.color;
        c.a = 0;
        fadeImage.color = c;
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
            case 4:
                StartCoroutine("FadeToBlack");
                break;
        }
    }

    //plays the part of the scene where the screen is counting down
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

    //plays the part of the scene where Hani and Reza enter the controlroom
    IEnumerator EnterHaniAndReza()
    {
        showCongratulation = true;
        StartCoroutine("FlashCongratulation");
        yield return new WaitForSeconds(1);
        flowchart.ExecuteBlock("dialog");
        while(flowchart.HasExecutingBlocks()){
            yield return new WaitForSeconds(0.3f);
        }
        playNewScene = true;
    }


    //flashes congratulation on screen for a while
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

    //plays the part of the scene where the villain is performing a monolog
    IEnumerator VillainMonolog()
    {
        showCongratulation = false;
        screen.sprite = blackScreen;
        SpriteRenderer wanderer = GameObject.Find("ship_outside").GetComponent<SpriteRenderer>();
        for(int i = 1; i < 7; i++)
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
                    screen.sprite = knowledgeCollage;
                    break;
                case 3:
                    screen.sprite = foodCollage;
                    break;
                case 4:
                    screen.sprite = friendsCollage;
                    break;
                case 5:
                    screen.color = new Color(1f, 1f, 1f, 0f);
                    break;
                case 6:
                    break;
            }
        }
        playNewScene = true;
    }

    //fades the screen to black at the end of the scene
    IEnumerator FadeToBlack()
    {
        Color c = fadeImage.color;
        for(int i = 0; i < 100; i++)
        {
            c.a = 0.01f * i;
            fadeImage.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5f);
        //should make the game quit if one is playing an executable (does not work in editor)
        Application.Quit();
    }

    //updates the screen
    //plays a new scene-part if available
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
