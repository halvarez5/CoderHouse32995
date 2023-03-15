using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool dontDestroyOnLoad;

    public static GameState state;
    public static int lives;


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

    public static void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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
            Debug.Log("GAME OVER");
        }
    }


}


public enum GameState
{
    PlayerTurn,
    Paused,
    Victory,
    Lose
}
