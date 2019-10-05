using System.Collections;
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

    public float speed = 0.5f;
    public float jump_speed = 3f;

    private bool is_jumping = false;
    private bool double_jump = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(right))
        {
            transform.position += new Vector3(speed, 0, 0);
        }

        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }

        if (Input.GetKey(up))
        {
            transform.position += new Vector3(0, 0, speed);
        }

        if (Input.GetKey(down))
        {
            transform.position += new Vector3(0, 0, -speed);
        }

        if (Input.GetKeyDown(space) && (is_jumping == false || double_jump == true))
        {
            if(is_jumping == true)
            {
                double_jump = false;
            }

            is_jumping = true;
            transform.position += new Vector3(0, jump_speed, 0);

            //GetComponent<Rigidbody>().AddForce(new Vector3(0, 300f, 0));
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            is_jumping = false;
            double_jump = true;
        }
    }

}
