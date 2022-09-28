using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [Header("Canvas Settings")]
    [SerializeField] public Canvas settingsCanvas;
    [SerializeField] public bool a = false;

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

    // Private Methods
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

    // Public Methods
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
}
