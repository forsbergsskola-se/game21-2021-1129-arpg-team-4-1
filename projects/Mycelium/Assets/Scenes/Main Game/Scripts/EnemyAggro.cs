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

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
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
        rb2d.velocity = Vector2.zero;

    }

    private void ChasePlayer()
    {
        if(Vector2.Distance(transform.position, player.position) > minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //Attack
        }
    }
}
