using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class HeroSelection : MonoBehaviour
{
    public static string levelName;

    public Toggle[] heroToggles;
    public static int selectedHeroes = 0;
    public int maxHeroes = 4;

    private void Start()
    {
        selectedHeroes = 0;
        Debug.Log("(HeroSelection Scene) Current Selected Level: " + levelName);

    }

    private void Update()
    {
        Debug.Log("Selected Heroes: " + selectedHeroes);
        for (int i = 0; i < heroToggles.Length; i++)
        {
            if (selectedHeroes < maxHeroes)
            {
                heroToggles[i].interactable = true;
            }
            else
            {
                if (heroToggles[i].isOn == false)
                {
                    heroToggles[i].interactable = false;
                }
            }
        }
    }

    public void OnBackSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnStartSelect()
    {
        if (levelName == "1")
            SceneManager.LoadScene("CutsceneLevel1Opening");
        else if (levelName == "4")
            SceneManager.LoadScene("CutsceneLevel4Opening");
        else if (levelName == "8")
            SceneManager.LoadScene("CutsceneLevel8Opening");
        else
            SceneManager.LoadScene("Level " + levelName);
    }
}
