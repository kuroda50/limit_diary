using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TitleUiButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Image image_;
    Button button_;
    [SerializeField] Sprite idleSprite_;
    [SerializeField] Sprite pointerDownSprite_;

    private void Awake()
    {
        button_ = GetComponent<Button>();
        image_ = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image_.sprite = pointerDownSprite_;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image_.sprite = idleSprite_;
    }
}
