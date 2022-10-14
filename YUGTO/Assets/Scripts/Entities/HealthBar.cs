using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar Parameters")]
    public Slider healthbarSlider;
    public Gradient gradient;
    public Image fill;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        healthbarSlider.value = health;
        fill.color = gradient.Evaluate(healthbarSlider.normalizedValue);
    }
}
