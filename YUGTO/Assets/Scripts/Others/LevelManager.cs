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

    private bool levelDone = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0  && levelDone == false)
        {
            levelDone = true;
            LevelComplete();
        }
        else if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            levelDone = true;
            LevelFailed();
        }
    }

    private void LevelComplete()
    {
        PlayFabManager.instance.GetLevelData();
        blurImage.SetActive(true);
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LevelFailed()
    {
        blurImage.SetActive(true);
        levelFailedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnHomeSelect()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRetryorNextSelect()
    {
        PlayFabManager.instance.GetPlayerLevelData();
        StartCoroutine(LevelWaiter());
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
