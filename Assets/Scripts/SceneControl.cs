using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public Text LifeCount;


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
}
