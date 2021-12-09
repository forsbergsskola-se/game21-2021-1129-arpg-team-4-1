using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoxDesEU : MonoBehaviour
{
    /// <summary>
    /// If an object has the tag "player" and gets touched by the object with player tag
    /// it will get destroyed.
    /// </summary>
    /// <param name="other"></param>
    
    
    //Destroy function
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
