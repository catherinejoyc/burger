using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Overworld,
    Dialog,
    Transition,
    Fight,
}

public class GameManager : MonoBehaviour
{
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

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.Overworld;
        battleSystem = GetComponent<Battlesystem>();
    }
}
