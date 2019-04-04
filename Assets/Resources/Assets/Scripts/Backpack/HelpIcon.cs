using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HelpIcon : MonoBehaviour {

    Flowchart flowchart;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    void OnMouseDown() {
        // Provide help 
        flowchart.ExecuteBlock("Help");
    }

    
}
