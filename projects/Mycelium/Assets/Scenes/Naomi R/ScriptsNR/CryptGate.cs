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
    
    public void onClickAction()
    {
        if (PC.isClickColliding)
        {
            PM.destination = Player.transform.position;
            Debug.Log("you clicked gate");
            SceneManager.LoadScene("Crypt", LoadSceneMode.Single);
        }
        else Debug.Log("Not Colliding");
    }
    
}
