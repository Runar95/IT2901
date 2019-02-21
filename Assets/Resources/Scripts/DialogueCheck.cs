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
 
	//	Checks if there is an active dialogue element, creating a new boolean variable in a Scene named inDialogue is neccesary if you want to reuse the script. 
	//  You also need to call the method after a say element in a block
    public void inDialogue() {
		var sayDialog = Fungus.SayDialog.GetSayDialog(); 
		dialogue = sayDialog.isActiveAndEnabled || EventSystem.current.IsPointerOverGameObject();
    	flowchart.SetBooleanVariable("inDialogue", dialogue);
    }
    
}
