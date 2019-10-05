using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 position;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0, 0);
        }
      
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

    }
}
