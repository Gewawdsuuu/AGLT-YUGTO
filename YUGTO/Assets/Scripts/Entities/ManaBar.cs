using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [Header("Health Bar Parameters")]
    public Slider manabarSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxMana(float mana)
    {
        manabarSlider.maxValue = mana;
        manabarSlider.value = mana;
    }

    public void SetMana(float mana)
    {
        manabarSlider.value = mana;
    }
}
