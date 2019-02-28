using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StoryScript : MonoBehaviour
{

    private SayDialog diag; 
    private bool isWriting = false;
    private List<string> toSay;


    // Start is called before the first frame update
    void Start()
    {
        // Setup dialog system and List
        toSay = new List<string>();
        diag = SayDialog.GetSayDialog();
        diag.SetActive(true);

        // Add strings
        AddSayString("Hei!");
        AddSayString("Velkommen! Bli med på tur!");
        AddSayString("Trykk på døren for å gå inn");

        InvokeRepeating("SayNextString", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSayString(string s) {
        toSay.Add(s);
    }

    private void Done() {
        isWriting = false;
    }

    private void SayNextString() {
        if (toSay.Count != 0 && !isWriting) {
            isWriting = true;
            string s = toSay[0];
            toSay.RemoveRange(0,1);
            diag = SayDialog.GetSayDialog();
            diag.SetActive(true);
            diag.Say(s, true, true, true, true, false, null, Done);
        }

    }

}
