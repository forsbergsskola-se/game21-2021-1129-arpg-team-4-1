using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthSO : MonoBehaviour
{
    public float enemyHealth;
    public float maxEnemyHealth;

    public GameObject healthBarUI;
    public Slider slider;
    [SerializeField] private Animator playerAnimator;
    
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
            healthBarUI.SetActive(true);
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            playerAnimator.SetBool("isDead", false);
        }

        if (enemyHealth > maxEnemyHealth)
        {
            enemyHealth = maxEnemyHealth;
        }
    } 
  
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage; //When taking damage, we subtract damage from players current health
        //healthBarUI.SetHealth(enemyHealth;
    } 
    
    public void SetEnemyHealth(float health)
    {
        //slider.value = ; 
       
    }
    float CalculateHealth()
    {
        return enemyHealth / maxEnemyHealth;
    }

}
