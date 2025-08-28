using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private bool isGameover = false;
    [SerializeField] float timerLimit;
    [SerializeField] TimerInner timer;
    float seconds = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            timer.UpdateClock(_updateTimer());
        }
    }

    private float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = seconds / timerLimit;
        // Debug.Log("seconds: " + seconds);
        // Debug.Log("timer: " + timer);
        if (seconds >= timerLimit)
        {
            if(!isGameover)
                SEManager.instance.PlaySE(4);
            isGameover = true;
        }

        return timer;
    }
    public bool IsGameOver()
    {
        return isGameover;
    }
}
