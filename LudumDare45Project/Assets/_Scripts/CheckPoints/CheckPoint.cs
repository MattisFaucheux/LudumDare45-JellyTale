using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{

    public UnityEvent cpTriggered;
    public bool activated = false;

    public static GameObject[] CheckPointsList;

    void Start()
    {
        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    // Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().activated = false;
            //cp.GetComponent<CheckPoint>().SetBool("Active", false);
        }

        // We activate the current checkpoint
        activated = true;
        //Send message
        cpTriggered.Invoke();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }
}

    /*public bool enabled = false;
    public Transform cpTransform*/

    /*public UnityEvent cpTriggered;

    public bool triggeredOnce = false;

    public CheckPoint(bool state, Transform coord)
    {
        state = false;
        coord = this.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if not triggered yet and if player collides with enemy
        if (!triggeredOnce && other.gameObject.tag == "Player")
        {
            triggeredOnce = true;

            
            //Send message
            cpTriggered.Invoke();
        }
    }*/

//}
