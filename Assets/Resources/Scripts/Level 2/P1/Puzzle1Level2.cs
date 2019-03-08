using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Level2 : MonoBehaviour
{
    private SayingMatcher sm;
    private Dictionary<string, string> playerCombinations;
    private static string[] keys = { "norsk_metafor_1", "norsk_metafor_2", "norsk_metafor_3", "norsk_metafor_4" };
    private static string[] solutions = {"x_land_metafor_1", "x_land_metafor_2", "x_land_metafor_3", "x_land_metafor_4"};
    //only one key and value can be selected at a time
    private static ClickableSaying selectedKey = null;
    private static ClickableSaying selectedValue = null;

    //list of lines that might be drawn
    public static Dictionary<string, Line> lines;

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
            Line l = new Line(null, null, null);
            lines.Add(keys[i], l);
        }
        SetUpLine();
    }

    public void SetUpLine()
    {
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.widthMultiplier = 0.2f;

        lr.positionCount = 100;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lr.colorGradient = gradient;
    }

    void ConnectTwoSayings(string key, string value)
    {
        playerCombinations[key] = value;
    }

    public static void SetSelected(bool isKey, ClickableSaying cs)
    {
        //do nothing if cs allready selected
        if(selectedKey == cs || selectedValue == cs){
            return;
        }

        //gets relevant line
        Line l = new Line(null, null, null);

        //sets a given key
        if (isKey)
        {
            l = lines[cs.saying];
            if (selectedKey != null)
            {
                selectedKey.UnselectSaying();
            }
            selectedKey = cs;
            //sets saying as From point in line
            l.lineFrom = cs.go;
            if(selectedValue != null){
                  l.lineTo = selectedValue.go;
            }
            lines[selectedKey.saying] = l;
        }
        //sets a given value
        else
        {
            if (selectedValue != null)
            {
                selectedValue.UnselectSaying();
            }
            if(selectedKey != null)
            {
                l = lines[selectedKey.saying];
                //sets sayig as lineto value
                l.lineTo = cs.go;
                lines[selectedKey.saying] = l;
            }
            selectedValue = cs;
        }
        //deactivates the clickable sayings interactable component
        cs.ii.Deactivate();
        if(selectedKey != null){
          l = lines[selectedKey.saying];
          string debugString = "";
          debugString += "From: " + l.lineFrom.GetComponent<ClickableSaying>().saying + "\n";
          if(selectedValue){
            debugString += "To: " + l.lineTo.GetComponent<ClickableSaying>().saying;
          }
          Debug.Log(debugString);
        }
    }

    public void Update(){
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;
        for (int i = 0; i < 100; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        }
    }



    //finsih this later, look at examples

    //draws the lines on screen
    public void UpdateNot(){
      //iterates over lines
      foreach(string key in lines.Keys)
      {
          Line l = lines[key]
          if(selectedKey != null && selectedValue != null){
              lr = l.lineObject.GetComponent<LineRenderer>();
              lr.SetPosition(0, );
              lr.SetPosition();
          }
      }
   }

}
