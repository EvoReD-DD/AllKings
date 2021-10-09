using UnityEngine;

public class SinglePlayerButton : MonoBehaviour
{
    [SerializeField] private GameObject playModeMenu;
    [SerializeField] private GameObject singlePlayerMenu;
    [SerializeField] private GameObject multiPlayerMenu;
    [SerializeField] private GameObject singlePlayerButton;
    [SerializeField] private GameObject multiPlayerButton;
    [SerializeField] private GameObject playButton;
    public void OpenSinglePlayerMenu()
    {
        playModeMenu.SetActive(true);
        singlePlayerMenu.SetActive(true);
        multiPlayerMenu.SetActive(false);
        singlePlayerButton.SetActive(false);
        multiPlayerButton.SetActive(false);
        playButton.SetActive(false);
    }
}
