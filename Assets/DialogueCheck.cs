using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class DialogueCheck : MonoBehaviour
{
	//Check canvas to fix bug where you can click through a dialogue box when the text is not done
	public Flowchart flowchart;
	public bool dialogue;
 
	//	Checks if there is a UI element above a button, creating a new boolean variable in a Scene named inDialogue is neccesary if you want to reuse the script. 
    public void inDialogue() {
		var sayDialog = Fungus.SayDialog.GetSayDialog(); 
		dialogue = sayDialog.isActiveAndEnabled;
    	//dialogue = Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject();
    	Debug.Log(dialogue);
    	flowchart.SetBooleanVariable("inDialogue", dialogue);
    }
    
}
