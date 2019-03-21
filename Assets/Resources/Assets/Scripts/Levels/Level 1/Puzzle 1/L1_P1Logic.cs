using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class L1_P1Logic : MonoBehaviour
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

    public void CheckLevelComplete()
    {
        if (cc.Count == 6)
        {
            // TODO: call fungus block, narrative dialog, return to level
            flowchart.ExecuteBlock("PuzzleFinish");
        }
        else if (pc.Count == 6)
        {
            flowchart.ExecuteBlock("PuzzleIncorrect");
        }
    }
}
