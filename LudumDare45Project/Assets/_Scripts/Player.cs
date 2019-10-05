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

    public float speed = 0.3f;
    public float jump_speed = 300f;
    public float double_jump_speed = 1f;
    //public float gravity = -1f;

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
            if (is_jumping == true)
            {
                double_jump = false;
                //gravity = -1f;

                //if (GetComponent<Rigidbody>().velocity.y < 0f)
                //{
                double_jump_speed = -GetComponent<Rigidbody>().velocity.y*50;
                //}
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed + double_jump_speed, 0));

            }
            else
            {
                is_jumping = true;

                GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed, 0));
            }
        }

        //if(is_jumping == true && GetComponent<Rigidbody>().velocity.y <= 2f)
        //{
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, gravity, 0));

        //    gravity -= 1f;
        //}

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            is_jumping = false;
            double_jump = true;
            //gravity = -1f;
            double_jump_speed = 1f;
}
    }

    //void OnCollision(Collision col)
    //{
    //    if (col.transform.tag == "Wall")
    //    {
            
    //    }
    //}

}
