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
}

