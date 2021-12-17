using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class CryptGate : MonoBehaviour, IClick
{
    [SerializeField] private PlayerCollisionNR PC;
    [SerializeField] private PlayerMovementNR PM;
    [SerializeField] private GameObject Player;
    [SerializeField] private LevelLoader LL;
    
    public void onClickAction()
    {
        if (PC.isClickColliding)
        {
            PM.destination = Player.transform.position;
            LL.LoadLevel(2);
        }
        else Debug.Log("Not Colliding");
    }
    
}
