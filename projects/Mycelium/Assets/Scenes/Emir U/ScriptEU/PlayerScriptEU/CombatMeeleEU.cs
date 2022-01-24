using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.AI;

public class CombatMeeleEU : MonoBehaviour
{
    

    public Animator animation;

    public Transform attackPoint;
    public float attackRange = 0.5F;
    public LayerMask enemyLayers;

    public GameObject Player;
    public GameObject enemie_Player;
    

    public int attackDamage = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            
        }

    }

    void Attack()
    {
        //Play Attack animation
        //animation.SetTrigger("Attack");
        
        //Detect enemies in the range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BarrelDieEU>().TakeDamage(attackDamage);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        {
            
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
