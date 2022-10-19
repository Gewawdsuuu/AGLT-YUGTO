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

    private void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            levelButtons[i].interactable = true;
        }

        Debug.Log("Unlocked Levels: " + levelsUnlocked);
    }

    public void OnLevelSelect()
    {
        string selectedButton = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("HeroSelection");
        HeroSelection.levelName = selectedButton;
    }


    public void OnSetCurrentLevelDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("User data updated!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

}
