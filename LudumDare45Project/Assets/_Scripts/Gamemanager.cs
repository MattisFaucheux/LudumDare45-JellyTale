using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public string messageTriggered;
    public string receivedDeathMessage;
    public string receivedBoulderStartMessage;

    //Store current game state
    private GameState curState;

    //Check player current state
    private bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        curState = GameState.MainMenu;

        //Setup listeners to enable message receiving
        Messenger.AddListener<GameObject>(messageTriggered, onDeathMessage);
        Messenger.AddListener<GameObject>(receivedDeathMessage, onDeathMessage);

        Messenger.AddListener<GameObject>(messageTriggered, onBoulderStartMessage);
        Messenger.AddListener<GameObject>(receivedBoulderStartMessage, onBoulderStartMessage);
    }

    private void FixedUpdate()
    {
        //Check current game state and execute relative methods
        switch (curState)
        {
            case GameState.MainMenu:

                break;

            case GameState.Zone1:

                break;

            case GameState.Zone2:

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
    void onDeathMessage(GameObject propType)
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
    void onBoulderStartMessage(GameObject propType)
    {
        Debug.Log("BoulderStart");
        curState = GameState.Zone2;
        Debug.Log("Current State = " + curState);


    }
}
