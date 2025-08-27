using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject clickButton;
    [SerializeField] private TextMeshProUGUI resultCounterText;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int counter = 0;
    [SerializeField] private Timer timer;

    void Start()
    {

    }

    void Update()
    {
        if (timer.IsGameOver() && !resultPanel.activeSelf)//制限時間が来たら条件式をtrueにする処理に書き換える
        {
            Debug.Log("ゲームオーバーです");
            resultPanel.SetActive(true); // 結果パネルを表示
            clickButton.SetActive(false); // クリックパネルを非表示
            return;
        }
    }

    public void Click()
    {
        counter++;
        counterText.text = counter.ToString();
        resultCounterText.text = counter.ToString();
        Debug.Log("counter: " + counter);
        anim.SetBool("OnClick", true);
    }

    public void ChangeToScene(string sceneName)
    {
        Debug.Log(sceneName + "シーンに移動する処理を実装してください");
        // SceneManager.LoadScene(sceneName);
    }
}
