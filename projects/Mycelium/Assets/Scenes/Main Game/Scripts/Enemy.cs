using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;
    float dirX, dirY;
    float moveSpeed = 5f;
    public static float healthAmount;

    void Start () {
        healthAmount = 1;
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        dirY = Input.GetAxis ("Vertical") * moveSpeed;

        if (healthAmount <= 0)
            Destroy (gameObject);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, dirY);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals ("Danger"))
            healthAmount -= 0.1f;
    }
}