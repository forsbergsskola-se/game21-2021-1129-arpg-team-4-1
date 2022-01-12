using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    public Transform[] patrolPoints;
    [SerializeField] private Animator enemyAnimator;
    public float speed;
    public float waitTime;
    private int currentPointIndex;

    private bool once;        
    
    void Update()
    {
        
        if(transform.position != patrolPoints[currentPointIndex].position)
        {
            var oldPosition = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            var difference = transform.position - oldPosition;
            enemyAnimator.SetFloat("Horizontal", difference.x);
            enemyAnimator.SetFloat("Vertical", difference.y);
            enemyAnimator.SetFloat("Speed", difference.magnitude);
            
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
            
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }

        once = false;

    }
}


