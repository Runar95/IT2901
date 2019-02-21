using UnityEngine; using System; 
using System.Collections; 
using System.Collections.Generic;

public class WordSearch : MonoBehaviour {
    public int gridX, gridY;
    public float spacing;
    public GameObject tile, background, current;             
    public Color defaultTint, mouseoverTint, identifiedTint;
    public bool ready = false, correct = false;
    public string selectedString = "";
    public List<GameObject> selected = new List<GameObject>();
    private List<GameObject> tiles = new List<GameObject>();
    private GameObject temporary, backgroundObject;
    private int identified = 0;
    private string[,] matrix;
    private Dictionary<string, bool> word = new Dictionary<string, bool>();
    private Dictionary<string, bool> insertedWords = new Dictionary<string, bool>();
    private string[] letters = new string[26]
	{"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
    private Ray ray;
    private RaycastHit hit;

    private static WordSearch instance;
    public static WordSearch Instance {
        get {
			return instance;
		}
    }

	void Awake() {
        instance = this;
    }

    void Start() {
        matrix = new string[gridX, gridY];
        InstantiateBackground();

        for (int i = 0; i < gridX; i++) {
            for (int j = 0; j < gridY; j++) {
                temporary = Instantiate(tile, new Vector3(i * 1 * tile.transform.localScale.x * spacing, 10, j * 1 * tile.transform.localScale.z * spacing), Quaternion.identity) as GameObject;
                temporary.name = "tile-" + i.ToString() + "-" + j.ToString();
                temporary.transform.eulerAngles = new Vector3(180, 0, 0);
                temporary.transform.parent = backgroundObject.transform;
                BoxCollider boxCollider = temporary.GetComponent<BoxCollider>() as BoxCollider;
                temporary.GetComponent<Letters>().letter.text = "";
                temporary.GetComponent<Letters>().gridX = i;
                temporary.GetComponent<Letters>().gridY = j;
                tiles.Add(tile);
                matrix[i, j] = "";
            }
        }
        CenterBackground();
        FillTiles();
    }
    private void CenterBackground() {
        backgroundObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, (Screen.height / 2) + 50, 200));
	}

    private void InstantiateBackground() {
			backgroundObject = Instantiate (background, new Vector3 ((tile.transform.localScale.x * spacing)
			* (gridX / 2), 1, (tile.transform.localScale.z * spacing)
			* (gridY / 2) - (tile.transform.localScale.z * spacing)), Quaternion.identity) as GameObject;
   }

    private void FillTiles() {

        //row 9
        GameObject.Find("tile-0-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-1-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-8").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-8").GetComponent<Letters>().letter.text = letters[10];

        //row 8
        GameObject.Find("tile-0-7").GetComponent<Letters>().letter.text = letters[20];
        GameObject.Find("tile-1-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-7").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-7").GetComponent<Letters>().letter.text = letters[14];
        GameObject.Find("tile-8-7").GetComponent<Letters>().letter.text = letters[2];

        //row 7
        GameObject.Find("tile-0-6").GetComponent<Letters>().letter.text = letters[3];
        GameObject.Find("tile-1-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-6").GetComponent<Letters>().letter.text = letters[1];
        GameObject.Find("tile-7-6").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-6").GetComponent<Letters>().letter.text = letters[2];

        //row 6
        GameObject.Find("tile-0-5").GetComponent<Letters>().letter.text = letters[13];
        GameObject.Find("tile-1-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-5").GetComponent<Letters>().letter.text = letters[3];
        GameObject.Find("tile-6-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-5").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-5").GetComponent<Letters>().letter.text = letters[2];

        //row 5
        GameObject.Find("tile-0-4").GetComponent<Letters>().letter.text = letters[8];
        GameObject.Find("tile-1-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-4").GetComponent<Letters>().letter.text = letters[17];
        GameObject.Find("tile-5-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-4").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-4").GetComponent<Letters>().letter.text = letters[2];

        //row 4
        GameObject.Find("tile-0-3").GetComponent<Letters>().letter.text = letters[21];
        GameObject.Find("tile-1-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-3").GetComponent<Letters>().letter.text = letters[14];
        GameObject.Find("tile-4-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-3").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-3").GetComponent<Letters>().letter.text = letters[2];

        //row 3
        GameObject.Find("tile-0-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-1-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-2").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-2").GetComponent<Letters>().letter.text = letters[2];

        //row 2
        GameObject.Find("tile-0-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-1-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-2-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-3-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-4-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-5-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-6-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-7-1").GetComponent<Letters>().letter.text = letters[2];
        GameObject.Find("tile-8-1").GetComponent<Letters>().letter.text = letters[2];

        //row 1         GameObject.Find("tile-0-0").GetComponent<Letters>().letter.text = letters[5];         GameObject.Find("tile-1-0").GetComponent<Letters>().letter.text = letters[9];         GameObject.Find("tile-2-0").GetComponent<Letters>().letter.text = letters[14];         GameObject.Find("tile-3-0").GetComponent<Letters>().letter.text = letters[17];         GameObject.Find("tile-4-0").GetComponent<Letters>().letter.text = letters[3];         GameObject.Find("tile-5-0").GetComponent<Letters>().letter.text = letters[2];         GameObject.Find("tile-6-0").GetComponent<Letters>().letter.text = letters[2];         GameObject.Find("tile-7-0").GetComponent<Letters>().letter.text = letters[2];         GameObject.Find("tile-8-0").GetComponent<Letters>().letter.text = letters[2];
    }

    void Update() {
		if (Input.GetMouseButton (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				current = hit.transform.gameObject;
			}
			ready = true;
		}
		if (Input.GetMouseButtonUp (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				current = hit.transform.gameObject;
			}
			Verify();
		}
	}

    private void Verify() {
        if (selectedString.ToLower() == "fjord" || selectedString.ToLower() == "ordbok" || selectedString.ToLower() == "vindu") {
            foreach (GameObject g in selected) {
                g.GetComponent<Letters>().identified = true;
            }
            correct = true;
        }
        ready = false;
        selected.Clear();
        selectedString = "";
    }
}