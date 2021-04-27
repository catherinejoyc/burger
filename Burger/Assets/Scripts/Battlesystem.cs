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

public enum PlayerAttackType
{
    Vik,
    Tam,
    Dor
}

public class Battlesystem : MonoBehaviour
{
    public GameObject fightPanel;
    public GameObject fightBox;
    GameObject enemyPref;
    public Button vikButton;
    public Button tamButton;
    public Button dorButton;
    public Transform enemyPos;
    public BattleState currentBattleState;
    PlayerAttackType lastPlayerAttack;

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
    Animator enemyAnim;

    bool isSettingUp = false;

    public void SetUp(Unit en, GameObject enemyUIPref)
    {
        if (isSettingUp)
            return;

        isSettingUp = true;

        currentBattleState = BattleState.PlayerTurn;

        viktoriaHP.maxValue = viktoria.maxHP;
        viktoriaHP.value = viktoria.currentHP;

        tamaraHP.maxValue = tamara.maxHP;
        tamaraHP.value = tamara.currentHP;

        doraHP.maxValue = dora.maxHP;
        doraHP.value = dora.currentHP;

        enemyPref = Instantiate(enemyUIPref, enemyPos);

        enemyHP.maxValue = en.maxHP;
        enemyHP.value = en.currentHP;

        enemy = en;
        enemyAnim = enemyPref.GetComponent<Animator>();
    }

    void UpdateEnemyTurn()
    {
        isSettingUp = false;

        currentBattleState = BattleState.EnemyTurn;
        fightBox.SetActive(false);

        //attack animation
        EnemyAttack();
    }

    void UpdatePlayerTurn()
    {
        currentBattleState = BattleState.PlayerTurn;
        fightBox.SetActive(true);

    }

    public void VikAttack()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Vik;
        StartCoroutine(VikAttackEnum());
    }
    IEnumerator VikAttackEnum()
    {
        bool gameOver = enemy.TakeDamage(viktoria.damage);
        vikAnim.SetTrigger("attack");

        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetTrigger("damaged");

        while (enemyHP.value > enemy.currentHP)
        {
            enemyHP.value-=0.1f;
            yield return new WaitForFixedUpdate();
        }

        if (gameOver)
        {
            Win();
        }
        else
            UpdateEnemyTurn();
    }

    public void TamAttack()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Tam;
        StartCoroutine(TamAttackEnum());
    }
    IEnumerator TamAttackEnum()
    {
        bool gameOver = enemy.TakeDamage(tamara.damage);
        tamAnim.SetTrigger("attack");

        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetTrigger("damaged");

        while (enemyHP.value > enemy.currentHP)
        {
            enemyHP.value -= 0.1f;
            yield return new WaitForFixedUpdate();
        }

        if (gameOver)
        {
            Win();
        }
        else
            UpdateEnemyTurn();
    }

    public void DorAttack()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Dor;
        StartCoroutine(DorAttackEnum());
    }
    IEnumerator DorAttackEnum()
    {
        bool gameOver = enemy.TakeDamage(dora.damage);
        dorAnim.SetTrigger("attack");

        yield return new WaitForSeconds(1.5f);
        enemyAnim.SetTrigger("damaged");

        while (enemyHP.value > enemy.currentHP)
        {
            enemyHP.value -= 0.1f;
            yield return new WaitForFixedUpdate();
        }

        if (gameOver)
        {
            Win();
        }
        else
            UpdateEnemyTurn();
    }

    void EnemyAttack()
    {
        StartCoroutine(EnemyAttackEnum());
    }
    IEnumerator EnemyAttackEnum()
    {
        int chosenPlayerNr = ChoosePlayer();

        //say dialog
        ChooseEvilDialog();
        yield return new WaitForSeconds(1.5f);
        Dialogsystem.instance.dialogPanel.SetActive(false);

        enemyAnim.enabled = true;
        enemyAnim.SetTrigger("attack");

        yield return new WaitForSeconds(1.5f);

        switch (chosenPlayerNr)
        {
            case 0:
                bool gameOver = viktoria.TakeDamage(enemy.damage);
                vikAnim.SetTrigger("damaged");

                while (viktoriaHP.value > viktoria.currentHP)
                {
                    viktoriaHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }

                if (gameOver)
                {
                    //kill Vik
                    vikButton.interactable = false;
                }
                break;
            case 1:
                bool gameOver1 = tamara.TakeDamage(enemy.damage);
                tamAnim.SetTrigger("damaged");

                while (tamaraHP.value > tamara.currentHP)
                {
                    tamaraHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }

                if (gameOver1)
                {
                    //kill Tamara
                    tamButton.interactable = false;
                }
                break;
            case 2:
                bool gameOver2 = dora.TakeDamage(enemy.damage);
                dorAnim.SetTrigger("damaged");

                while (doraHP.value > dora.currentHP)
                {
                    doraHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }

                if (gameOver2)
                {
                    //kill dora
                    dorButton.interactable = false;
                }
                break;
        }

        yield return new WaitForSeconds(1.5f);

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
        StartCoroutine(WinEnum());
    }

    IEnumerator WinEnum()
    {
        yield return new WaitForSeconds(1.5f);

        vikAnim.SetTrigger("eat");
        tamAnim.SetTrigger("eat");
        dorAnim.SetTrigger("eat");

        yield return new WaitForSeconds(2f);

        Destroy(enemyPref.gameObject);
        enemy.gameObject.SetActive(false);

        yield return new WaitForSeconds(1);

        fightPanel.SetActive(false);

        AudioManager.Instance.PlayOverworldClip();

        GameManager.Instance.currentGameState = GameState.Overworld;
        GameManager.Instance.AddScore();

        if (enemy.isBurger)
            GameManager.Instance.EndGame();
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

    void ChooseEvilDialog()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("You call THAT a slap?");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Can you play other chords too?");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("That's not how you hold drumsticks.");
                break;
        }
    }
}
