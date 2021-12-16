using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionNr : MonoBehaviour
{
    public bool isClickColliding;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider != null && collider.tag == "Clickable")
        {
            isClickColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider != null && collider.tag == "Clickable")
        {
            isClickColliding = false;
        }
    }
}
