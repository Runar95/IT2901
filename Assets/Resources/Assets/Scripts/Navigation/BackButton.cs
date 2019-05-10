using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BackButton : MonoBehaviour {

    public Sprite hoverSprite;
    public string fungusBlock;

    private Sprite normalSprite;
    private SpriteRenderer spriteRenderer;
    private Flowchart flowchart;

     // Start is called before the first frame update
    void Start() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        this.normalSprite = spriteRenderer.sprite;
    }

    void OnMouseEnter() {
        spriteRenderer.sprite = hoverSprite;
    }

    void OnMouseExit() {
        spriteRenderer.sprite = normalSprite;
    }

    void OnMouseUpAsButton() {
        flowchart.ExecuteBlock(fungusBlock);
    }


 }