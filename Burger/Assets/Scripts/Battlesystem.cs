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
    public Button vikAttackBtn;
    public Button vikHealBtn;
    public Button tamAttackBtn;
    public Button tamHealBtn;
    public Button dorAttackBtn;
    public Button dorHealBtn;
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
        print("PlayerTurn2");
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

        if (GameManager.Instance.playerScore == 0)
        {
            ChooseEvilDialog();
        }
        else if (GameManager.Instance.playerScore == 1)
        {
            ChooseEvilDialog2();
        }
        else if (GameManager.Instance.playerScore == 2)
        {
            ChooseEvilDialog3();
        }
        else if (GameManager.Instance.playerScore == 3)
        {
            ChooseEvilDialog4();
        }
        else if (GameManager.Instance.playerScore == 4)
        {
            ChooseEvilDialog5();
        }
        else if (GameManager.Instance.playerScore == 5)
        {
            ChooseEvilDialog6();
        }
        else if (GameManager.Instance.playerScore == 6)
        {
            ChooseEvilDialog7();
        }

        yield return new WaitForSeconds(2.5f);
        Dialogsystem.instance.dialogPanel.SetActive(false);

        enemyAnim.enabled = true;
        enemyAnim.SetTrigger("attack");

        yield return new WaitForSeconds(1.5f);

        switch (chosenPlayerNr)
        {
            case 0:
                if (viktoria.TakeDamage(enemy.damage))
                {
                    //kill Vik
                    vikAnim.SetTrigger("death");
                    vikAttackBtn.enabled = false;
                    vikHealBtn.enabled = false;
                }
                vikAnim.SetTrigger("damaged");

                while (viktoriaHP.value > viktoria.currentHP)
                {
                    viktoriaHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 1:
                if (tamara.TakeDamage(enemy.damage))
                {
                    //kill Tamara
                    tamAnim.SetTrigger("death");
                    tamAttackBtn.enabled = false;
                    tamHealBtn.enabled = false;
                }
                tamAnim.SetTrigger("damaged");

                while (tamaraHP.value > tamara.currentHP)
                {
                    tamaraHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }
                break;
            case 2:
                if (dora.TakeDamage(enemy.damage))
                {
                    //kill dora
                    dorAnim.SetTrigger("death");
                    dorAttackBtn.enabled = false;
                    dorHealBtn.enabled = false;
                }
                dorAnim.SetTrigger("damaged");

                while (doraHP.value > dora.currentHP)
                {
                    doraHP.value -= 0.1f;
                    yield return new WaitForFixedUpdate();
                }
                break;
        }

        yield return new WaitForSeconds(1.5f);

        if (!vikAttackBtn.enabled && !tamAttackBtn.enabled && !dorAttackBtn.enabled)
        {
            //die
            SceneManager.LoadScene(5);
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

        vikAnim.SetTrigger("finish");
        tamAnim.SetTrigger("finish");
        dorAnim.SetTrigger("finish");

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
                    if (vikAttackBtn.enabled)
                    {
                        playerChoosable = true;
                        return 0;
                    }
                    break;
                case 1:
                    if (tamAttackBtn.enabled)
                    {
                        playerChoosable = true;
                        return 1;
                    }
                    break;
                case 2:
                    if (dorAttackBtn.enabled)
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

    void ChooseEvilDialog2()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("I don't want any treble!");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Damn. Must be this time of the month...");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("Do I look like a drumset to you???");
                break;
        }
    }

    void ChooseEvilDialog3()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("Come on, this doesn't have to end on such a low note.");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Have you tried music theory?");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("Hey! I wasn't prepared!");
                break;
        }
    }

    void ChooseEvilDialog4()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("I didn't mean it that way!");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Whatever. I didn't like you anyway.");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("So this is what I get for being a nice guy?");
                break;
        }
    }

    void ChooseEvilDialog5()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("Your're giving me a headache!");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Is that a fret?");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("Wow, I really got a kick out of this!");
                break;
        }
    }

    void ChooseEvilDialog6()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("Oh, give me a break!");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("Now that was just rude.");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("Boo! Get outta here!");
                break;
        }
    }

    void ChooseEvilDialog7()
    {
        switch (lastPlayerAttack)
        {
            case PlayerAttackType.Vik:
                Dialogsystem.instance.Say("Good hit. Hope you don't mind me taking notes.");
                break;
            case PlayerAttackType.Tam:
                Dialogsystem.instance.Say("That really struck a chord.");
                break;
            case PlayerAttackType.Dor:
                Dialogsystem.instance.Say("I think your rythm is off.");
                break;
        }
    }

    public void VikHeal()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Vik;
        StartCoroutine(VikHealEnum());
    }
    IEnumerator VikHealEnum()
    {
        viktoria.Heal();
        vikAnim.SetTrigger("heal");

        yield return new WaitForSeconds(1.5f);

        while (viktoriaHP.value < viktoria.currentHP)
        {
            viktoriaHP.value += 0.1f;
            yield return new WaitForFixedUpdate();
        }

        UpdateEnemyTurn();
    }

    public void DorHeal()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Dor;
        StartCoroutine(DorHealEnum());
    }
    IEnumerator DorHealEnum()
    {
        dora.Heal();
        dorAnim.SetTrigger("heal");

        yield return new WaitForSeconds(1.5f);

        while (doraHP.value < dora.currentHP)
        {
            doraHP.value += 0.1f;
            yield return new WaitForFixedUpdate();
        }

        UpdateEnemyTurn();
    }

    public void TamHeal()
    {
        fightBox.SetActive(false);
        lastPlayerAttack = PlayerAttackType.Tam;
        StartCoroutine(TamHealEnum());
    }
    IEnumerator TamHealEnum()
    {
        tamara.Heal();
        tamAnim.SetTrigger("heal");

        yield return new WaitForSeconds(1.5f);

        while (tamaraHP.value < tamara.currentHP)
        {
            tamaraHP.value += 0.1f;
            yield return new WaitForFixedUpdate();
        }

        UpdateEnemyTurn();
    }
}
