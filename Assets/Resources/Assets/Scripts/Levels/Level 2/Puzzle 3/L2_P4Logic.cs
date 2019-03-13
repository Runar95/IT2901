using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class L2_P4Logic : MonoBehaviour
{

    public HashSet<string> cc;
    public HashSet<string> pc;
    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        cc = new HashSet<string>();
        pc = new HashSet<string>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void CheckLevelComplete()
    {
        //Debug.Log(cc.Count);

        if (cc.Count == 5)
        {
            // TODO: call fungus block, narrative dialog, return to level
            flowchart.ExecuteBlock("PuzzleFinish");
        }
        else if (pc.Count == 5)
        {
            flowchart.ExecuteBlock("PuzzleIncorrect");
        }
        flowchart.SetIntegerVariable("placedIncorrect", pc.Count-cc.Count);
    }
}
