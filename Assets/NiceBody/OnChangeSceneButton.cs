using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public sealed class OnChangeSceneButton : MonoBehaviour
{
    [SerializeField] string onLoadSceneName;


    private void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            UnityEngine.SceneManagement.SceneManager.LoadScene(onLoadSceneName);
        });
    }
}
