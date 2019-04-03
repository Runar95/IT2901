using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarianScriptP1L2 : MonoBehaviour
{
    void OnMouseDown()
    {
        if(P1L2Story.act != 1)
        {
            return;
        }
        P1L2Story.playNextAct = true;
    }
}
