using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerMovementNR : MonoBehaviour
{
    
    public CursorControllerNR CC;
    public Vector3 destination;
    private GameObject currentPrefab;
    private bool hasSpawned;

    [SerializeField] private MapCollision MC;
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Tilemap map;
    
    
    void Start()
    {
        destination = player.transform.position;
        CC.controls.Mouse.MouseClick.performed += _ => MouseClick();
    }
    
    void Update()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, destination, movementSpeed * Time.deltaTime); 
        
        if (DestinationReached() && hasSpawned)
        {
            Destroy(currentPrefab);
            hasSpawned = false;
        }
    }

    private void MouseClick()
    {
        Vector2 mousePosition = CC.controls.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        
        
        if (map.HasTile(gridPosition) && MC.isValidLocation)
        {
            destination = mousePosition;
            SpawnPointer();
        }
    }

    private void SpawnPointer()
    {
        Destroy(currentPrefab);
        currentPrefab = Instantiate(prefab, destination, Quaternion.identity);
        hasSpawned = true;
    }
    
    public bool DestinationReached()
    {
        return destination == player.transform.position;
    }
}
