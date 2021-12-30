using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Adding correct namespace. This allowes us to create a variabel that lets us store our slider.

public class PlayerHealthBar : MonoBehaviour
{
//These functions are public so we can call them from other scripts.
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health; 
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}