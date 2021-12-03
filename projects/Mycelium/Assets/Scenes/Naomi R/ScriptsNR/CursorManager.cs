using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorInvalid;
    

    private void Awake()
    {
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined; //keeps the cursor inside the game
    }

    private void Update()
    {
       
    }
    
    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, new Vector2 (4, 4), CursorMode.Auto);
    }

    private void OnMouseEnter()
    {
       ChangeCursor(cursorInvalid);
    }

    private void OnMouseOver()
    {
        ChangeCursor(cursorInvalid);
    }


    private void OnMouseExit()
    { 
        ChangeCursor(cursor);
    }
}
