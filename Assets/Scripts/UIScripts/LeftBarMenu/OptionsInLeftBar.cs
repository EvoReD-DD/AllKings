using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsInLeftBar : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    public void OptionsOpen()
    {
        if (optionsMenu.activeSelf == false)
        {
            optionsMenu.SetActive(true);
        }
        else
        {
            optionsMenu.SetActive(false);
        }
    }
}
