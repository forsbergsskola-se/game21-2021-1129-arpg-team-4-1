using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDesEU : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Barrel")
        {
            Destroy(gameObject);
        }
    }
}
