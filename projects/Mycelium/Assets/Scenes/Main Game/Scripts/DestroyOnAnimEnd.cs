using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimEnd : MonoBehaviour
{
    // since Animated objects are always attached to a Parent for ease of use, we grab the parent and destroy it.
    // this script is part of the animation events and will therefore execute after the animation is done. 
    
    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
