using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Button fireButton;
    public bool isDown = false;
    public bool isUp = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        isUp = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        isUp = true;
    }
}
