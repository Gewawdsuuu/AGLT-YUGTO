using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewShopManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI goldValueText;

    public static int goldValue;

    [Header("Main Shop Buttons")]
    public Button healthPotionButton;
    public Button manaPotionButton;
    public Button mainExitButton;

    [Header("Panel Settings")]
    public GameObject healthPanel;
    public GameObject manaPanel;

    [Header("Image Settings")]
    public Image healthImage;
    public Image manaImage;
    public Color normalAlpha;
    public Color reducedAlpha;

    [Header("Health Panel Settings")]
    public Button healthPlus;
    public Button healthMinus;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthTotalText;

    [Header("Mana Panel Settings")]
    public Button manaPlus;
    public Button manaMinus;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI manaTotalText;

    private bool isHealthOpen;
    private bool isManaOpen;

    private int numberOfHealth = 1;
    private int numberOfMana = 1;

    private int price = 200;

    private void Start()
    {
        isHealthOpen = false;
        isManaOpen = false;

        numberOfHealth = 1;
        numberOfMana = 1;
    }

    private void Update()
    {
        // The value of this gold comes from the PlayFabManager Script;
        goldValueText.text = "Gold: " + goldValue.ToString();

        if (goldValue < (price * numberOfHealth))
        {
            numberOfHealth--;
            healthText.text = numberOfHealth.ToString();
            healthTotalText.text = "Total: " + (price * numberOfHealth).ToString();
        }

        if (goldValue < (price * numberOfMana))
        {
            numberOfMana--;
            manaText.text = numberOfMana.ToString();
            manaTotalText.text = "Total: " + (price * numberOfMana).ToString();
        }

    }

    #region GoldThings
    public void BuyHealthPotion()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "GD",
            Amount = price * numberOfHealth
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnBuyHealthSuccess, OnError);
    }

    void OnBuyHealthSuccess(ModifyUserVirtualCurrencyResult result)
    {
        // Code to add item to player inventory

        Debug.Log("Brought " + numberOfHealth + " Health Potions!");
        PlayFabManager.instance.GetVirtualCurrency();
    }

    public void BuyManaPotion()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "GD",
            Amount = price * numberOfMana
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnBuyManaSuccess, OnError);
    }

    void OnBuyManaSuccess(ModifyUserVirtualCurrencyResult result)
    {
        // Code to add item to player inventory

        Debug.Log("Brought " + numberOfMana + " Mana Potions!");
        PlayFabManager.instance.GetVirtualCurrency();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion

    private void ButtonDisabler(bool disabler)
    {
        healthPotionButton.interactable = disabler;
        manaPotionButton.interactable = disabler;
        mainExitButton.interactable = disabler;
    }
    
    private void AlphaChanger(Color color)
    {
        healthImage.color = color;
        manaImage.color = color;
    }

    public void HealthPanel()
    {
        if (isHealthOpen == false)
        {
            isHealthOpen = true;
            healthPanel.SetActive(true);
            ButtonDisabler(false);
            AlphaChanger(reducedAlpha);
        }
        else if (isHealthOpen == true)
        {
            isHealthOpen = false;
            healthPanel.SetActive(false);
            ButtonDisabler(true);
            AlphaChanger(normalAlpha);
        }
    }

    public void UpHealth()
    {
        if (goldValue > (price * numberOfHealth))
        {
            numberOfHealth++;
            healthText.text = numberOfHealth.ToString();
            healthTotalText.text =  "Total: " + (price * numberOfHealth).ToString();
        }
    }

    public void DownHealth()
    {
        if (numberOfHealth > 1)
        {
            numberOfHealth--;
            healthText.text = numberOfHealth.ToString();
            healthTotalText.text = "Total: " + (price * numberOfHealth).ToString();
        }
    }

    public void ManaPanel()
    {
        if (isManaOpen == false)
        {
            isManaOpen = true;
            manaPanel.SetActive(true);
            ButtonDisabler(false);
            AlphaChanger(reducedAlpha);
        }
        else if (isManaOpen == true)
        {
            isManaOpen = false;
            manaPanel.SetActive(false);
            ButtonDisabler(true);
            AlphaChanger(normalAlpha);
        }
    }

    public void UpMana()
    {
        if (goldValue > (price * numberOfMana))
        {
            numberOfMana++;
            manaText.text = numberOfMana.ToString();
            manaTotalText.text = "Total: " + (price * numberOfMana).ToString();
        }
    }

    public void DownMana()
    {
        if (numberOfMana > 1)
        {
            numberOfMana--;
            manaText.text = numberOfMana.ToString();
            manaTotalText.text = "Total: " + (price * numberOfMana).ToString();
        }
    }
}
