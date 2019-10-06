using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath_Message : MonoBehaviour
{
    //Specify message type

    public UnityEvent playerDeath;

    public void OnCollisionEnter(Collision _collider)
    {
        //Check if not triggered yet and if player collides with enemy
        if (_collider.gameObject.tag == "Player")
        {
            //Send message
            playerDeath.Invoke();
        }
    }
}
