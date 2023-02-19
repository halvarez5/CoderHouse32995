using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dontDestroyOnLoad;

    public static GameState state;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public static void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.PlayerTurn:
                break;
            case GameState.Victory:
                Debug.Log("GANASTE !!");
                break;
            case GameState.Lose:
                Debug.Log("PERDISTE");
                break;
            default:
                break;
        }
    }
}

public enum GameState
{
    PlayerTurn,
    Victory,
    Lose
}
