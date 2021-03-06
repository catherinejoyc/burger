using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject credits;
    public GameObject chooseCharacter;

    private void Start()
    {
        credits.SetActive(false);
        chooseCharacter.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1); 
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

    public void StartChooseCharacter()
    {
        startmenu.SetActive(false);
        chooseCharacter.SetActive(true);
    }

    public void ToDIVESWebsite()
    {
         Application.OpenURL("https://www.divesmusic.com");
    }
}
