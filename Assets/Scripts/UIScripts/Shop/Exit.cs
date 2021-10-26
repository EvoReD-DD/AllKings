using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    public void ShopClose()
    {
        shop.SetActive(false);
    }
}
