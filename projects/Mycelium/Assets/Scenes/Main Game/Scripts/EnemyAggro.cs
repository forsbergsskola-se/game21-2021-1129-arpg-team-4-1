using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float agroRange;

    [SerializeField] private float moveSpeed;

    public float minDistance;
    public float attackRange;
    //public GameObject sword;
    public float swingRate =1f;
    public float nextSwing;
    public float lineOfSite;
    
    
    

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        print("distToPlayer:" + distToPlayer);

        if (distToPlayer < agroRange)
        {
            ChasePlayer(); 
            
            Debug.Log("chasing");
        }

        else
        {
           StopChasingPlayer(); 
           Debug.Log("outOfRange");
        }
    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector3.zero;

    }

    private void ChasePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < agroRange) //Agro range
        {
            //rotate to look at the player
            //transform.LookAt(player.position);
           // transform.Rotate(new Vector3(0, -90, 0), Space.Self); //correcting the original rotation
        }

        if (Vector3.Distance(transform.position, player.position) < agroRange) //Agro range
        {
            //move towards the player
            if (Vector3.Distance(transform.position, player.position) > minDistance)
            {
                //move if distance from target is greater than distance
                //transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
                transform.Translate((player.position - transform.position) * moveSpeed * Time.deltaTime);
            }

            if (minDistance <= attackRange)
            {
                
            }
            
        } 
        
        
    }

    private void OnDrawGizmosSelected()
    {
       Gizmos.color = Color.green;
       Gizmos.DrawWireSphere(transform.position, lineOfSite);
       Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

