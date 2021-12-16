using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CryptGate : MonoBehaviour, IClick
{
    [SerializeField] private PlayerCollisionNr PC;
    
    public void onClickAction()
    {
        if (PC.isClickColliding)
        {
            Debug.Log("you clicked gate");
            Destroy(gameObject);
        }
        else Debug.Log("Not Colliding");
    }
    
}
