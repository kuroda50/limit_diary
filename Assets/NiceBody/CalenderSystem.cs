using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public sealed class CalenderSystem : MonoBehaviour
{
    [SerializeField] Image marker;
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
            var matched = eventDaies.FirstOrDefault(e => e.Day == currentDay);
            if (matched != null)
            {
                matched.OnStart();
            }

            if (weekEndDaies.Contains(currentDay))
            {
                yield return StartCoroutine(OnDisappearNextWeekAsync(currentDay));
            }
            else
            {
                yield return StartCoroutine(OnMoveMarkerNextDayAsync(currentDay + 1));
            }
        }
    }

    private IEnumerator OnMoveMarkerNextDayAsync(int nextDay)
    {
        while (true)
        {
            var moveDirection = daySlots[nextDay - 1].position - marker.transform.position;

            if (moveDirection.magnitude < 2)
                break;

            marker.transform.position += moveDirection.normalized;
            yield return null;
        }
    }

    private IEnumerator OnDisappearNextWeekAsync(int nextDay)
    {
        for (float alpha = 1; alpha > 0; alpha -= 0.02f)
        {
            marker.color = new Color(marker.color.r, marker.color.g, marker.color.b, alpha);
            yield return null;
        }

        marker.transform.position = daySlots[nextDay].transform.position;
        marker.color = new Color(255, 255, 255, 255);
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
