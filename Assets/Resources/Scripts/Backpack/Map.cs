using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject map;
    public bool showMap;
    Animator anim;
    public void Start()
    {
        map.SetActive(showMap);
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("Big", true);
        //transform.localScale += new Vector3(0.7F, 0.7F, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("Big", false);
        // transform.localScale += new Vector3(-0.7F, -0.7F, 0);
    } 
}
