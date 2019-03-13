using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HooverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("Big", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("Big", false);
    }
}
