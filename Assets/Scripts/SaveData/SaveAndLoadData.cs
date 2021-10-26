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
    [SerializeField] private GameObject nickNameInput;
    [SerializeField] private Image expFill;
    private int lvlStep = 1;
    private static SavedData sv = new SavedData();
    private static string path;
    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "SaveData.json");
#endif

        if (File.Exists(path))
        {
            Load();
        }
        else
        {
            nickNameInput.SetActive(true);
        }
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
        lvl.text = Convert.ToString(SaveData.lvl-lvlStep);
        SaveData.playerChoiced = sv.savedPlayerChoiced;
        Debug.Log("GameLoaded");
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
        Debug.Log("GameSaved");
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
        Debug.Log("GameSaved");
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
