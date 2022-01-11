using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportStones : MonoBehaviour, IClick
{
    [SerializeField] private PlayerCollisionNR PC;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject NextStatue;
    [SerializeField] private Vector3 offset;

    public void onClickAction()
    {
        if (PC.isClickColliding)
        {
            Player.transform.position = NextStatue.transform.position + offset;
        }
        else Debug.Log("Not close enough");
    }

}
