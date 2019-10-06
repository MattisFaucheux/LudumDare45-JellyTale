using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Vector3 position;

    public KeyCode space;
    public KeyCode sprint;
    public KeyCode dash;

    public float speed = 10f;
    public float speed_copy = 0f;
    public float sprint_speed = 1.7f;
    public float jump_speed = 600f;
    public float double_jump_speed = 50f;
    public float dashX;
    public float dashY;
    public float dash_speed = 5f;
    public float dash_time = 0.2f;

    private float time;

    private bool is_jumping = false;
    private bool double_jump = true;
    private bool is_dash = false;

    public bool wall_jump = false;

    private float LastMooveX;

    // Start is called before the first frame update
    void Start()
    {
        speed_copy = speed;
        
    }

    // Update is called once per frame
    void Update()
    {

        time = Time.deltaTime;

        if (Input.GetKey(sprint))
        {
            speed = speed_copy * sprint_speed;
        }
        else
        {
            speed = speed_copy;
        }

        if (Input.GetKeyDown(dash))
        {
            is_dash = true;
            dashX = Input.GetAxis("Horizontal");
            dashY = Input.GetAxis("Vertical");
            StartCoroutine(MyDash());
        }

        if (is_dash == true)
        {
            transform.Translate(dashX * speed * time * dash_speed, 0, dashY * speed * time * dash_speed);
        }
        else
        {
            transform.Translate(Input.GetAxis("Horizontal") * time * speed, 0, 0);
            transform.Translate(0, 0, Input.GetAxis("Vertical") * time * speed);
        }

        if (Input.GetKeyDown(space) && wall_jump == true)
        {
            Debug.Log("test");
        }
        else if (Input.GetKeyDown(space) && (is_jumping == false || double_jump == true))
        {
            if (is_jumping == true)
            {
                double_jump = false;

                if (GetComponent<Rigidbody>().velocity.y < 0f)
                {
                 double_jump_speed *= -GetComponent<Rigidbody>().velocity.y;
                }
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed + double_jump_speed, 0));
            }
            else
            {
                is_jumping = true;

                GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed, 0));
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            is_jumping = false;
            double_jump = true;
            double_jump_speed = 50f;
        }
        else if (col.transform.tag == "Wall")
        {
            wall_jump = true;
            Physics.gravity = new Vector3(0, -5, 0);
            speed = 1;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.transform.tag == "Wall")
        {
            wall_jump = false;
            Physics.gravity = new Vector3(0, -40, 0);
            speed = speed_copy;
        }
    }

    IEnumerator MyDash()
    {
        yield return new WaitForSeconds(dash_time);
        is_dash = false;
    }


}
