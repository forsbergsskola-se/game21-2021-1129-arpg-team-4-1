using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemySO : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack
        }
    }
}
