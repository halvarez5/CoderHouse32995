using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public Text LifeCount;
    public Text pause;
    public Text lose;
    public Text gameOver;
    public Text gracias;


    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Game");
        GameManager.lives = 3;
    }
     
    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateLifeCount()
    {
        LifeCount.text = GameManager.lives.ToString();
    }

    private void Update()
    {
        if (GameManager.state != GameState.Default)
        {
            switch (GameManager.state)
            {
                case GameState.PlayerTurn:
                    pause.gameObject.SetActive(false);
                    lose.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    gracias.gameObject.SetActive(false);
                    break;
                case GameState.Paused:
                    pause.gameObject.SetActive(true);
                    lose.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    gracias.gameObject.SetActive(false);
                    break;
                case GameState.Victory:
                    pause.gameObject.SetActive(false);
                    lose.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    gracias.gameObject.SetActive(true);
                    break;
                case GameState.Lose:
                    pause.gameObject.SetActive(false);
                    lose.gameObject.SetActive(true);
                    gameOver.gameObject.SetActive(false);
                    gracias.gameObject.SetActive(false);
                    break;
                case GameState.GameOver:
                    pause.gameObject.SetActive(false);
                    lose.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(true);
                    gracias.gameObject.SetActive(false);
                    break;
                default:
                    pause.gameObject.SetActive(false);
                    lose.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(false);
                    gracias.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
