using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    PlayerTurn, 
    EnemyTurn //Attack, Animation, Health update (gradual reduction)
}

public class Battlesystem : MonoBehaviour
{

    [SerializeField] Transform enemyBattleStation;
    [SerializeField] GameObject fightBox;

    private BattleState currentBattleState;

    public void PrepareBattle(GameObject enemyUIPref)
    {
        Instantiate(enemyUIPref, enemyBattleStation);

        //playerTurn
        UpdatePlayerTurn();
    }

    void UpdatePlayerTurn()
    {
        currentBattleState = BattleState.PlayerTurn;
        fightBox.SetActive(true);
    }

    void UpdateEnemyTurn()
    {
        currentBattleState = BattleState.EnemyTurn;
        //EnemyFightScript
        //  choose random character, animation, damage (gradual reduction)
    }
}
