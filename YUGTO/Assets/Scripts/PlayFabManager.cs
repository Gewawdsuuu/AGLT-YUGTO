using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager instance;

    [Header("PlayFabCharacterData")]
    public PlayFabCharacterData characterData;

    public static int levelsUnlocked;
    public static int goldValue;

    [Header("Default Input Fields")]
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    [Header("Forgot Password Input Fields")]
    public TMP_InputField forgotEmailInput;

    private string myID;

    private void Awake()
    {
        instance = this;
    }

    #region PlayerLevelData
    public void GetPlayerLevelData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest
        {
            Keys = null
        }, OnGetUserLevelDataSuccess, OnError);
    }

    public void OnGetUserLevelDataSuccess(GetUserDataResult result)
    {
        // Checks if there is no save info
        if (result.Data == null || !result.Data.ContainsKey("UnlockedLevels"))
        {
            // If There is no save data then write a new one with the default value
            var writeRequest = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    {"UnlockedLevels", "1" }
                }
            };
            PlayFabClientAPI.UpdateUserData(writeRequest, OnSetLevelDataSuccess, OnError);
        }
        // If there is a save info
        else
        {
            levelsUnlocked = int.Parse(result.Data["UnlockedLevels"].Value);
            PlayFabLevelLoad.levelsUnlocked = levelsUnlocked;
            Debug.Log("PlayfabLevelLoad Unlocked: " + PlayFabLevelLoad.levelsUnlocked);
        }
    }

    // Used for updating level data when player finishes a level
    public void GetLevelData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest
        {
            Keys = null
        }, OnGetUpdateUserLevelSuccess, OnError);
    }

    public void OnGetUpdateUserLevelSuccess(GetUserDataResult result)
    {
        levelsUnlocked += 1;

        var writeRequest = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"UnlockedLevels", levelsUnlocked.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(writeRequest, OnDataSend, OnError);
    }

    public void OnSetLevelDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("User data updated!");
    }
    #endregion

    #region PlayerCurrencyData
    public void GetVirtualCurrency()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        goldValue = result.VirtualCurrency["GD"];
        PlayFabShopManager.goldValue = goldValue;
    }
    #endregion

    #region Register
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password must be 6 to 10 characters long";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered Successfully!";

        myID = result.PlayFabId;

        GetPlayerLevelData();
    }

    void OnRegisterError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion

    #region Login
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult login)
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful login!");

        myID = login.PlayFabId;


        // Fetch Player Data
        GetPlayerLevelData();
        GetVirtualCurrency();

        SceneManager.LoadScene("MainMenu");
    }

    void OnLoginError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    #endregion

    #region ResetPassword
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = forgotEmailInput.text,
            TitleId = "C33F5"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnResetError);
    }

    void OnResetError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }
    #endregion

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful user data send!");
    }

}
