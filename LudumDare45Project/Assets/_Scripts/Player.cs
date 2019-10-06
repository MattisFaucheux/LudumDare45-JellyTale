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
    public bool touch_ground = true;

    public bool wall_jump = false;

    private float LastMooveX;

    public float wall_jump_Y = 1f;
    public float wall_jump_X = 1f;

    public float is_turn = 1f;

    /*public bool can_Sprint = true; //1
    public bool can_Dash = true; //2 
    public bool can_Moove = true; //3 
    public bool can_Jump = true; //4 
    public bool can_Double_Jump = true; //5 
    public bool can_Wall_Jump = true; //6 */

    /// <summary>
    /// Dictionaray containing all skills
    /// 1 : move
    /// 2 : jump
    /// 3 : sprint
    /// 4 : dash
    /// 5 : double jump
    /// 6 : wall jump
    /// </summary>
    Dictionary<int, bool> playerSkills = new Dictionary<int, bool>();

    // Start is called before the first frame update
    void Start()
    {
        speed_copy = speed;
        playerSkills.Add(1, true);
        playerSkills.Add(2, true);
        playerSkills.Add(3, true);
        playerSkills.Add(4, true);
        playerSkills.Add(5, true);
        playerSkills.Add(6, true);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            is_turn = -1;
        }
        else
        {
            is_turn = 1;
        }

        time = Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0)
        {
            LastMooveX = Input.GetAxis("Horizontal");
        }

        if (playerSkills[3] == true)
        {
            Player_Sprint();
        }

        if (playerSkills[4] == true)
        {
            Player_Dash();
        }

        if (playerSkills[1] == true)
        {
            Player_Moovement();
        }

        if (playerSkills[6] == true)
        {
            Player_Wall_Jump();
        }

        if (playerSkills[5] == true)
        {
            Player_Double_Jump();
        }

        if (playerSkills[2] == true)
        {
            Debug.Log("Can Jump");
            Player_Jump();
        }

    }

    void Player_Sprint()
    {
        if (Input.GetKey(sprint))
        {
            speed = speed_copy * sprint_speed;
        }
        else
        {
            speed = speed_copy;
        }
    }

    void Player_Dash()
    {
        if (Input.GetKeyDown(dash))
        {
            is_dash = true;
            dashX = Input.GetAxis("Horizontal") * is_turn;
            dashY = Input.GetAxis("Vertical")* is_turn;
            Physics.gravity = new Vector3(0, 0, 0);
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            StartCoroutine(MyDash(velocity));
        }
    }

    void Player_Moovement()
    {
        if (is_dash == true)
        {
            if (Physics.Raycast(transform.position, new Vector3(dashX * is_turn, 0, dashY * is_turn), speed * time * dash_speed * 1f) == false)
            {
                transform.Translate(dashX * speed * time * dash_speed, 0, dashY * speed * time * dash_speed);
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), speed * time * 3.1f) == false)
            {
                transform.Translate(Input.GetAxisRaw("Horizontal") * is_turn * time * speed, 0, 0);
                transform.Translate(0, 0, Input.GetAxis("Vertical") * is_turn * time * speed);
                // LastMooveX = Input.GetAxis("Horizontal");

                if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    void Player_Wall_Jump()
    {
        if (Input.GetKeyDown(space) && wall_jump == true && touch_ground == false)
        {
            if (Physics.Raycast(transform.position, new Vector3(1 * is_turn, 0, 0), speed * time * 3.1f) == true)
            {
                LastMooveX = -1 * is_turn;

            }
            else if (Physics.Raycast(transform.position, new Vector3(-1 * is_turn, 0, 0), speed * time * 3.1f) == true)
            {
                LastMooveX = 1 * is_turn;
            }

            if (LastMooveX > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); ;
            }
            else if (LastMooveX < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            GetComponent<Rigidbody>().AddForce(new Vector3(LastMooveX * jump_speed * wall_jump_X, jump_speed * wall_jump_Y, 0));
        }
    }

    void Player_Jump()
    {
        if (Input.GetKeyDown(space) && wall_jump == false && is_jumping == false)
        {
            is_jumping = true;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed, 0));
        }

    }

    void Player_Double_Jump()
    {
        if (Input.GetKeyDown(space) && wall_jump == false && is_jumping == true && double_jump == true)
        {
            double_jump = false;

            if (GetComponent<Rigidbody>().velocity.y < 0f)
            {
                double_jump_speed *= -GetComponent<Rigidbody>().velocity.y;
            }
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jump_speed + double_jump_speed, 0));
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
            Physics.gravity = new Vector3(0, -10, 0);
            speed = 1;
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.transform.tag == "Ground")
        {
            touch_ground = true;
        }
        else if (col.transform.tag == "Wall")
        {
            wall_jump = true;
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
        else if(col.transform.tag == "Ground")
        {
            touch_ground = false;
        }
    }

    IEnumerator MyDash(Vector3 velocity)
    {
        yield return new WaitForSeconds(dash_time);
        is_dash = false;
        Physics.gravity = new Vector3(0, -40, 0);
        GetComponent<Rigidbody>().velocity = velocity;
    }


    public void CheckSkills()
    {
        for(int i = 1; i < playerSkills.Count; i++)
        {
            if(playerSkills[i] == false)
            {
                playerSkills[i] = true;
                Debug.Log(playerSkills[i]);
                break;
            }
        }
    }

}
