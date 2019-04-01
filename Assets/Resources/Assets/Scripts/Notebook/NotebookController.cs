using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotebookController
{
   public static Dictionary<string, Notebook> NoteVisibility = new Dictionary<string, Notebook>();

    public static void ShowNote(string key, Notebook nb)
    {
        HideNotes();
        nb.SetActive(true);
        if (!(NoteVisibility.ContainsKey(key))) 
        {
            NoteVisibility[key] = nb;
        }
    }

    public static void HideNotes() {
        foreach (string key in NoteVisibility.Keys)
        {
            //Debug.Log(key);
            NoteVisibility[key].SetActive(false);
        }
    }
}

