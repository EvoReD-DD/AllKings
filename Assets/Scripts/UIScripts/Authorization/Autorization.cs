using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class Autorization : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] SaveAndLoadData sv;
    [SerializeField] private GameObject errorLogin;
    [SerializeField] private GameObject characterChoise;
    [SerializeField] private GameObject loadScreen;
    private void Awake()
    {
        if (!SaveData.authorOnce)
        {
            StartCoroutine(LoadScreen(5));
        }
        else
        {
            StartCoroutine(LoadScreen(1));
        }
    }
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Initialized();
    }
    public void Initialized()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        if (SaveData.authorOnce)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
            {
                name.text = PlayGamesPlatform.Instance.localUser.userName;
                sv.Load();
                SaveData.authorOnce = true;
            });
        }
        else
        {
            PlayGamesPlatform.Instance.Authenticate(FirstAuthorization, false);
        }
    }
    private void FirstAuthorization(bool success)
    {
        if (success)
        {
            sv.CreatePath();
            SaveData.nickName = Convert.ToString(PlayGamesPlatform.Instance.localUser.userName);
            name.text = SaveData.nickName;
            SaveData.authorOnce = true;
            if (File.Exists(SaveAndLoadData.path))
            {
                sv.Load();
            }
            else
            {
                characterChoise.SetActive(true);
            }
        }
        else
        {
            SaveData.nickName = PlayGamesPlatform.Instance.localUser.userName;
            name.text = PlayGamesPlatform.Instance.localUser.userName;
            SaveData.authorOnce = true;
            if (File.Exists(SaveAndLoadData.path))
            {
                sv.Load();
            }
            else
            {
                name.text = "Player1";
                SaveData.nickName = PlayGamesPlatform.Instance.localUser.userName;
                characterChoise.SetActive(true);
            }
        }
    }
    private IEnumerator LoadScreen(int time)
    {
        loadScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        loadScreen.SetActive(false);
    }
}
