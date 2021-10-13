using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private Text timeTextMinutes;
    [SerializeField] private Text timeTextSeconds;
    [SerializeField] private UnityEvent timeOut;
    public float startTime = 180f;
    private bool callOnce = true;

    private DateTime timerEnd;

    private void Start()
    {
        startTime = SingleGameSettings.setTimeStart;
        timerEnd = DateTime.Now.AddSeconds(startTime);
    }
    private void Update()
    {
        TimeSpan delta = timerEnd - DateTime.Now;
        timeTextMinutes.text = delta.Minutes.ToString("00");
        timeTextSeconds.text = delta.Seconds.ToString("00");
        if (delta.TotalSeconds <= 0 && callOnce==true)
        {
            timeOut.Invoke();
            callOnce = false;
        }
    }

}
