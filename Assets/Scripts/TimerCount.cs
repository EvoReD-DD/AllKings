using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private Text timeTextMinutes;
    [SerializeField] private Text timeTextSeconds;
    [SerializeField] private float startTime;

    private DateTime timerEnd;

    private void Start()
    {
        timerEnd = DateTime.Now.AddSeconds(startTime);
    }

    private void Update()
    {
        TimeSpan delta = timerEnd - DateTime.Now;
        timeTextMinutes.text = delta.Minutes.ToString("00");
        timeTextSeconds.text = delta.Seconds.ToString("00");
        if (delta.TotalSeconds <= 0)
        {
            Debug.Log("The END");
        }
    }
}
