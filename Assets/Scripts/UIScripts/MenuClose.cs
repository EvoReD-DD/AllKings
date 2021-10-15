using UnityEngine;

public class MenuClose : MonoBehaviour
{
    [SerializeField] private GameObject leftBarMenu;
    [SerializeField] private GameObject leftBarMenuButton;
    public void LeftBarMenuClose()
    {
        leftBarMenu.SetActive(false);
        leftBarMenuButton.SetActive(true);
    }

}
