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

    // Update is called once per frame
    void Update()
    {
        goldValueText.text = "Gold: " + goldValue.ToString();
    }

    public void BuyItem()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "GD",
            Amount = 10
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractGoldSuccess, OnError);
    }

    void OnSubtractGoldSuccess(ModifyUserVirtualCurrencyResult result)
    {
        // Code to add item to player inventory
        Debug.Log("Subtracted 10 gold!");
        PlayFabManager.instance.GetVirtualCurrency();
    }

    // Testing Giving gold
    public void GrantVirtualCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "GD",
            Amount = 10
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantGoldSuccess, OnError);
    }

    void OnGrantGoldSuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Added 10 Gold!");
        PlayFabManager.instance.GetVirtualCurrency();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
