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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        Debug.Log("Map Next Destination Clicked");
        if (Globals.nextLevelAvailable) {
            Globals.nextLevel();
            Globals.resetOpenDoors();
            // TODO: Update map, animation
            // Temp fix: load main scene
            SceneManager.LoadScene("MyStartScene", LoadSceneMode.Single);
        }

    }
}
