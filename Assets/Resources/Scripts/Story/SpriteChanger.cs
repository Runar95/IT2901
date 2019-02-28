using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    public Sprite[] sprites;

    SpriteRenderer sr;

    void Start() {
        sr = gameObject.GetComponent<SpriteRenderer>();
        
    }

    public void ChangeSpriteTo(int spriteNum) {
        if (spriteNum < sprites.Length) {
            sr.sprite = sprites[spriteNum];
        }
    }


}
