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
    [SerializeField] private Animator animator;
    [SerializeField] private float enemyDespawn = 0.8f;
    //public static bool GameOver;
    void Start()
    {
        enemyHealth = maxEnemyHealth;
        slider.value = CalculateHealth();
        //GameOver = false;
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
            animator.SetBool("isDead", true);
            Destroy(gameObject, enemyDespawn );
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
