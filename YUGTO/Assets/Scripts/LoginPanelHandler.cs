using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanelHandler : MonoBehaviour
{
    public GameObject defaultPanel;
    public GameObject forgotPanel;

    private bool isDefaultActive;

    public void OpenCloseForgot()
    {
        if (defaultPanel != null)
        {
            isDefaultActive = defaultPanel.activeSelf;
            forgotPanel.SetActive(isDefaultActive);
            defaultPanel.SetActive(!isDefaultActive);
        }
    }
}
