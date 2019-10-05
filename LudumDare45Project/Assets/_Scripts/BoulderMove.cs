using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{

    /// <summary>
    /// The enemy's transform, used to move it
    /// </summary>
    Transform _boulderTransform;

    /// <summary>
    /// A modifier to the base movement speed
    /// </summary>
    float moveSpeed = 5.0f;

    public bool move = false;

    public void Start()
    {
        _boulderTransform = GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        if(move == true)
        {
            _boulderTransform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }

    public void EnableBoulder()
    {
        move = true;
    }
}
