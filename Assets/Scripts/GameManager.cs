using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dontDestroyOnLoad;

    public static GameState state;
    public static int lives;
    public static int level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            state = GameState.Default;

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

    public static void ReadGameState(GameState gs)
    {
        switch (gs)
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

    public static void UpdateGameState(GameState newState)
    {
        state = newState;
        ReadGameState(state);
    }

    public static void PauseGame()
    {
        if (state == GameState.PlayerTurn)
        {
            Time.timeScale = 0;
            UpdateGameState(GameState.Paused);
        }
        else if(state == GameState.Paused)
        {
            Time.timeScale = 1;
            UpdateGameState(GameState.PlayerTurn);
        }
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void UpdateLives(int p_quantity)
    {
        lives += p_quantity;        
    }

    public static void PlayerDie()
    {
        UpdateGameState(GameState.Lose);
        UpdateLives(-1);

        if (lives == 0)
        {
            UpdateGameState(GameState.GameOver);
            Debug.Log("GAME OVER");
        }
    }


}


public enum GameState
{
    Default,
    PlayerTurn,
    Paused,
    Victory,
    Lose,
    GameOver
}
