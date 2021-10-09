using UnityEngine;

public class LeftBarMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject leftBarPopUpMenu;
    [SerializeField] private Vector3 thisButtonPositionOnPopUp;
    [SerializeField] private Vector3 thisButtonPositionOffPopUp;

    public void LeftBarActive()
    {
        if (leftBarPopUpMenu.activeSelf == false)
        {
            leftBarPopUpMenu.SetActive(true);
            leftBarPopUpMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            leftBarPopUpMenu.SetActive(false);
            leftBarPopUpMenu.SetActive(false);
            this.gameObject.SetActive(true);
        }
    }
}
