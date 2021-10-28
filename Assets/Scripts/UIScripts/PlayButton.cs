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
            StartCoroutine(SceneTransition.LoadScene(1));
        }
        else if (SaveData.mapsChoiced == 1)
        {
            StartCoroutine(SceneTransition.LoadScene(2));
        }
    }
}
