using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject singlePlayerButton;
    [SerializeField] private GameObject multiPlayerButton;
    [SerializeField] private DataSaver dataSaver;

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
        SceneManager.LoadScene(1);
    }
}
