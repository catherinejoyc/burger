using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] int healthPoints;

    private void Start()
    {
        hpSlider.maxValue = healthPoints;
        hpSlider.value = healthPoints;
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(UpdateHealthValue(damage));
    }

    IEnumerator UpdateHealthValue(int damage)
    {
        healthPoints -= damage;
        while (hpSlider.value < healthPoints)
        {
            --hpSlider.value;
            yield return new WaitForFixedUpdate();
        }
    }
}
