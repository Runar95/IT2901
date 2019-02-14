using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFadeScript : MonoBehaviour {


    private Animator FadeBlack;

    // Start is called before the first frame update
    void Start()
    {
        FadeBlack = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadScene(string scene) {
        FadeBlack.Play("FadeOut");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private IEnumerator FadeOutCoroutine() {
        FadeBlack.Play("FadeOut");
        yield return new WaitForSeconds(1.3f);
    }

    public void FadeOut() {
        StartCoroutine(FadeOutCoroutine());
    }

}
