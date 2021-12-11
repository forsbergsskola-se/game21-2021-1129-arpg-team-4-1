using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageManagerNR : MonoBehaviour
{
    public GameObject damageTextPrefab, enemyInstance;
    public string damageTaken;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject damageTextInstance = Instantiate(damageTextPrefab, enemyInstance.transform);
            damageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damageTaken);
        }
    }
}
