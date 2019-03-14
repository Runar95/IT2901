using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.EventSystems;

//TODO: Fix inexplicable null error. Note, might be on unity's end, seen simmilar examples happen to others
public class CodeValidation : MonoBehaviour
{
	//CONSTANTS
	public const string CODE1_SOLUTION = "ar9y761m";
	public const string CODE2_SOLUTION = "pu44m3k9";

	public Flowchart flowchart;
	public GameObject Codepanel_Input;
	public InputField code_input;

	public static bool code1_solved = false;
	public static bool code2_solved = false;

	void Start() {
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		code_input.onEndEdit = se;
		code_input.ActivateInputField();
		code_input.Select();
	}

	private void SubmitName(string arg0)
    {
		EventSystem.current.SetSelectedGameObject(null);
		code_input.text = "";
		if (!flowchart.GetBooleanVariable("L_R")) {
			if (arg0.Equals(CODE1_SOLUTION)) {
				code1_solved = true;
				flowchart.ExecuteBlock("Feedback_Codepanel_Correct");
			} else {
				flowchart.ExecuteBlock("Feedback_Codepanel_Incorrect");
			}
		} else {
			if (arg0.Equals(CODE2_SOLUTION)) {
				code2_solved = true;
				flowchart.ExecuteBlock("Feedback_Codepanel_Correct");
			} else {
				flowchart.ExecuteBlock("Feedback_Codepanel_Incorrect");
			}
		}
      checkAnswer();
    }

	public void checkAnswer() {
		if (code1_solved && code2_solved) {
			Globals.setControlroomDoor(false);
			updateDoor();
		}
	}

	public void updateDoor() {
		flowchart.SetBooleanVariable("CtrlRoomLocked", Globals.getControlroomDoor(1));
		flowchart.ExecuteBlock("Update_Controlroom_Door");
	}
}
