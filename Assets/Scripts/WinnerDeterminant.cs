using UnityEngine;
using UnityEngine.UI;

public class WinnerDeterminant : MonoBehaviour
{
    [SerializeField] private Text redTeamPoint;
    [SerializeField] private Text blueTeamPoint;
    [SerializeField] private Text winnerText;
    [SerializeField] private GameObject winnerMenu;
    private int redTeamScore;
    private int blueTeamScore;
    public void DeterminantWinTeam()
    {
        winnerMenu.SetActive(true);
        redTeamScore = System.Convert.ToInt32(redTeamPoint.text);
        blueTeamScore = System.Convert.ToInt32(blueTeamPoint.text);
        if (redTeamScore > blueTeamScore)
        {
            winnerText.text = "Red Team Win";
        }
        else if (redTeamScore < blueTeamScore)
        {
            winnerText.text = "Blue Team Win";
        } 
        else if (redTeamScore == blueTeamScore)
        {
            winnerText.text = "Draw";
        }
    }
}
