using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptGate : MonoBehaviour, IClick
{
    public void onClickAction()
    {
        Debug.Log("You clicked the gate");
        Destroy(gameObject);
    }
}
