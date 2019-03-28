using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NoteScript : MonoBehaviour {

    public DragSprite[] crayons;
    public Sprite hoverSprite;
    Flowchart flowchart;
    
    private Sprite origSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        origSprite = sr.sprite;

        foreach (DragSprite crayon in crayons) {
            crayon.isEnabled = false;
        }
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnMouseDown() {
        foreach (DragSprite crayon in crayons) {
            crayon.isEnabled = true;
        }
        flowchart.ExecuteBlock("NoteClicked");
    }

    void OnMouseEnter() {
        sr.sprite = hoverSprite;
    }

    void OnMouseExit() {
        sr.sprite = origSprite;
    }


}
