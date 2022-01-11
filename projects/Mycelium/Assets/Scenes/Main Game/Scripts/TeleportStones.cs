using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStones : MonoBehaviour, IClick
{
    [SerializeField] private PlayerCollisionNR PC;
    [SerializeField] private GameObject Player;
    [SerializeField] private PlayerMovementExperimentation PM;
    [SerializeField] private GameObject NextStatue;
    [SerializeField] private Vector3 offset;
    private bool hasTeleported;

    public void onClickAction()
    {
        if (PC.isClickColliding)
        {
            Player.transform.position = NextStatue.transform.position + offset;
            hasTeleported = true;
        }
        else Debug.Log("Not close enough");
    }

    public void FixedUpdate()
    {
        if (hasTeleported)
        {
            PM.destination = NextStatue.transform.position + offset;
            hasTeleported = false;
        }
    }
}
