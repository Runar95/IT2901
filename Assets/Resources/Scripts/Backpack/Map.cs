using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject map;
    Animator anim;
    public GameObject YouAreHere;
    Animator positionAnim;
    public enum mapPosition{MH_View1, MH_View2, MH_View3, MH_View4, CH_View1, CH_View2, CH_View3, CH_View4, EH_View1, EH_View2, EH_View3, EH_View4}
 
    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        positionAnim = YouAreHere.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)//When mouse is over map, make it bigger
    {
        anim.SetBool("Big", true);
    }

    public void OnPointerExit(PointerEventData eventData)//When mouse is no longer over map, make it smaler 
    {
        anim.SetBool("Big", false);
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
}
