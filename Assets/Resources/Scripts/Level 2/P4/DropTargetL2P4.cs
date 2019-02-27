using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTargetL2P4 : MonoBehaviour
{

    private GameObject lastCollider;
    public GameObject correctValue;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision) {
        lastCollider = collision.gameObject;
        if (lastCollider != null) {

            // Snap value to target
            Vector3 pos = gameObject.transform.position;
            pos.z = -1;
            lastCollider.SendMessage("SetSnapPos", pos);
            lastCollider.SendMessage("SetLastTarget", gameObject.transform);

            // Show rect
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

            if (collision.gameObject == correctValue)
            {
                cam.GetComponent<L2_P4Logic>().cc.Add("" + correctValue.GetInstanceID());
            }
            cam.GetComponent<L2_P4Logic>().pc.Add("" + collision.GetInstanceID());
            // cam.GetComponent<L2_P4Logic>().CheckLevelComplete();

        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        lastCollider = c.gameObject;
        Vector3 pos = gameObject.transform.position;
        pos.z = -1;
        lastCollider.SendMessage("SetSnapPos", pos);
        lastCollider.SendMessage("SetLastTarget", gameObject.transform);
    }

    void OnTriggerExit2D(Collider2D collision) {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        collision.gameObject.SendMessage("SetSnapPos", Vector3.zero);
        collision.gameObject.SendMessage("ResetLastTarget");

        lastCollider = null;

        if (collision.gameObject == correctValue)
        {
            cam.GetComponent<L2_P4Logic>().cc.Remove("" + correctValue.GetInstanceID());
        }
        cam.GetComponent<L2_P4Logic>().pc.Remove("" + collision.GetInstanceID());
    }
}
