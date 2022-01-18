using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float agroRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackTimer = 0.0f;
    
    public static bool GameOver;
    public float minDistance;
    private float attackCooldown = 2.5f;
    public float attackRange = 0f;
    private Rigidbody2D rb2d;
  
    
    
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        attackRange = minDistance + 0.2f;

        GameOver = false;

    }


    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            
        }
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        

        if (distToPlayer < agroRange)
        {
            ChasePlayer();

           
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

    //private IEnumerator Regen()
    //{

       
        
           //if (!InCombat)
           // {
                //EnemyHealthSO ebehaviour = GetComponent<EnemyHealthSO>();
                //if (ebehaviour.enemyHealth < ebehaviour.maxEnemyHealth)
                //{ int value = Mathf.FloorToInt(ebehaviour.maxEnemyHealth * 0.05f);
                   
                //}
           // }
        
            // How often enemy will regen
            //yield return new WaitForSeconds(1.5f);
        
       
   // }

    
    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector3.zero;
        enemyAnimator.SetBool("isAttacking", false);
    }

    private void ChasePlayer()
    {
        enemyAnimator.SetBool("isAttacking", false);

        if (Vector3.Distance(transform.position, player.position) > minDistance)
        {
            //move if distance from target is greater than distance
            transform.Translate((player.position - transform.position) * moveSpeed * Time.deltaTime);
        }
        
    }

   
    private void Attack()
    {
        
        enemyAnimator.SetBool("isAttacking", true);
        
        if (attackTimer > 0)
        {
            return;
        }
        Debug.Log("Attack");
        
       
        Player playerHealth = player.GetComponent<Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(5);
            
            Debug.Log("Hit player");
            attackTimer = attackCooldown;
        }
    }
    
}

