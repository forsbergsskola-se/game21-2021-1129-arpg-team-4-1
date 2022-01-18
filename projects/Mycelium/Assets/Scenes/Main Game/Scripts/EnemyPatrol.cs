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
            
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            enemyAnimator.SetFloat("Horizontal", transform.position.x);
            enemyAnimator.SetFloat("Vertical", transform.position.y);
            SpeedFix();
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
            
        } 
        
        if (EnemyHealthSO.GameOver)
        {
            //disable animator
            this.enabled = false;
        }

       
    }
    
    private void SpeedFix()
    {
        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            enemyAnimator.SetFloat("Speed", 0);
        }
        else enemyAnimator.SetFloat("Speed", transform.position.sqrMagnitude);
        
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


