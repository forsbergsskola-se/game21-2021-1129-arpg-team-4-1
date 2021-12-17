using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndieMovementEU : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D Rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Movement
        Rb.MovePosition(Rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
