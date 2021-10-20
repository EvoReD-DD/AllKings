using UnityEngine;
using UnityEngine.UI;


public class SingleGameSettings : MonoBehaviour
{
    [SerializeField] private Toggle teamToggle;
    [SerializeField] private Scrollbar timeScrollBar;
    [SerializeField] private Text timeText;
    [SerializeField] private Scrollbar teamScrollBar;
    [SerializeField] private Image teamColorImage;

    public void SingleModeSetSave()
    {
        TeamScrollBar();
        MatchTimeSetSave();
    }
    private void Update()
    {
        MatchTimeSetSave();
        TeamScrollBar();
    }
    private void TeamScrollBar()
    {
        if (teamScrollBar.value >= 0 && timeScrollBar.value <= 0.49)
        {
            SaveData.redBlue = false;
            teamColorImage.color = Color.blue;
        }
        if (teamScrollBar.value >= 0.5 && timeScrollBar.value <= 1)
        {
            SaveData.redBlue = true;
            teamColorImage.color = Color.red;
        }
    }
    private void MatchTimeSetSave()
    {
        if (timeScrollBar.value >= 0 && timeScrollBar.value <= 0.19)
        {
            SaveData.setTimeStart = 180;
            timeText.text = "3 min";
        }
        if (timeScrollBar.value >= 0.2 && timeScrollBar.value <= 0.49)
        {
            SaveData.setTimeStart = 300;
            timeText.text = "5 min";
        }
        if (timeScrollBar.value >= 0.5 && timeScrollBar.value <= 0.69)
        {
            SaveData.setTimeStart = 600;
            timeText.text = "10 min";
        }
        if (timeScrollBar.value >= 0.7 && timeScrollBar.value <= 1)
        {
            SaveData.setTimeStart = 900;
            timeText.text = "15 min";

        }
    }
}
