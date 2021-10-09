using UnityEngine;

public class PlayMenuSettings : MonoBehaviour
{
    [SerializeField] private GameObject playModeSinglePlayer;
    [SerializeField] private GameObject playButton;

    public void CloseSingleMenu()
    {
        playModeSinglePlayer.SetActive(false);
        playButton.SetActive(true);
    }
}
