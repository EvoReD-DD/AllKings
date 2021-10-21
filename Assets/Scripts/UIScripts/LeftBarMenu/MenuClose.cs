using UnityEngine;

public class MenuClose : MonoBehaviour
{
    [SerializeField] private GameObject leftBarMenu;
    [SerializeField] private GameObject leftBarMenuButton;
    [SerializeField] private GameObject options;
    public void LeftBarMenuClose()
    {
        leftBarMenu.SetActive(false);
        leftBarMenuButton.SetActive(true);
        options.SetActive(false);
    }
}
