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

    void Start()
    {
        if (Globals.level == 1) {
            //Debug.Log("Level 1");
            controlroomWindow.sprite = lvl1Window;
        } else if (Globals.level == 2) {
            //Debug.Log("Level 2");
            controlroomWindow.sprite = lvl2Window;
        } else if (Globals.level == 3) {
            //Debug.Log("Level 3");
            controlroomWindow.sprite = lvl3Window;
        }

        screenNewDest.SetActive(Globals.nextLevelAvailable);

    }

    public void goToLastCamPos() {
        gameObject.transform.position = Globals.lastCamPos;
        Globals.lastCamPos = defaultView.transform.position;
    }

    public void saveLastCamPos() {
        Globals.lastCamPos = gameObject.transform.position;
    }
}
