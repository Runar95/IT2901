using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour{
    public DropZone inSlot;
    public bool isLocked;// Makes it possible to lock items in slot
    public BackpackVariables.Item itemType;
    private bool isPressed = false;
    private Vector3 origScale;
    private Vector3 snapPos = Vector3.zero;

    void Start(){
        origScale = gameObject.transform.localScale;
    }
    void Update(){
        if (isPressed)
        {
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }
    void OnMouseDown(){
        if(!this.isLocked && this.inSlot.type != DropZone.Type.drop){
            isPressed = true; 
        }
    }
    public void OnMouseUp(){
        isPressed = false;
        if (snapPos != Vector3.zero) {
            this.gameObject.transform.position = snapPos;
        }
    }
    public void OnMouseEnter() {
        gameObject.transform.localScale = origScale * 1.1f; // Scale on hover
    }
    public void OnMouseExit() {
        gameObject.transform.localScale = origScale;
    }
    public void SetSnapPos(Vector3 position) {
        snapPos = position;
    }
}