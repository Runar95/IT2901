using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHoverDisablable : MonoBehaviour
{

    public float scaleMultiplier = 0.1f;
    public bool isActive;
    public GameObject objectToScale;
    private Vector3 origScale;

    void Start()
    {
        origScale = objectToScale.transform.localScale;
    }

    public void OnMouseEnter() {
        if(isActive){
            ScaleUp();
        }
    }

    public void OnMouseExit() {
        ScaleNormal();
    }

    private void ScaleUp() {
        objectToScale.transform.localScale = origScale * (1 + scaleMultiplier); // Scale on hover
    }

    private void ScaleNormal() {
        objectToScale.transform.localScale = origScale;
    }
    public void SetActive(){
        this.isActive =  true;
    }
    public void SetInactive(){
        this.isActive = false;
        ScaleNormal(); 
    }
}

