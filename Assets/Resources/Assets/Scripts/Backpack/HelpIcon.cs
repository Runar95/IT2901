using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HelpIcon : MonoBehaviour {

    Flowchart flowchart;

    private bool clickedHelp = false;
    private Animator animator;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(Animate());
    }

    void OnMouseDown() {
        clickedHelp = true;
        // Provide help 
        flowchart.ExecuteBlock("Help");
    }

    IEnumerator Animate() {
        yield return new WaitForSeconds(15); // Wait time before first animation
        while (!clickedHelp) {
            animator.Play("HelpIconAnimation");
            yield return new WaitForSeconds(15); 
        }
    }
    
}
