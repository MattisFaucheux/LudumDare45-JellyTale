using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoulderStartTrigger : MonoBehaviour
{
    //Specify message type and if it was triggered

    public UnityEvent boulderStart;

    /*public string messageSent;
    public string receivedEndMessage;*/
    private bool triggeredOnce = false;

    public void OnTriggerEnter(Collider _collider)
    {
        //Check if not triggered yet and if player collides with enemy
        if (!triggeredOnce && _collider.gameObject.tag == "Player")
        {
            triggeredOnce = true;
            //Send message
            //Messenger.Broadcast<GameObject>(messageSent, this.gameObject);
            boulderStart.Invoke();
        }
    }
}
