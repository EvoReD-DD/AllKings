using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject singlePlayerButton;
    [SerializeField] private GameObject multiPlayerButton;

    public void FirstPlayButton()
    {
        if (singlePlayerButton.activeSelf == false)
        {
            singlePlayerButton.SetActive(true);
            multiPlayerButton.SetActive(true);
        }
        else {
            singlePlayerButton.SetActive(false);
            multiPlayerButton.SetActive(false);
        }
    }
    public void SecondPlayButton()
    {
        if (SaveData.mapsChoiced == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (SaveData.mapsChoiced == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
}
