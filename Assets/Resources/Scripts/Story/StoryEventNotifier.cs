using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventNotifier : MonoBehaviour {
    public void NewQuest(string s) {
        EventDrawer.DrawMessage(s);
    }

}
