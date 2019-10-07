using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    //Specify message type

    public UnityEvent playerDeath;
    
    public void OnTriggerEnter(Collider other)
    {
        //Check if not triggered yet and if player collides with enemy
        if (other.gameObject.tag == "Player")
        {
            //Send message
            playerDeath.Invoke();
        }
    }
}
