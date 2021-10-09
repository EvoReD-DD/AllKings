using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaverData : MonoBehaviour
{
    [SerializeField]private Text nickName;
    public float floatToSave;
    public bool boolToSave;

    private string nickNameTo;

    private void Start()
    {
        
        LoadGame();
    }
    private void Update()
    {
        nickNameTo = nickName.text;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedNickName = nickNameTo;
        data.savedFloat = floatToSave;
        data.savedBool = boolToSave;
        Debug.Log("Save" + nickNameTo);
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
            nickNameTo = data.savedNickName;
            floatToSave = data.savedFloat;
            boolToSave = data.savedBool;
            Debug.Log("load" + nickNameTo);
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
            nickNameTo = "";
            floatToSave = 0.0f;
            boolToSave = false;
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
    public float savedFloat;
    public bool savedBool;
}
