using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Game is launched");
        SceneLoader.Load(SceneLoader.Scene.Game);
        //SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
