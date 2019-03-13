using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


/*
This class is meant to assure that one cannot start dialogs whilst another one is in progress. 
     
*/
public class DialogController : MonoBehaviour
{
    //bool that says if someone is performing dialog
    private static bool performingDialog = false;
    

    //used when some character wants to perform dialog
    public static bool ClaimDialog(Flowchart flowchart)
    {
        if (flowchart.HasExecutingBlocks() || performingDialog == true)
        {
            return false;
        }
        performingDialog = true;
        return true;
    }

    //used when some character is releasing the dialog for other people to use it
    public static void ReleaseDialog()
    {
        performingDialog = false;
    }
}
