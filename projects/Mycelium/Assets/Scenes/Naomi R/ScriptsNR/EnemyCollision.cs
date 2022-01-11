using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BoxCollider2D colliderLayer;
    public bool isEnemy;
    
    private void Awake()
    {
        colliderLayer = GetComponent<BoxCollider2D>();
        isEnemy = false;
    }
    
    private void OnMouseEnter()
    {
        isEnemy = true;
    }
    
    private void OnMouseExit()
    { 
        isEnemy = false;
    }
}
