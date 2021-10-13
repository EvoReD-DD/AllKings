using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class ScoringWinner : MonoBehaviour
{
    [SerializeField] private Text bonusWinExp;
    [SerializeField] private Text bonusWinCoins;
    private int prefCoins;
    private int prefLvl;
    private string prefCoinsText;
    private string prefLvlText;
    private SavedData sv = new SavedData();
    private string path;

    private void Start()
    {
        ScoreCalculate();
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "SaveData.json");
#endif
        Debug.Log(sv.savedCoins);
        Debug.Log(sv.savedLvl);
        Debug.Log(bonusWinCoins.text);
        Debug.Log(bonusWinExp.text);
    }
    public void LoadPrefInfo()
    {
        sv = JsonUtility.FromJson<SavedData>(File.ReadAllText(path));
        prefCoins = Convert.ToInt32(bonusWinCoins.text) + Convert.ToInt32(sv.savedCoins);
        prefLvl = Convert.ToInt32(bonusWinExp.text) + Convert.ToInt32(sv.savedLvl);
        Debug.Log(prefCoins);
        Debug.Log(prefLvl);
        prefCoinsText = Convert.ToString(prefCoins);
        prefLvlText = Convert.ToString(prefLvl);
        sv.savedCoins = prefCoinsText;
        sv.savedLvl = prefLvlText;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

    private void ScoreCalculate()
    {
        if (SingleGameSettings.setTimeStart == 180f)
        {
            bonusWinCoins.text =Convert.ToString(100);
            bonusWinExp.text = Convert.ToString(50);
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
