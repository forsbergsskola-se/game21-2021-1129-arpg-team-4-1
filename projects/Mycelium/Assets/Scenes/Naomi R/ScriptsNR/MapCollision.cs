using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MapCollision : MonoBehaviour
{
    
    private CompositeCollider2D collider;
    public bool isValidLocation;
    
    private void Awake()
    {
        collider = GetComponent<CompositeCollider2D>();
        isValidLocation = true;
    }
    
    private void OnMouseEnter()
    {
        isValidLocation = false;
    }
    
    private void OnMouseExit()
    { 
        isValidLocation = true;
    }
}
