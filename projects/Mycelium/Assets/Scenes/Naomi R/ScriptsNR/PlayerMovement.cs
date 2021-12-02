using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    private Vector3 destination;
    [SerializeField] private float movementSpeed;
    public bool canMove;


    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }

    void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        
        //makes sure we are clicking on a tile 
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform. position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime); 
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        Debug.Log(hit);
        if (hit.gameObject.tag == "Collider")
        {
            destination = transform.position;
        }
    }
}
