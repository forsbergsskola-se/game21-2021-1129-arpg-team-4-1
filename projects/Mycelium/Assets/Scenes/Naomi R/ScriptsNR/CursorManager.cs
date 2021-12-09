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
        collider = GetComponent<CompositeCollider2D>();
        ChangeCursor(cursor);
        
        //keeps the cursor inside the game, click esc to escape the window
        Cursor.lockState = CursorLockMode.Confined; 
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, new Vector2 (0, 0), CursorMode.Auto);
    }

    //changes the mouse when it enters the collider.
    private void OnMouseEnter()
    {
       ChangeCursor(cursorInvalid);
       PM.isValidLocation = false;
    }
    
    //changes the mouse when it's hovering over the collider. Not necessary but clean.
    private void OnMouseOver()
    {
        ChangeCursor(cursorInvalid);
        PM.isValidLocation = false;
    }
    
    //changes the mouse when we leave the collider.
    private void OnMouseExit()
    { 
        ChangeCursor(cursor);
        PM.isValidLocation = true;
    }
}
