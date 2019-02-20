using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class L1_P2Logic : MonoBehaviour
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
        Debug.Log(cc.Count);
        Debug.Log(pc.Count);

        if (cc.Count == 7)
        {
            // TODO: call fungus block, narrative dialog, return to level
            flowchart.ExecuteBlock("PuzzleFinish");
        }
        else if (pc.Count == 7)
        {
            flowchart.ExecuteBlock("PuzzleIncorrect");
        }
    }
}
