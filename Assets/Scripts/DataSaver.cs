using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataSaver : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text coins;
    [SerializeField] private Text donateCoins;
    private string nick;
    private string coinsgame;
    private string donate;
    DataSaver loadedData = null;
    void Start()
    {
        //loadedData instance is created once
        loadedData = new DataSaver();
        Debug.Log(nickName);

    }

    public void Save()
    {
        DataSaver saveData = new DataSaver();
        saveData.nick = nickName.text;
        saveData.coinsgame = coins.text;
        
        saveData.donate = donateCoins.text;

        //Convert to Json
        string jsonData = JsonUtility.ToJson(saveData);
        //Save Json string
        PlayerPrefs.SetString("MySettings", jsonData);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        string jsonData = PlayerPrefs.GetString("MySettings");
        //Convert to Class but don't create new Save Object. Re-use loadedData and overwrite old data in it
        JsonUtility.FromJsonOverwrite(jsonData, loadedData);
        Debug.Log("Nickname: " + loadedData.nickName);
    }
}
