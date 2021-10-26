using UnityEngine;
using UnityEngine.UI;
using System;

public class GetCountItems : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private Text donate;

    private void Update()
    {
        coins.text = Convert.ToString(SaveData.coins);
        donate.text = Convert.ToString(SaveData.donateCoins);
    }
}
