using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called biefore the first frame update
    private float maxValue;
    public Slider slider;

    private void Start()
    {
       
    }

    public void init(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setHealth(int health)
    {
        slider.value = health;
        
    }

  
}
