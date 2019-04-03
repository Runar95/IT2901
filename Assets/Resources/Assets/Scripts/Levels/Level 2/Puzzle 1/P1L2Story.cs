using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class P1L2Story : MonoBehaviour
{
    public static bool playNextAct = false;
    public static int act = 0;
    private Flowchart flowchart;
    private SpriteRenderer star;

    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        playNextAct = true;
        star = GameObject.Find("star").GetComponent<SpriteRenderer>();
        //makes the star see-through
        star.color = new Color(1f, 1f, 1f, 0f);
    }

    void playNext()
    {
        switch(act)
        {
            case 1:
                StartCoroutine("PlayStartDialog");
                break;
            case 2:
                StartCoroutine("PlayStartPuzzleDialog");
                break;
            case 3:
                StartCoroutine("PlayFinalDialog");
                break;
        }
    }

    IEnumerator PlayStartDialog()
    {
        flowchart.ExecuteBlock("StartDialog");
        while(flowchart.HasExecutingBlocks())
        {
            yield return new WaitForSeconds(0.3f);
        }
        yield return null;
    }

    IEnumerator PlayStartPuzzleDialog()
    {
        flowchart.ExecuteBlock("StartPuzzleDialog");
        while(flowchart.HasExecutingBlocks())
        {
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("L2_P1_puzzle");
    }

    IEnumerator PlayFinalDialog()
    {
        Color c;
        for(int i = 0; i < 50; i++)
        {
            c = new Color(1f, 1f, 1f, 0.01f * (2*i));
            star.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        flowchart.ExecuteBlock("FinalDialog");
        while(flowchart.HasExecutingBlocks())
        {
            yield return new WaitForSeconds(0.3f);
        }
        //reset static variables
        playNextAct = true;
        act = 0;
        SceneManager.LoadScene("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        if(playNextAct)
        {
            playNextAct = false;
            act++;
            playNext();
        }
    }
}
