using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthSlider;
    public Health playerHealth;

    private void Start()
    {
        
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = healthSlider.maxValue;
    }
    public void SetHealth(int hp)
    {
        healthSlider.value = hp;
    }
}
