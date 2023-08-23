using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BattleLogic : MonoBehaviour
{

    public Image HealthBarAlly1;
    public float healthAmountAlly1;

    public Image HealthBarAlly2;
    public float healthAmountAlly2;

    public Image HealthBarAlly3;
    public float healthAmountAlly3;

    public Image HealthBarAlly4;
    public float healthAmountAlly4;

    public Image HealthBarEnemy1;
    public float healthAmountEnemy1;

    public Image HealthBarEnemy2;
    public float healthAmountEnemy2;

    public Image HealthBarEnemy3;
    public float healthAmountEnemy3;

    public Image HealthBarEnemy4;
    public float healthAmountEnemy4;


    void Update()
    {

        if (
            healthAmountAlly1 <= 0 
            || healthAmountAlly2 <= 0 
            || healthAmountAlly3 <= 0
            || healthAmountAlly4 <= 0
            || healthAmountEnemy1 <= 0
            || healthAmountEnemy2 <= 0
            || healthAmountEnemy3 <= 0
            || healthAmountEnemy4 <= 0

         )
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            (healthAmountAlly1, HealthBarAlly1) = TakeDamage(20, healthAmountAlly1, HealthBarAlly1);
            (healthAmountAlly2, HealthBarAlly2) = TakeDamage(20, healthAmountAlly2, HealthBarAlly2);
            (healthAmountAlly3, HealthBarAlly3) = TakeDamage(20, healthAmountAlly3, HealthBarAlly3);
            (healthAmountAlly4, HealthBarAlly4) = TakeDamage(20, healthAmountAlly4, HealthBarAlly4);

            (healthAmountEnemy1, HealthBarEnemy1) = TakeDamage(20, healthAmountEnemy1, HealthBarEnemy1);
            (healthAmountEnemy2, HealthBarEnemy2) = TakeDamage(20, healthAmountEnemy2, HealthBarEnemy2);
            (healthAmountEnemy3, HealthBarEnemy3) = TakeDamage(20, healthAmountEnemy3, HealthBarEnemy3);
            (healthAmountEnemy4, HealthBarEnemy4) = TakeDamage(20, healthAmountEnemy4, HealthBarEnemy4); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            (healthAmountAlly1, HealthBarAlly1) = Heal(10, healthAmountAlly1, HealthBarAlly1);
            (healthAmountAlly2, HealthBarAlly2) = Heal(10, healthAmountAlly2, HealthBarAlly2);
            (healthAmountAlly3, HealthBarAlly3) = Heal(10, healthAmountAlly3, HealthBarAlly3);
            (healthAmountAlly4, HealthBarAlly4) = Heal(10, healthAmountAlly4, HealthBarAlly4);

            (healthAmountEnemy1, HealthBarEnemy1) = Heal(10, healthAmountEnemy1, HealthBarEnemy1);
            (healthAmountEnemy2, HealthBarEnemy2) = Heal(10, healthAmountEnemy2, HealthBarEnemy2);
            (healthAmountEnemy3, HealthBarEnemy3) = Heal(10, healthAmountEnemy3, HealthBarEnemy3);
            (healthAmountEnemy4, HealthBarEnemy4) = Heal(10, healthAmountEnemy4, HealthBarEnemy4);
        }
    }

    public Tuple<float, Image> TakeDamage(float damage, float healthAmount, Image healthBar)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;

        return Tuple.Create(healthAmount, healthBar);
    }

    public Tuple<float, Image> Heal(float healingAmount, float healthAmount, Image healthBar)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;

        return Tuple.Create(healthAmount, healthBar);

    }
}
