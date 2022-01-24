using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class BoxDamageEU : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    [SerializeField] 
    Object destrucableRef;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            health--;

            if (health <= 0)
            {
                ExplodeThisGameObject();
            }
        }
    }

    private void ExplodeThisGameObject()
    {
        GameObject destructable = (GameObject) Instantiate(destrucableRef);
        
        // map the newly loaded destrucable object to the x and y postition of the previously destroyed barrel
        destructable.transform.position = transform.position;
        
        Destroy(gameObject);
    }
}
