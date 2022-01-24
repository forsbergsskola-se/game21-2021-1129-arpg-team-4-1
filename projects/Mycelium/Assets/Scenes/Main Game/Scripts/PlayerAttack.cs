using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyTargeted;
    [SerializeField] private EnemyHealthSO enemyHealth;
    [SerializeField] private BarrelDieEU barrelHealth;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float attackRange = 0.1f;
    [SerializeField] private float attackTimer = 0.0f;
    [SerializeField] private Transform player;
    private float attackCooldown = 2.5f; 
  
    
    void Update()
    {
        if (enemyTargeted == null)
        { 
            playerAnimator.SetBool("isAttacking", false);
            
            return;
        }
        float distToEnemy = Vector3.Distance(transform.position, enemyTargeted.transform.position);
        
        if (distToEnemy <= attackRange)
        {
            Attack(); 
           // Debug.Log("Attacking");
        }
        else
        {
            playerAnimator.SetBool("isAttacking", false);
        }
        
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            //Debug.Log("attacktimer"+ attackTimer);
        }

        if (Player.gameOver)
        {
         this.enabled = false;
        }
    }

    public void SetEnemyTarget(GameObject newTarget)
    {
        if (newTarget == null)
        {
            return;
        }
        enemyTargeted = newTarget; 
        enemyHealth = enemyTargeted.GetComponent<EnemyHealthSO>();
        barrelHealth = enemyTargeted.GetComponent<BarrelDieEU>();

    } 
    
    private void Attack()
    {
        if (attackTimer > 0)
        {
            return;
        }
        //Debug.Log("Attack enemy");
        attackTimer = attackCooldown;
        
        
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(40);
            playerAnimator.SetBool("isAttacking", true);
            
            
            //Debug.Log("Hit enemy");
           attackTimer = attackCooldown;
        } 
        
        
        if (barrelHealth != null)
        {
            barrelHealth.TakeDamage(10);
            //Debug.Log("Hit Barrel");
            attackTimer = attackCooldown;
        }
    }
}
