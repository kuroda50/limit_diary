using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishScreen;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimerBase").GetComponent<Timer>();
        finishScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer.IsGameOver());
        if (timer.IsGameOver())
        {
            finishScreen.SetActive(true);
        }
    }
}
