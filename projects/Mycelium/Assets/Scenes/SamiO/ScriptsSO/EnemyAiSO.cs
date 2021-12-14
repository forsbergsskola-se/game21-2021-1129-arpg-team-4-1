using UnityEngine;
using System.Collections;

public class EnemyAiSo : MonoBehaviour
{

    public Transform target;//set target from inspector instead of looking in Update
    public float speed;
    public float distance;
    public float agroRange;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < agroRange) //Agro range
        {  //rotate to look at the player
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
        }

        if (Vector3.Distance(transform.position, target.position) < agroRange) //Agro range
        {   //move towards the player
            if (Vector3.Distance(transform.position, target.position) > distance)
            {//move if distance from target is greater than distance
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }
}