using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayFabLevelLoad : MonoBehaviour
{
    public static int levelsUnlocked;
    private string levelName;

    public Button[] levelButtons;

    private void Awake()
    {
        PlayFabManager.instance.GetPlayerLevelData();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void OnLevelSelect()
    {
        string selectedButton = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("HeroSelection");
        HeroSelection.levelName = selectedButton;
        DemoLevelHandler.currentLevel = int.Parse(selectedButton);
    }

    public void OnLevel1Select()
    {
        string selectedButton = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("CutsceneLevel1Opening");
        DemoLevelHandler.currentLevel = int.Parse(selectedButton);
    }

    public void OnDemoSelect()
    {
        SceneManager.LoadScene("CutsceneDemoStart");
    }


    public void OnSetCurrentLevelDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("User data updated!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    public void OnBackSelect()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
