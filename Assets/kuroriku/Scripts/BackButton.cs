using UnityEngine;
using UnityEngine.SceneManagement;

public class BuckButton : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
