﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 position;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0, 0);
        }
      
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(up))
        {
            transform.position += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(down))
        {
            transform.position += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0));
        }


    }
}
