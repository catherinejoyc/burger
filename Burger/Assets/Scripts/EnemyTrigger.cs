using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject enemyUIPrefab;
    Battlesystem battleSystem;
    PlayerBattle player;

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
            player = collision.GetComponent<PlayerBattle>();
            gameManager.WinTransGSEvent.AddListener(DeactivateEnemy);
            gameManager.FightGSEvent.AddListener(PrepareUI);
            gameManager.DialogGSEvent.Invoke();
        }
    }

    void PrepareUI()
    {
        battleSystem.PrepareBattle(enemyUIPrefab, player);
        gameManager.FightGSEvent.RemoveListener(PrepareUI);
    }

    void DeactivateEnemy()
    {
        gameManager.WinTransGSEvent.RemoveListener(DeactivateEnemy);

        GetComponentInParent<GameObject>().SetActive(false);        
    }
}
