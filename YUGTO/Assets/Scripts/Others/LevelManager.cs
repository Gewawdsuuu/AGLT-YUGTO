using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Panel Settings")]
    public GameObject blurImage;
    public GameObject levelCompletePanel;
    public GameObject levelFailedPanel;

    public static int levelsUnlocked;
    public static int currentLevel;

    private bool levelDone = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
            AudioManager.Instance.PlayMusic("Arcane Battle Music");
        else if (SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7")
            AudioManager.Instance.PlayMusic("Battle Music 1");
        else if (SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9" || SceneManager.GetActiveScene().name == "Level 10")
            AudioManager.Instance.PlayMusic("Arcane Battle Music");


        levelsUnlocked = PlayFabManager.levelsUnlocked;

        if (SceneManager.GetActiveScene().name != "Level 1")
            currentLevel = int.Parse(HeroSelection.levelName);

        Debug.Log("Current Level: " + currentLevel);
    }

    void Update()
    {
        CheckLevel();
        StartCoroutine(CheckLevelInterval());
    }

    public void CheckLevel()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && levelDone == false)
        {
            levelDone = true;
            LevelComplete();
        }
        else if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && levelDone == false)
        {
            levelDone = true;
            LevelFailed();
        }
    }

    IEnumerator CheckLevelInterval()
    {
        yield return new WaitForSeconds(5f);
    }

    private void LevelComplete()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
            AudioManager.Instance.StopMusic("Arcane Battle Music");
        else if (SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7")
            AudioManager.Instance.StopMusic("Battle Music 1");
        else if (SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9" || SceneManager.GetActiveScene().name == "Level 10")
            AudioManager.Instance.StopMusic("Arcane Battle Music");

        AudioManager.Instance.PlaySFX("Level Cleared");
        if (levelsUnlocked <= (currentLevel + 1))
        {
            PlayFabManager.instance.GetLevelData();
        }
        blurImage.SetActive(true);
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LevelFailed()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
            AudioManager.Instance.StopMusic("Arcane Battle Music");
        else if (SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7")
            AudioManager.Instance.StopMusic("Battle Music 1");
        else if (SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9" || SceneManager.GetActiveScene().name == "Level 10")
            AudioManager.Instance.StopMusic("Arcane Battle Music");

        AudioManager.Instance.PlaySFX("Level Failed");
        blurImage.SetActive(true);
        levelFailedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnHomeSelect()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnNextSelect()
    {
        PlayFabManager.instance.GetPlayerLevelData();
        StartCoroutine(LevelWaiter());
    }

    public void OnNextQuizLevelSelect()
    {
        if (currentLevel == 2)
        {
            currentLevel = 2;
            SceneManager.LoadScene("QuizLevel1-3");
        }
        else if (currentLevel == 6)
        {
            currentLevel = 6;
            SceneManager.LoadScene("QuizLevel4-7");
        }
        else if (currentLevel == 9)
        {
            currentLevel = 9;
            SceneManager.LoadScene("QuizLevel8-10");
        }
    }

    public void OnNextCutsceneSelect()
    {
        if (currentLevel == 3)
        {
            SceneManager.LoadScene("CutsceneLevel1Ending");
        }
        else if (currentLevel == 7)
        {
            SceneManager.LoadScene("CutsceneLevel4Ending");
        }
        else if (currentLevel == 10)
        {
            SceneManager.LoadScene("CutsceneLevel8Ending");
        }
    }

    public void OnRetrySelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator LevelWaiter()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnExitSelect()
    {
        Application.Quit();
    }
}
