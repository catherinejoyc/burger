using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    GameManager gameManager;
    Dialogsystem dialogSystem;

    [SerializeField]
    private string[] dialog;
    [SerializeField]
    private Sprite face;

    int index = 0;

    private void Start()
    {
        gameManager = GameManager.Instance;
        dialogSystem = Dialogsystem.instance;
        dialogSystem.face.sprite = face;
        Say(dialog[index]);
        ++index;
    }

    private void Update()
    {
        if (Input.anyKeyDown && gameManager.CurrentGameState == GameState.Dialog)
        {
            if (!dialogSystem.isSpeaking || dialogSystem.isWaitingForUserInput)
            {
                if (index >= dialog.Length)
                {
                    gameManager.FightTransGSEvent.Invoke();
                    return;
                }

                Say(dialog[index]);
                ++index;
            }
        }
    }

    void Say(string s)
    {
        dialogSystem.Say(s);
    }
}