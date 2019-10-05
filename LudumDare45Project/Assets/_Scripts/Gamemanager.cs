using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
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
    };

    private GameState curState;

    private bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener<GameObject>(messageTriggered, onDeathMessage);
        Messenger.AddListener<GameObject>(receivedDeathMessage, onDeathMessage);
    }

    void onDeathMessage(GameObject propType)
    {

    }
}
