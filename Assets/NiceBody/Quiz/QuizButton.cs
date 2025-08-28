using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class QuizButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Sprite idleSprite;
    [SerializeField] Sprite pusshingSprite;

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = pusshingSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = idleSprite; 
    }
}
