using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable2 : MonoBehaviour
{
    public string inSlot;
    public bool isLocked;
    public BackpackVariables.Item type;
    private bool isPressed = false;
    private Vector3 origScale;
    private Vector3 snapPos = Vector3.zero;
    private Transform lastTarget;

    // Start is called before the first frame update
    void Start()
    {
        origScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Pressed();
    }

    void OnMouseDown()
    {
        if(!this.isLocked){
            BackpackVariables.items[inSlot] = BackpackVariables.Item.Empty;
            Debug.Log("Mouse down");
            isPressed = true; 
        }
    }

    public void OnMouseUp()
    {
        Debug.Log("Mouse up");
        isPressed = false;
        BackpackVariables.items[this.inSlot] = this.type;
        if (snapPos != Vector3.zero) {
            this.gameObject.transform.position = snapPos;
        }
    }

    public void OnMouseEnter() {
        Debug.Log("Mouse over");
        scaleUp();
    }

    public void OnMouseExit() {
        scaleNormal();
    }

    void Pressed()
    {
        if (isPressed)
        {
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }

    private void scaleUp() {
        gameObject.transform.localScale = origScale * 1.1f; // Scale on hover
    }

    private void scaleNormal() {
        gameObject.transform.localScale = origScale;
    }

    public void SetSnapPos(Vector3 position) {
        snapPos = position;
    }

    public void SetLastTarget(Transform transform) {
        lastTarget = transform;
    }

    public void ResetLastTarget() {
        lastTarget = null;
    }

}
