using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetValue(float health)
    {
        slider.value = health;
    }

    public void SetMax(float newMax)
    {
        slider.maxValue = newMax;
    }

    public void InitializeHealth(float newMax)
    {
        slider.maxValue = newMax;
        slider.value = newMax;
    }
}
