using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabLevelLoad : MonoBehaviour
{

    public static int levelsUnlocked;

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
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i] != null && levelButtons[i].interactable)
            {
                SceneManager.LoadScene("Level " + levelButtons[i].name);
            }
        }
    }

}
