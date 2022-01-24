using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemySO : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    private int currentPointIndex;

    private bool once;        
    // Update is called once per frame
    void Update()
    {
        if(transform.position != patrolPoints[currentPointIndex].position)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position,
                speed * Time.deltaTime);
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
