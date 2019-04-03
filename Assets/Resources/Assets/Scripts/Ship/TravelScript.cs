using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TravelScript : MonoBehaviour
{
    public GameObject screenNewDest;

    public View defaultView;

    public SpriteRenderer controlroomWindow;

    public Sprite lvl1Window;
    public Sprite lvl2Window;
    public Sprite lvl3Window;

    public SpriteChanger mainHall1;
    public SpriteChanger mainHall2;
    public SpriteChanger mainHall3;
    public SpriteChanger mainHall4;

    void Start()
    {
        if (Globals.level == 1) {
            //Debug.Log("Level 1");
            controlroomWindow.sprite = lvl1Window;
            mainHall1.ChangeSpriteTo(0);
            mainHall2.ChangeSpriteTo(0);
            mainHall3.ChangeSpriteTo(0);
            mainHall4.ChangeSpriteTo(0);
        } else if (Globals.level == 2) {
            //Debug.Log("Level 2");
            controlroomWindow.sprite = lvl2Window;
            mainHall1.ChangeSpriteTo(1);
            mainHall2.ChangeSpriteTo(1);
            mainHall3.ChangeSpriteTo(1);
            mainHall4.ChangeSpriteTo(1);
        } else if (Globals.level == 3) {
            //Debug.Log("Level 3");
            controlroomWindow.sprite = lvl3Window;
            mainHall1.ChangeSpriteTo(2);
            mainHall2.ChangeSpriteTo(2);
            mainHall3.ChangeSpriteTo(2);
            mainHall4.ChangeSpriteTo(2);
        }

        screenNewDest.SetActive(Globals.nextLevelAvailable);

        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowchart.SetBooleanVariable("LevelComplete", Globals.nextLevelAvailable);

    }

    public void goToLastCamPos() {
        gameObject.transform.position = Globals.lastCamPos;
        Globals.lastCamPos = defaultView.transform.position;
    }

    public void saveLastCamPos() {
        Globals.lastCamPos = gameObject.transform.position;
    }

}
