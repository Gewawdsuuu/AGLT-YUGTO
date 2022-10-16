using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabLevelLoad : MonoBehaviour
{
    public static PlayFabLevelLoad Instance { get; set; }

    public int levelsUnlocked;

    public Button[] levelButtons;

    private void Start()
    {
        GetPlayerData();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #region PlayerData
    public void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            Keys = null
        }, GetUserDataSucess, OnError);
    }

    void GetUserDataSucess(GetUserDataResult result)
    {
        // Checks if there is no save info
        if (result.Data == null || !result.Data.ContainsKey("UnlockedLevels"))
        {
            Debug.Log("No Save Info");
        }
        // If there is a save info
        else
        {

        }
    }
    #endregion

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
