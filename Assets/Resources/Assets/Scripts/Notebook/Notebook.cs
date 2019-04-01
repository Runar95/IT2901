using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Notebook : ScriptableObject
{
    private GameObject canvasGO;
    private Text text;
 
    //The NotesText dictionary stores all the notebook text under the appropriate key. L is shorthand for level. P is shorthand for puzzle
    private static Dictionary<string, string> NotesText = new Dictionary<string, string>
        {  
            { "ShipL1",     "Jeg våknet opp i et rom, til min store forundrelse husker jeg ingenting fra i går. Like etter at jeg våknet, møtte jeg Reza og Hani. Sammen prøver vi å finne ut av hva vi skal gjøre videre..." },
            { "L1P1",       "Landet vi er i, har fjorder og fjell. De bruker også noen ganger en rar måte å telle på, men jeg tror det er ganske gammeldags." },
            { "L1P2",       "En ting er sikkert: De spiser mye merkelig mat i dette landet! Hvem skulle tro at noen ville spise et sauehode?" },
            { "L1P3",       "Nå har jeg notert ned ordtakene! \"Ikke selg skinnet før du har skutt bjørnen.\", \"Snakker du om sola, så skinner den.\"" },
            { "ShipL2",     "Etter at vi fullførte alle oppgavene i Norge, reiste vi videre, det første vi la merke til var at det var veldig varmt her..." },
            { "L2P1",       "Da vet vi at innbyggerne i dette landet bruker disse metaforene: \"ብ ሓንቲ ወንጭፍ ክልተ ዑፍ\", \"ኣብ ኣፋን ዕርበታን\", \"ጻዕዳ ሓሶት\" og \"ድራር ዓይነይ\" . Kanskje det kan gi noen hint om hvilket område vi befinner oss i også?" },
            { "L2P2",       "Vi er i et område der det er ørkenlandskap, og der de skriver med en annen type bokstaver. Og de har nydelige lavendelblomster og sommerfulger!" },
            { "L2P3",       "I dette landet spiser de Injera, tshebi, Kitcha fit-fit, Ga'at og Hamli. Jeg blir sulten bare av å tenke på det." },
            { "ShipL3",     "Når vi fullførte utfordingene i Eritra, reiste vi nok en gang til et nytt sted." },
            { "L3P1",       "Det store maleriet på veggen kunne kanskje gi noen hint om hvor vi er? Sooker, moskeer, sandfargede hus…" },
            { "L3P2",       "Landet vi er i, bruker et annet skriftspråk enn det latinske. Er det arabisk, kanskje?" },
            { "L3P3",       "En ting er sikkert: Landet vi er i, er gode på mat! Aubergine, kikerter, lammekjøtt… men svinekjøtt så jeg ikke der. Jeg tipper de har gode søtsaker også!" }
        };
    
    //UnlockedNotes tracks which notes should be available to the player. 0 - locked, 1 - unlocked and current level, 2 - unlocked, but previous level
    private static Dictionary<string, int> UnlockedNotes =new Dictionary<string, int> 
        {
            {"ShipL1",  0}, 
            {"L1P1",    0},
            {"L1P2",    0},
            {"L1P3",    0},
            {"ShipL2",  0}, 
            {"L2P1",    0},
            {"L2P2",    0},
            {"L2P3",    0},  
            {"ShipL3",  0}, 
            {"L3P1",    0},
            {"L3P2",    0},
            {"L3P3",    0} 
        };

        void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.fontSize = 28;
        text.alignment = TextAnchor.UpperLeft;
        text.color = Color.black;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(260, -300, 0);
        rectTransform.sizeDelta = new Vector2(380, 600);
    }

    public void SetAccess(int access, params string[] notes) 
    {
        foreach (var note in notes)
        {
            UnlockedNotes[note] = access;
        }
    }

    public void SetText(string key) 
    {
        text.text = NotesText[key];
    } 

    public void SetActive(bool active) 
    {
        canvasGO.SetActive(active);
    }
}
