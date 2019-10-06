using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
