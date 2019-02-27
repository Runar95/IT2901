using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class L2P2Logic : MonoBehaviour
{

    public HashSet<int> cc; // Correct crayon set
    public HashSet<int> pc; // Placed crayon set
    public Flowchart flowchart;

    public bool userIsNotified = false;

    // Start is called before the first frame update
    public void Start()
    {
        cc = new HashSet<int>();
        pc = new HashSet<int>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void CheckLevelComplete() {
        if (!userIsNotified) {
            if (IsLevelComplete()) {
                flowchart.ExecuteBlock("PuzzleFinish");
                userIsNotified = true;
            } else if (pc.Count == 5) {
                flowchart.ExecuteBlock("PuzzleIncorrect");
                userIsNotified = true;
            }
        }
    }

    public bool IsLevelComplete() {
        return cc.Count == 5;
    }

    public void AddPlacedCrayon(int hash) {
        pc.Add(hash);
    }

    public void AddCorrectCrayon(int hash) {
        cc.Add(hash);
    }

    public void RemovePlacedCrayon(int hash) {
        pc.Remove(hash);
    }

    public void RemoveCorrectCrayon(int hash) {
        cc.Remove(hash);
    }

}
