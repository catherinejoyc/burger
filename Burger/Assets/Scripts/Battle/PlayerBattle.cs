using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    //Attack, Animation, Health update (gradual reduction)
    [SerializeField] int vDamage;
    [SerializeField] int dDamage;
    [SerializeField] int tHeal;

    public void ViktoriaAttack(EnemyBattle enemy)
    {
        //animate playerSprite
        //reduce enemy health by attack points (gradual reduction)
        enemy.TakeDamage(vDamage);
    }

    public void DoraAttack(EnemyBattle enemy)
    {
        //animate playerSprite
        //reduce enemy health by attack points OR 30% chance of critical damage (gradual reduction)
    }

    public void TamaraAttack(EnemyBattle enemy)
    {
        //animate playerSprite
        //heal one player
    }
}
