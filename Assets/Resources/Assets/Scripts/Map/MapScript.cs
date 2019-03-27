using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class MapScript : MonoBehaviour
{
    public Sprite L1_TravelSprite;
    public Sprite L1_NoTravelSprite;
    public Sprite L2_TravelSprite;
    public Sprite L2_NoTravelSprite;

    public Animator FadeBlack;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.nextLevelAvailable) {
            gameObject.GetComponent<Clickable2D>().ClickEnabled = true;
            if (Globals.level == 1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = L1_TravelSprite;
            } else if (Globals.level == 2) {
                gameObject.GetComponent<SpriteRenderer>().sprite = L2_TravelSprite;
            }
        } else {
            gameObject.GetComponent<Clickable2D>().ClickEnabled = false;
            if (Globals.level == 1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = L1_NoTravelSprite;
            } else if (Globals.level == 2) {
                gameObject.GetComponent<SpriteRenderer>().sprite = L2_NoTravelSprite;
            }
        }

    }

    public void OnMouseDown() {
        Debug.Log("Map Next Destination Clicked");
        if (Globals.nextLevelAvailable) {
            // Globals.nextLevel();
            // Globals.resetOpenDoors();

            // StartCoroutine(LoadScene("Ship"));
            // StartCoroutine(LoadScene("MapSceneAltP2"));
            SceneManager.LoadScene("MapSceneAltP2", LoadSceneMode.Single);
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
