using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private UnityEvent timeOut;
    public float startTime = 180f;
    private bool callOnce = true;
    public float minutes;
    public float seconds;

    private DateTime timerEnd;

    private void Start()
    {
        startTime = SingleGameSettings.setTimeStart;
    }
    private void Update()
    {
        startTime -= Time.deltaTime;
        Timer(startTime);
    }

    private void Timer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
        if (minutes <= 0 && callOnce == true)
        {
            if (seconds <= 0 && callOnce == true)
            {
                timeOut.Invoke();
                callOnce = false;
            }
        }
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
