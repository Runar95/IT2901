using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CallFungusBlockOnStart : MonoBehaviour {

    Flowchart flowchart;

    public string blockName;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowchart.ExecuteBlock(blockName);
    }

}

