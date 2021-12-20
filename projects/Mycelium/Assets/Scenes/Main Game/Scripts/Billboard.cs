using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    //Using LateUpdate instead of Update to avoid jitter
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
