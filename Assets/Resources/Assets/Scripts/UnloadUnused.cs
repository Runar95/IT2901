using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadUnused: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false, 60);
        StartCoroutine(Unload());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Unload() {
        yield return new WaitForSeconds(3);
        Resources.UnloadUnusedAssets();
    }
}
