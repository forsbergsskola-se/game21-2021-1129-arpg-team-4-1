using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerNR : MonoBehaviour
{
    
    public Texture2D cursorDefault;
    public Texture2D cursorInvalid;
    public Texture2D cursorClicked;
    // public Texture2D attack;
    // public Texture2D destroyableObject;
    // public Texture2D gateLocked;
    // public Texture2D gateUnlocked;

    [SerializeField] private MapCollision MC;

        private void Awake()
    {
        ChangeCursor(cursorDefault);
        
        Cursor.lockState = CursorLockMode.Confined; 
    }

    private void FixedUpdate()
    {
        if (MC.isValidLocation)
        {
            ChangeCursor(cursorDefault);
        }
        
        if (MC.isValidLocation == false)
        {
            ChangeCursor(cursorInvalid);
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, new Vector2 (0, 0), CursorMode.Auto);
    }
    
}
