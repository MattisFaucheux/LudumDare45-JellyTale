using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * GOAL : Trigger new skill unlock upon trigger enter
 * 
 * NOTE : Seperated from checkpoints and zone triggers for clarity and to prevent emergent behaviour
 * 
 */
public class NewSkillTrigger : MonoBehaviour
{
    public UnityEvent newSkill;

    private bool triggeredOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggeredOnce && other.gameObject.tag == "Player")
        {
            triggeredOnce = true;
            newSkill.Invoke();
        }
    }
}
