using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CursorManagerNR : MonoBehaviour
{
    private CompositeCollider2D collider;
    [SerializeField] private PlayerMovementNR PM;
    [SerializeField] private Texture2D cursor;
    [SerializeField] private Texture2D cursorInvalid;
    [SerializeField] private Texture2D cursorClicked;


    private void Awake()
    {
        // takes in the Collider Tilemaps' Composite Collider 2D which the onMouse methods need.
        collider = GetComponent<CompositeCollider2D>();
        
        // makes sure we start out with our default cursor
        ChangeCursor(cursor);
        
        // locks the cursor inside the game, click esc to escape the window.
        Cursor.lockState = CursorLockMode.Confined; 
    }
    
    private void OnMouseEnter()
    {
        // changes the mouse when it enters the collider, sets valid location to false since we're now over collider. 
        ChangeCursor(cursorInvalid);
        PM.isValidLocation = false;
    }
    
    
    private void OnMouseOver()
    {
        // changes the mouse when it's hovering over the collider. Not necessary but clean.
        ChangeCursor(cursorInvalid);
    }
    
    
    private void OnMouseExit()
    { 
        // changes the mouse when we leave the collider, sets the valid location to true since we're now outside of the colliders and should be able to move.
        ChangeCursor(cursor);
        PM.isValidLocation = true;
    }
    
    private void ChangeCursor(Texture2D cursorType)
    {
        //the second argument is for knowing where we click from, with a normal cursor its the top left, with a middle one its the middle.
        // in our case since the cursor is pointing to the top left we pass Vector2.zero as our argument. Alternatives to this are:
        // new Vector2 (x: int, y: int) add numbers that fits your cursors point
        // Vector2 hotspot = new Vector2(cursorType.width /2, cursorType.height /2) then pass hotspot in the second argument for a middle cursor. 
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
