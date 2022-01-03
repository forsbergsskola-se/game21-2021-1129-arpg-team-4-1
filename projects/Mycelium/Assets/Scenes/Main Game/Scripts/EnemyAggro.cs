using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float agroRange;

    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float attackTimer = 0.0f;
    
    public float minDistance;
    public float lineOfSite;
    private float attackCooldown = 2.0f;
    public float attackRange = 0f;
    

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        attackRange = minDistance + 0.2f;
    }


    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            //Debug.Log("attacktimer"+ attackTimer);
        }
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        

        if (distToPlayer < agroRange)
        {
            ChasePlayer(); 
            Debug.Log("chasingPlayer");
            
        }
        else
        {
           StopChasingPlayer(); 
          
        }

        if (distToPlayer <= attackRange)
        {
            Attack();
        }
        
    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector3.zero;

    }

    private void ChasePlayer()
    {

        if (Vector3.Distance(transform.position, player.position) > minDistance)
        {
            //move if distance from target is greater than distance
            //transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            transform.Translate((player.position - transform.position) * moveSpeed * Time.deltaTime);
        }
        
    }

   
    private void Attack()
    {
        if (attackTimer > 0)
        {
            return;
        }
        Debug.Log("Attack");
        Player playerHealth = player.GetComponent<Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(5);
            //anime here
            Debug.Log("Hit player");
            attackTimer = attackCooldown;
        }
    }
    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.green;
       Gizmos.DrawWireSphere(transform.position, lineOfSite);
       //Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

