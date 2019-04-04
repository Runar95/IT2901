using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;
using UnityEngine.SceneManagement;

public class CatGuess : MonoBehaviour, IPointerClickHandler {
    public InputField inputField;
    public string correctNumber;
    private Flowchart flowchart;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData){
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left){
            if (inputField.text.Trim().ToLower() == correctNumber) {
                flowchart.ExecuteBlock("CorrectGuess");
            } else {
                // Show user they answered incorrectly
                flowchart.ExecuteBlock("IncorrectGuess");
            }

        }
    }
}
