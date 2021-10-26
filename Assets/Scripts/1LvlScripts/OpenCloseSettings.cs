using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSettings : MonoBehaviour
{
    [SerializeField] private GameObject settings;

    public void OpenMenuSettings()
    {
        settings.SetActive(true);
    }

    public void CloseMenuSettings()
    {
        settings.SetActive(false);
    }
}
