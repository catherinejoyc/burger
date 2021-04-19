using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    GameManager gameManager;
    public GameObject enemyUIPref;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.currentGameState = GameState.Dialog;
            GetComponent<Dialog>().enabled = true;
        }
    }

    public void ActivateFight()
    {
        //Music stoppen, neue Music

        AudioManager.Instance.PlayFightClip();

        gameManager.radialTrans.StartTransition();

        gameManager.battleSystem.SetUp(GetComponent<Unit>(), enemyUIPref);
    }
}
