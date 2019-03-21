using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;
using UnityEngine.SceneManagement;

public class TravelCountryChecker : MonoBehaviour, IPointerClickHandler {
    public InputField inputField;
    public Animator FadeBlack;
    private Flowchart flowchart;

    public int incorrectGuesses = 0;

    void Start() {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData){
        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left){
            Debug.Log(name + " Game Object Left Clicked!");
            Debug.Log(inputField.text);

            if (inputField.text.Trim().ToLower() == Globals.getCurrentLevelString()) {
                // Show user they answered correctly (fungus block)
                // Travel to next location => travel scene (same fungus block)
                Globals.nextLevel();
                Globals.resetOpenDoors();

                flowchart.ExecuteBlock("CorrectCountry");
                // StartCoroutine(LoadScene("MapSceneAltP3")); 
                SceneManager.LoadScene("MapSceneAltP3", LoadSceneMode.Single);
            } else {
                // Show user they answered incorrectly
                flowchart.ExecuteBlock("IncorrectCountry");
                // Incr. incorrect counter
                incorrectGuesses++;
                // Show help if >3
                if (incorrectGuesses > 3) {
                    // Show BIG help (fungus block)
                } else {
                    // Show SMALL help (?) (fungus block)
                }

            }

        }
    }

    // Loads scene, shows traveling plane for 3 seconds first
    private IEnumerator LoadScene(string scene) {
        FadeBlack.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("PlaneTravelScene", LoadSceneMode.Additive);
        FadeBlack.Play("FadeIn");
        yield return new WaitForSeconds(4);
        FadeBlack.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
