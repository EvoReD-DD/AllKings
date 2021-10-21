using UnityEngine;

public class LeftBarMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject leftBarPopUpMenu;

    public void LeftBarActive()
    {
        if (leftBarPopUpMenu.activeSelf == false)
        {
            leftBarPopUpMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            leftBarPopUpMenu.SetActive(false);
            this.gameObject.SetActive(true);
        }
    }
}
