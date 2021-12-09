using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorInvalid;
    private CompositeCollider2D collider;
    [SerializeField] private PlayerMovement PM;


    private void Awake()
    {
        // takes in the Collider Tilemaps' Composite Collider 2D which the onMouse methods need.
        collider = GetComponent<CompositeCollider2D>();
        
        ChangeCursor(cursor);
        
        // keeps the cursor inside the game, click esc to escape the window.
        Cursor.lockState = CursorLockMode.Confined; 
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, new Vector2 (0, 0), CursorMode.Auto);
    }

   
    private void OnMouseEnter()
    {
        // changes the mouse when it enters the collider, sets valid location to false since we're now over collider. 
       ChangeCursor(cursorInvalid);
       PM.isValidLocation = false;
    }
    
    
    private void OnMouseOver()
    {
        // changes the mouse when it's hovering over the collider. Not necessary but clean. Also makes sure the valid location is still false.
        ChangeCursor(cursorInvalid);
        PM.isValidLocation = false;
    }
    
    
    private void OnMouseExit()
    { 
        // changes the mouse when we leave the collider, sets the valid location to true since we're now outside of the colliders and should be able to move.
        ChangeCursor(cursor);
        PM.isValidLocation = true;
    }
}
