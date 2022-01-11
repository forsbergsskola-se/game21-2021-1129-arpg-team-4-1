using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DOExperimentation : MonoBehaviour
{
    public bool isObject;
    
    private void FixedUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other != null && other.tag == "Barrel")
        {
            isObject = true;
        }
        else isObject = false;
    }
}
