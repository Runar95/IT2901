using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class Map : MonoBehaviour
{
    public GameObject map;

    public GameObject YouAreHere;
    Animator positionAnim;
    public enum mapPosition{MH_View1, MH_View2, MH_View3, MH_View4, CH_View1, CH_View2, CH_View3, CH_View4, EH_View1, EH_View2, EH_View3, EH_View4}
 
    public void Start()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        flowchart.SetStringVariable("enterView", Globals.lastView);
        positionAnim = YouAreHere.GetComponent<Animator>();
    }

    public void updatePosition(mapPosition position){
      switch (position)
      {
          case mapPosition.MH_View1:
                positionAnim.SetTrigger("MH_View1");
              break;
          case  mapPosition.MH_View2:
                positionAnim.SetTrigger("MH_View2");
              break;
          case  mapPosition.MH_View3:
                positionAnim.SetTrigger("MH_View3");
              break;
          case  mapPosition.MH_View4:
                positionAnim.SetTrigger("MH_View4");
              break;
          case mapPosition.EH_View1:
                positionAnim.SetTrigger("EH_View1");
              break;
          case  mapPosition.EH_View2:
                positionAnim.SetTrigger("EH_View2");
              break;
          case  mapPosition.EH_View3:
                positionAnim.SetTrigger("EH_View3");
              break;
          case  mapPosition.EH_View4:
                positionAnim.SetTrigger("EH_View4");
              break;
          case mapPosition.CH_View1:
                positionAnim.SetTrigger("CH_View1");
              break;
          case  mapPosition.CH_View2:
                positionAnim.SetTrigger("CH_View2");
              break;
          case  mapPosition.CH_View3:
                positionAnim.SetTrigger("CH_View3");
              break;
          case  mapPosition.CH_View4:
                positionAnim.SetTrigger("CH_View4");
              break;
         default:
              break;
      }

    }
    public void SetLastView(string lastView){
        Globals.lastView = lastView;
    }
    public string GetLastView(){
        return Globals.lastView;
    }
}
