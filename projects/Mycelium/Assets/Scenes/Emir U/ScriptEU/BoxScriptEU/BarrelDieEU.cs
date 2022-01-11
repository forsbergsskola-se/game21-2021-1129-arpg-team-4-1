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
    
    // Start is called before the first frame update
    void Start()
    {
        barrelcurrentHealth = barrelmaxHealth;
    }

    public void TakeDamage(int damage)
    {
        // substracts health
        barrelcurrentHealth -= damage;
        
        // Animation and fucntion for destroying object
    
        if (barrelcurrentHealth <= 0)
        {
            Destroy(gameObject, 2);
            destroyed = true;
            animator.SetBool("IsDestroyed", true);
            GetComponent<Collider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
