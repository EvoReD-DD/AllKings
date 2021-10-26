using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Collections;

public class TimerCount : MonoBehaviour
{
    [SerializeField] private GameObject timerText;
    [SerializeField] private UnityEvent timeOut;
    [SerializeField] private GameObject pauseImage;
    private Animator animPauseCount;
    private Text timer;
    public float startTime = 180f;
    private bool callOnce = true;
    public float minutes;
    public float seconds;
    public static bool pauseOn = false;
    #region firstTimerVariable
    private float pauseTime = 3f;
    private DateTime timerEnd;
    #endregion
    private void Start()
    {
        timerText.SetActive(false);
        startTime = SaveData.setTimeStart;
        timerEnd = DateTime.Now.AddSeconds(pauseTime);
        timer = timerText.GetComponent<Text>();
        Time.timeScale = 0;
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
        TimeSpan delta = timerEnd - DateTime.Now;
        if (delta.TotalSeconds <= 0)
        {
            timerText.SetActive(true);
            pauseImage.SetActive(false);
            pauseOn = true;
            startTime -= Time.deltaTime;
            Timer(startTime);
            GamePause.OffPause();
        }
    }
}
