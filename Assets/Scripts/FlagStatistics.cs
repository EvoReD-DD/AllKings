using UnityEngine;
using UnityEngine.UI;

public class FlagStatistics : MonoBehaviour
{
    [SerializeField] private Text pointRedTeam;
    [SerializeField] private Text pointBlueTeam;
    [SerializeField] private GameObject redTeamTakeFlag;
    [SerializeField] private GameObject blueTeamTakeFlag;
    private int redPoint = 0;
    private int bluePoint = 0;

    private void Start()
    {
        pointBlueTeam.text = bluePoint.ToString();
        pointRedTeam.text = redPoint.ToString();
    }

    public void FlagTakeRed()
    {
        redTeamTakeFlag.SetActive(true);
        Invoke("FlagTakeRedOff", 2f);
    }

    public void FlagTakeBlue()
    {
        blueTeamTakeFlag.SetActive(true);
        Invoke("FlagTakeBlueOff", 2f);
    }

    private void FlagTakeRedOff()
    {
        redTeamTakeFlag.SetActive(false);
    }
    private void FlagTakeBlueOff()
    {
        blueTeamTakeFlag.SetActive(false);
    }

}
