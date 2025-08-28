using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class QuizResultSystem : MonoBehaviour
{
    [Header("View")]
    [SerializeField] Canvas resultCanvas_;
    [SerializeField] Image  resultImage_;

    [Header("Result Sprites")]
    [SerializeField] Sprite successSprite;
    [SerializeField] Sprite failureSprite;

    private void Awake()
    {
        resultCanvas_.enabled = false;
    }

    public void OnDisplayResult(bool isSuccess)
    {
        resultCanvas_.enabled = true;
        
        if (isSuccess)
        {
            resultImage_.sprite = successSprite;
        }
        else
        {
            resultImage_.sprite = failureSprite;
        }
    }
}
