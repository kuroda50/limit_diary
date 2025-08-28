using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public sealed class OnChangeSceneButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string onLoadSceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(onLoadSceneName);
        SEManager.instance.PlaySE(4);
    }
}
