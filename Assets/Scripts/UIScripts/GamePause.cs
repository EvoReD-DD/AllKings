using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private float timer;
    public static bool isPause;

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
            isPause = true;
        }
        else if (isPause == false)
        {
            timer = 1f;
            pauseImage.SetActive(false);
            isPause = false;
        }
    }
}
