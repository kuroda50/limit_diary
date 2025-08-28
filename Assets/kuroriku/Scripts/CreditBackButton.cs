using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditBuckButton : MonoBehaviour
{
    public void OnClick(string sceneName)
    {
        Debug.Log(sceneName + "シーンに移動する処理を実装してください");
        SceneManager.LoadScene(sceneName);
    }
}
