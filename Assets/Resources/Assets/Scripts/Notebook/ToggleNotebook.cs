﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNotebook : MonoBehaviour
{
    public GameObject canvas;
    public void OnMouseDown()
    {
        Toggle();
    }
    public void Toggle()
    {
        NotebookController.HideNotes();
        canvas.SetActive(!canvas.activeSelf);
    }
}
