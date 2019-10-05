using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath_Message : MonoBehaviour
{
    //Specify message type and if it was triggered
    public string messageTriggered;
    public string receivedEndMessage;
    private bool triggeredOnce = false;

    public void OnCollisionEnter(Collision _collider)
    {
        //Check if not triggered yet and if player collides with enemy
        if (!triggeredOnce && _collider.gameObject.tag == "Player")
        {
            triggeredOnce = true;
            //Send message
            Messenger.Broadcast<GameObject>(messageTriggered, this.gameObject);
        }
    }
}
