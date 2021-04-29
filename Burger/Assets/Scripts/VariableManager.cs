using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    int playerIndex; //1 Vik, 2 Tam, 3 Dor
    bool playerIsSet = false;
    bool gameIsWon = false;

    int score;
    int time;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsSet && SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerIsSet = true;
            GameManager.Instance.EnableCharacter(playerIndex);
            GameManager.Instance.SetVManager(this);
        }
        if (!gameIsWon && SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameIsWon = true;
            DisplayScore();
        }
    }

    public void SetPlayerIndex(int i)
    {
        playerIndex = i;
    }

    public void SaveScore(int currentTime, int currentScore)
    {
        time = currentTime;
        score = currentScore;
    }

    void DisplayScore()
    {
        Credits.Instance.UpdateScore(time, score);
    }
}
