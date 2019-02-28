using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Level2 : MonoBehaviour
{
    private SayingMatcher sm;
    private Dictionary<string, string> playerCombinations;

    // Start is called before the first frame update
    void Start()
    {
        sm = new SayingMatcher(null, null);
        playerCombinations = new Dictionary<string, string>();
    }

    void ConnectTwoSayings(string key, string value)
    {
        playerCombinations[key] = value;
    }
    

}
