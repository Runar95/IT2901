using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TravelScript : MonoBehaviour
{

    public GameObject screenNewDest;

    public View defaultView;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.level == 1) {
            // First level
            Debug.Log("Level 1");
        } else if (Globals.level == 2) {
            // Second level
            Debug.Log("Level 2");
        }

        screenNewDest.SetActive(Globals.nextLevelAvailable);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToLastCamPos() {
        gameObject.transform.position = Globals.lastCamPos;
        Globals.lastCamPos = defaultView.transform.position;
    }

    public void saveLastCamPos() {
        Globals.lastCamPos = gameObject.transform.position;
    }
}
