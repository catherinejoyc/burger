using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;
    public int healFactor = 3;
    public bool isBurger;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }

        return false;
    }

    public bool Heal()
    {
        if (currentHP + healFactor > maxHP)
        {
            currentHP = maxHP;
        }
        else
        {
            currentHP += healFactor;
        }

        return false;
    }
}
