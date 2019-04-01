using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{    
    private Notebook nb;
    
    void Awake() 
    {
        var notebook = (Notebook) ScriptableObject.CreateInstance("Notebook");
        nb = notebook;
    }

    public void OnMouseDown() {
        nb.SetText(gameObject.name);
        NotebookController.ShowNote(gameObject.name, nb);
        nb.SetAccess(1, gameObject.name);
    }
}
