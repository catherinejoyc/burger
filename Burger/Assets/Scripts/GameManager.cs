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
    WinTransition,
    LoseTransition
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
    public GameState CurrentGameState { get { return currentGameState; } }

    [Header("Game States")]
    public UnityEvent OverworldGSEvent;
    public UnityEvent DialogGSEvent;
    public UnityEvent FightTransGSEvent;
    public UnityEvent FightGSEvent;
    public UnityEvent WinTransGSEvent;
    public UnityEvent LoseTransGSEvent;

    [Header("BattleSystem")]
    Battlesystem battleSystem;
    public Battlesystem BattleSystem { get { return battleSystem; } }


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        battleSystem = GetComponent<Battlesystem>();

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
        WinTransGSEvent.AddListener(() =>
        {
            currentGameState = GameState.WinTransition;
        });
        LoseTransGSEvent.AddListener(() =>
        {
            currentGameState = GameState.LoseTransition;
        });
    }
}
