using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/*
 * GOAL : Manage game states and relevant events 
 * 
 * INPUT : Messages from game objects 
 * 
 * OUTPUT : State modification and relevant method output
 * 
 * NOTE : Create methods beneath FixedUpdate and call them in Switch statement
 * 
 * */

public class Gamemanager : MonoBehaviour
{
    /// <summary>
    /// Maximum number of checkpoints
    /// </summary>
    const int MAXINDEX = 6;

    //Define all different game states
    protected enum GameState
    {
        None = 0,
        MainMenu = 1,
        Zone1 = 2,
        Zone2 = 3,
        Zone3 = 4,
        Zone4 = 5,
        Zone5 = 6,
        Zone6 = 7,
        End = 8,
        GameOver = 9,
    };

    //All events triggered by GameManager
    public UnityEvent boulderLaunch;
    public UnityEvent newSkill;

    //Store current game state
    private GameState curState;

    //Check player current state
    private bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        curState = GameState.MainMenu;
}

    private void FixedUpdate()
    {
        //Switch between game states and execute relative methods
        switch (curState)
        {
            case GameState.MainMenu:

                break;

            case GameState.Zone1:

                break;

            case GameState.Zone2:
                
                break;

            case GameState.Zone3:
                BoulderStart();
                break;

            case GameState.Zone4:

                break;

            case GameState.Zone5:

                break;

            case GameState.Zone6:

                break;

            case GameState.GameOver:
                PlayerDeath();

                break;

            case GameState.End:

                break;
        }
    }

    /// <summary>
    /// React to player death
    /// </summary>
    /// <param name="propType"></param>
    public void onDeathMessage(GameObject propType)
    {
        Debug.Log("PlayerDead");
        Debug.Log("Current State = " + curState);

        //Player position takes active checkpoint position
        GameObject.FindGameObjectWithTag("Player").transform.position = CheckPoint.GetActiveCheckPointPosition();
        //Freeze player rotation
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //On player input, unfreeze rotations
        if (Input.anyKey)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

    }

    /// <summary>
    /// Manage player death events
    /// </summary>
    private void PlayerDeath()
    {
        Debug.Log(curState);
        
    }

    /// <summary>
    /// React to boulder scene start trigger
    /// </summary>
    /// <param name="propType"></param>
    public void onBoulderStartMessage(GameObject propType)
    {
        Debug.Log("BoulderStart");
        curState = GameState.Zone2;
        Debug.Log("Current State = " + curState);
        
    }

    /// <summary>
    /// Send message to Boulder to enable movement
    /// </summary>
    void BoulderStart()
    {
        Debug.Log("Boulder rolling");
        boulderLaunch.Invoke();
    }

    public void onNewState()
    {

        //Create an array storing all enum indexes
        System.Array a = System.Enum.GetValues(typeof(GameState));
        int i = 0;
        //Iterate through array to fetch current state index
        for (i = 0; i < a.Length; i++)
        {
            //Go to next index
            if ((int)a.GetValue(i) == (int)curState)
                break;
        }
        //Current state updated to newly fetched state index
        curState = (GameState)a.GetValue(i + 1);
        Debug.Log(curState);
    }

    /// <summary>
    /// Call for new skill unlock
    /// </summary>
    public void onNewSkill()
    {
        Debug.Log("New Skill unlocked");
        newSkill.Invoke();
    }
}
