using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    [SerializeField]
    private Transform player;
   
    [SerializeField]
    private float agroRange;
    
    [SerializeField]
    private float moveSpeed;

    public float minDistance;

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
        }

        else
        {
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector3.zero;

    }

    private void ChasePlayer()
    {
        if(Vector3.Distance(transform.position, player.position) > minDistance) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //Attack
        }
    }
}
