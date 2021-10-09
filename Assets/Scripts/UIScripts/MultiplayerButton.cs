using UnityEngine;

public class MultiplayerButton : MonoBehaviour
{
    [SerializeField] private GameObject playModeMenu;
    [SerializeField] private GameObject singlePlayerButton;
    [SerializeField] private GameObject singlePlayerMenu;
    [SerializeField] private GameObject multiPlayerMenu;
    [SerializeField] private GameObject multiPlayerButton;
    public void OpenMultiPlayerMenu()
    {
        playModeMenu.SetActive(true);
        multiPlayerMenu.SetActive(true);
        singlePlayerMenu.SetActive(false);
        singlePlayerButton.SetActive(false);
        multiPlayerButton.SetActive(false);
    }
}
