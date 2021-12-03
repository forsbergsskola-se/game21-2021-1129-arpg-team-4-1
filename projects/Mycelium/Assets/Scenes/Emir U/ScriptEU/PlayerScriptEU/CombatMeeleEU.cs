using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMeeleEU : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play Attack animation
        //Detect enemies in the range of attack
        //Damage them
    }
}
