using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject blurImage;
    public GameObject skillsPanel;

    public void OnPauseSelect()
    {
        AudioManager.Instance.PauseMusic("Arcane Battle Music");
        skillsPanel.SetActive(false);
        blurImage.SetActive(true);
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeSelect()
    {
        AudioManager.Instance.PlayMusic("Arcane Battle Music");
        skillsPanel.SetActive(true);
        blurImage.SetActive(false);
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnHomeSelect()
    {
        blurImage.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
