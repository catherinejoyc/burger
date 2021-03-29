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
    public EnemyBattle enemy;
    public PlayerBattle player;

    private BattleState currentBattleState;

    public void PrepareBattle(GameObject _enemyUIPref, PlayerBattle _player)
    {
        Instantiate(_enemyUIPref, enemyBattleStation);
        enemy = _enemyUIPref.GetComponent<EnemyBattle>();
        player = _player;
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
