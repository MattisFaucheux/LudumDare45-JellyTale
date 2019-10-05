using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnter_Message : MonoBehaviour
{
    public string messageTriggered;
    private bool triggeredOnce = false;


    public void OnTriggerStay(Collider _collider)
    {
        Messenger.Broadcast<GameObject>(messageTriggered, this.gameObject);
        if (!triggeredOnce && Input.GetKey(KeyCode.E))
        {
            triggeredOnce = true;
            Messenger.Broadcast<GameObject>(messageTriggered, this.gameObject);
        }
    }
}
