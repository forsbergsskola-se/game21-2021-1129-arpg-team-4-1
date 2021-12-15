using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerMovementNR : MonoBehaviour
{
    
    private MouseInput controls;
    private Vector3 destination;
    private GameObject currentPrefab;
    private bool hasSpawned;

    [SerializeField] private MapCollision MC;
    [SerializeField] private GameObject player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Tilemap map;
    
    
    private void Awake()
    {
        controls = new MouseInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        destination = player.transform.position;
        controls.Mouse.MouseClick.performed += _ => MouseClick();
    }
    
    void Update()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, destination, movementSpeed * Time.deltaTime); 
        
        if (destinationReached() && hasSpawned)
        {
            Destroy(currentPrefab);
            hasSpawned = false;
        }
    }

    private void MouseClick()
    {
        Vector2 mousePosition = controls.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        
        
        if (map.HasTile(gridPosition) && MC.isValidLocation)
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
        return destination == player.transform.position;
    }
    
}
