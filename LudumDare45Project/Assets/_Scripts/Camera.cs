using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform lookAt;
    public GameObject player;

    //Camera Box
    public float boundX = 1.2f;
    public float boundY = 1.5f;

    //smoothing
    public float speed = 0.15f;
    private Vector3 desiredPosition;

    private void Start()
    {
        // Si lookAt est nul, alors cherchons le joueur (default)
        if (lookAt == null)
        {
            if (player != null) lookAt = player.transform;
        }
    }

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //X Axis
        float dx = lookAt.position.x - transform.position.x;
        if (dx > boundX || dx < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = dx - boundX;

            }
            else
            {
                delta.x = dx + boundX;
            }
        }

        //Y Axis
        float dy = lookAt.position.y - transform.position.y;
        if (dy > boundY || dy < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = dy - boundY;

            }
            else
            {
                delta.y = dy + boundY;
            }
        }

        //Move the camera and smoothing
        desiredPosition = transform.position + delta;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed);
    }
}
