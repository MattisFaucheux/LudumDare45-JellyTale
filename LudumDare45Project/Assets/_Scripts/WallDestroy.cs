using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code set up on walls to manage destruction by boulder
//Add Box collider as trigger to wall

public class WallDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boulder")
        {
            Destroy(this.gameObject);
        }
    }
}
