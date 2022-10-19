using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroToggleHandler : MonoBehaviour
{
    private Toggle heroToggle;

    private void Start()
    {
        heroToggle = this.GetComponent<Toggle>();
    }

    public void ButtonClick()
    {
        if (heroToggle.isOn)
        {
            HeroSelection.selectedHeroes += 1;
        }
        else
        {
            HeroSelection.selectedHeroes -= 1;
        }
    }
}
