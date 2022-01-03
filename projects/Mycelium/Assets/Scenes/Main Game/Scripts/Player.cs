using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; //Player max health is 100
    public int currentHealth; //Player current health
    public PlayerHealthBar healthBar; //Reference to player health bar

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //When we start our game, players health will be set to max health
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    //Everytime we press the space bar, player takes 20 damage
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //When taking damage, we subtract damage from players current health
        healthBar.SetHealth(currentHealth);
    }
}