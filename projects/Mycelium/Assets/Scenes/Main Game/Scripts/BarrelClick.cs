using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelClick : MonoBehaviour ,IClick
{
    public GameObject player;
    private PlayerAttack attackScript;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        attackScript = player.GetComponent<PlayerAttack>();
    }

    public void onClickAction()
    {
        attackScript.SetEnemyTarget(this.gameObject);
        Debug.Log("Barrel attacked");
    }
}
