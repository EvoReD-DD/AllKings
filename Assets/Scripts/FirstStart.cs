using UnityEngine;
using UnityEngine.UI;

public class FirstStart : MonoBehaviour
{
    [SerializeField] private GameObject nickNameInputMenu;
    [SerializeField] private Text nickNameText;
    [SerializeField] private GameObject playerChoice;
    [SerializeField] private GameObject[] deactivateGameObject;

    void Start()
    {
        if (nickNameText.text != "")
        {
            
            SetActiveGameObject(false);
        }
        else
        {
            
            SetActiveGameObject(true);
        }
    }
    public void SetActiveGameObject(bool active)
    {
        if (active == true)
        {
            for (int i = 0; i < deactivateGameObject.Length; i++)
            {
                deactivateGameObject[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < deactivateGameObject.Length; i++)
            {
                deactivateGameObject[i].SetActive(true);
            }
        }
    }
}
