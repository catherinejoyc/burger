using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject credits;

    private void Start()
    {
        credits.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2); 
    }

    public void StartCredits()
    {
        startmenu.SetActive(false);
        credits.SetActive(true);
    }
    
    public void BackToMenu()
    {
        credits.SetActive(false);
        startmenu.SetActive(true);
    }
}
