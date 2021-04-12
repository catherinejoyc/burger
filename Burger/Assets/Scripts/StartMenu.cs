using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartCredits()
    {
        SceneManager.LoadScene(3);
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
