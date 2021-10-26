using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;
    private static float timer;
    public static bool isPause;
    private static bool callOnce;

    private void Start()
    {
        callOnce = false;
    }
    void Update()
    {
        Time.timeScale = timer;
        Timer();
    }
    public void Close()
    {
        isPause = false;
    }
    public void Pause()
    {
        isPause = true;
    }
    private void Timer()
    {
        if (isPause == true)
        {
            timer = 0;
            pauseImage.SetActive(true);
        }
        else if (isPause == false)
        {
            timer = 1f;
            pauseImage.SetActive(false);
        }
    }
    public static void OffPause()
    {
        if (!callOnce)
        {
            timer = 1f;
            callOnce = true;
        }
    }
}
