using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{

    /// <summary>
    /// The boulder's transform, used to move it
    /// </summary>
    Transform _boulderTransform;

    /// <summary>
    /// A modifier to the base movement speed
    /// </summary>
    [SerializeField]
    float moveSpeed = 5.0f;

    //Boulder immobile by default
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

    /// <summary>
    /// Method used to toggle boulder movement upon message
    /// </summary>
    public void EnableBoulder()
    {
        move = true;
    }
}
