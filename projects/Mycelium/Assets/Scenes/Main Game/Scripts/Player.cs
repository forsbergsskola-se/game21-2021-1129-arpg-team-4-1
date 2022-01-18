using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    public static int maxHealth = 100; //Player max health is 100
    public static int currentHealth; //Player current health
    public PlayerHealthBar healthBar; //Reference to player health bar 
    public static bool gameOver;
    public float minDistance;
    private float attackCooldown = 2.5f;
    public float attackRange = 0f;
    public Animator animator;
    
   

    void Start()
    {
        currentHealth = maxHealth; //When we start our game, players health will be set to max health
        healthBar.SetMaxHealth(maxHealth);
        attackRange = minDistance + 0.2f;
        gameOver = false; 
    }

    
    void Update()
    {
        if (currentHealth < 0)
        {
            animator.SetBool("isDead", true);

            gameOver = true;
        } 
        
     

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //When taking damage, we subtract damage from players current health
        healthBar.SetHealth(currentHealth);
        
        
    }
   
   
}