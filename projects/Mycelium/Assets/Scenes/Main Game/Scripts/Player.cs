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
    public static float regenSpeed; //Regen speed (wait time)
    public static float regenWaitTime; //Time before regen starts
    static bool isRegen = false; //If regening
    bool canRegen = true; //If can regen
    
    
    void Start()
    {
        currentHealth = maxHealth; //When we start our game, players health will be set to max health
        healthBar.SetMaxHealth(maxHealth);
        gameOver = false;
    }

    private Coroutine coroutine;
    void Update()
    //Everytime we press the space bar, player takes 20 damage
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (currentHealth < 0)
        {
            gameOver = true;
        } 
        else if (currentHealth != maxHealth && !isRegen)
        { //If they have health less than max
            //coroutine = Regen();
            //StartCoroutine(coroutine); //Start regen
        }
    }

    private void StartCoroutine(Coroutine methodName)
    {
        throw new NotImplementedException();
    }

    IEnumerable<WaitForSeconds> couroutine = Regen();

    static IEnumerable<WaitForSeconds> Regen(){
        isRegen = true; //Set regenning to true
        yield return new WaitForSeconds(regenWaitTime); //Wait for delay
 
        while(currentHealth<maxHealth){ //Start the regen cycle
            currentHealth += 1; //Increase health by 1
            yield return new WaitForSeconds(regenSpeed); //Wait for regen speed
        }
        isRegen = false; //Set regenning to false
    }

    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //When taking damage, we subtract damage from players current health
        healthBar.SetHealth(currentHealth);
        
        if (isRegen)
        {
            StopCoroutine(couroutine);
            isRegen = !isRegen;
        }
        if (currentHealth <= 0)
        {
            //Die
        }
       
    }

    private void StopCoroutine(IEnumerable<WaitForSeconds> methodName)
    {
        
    }
}