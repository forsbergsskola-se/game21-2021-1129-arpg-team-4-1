using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDieEU : MonoBehaviour
{
    public int barrelmaxHealth = 10;
    int barrelcurrentHealth;

    bool destroyed = false;
    public Animator animator;
    
   
    void Start()
    {
        barrelcurrentHealth = barrelmaxHealth;
    }

    public void TakeDamage(int damage)
    {
        // subtracts health
        barrelcurrentHealth -= damage;
        
        // Animation and function for destroying object
    
        if (barrelcurrentHealth <= 0)
        {
            destroyed = true;
            animator.SetBool("IsDestroyed", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }


}
