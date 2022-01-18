using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptMouse : MonoBehaviour
{
    public BoxCollider2D[] colliderLayer;
    public bool isBoxes;
    
    private void Awake()
    {
        colliderLayer = GetComponentsInChildren<BoxCollider2D>();
        isBoxes = false;
    }
    
    private void OnMouseEnter()
    {
        isBoxes = true;
    }
    
    private void OnMouseExit()
    { 
        isBoxes = false;
    }
}