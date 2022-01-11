using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerExperimentation : MonoBehaviour
{
     public MouseInput controls;
    private Camera mainCamera;
    
    [SerializeField] private MapCollision MC;
    [SerializeField] private EnemyCollision EC;
    [SerializeField] private DestroyableObjectCollision DO;
    
    [SerializeField] private Texture2D cursorDefault;
    [SerializeField] private Texture2D cursorInvalid;
    [SerializeField] private Texture2D cursorAttack;

    private void Awake()
    {
        controls = new MouseInput();
        mainCamera = Camera.main;
        
        ChangeCursor(cursorDefault);
        Cursor.lockState = CursorLockMode.Confined; 
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Mouse.MouseClick.started += _ => StartedClick();
        controls.Mouse.MouseClick.performed += _ => EndedClick();
    }

    private void FixedUpdate()
    {
        if (MC.isValidLocation && !EC.isEnemy && !DO.isObject)
        {
            ChangeCursor(cursorDefault);
        }
        if (MC.isValidLocation == false)
        {
            ChangeCursor(cursorInvalid);
        }
        if (EC.isEnemy || DO.isObject)
        {
            ChangeCursor(cursorAttack);
        }

    }

    public void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.MousePosition.ReadValue<Vector2>());
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null) 
        {
            IClick click = hits2D.collider.gameObject.GetComponent<IClick>();
            if (click != null) click.onClickAction();
        }
    }

    private void StartedClick()
    {
       // null
    }
    
    private void EndedClick()
    {
        DetectObject();
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, new Vector2 (0, 0), CursorMode.Auto);
    }
    
}