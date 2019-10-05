using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool enabled = false;
    public Transform cpTransform;

    private void Start()
    {
        cpTransform = this.transform;
    }

}
