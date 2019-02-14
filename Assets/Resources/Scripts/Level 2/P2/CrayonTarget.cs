using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonTarget : MonoBehaviour
{   

    public GameObject correctCrayon;
    public GameObject cam;

    private GameObject lastCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cryon enters target-collider
    void OnTriggerEnter2D(Collider2D collision) {
        lastCollider = collision.gameObject;
        if (lastCollider != null) {
            Vector3 pos = gameObject.transform.position;
            pos.z = -1;
            lastCollider.SendMessage("SetSnapPos", pos);
            lastCollider.SendMessage("SetLastTarget", gameObject.transform);

            // Show rect
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (collision.gameObject == correctCrayon) {
            cam.GetComponent<L2P2Logic>().cc.Add("" + correctCrayon.GetInstanceID());
        }
        cam.GetComponent<L2P2Logic>().pc.Add("" + correctCrayon.GetInstanceID());

    }

    void OnTriggerStay2D(Collider2D c) {
        lastCollider = c.gameObject;
        Vector3 pos = gameObject.transform.position;
        pos.z = -1;
        lastCollider.SendMessage("SetSnapPos", pos);
        lastCollider.SendMessage("SetLastTarget", gameObject.transform);
    }

    // Cryon exits target-collider
    void OnTriggerExit2D(Collider2D collision) {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        collision.gameObject.SendMessage("SetSnapPos", Vector3.zero);
        collision.gameObject.SendMessage("ResetLastTarget");

        lastCollider = null;

        if (collision.gameObject == correctCrayon) {
            cam.GetComponent<L2P2Logic>().cc.Remove("" + correctCrayon.GetInstanceID());
        }
        cam.GetComponent<L2P2Logic>().pc.Remove("" + correctCrayon.GetInstanceID());
    }
}
