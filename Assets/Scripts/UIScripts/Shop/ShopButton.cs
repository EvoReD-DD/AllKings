using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    public void OpenShop()
    {
        shop.SetActive(true);
    }
}
