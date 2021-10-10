using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SaverData : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text donateCoinsToSave;
    [SerializeField] private Text moneyCoinsToSave;
    [SerializeField] private Text levelToSave;
    private GameObject playerPrefabToSave;
    public bool boolToSave;


    private void Awake()
    {
        LoadGame();
        DontDestroyOnLoad(this.gameObject);
    }

    public void InvokeSaveGame()
    {
        Invoke("SaveGame", 2f);
    }
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedNickName = nickName.text;
        data.savedDonateCoins = donateCoinsToSave.text;
        data.savedMoneyCoins = moneyCoinsToSave.text;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            nickName.text = data.savedNickName;
            donateCoinsToSave.text = data.savedDonateCoins;
            moneyCoinsToSave.text = data.savedMoneyCoins;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            nickName.text = "";
            donateCoinsToSave.text = "0";
            moneyCoinsToSave.text = "0";
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

}

[Serializable]
public class SaveData
{
    public string savedNickName;
    public string savedDonateCoins;
    public string savedMoneyCoins;
    public string savedLevel;
    public bool savedBool;
}
