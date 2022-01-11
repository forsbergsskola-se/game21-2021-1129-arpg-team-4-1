using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyTargeted;
    //[SerializeField] private enemyHealthScirpt enemyHealth;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float attackTimer = 0.0f;
    [SerializeField] private Transform player;
    private float attackCooldown = 2.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (enemyTargeted == null)
        {
            return;
        }
        float distToEnemy = Vector3.Distance(transform.position, enemyTargeted.transform.position);
        
        if (distToEnemy <= attackRange)
        {
            Attack();
        } 
        
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            //Debug.Log("attacktimer"+ attackTimer);
        }
    }

    public void SetEnemyTarget(GameObject newTarget)
    {
        if (newTarget == null)
        {
            return;
        }
        enemyTargeted = newTarget; 
        //enemyHealth = enemyTargeted.GetComponent<enemyHealthScript>();
        
    } 
    
    private void Attack()
    {
        if (attackTimer > 0)
        {
            return;
        }
        Debug.Log("Attack enemy");
        attackTimer = attackCooldown;
        //change to enemy health
        
        //if (enemyHealth != null)
        //{
          //  enemyHealth.TakeDamage(10);
            //anime here
           // Debug.Log("Hit enemy");
           // attackTimer = attackCooldown;
        //} 


        BarrelDieEU barrelHealth = player.GetComponent<BarrelDieEU>();
        if (barrelHealth != null)
        {
            barrelHealth.TakeDamage(10);
            //anime here
            Debug.Log("Hit Barrel");
            attackTimer = attackCooldown;
        }
    }
}
