using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public EnemyHealthBar HealthBarEnemy;
    
    void Start()
    {
        Hitpoints = MaxHitpoints;
        HealthBarEnemy.SetHealth(Hitpoints, MaxHitpoints);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHit(2);
        }
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        HealthBarEnemy.SetHealth(Hitpoints, MaxHitpoints);
        
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        Hitpoints += amount;

        if (Hitpoints > MaxHitpoints)
        {
            Hitpoints = MaxHitpoints;
        }
        
        HealthBarEnemy.SetHealth(Hitpoints, MaxHitpoints);
    }
    
    
}
