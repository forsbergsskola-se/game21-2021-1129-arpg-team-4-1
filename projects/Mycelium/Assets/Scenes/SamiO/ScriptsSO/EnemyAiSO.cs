using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiSO : MonoBehaviour
{
  public float speed;
  public Transform target;
  public float minimumDistance;

  private void Update()
  {
    if (Vector3.Distance(transform.position, target.position) > minimumDistance)
    {
      transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
   //else
   // {
      //attack
    //}

  }
}