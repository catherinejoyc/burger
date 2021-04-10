using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    PlayerTurn, 
    EnemyTurn, //Attack, Animation, Health update (gradual reduction)
    Won,
    Lost
}

public class Battlesystem : MonoBehaviour
{
    public GameObject fightPanel;
    public GameObject fightBox;
    public BattleState currentBattleState;

    public Slider enemyHP;
    public Slider viktoriaHP;
    public Slider tamaraHP;
    public Slider doraHP;

    public Unit viktoria;
    public Unit tamara;
    public Unit dora;
    public Unit enemy;

    public void SetUp(Unit en)
    {
        currentBattleState = BattleState.PlayerTurn;

        viktoriaHP.maxValue = viktoria.maxHP;
        viktoriaHP.value = viktoria.currentHP;

        tamaraHP.maxValue = tamara.maxHP;
        tamaraHP.value = tamara.currentHP;

        doraHP.maxValue = dora.maxHP;
        doraHP.value = dora.currentHP;

        enemy = en;
        //*place enemy prefab on position

        enemyHP.maxValue = enemy.maxHP;
        enemyHP.value = enemy.currentHP;
    }

    void UpdateEnemyTurn()
    {
        currentBattleState = BattleState.EnemyTurn;
        fightBox.SetActive(false);

        //attack animation
        EnemyAttack();
        UpdatePlayerTurn();
    }

    void UpdatePlayerTurn()
    {
        currentBattleState = BattleState.PlayerTurn;
        fightBox.SetActive(true);

    }

    public void VikAttack()
    {
        enemy.TakeDamage(viktoria.damage);
        enemyHP.value = enemy.currentHP;

        UpdateEnemyTurn();
    }

    public void TamAttack()
    {
        enemy.TakeDamage(tamara.damage);
        enemyHP.value = enemy.currentHP;

        UpdateEnemyTurn();
    }

    public void DorAttack()
    {
        enemy.TakeDamage(dora.damage);
        enemyHP.value = enemy.currentHP;

        UpdateEnemyTurn();
    }

    void EnemyAttack()
    {
        int i = Random.Range(0, 2);

        switch (i)
        {
            case 0:
                viktoria.TakeDamage(enemy.damage);
                viktoriaHP.value = viktoria.currentHP;
                break;
            case 1:
                tamara.TakeDamage(enemy.damage);
                tamaraHP.value = tamara.currentHP;
                break;
            case 2:
                dora.TakeDamage(enemy.damage);
                doraHP.value = dora.currentHP;
                break;
        }

        //player turn
        currentBattleState = BattleState.PlayerTurn;
    }
}
