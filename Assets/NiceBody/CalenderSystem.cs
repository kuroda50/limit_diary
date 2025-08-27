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
        StartCoroutine(OnStartAsync(currentDay));
    }


    private IEnumerator OnStartAsync(int startDay)
    {
        marker.transform.position = daySlots[startDay - 1].position;


        for (; ; currentDay++)
        {
            var matchedEventDay = eventDaies.FirstOrDefault(e => e.Day == currentDay);
            if (matchedEventDay != null)
            {
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
