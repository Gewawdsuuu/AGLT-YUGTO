using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [Header("Button On click settings")]
    [SerializeField] private string playButtonScene;

    [Header("Canvas Settings")]
    [SerializeField] public Canvas settingsCanvas;

    [Header("Disabled Buttons")]
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button BurgerButton;
    [SerializeField] private Button ProfileButton;
    [SerializeField] private Button HeroButton;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ShopButton;
    [SerializeField] private Button ExitButton;

    [Header("Image Settings")]
    [SerializeField] private Image menuImage;
    [SerializeField] private Image logoImage;
    [SerializeField] private Image lineImage;
    [SerializeField] private Color normalAlpha;
    [SerializeField] private Color reducedAlpha;

    [Header("Hero Button Settings")]
    [SerializeField] private GameObject MenuGroup;
    [SerializeField] private GameObject HeroGroup;

    private bool a = false;
    private bool isMenuActive;

    private void Start()
    {
        Time.timeScale = 1f;
        PlayFabManager.instance.GetPlayerLevelData();
    }

    private void disableButton(bool disabler)
    {
        settingsButton.interactable = disabler;
        BurgerButton.interactable = disabler;
        ProfileButton.interactable = disabler;
        HeroButton.interactable = disabler;
        PlayButton.interactable = disabler;
        ShopButton.interactable = disabler;
        ExitButton.interactable = disabler;
    }

    private void changeAlpha(Color color)
    {
        menuImage.color = color;
        logoImage.color = color;
        lineImage.color = color;
    }

    public void settingsPopUp()
    {
        if (a == false)
        {
            a = true;
            settingsCanvas.enabled = true;
            disableButton(false);
            changeAlpha(reducedAlpha);

        }
        else if (a == true)
        {
            a = false;
            settingsCanvas.enabled = false;
            disableButton(true);
            changeAlpha(normalAlpha);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCloseHero()
    {
        if (MenuGroup != null)
        {
            isMenuActive = MenuGroup.activeSelf;
            HeroGroup.SetActive(isMenuActive);
            MenuGroup.SetActive(!isMenuActive);
        }
    }

    public void PlayOnClick()
    {
        StartCoroutine(WaitBeforePlay());
    }

    public void ShopOnClick()
    {
        SceneManager.LoadScene("Shop");
    }

    IEnumerator WaitBeforePlay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(playButtonScene);
    }
}
