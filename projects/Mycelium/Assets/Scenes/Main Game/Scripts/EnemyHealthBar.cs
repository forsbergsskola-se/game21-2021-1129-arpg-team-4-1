using System;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset; //We use this, because not all enemies have the same height. 
    private Camera mainCamera;


    public void Awake()
    {
        mainCamera = Camera.main;
    }

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth); //The enemy health bar should only be visable when the enemy is not at full health.
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue); //Adjusting color to the amount of health left on enemy.
    }

    void Update()
    {
        Slider.transform.position = mainCamera.WorldToScreenPoint(transform.position + Offset);
    }
}