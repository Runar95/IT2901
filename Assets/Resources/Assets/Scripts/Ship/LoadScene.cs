using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class LoadScene : MonoBehaviour
{
    public Flowchart flowchart;

    public void ChangeScene(){
        SceneManager.LoadScene(6);
    }

    public void L1() {
        SceneManager.LoadScene("Ship");
    }

    public void L2() {
        Globals.nextLevel();
        SceneManager.LoadScene("Ship");
        NotebookController.SetAccess(1, NotebookController.GetLevelKey(2));
    }

    public void L3() {
        Globals.nextLevel();
        Globals.nextLevel();
        NotebookController.SetAccess(1, NotebookController.GetLevelKey(3));
        SceneManager.LoadScene("Ship");
    }
}

