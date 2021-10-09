using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBarMenu : MonoBehaviour
{
    [SerializeField] private GameObject leftBarMenu;
    [SerializeField] private GameObject leftBarMenuButton;
    public void LeftBarMenuClose()
    {
        leftBarMenu.SetActive(false);
        leftBarMenuButton.SetActive(true);
    }
}
