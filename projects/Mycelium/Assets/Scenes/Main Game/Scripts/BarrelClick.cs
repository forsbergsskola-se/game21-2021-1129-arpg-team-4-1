using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelClick : MonoBehaviour ,IClick
{
    private GameObject player;
    private PlayerAttack attackScript;
    private Animator playerAnimator;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        attackScript = player.GetComponent<PlayerAttack>();
        playerAnimator = player.gameObject.GetComponent<Animator>();
    }

    public void onClickAction()
    {
        playerAnimator.SetBool("isAttacking", true);
        attackScript.SetEnemyTarget(this.gameObject);
        Debug.Log("Barrel attacked");
    }
}
