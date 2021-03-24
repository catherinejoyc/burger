using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject enemyUIPrefab;
    Battlesystem battleSystem;

    private void Start()
    {
        gameManager = GameManager.Instance;
        battleSystem = gameManager.BattleSystem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Dialog>().enabled = true;

            gameManager.WinTransGSEvent.AddListener(DeactivateEnemy);
            gameManager.FightGSEvent.AddListener(PrepareEnemyUI);
            gameManager.DialogGSEvent.Invoke();
        }
    }

    void PrepareEnemyUI()
    {
        battleSystem.PrepareBattle(enemyUIPrefab);
        gameManager.FightGSEvent.RemoveListener(PrepareEnemyUI);
    }

    void DeactivateEnemy()
    {
        gameManager.WinTransGSEvent.RemoveListener(DeactivateEnemy);

        GetComponentInParent<GameObject>().SetActive(false);        
    }
}
