using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Button vikButton;
    public Button tamButton;
    public Button dorButton;
    public BattleState currentBattleState;

    public Slider enemyHP;
    public Slider viktoriaHP;
    public Slider tamaraHP;
    public Slider doraHP;

    public Unit viktoria;
    public Unit tamara;
    public Unit dora;
    public Unit enemy;

    [Header("UI Animators")]
    public Animator vikAnim;
    public Animator dorAnim;
    public Animator tamAnim;

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
        bool gameOver = enemy.TakeDamage(viktoria.damage);
        vikAnim.SetTrigger("attack");

        //gradual reduction
        enemyHP.value = enemy.currentHP;

        if (gameOver)
        {
            Win();
        }

        UpdateEnemyTurn();
    }

    public void TamAttack()
    {
        bool gameOver = enemy.TakeDamage(tamara.damage);
        tamAnim.SetTrigger("attack");

        //gradual reduction
        enemyHP.value = enemy.currentHP;

        if (gameOver)
        {
            Win();
        }

        UpdateEnemyTurn();
    }

    public void DorAttack()
    {
        bool gameOver = enemy.TakeDamage(dora.damage);
        dorAnim.SetTrigger("attack");

        //gradual reduction
        enemyHP.value = enemy.currentHP;

        if (gameOver)
        {
            Win();
        }

        UpdateEnemyTurn();
    }

    void EnemyAttack()
    {
        int chosenPlayerNr = ChoosePlayer();

        switch (chosenPlayerNr)
        {
            case 0:
                bool gameOver = viktoria.TakeDamage(enemy.damage);
                //gradual reduction
                viktoriaHP.value = viktoria.currentHP;

                if (gameOver)
                {
                    //kill Vik
                    vikButton.interactable = false;
                }
                break;
            case 1:
                bool gameOver1 = tamara.TakeDamage(enemy.damage);
                //gradual reduction
                tamaraHP.value = tamara.currentHP;

                if (gameOver1)
                {
                    //kill Tamara
                    tamButton.interactable = false;
                }
                break;
            case 2:
                bool gameOver2 = dora.TakeDamage(enemy.damage);
                //gradual reduction
                doraHP.value = dora.currentHP;

                if (gameOver2)
                {
                    //kill dora
                    dorButton.interactable = false;
                }
                break;
        }


        if (!vikButton.interactable && !tamButton.interactable && !dorButton.interactable)
        {
            //die
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //player turn
        UpdatePlayerTurn();
    }

    void Win()
    {
        enemy.gameObject.SetActive(false);
        fightPanel.SetActive(false);

        GameManager.Instance.currentGameState = GameState.Overworld;
    }

    int ChoosePlayer()
    {
        bool playerChoosable = false;

        while (!playerChoosable)
        {
            int i = Random.Range(0, 3);

            switch (i)
            {
                case 0:
                    if (vikButton.interactable)
                    {
                        playerChoosable = true;
                        return 0;
                    }
                    break;
                case 1:
                    if (tamButton.interactable)
                    {
                        playerChoosable = true;
                        return 1;
                    }
                    break;
                case 2:
                    if (dorButton.interactable)
                    {
                        playerChoosable = true;
                        return 2;
                    }
                    break;
            }
        }

        return 3;
    }
}
