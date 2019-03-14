using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class OnSceneLoad : MonoBehaviour
{
	public Flowchart flowchart;
	void Start()
    {
		//Commented out for the purpose of testing
		//flowchart.SetBooleanVariable("CtrlRoomLocked", Globals.getControlroomDoor(1));
		//flowchart.ExecuteBlock("Update_Controlroom_Door");
    }
}
