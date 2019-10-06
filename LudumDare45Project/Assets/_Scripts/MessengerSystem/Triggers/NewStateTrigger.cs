using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewStateTrigger : MonoBehaviour
{
    public UnityEvent newState;

    private bool triggeredOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!triggeredOnce && other.gameObject.tag == "Player")
        {
            triggeredOnce = true;
            newState.Invoke();
        }
    }
}
