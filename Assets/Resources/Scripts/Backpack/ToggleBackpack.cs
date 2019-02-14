using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBackpack : MonoBehaviour
{
    public GameObject canvas;
 
    public void OnMouseDown()
    {
        Debug.Log("wewe");
        canvas.SetActive(!canvas.activeSelf);
    }


}
