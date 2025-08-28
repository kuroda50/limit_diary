using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Microsoft.Unity.VisualStudio.Editor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator handR;
    [SerializeField] private Animator handL;
    [SerializeField] private Animator stick;
    [SerializeField] private Animator smoke;
    [SerializeField] private GameObject clearResultPanel;
    [SerializeField] private GameObject failureResultPanel;
    [SerializeField] private GameObject clickButton;
    [SerializeField] private TextMeshProUGUI clearResultCounterText;
    [SerializeField] private TextMeshProUGUI faultResultCounterText;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private int counter = 0;
    [SerializeField] private Timer timer;

    private int clearCount = 40;

    void Start()
    {

    }

    void Update()
    {
        if (timer.IsGameOver() && !clearResultPanel.activeSelf)//制限時間が来たら条件式をtrueにする処理に書き換える
        {
            Debug.Log("ゲームオーバーです");
            clickButton.SetActive(false); // クリックパネルを非表示
            if (counter >= clearCount)
            {
                clearResultPanel.SetActive(true); // 結果パネルを表示
            }
            else
            {
                failureResultPanel.SetActive(true); // 結果パネルを表示
            }
            return;
        }
    }

    public void Click()
    {
        counter++;
        counterText.text = counter.ToString();
        clearResultCounterText.text = counter.ToString();
        faultResultCounterText.text = counter.ToString();
        Debug.Log("counter: " + counter);
        handR.SetBool("OnClick", true);
        handL.SetBool("OnClick", true);
        stick.SetBool("OnClick", true);
        smoke.SetBool("OnClick", true);
        SEManager.instance.PlaySE(0);
    }

    public void ChangeToScene(string sceneName)
    {
        Debug.Log(sceneName + "シーンに移動する処理を実装してください");
        // SceneManager.LoadScene(sceneName);
    }
}
