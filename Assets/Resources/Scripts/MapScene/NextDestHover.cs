using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDestHover : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        // Show hower sprite when mouse enters collider and the next level is available
        if (Globals.nextLevelAvailable) {
            spriteRenderer.enabled = true;
        }
    }

    void OnMouseExit() {
        spriteRenderer.enabled = false;
    }
}
