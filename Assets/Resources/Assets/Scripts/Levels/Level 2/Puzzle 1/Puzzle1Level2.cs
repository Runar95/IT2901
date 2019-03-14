﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class Puzzle1Level2 : MonoBehaviour
{
    private bool puzzleIsFinished = false;
    private SayingMatcher sm;
    private Dictionary<string, string> playerCombinations;
    private static string[] keys = { "norsk_metafor_1", "norsk_metafor_2", "norsk_metafor_3", "norsk_metafor_4" };
    private static string[] solutions = {"x_land_metafor_1", "x_land_metafor_2", "x_land_metafor_3", "x_land_metafor_4"};
    //only one key and value can be selected at a time
    private static ClickableSaying selectedKey = null;
    private static ClickableSaying selectedValue = null;

    //Dict of lines that might be drawn
    private static Dictionary<string, Line> lines = null;
    //colors for the lines to have
    private static Color[] colors = {Color.yellow, Color.red, Color.green, Color.black };
    private static int colorIndex = 0;

    //instance of level, to be used as reference
    private static Puzzle1Level2 instance = null;

    //variable that tells the update function to stop updating during teardown
    private bool teardown = false;

    //dialog component to be used for dialog
    private SayDialog sayDialog;
    private List<string> toSay = new List<string>();
    private bool isWriting = false;

    //struct representing a line in the scene
    public struct Line
    {
        public GameObject lineFrom;
        public GameObject lineTo;
        public GameObject lineObject;

        public Line(GameObject lf, GameObject lt, GameObject lo){
            lineFrom = lf;
            lineTo = lt;
            lineObject = lo;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //creates the SayingMatcher
        this.sm = new SayingMatcher(keys, solutions);
        //sets dictionary with player combinations
        this.playerCombinations = new Dictionary<string, string>();
        //initiate keys with empty values
        for (int i = 0; i < keys.Length; i++)
        {
            this.playerCombinations[keys[i]] = null;
        }

        //sets line to be drawn between objects
        lines = new Dictionary<string, Line>();
        for(int i = 0; i < keys.Length; i++)
        {
            //initiates lines, currently with no start or end points
            Line l = new Line(null, null, CreateLineObject());
            lines.Add(keys[i], l);
        }

        instance = this;

        //flowchart components for dialog
        this.gameObject.AddComponent<Flowchart>();
        sayDialog = SayDialog.GetSayDialog();
        sayDialog.SetActive(true);
        InvokeRepeating("SayNextString", 1f, 1f);
        PlayWelcomeMessage();
    }

    //plays the dialogs for the begining of the game
    private void PlayWelcomeMessage()
    {
        toSay.Add("Til venstre ser dere norske uttrykk");
        toSay.Add("Til høyre ser dere uttrykk på tigrinja");
        toSay.Add("Prøv å koble sammen uttrykk på begge sidene");
        toSay.Add("Sjekk svar ved å trykke på knappen kalt sjekk svar");
        SayNextString();

    }

    //function called after dialog boxes are called
    private void Done() {
        isWriting = false;
        //after the last dialog box one should returm to the plane
        if(puzzleIsFinished){
            PuzzleComplete pc = gameObject.GetComponent<PuzzleComplete>();
            pc.FinishLevel();
            TearDownScene();
            ReturnToPlane();
        }
    }

    private void SayNextString() {
        if (toSay.Count != 0 && !isWriting) {
            isWriting = true;
            string s = toSay[0];
            toSay.RemoveRange(0,1);
            sayDialog = SayDialog.GetSayDialog();
            sayDialog.SetActive(true);
            sayDialog.Say(s, true, true, true, true, false, null, Done);
        }
    }




    //creates a new object in the scene with a lineRenderer component, to be attached to Line structs
    public GameObject CreateLineObject()
    {
        GameObject gO = new GameObject();
        LineRenderer lr = gO.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.2f;

        lr.positionCount = 2;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(colors[colorIndex], 0.0f), new GradientColorKey(colors[colorIndex], 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        colorIndex++;
        lr.colorGradient = gradient;
        return gO;
    }

    //connects a key-value sayings pair
    void ConnectTwoSayings(string key, string value)
    {
        playerCombinations[key] = value;
    }

    //checks if all answers are correct
    public static void CheckCorrectAnswers()
    {
        int[] fraction = instance.sm.CheckCorrectAnswers(instance.playerCombinations);
        if (fraction[0] == fraction[1])
        {
            instance.toSay.Add("Gratulerer, dere klarte det!");
            instance.SayNextString();
            instance.puzzleIsFinished = true;
        }
        else
        {
            instance.toSay.Add("" + fraction[0] + " av " + fraction[1] + " fullført");
            instance.SayNextString();
        }
    }

    //destroys gameobjects not needed after scene, and resets static variables
    static void TearDownScene()
    {
        instance.teardown = true;
        foreach(string k in lines.Keys)
        {
            Line l = lines[k];
            GameObject go = l.lineObject;
            Destroy(go);
        }
        lines = null;
        selectedKey = null;
        selectedValue = null;
        colorIndex = 0;
        instance = null;
    }

    //disconnects key/value sayings pair
    void DisconnectTwoSayings(string key)
    {
        playerCombinations[key] = null;
    }

    //returns to the inside plane scene
    static void ReturnToPlane()
    {
        //set next level available
        SceneManager.LoadScene("Ship");
    }

    //function called when a saying is clicked
    public static void SetSelected(bool isKey, ClickableSaying cs)
    {
        //do nothing if cs allready selected
        if(selectedKey == cs){
            return;
        }else if (selectedValue == cs)
        {
            return;
        }

        //sets a given key saying
        if (isKey)
        {
            SetKeySaying(cs);
        }
        //sets a given value saying
        else
        {
            SetValueSaying(cs);
        }

        //if both a key and value is selcted, a line has been drawn
        //therefore, they are now unselected, so a new line can be drawn
        if(selectedValue != null && selectedKey != null)
        {
            selectedValue.ii.Activate();
            selectedKey.ii.Activate();
            instance.ConnectTwoSayings(selectedKey.saying, selectedValue.saying);
            selectedKey = null;
            selectedValue = null;
        }
    }



    //sets a key saying, called from SetSaying
    private static void SetKeySaying(ClickableSaying cs)
    {
        //gets the line connected to a saying
        Line l = lines[cs.saying];

        //if a clicked key saying is allready in a drawn line, it is now unselected for drawing
        if (l.lineTo != null && selectedValue == null)
        {
            cs.ii.Activate();
            l.lineTo.GetComponent<ClickableSaying>().ii.Activate();
            l.lineTo = null;
            lines[cs.saying] = l;
            selectedKey = null;
            selectedValue = null;
            instance.DisconnectTwoSayings(cs.saying);
            return;
        }
        //if a clicked key saying is allready in a drawn line, but a value saying is selected, a new line is made between the two
        else if (l.lineTo != null && selectedValue != null)
        {
            instance.DisconnectTwoSayings(cs.saying);
            instance.ConnectTwoSayings(cs.saying, selectedValue.saying);
            l.lineTo = selectedValue.go;
            lines[cs.saying] = l;
            selectedKey = null;
            selectedValue.ii.Activate();
            selectedValue = null;
            return;
        }

        //unselects the last chosen saying
        if (selectedKey != null)
        {
            selectedKey.UnselectSaying();
        }
        selectedKey = cs;
        //sets saying as From point in line
        l.lineFrom = cs.go;
        //sets the key saying to connect to the selected value saying
        if (selectedValue != null)
        {
            l.lineTo = selectedValue.go;
        }
        lines[cs.saying] = l;

        cs.ii.Deactivate();
    }

    //sets a value saying, called from SetSaying
    private static void SetValueSaying(ClickableSaying cs)
    {
        //iterates over lines to see if values saying is in a drawn line
        //if it is, that line will no longer be drawn
        Line checkLine;
        foreach (string k in lines.Keys)
        {
            checkLine = lines[k];
            if(checkLine.lineTo == null)
            {
                continue;
            }
            ClickableSaying valueSaying = checkLine.lineTo.GetComponent<ClickableSaying>();
            ClickableSaying keySaying = checkLine.lineFrom.GetComponent<ClickableSaying>();
            //if one selects a value saying that is allready connected
            if (valueSaying == cs && selectedKey == null)
            {
                keySaying.ii.Activate();
                cs.ii.Activate();
                checkLine.lineTo = null;
                lines[keySaying.saying] = checkLine;
                selectedKey = null;
                selectedValue = null;
                instance.DisconnectTwoSayings(keySaying.saying);
                return;
            }
            //if one selects a value saying that is connected, while having selected a new key, a new line is drawn between the two
            else if (valueSaying == cs && selectedKey != null)
            {
                keySaying.ii.Activate();
                instance.DisconnectTwoSayings(keySaying.saying);
                instance.ConnectTwoSayings(selectedKey.saying, cs.saying);
                checkLine.lineTo = null;
                lines[keySaying.saying] = checkLine;
                checkLine = lines[selectedKey.saying];
                checkLine.lineTo = cs.go;
                lines[selectedKey.saying] = checkLine;
                selectedKey.ii.Activate();
                selectedKey = null;
                selectedValue = null;
                return;
            }
        }

        //if another saying is selected, then it is unselected
        if (selectedValue != null)
        {
            selectedValue.UnselectSaying();
        }

        //if a key is selected, a line is formed
        if (selectedKey != null)
        {
            Line l = lines[selectedKey.saying];
            //sets sayig as lineto value
            l.lineTo = cs.go;
            lines[selectedKey.saying] = l;
        }
        selectedValue = cs;
        cs.ii.Deactivate();
    }

    //draws the lines on screen
    public void Update(){
        //makes sure one does not attempt to draw lines that are being deleted
        if (teardown)
        {
            return;
        }
        //iterates over lines, and draws the ones that are set
        foreach (string key in lines.Keys)
        {
            Line l = lines[key];
            LineRenderer lr = l.lineObject.GetComponent<LineRenderer>();
            if (l.lineFrom != null && l.lineTo != null){
                lr.SetPosition(0, l.lineFrom.transform.position);
                lr.SetPosition(1, l.lineTo.transform.position);
            }
            else
            {
                lr.SetPosition(0, new Vector3(Screen.width + 5, Screen.height + 5, 0));
                lr.SetPosition(1, new Vector3(Screen.width + 10, Screen.height + 10, 0));
            }
        }
    }

}
