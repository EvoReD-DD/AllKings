
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    [SerializeField] private GameObject[] playerCharacterArray;
    [SerializeField] private FirstStart firstStartScript;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    [SerializeField] private GameObject choiceCharacter;
    
    private int currentCharacter;
    private int i;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentCharacter"))
        {
            i = PlayerPrefs.GetInt("CurrentCharacter");
            currentCharacter = PlayerPrefs.GetInt("CurrentCharacter");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentCharacter", i);
        }
        playerCharacterArray[i].SetActive(true);
        if (i < 0)
        {
            arrowLeft.SetActive(true);
        }
        if (i == playerCharacterArray.Length)
        {
            arrowRight.SetActive(false);
        }
    }
    public void ArrowRight()
    {
        if (i < playerCharacterArray.Length)
        {
            if (i == 0)
            {
                arrowLeft.SetActive(true);
            }
            playerCharacterArray[i].SetActive(false);
            i++;
            playerCharacterArray[i].SetActive(true);
            if (i + 1 == playerCharacterArray.Length)
            {
                arrowRight.SetActive(false);
            }
        }

    }
    public void ArrowLeft()
    {

        if (i < playerCharacterArray.Length)
        {
            playerCharacterArray[i].SetActive(false);
            i--;
            playerCharacterArray[i].SetActive(true);
            arrowRight.SetActive(true);
            if (i == 0)
            {
                arrowLeft.SetActive(false);
            }
        }

    }
    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("CurrentCharacter", i);
        currentCharacter = i;
        firstStartScript.SetActiveGameObject(false);
        choiceCharacter.SetActive(false);
        if (currentCharacter == 0)
        {
            SaveData.playerChoiced = true;
            Debug.Log(SaveData.playerChoiced);
        }
        else {
            SaveData.playerChoiced = false;
            Debug.Log(SaveData.playerChoiced);
        }
    }
}
