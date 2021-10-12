using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class SaveDataJson : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text coins;
    [SerializeField] private Text donateCoins;
    [SerializeField] private GameObject nickNameInput;
    [SerializeField] private PlayerChoice playerChoice;
    private GameObject selectedPlayer;
    private SavedData sv = new SavedData();
    private string path;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        path = Path.Combine(Application.dataPath, "SaveData.json");
#endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<SavedData>(File.ReadAllText(path));
            nickName.text = sv.nickName;
            coins.text = sv.savedCoins;
            donateCoins.text = sv.savedDonateCoins;
            selectedPlayer = sv.savedSelectedPlayer;
            selectedPlayer.SetActive(true);
            Debug.Log("GameLoaded");
        }
        else
        {
            nickNameInput.SetActive(true);
        } 
    }


#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) 
        {
        sv.nickName = nickName.text;
        sv.savedCoins = coins.text;
        sv.savedDonateCoins = donateCoins.text;
        sv.savedSelectedPlayer = selectedPlayer;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
        }
    }
#endif
    private void OnApplicationQuit()
    {
        sv.nickName = nickName.text;
        sv.savedCoins = coins.text;
        sv.savedDonateCoins = donateCoins.text;
        sv.savedSelectedPlayer = selectedPlayer;
        File.WriteAllText(path, JsonUtility.ToJson(sv));
        Debug.Log("GameSaved");
    }
    public void SelectedPlayer()
    {
        selectedPlayer = playerChoice.GameObjectGet();
    }
}
[Serializable]
public class SavedData 
{
    public string nickName;
    public string savedCoins;
    public string savedDonateCoins;
    public GameObject savedSelectedPlayer;
}
