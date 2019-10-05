using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath_Message : MonoBehaviour
{
    public string messageTriggered;
    private bool triggeredOnce = false;


    public void OnCollisionEnter(Collision _collider)
    {
        if (!triggeredOnce && _collider.gameObject.tag == "Enemy")
        {
            triggeredOnce = true;
            Messenger.Broadcast<GameObject>(messageTriggered, this.gameObject);
        }
    }
}
