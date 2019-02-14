using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlaneDoor : MonoBehaviour
{

    public Sprite doorHoverSprite;
    public Sprite doorOpenSprite;

    public Flowchart flowchart;

    public bool doorOpen = false;
    public bool doorActive = false;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        if (!doorOpen && doorActive) {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = doorHoverSprite;
        }
    }

    void OnMouseExit() {
        if (!doorOpen && doorActive) {
            spriteRenderer.enabled = false;
        }
    }

    void OnMouseUpAsButton() {
        if (!doorOpen && doorActive) {
            doorOpen = true;
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = doorOpenSprite;
            flowchart.ExecuteBlock("DoorClicked");
        }
    }

    private IEnumerator Sleep(float secs) {
        yield return new WaitForSeconds(secs);
    }

    public void SetDoorInteractionActive() {
        this.doorActive = true;
    }
}
