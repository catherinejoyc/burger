using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Overworld,
    Dialog,
    FightTransition,
    Fight,
    WinLoseTransition
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

    private GameState currentGameState;
    //public GameState CurrentGameState
    //{
    //    get
    //    {
    //        return currentGameState;
    //    }
    //    set
    //    {
    //        switch (value)
    //        {
    //            case GameState.Overworld:
    //                break;
    //            case GameState.Dialog:
    //                break;
    //            case GameState.FightTransition:
    //                break;
    //            case GameState.Fight:
    //                break;
    //            case GameState.WinLoseTransition:
    //                break;
    //            default:
    //                Debug.LogError("Trying to set to invalid Game State!");
    //                break;
    //        }
    //    }
    //}

    private Dialogsystem dialogsystem;

    public UnityEvent OverworldGSEvent;
    public UnityEvent DialogGSEvent;
    public UnityEvent FightTransGSEvent;
    public UnityEvent FightGSEvent;
    public UnityEvent WLTransGSEvent;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        dialogsystem = GetComponent<Dialogsystem>();

        OverworldGSEvent.AddListener(() =>
        {
            currentGameState = GameState.Overworld;
        });
        DialogGSEvent.AddListener(() =>
        {
            currentGameState = GameState.Dialog;
        });
        FightTransGSEvent.AddListener(() =>
        {
            currentGameState = GameState.FightTransition;
        });
        FightGSEvent.AddListener(() =>
        {
            currentGameState = GameState.Fight;
        });
        WLTransGSEvent.AddListener(() =>
        {
            currentGameState = GameState.WinLoseTransition;
        });
    }

    void Update()
    {
        
    }
}
