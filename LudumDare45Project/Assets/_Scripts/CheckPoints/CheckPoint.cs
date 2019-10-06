using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{

    private Gamemanager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Gamemanager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            gm.lastCPPos = transform.position;
        }
    }
}
