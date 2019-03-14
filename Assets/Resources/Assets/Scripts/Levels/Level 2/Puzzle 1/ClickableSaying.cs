using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSaying : MonoBehaviour
{
    //clickable sayings are either keys (true) or values (false)
    public bool isKey;
    //saying connected to this object
    public string saying;
    private bool isSelected = false;
    //so that one can change the scale of the gameobject
    public InteractableIndicator ii;
    //gameobject the cs is connected to
    public GameObject go;

    public void Start(){
        this.ii.scale = 1.1f;
        this.go = this.gameObject;
    }

    public void OnMouseDown()
    {
        Puzzle1Level2.SetSelected(isKey, this);
    }

    public void UnselectSaying()
    {
        this.isSelected = false;
        //sets the InteractableIndicator to active
        this.ii.Activate();
    }
}
