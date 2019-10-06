using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath_Message : MonoBehaviour
{
    //Specify message type and if it was triggered

    public UnityEvent playerDeath;
    
    //private bool triggeredOnce = false;

    public void OnCollisionEnter(Collision _collider)
    {
        //Check if not triggered yet and if player collides with enemy
        if (/*triggeredOnce != true &&*/ _collider.gameObject.tag == "Player")
        {
            //triggeredOnce = true;
            //Send message
            playerDeath.Invoke();
        }
    }
}
