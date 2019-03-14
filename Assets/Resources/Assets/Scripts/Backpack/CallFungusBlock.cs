using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CallFungusBlock : MonoBehaviour {

    Flowchart flowchart;


    public string blockName;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

    }

    void OnMouseDown() {
        flowchart.ExecuteBlock(blockName);
    }
    
}

