using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class SaveAndLoadData : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text coins;
    [SerializeField] private Text donateCoins;
    [SerializeField] private Text lvl;
    [SerializeField] private Image expFill;
    [SerializeField] private GameObject loginMenu;
    [SerializeField] private GameObject leftBar;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject leftBarMenuButton;
    private static SavedData sv = new SavedData();
    public static string path;

    public void CreatePath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "SaveData.json");
#endif
    }
    public void Load()
    {
        sv = JsonUtility.FromJson<SavedData>(File.ReadAllText(path));
        SaveData.nickName = sv.savedNickName;
        SaveData.coins = sv.savedCoins;
        SaveData.donateCoins = sv.savedDonateCoins;
        SaveData.exp = sv.savedExp;
        SaveData.lvl = sv.savedLvl;
        SaveData.baseSide = sv.savedBaseSide;
        nickName.text = SaveData.nickName;
        coins.text = Convert.ToString(SaveData.coins);
        donateCoins.text = Convert.ToString(SaveData.donateCoins);
        lvl.text = Convert.ToString(SaveData.lvl);
        SaveData.playerChoiced = sv.savedPlayerChoiced;
    }
    public static void Save()
    {
        sv.savedNickName = SaveData.nickName;
        sv.savedCoins = SaveData.coins;
        sv.savedDonateCoins = SaveData.donateCoins;
        sv.savedLvl = SaveData.lvl;
        sv.savedExp = SaveData.exp;
        sv.savedBaseSide = SaveData.baseSide;
        sv.savedPlayerChoiced = SaveData.playerChoiced;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
    public void ResetData()
    {
        File.Delete(path);
        leftBar.SetActive(false);
        options.SetActive(true);
        loginMenu.SetActive(true);
        leftBarMenuButton.SetActive(true);
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) 
        {
        sv.savedNickName = SaveData.nickName;
        sv.savedCoins = SaveData.coins;
        sv.savedDonateCoins = SaveData.donateCoins;
        sv.savedLvl = SaveData.lvl;
        sv.savedExp = SaveData.exp;
        sv.savedBaseSide = SaveData.baseSide;
        sv.savedPlayerChoiced = SaveData.playerChoiced;
        SaveData.authorOnce = false;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
        }
    }
#endif
    private void OnApplicationQuit()
    {
        sv.savedNickName = SaveData.nickName;
        sv.savedCoins = SaveData.coins;
        sv.savedDonateCoins = SaveData.donateCoins;
        sv.savedLvl = SaveData.lvl;
        sv.savedExp = SaveData.exp;
        sv.savedBaseSide = SaveData.baseSide;
        sv.savedPlayerChoiced = SaveData.playerChoiced;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}
[Serializable]
public class SavedData
{
    public string savedNickName;
    public int savedCoins;
    public int savedDonateCoins;
    public int savedLvl;
    public int savedExp;
    public bool savedPlayerChoiced;
    public int savedBaseSide;
}
