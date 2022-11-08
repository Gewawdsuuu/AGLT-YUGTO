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
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
            AudioManager.Instance.PauseMusic("Arcane Battle Music");
        else if (SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7")
            AudioManager.Instance.PauseMusic("Battle Music 1");
        else if (SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9" || SceneManager.GetActiveScene().name == "Level 10")
            AudioManager.Instance.PauseMusic("Arcane Battle Music");

        skillsPanel.SetActive(false);
        blurImage.SetActive(true);
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeSelect()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
            AudioManager.Instance.PlayMusic("Arcane Battle Music");
        else if (SceneManager.GetActiveScene().name == "Level 4" || SceneManager.GetActiveScene().name == "Level 5" || SceneManager.GetActiveScene().name == "Level 6" || SceneManager.GetActiveScene().name == "Level 7")
            AudioManager.Instance.PlayMusic("Battle Music 1");
        else if (SceneManager.GetActiveScene().name == "Level 8" || SceneManager.GetActiveScene().name == "Level 9" || SceneManager.GetActiveScene().name == "Level 10")
            AudioManager.Instance.PlayMusic("Arcane Battle Music");


        skillsPanel.SetActive(true);
        blurImage.SetActive(false);
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnHomeSelect()
    {
        AudioManager.Instance.PlayMusic("Main Menu");
        blurImage.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
