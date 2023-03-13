using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void NextSceneLoad()
    {
        SceneManager.LoadScene("Game");
    }
     
    public void ExitGame()
    {
        Application.Quit();
    }
}
