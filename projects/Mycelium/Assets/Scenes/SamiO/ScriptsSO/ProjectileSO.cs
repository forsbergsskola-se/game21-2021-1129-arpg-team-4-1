using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSO : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed;


    private void Start()
    {
        targetPosition = FindObjectOfType<CharCont>().transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
