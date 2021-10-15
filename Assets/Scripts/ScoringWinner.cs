using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class ScoringWinner : MonoBehaviour
{
    [SerializeField] private Text bonusWinExp;
    [SerializeField] private Text bonusWinCoins;

    private void Start()
    {
        ScoreCalculate();
    }
    public void BonusAccrual()
    {
        SaveData.coins += Convert.ToInt32(bonusWinCoins.text);
        LvlSystem.LvlIncrease(Convert.ToInt32(bonusWinExp.text));
        Debug.Log("+exp and + coins");
        SaveAndLoadData.Save();
    }

    private void ScoreCalculate()
    {
        if (SingleGameSettings.setTimeStart == 180f)
        {
            bonusWinCoins.text = Convert.ToString(100);
            bonusWinExp.text = Convert.ToString(1200);
        }
        if (SingleGameSettings.setTimeStart == 300f)
        {
            bonusWinCoins.text = Convert.ToString(150);
            bonusWinExp.text = Convert.ToString(75);
        }
        if (SingleGameSettings.setTimeStart == 600f)
        {
            bonusWinCoins.text = Convert.ToString(250);
            bonusWinExp.text = Convert.ToString(125);
        }
        if (SingleGameSettings.setTimeStart == 900f)
        {
            bonusWinCoins.text = Convert.ToString(350);
            bonusWinExp.text = Convert.ToString(200);
        }
    }
}
