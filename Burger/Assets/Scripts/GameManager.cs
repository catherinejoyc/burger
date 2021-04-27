using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Overworld,
    Dialog,
    Transition,
    Fight,
}

public class GameManager : MonoBehaviour
{
    public float playerTimef = 0; //how much time the player spent
    public int playerTimei = 0;
    public int playerScore = 0; //how many enemies the player fought
    public Text timeDisplay;
    public Text scoreDisplay;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
            else
            {
                Debug.LogError("Game Manager exists already!");
            }
        }
    }

    public GameState currentGameState;

    public Battlesystem battleSystem;
    public RadialTransition radialTrans;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.Overworld;
        battleSystem = GetComponent<Battlesystem>();

        //Audio starten
    }

    void Update()
    {
        playerTimef += Time.deltaTime;
        playerTimei = (int)playerTimef;
        timeDisplay.text = playerTimei.ToString();
    }

    public void AddScore()
    {
        playerScore++;
        scoreDisplay.text = playerScore.ToString();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(5);
    }
}
