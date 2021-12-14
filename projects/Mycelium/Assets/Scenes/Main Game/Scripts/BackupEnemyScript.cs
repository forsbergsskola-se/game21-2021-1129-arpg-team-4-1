using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupEnemyScript : MonoBehaviour
{
  public float speed;
  public float checkRadius;
  public float attackRadius;

  public bool shouldRotate;

  public LayerMask whatIsPlayer;

  private Transform target;
  private Rigidbody2D rb;
  private Animator anim;
  private Vector2 movement;
  public Vector3 dir;

  private bool isInChaseRange;
  private bool isInAttackRange;


  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    target = GameObject.FindWithTag("Player").transform;
  }

  private void Update()
  {
    anim.SetBool("runAnimation", isInChaseRange );

    isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
    isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

    dir = target.position - transform.position;
    //float angle = Mathf.Atan(dir.y, dir.x) * Mathf.Rad2Deg;
    dir.Normalize();
    movement = dir;
    
  }
}
