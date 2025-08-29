using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class CalenderSystem : MonoBehaviour
{
    [SerializeField] MarkerUI marker;
    [SerializeField] List<RectTransform> daySlots;
    [SerializeField] List<int> weekEndDaies;
    [SerializeField] List<EventDay> eventDaies;
    [SerializeField] int currentDay = 1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("HasLaunchedBefore", 0) == 0)
        {
            Debug.Log("これは初回起動です！");

            PlayerPrefs.SetInt("currentDay", currentDay);
            PlayerPrefs.SetInt("HasLaunchedBefore", 1);
            PlayerPrefs.Save();
        }
        else
        {
            currentDay = PlayerPrefs.GetInt("currentDay");
        }
        StartCoroutine(OnStartAsync(currentDay));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt("currentDay", 1);
        }
    }
    private IEnumerator OnStartAsync(int startDay)
    {
        marker.transform.position = daySlots[startDay - 1].position;

        for (; ; currentDay++)
        {
            PlayerPrefs.SetInt("currentDay", currentDay);
            PlayerPrefs.Save();
            var matchedEventDay = eventDaies.FirstOrDefault(e => e.Day == currentDay);
            if (matchedEventDay != null)
            {
                PlayerPrefs.SetInt("currentDay", currentDay + 1);
                PlayerPrefs.Save();
                yield return StartCoroutine(OnTranslateEventDay(matchedEventDay));
            }

            if (weekEndDaies.Contains(currentDay))
            {
                yield return StartCoroutine(OnDisappearNextWeekAsync(currentDay));
            }
            else
            {
                yield return StartCoroutine(marker.OnMoveAsync(daySlots[currentDay].position));
            }
        }
    }

    private IEnumerator OnDisappearNextWeekAsync(int nextDay)
    {
        yield return marker.OnDisappearAnimationAsync();
        marker.transform.position = daySlots[nextDay].transform.position;
        yield return marker.OnAppearAnimationAsync();
    }


    private IEnumerator OnTranslateEventDay(EventDay eventDay)
    {
        yield return StartCoroutine(marker.OnScaleAttensionAsync());

        eventDay.OnStart();
        yield return new WaitForSeconds(1);
    }



    [Serializable]
    public sealed class EventDay
    {
        [SerializeField] int day_;
        [SerializeField] string eventSceneName_;

        public int Day => day_;

        public void OnStart()
        {
            SceneManager.LoadScene(eventSceneName_);
        }
    }
}