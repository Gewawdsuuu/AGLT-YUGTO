using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayFabShopManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI goldValueText;

    public static int goldValue;

    [Header("Panel Settings")]
    public GameObject shopPanel;
    public GameObject AttributesPanel;
    public GameObject skillsPanel;

    [Header("Attributes Submenu Settings")]
    public float attributesAvailable;
    public float currentStrength;
    public float currentAgility;
    public float currentIntelligence;

    public TextMeshProUGUI attributesAvailableText;
    public TextMeshProUGUI strengthCountText;
    public TextMeshProUGUI agilityCountText;
    public TextMeshProUGUI intelligenceCountText;

    private void Start()
    {
        attributesAvailableText.text = attributesAvailable.ToString();
        currentStrength = 0;
        currentAgility = 0; 
        currentIntelligence = 0;
    }

    void Update()
    {
        //goldValueText.text = "Gold: " + goldValue.ToString();
    }

    #region GoldThings
    //public void BuyItem()
    //{
    //    var request = new SubtractUserVirtualCurrencyRequest
    //    {
    //        VirtualCurrency = "GD",
    //        Amount = 10
    //    };
    //    PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractGoldSuccess, OnError);
    //}

    //void OnSubtractGoldSuccess(ModifyUserVirtualCurrencyResult result)
    //{
    //    // Code to add item to player inventory
    //    Debug.Log("Subtracted 10 gold!");
    //    PlayFabManager.instance.GetVirtualCurrency();
    //}

    //// Testing Giving gold
    //public void GrantVirtualCurrency()
    //{
    //    var request = new AddUserVirtualCurrencyRequest
    //    {
    //        VirtualCurrency = "GD",
    //        Amount = 10
    //    };
    //    PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantGoldSuccess, OnError);
    //}

    //void OnGrantGoldSuccess(ModifyUserVirtualCurrencyResult result)
    //{
    //    Debug.Log("Added 10 Gold!");
    //    PlayFabManager.instance.GetVirtualCurrency();
    //}

    //void OnError(PlayFabError error)
    //{
    //    Debug.Log(error.GenerateErrorReport());
    //}
    #endregion

    #region MainShop
    public void OnAttributesClick()
    {
        shopPanel.SetActive(false);
        AttributesPanel.SetActive(true);
    }
    #endregion

    #region AttributesPanel
    public void UpStrengthButton()
    {
        if (attributesAvailable > 0)
        {
            attributesAvailable -= 1;
            currentStrength += 1;
            strengthCountText.text = currentStrength.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void DownStrengthButton()
    {
        if (currentStrength > 0)
        {
            currentStrength -= 1;
            attributesAvailable += 1;
            strengthCountText.text = currentStrength.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void UpAgilityButton()
    {
        if (attributesAvailable > 0)
        {
            attributesAvailable -= 1;
            currentAgility += 1;
            agilityCountText.text = currentAgility.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void DownAgilityButton()
    {
        if (currentAgility > 0)
        {
            currentAgility -= 1;
            attributesAvailable += 1;
            agilityCountText.text = currentAgility.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void UpIntelligenceButton()
    {
        if (attributesAvailable > 0)
        {
            attributesAvailable -= 1;
            currentIntelligence += 1;
            intelligenceCountText.text = currentIntelligence.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void DownIntelligenceButton()
    {
        if (currentIntelligence > 0)
        {
            currentIntelligence -= 1;
            attributesAvailable += 1;
            intelligenceCountText.text = currentIntelligence.ToString();
            attributesAvailableText.text = attributesAvailable.ToString();
        }
    }

    public void OnApplyClick()
    {
        currentStrength = 0;
        currentAgility = 0;
        currentIntelligence = 0;

        attributesAvailableText.text = attributesAvailable.ToString();
        strengthCountText.text = currentStrength.ToString();
        agilityCountText.text = currentAgility.ToString();
        intelligenceCountText.text = currentIntelligence.ToString();
    }

    public void CloseAttributesPanel()
    {
        shopPanel.SetActive(true);
        AttributesPanel.SetActive(false);
    }
    #endregion

    public void ExitShopClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
