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
    }

    public void L3() {
        Globals.nextLevel();
        Globals.nextLevel();
        SceneManager.LoadScene("Ship");
    }
}

