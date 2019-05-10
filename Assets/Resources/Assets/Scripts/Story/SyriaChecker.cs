using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SyriaChecker : MonoBehaviour
{
    private Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowchart.SetStringVariable("Location", Globals.getCurrentLevelString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
