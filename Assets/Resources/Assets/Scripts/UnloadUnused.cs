using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadUnused: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Screen.SetResolution(1920, 1080, false, 60);
	    Screen.fullScreen = true;
	    Application.targetFrameRate = 60;
        StartCoroutine(Unload());
    }

    IEnumerator Unload() {
        yield return new WaitForSeconds(3);
        Resources.UnloadUnusedAssets();
    }
}
