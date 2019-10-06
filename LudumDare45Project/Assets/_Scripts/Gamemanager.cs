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
    private enum GameState
    {
        None = 0,
        MainMenu,
        Zone1,
        Zone2,
        Zone3,
        Zone4,
        Zone5,
        Zone6,
        End,
        GameOver,
    };

    List<CheckPoint> checkPoints = new List<CheckPoint>();
    //public static GameObject[] CheckPointList;

    //All events triggered by GameManager
    public UnityEvent boulderLaunch;

    //Store current game state
    private GameState curState;

    //Check player current state
    private bool playerDead = false;

    private static Gamemanager instance;
    Vector3 lastCPPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < MAXINDEX; i++)
        {
            checkPoints.Add(new CheckPoint (false, transform));
        }*/
        //CheckPointList = GameObject.FindGameObjectsWithTag("CheckPoint");
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
                BoulderStart();
                break;

            case GameState.Zone3:

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
        curState = GameState.GameOver;
        Debug.Log("Current State = " + curState);
        

    }

    /// <summary>
    /// Manage player death events
    /// </summary>
    private void PlayerDeath()
    {
        Debug.Log(curState);
        Destroy(GameObject.FindGameObjectWithTag("Player"), 0.2f);

        
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

    private void setCp()
    {
        //lastCPPos

    }
}
