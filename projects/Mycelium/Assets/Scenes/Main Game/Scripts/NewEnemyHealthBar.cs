using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyHealthBar : MonoBehaviour {

    Vector3 localScale;
    void Start () {
        localScale = transform.localScale;
    }
    void Update () {
       // localScale.x = Cat.healthAmount;
        transform.localScale = localScale;
    }
}