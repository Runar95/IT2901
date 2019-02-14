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

    public void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnMouseEnter()
    {
        //creates scalar to use on scale
        Vector3 scalar = new Vector3(scale, scale, 1.0f);
        transform.localScale = Vector3.Scale(originalScale, scalar);
    }

    public void OnMouseExit()
    {
        //simply sets scale to original scale
        transform.localScale = originalScale;
    }
}
