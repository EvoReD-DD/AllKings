using UnityEngine;

public class SelectedCharacterReceive : MonoBehaviour
{
    [SerializeField] private GameObject playerMale;
    [SerializeField] private GameObject playerFemale;
    [SerializeField] private Renderer male;
    [SerializeField] private Renderer female;
    private bool playerChoiced;
    private bool redBlue;
    private void Awake()
    {
        
        redBlue = SingleGameSettings.redBlue;
        playerChoiced = PlayerChoice.playerChoiced;
    }

    private void Start()
    {
        PlayerChoicedActivate();
        LoadTeamColorSettings();
    }
    private void LoadTeamColorSettings()
    {
        if (redBlue)
        {
            male.material.color = Color.red;
            playerMale.tag = "CharacterRed";
            playerFemale.tag = "CharacterRed";
            female.material.color = Color.red;
        }
        else
        {
            playerMale.tag = "CharacterBlue";
            playerFemale.tag = "CharacterBlue";
            male.material.color = Color.blue;
            female.material.color = Color.blue;
        }
    }
    private void PlayerChoicedActivate()
    {
        if (playerChoiced)
        {
            playerMale.SetActive(true);
        }
        else
        {
            
            playerFemale.SetActive(true);
        }
    }
}
