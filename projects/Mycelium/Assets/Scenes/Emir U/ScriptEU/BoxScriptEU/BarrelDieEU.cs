using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDieEU : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // Play hurt Animation

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Box got destroyed");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
