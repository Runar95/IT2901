using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueLock : MonoBehaviour
{
	public Flowchart flowchart;

	public bool getDialogue() {
		return flowchart.GetBooleanVariable("dialogueLocked");
	}
}
