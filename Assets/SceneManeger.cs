using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManeger : MonoBehaviour
{

    private Dictionary<SuikaMover.SuikaType, int> DestroyCountDictionary = new()
    {
        {SuikaMover.SuikaType.suika,0},
        {SuikaMover.SuikaType.human,0},
        {SuikaMover.SuikaType.ball,0},
    };
    public float timeLimit = 30f; // 経過時間（秒）でリザルトへ

    private float timer = 0f;

    public void addmelonDestroyCount()
    {
        DestroyCountDictionary[SuikaMover.SuikaType.suika]++;
    }

    public void addhumanDestroyCount()
    {
        DestroyCountDictionary[SuikaMover.SuikaType.human]++;
    }

    public void addballDestroyCount()
    {
        DestroyCountDictionary[SuikaMover.SuikaType.ball]++;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            var max = DestroyCountDictionary.OrderByDescending(dict => dict.Value).First();
            SuikaMover.SuikaType Type = max.Key;
            if (Type == SuikaMover.SuikaType.suika)
            {
                SceneManager.LoadScene("Result1");
            }
            if (Type == SuikaMover.SuikaType.human)
            {
                SceneManager.LoadScene("Result3");
            }
            if(Type == SuikaMover.SuikaType.ball)
            {
                SceneManager.LoadScene("Result2");
            }
        }
    }
}
