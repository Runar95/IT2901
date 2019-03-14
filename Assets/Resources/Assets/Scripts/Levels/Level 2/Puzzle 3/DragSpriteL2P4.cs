using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSpriteL2P4 : MonoBehaviour
{

    public GameObject cam;

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
        isPressed = true;
        if (lastTarget != null)
        {
            lastTarget.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnMouseUp()
    {
        isPressed = false;
        if (snapPos != Vector3.zero) {
            this.gameObject.transform.position = snapPos;
        }
        if (lastTarget != null)
        {
            lastTarget.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        // TODO: check if puzzle is finished
        cam.GetComponent<L2_P4Logic>().CheckLevelComplete();
    }

    public void OnMouseOver() {
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

    public void SetLastTarget(Transform g)
    {
        lastTarget = g;
    }

    public void ResetLastTarget()
    {
        lastTarget = null;
    }

}
