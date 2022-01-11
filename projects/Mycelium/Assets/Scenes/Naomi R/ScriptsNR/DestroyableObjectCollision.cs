using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjectCollision : MonoBehaviour
{
    private BoxCollider2D colliderLayer;
    public bool isObject;
    
    private void Awake()
    {
        colliderLayer = GetComponent<BoxCollider2D>();
        isObject = false;
    }
    
    private void OnMouseEnter()
    {
        isObject = true;
    }
    
    private void OnMouseExit()
    { 
        isObject = false;
    }
}
