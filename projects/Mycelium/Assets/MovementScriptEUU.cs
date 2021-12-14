using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptEUU : MonoBehaviour
{
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }
}
