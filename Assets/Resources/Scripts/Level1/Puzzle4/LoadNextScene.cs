using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class LoadNextScene : MonoBehaviour
{
    private bool check = true;
    public Flowchart flowchart;
    void Update()
    {
        if(BackpackVariables.BackpackContainsKey(BackpackVariables.Item.Key ) && check){
            Invoke("ChangeScene", 2);
            check = false;
        }
    }

    void ChangeScene(){
         if(BackpackVariables.BackpackContainsKey(BackpackVariables.Item.Key)){
            //SceneManager.LoadScene("InsidePlane", LoadSceneMode.Additive);
            flowchart.ExecuteBlock("Back_to_ship");
        }else{
            check = true;
        }

    }
}
