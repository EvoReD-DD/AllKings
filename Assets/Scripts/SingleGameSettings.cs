using UnityEngine;
using UnityEngine.UI;


public class SingleGameSettings : MonoBehaviour
{
    [SerializeField] private Toggle teamToggle;
    [SerializeField] private Dropdown matchTimeDropDown;

    public void SingleModeSetSave()
    {
        TeamToggle();
        MatchTimeSetSave();
    }

    private void TeamToggle()
    {
        if (teamToggle.isOn == true)
        {
            SaveData.redBlue = false;
        }
        else
        {
            SaveData.redBlue = true;
        }
    }

    private void MatchTimeSetSave()
    {
        if (matchTimeDropDown.value == 0)
        {
            SaveData.setTimeStart = 180;
        }
        if (matchTimeDropDown.value == 1)
        {
            SaveData.setTimeStart = 300;
        }
        if (matchTimeDropDown.value == 2)
        {
            SaveData.setTimeStart = 600;
        }
        if (matchTimeDropDown.value == 3)
        {
            SaveData.setTimeStart = 900;
        }
    }
}
