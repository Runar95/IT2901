using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBackpack : MonoBehaviour
{
    public GameObject canvas;
 
    public void OnMouseDown()
    {
        canvas.SetActive(!canvas.activeSelf);
    }


}
