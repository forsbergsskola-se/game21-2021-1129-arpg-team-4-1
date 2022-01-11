using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthSO : MonoBehaviour
{
    public float enemyHealth;
    public float maxEnemyHealth;

    public GameObject heathBarUI;
    public Slider slider;
    
    void Start()
    {
        enemyHealth = maxEnemyHealth;
        slider.value = CalculateHealth();
    }

   
    void Update()
    {
        slider.value = CalculateHealth();

        if (enemyHealth < maxEnemyHealth)
        {
            heathBarUI.SetActive(true);
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (enemyHealth > maxEnemyHealth)
        {
            enemyHealth = maxEnemyHealth;
        }
    }

    float CalculateHealth()
    {
        return enemyHealth / maxEnemyHealth;
    }
}
