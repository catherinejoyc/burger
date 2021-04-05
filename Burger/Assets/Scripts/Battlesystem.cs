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
    public GameObject FightPanel;
    public BattleState currentBattleState;

    public Slider enemyHP;
    public Slider playerHP;

    public Unit player;
    public Unit enemy;

    public void SetUp(Unit en)
    {
        enemy = en;

        enemyHP.maxValue = enemy.maxHP;
        enemyHP.value = enemy.currentHP;
    }

    public void PlayerAttack()
    {
        enemy.TakeDamage(player.damage);
        enemyHP.value = enemy.currentHP;
    }

    void EnemyAttack()
    {

    }
}
