using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDieEU : MonoBehaviour
{
    public int barrelmaxHealth = 10;
    int barrelcurrentHealth;

    private GameObject player;
    private bool destroyed;
    public Animator animator;
    public Animator playerAnimator;
    
   
    void Start()
    {
        barrelcurrentHealth = barrelmaxHealth;
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // subtracts health
        barrelcurrentHealth -= damage;
        
        // Animation and function for destroying object
    
        if (barrelcurrentHealth <= 0)
        {
            //destroyed = true;
            animator.SetBool("IsDestroyed", true);
            GetComponent<Collider2D>().enabled = false;
            playerAnimator.SetBool("isAttacking", false);
        }
    }


}
