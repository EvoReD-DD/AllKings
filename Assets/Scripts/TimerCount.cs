using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.Events;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private GameObject timerText;
    [SerializeField] private UnityEvent timeOut;
    [SerializeField] private GameObject pauseImage;
    private Text timer;
    public float startTime = 180f;
    private bool callOnce = true;
    public float minutes;
    public float seconds;
    public static bool pauseOn;
    #region firstTimerVariable
    private float pauseTime = 5f;
    private DateTime timerEnd;
    #endregion
    private void Start()
    {
        timerText.SetActive(false);
        startTime = SaveData.setTimeStart;
        timerEnd = DateTime.Now.AddSeconds(pauseTime);
        timer = timerText.GetComponent<Text>();
    }
    private void Update()
    {
        CountdownToStart();
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
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    private void CountdownToStart()
    {
        pauseOn = false;
        Time.timeScale = 0;
        TimeSpan delta = timerEnd - DateTime.Now;
        if (delta.TotalSeconds <= 0)
        {
            Time.timeScale = 1f;
            timerText.SetActive(true);
            pauseImage.SetActive(false);
            startTime -= Time.deltaTime;
            Timer(startTime);
            pauseOn = true;
        }
    }
}
