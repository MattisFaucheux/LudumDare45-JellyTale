using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    /// <summary>
    /// The enemy's transform, used to move it
    /// </summary>
    Transform _enemyTransform;

    /// <summary>
    /// A modifier to the base movement speed
    /// </summary>
    float moveSpeed = 5.0f;
    float rotation = 90;

    public void Awake()
    {
        _enemyTransform = GetComponent<Transform>();
    }

    /// <summary>
    /// Fixed update to move enemy in a constant manner
    /// </summary>
    public void FixedUpdate()
    {
        _enemyTransform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    /// <summary>
    /// Collision check, tag used to determine behaviour
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            transform.rotation = Quaternion.Euler(0, rotation, 0);
            rotation = rotation + 180;
            

        }else if(collision.gameObject.tag == "Player")
        {
            //Placeholder until message system implemented
            Debug.Log("Impact with player");
        }
    }
}
