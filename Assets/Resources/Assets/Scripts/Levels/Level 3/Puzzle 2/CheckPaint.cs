using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class CheckPaint : MonoBehaviour
{
    public Flowchart flowchart;

    public void Check(){
        string glass1 = flowchart.GetVariable("glass1").ToString();
        string glass2 = flowchart.GetVariable("glass2").ToString();
        string glass3 = flowchart.GetVariable("glass3").ToString();
 
        if(glass1 == "green" && glass2 == "purple" && glass3 == "orange"){
            flowchart.ExecuteBlock("PaintDone");
        }else if((glass1 == "purple" || glass1 == "green" || glass1 == "orange")&&
                (glass2 == "purple" || glass2 == "green" || glass2 == "orange")&&
                (glass3 == "purple" || glass3 == "green" || glass3 == "orange")){
            flowchart.ExecuteBlock("wrongPaint");
        }

    }
}
