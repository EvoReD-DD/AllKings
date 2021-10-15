using UnityEngine;
using UnityEngine.UI;


public class SingleGameSettings : MonoBehaviour
{
    [SerializeField] private Toggle teamToggle;
    [SerializeField] private Dropdown matchTimeDropDown;
    public static float setTimeStart;
    public static bool redBlue;

    public void SingleModeSetSave()
    {
        TeamToggle();
        MatchTimeSetSave();
    }

    private void TeamToggle()
    {
        if (teamToggle.isOn == true)
        {
            redBlue = false;
        }
        else
        {
            redBlue = true;
        }
    }

    private void MatchTimeSetSave()
    {
        if (matchTimeDropDown.value == 0)
        {
            setTimeStart = 180;
        }
        if (matchTimeDropDown.value == 1)
        {
            setTimeStart = 300;
        }
        if (matchTimeDropDown.value == 2)
        {
            setTimeStart = 600;
        }
        if (matchTimeDropDown.value == 3)
        {
            setTimeStart = 900;
        }
    }
}
