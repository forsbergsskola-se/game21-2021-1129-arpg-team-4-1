using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private MouseInput mouseInput;
    private Vector3 destination;
    private GameObject currentPrefab;
    private bool hasSpawned;
    public bool isValidLocation;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Tilemap map;


    private void Awake()
    {
        mouseInput = new MouseInput();
        isValidLocation = true;
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
    
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime); 
        
        if (destinationReached() && hasSpawned)
        {
            Destroy(currentPrefab);
            hasSpawned = false;
        }
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        

        //makes sure we are clicking on a tile 
        if (map.HasTile(gridPosition) && isValidLocation)
        {
            destination = mousePosition;
            spawnPointer();
        }

    }

    private void spawnPointer()
    {
        Destroy(currentPrefab);
        currentPrefab = Instantiate(prefab, destination, Quaternion.identity);
        hasSpawned = true;
    }


    private bool destinationReached()
    {
        return destination == transform.position;
    }
    
}
