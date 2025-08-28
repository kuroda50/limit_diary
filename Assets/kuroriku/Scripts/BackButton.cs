using UnityEngine;
using UnityEngine.SceneManagement;

public class BuckButton : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        SEManager.instance.PlaySE(2);
        Debug.Log(sceneName + "シーンに移動する処理を実装してください");
        SceneManager.LoadScene(sceneName);
    }
}
