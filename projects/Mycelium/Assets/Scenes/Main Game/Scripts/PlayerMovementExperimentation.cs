using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovementExperimentation : MonoBehaviour
{ 
    public Vector3 destination;
    
    private GameObject currentPrefab;
    private bool hasSpawned;
    

    [SerializeField] private CursorControllerExperimentation CC;
    [SerializeField] private MapCollision MC;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Tilemap map;
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed;
    
    
    
    void Start()
    {
        destination = player.transform.position;
        CC.controls.Mouse.MouseClick.performed += _ => MouseClick();
        
    }
    
    void Update()
    {
        var oldPosition = player.transform.position;
        player.transform.position = Vector3.MoveTowards(player.transform.position, destination, movementSpeed * Time.deltaTime);
        var difference = player.transform.position - oldPosition;
        
        animator.SetFloat("Horizontal", difference.x);
        animator.SetFloat("Vertical", difference.y);
        SpeedFix();
        
        if (DestinationReached() && hasSpawned)
        {
            Destroy(currentPrefab);
            hasSpawned = false;
        }

        if (Player.gameOver)
        {
            this.enabled = false;
        }
    }

    
     private void SpeedFix()
    {
        if (DestinationReached())
        {
            animator.SetFloat("Speed", 0);
        }
        else animator.SetFloat("Speed", destination.sqrMagnitude);
        
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