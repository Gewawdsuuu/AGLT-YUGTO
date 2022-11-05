using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginPanelHandler : MonoBehaviour
{
    public GameObject defaultPanel;
    public GameObject forgotPanel;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;


    private bool isDefaultActive;

    public void OpenCloseForgot()
    {
        if (defaultPanel != null)
        {
            isDefaultActive = defaultPanel.activeSelf;
            forgotPanel.SetActive(isDefaultActive);
            defaultPanel.SetActive(!isDefaultActive);
            emailInput.text = "";
            passwordInput.text = "";
        }
    }
}
