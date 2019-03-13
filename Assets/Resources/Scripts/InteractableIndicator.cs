using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script must be combined with a box collider

  when used as combonent, the object using it will scale in size when the mouse
  hovers over it. It will revert to normal size afterwards.
 */

public class InteractableIndicator : MonoBehaviour
{
    //amount to scale objects with when hovering over them
    //10% by default
    public float scale = 1.1f;

    //scale object has originaly -> before initial hover
    private Vector3 originalScale;

    //variable saying if the InteractableIndicator is deactivated or not
    private bool activated;

    public void Start()
    {
        this.originalScale = transform.localScale;
        this.activated = true;
    }

    public void OnMouseEnter()
    {
        if(!activated){
          return;
        }
        //creates scalar to use on scale
        Vector3 scalar = new Vector3(scale, scale, 1.0f);
        transform.localScale = Vector3.Scale(originalScale, scalar);
    }

    public void OnMouseExit()
    {
        if(!activated){
          return;
        }
        //simply sets scale to original scale
        transform.localScale = originalScale;
    }

    public void Activate(){
        this.activated = true;
        this.OnMouseExit();
    }

    public void Deactivate(){
        this.activated = false;
    }
}
