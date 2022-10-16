using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{

    [Header("Default Input Fields")]
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    [Header("Forgot Password Input Fields")]
    public TMP_InputField forgotEmailInput;

    private string myID;

    #region PayerData

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

}
