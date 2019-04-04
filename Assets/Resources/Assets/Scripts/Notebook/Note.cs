using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{    
    public Text text;
    
    void Start() 
    {
        text.GetComponent<Text>();
        if (NotebookController.GetAccess(gameObject.name) == 1)
        {
            gameObject.SetActive(true);
        } else 
        {
            gameObject.SetActive(false);
        }
    }

    public void OnMouseDown() {
        text.text = NotebookController.GetNote(gameObject.name);

    }
}
