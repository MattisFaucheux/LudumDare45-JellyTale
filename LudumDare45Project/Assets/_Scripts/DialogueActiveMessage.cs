using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueActiveMessage : MonoBehaviour
{
    public UnityEvent dialogueActive;
    private bool triggeredOnce = false;

    public void OnTriggerEnter(Collider other)
    {
        //Check if not triggered yet and if player collides with enemy
        if (triggeredOnce != true && other.gameObject.tag == "Player")
        {
            triggeredOnce = true;
            //Send message
            dialogueActive.Invoke();
        }
    }
}
