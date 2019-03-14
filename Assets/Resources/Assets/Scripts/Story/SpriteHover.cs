using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHover : MonoBehaviour
{

    public float scaleMultiplier = 0.1f;

    private Vector3 origScale;

    void Start()
    {
        origScale = gameObject.transform.localScale;
    }

    public void OnMouseEnter() {
        ScaleUp();
    }

    public void OnMouseExit() {
        ScaleNormal();
    }

    private void ScaleUp() {
        gameObject.transform.localScale = origScale * (1 + scaleMultiplier); // Scale on hover
    }

    private void ScaleNormal() {
        gameObject.transform.localScale = origScale;
    }
}
